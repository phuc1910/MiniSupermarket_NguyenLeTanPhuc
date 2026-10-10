using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniSupermarket.WinForms.Models;

namespace MiniSupermarket.WinForms
{
    public partial class FormProductManagement : Form
    {
        public FormProductManagement()
        {
            InitializeComponent();
        }

        // Khi form mở: nạp danh mục trước, rồi nạp sản phẩm
        private async void FormProductManagement_Load(object sender, EventArgs e)
        {
            await LoadCategoriesToComboAsync();
            await LoadProductsAsync();
        }

        // ================== HÀM HỖ TRỢ ==================

        // [MỚI] Hiển thị lỗi chi tiết từ API (mã HTTP + message do server trả về)
        // Giúp biết rõ vì sao thất bại: 400 (dữ liệu sai), 401 (chưa đăng nhập),
        // 403 (không phải Admin), 409 (trùng mã vạch / sản phẩm đã có hóa đơn)...
        private async Task ShowApiErrorAsync(HttpResponseMessage res, string action)
        {
            string body = await res.Content.ReadAsStringAsync();
            string detail = res.StatusCode switch
            {
                System.Net.HttpStatusCode.Unauthorized => "Chưa đăng nhập hoặc phiên đã hết hạn.",
                System.Net.HttpStatusCode.Forbidden => "Bạn không có quyền Admin để thực hiện thao tác này.",
                _ => body
            };

            MessageBox.Show(
                $"{action} thất bại ({(int)res.StatusCode}):\n{detail}",
                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // [MỚI] Kiểm tra dữ liệu nhập trước khi gửi lên API
        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtBarcode.Text))
            {
                MessageBox.Show("Vui lòng nhập mã vạch!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBarcode.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProductName.Focus();
                return false;
            }
            // Danh mục rỗng (nạp thất bại) thì SelectedValue = null -> tránh lỗi ép kiểu
            if (cboCategory.SelectedValue == null)
            {
                MessageBox.Show("Chưa có nhóm hàng để chọn. Hãy bấm Tải lại hoặc kiểm tra đăng nhập!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        // ================== NẠP DỮ LIỆU ==================

        private async Task LoadCategoriesToComboAsync()
        {
            try
            {
                var categories = await ApiClientService.Client.GetFromJsonAsync<List<CategoryDto>>("categories")
                                 ?? new List<CategoryDto>();

                // --- Combo dùng cho Thêm/Sửa ---
                // Gán DisplayMember/ValueMember TRƯỚC DataSource để tránh lỗi SelectedValue
                cboCategory.DisplayMember = "CategoryName";
                cboCategory.ValueMember = "CategoryId";
                cboCategory.DataSource = categories;

                // --- [MỚI] Combo dùng cho Lọc ---
                // Dùng một List RIÊNG (copy), nếu dùng chung list thì 2 combo sẽ đổi lựa chọn theo nhau
                var filterList = new List<CategoryDto>(categories);
                // Thêm mục "Tất cả" (Id = 0) ở đầu để không lọc theo nhóm hàng
                filterList.Insert(0, new CategoryDto { CategoryId = 0, CategoryName = "-- Tất cả --" });

                cboFilterCategory.DisplayMember = "CategoryName";
                cboFilterCategory.ValueMember = "CategoryId";
                cboFilterCategory.DataSource = filterList;
            }
            catch (HttpRequestException ex)
            {
                // Hiện rõ mã lỗi (401, 403, 404...) để dễ chẩn đoán
                MessageBox.Show(
                    $"Lỗi nạp danh mục: {(ex.StatusCode.HasValue ? ((int)ex.StatusCode.Value).ToString() : "Không kết nối được")} - {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nạp danh mục: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút Tải lại: nạp lại danh mục + sản phẩm và xóa bộ lọc
        private async void btnLoad_Click(object sender, EventArgs e)
        {
            txtSearchBarcode.Clear();
            await LoadCategoriesToComboAsync();
            await LoadProductsAsync();
        }

        private async Task LoadProductsAsync()
        {
            try
            {
                var products = await ApiClientService.Client.GetFromJsonAsync<List<ProductDto>>("products");
                dgvProducts.DataSource = products;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nạp sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================== CHỌN DÒNG TRÊN BẢNG ==================

        // Click vào dòng -> đưa dữ liệu lên các ô nhập
        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // [SỬA] Lấy trực tiếp đối tượng ProductDto thay vì đọc theo tên cột
            // (an toàn hơn, không lỗi nếu tên cột thay đổi)
            if (dgvProducts.Rows[e.RowIndex].DataBoundItem is ProductDto p)
            {
                txtId.Text = p.ProductId.ToString();
                txtBarcode.Text = p.Barcode;
                txtProductName.Text = p.ProductName;
                nudPrice.Value = p.Price;
                nudStock.Value = p.StockQuantity;

                // [MỚI] Chọn đúng nhóm hàng của sản phẩm trong combo
                cboCategory.SelectedValue = p.CategoryId;
            }
        }

        // ================== THÊM / SỬA / XÓA ==================

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            try
            {
                var newProd = new
                {
                    Barcode = txtBarcode.Text.Trim(),
                    ProductName = txtProductName.Text.Trim(),
                    Price = nudPrice.Value,
                    StockQuantity = (int)nudStock.Value,
                    CategoryId = (int)cboCategory.SelectedValue!
                };

                var res = await ApiClientService.Client.PostAsJsonAsync("products", newProd);
                if (res.IsSuccessStatusCode)
                {
                    MessageBox.Show("Thêm mới sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadProductsAsync();
                    ClearInputs();
                }
                else
                {
                    // [MỚI] Báo lỗi khi API từ chối (trước đây im lặng)
                    await ShowApiErrorAsync(res, "Thêm mới");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var products = await ApiClientService.Client.GetFromJsonAsync<List<ProductDto>>("products");
                if (products == null) return;

                // Lọc theo mã vạch
                string barcode = txtSearchBarcode.Text.Trim();
                if (!string.IsNullOrWhiteSpace(barcode))
                {
                    // [SỬA] Thêm kiểm tra null cho Barcode để tránh NullReferenceException
                    products = products
                        .Where(p => p.Barcode != null && p.Barcode.Contains(barcode))
                        .ToList();
                }

                // Lọc theo nhóm hàng
                // [SỬA] categoryId > 0: mục "-- Tất cả --" (Id = 0) sẽ không lọc
                if (cboFilterCategory.SelectedValue != null &&
                    int.TryParse(cboFilterCategory.SelectedValue.ToString(), out int categoryId) &&
                    categoryId > 0)
                {
                    products = products
                        .Where(p => p.CategoryId == categoryId)
                        .ToList();
                }

                dgvProducts.DataSource = products;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            // [SỬA] Báo người dùng khi chưa chọn sản phẩm (trước đây return im lặng)
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidateInputs()) return;

            try
            {
                int id = int.Parse(txtId.Text);

                var updateProd = new
                {
                    ProductId = id,
                    Barcode = txtBarcode.Text.Trim(),
                    ProductName = txtProductName.Text.Trim(),
                    Price = nudPrice.Value,
                    StockQuantity = (int)nudStock.Value,
                    CategoryId = (int)cboCategory.SelectedValue!
                };

                var res = await ApiClientService.Client.PutAsJsonAsync($"products/{id}", updateProd);
                if (res.IsSuccessStatusCode)
                {
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadProductsAsync();
                    ClearInputs();
                }
                else
                {
                    await ShowApiErrorAsync(res, "Cập nhật");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = int.Parse(txtId.Text);

            if (MessageBox.Show($"Xác nhận xóa sản phẩm ID = {id}?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                var res = await ApiClientService.Client.DeleteAsync($"products/{id}");
                if (res.IsSuccessStatusCode)
                {
                    MessageBox.Show("Đã xóa sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadProductsAsync();
                    ClearInputs();
                }
                else
                {
                    // Ví dụ 409: "Không thể xóa sản phẩm đã có trong hóa đơn!"
                    await ShowApiErrorAsync(res, "Xóa");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xóa trắng các ô nhập liệu
        private void ClearInputs()
        {
            txtId.Clear();
            txtBarcode.Clear();
            txtProductName.Clear();
            nudPrice.Value = 0;
            nudStock.Value = 0;
        }
    }
}