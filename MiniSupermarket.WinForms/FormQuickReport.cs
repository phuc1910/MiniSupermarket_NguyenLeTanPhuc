using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniSupermarket.WinForms
{
    // Báo cáo nhanh theo KHOẢNG NGÀY: từ ngày -> đến ngày (chỉ Admin vào được - FormMainShell đã chặn các vai trò khác)
    // Gọi API: GET api/Reports/quick-report?fromDate=yyyy-MM-dd&toDate=yyyy-MM-dd
    public partial class FormQuickReport : Form
    {
        public FormQuickReport()
        {
            InitializeComponent();

            // [BUỔI 5] Hiển thị ngày dạng ngắn (dd/MM/yyyy theo cấu hình máy)
            dtpFromDate.Format = DateTimePickerFormat.Short;
            dtpToDate.Format = DateTimePickerFormat.Short;

            // Giữ cho khoảng ngày luôn hợp lệ: chọn "Từ ngày" lớn hơn "Đến ngày" thì đẩy "Đến ngày" theo,
            // và ngược lại. Nhờ vậy người dùng không bao giờ gặp trường hợp từ ngày > đến ngày.
            dtpFromDate.ValueChanged += (s, e) =>
            {
                if (dtpFromDate.Value.Date > dtpToDate.Value.Date)
                    dtpToDate.Value = dtpFromDate.Value;
            };
            dtpToDate.ValueChanged += (s, e) =>
            {
                if (dtpToDate.Value.Date < dtpFromDate.Value.Date)
                    dtpFromDate.Value = dtpToDate.Value;
            };

            // Tên mặt hàng có thể dài: cho phép xuống dòng trong khung thay vì tràn ra ngoài
            lblBestSeller.AutoSize = false;
            lblBestSeller.TextAlign = ContentAlignment.MiddleCenter;
            lblBestSeller.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblBestSeller.SetBounds(8, 64, panel3.Width - 16, 100);

            // [BUỔI 5] Gắn sự kiện (File Designer chưa gắn).
            // Nếu bạn đã gắn Click/Load trong Designer thì XÓA 2 dòng dưới để tránh chạy hai lần.
            btnRunReport.Click += btnRunReport_Click;
            Load += FormQuickReport_Load;
        }

        // Mở form là xem luôn báo cáo của khoảng ngày đang chọn (mặc định là hôm nay -> hôm nay)
        private async void FormQuickReport_Load(object? sender, EventArgs e)
        {
            await LoadReportAsync();
        }

        private async void btnRunReport_Click(object? sender, EventArgs e)
        {
            await LoadReportAsync();
        }

        private async Task LoadReportAsync()
        {
            DateTime fromDate = dtpFromDate.Value.Date;
            DateTime toDate = dtpToDate.Value.Date;

            // Kiểm tra phía client trước khi gọi API (API cũng kiểm tra lại)
            if (fromDate > toDate)
            {
                MessageBox.Show("Từ ngày không được lớn hơn đến ngày!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Khóa nút trong lúc chờ máy chủ để tránh bấm liên tục
            btnRunReport.Enabled = false;
            try
            {
                string from = fromDate.ToString("yyyy-MM-dd");
                string to = toDate.ToString("yyyy-MM-dd");
                var response = await ApiClientService.Client.GetAsync(
                    $"Reports/quick-report?fromDate={from}&toDate={to}");

                if (!response.IsSuccessStatusCode)
                {
                    ResetLabels();
                    MessageBox.Show(await ReadErrorMessageAsync(response), "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string json = await response.Content.ReadAsStringAsync();
                using var doc = JsonDocument.Parse(json);
                var root = doc.RootElement;

                int totalOrders = root.GetProperty("totalOrders").GetInt32();
                decimal totalRevenue = root.GetProperty("totalRevenue").GetDecimal();

                lblTotalOrders.Text = totalOrders.ToString("N0");
                lblTotalRevenue.Text = $"{totalRevenue:N0} đ";

                // Ghi rõ khoảng ngày đang xem lên tiêu đề khung tổng quan
                groupBox3.Text = fromDate == toDate
                    ? $"Tổng quan doanh thu ({fromDate:dd/MM/yyyy})"
                    : $"Tổng quan doanh thu ({fromDate:dd/MM/yyyy} - {toDate:dd/MM/yyyy})";

                // bestSeller là null khi khoảng ngày đó không có hóa đơn hoặc hóa đơn chưa có chi tiết
                var best = root.GetProperty("bestSeller");
                if (best.ValueKind == JsonValueKind.Null)
                {
                    lblBestSeller.Text = "Chưa có dữ liệu";
                }
                else
                {
                    string name = best.GetProperty("productName").GetString() ?? string.Empty;
                    int sold = best.GetProperty("totalSold").GetInt32();
                    lblBestSeller.Text = $"{name}\n(đã bán {sold})";
                }
            }
            catch (Exception ex)
            {
                ResetLabels();
                MessageBox.Show("Lỗi kết nối máy chủ: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnRunReport.Enabled = true;
            }
        }

        private void ResetLabels()
        {
            lblTotalOrders.Text = "0";
            lblTotalRevenue.Text = "0 đ";
            lblBestSeller.Text = "Chưa có dữ liệu";
        }

        // Đổi phản hồi lỗi của API thành câu thông báo dễ hiểu
        private static async Task<string> ReadErrorMessageAsync(HttpResponseMessage response)
        {
            if (response.StatusCode == HttpStatusCode.Unauthorized)
                return "Phiên đăng nhập đã hết hạn, vui lòng đăng nhập lại!";

            if (response.StatusCode == HttpStatusCode.Forbidden)
                return "Chỉ tài khoản Admin mới được xem báo cáo doanh thu!";

            try
            {
                string json = await response.Content.ReadAsStringAsync();
                using var doc = JsonDocument.Parse(json);
                if (doc.RootElement.TryGetProperty("message", out var m) && !string.IsNullOrWhiteSpace(m.GetString()))
                    return m.GetString()!;
            }
            catch
            {
                // Phản hồi không phải JSON: dùng thông báo mặc định bên dưới
            }

            return $"Máy chủ trả về lỗi {(int)response.StatusCode}.";
        }
    }
}