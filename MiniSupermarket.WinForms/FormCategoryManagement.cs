using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using MiniSupermarket.WinForms.Models;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniSupermarket.WinForms
{
    public partial class FormCategoryManagement : Form
    {

        // Khởi tạo HttpClient tĩnh kết nối trực tiếp đến Web API (Đảm bảo số Port https://localhost:7123 khớp với API của bạn)
        private static readonly HttpClient _client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7251/api/")
        };

        // [BUỔI 6] Phân trang phía máy chủ
        private int _currentPage = 1;
        private const int PageSize = 5;
        private readonly PagingBar _paging = new();

        public FormCategoryManagement()
        {
            InitializeComponent();

            dgvCategories.Parent!.Controls.Add(_paging);
            _paging.PrevClicked += async (s, e) => { if (_currentPage > 1) { _currentPage--; await LoadDataAsync(); } };
            _paging.NextClicked += async (s, e) => { if (_currentPage < _paging.TotalPages) { _currentPage++; await LoadDataAsync(); } };
        }

        // Sự kiện Form vừa bật lên: Tự động tải dữ liệu từ API lên bảng
        private async void FormCategoryManagement_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        // [MỚI] Gán tên tiêu đề tiếng Việt + độ rộng cột theo nội dung (Mã ID ngắn -> hẹp,
        // Mô tả dài -> rộng). Tách riêng thành hàm dùng chung để gọi được ở cả LoadDataAsync
        // lẫn btnSearch_Click, tránh lặp code và tránh quên áp dụng khi tìm kiếm.
        private void FormatCategoryGridColumns()
        {
            dgvCategories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvCategories.Columns["CategoryId"] != null)
            {
                dgvCategories.Columns["CategoryId"].HeaderText = "Mã ID";
                dgvCategories.Columns["CategoryId"].FillWeight = 15;
            }
            if (dgvCategories.Columns["CategoryName"] != null)
            {
                dgvCategories.Columns["CategoryName"].HeaderText = "Tên nhóm hàng";
                dgvCategories.Columns["CategoryName"].FillWeight = 35;
            }
            if (dgvCategories.Columns["Description"] != null)
            {
                dgvCategories.Columns["Description"].HeaderText = "Mô tả";
                dgvCategories.Columns["Description"].FillWeight = 50;
            }
        }

        // Ví dụ áp dụng khi gọi hàm tải dữ liệu LoadDataAsync():
        private async Task LoadDataAsync()
        {
            try
            {
                // [BUỔI 6] Gọi API phân trang: GET /api/categories/paged
                string url = $"categories/paged?keyword={Uri.EscapeDataString(txtKeyword.Text.Trim())}&pageNumber={_currentPage}&pageSize={PageSize}";
                var result = await ApiClientService.Client.GetFromJsonAsync<PagedViewResult<CategoryDto>>(url);
                if (result == null) return;

                if (result.Items.Count == 0 && result.CurrentPage > 1 && result.TotalPages > 0)
                {
                    _currentPage = result.TotalPages;
                    await LoadDataAsync();
                    return;
                }

                _currentPage = result.CurrentPage;
                dgvCategories.DataSource = result.Items;
                FormatCategoryGridColumns();
                _paging.UpdateState(result.CurrentPage, result.TotalPages, result.TotalItems);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi quyền truy cập hoặc mất kết nối: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        // Nút Tải lại dữ liệu (Refresh)
        private async void btnLoad_Click(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        // Sự kiện khi click vào một dòng trên DataGridView: Đưa dữ liệu lên các ô nhập (TextBox) để chuẩn bị Sửa/Xóa
        private void dgvCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var row = dgvCategories.Rows[e.RowIndex];

            if (row.DataBoundItem is CategoryDto category)
            {
                txtId.Text = category.CategoryId.ToString();
                txtCategoryName.Text = category.CategoryName;
                txtDescription.Text = category.Description ?? string.Empty;
            }
        }

        // Nút THÊM MỚI (CREATE): Gửi dữ liệu POST lên Web API
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var newCat = new
            {
                CategoryName = txtCategoryName.Text,
                Description = txtDescription.Text
            };

            // Gửi request POST kèm theo đối tượng dạng JSON
            // Sử dụng client đã gắn JWT Token
            using var client = GetAuthenticatedClient();

            // Gửi request POST kèm Token
            var response = await client.PostAsJsonAsync("categories", newCat);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Thêm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync(); // Tải lại danh sách mới
                ClearInputs();         // Xóa sạch ô nhập
            }
            else
            {
                MessageBox.Show("Thêm mới thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Nút CẬP NHẬT (UPDATE): Gửi dữ liệu PUT lên Web API theo ID
        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Vui lòng chọn nhóm hàng cần sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = int.Parse(txtId.Text);
            var updateCat = new
            {
                CategoryId = id,
                CategoryName = txtCategoryName.Text,
                Description = txtDescription.Text
            };

            // Sử dụng client đã gắn JWT Token
            using var client = GetAuthenticatedClient();

            // Gửi request PUT kèm Token
            var response = await client.PutAsJsonAsync($"categories/{id}", updateCat);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync();
                ClearInputs();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Nút XÓA (DELETE): Gửi request DELETE lên Web API theo ID
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Vui lòng chọn nhóm hàng cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = int.Parse(txtId.Text);
            var confirm = MessageBox.Show($"Bạn có chắc muốn xóa nhóm hàng ID = {id}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                // Sử dụng client đã gắn JWT Token
                using var client = GetAuthenticatedClient();

                // Gửi request DELETE kèm Token
                var response = await client.DeleteAsync($"categories/{id}");
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadDataAsync();
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        // Nút TÌM KIẾM (SEARCH): Gọi API lọc danh mục theo từ khóa Query String
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            // Tìm kiếm từ khóa mới -> luôn quay về trang 1 rồi gọi lại API phân trang
            _currentPage = 1;
            await LoadDataAsync();
        }

        // Bổ sung phương thức cấu hình HttpClient có gắn kèm Token bảo mật
        private HttpClient GetAuthenticatedClient()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7251/api/")
            };

            // Đính kèm Token vào Header theo chuẩn Bearer Authentication
            if (!string.IsNullOrEmpty(SessionManager.JwtToken))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SessionManager.JwtToken);
            }
            return client;
        }


        // Hàm phụ trợ: Xóa trắng các ô nhập liệu sau khi thao tác xong
        private void ClearInputs()
        {
            txtId.Text = "";
            txtCategoryName.Text = "";
            txtDescription.Text = "";
        }
    }

    // Lớp DTO trung gian tại Client hứng dữ liệu JSON trả về từ Server
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}