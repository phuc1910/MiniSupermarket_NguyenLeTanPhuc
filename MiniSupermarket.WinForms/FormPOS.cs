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

        // Quy tắc đổi điểm phải khớp với API: 1 điểm giảm 1.000 đồng.
        private const decimal PointValue = 1000m;
        private bool _updatingRedeemState;
        private int _customerPoints = 0;         // điểm hiện có của khách đang chọn
        private string _lookedUpPhone = string.Empty; // SĐT đã tra cứu (tránh gọi API lặp)

        public FormPOS()
        {
            InitializeComponent();

            // [BUỔI 5] Gắn sự kiện cho các điều khiển của form POS.
            // (File Designer chưa gắn các sự kiện này nên quét mã / bấm THANH TOÁN chưa có tác dụng.)
            // LƯU Ý: nếu bạn đã gắn các sự kiện này bằng Properties -> Events trong Designer
            // thì XÓA 4 dòng dưới đây để tránh một sự kiện chạy hai lần.
            txtBarcode.KeyDown += txtBarcode_KeyDown;
            txtCashReceived.TextChanged += txtCashReceived_TextChanged;
            btnCheckout.Click += btnCheckout_Click;
            btnClearCart.Click += btnClearCart_Click;

            // [TC 47] Tra điểm khách hàng khi nhập xong SĐT (Enter hoặc rời ô), bật/tắt ô "Dùng điểm"
            txtCustomerPhone.KeyDown += txtCustomerPhone_KeyDown;
            txtCustomerPhone.Leave += txtCustomerPhone_Leave;
            txtCustomerPhone.TextChanged += (s, e) => ResetCustomerInfo();
            chkUsePoints.CheckedChanged += (s, e) => RefreshTotals();

            // [BUỔI 5] Phím tắt F9 = THANH TOÁN (nút đang ghi "THANH TOÁN (F9)")
            KeyPreview = true;
            KeyDown += FormPOS_KeyDown;
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

            RefreshTotals();
        }

        // ================== [TC 47] ĐỔI ĐIỂM THƯỞNG TRỪ TIỀN ==================

        private decimal GetSubtotal() => _cart.Sum(x => x.TotalPrice);

        private decimal GetDiscount() => chkUsePoints.Checked ? (int)nudPointsToRedeem.Value * PointValue : 0m;

        // Số tiền khách phải trả = tiền hàng - tiền giảm từ điểm
        private decimal GetPayable() => Math.Max(0m, GetSubtotal() - GetDiscount());

        // Giới hạn theo điểm hiện có và số tiền hàng, không giảm vượt tổng hóa đơn.
        private void UpdateRedeemState()
        {
            _updatingRedeemState = true;
            try
            {
                decimal maxPoints = Math.Min(Math.Max(0, _customerPoints), Math.Floor(GetSubtotal() / PointValue));
                nudPointsToRedeem.Maximum = Math.Max(0, maxPoints);
                nudPointsToRedeem.Value = decimal.Truncate(nudPointsToRedeem.Value);
                bool eligible = maxPoints > 0;
                if (!eligible) chkUsePoints.Checked = false;
                chkUsePoints.Enabled = eligible;
                nudPointsToRedeem.Enabled = eligible && chkUsePoints.Checked;
                if (!chkUsePoints.Checked) nudPointsToRedeem.Value = 0;
            }
            finally { _updatingRedeemState = false; }
        }

        private void nudPointsToRedeem_ValueChanged(object? sender, EventArgs e)
        {
            RefreshTotals();
        }

        private void RefreshTotals()
        {
            if (_updatingRedeemState) return;
            UpdateRedeemState();

            decimal discount = GetDiscount();
            lblTotalAmount.Text = $"{GetPayable():N0} đ";
            lblDiscountInfo.Text = discount > 0 ? $"Đã trừ {discount:N0} đ ({(int)nudPointsToRedeem.Value:N0} điểm)" : string.Empty;
            if (_customerPoints > 0)
                lblCustomerPoints.Text = $"Có {_customerPoints:N0} điểm | Đổi tối đa {nudPointsToRedeem.Maximum:N0} điểm";
            CalculateChange();
        }

        // Đổi SĐT thì thông tin khách cũ không còn đúng -> xóa điểm và bỏ tick
        private void ResetCustomerInfo()
        {
            _customerPoints = 0;
            _lookedUpPhone = string.Empty;
            lblCustomerPoints.Text = string.Empty;
            lblCustomerName.Text = "Chưa chọn khách hàng";
            RefreshTotals();
        }

        private void txtCustomerPhone_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtBarcode.Focus(); // rời ô SĐT -> sự kiện Leave sẽ tự tra cứu khách hàng
            }
        }

        private async void txtCustomerPhone_Leave(object? sender, EventArgs e)
        {
            await LookupCustomerAsync();
        }

        // Tra khách hàng theo SĐT: GET api/customers/search?keyword=... rồi chọn đúng SĐT trùng khớp
        private async Task LookupCustomerAsync()
        {
            string phone = txtCustomerPhone.Text.Trim();
            if (phone.Length == 0 || phone == _lookedUpPhone) return;

            try
            {
                var response = await ApiClientService.Client.GetAsync($"customers/search?keyword={Uri.EscapeDataString(phone)}");
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show(await ReadErrorMessageAsync(response), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using var doc = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
                if (IsDisposed || txtCustomerPhone.Text.Trim() != phone) return;
                foreach (var c in doc.RootElement.EnumerateArray())
                {
                    if (c.GetProperty("phoneNumber").GetString() == phone)
                    {
                        _lookedUpPhone = phone;
                        _customerPoints = c.GetProperty("rewardPoints").GetInt32();
                        lblCustomerName.Text = c.GetProperty("customerName").GetString() ?? string.Empty;
                        lblCustomerPoints.Text = $"Điểm tích lũy: {_customerPoints:N0}";
                        RefreshTotals();
                        return;
                    }
                }

                // Không có khách trùng SĐT: vẫn bán được như khách vãng lai
                lblCustomerName.Text = "Không tìm thấy - tính khách vãng lai";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối máy chủ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCashReceived_TextChanged(object? sender, EventArgs e)
        {
            CalculateChange();
        }

        private void CalculateChange()
        {
            decimal total = GetPayable(); // [TC 47] đã trừ tiền giảm từ điểm
            if (decimal.TryParse(txtCashReceived.Text, out decimal cashReceived))
            {
                decimal change = cashReceived - total;
                bool validCash = cashReceived >= 0 && (total == 0 || cashReceived > total);
                lblChange.Text = validCash ? $"{change:N0} đ" : "Cần đưa lớn hơn tổng!";
                lblChange.ForeColor = validCash ? Color.FromArgb(15, 118, 110) : Color.FromArgb(185, 28, 28);
            }
            else
            {
                lblChange.Text = "0 đ";
                lblChange.ForeColor = Color.FromArgb(22, 54, 90);
            }
        }

        private async void btnCheckout_Click(object? sender, EventArgs e)
        {
            if (_cart.Count == 0)
            {
                MessageBox.Show("Giỏ hàng đang trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            RefreshTotals();
            if (chkUsePoints.Checked && nudPointsToRedeem.Value <= 0)
            {
                MessageBox.Show("Vui lòng nhập số điểm muốn đổi lớn hơn 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudPointsToRedeem.Focus();
                return;
            }

            // Tổng bằng 0 sau đổi điểm thì được nhập tiền khách đưa bằng 0.
            decimal total = GetPayable();
            if (!decimal.TryParse(txtCashReceived.Text, out decimal cashReceived))
            {
                MessageBox.Show("Vui lòng nhập số tiền khách đưa hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCashReceived.Focus();
                txtCashReceived.SelectAll();
                return;
            }
            if (cashReceived < 0 || (total > 0 && cashReceived <= total))
            {
                string message = total == 0 ? "Tiền khách đưa không được âm!" :
                    $"Tiền khách đưa phải lớn hơn tổng cần thanh toán ({total:N0} đ)!";
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCashReceived.Focus();
                txtCashReceived.SelectAll();
                return;
            }

            var orderRequest = new
            {
                CashierUsername = SessionManager.CurrentUsername,
                CustomerPhone = txtCustomerPhone.Text.Trim(),
                CashReceived = cashReceived,
                UsePoints = chkUsePoints.Checked, // [TC 47] máy chủ kiểm tra lại điều kiện và trừ điểm trong Transaction
                PointsToRedeem = chkUsePoints.Checked ? (int)nudPointsToRedeem.Value : 0,
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
                    int pointsRedeemed = root.TryGetProperty("pointsRedeemed", out var pr) ? pr.GetInt32() : 0;
                    decimal discountAmount = root.TryGetProperty("discountAmount", out var da) ? da.GetDecimal() : 0m;

                    string redeemLine = pointsRedeemed > 0
                        ? $"\nĐã dùng {pointsRedeemed} điểm (giảm {discountAmount:N0} đ)"
                        : string.Empty;

                    MessageBox.Show(
                        $"Thanh toán thành công!\n\nMã hóa đơn: {orderCode}\nKhách hàng: {customerName}" + redeemLine + "\n" +
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
