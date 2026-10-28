using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using MiniSupermarket.WinForms.Models;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniSupermarket.WinForms
{
    public partial class FormCustomerManagement : Form
    {
        // ============================================================
        // KHỞI TẠO HTTP CLIENT
        // ============================================================
        // HttpClient dùng để kết nối trực tiếp đến Web API.
        // Port 7251 phải trùng với port của project MiniSupermarket.API.
        private static readonly HttpClient _client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7251/api/")
        };

        // ============================================================
        // CONSTRUCTOR
        // ============================================================
        // [BUỔI 6] Phân trang phía máy chủ
        private int _currentPage = 1;
        private const int PageSize = 5;
        private readonly PagingBar _paging = new();

        public FormCustomerManagement()
        {
            InitializeComponent();

            dgvCustomers.Parent!.Controls.Add(_paging);
            _paging.PrevClicked += async (s, e) => { if (_currentPage > 1) { _currentPage--; await LoadDataAsync(); } };
            _paging.NextClicked += async (s, e) => { if (_currentPage < _paging.TotalPages) { _currentPage++; await LoadDataAsync(); } };
        }

        // ============================================================
        // SỰ KIỆN KHI FORM ĐƯỢC MỞ
        // ============================================================
        // Khi Form vừa mở lên, tự động gọi API để
        // tải danh sách khách hàng lên DataGridView.
        private async void FormCustomerManagement_Load(
            object sender,
            EventArgs e)
        {
            await LoadDataAsync();
        }

        // [MỚI] Gán tiêu đề tiếng Việt + độ rộng cột theo nội dung (Mã KH/Điểm/Hạng ngắn -> hẹp,
        // Địa chỉ dài -> rộng). Tách riêng thành hàm dùng chung để gọi được ở cả LoadDataAsync
        // lẫn btnSearch_Click, tránh lặp code và tránh quên áp dụng khi tìm kiếm.
        private void FormatCustomerGridColumns()
        {
            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvCustomers.Columns["CustomerId"] != null) { dgvCustomers.Columns["CustomerId"].HeaderText = "Mã KH"; dgvCustomers.Columns["CustomerId"].FillWeight = 10; }
            if (dgvCustomers.Columns["CustomerName"] != null) { dgvCustomers.Columns["CustomerName"].HeaderText = "Họ và tên"; dgvCustomers.Columns["CustomerName"].FillWeight = 25; }
            if (dgvCustomers.Columns["PhoneNumber"] != null) { dgvCustomers.Columns["PhoneNumber"].HeaderText = "Số điện thoại"; dgvCustomers.Columns["PhoneNumber"].FillWeight = 18; }
            if (dgvCustomers.Columns["Address"] != null) { dgvCustomers.Columns["Address"].HeaderText = "Địa chỉ"; dgvCustomers.Columns["Address"].FillWeight = 27; }
            if (dgvCustomers.Columns["RewardPoints"] != null) { dgvCustomers.Columns["RewardPoints"].HeaderText = "Điểm"; dgvCustomers.Columns["RewardPoints"].FillWeight = 10; }
            if (dgvCustomers.Columns["MembershipRank"] != null) { dgvCustomers.Columns["MembershipRank"].HeaderText = "Hạng"; dgvCustomers.Columns["MembershipRank"].FillWeight = 10; }
        }

        // ==============================
        // LOAD DANH SÁCH KHÁCH HÀNG
        // ==============================
        private async Task LoadDataAsync()
        {
            try
            {
                // [BUỔI 6] Gọi API phân trang: GET /api/customers/paged (sắp xếp giảm dần theo điểm thưởng)
                string url = $"customers/paged?keyword={Uri.EscapeDataString(txtKeyword.Text.Trim())}&pageNumber={_currentPage}&pageSize={PageSize}";
                var result = await ApiClientService.Client.GetFromJsonAsync<PagedViewResult<CustomerDto>>(url);
                if (result == null) return;

                // Xóa dòng cuối của trang cuối -> lùi về trang trước
                if (result.Items.Count == 0 && result.CurrentPage > 1 && result.TotalPages > 0)
                {
                    _currentPage = result.TotalPages;
                    await LoadDataAsync();
                    return;
                }

                _currentPage = result.CurrentPage;
                dgvCustomers.AutoGenerateColumns = true;
                dgvCustomers.DataSource = null;
                dgvCustomers.DataSource = result.Items;
                FormatCustomerGridColumns();
                _paging.UpdateState(result.CurrentPage, result.TotalPages, result.TotalItems);
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("Không thể kết nối đến Web API!\n\n" + ex.Message, "Lỗi kết nối",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // ============================================================
        // SỰ KIỆN CLICK VÀO MỘT DÒNG TRONG DATAGRIDVIEW
        // ============================================================
        // Khi người dùng click vào một khách hàng,
        // dữ liệu của khách hàng đó sẽ được đưa lên các TextBox.
        // Sau đó có thể sử dụng để Sửa hoặc Xóa.
        private void dgvCustomers_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            // Không xử lý nếu click vào phần tiêu đề cột.
            if (e.RowIndex < 0)
                return;

            // Lấy dòng hiện tại.
            var row = dgvCustomers.Rows[e.RowIndex];

            // Kiểm tra dữ liệu của dòng có phải CustomerDto hay không.
            if (row.DataBoundItem is CustomerDto customer)
            {
                // Hiển thị mã khách hàng.
                txtCustomerId.Text =
                    customer.CustomerId.ToString();

                // Hiển thị tên khách hàng.
                txtCustomerName.Text =
                    customer.CustomerName;

                // Hiển thị số điện thoại.
                txtPhoneNumber.Text =
                    customer.PhoneNumber;

                // Hiển thị địa chỉ.
                txtAddress.Text =
                    customer.Address ?? string.Empty;

                // Hiển thị điểm tích lũy.
                txtRewardPoints.Text =
                    customer.RewardPoints.ToString();

                // Hiển thị hạng thành viên.
                txtMembershipRank.Text =
                    customer.MembershipRank;
            }
        }

        // ============================================================
        // NÚT TẢI LẠI DỮ LIỆU (REFRESH)
        // ============================================================
        // Khi click nút "Tải lại", gọi API để lấy
        // danh sách khách hàng mới nhất.
        private async void btnLoad_Click(
            object sender,
            EventArgs e)
        {
            await LoadDataAsync();
        }

        // ============================================================
        // NÚT THÊM KHÁCH HÀNG (CREATE)
        // ============================================================
        // Gửi request POST lên Web API để thêm khách hàng mới.
        private async void btnAdd_Click(
            object sender,
            EventArgs e)
        {
            // Kiểm tra tên khách hàng.
            if (string.IsNullOrWhiteSpace(txtCustomerName.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập tên khách hàng!",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Kiểm tra số điện thoại.
            if (string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập số điện thoại!",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Tạo object khách hàng mới.
            // Không cần truyền CustomerId vì ID được Database tự tăng.
            var newCustomer = new
            {
                CustomerName =
                    txtCustomerName.Text.Trim(),

                PhoneNumber =
                    txtPhoneNumber.Text.Trim(),

                Address =
                    txtAddress.Text.Trim(),

                RewardPoints =
                    int.TryParse(
                        txtRewardPoints.Text,
                        out int points)
                        ? points
                        : 0,

                MembershipRank =
                    string.IsNullOrWhiteSpace(
                        txtMembershipRank.Text)
                        ? "Chuẩn"
                        : txtMembershipRank.Text.Trim()
            };

            try
            {
                // Sử dụng client đã gắn JWT Token.
                using var client = GetAuthenticatedClient();

                // Gửi request POST:
                // POST: api/customers
                //
                // PostAsJsonAsync sẽ tự động chuyển object
                // newCustomer thành JSON.
                var response =
                    await client.PostAsJsonAsync(
                        "customers",
                        newCustomer);

                // Kiểm tra API trả về thành công.
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show(
                        "Thêm khách hàng thành công!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // Tải lại danh sách.
                    await LoadDataAsync();

                    // Xóa dữ liệu trên Form.
                    ClearInputs();
                }
                else
                {
                    // Nếu API trả về lỗi như 400, 401, 403...
                    MessageBox.Show(
                        "Thêm khách hàng thất bại!\nMã lỗi: "
                        + response.StatusCode,
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // Bắt lỗi kết nối hoặc lỗi HTTP.
                MessageBox.Show(
                    "Lỗi: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // NÚT CẬP NHẬT KHÁCH HÀNG (UPDATE)
        // ============================================================
        // Gửi request PUT lên API theo CustomerId.
        private async void btnUpdate_Click(
            object sender,
            EventArgs e)
        {
            // Kiểm tra người dùng đã chọn khách hàng hay chưa.
            if (!int.TryParse(
                txtCustomerId.Text,
                out int id))
            {
                MessageBox.Show(
                    "Vui lòng chọn khách hàng cần sửa!",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Kiểm tra tên khách hàng.
            if (string.IsNullOrWhiteSpace(txtCustomerName.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập tên khách hàng!",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Kiểm tra số điện thoại.
            if (string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập số điện thoại!",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Tạo object chứa dữ liệu cần cập nhật.
            var updateCustomer = new
            {
                CustomerId = id,

                CustomerName =
                    txtCustomerName.Text.Trim(),

                PhoneNumber =
                    txtPhoneNumber.Text.Trim(),

                Address =
                    txtAddress.Text.Trim(),

                RewardPoints =
                    int.TryParse(
                        txtRewardPoints.Text,
                        out int points)
                        ? points
                        : 0,

                MembershipRank =
                    string.IsNullOrWhiteSpace(
                        txtMembershipRank.Text)
                        ? "Chuẩn"
                        : txtMembershipRank.Text.Trim()
            };

            try
            {
                // Sử dụng client đã gắn JWT Token.
                using var client = GetAuthenticatedClient();

                // Gửi request PUT:
                // PUT: api/customers/{id}
                var response =
                    await client.PutAsJsonAsync(
                        $"customers/{id}",
                        updateCustomer);

                // Kiểm tra kết quả.
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show(
                        "Cập nhật khách hàng thành công!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // Tải lại danh sách.
                    await LoadDataAsync();

                    // Xóa dữ liệu trên Form.
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show(
                        "Cập nhật thất bại!\nMã lỗi: "
                        + response.StatusCode,
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // NÚT XÓA KHÁCH HÀNG (DELETE)
        // ============================================================
        // Gửi request DELETE lên API theo CustomerId.
        private async void btnDelete_Click(
            object sender,
            EventArgs e)
        {
            // Kiểm tra đã chọn khách hàng hay chưa.
            if (!int.TryParse(
                txtCustomerId.Text,
                out int id))
            {
                MessageBox.Show(
                    "Vui lòng chọn khách hàng cần xóa!",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Hiển thị hộp thoại xác nhận trước khi xóa.
            var confirm = MessageBox.Show(
                $"Bạn có chắc muốn xóa khách hàng ID = {id}?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            // Nếu chọn No thì không thực hiện xóa.
            if (confirm != DialogResult.Yes)
                return;

            try
            {
                // Sử dụng client đã gắn JWT Token.
                using var client = GetAuthenticatedClient();

                // Gửi request DELETE:
                // DELETE: api/customers/{id}
                var response =
                    await client.DeleteAsync(
                        $"customers/{id}");

                // Kiểm tra API trả về thành công.
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show(
                        "Xóa khách hàng thành công!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // Tải lại danh sách.
                    await LoadDataAsync();

                    // Xóa dữ liệu trên Form.
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show(
                        "Xóa khách hàng thất bại!\nMã lỗi: "
                        + response.StatusCode,
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // NÚT TÌM KIẾM KHÁCH HÀNG (SEARCH)
        // ============================================================
        // Gửi keyword lên API để tìm kiếm khách hàng.
        private async void btnSearch_Click(
            object sender,
            EventArgs e)
        {
            // Tìm kiếm từ khóa mới -> luôn quay về trang 1 rồi gọi lại API phân trang
            _currentPage = 1;
            await LoadDataAsync();
        }

        // ============================================================
        // TẠO HTTP CLIENT CÓ GẮN JWT TOKEN
        // ============================================================
        // API của bạn đang sử dụng JWT Authentication.
        // Vì vậy mỗi request cần gửi Token trong Authorization Header.
        private HttpClient GetAuthenticatedClient()
        {
            var client = new HttpClient
            {
                BaseAddress =
                    new Uri("https://localhost:7251/api/")
            };

            // Kiểm tra SessionManager có Token hay không.
            if (!string.IsNullOrEmpty(
                SessionManager.JwtToken))
            {
                // Gắn JWT Token vào Header:
                //
                // Authorization: Bearer <token>
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue(
                        "Bearer",
                        SessionManager.JwtToken);
            }

            return client;
        }

        // ============================================================
        // XÓA TRẮNG CÁC Ô NHẬP LIỆU
        // ============================================================
        // Được gọi sau khi Thêm / Sửa / Xóa thành công.
        private void ClearInputs()
        {
            // Xóa mã khách hàng.
            txtCustomerId.Text = "";

            // Xóa tên khách hàng.
            txtCustomerName.Text = "";

            // Xóa số điện thoại.
            txtPhoneNumber.Text = "";

            // Xóa địa chỉ.
            txtAddress.Text = "";

            // Đưa điểm tích lũy về 0.
            txtRewardPoints.Text = "0";

            // Đưa hạng thành viên về Chuẩn.
            txtMembershipRank.Text = "Chuẩn";
        }
    }

    // ================================================================
    // DTO KHÁCH HÀNG
    // ================================================================
    // DTO dùng ở WinForms để nhận dữ liệu JSON
    // trả về từ Web API.
    public class CustomerDto
    {
        // Mã khách hàng.
        public int CustomerId { get; set; }

        // Tên khách hàng.
        public string CustomerName { get; set; }
            = string.Empty;

        // Số điện thoại.
        public string PhoneNumber { get; set; }
            = string.Empty;

        // Địa chỉ.
        public string? Address { get; set; }

        // Điểm tích lũy.
        public int RewardPoints { get; set; }

        // Hạng thành viên.
        public string MembershipRank { get; set; }
            = "Chuẩn";
    }
}