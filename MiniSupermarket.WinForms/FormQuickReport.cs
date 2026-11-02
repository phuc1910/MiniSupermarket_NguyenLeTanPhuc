using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MiniSupermarket.WinForms
{
    // Báo cáo & Dashboard theo KHOẢNG NGÀY: từ ngày -> đến ngày (chỉ Admin vào được - FormMainShell đã chặn các vai trò khác)
    // Gọi API:
    //   GET api/Reports/quick-report?fromDate=yyyy-MM-dd&toDate=yyyy-MM-dd   -> tổng hóa đơn, doanh thu, bán chạy nhất (theo khoảng ngày)
    //   GET api/Reports/dashboard-summary                                    -> [TC 44] hôm nay: doanh thu, hóa đơn; khách mới; hàng sắp hết
    //   GET api/Reports/revenue-by-day?fromDate=...&toDate=...               -> [TC 45] biểu đồ cột doanh thu từng ngày
    //   GET api/Reports/best-sellers                                         -> [TC 46] Top 5 sản phẩm bán chạy
    public partial class FormQuickReport : Form
    {
        public FormQuickReport()
        {
            InitializeComponent();

            // [BUỔI 5] Hiển thị ngày dạng ngắn (dd/MM/yyyy theo cấu hình máy)
            dtpFromDate.Format = DateTimePickerFormat.Short;
            dtpToDate.Format = DateTimePickerFormat.Short;

            // [DASHBOARD] Mặc định xem 7 ngày gần nhất để biểu đồ cột có nhiều cột (muốn xem riêng hôm nay: chọn cùng một ngày cho cả hai ô)
            dtpToDate.Value = DateTime.Today;
            dtpFromDate.Value = DateTime.Today.AddDays(-6);

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

            // [TC 45] Cấu hình hiển thị biểu đồ cột
            var area = chartRevenue.ChartAreas[0];
            area.AxisY.LabelStyle.Format = "#,##0";
            area.AxisX.MajorGrid.Enabled = false;
            chartRevenue.Legends.Clear();

            // [BUỔI 5] Gắn sự kiện (File Designer chưa gắn).
            // Nếu bạn đã gắn Click/Load trong Designer thì XÓA 2 dòng dưới để tránh chạy hai lần.
            btnRunReport.Click += btnRunReport_Click;
            btnExportProducts.Click += btnExportProducts_Click;
            btnExportRevenue.Click += btnExportRevenue_Click;
            Load += FormQuickReport_Load;
        }

        // Mở form là xem luôn báo cáo của khoảng ngày đang chọn (mặc định là 7 ngày gần nhất)
        private async void FormQuickReport_Load(object? sender, EventArgs e)
        {
            await LoadAllAsync();
        }

        private async void btnRunReport_Click(object? sender, EventArgs e)
        {
            await LoadAllAsync();
        }

        // Nạp tuần tự các phần của báo cáo. Một phần lỗi (mất mạng, hết phiên...) thì dừng luôn
        // để không hiện nhiều hộp thoại lỗi liên tiếp.
        private async Task LoadAllAsync()
        {
            // Khóa nút trong lúc chờ máy chủ để tránh bấm liên tục
            btnRunReport.Enabled = false;
            try
            {
                if (!await LoadReportAsync()) return;      // 3 thẻ theo khoảng ngày
                if (!await LoadSummaryAsync()) return;     // [TC 44] thẻ hôm nay / khách mới / sắp hết hàng
                if (!await LoadRevenueChartAsync()) return; // [TC 45] biểu đồ cột
                await LoadBestSellersAsync();               // [TC 46] Top 5
            }
            finally
            {
                btnRunReport.Enabled = true;
            }
        }

        // ================== BÁO CÁO THEO KHOẢNG NGÀY (3 thẻ có sẵn) ==================

        private async Task<bool> LoadReportAsync()
        {
            DateTime fromDate = dtpFromDate.Value.Date;
            DateTime toDate = dtpToDate.Value.Date;

            // Kiểm tra phía client trước khi gọi API (API cũng kiểm tra lại)
            if (fromDate > toDate)
            {
                MessageBox.Show("Từ ngày không được lớn hơn đến ngày!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

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
                    return false;
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
                return true;
            }
            catch (Exception ex)
            {
                ResetLabels();
                MessageBox.Show("Lỗi kết nối máy chủ: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void ResetLabels()
        {
            lblTotalOrders.Text = "0";
            lblTotalRevenue.Text = "0 đ";
            lblBestSeller.Text = "Chưa có dữ liệu";
            lblOrdersToday.Text = "Hôm nay: 0 hóa đơn";
            lblRevenueToday.Text = "Hôm nay: 0 đ";
            lblNewCustomers.Text = "0";
            lblLowStock.Text = "0";
        }

        // ================== [TC 44] CÁC THẺ DASHBOARD ==================

        private async Task<bool> LoadSummaryAsync()
        {
            try
            {
                var response = await ApiClientService.Client.GetAsync("Reports/dashboard-summary");
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show(await ReadErrorMessageAsync(response), "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                using var doc = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
                var root = doc.RootElement;

                decimal revenueToday = root.GetProperty("revenueToday").GetDecimal();
                int invoicesToday = root.GetProperty("invoicesToday").GetInt32();
                int newCustomers = root.GetProperty("newCustomersToday").GetInt32();
                int lowStock = root.GetProperty("lowStockProducts").GetInt32();
                int threshold = root.GetProperty("lowStockThreshold").GetInt32();

                lblRevenueToday.Text = $"Hôm nay: {revenueToday:N0} đ";
                lblOrdersToday.Text = $"Hôm nay: {invoicesToday:N0} hóa đơn";
                lblNewCustomers.Text = newCustomers.ToString("N0");
                lblLowStock.Text = lowStock.ToString("N0");
                lblLowStockSub.Text = $"Tồn kho <= {threshold}";
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối máy chủ: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // ================== [TC 45] BIỂU ĐỒ CỘT DOANH THU THEO NGÀY ==================

        private async Task<bool> LoadRevenueChartAsync()
        {
            DateTime from = dtpFromDate.Value.Date;
            DateTime to = dtpToDate.Value.Date;

            if ((to - from).TotalDays > 366)
            {
                MessageBox.Show("Vui lòng chọn khoảng thời gian tối đa 366 ngày!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            try
            {
                var response = await ApiClientService.Client.GetAsync(
                    $"Reports/revenue-by-day?fromDate={from:yyyy-MM-dd}&toDate={to:yyyy-MM-dd}");
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show(await ReadErrorMessageAsync(response), "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                // Doanh thu theo ngày từ API (ngày không có hóa đơn sẽ không có dòng)
                var revenueByDay = new Dictionary<DateTime, decimal>();
                using (var doc = JsonDocument.Parse(await response.Content.ReadAsStringAsync()))
                {
                    foreach (var item in doc.RootElement.GetProperty("data").EnumerateArray())
                    {
                        DateTime day = DateTime.Parse(item.GetProperty("date").GetString()!).Date;
                        revenueByDay[day] = item.GetProperty("totalRevenue").GetDecimal();
                    }
                }

                // Vẽ đủ mọi ngày trong khoảng; ngày không bán được gì = 0 để dễ so sánh
                Series series = chartRevenue.Series[0];
                series.Points.Clear();
                for (DateTime day = from; day <= to; day = day.AddDays(1))
                {
                    decimal revenue = revenueByDay.TryGetValue(day, out var r) ? r : 0;
                    int index = series.Points.AddXY(day.ToString("dd/MM"), (double)revenue);
                    series.Points[index].ToolTip = $"{day:dd/MM/yyyy}: {revenue:N0} đ";
                }

                // Khoảng ngắn: hiện đủ nhãn từng ngày. Khoảng dài: để biểu đồ tự chọn bước nhãn cho khỏi dính chữ
                chartRevenue.ChartAreas[0].AxisX.Interval = (to - from).TotalDays > 31 ? 0 : 1;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối máy chủ: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // ================== [TC 46] TOP 5 SẢN PHẨM BÁN CHẠY ==================

        private async Task<bool> LoadBestSellersAsync()
        {
            try
            {
                var response = await ApiClientService.Client.GetAsync("Reports/best-sellers");
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show(await ReadErrorMessageAsync(response), "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                dgvTopProducts.Rows.Clear();
                using var doc = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
                int rank = 1;
                foreach (var item in doc.RootElement.GetProperty("data").EnumerateArray())
                {
                    dgvTopProducts.Rows.Add(
                        rank++,
                        item.GetProperty("productName").GetString(),
                        item.GetProperty("totalSold").GetInt32().ToString("N0"));
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối máy chủ: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // ================== [TC 48] XUẤT BÁO CÁO RA FILE CSV (MỞ BẰNG EXCEL) ==================

        // Xuất toàn bộ mặt hàng kèm số lượng tồn kho: GET api/Products/with-category
        private async void btnExportProducts_Click(object? sender, EventArgs e)
        {
            btnExportProducts.Enabled = false;
            try
            {
                var response = await ApiClientService.Client.GetAsync("Products/with-category");
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show(await ReadErrorMessageAsync(response), "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var rows = new List<string[]>();
                using (var doc = JsonDocument.Parse(await response.Content.ReadAsStringAsync()))
                {
                    foreach (var p in doc.RootElement.EnumerateArray())
                    {
                        int stock = p.GetProperty("stockQuantity").GetInt32();
                        rows.Add(new[]
                        {
                            p.GetProperty("productId").GetInt32().ToString(),
                            p.GetProperty("barcode").GetString() ?? string.Empty,
                            p.GetProperty("productName").GetString() ?? string.Empty,
                            p.GetProperty("categoryName").GetString() ?? string.Empty,
                            Math.Round(p.GetProperty("price").GetDecimal()).ToString(CultureInfo.InvariantCulture),
                            stock.ToString(),
                            stock <= 10 ? "Sắp hết hàng" : "Còn hàng"
                        });
                    }
                }

                if (rows.Count == 0)
                {
                    MessageBox.Show("Chưa có mặt hàng nào để xuất!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                SaveCsvFile($"TonKho_{DateTime.Now:yyyyMMdd_HHmm}.csv",
                    new[] { "Mã SP", "Mã vạch", "Tên sản phẩm", "Nhóm hàng", "Đơn giá (VNĐ)", "Tồn kho", "Trạng thái" },
                    rows);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất danh sách sản phẩm: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnExportProducts.Enabled = true;
            }
        }

        // Xuất doanh thu từng ngày trong khoảng Từ ngày - Đến ngày: GET api/Reports/revenue-by-day
        private async void btnExportRevenue_Click(object? sender, EventArgs e)
        {
            DateTime from = dtpFromDate.Value.Date;
            DateTime to = dtpToDate.Value.Date;

            if (from > to)
            {
                MessageBox.Show("Từ ngày không được lớn hơn đến ngày!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnExportRevenue.Enabled = false;
            try
            {
                var response = await ApiClientService.Client.GetAsync(
                    $"Reports/revenue-by-day?fromDate={from:yyyy-MM-dd}&toDate={to:yyyy-MM-dd}");
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show(await ReadErrorMessageAsync(response), "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var rows = new List<string[]>();
                decimal sumRevenue = 0;
                int sumOrders = 0;
                using (var doc = JsonDocument.Parse(await response.Content.ReadAsStringAsync()))
                {
                    foreach (var item in doc.RootElement.GetProperty("data").EnumerateArray())
                    {
                        DateTime day = DateTime.Parse(item.GetProperty("date").GetString()!);
                        int orders = item.GetProperty("totalOrders").GetInt32();
                        decimal revenue = item.GetProperty("totalRevenue").GetDecimal();
                        sumOrders += orders;
                        sumRevenue += revenue;
                        rows.Add(new[]
                        {
                            day.ToString("dd/MM/yyyy"),
                            orders.ToString(),
                            Math.Round(revenue).ToString(CultureInfo.InvariantCulture)
                        });
                    }
                }

                if (rows.Count == 0)
                {
                    MessageBox.Show("Khoảng ngày này chưa có hóa đơn nào để xuất!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Dòng tổng cộng ở cuối file
                rows.Add(new[] { "TỔNG CỘNG", sumOrders.ToString(), Math.Round(sumRevenue).ToString(CultureInfo.InvariantCulture) });

                SaveCsvFile($"DoanhThu_{from:yyyyMMdd}_{to:yyyyMMdd}.csv",
                    new[] { "Ngày", "Số hóa đơn", "Doanh thu (VNĐ)" },
                    rows);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất doanh thu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnExportRevenue.Enabled = true;
            }
        }

        // Hộp thoại chọn nơi lưu rồi ghi file CSV
        private static void SaveCsvFile(string defaultFileName, string[] header, List<string[]> rows)
        {
            using var dialog = new SaveFileDialog
            {
                Title = "Chọn nơi lưu báo cáo",
                Filter = "Tệp CSV - mở được bằng Excel (*.csv)|*.csv",
                FileName = defaultFileName,
                OverwritePrompt = true
            };

            if (dialog.ShowDialog() != DialogResult.OK) return;

            // Dùng đúng ký tự phân cách cột mà Excel của máy này đang dùng (",", hoặc ";" ở nhiều máy tiếng Việt)
            string separator = CultureInfo.CurrentCulture.TextInfo.ListSeparator;
            if (string.IsNullOrEmpty(separator)) separator = ",";

            var sb = new StringBuilder();
            sb.AppendLine(string.Join(separator, header.Select(h => EscapeCsv(h, separator))));
            foreach (var row in rows)
            {
                sb.AppendLine(string.Join(separator, row.Select(v => EscapeCsv(v, separator))));
            }

            try
            {
                // UTF-8 có BOM để Excel hiển thị đúng tiếng Việt có dấu
                File.WriteAllText(dialog.FileName, sb.ToString(), new UTF8Encoding(true));
                MessageBox.Show($"Xuất thành công {rows.Count} dòng!\n\n{dialog.FileName}", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (IOException)
            {
                MessageBox.Show("Không ghi được file. Có thể file đang mở trong Excel - hãy đóng file rồi thử lại!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Bạn không có quyền ghi vào thư mục này, hãy chọn thư mục khác!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Bọc dấu ngoặc kép khi giá trị chứa ký tự phân cách / ngoặc kép / xuống dòng.
        // Giá trị chữ bắt đầu bằng = + - @ bị Excel hiểu là công thức -> thêm dấu ' phía trước (chống CSV injection).
        private static string EscapeCsv(string value, string separator)
        {
            if (value.Length > 0 && "=+-@".IndexOf(value[0]) >= 0 && !decimal.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out _))
            {
                value = "'" + value;
            }

            if (value.Contains(separator) || value.Contains('"') || value.Contains('\n') || value.Contains('\r'))
            {
                value = "\"" + value.Replace("\"", "\"\"") + "\"";
            }
            return value;
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