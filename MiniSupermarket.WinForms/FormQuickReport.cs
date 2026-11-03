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
        private readonly CancellationTokenSource _reportLifetime = new();
        private readonly HashSet<string> _activeReportLoads = new();
        private static readonly JsonSerializerOptions ReportJson = new(JsonSerializerDefaults.Web);
        private bool _loadingOverview;
        private bool _bindingOrders;
        private bool _reloadOrders;
        private int _orderPage = 1;
        private int _orderTotalPages;
        private CancellationTokenSource? _detailRequest;
        private bool _initializingReportFilters = true;

        public FormQuickReport()
        {
            InitializeComponent();

            // Giữ bộ lọc tùy chọn cũ khi mở form; các kỳ mới chỉ chuyển thành khoảng ngày.
            dtpFromDate.Value = DateTime.Today.AddDays(-6);
            dtpToDate.Value = DateTime.Today;
            dtpOverviewAnchor.Value = DateTime.Today;
            dtpOrdersFrom.Value = DateTime.Today.AddDays(-6);
            dtpOrdersTo.Value = DateTime.Today;
            dtpDaily.Value = DateTime.Today;
            dtpCashierFrom.Value = DateTime.Today.AddDays(-6);
            dtpCashierTo.Value = DateTime.Today;
            dtpCashierAnchor.Value = DateTime.Today;
            cmbOverviewPeriod.SelectedIndex = 4;
            cmbDailyPeriod.SelectedIndex = 0;
            cmbCashierPeriod.SelectedIndex = 4;
            _initializingReportFilters = false;
            ApplyOverviewPeriod();
            ApplyDailyPeriod();
            ApplyCashierPeriod();
            UpdateOrderButtons();

            chartRevenue.ChartAreas[0].AxisY.LabelStyle.Format = "#,##0";
            chartRevenue.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chartRevenue.Legends.Clear();
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
            if (_loadingOverview) return;
            _loadingOverview = true;
            // Khóa nút trong lúc chờ máy chủ để tránh bấm liên tục
            groupBox2.Enabled = false;
            try
            {
                if (!await LoadReportAsync()) return;      // 3 thẻ theo khoảng ngày
                if (!await LoadSummaryAsync()) return;     // [TC 44] thẻ hôm nay / khách mới / sắp hết hàng
                if (!await LoadRevenueChartAsync()) return; // [TC 45] biểu đồ cột
                await LoadBestSellersAsync();               // [TC 46] Top 5
            }
            finally
            {
                _loadingOverview = false;
                if (!IsDisposed)
                {
                    groupBox2.Enabled = true;
                    ApplyOverviewPeriod();
                }
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
                            p.GetProperty("stockStatus").GetString() ?? string.Empty
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

        // ================== SỰ KIỆN CÁC TAB BÁO CÁO ==================

        private async void tabReports_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (_initializingReportFilters) return;
            if (tabReports.SelectedTab == tabOrders) await LoadOrdersAsync();
            else if (tabReports.SelectedTab == tabDaily) await LoadDailyAsync();
            else if (tabReports.SelectedTab == tabCashiers) await LoadCashiersAsync();
        }

        private void FormQuickReport_FormClosed(object? sender, FormClosedEventArgs e)
        {
            _detailRequest?.Cancel();
            _reportLifetime.Cancel();
        }

        private async void btnLoadOrders_Click(object? sender, EventArgs e)
        {
            _orderPage = 1;
            await LoadOrdersAsync();
        }

        private async void btnOrderPrevious_Click(object? sender, EventArgs e)
        {
            if (_orderPage <= 1) return;
            _orderPage--;
            await LoadOrdersAsync();
        }

        private async void btnOrderNext_Click(object? sender, EventArgs e)
        {
            if (_orderPage >= _orderTotalPages) return;
            _orderPage++;
            await LoadOrdersAsync();
        }

        private async void btnOrderDetail_Click(object? sender, EventArgs e)
        {
            await LoadSelectedOrderAsync();
        }

        private async void dgvOrders_SelectionChanged(object? sender, EventArgs e)
        {
            if (!_bindingOrders) await LoadSelectedOrderAsync();
        }

        private async void dgvOrders_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) await LoadSelectedOrderAsync();
        }

        private async void btnLoadDaily_Click(object? sender, EventArgs e)
        {
            await LoadDailyAsync();
        }

        private async void btnDailyOrders_Click(object? sender, EventArgs e)
        {
            var period = GetRevenuePeriod(cmbDailyPeriod.SelectedIndex, dtpDaily.Value);
            dtpOrdersFrom.Value = period.From;
            dtpOrdersTo.Value = period.To;
            _orderPage = 1;
            if (tabReports.SelectedTab == tabOrders) await LoadOrdersAsync();
            else tabReports.SelectedTab = tabOrders;
        }

        private async void btnLoadCashiers_Click(object? sender, EventArgs e)
        {
            await LoadCashiersAsync();
        }

        private void chkAllCashierHistory_CheckedChanged(object? sender, EventArgs e)
        {
            if (!_initializingReportFilters) ApplyCashierPeriod();
        }

        private void dtpFromDate_ValueChanged(object? sender, EventArgs e)
        {
            if (!_initializingReportFilters && dtpFromDate.Value.Date > dtpToDate.Value.Date)
                dtpToDate.Value = dtpFromDate.Value;
        }

        private void dtpToDate_ValueChanged(object? sender, EventArgs e)
        {
            if (!_initializingReportFilters && dtpToDate.Value.Date < dtpFromDate.Value.Date)
                dtpFromDate.Value = dtpToDate.Value;
        }

        // ================== BỘ LỌC NGÀY / TUẦN / THÁNG / NĂM ==================

        private void cmbOverviewPeriod_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (!_initializingReportFilters) ApplyOverviewPeriod();
        }

        private void dtpOverviewAnchor_ValueChanged(object? sender, EventArgs e)
        {
            if (!_initializingReportFilters) ApplyOverviewPeriod();
        }

        private void cmbDailyPeriod_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (!_initializingReportFilters) ApplyDailyPeriod();
        }

        private void dtpDaily_ValueChanged(object? sender, EventArgs e)
        {
            if (!_initializingReportFilters) ApplyDailyPeriod();
        }

        private void cmbCashierPeriod_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (!_initializingReportFilters) ApplyCashierPeriod();
        }

        private void dtpCashierAnchor_ValueChanged(object? sender, EventArgs e)
        {
            if (!_initializingReportFilters) ApplyCashierPeriod();
        }

        private void ApplyOverviewPeriod()
        {
            ApplyPeriodFilter(cmbOverviewPeriod, dtpOverviewAnchor, dtpFromDate, dtpToDate, false);
        }

        private void ApplyCashierPeriod()
        {
            bool allHistory = chkAllCashierHistory.Checked;
            cmbCashierPeriod.Enabled = !allHistory;
            ApplyPeriodFilter(cmbCashierPeriod, dtpCashierAnchor, dtpCashierFrom, dtpCashierTo, allHistory);
        }

        private void ApplyDailyPeriod()
        {
            FormatPeriodPicker(dtpDaily, cmbDailyPeriod.SelectedIndex);
        }

        private static void ApplyPeriodFilter(ComboBox mode, DateTimePicker anchor,
            DateTimePicker from, DateTimePicker to, bool allHistory)
        {
            bool custom = mode.SelectedIndex == 4;
            anchor.Enabled = !custom && !allHistory;
            from.Enabled = to.Enabled = custom && !allHistory;
            FormatPeriodPicker(anchor, mode.SelectedIndex);
            if (!custom && !allHistory)
            {
                var period = GetRevenuePeriod(mode.SelectedIndex, anchor.Value);
                from.Value = period.From;
                to.Value = period.To;
            }
        }

        private static void FormatPeriodPicker(DateTimePicker picker, int mode)
        {
            picker.Format = DateTimePickerFormat.Custom;
            picker.CustomFormat = mode == 2 ? "MM/yyyy" : mode == 3 ? "yyyy" : "dd/MM/yyyy";
            picker.ShowUpDown = mode == 2 || mode == 3;
        }

        // Chỉ xác định khoảng ngày gửi API; doanh thu, điểm và tồn kho vẫn do server tính.
        private static (DateTime From, DateTime To) GetRevenuePeriod(int mode, DateTime referenceDate)
        {
            DateTime anchor = referenceDate.Date;
            DateTime from;
            DateTime to;
            switch (mode)
            {
                case 1:
                    int daysFromMonday = ((int)anchor.DayOfWeek + 6) % 7;
                    from = anchor.AddDays(-daysFromMonday);
                    to = from.AddDays(6);
                    break;
                case 2:
                    from = new DateTime(anchor.Year, anchor.Month, 1);
                    to = from.AddMonths(1).AddDays(-1);
                    break;
                case 3:
                    from = new DateTime(anchor.Year, 1, 1);
                    to = new DateTime(anchor.Year, 12, 31);
                    break;
                default:
                    from = anchor;
                    to = anchor;
                    break;
            }
            return (from, to);
        }

        private async Task LoadOrdersAsync()
        {
            if (_activeReportLoads.Contains("orders"))
            {
                _reloadOrders = true;
                return;
            }
            await RunReportActionAsync("orders", new Control[] { dtpOrdersFrom, dtpOrdersTo, btnLoadOrders,
                btnOrderPrevious, btnOrderNext, btnOrderDetail, dgvOrders }, async token =>
            {
                DateTime from = dtpOrdersFrom.Value.Date, to = dtpOrdersTo.Value.Date;
                ValidateDates(from, to);
                _detailRequest?.Cancel();
                _bindingOrders = true;
                dgvOrders.DataSource = null;
                _bindingOrders = false;
                dgvOrderDetails.DataSource = null;
                lblOrderDetail.Text = "Chọn một đơn hàng để xem chi tiết.";
                lblOrderPaging.Text = "Đang tải đơn hàng...";
                _orderTotalPages = 0;
                string url = $"orders?fromDate={from:yyyy-MM-dd}&toDate={to:yyyy-MM-dd}&pageNumber={_orderPage}&pageSize=20";
                var page = await GetReportDataAsync<OrderReportPage>(url, token);
                if (page.TotalPages > 0 && page.CurrentPage > page.TotalPages)
                {
                    _orderPage = page.TotalPages;
                    page = await GetReportDataAsync<OrderReportPage>(
                        $"orders?fromDate={from:yyyy-MM-dd}&toDate={to:yyyy-MM-dd}&pageNumber={_orderPage}&pageSize=20", token);
                }
                if (IsDisposed) return;
                if (from != dtpOrdersFrom.Value.Date || to != dtpOrdersTo.Value.Date)
                {
                    _reloadOrders = true;
                    return;
                }
                _orderPage = page.CurrentPage;
                _orderTotalPages = page.TotalPages;
                _bindingOrders = true;
                try { dgvOrders.DataSource = page.Items; }
                finally { _bindingOrders = false; }
                lblOrderPaging.Text = $"Trang {(page.TotalPages == 0 ? 0 : page.CurrentPage)}/{page.TotalPages} | " +
                    $"{page.TotalItems:N0} đơn | Thực thu toàn bộ kết quả: {page.TotalRevenue:N0} đ";
                if (page.Items.Count == 0) lblOrderDetail.Text = "Không có đơn hàng trong khoảng ngày này.";
                else await LoadSelectedOrderAsync();
            });
            UpdateOrderButtons();
            if (_reloadOrders && !IsDisposed)
            {
                _reloadOrders = false;
                _orderPage = 1;
                await LoadOrdersAsync();
            }
        }

        private async Task LoadSelectedOrderAsync()
        {
            if (IsDisposed || _bindingOrders || dgvOrders.CurrentRow?.DataBoundItem is not OrderReportItem selected) return;
            _detailRequest?.Cancel();
            _detailRequest?.Dispose();
            var request = CancellationTokenSource.CreateLinkedTokenSource(_reportLifetime.Token);
            _detailRequest = request;
            int orderId = selected.OrderId;
            dgvOrderDetails.DataSource = null;
            lblOrderDetail.Text = $"Đang tải chi tiết đơn {selected.OrderCode}...";
            try
            {
                var detail = await GetReportDataAsync<OrderReportDetail>($"orders/{orderId}", request.Token);
                if (request.IsCancellationRequested || IsDisposed ||
                    dgvOrders.CurrentRow?.DataBoundItem is not OrderReportItem current || current.OrderId != orderId) return;
                lblOrderDetail.Text = $"Đơn {detail.OrderCode} | {detail.CreatedDate:dd/MM/yyyy HH:mm} | Thu ngân: {detail.CashierUsername}\n" +
                    $"Khách: {detail.CustomerName}" + (string.IsNullOrWhiteSpace(detail.CustomerPhone) ? "" : $" — {detail.CustomerPhone}") +
                    $" | Thực thu: {detail.FinalAmount:N0} đ | Điểm thưởng: {detail.RewardPoints:N0}" +
                    (detail.Items.Count == 0 ? "\nĐơn này chưa có dòng chi tiết." : "");
                dgvOrderDetails.DataSource = detail.Items;
            }
            catch (OperationCanceledException) { }
            catch (Exception ex)
            {
                if (!IsDisposed && !request.IsCancellationRequested)
                {
                    lblOrderDetail.Text = "Không tải được chi tiết đơn hàng.";
                    MessageBox.Show(this, ex.Message, "Chi tiết đơn hàng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            UpdateOrderButtons();
        }

        private async Task LoadDailyAsync()
        {
            await RunReportActionAsync("daily", new Control[] { cmbDailyPeriod, dtpDaily, btnLoadDaily, btnDailyOrders }, async token =>
            {
                var period = GetRevenuePeriod(cmbDailyPeriod.SelectedIndex, dtpDaily.Value);
                DateTime from = period.From;
                DateTime to = period.To;
                lblDailyRevenue.Text = lblDailyOrders.Text = "—";
                lblDailyBestSeller.Text = "—";
                dgvDailyCashiers.DataSource = null;
                lblDailySummary.Text = "Đang tải doanh thu trong kỳ...";
                var report = await GetReportDataAsync<QuickReportResponse>(
                    $"reports/quick-report?fromDate={from:yyyy-MM-dd}&toDate={to:yyyy-MM-dd}", token);
                var cashiers = await GetReportDataAsync<CashierReportResponse>(
                    $"reports/revenue-by-cashier?fromDate={from:yyyy-MM-dd}&toDate={to:yyyy-MM-dd}", token);
                if (IsDisposed) return;
                lblDailyRevenue.Text = $"{report.TotalRevenue:N0} đ";
                lblDailyOrders.Text = report.TotalOrders.ToString("N0");
                lblDailyBestSeller.Text = report.BestSeller == null ? "Chưa có dữ liệu" :
                    $"{report.BestSeller.ProductName}\n(đã bán {report.BestSeller.TotalSold:N0})";
                dgvDailyCashiers.DataSource = cashiers.Data;
                string periodText = from == to ? $"Ngày {from:dd/MM/yyyy}" : $"{from:dd/MM/yyyy} – {to:dd/MM/yyyy}";
                lblDailySummary.Text = $"{periodText}: {cashiers.TotalCashiers:N0} thu ngân có đơn" +
                    (report.TotalOrders == 0 ? " — Không phát sinh doanh thu." : " — Chi tiết doanh thu theo thu ngân:");
            });
        }

        private async Task LoadCashiersAsync()
        {
            await RunReportActionAsync("cashiers", new Control[] { cmbCashierPeriod, dtpCashierAnchor, dtpCashierFrom, dtpCashierTo,
                chkAllCashierHistory, btnLoadCashiers }, async token =>
            {
                DateTime from = dtpCashierFrom.Value.Date, to = dtpCashierTo.Value.Date;
                bool all = chkAllCashierHistory.Checked;
                if (!all) ValidateDates(from, to);
                dgvCashiers.DataSource = null;
                lblCashierSummary.Text = "Đang tải doanh thu theo thu ngân...";
                string url = "reports/revenue-by-cashier" + (all ? "" : $"?fromDate={from:yyyy-MM-dd}&toDate={to:yyyy-MM-dd}");
                var report = await GetReportDataAsync<CashierReportResponse>(url, token);
                if (IsDisposed) return;
                dgvCashiers.DataSource = report.Data;
                string period = all ? "Toàn bộ lịch sử" : $"{from:dd/MM/yyyy} – {to:dd/MM/yyyy}";
                lblCashierSummary.Text = $"{period} | {report.TotalCashiers:N0} thu ngân | Tổng thực thu: {report.GrandTotalRevenue:N0} đ";
                if (report.Data.Count == 0) lblCashierSummary.Text += " | Không có đơn hàng.";
            });
            if (!IsDisposed) ApplyCashierPeriod();
        }

        private async Task<T> GetReportDataAsync<T>(string url, CancellationToken token)
        {
            using var response = await ApiClientService.Client.GetAsync(url, token);
            if (!response.IsSuccessStatusCode) throw new InvalidOperationException(await ReadErrorMessageAsync(response));
            return await response.Content.ReadFromJsonAsync<T>(ReportJson, token)
                ?? throw new InvalidOperationException("Máy chủ không trả về dữ liệu báo cáo hợp lệ.");
        }

        private async Task RunReportActionAsync(string key, Control[] controls, Func<CancellationToken, Task> action)
        {
            if (IsDisposed || !_activeReportLoads.Add(key)) return;
            foreach (var control in controls) control.Enabled = false;
            try { await action(_reportLifetime.Token); }
            catch (OperationCanceledException) { }
            catch (Exception ex)
            {
                if (!IsDisposed)
                {
                    ClearFailedReport(key);
                    MessageBox.Show(this, ex.Message, "Báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            finally
            {
                _activeReportLoads.Remove(key);
                if (!IsDisposed) foreach (var control in controls) control.Enabled = true;
            }
        }

        private void ClearFailedReport(string key)
        {
            const string message = "Không tải được dữ liệu. Kiểm tra điều kiện lọc và nhấn Xem để thử lại.";
            if (key == "orders")
            {
                _bindingOrders = true;
                try { dgvOrders.DataSource = null; }
                finally { _bindingOrders = false; }
                dgvOrderDetails.DataSource = null;
                _orderTotalPages = 0;
                lblOrderPaging.Text = message;
                lblOrderDetail.Text = "Chọn một đơn hàng để xem chi tiết.";
            }
            else if (key == "daily")
            {
                lblDailyRevenue.Text = lblDailyOrders.Text = lblDailyBestSeller.Text = "—";
                dgvDailyCashiers.DataSource = null;
                lblDailySummary.Text = message;
            }
            else if (key == "cashiers")
            {
                dgvCashiers.DataSource = null;
                lblCashierSummary.Text = message;
            }
        }

        private void UpdateOrderButtons()
        {
            if (IsDisposed) return;
            bool idle = !_activeReportLoads.Contains("orders");
            btnOrderPrevious.Enabled = idle && _orderPage > 1 && _orderTotalPages > 0;
            btnOrderNext.Enabled = idle && _orderPage < _orderTotalPages;
            btnOrderDetail.Enabled = idle && dgvOrders.CurrentRow?.DataBoundItem is OrderReportItem;
        }

        private static void ValidateDates(DateTime from, DateTime to)
        {
            if (from > to) throw new InvalidOperationException("Từ ngày không được lớn hơn đến ngày.");
        }

    }

    // DTO phản hồi báo cáo đặt cùng màn hình, không tách thêm tệp.
    public class OrderReportItem
    {
        public int OrderId { get; set; }
        public string OrderCode { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public string CashierUsername { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerPhone { get; set; } = string.Empty;
        public int TotalItems { get; set; }
        public decimal FinalAmount { get; set; }
        public int RewardPoints { get; set; }
    }

    public class OrderReportPage
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public decimal TotalRevenue { get; set; }
        public List<OrderReportItem> Items { get; set; } = new();
    }

    public class OrderReportDetail : OrderReportItem
    {
        public List<OrderReportLine> Items { get; set; } = new();
    }

    public class OrderReportLine
    {
        public int ProductId { get; set; }
        public string Barcode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineTotal { get; set; }
    }

    public class CashierReportItem
    {
        public string CashierUsername { get; set; } = string.Empty;
        public int TotalOrders { get; set; }
        public decimal TotalRevenue { get; set; }
        public int TotalPointsAwarded { get; set; }
    }

    public class CashierReportResponse
    {
        public int TotalCashiers { get; set; }
        public decimal GrandTotalRevenue { get; set; }
        public List<CashierReportItem> Data { get; set; } = new();
    }

    public class QuickReportResponse
    {
        public int TotalOrders { get; set; }
        public decimal TotalRevenue { get; set; }
        public QuickReportBestSeller? BestSeller { get; set; }
    }

    public class QuickReportBestSeller
    {
        public string ProductName { get; set; } = string.Empty;
        public int TotalSold { get; set; }
    }
}
