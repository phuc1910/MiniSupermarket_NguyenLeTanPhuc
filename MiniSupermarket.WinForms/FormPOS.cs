using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using MiniSupermarket.WinForms.Models;

namespace MiniSupermarket.WinForms
{
    public partial class FormPOS : Form
    {
        private readonly List<CartItemDto> _cart = new();

        public FormPOS()
        {
            InitializeComponent();
            SetupCartGrid();

            // [BUỔI 5] Gắn sự kiện cho các điều khiển của form POS.
            // (File Designer chưa gắn các sự kiện này nên quét mã / bấm THANH TOÁN chưa có tác dụng.)
            // LƯU Ý: nếu bạn đã gắn các sự kiện này bằng Properties -> Events trong Designer
            // thì XÓA 4 dòng dưới đây để tránh một sự kiện chạy hai lần.
            txtBarcode.KeyDown += txtBarcode_KeyDown;
            txtCashReceived.TextChanged += txtCashReceived_TextChanged;
            btnCheckout.Click += btnCheckout_Click;
            btnClearCart.Click += btnClearCart_Click;

            // [BUỔI 5] Phím tắt F9 = THANH TOÁN (nút đang ghi "THANH TOÁN (F9)")
            KeyPreview = true;
            KeyDown += FormPOS_KeyDown;
        }

        private void SetupCartGrid()
        {
            dgvCart.AutoGenerateColumns = false;

            // [SỬA] Dùng FillWeight thay cho Width cố định: lưới đang ở chế độ
            // AutoSizeColumnsMode = Fill (khai báo trong Designer) nên Width tĩnh bị bỏ qua.
            // FillWeight quyết định tỉ lệ chia không gian: cột ngắn (Mã SP, SL) hẹp,
            // cột dài (Tên Sản Phẩm) rộng nhất, vẫn lấp đầy hết chiều rộng khung giỏ hàng.
            dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCart.Columns.Clear();
            dgvCart.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ProductId", HeaderText = "Mã SP", FillWeight = 12 });
            dgvCart.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ProductName", HeaderText = "Tên Sản Phẩm", FillWeight = 38 });
            dgvCart.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "UnitPrice", HeaderText = "Đơn Giá", FillWeight = 20 });
            dgvCart.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Quantity", HeaderText = "SL", FillWeight = 10 });
            dgvCart.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TotalPrice", HeaderText = "Thành Tiền", FillWeight = 20 });
        }

        // Bắt sự kiện quét mã Barcode
        private async void txtBarcode_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrWhiteSpace(txtBarcode.Text))
            {
                string barcode = txtBarcode.Text.Trim();
                txtBarcode.Clear();
                await AddProductToCartByBarcodeAsync(barcode);
            }
        }

        private async Task AddProductToCartByBarcodeAsync(string barcode)
        {
            try
            {
                // [BUỔI 5] Gọi API tra cứu: GET api/Products/barcode/{barcode}
                // Dùng GetAsync để đọc được mã trạng thái (GetFromJsonAsync sẽ ném lỗi khi 404)
                var response = await ApiClientService.Client.GetAsync($"products/barcode/{Uri.EscapeDataString(barcode)}");

                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    MessageBox.Show($"Không tìm thấy sản phẩm có mã vạch: {barcode}", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show(await ReadErrorMessageAsync(response), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var product = await response.Content.ReadFromJsonAsync<ProductDto>();
                if (product == null)
                {
                    MessageBox.Show("Không đọc được dữ liệu sản phẩm từ máy chủ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var existingItem = _cart.FirstOrDefault(c => c.ProductId == product.ProductId);
                int newQuantity = (existingItem?.Quantity ?? 0) + 1;

                // [BUỔI 5] Chặn sớm nếu vượt tồn kho (máy chủ vẫn kiểm tra lại khi thanh toán)
                if (newQuantity > product.StockQuantity)
                {
                    MessageBox.Show($"'{product.ProductName}' chỉ còn {product.StockQuantity} trong kho!", "Không đủ tồn kho", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (existingItem != null)
                {
                    existingItem.Quantity++;
                }
                else
                {
                    _cart.Add(new CartItemDto
                    {
                        ProductId = product.ProductId,
                        ProductName = product.ProductName,
                        UnitPrice = product.Price,
                        Quantity = 1
                    });
                }

                UpdateCartDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối máy chủ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Trả con trỏ về ô mã vạch để quét món tiếp theo
                txtBarcode.Focus();
            }
        }

        private void UpdateCartDisplay()
        {
            dgvCart.DataSource = null;
            dgvCart.DataSource = _cart;

            decimal total = _cart.Sum(x => x.TotalPrice);
            lblTotalAmount.Text = $"{total:N0} đ";
            CalculateChange();
        }

        private void txtCashReceived_TextChanged(object? sender, EventArgs e)
        {
            CalculateChange();
        }

        private void CalculateChange()
        {
            decimal total = _cart.Sum(x => x.TotalPrice);
            if (decimal.TryParse(txtCashReceived.Text, out decimal cashReceived))
            {
                decimal change = cashReceived - total;
                lblChange.Text = change >= 0 ? $"{change:N0} đ" : "Chưa đủ tiền!";
                lblChange.ForeColor = change >= 0 ? Color.Black : Color.Red;
            }
            else
            {
                lblChange.Text = "0 đ";
            }
        }

        private async void btnCheckout_Click(object? sender, EventArgs e)
        {
            if (_cart.Count == 0)
            {
                MessageBox.Show("Giỏ hàng đang trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // [BUỔI 5] Nếu đã nhập tiền khách đưa thì phải đủ tiền mới cho thanh toán
            decimal total = _cart.Sum(x => x.TotalPrice);
            if (decimal.TryParse(txtCashReceived.Text, out decimal cashReceived) && cashReceived < total)
            {
                MessageBox.Show("Tiền khách đưa chưa đủ để thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var orderRequest = new
            {
                CashierUsername = SessionManager.CurrentUsername,
                CustomerPhone = txtCustomerPhone.Text.Trim(),
                Items = _cart.Select(i => new { i.ProductId, i.Quantity, i.UnitPrice }).ToList()
            };

            // [BUỔI 5] Khóa nút trong lúc chờ máy chủ: bấm đúp sẽ tạo ra 2 hóa đơn
            btnCheckout.Enabled = false;
            try
            {
                // Gọi API: POST api/orders/checkout (giao dịch SqlTransaction ở phía máy chủ)
                var response = await ApiClientService.Client.PostAsJsonAsync("orders/checkout", orderRequest);

                if (response.IsSuccessStatusCode)
                {
                    // Đọc kết quả máy chủ trả về để hiển thị cho thu ngân
                    string json = await response.Content.ReadAsStringAsync();
                    using var doc = JsonDocument.Parse(json);
                    var root = doc.RootElement;

                    string orderCode = root.GetProperty("orderCode").GetString() ?? string.Empty;
                    string customerName = root.GetProperty("customerName").GetString() ?? "Khách vãng lai";
                    decimal finalAmount = root.GetProperty("finalAmount").GetDecimal();
                    int points = root.GetProperty("rewardPointsAdded").GetInt32();

                    MessageBox.Show(
                        $"Thanh toán thành công!\n\nMã hóa đơn: {orderCode}\nKhách hàng: {customerName}\n" +
                        $"Tổng tiền: {finalAmount:N0} đ\nĐiểm thưởng cộng thêm: {points}",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _cart.Clear();
                    UpdateCartDisplay();
                    txtCashReceived.Clear();
                    txtCustomerPhone.Clear();
                    lblCustomerName.Text = "Khách vãng lai";
                }
                else
                {
                    // [BUỔI 5] Hiện đúng nguyên nhân (hết hàng, lệch giá...) thay vì câu chung chung.
                    // Giỏ hàng được GIỮ NGUYÊN vì máy chủ đã Rollback, thu ngân sửa rồi thanh toán lại.
                    MessageBox.Show("Thanh toán thất bại!\n\n" + await ReadErrorMessageAsync(response),
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối máy chủ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnCheckout.Enabled = true;
                txtBarcode.Focus();
            }
        }

        // [BUỔI 5] Nút HỦY GIỎ HÀNG
        private void btnClearCart_Click(object? sender, EventArgs e)
        {
            if (_cart.Count == 0) return;

            var confirm = MessageBox.Show("Bạn có chắc muốn xóa toàn bộ giỏ hàng?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                _cart.Clear();
                UpdateCartDisplay();
                txtBarcode.Focus();
            }
        }

        // [BUỔI 5] Phím tắt F9 = THANH TOÁN
        private void FormPOS_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                e.Handled = true;
                btnCheckout.PerformClick();
            }
        }

        // [BUỔI 5] Đổi phản hồi lỗi của API thành câu thông báo dễ hiểu
        // API trả JSON dạng { "message": "...", "errorDetail": "..." }
        private static async Task<string> ReadErrorMessageAsync(HttpResponseMessage response)
        {
            if (response.StatusCode == HttpStatusCode.Unauthorized)
                return "Phiên đăng nhập đã hết hạn, vui lòng đăng nhập lại!";

            if (response.StatusCode == HttpStatusCode.Forbidden)
                return "Tài khoản của bạn không có quyền thực hiện thao tác này!";

            try
            {
                string json = await response.Content.ReadAsStringAsync();
                using var doc = JsonDocument.Parse(json);

                string message = doc.RootElement.TryGetProperty("message", out var m) ? m.GetString() ?? "" : "";
                string detail = doc.RootElement.TryGetProperty("errorDetail", out var d) ? d.GetString() ?? "" : "";

                string result = string.IsNullOrEmpty(detail) ? message : $"{message}\n\n{detail}";
                if (!string.IsNullOrWhiteSpace(result)) return result;
            }
            catch
            {
                // Phản hồi không phải JSON: dùng thông báo mặc định bên dưới
            }

            return $"Máy chủ trả về lỗi {(int)response.StatusCode}.";
        }
    }

    public class CartItemDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice => UnitPrice * Quantity;
    }
}