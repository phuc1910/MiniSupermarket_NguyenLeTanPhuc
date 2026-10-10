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

namespace MiniSupermarket.WinForms
{
    public partial class FormUserManagement : Form
    {
        private int _selectedUserId = 0;

        public FormUserManagement()
        {
            InitializeComponent();

            // Danh sách vai trò
            cboRole.Items.AddRange(new string[]
            {
                "Admin",
                "Cashier",
                "Warehouse"
            });

            cboRole.SelectedIndex = 1;
        }

        private async void FormUserManagement_Load(object sender, EventArgs e)
        {
            await LoadUsersAsync();
        }

        // =========================
        // LOAD DANH SÁCH USER
        // =========================
        private async Task LoadUsersAsync()
        {
            try
            {
                using var request = new HttpRequestMessage(HttpMethod.Get, "users");

                using var response =
                    await ApiClientService.SendWithTokenAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    string error = await response.Content.ReadAsStringAsync();

                    MessageBox.Show(
                        $"Lỗi tải tài khoản: {(int)response.StatusCode}\n{error}");
                    return;
                }

                var users =
                    await response.Content.ReadFromJsonAsync<List<UserDto>>();

                dgvUsers.DataSource = users;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi lấy danh sách tài khoản: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================
        // CLICK CHỌN USER
        // =========================
        private void dgvUsers_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var row = dgvUsers.Rows[e.RowIndex];

            if (row.Cells["Id"].Value != null)
            {
                _selectedUserId =
                    Convert.ToInt32(row.Cells["Id"].Value);
            }

            txtUsername.Text =
                row.Cells["Username"].Value?.ToString() ?? "";

            txtFullName.Text =
                row.Cells["FullName"].Value?.ToString() ?? "";

            if (row.Cells["Role"].Value != null)
            {
                string role =
                    row.Cells["Role"].Value.ToString() ?? "";

                int index = cboRole.Items.IndexOf(role);

                if (index >= 0)
                    cboRole.SelectedIndex = index;
            }

            // Khi chọn tài khoản cũ thì không cần nhập password
            txtPassword.Clear();
        }

        // =========================
        // THÊM USER
        // =========================
        private async void btnAddUser_Click(
            object sender,
            EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show(
                    "Tên đăng nhập không được để trống!",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show(
                    "Mật khẩu không được để trống!",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            var newUser = new
            {
                Username = txtUsername.Text.Trim(),
                Password = txtPassword.Text.Trim(),
                FullName = txtFullName.Text.Trim(),
                Role = cboRole.SelectedItem?.ToString() ?? "Cashier"
            };

            try
            {
                var response =
                    await ApiClientService.Client
                        .PostAsJsonAsync("users", newUser);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show(
                        "Tạo tài khoản mới thành công!",
                        "Thành công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    await LoadUsersAsync();
                    ClearInputs();
                }
                else
                {
                    string message =
                        await response.Content.ReadAsStringAsync();

                    MessageBox.Show(
                        "Tạo tài khoản thất bại!\n" + message,
                        "Thất bại",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi khi tạo tài khoản: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================
        // ĐẶT LẠI MẬT KHẨU
        // =========================
        private async void btnResetPassword_Click(
            object sender,
            EventArgs e)
        {
            if (_selectedUserId == 0)
            {
                MessageBox.Show(
                    "Vui lòng chọn tài khoản cần đặt lại mật khẩu!",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập mật khẩu mới!",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            var confirm = MessageBox.Show(
                "Bạn có chắc muốn đặt lại mật khẩu cho tài khoản này?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            var request = new
            {
                Password = txtPassword.Text.Trim()
            };

            try
            {
                var response =
                    await ApiClientService.Client.PutAsJsonAsync(
                        $"users/{_selectedUserId}/reset-password",
                        request);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show(
                        "Đặt lại mật khẩu thành công!",
                        "Thành công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    txtPassword.Clear();
                }
                else
                {
                    MessageBox.Show(
                        "Đặt lại mật khẩu thất bại!",
                        "Thất bại",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi đặt lại mật khẩu: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        
        private async void btnUpdateUser_Click(object sender, EventArgs e)
        {
            // Kiểm tra tài khoản được chọn
            if (dgvUsers.CurrentRow == null ||
                dgvUsers.CurrentRow.Cells["Id"].Value == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn tài khoản cần cập nhật!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(
                dgvUsers.CurrentRow.Cells["Id"].Value);

            string fullName = txtFullName.Text.Trim();

            if (string.IsNullOrWhiteSpace(fullName))
            {
                MessageBox.Show("Vui lòng nhập họ tên!");
                txtFullName.Focus();
                return;
            }

            if (cboRole.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn vai trò!");
                return;
            }

            string role = cboRole.SelectedItem.ToString()!;

            var updateData = new
            {
                FullName = fullName,
                Role = role
            };

            try
            {
                using var request = new HttpRequestMessage(
                    HttpMethod.Put, $"users/{id}")
                {
                    Content = System.Net.Http.Json.JsonContent.Create(
                        updateData)
                };

                using var response =
                    await ApiClientService.SendWithTokenAsync(request);

                string result =
                    await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show(
                        "Cập nhật tài khoản thành công!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    await LoadUsersAsync();
                }
                else
                {
                    MessageBox.Show(
                        $"Cập nhật thất bại!\n" +
                        $"HTTP {(int)response.StatusCode}\n{result}",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi cập nhật tài khoản: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================
        // TẢI LẠI DANH SÁCH TÀI KHOẢN
        // =========================
        private async void btnReload_Click(object sender, EventArgs e)
        {
            await LoadUsersAsync();
        }



        // =========================
        // KHÓA / MỞ KHÓA
        // =========================
        private async void btnToggleLock_Click(
            object sender,
            EventArgs e)
        {
            if (_selectedUserId == 0)
            {
                MessageBox.Show(
                    "Vui lòng chọn tài khoản!",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            var confirm = MessageBox.Show(
                "Bạn có chắc muốn thay đổi trạng thái tài khoản này?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                var response =
                    await ApiClientService.Client.PutAsync(
                        $"users/{_selectedUserId}/toggle-lock",
                        null);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show(
                        "Đã thay đổi trạng thái tài khoản!",
                        "Thành công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    await LoadUsersAsync();
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show(
                        "Không thể thay đổi trạng thái tài khoản!",
                        "Thất bại",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi khóa/mở tài khoản: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================
        // XÓA FORM NHẬP
        // =========================
        private void ClearInputs()
        {
            _selectedUserId = 0;

            txtUsername.Clear();
            txtFullName.Clear();
            txtPassword.Clear();

            if (cboRole.Items.Count > 1)
                cboRole.SelectedIndex = 1;

            dgvUsers.ClearSelection();
        }
    }

    // =========================
    // DTO TÀI KHOẢN
    // =========================
    public class UserDto
    {
        public int Id { get; set; }

        public string Username { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty;

        public bool IsActive { get; set; }
    }
}
