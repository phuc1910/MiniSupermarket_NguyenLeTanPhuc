using System.Net.Http.Json;
using System.Text.Json;
using System.Net;

namespace MiniSupermarket.WinForms
{
    public partial class FormOrderManagement : Form
    {
        private readonly CancellationTokenSource _reportLifetime = new();
        private readonly HashSet<string> _activeReportLoads = new();
        private static readonly JsonSerializerOptions ReportJson = new(JsonSerializerDefaults.Web);
        private bool _bindingOrders;
        private bool _reloadOrders;
        private int _orderPage = 1;
        private int _orderTotalPages;
        private CancellationTokenSource? _detailRequest;
        private bool _initializingOrderFilters = true;

        public FormOrderManagement()
        {
            InitializeComponent();
            dtpOrdersFrom.Value = DateTime.Today.AddDays(-6);
            dtpOrdersTo.Value = DateTime.Today;
            dtpOrderAnchor.Value = DateTime.Today;
            cmbOrderPeriod.SelectedIndex = 3;
            _initializingOrderFilters = false;
            ApplyOrderPeriod();
            UpdateOrderButtons();
        }

        private async void FormOrderManagement_Load(object? sender, EventArgs e)
        {
            await LoadOrdersAsync();
        }

        private void FormOrderManagement_FormClosed(object? sender, FormClosedEventArgs e)
        {
            _detailRequest?.Cancel();
            _reportLifetime.Cancel();
        }

        private async void btnLoadOrders_Click(object? sender, EventArgs e)
        {
            _orderPage = 1;
            await LoadOrdersAsync();
        }

        private void OrderFilter_ValueChanged(object? sender, EventArgs e)
        {
            if (_initializingOrderFilters) return;
            ApplyOrderPeriod();
            _orderPage = 1;
            _orderTotalPages = 0;
            _detailRequest?.Cancel();
            _bindingOrders = true;
            try { dgvOrders.DataSource = null; }
            finally { _bindingOrders = false; }
            dgvOrderDetails.DataSource = null;
            lblOrderPaging.Text = "Bộ lọc đã thay đổi. Nhấn Tải đơn hàng để xem kết quả.";
            lblOrderDetail.Text = "Chọn một đơn hàng để xem chi tiết.";
            UpdateOrderButtons();
        }

        private void ApplyOrderPeriod()
        {
            int mode = cmbOrderPeriod.SelectedIndex;
            bool custom = mode == 3;
            dtpOrderAnchor.Enabled = !custom;
            dtpOrdersFrom.Enabled = dtpOrdersTo.Enabled = custom;
            dtpOrderAnchor.CustomFormat = mode == 1 ? "MM/yyyy" : mode == 2 ? "yyyy" : "dd/MM/yyyy";
            dtpOrderAnchor.ShowUpDown = mode == 1 || mode == 2;
            if (custom) return;

            DateTime anchor = dtpOrderAnchor.Value.Date;
            DateTime from = mode == 1 ? new DateTime(anchor.Year, anchor.Month, 1) :
                mode == 2 ? new DateTime(anchor.Year, 1, 1) : anchor;
            DateTime to = mode == 1 ? from.AddMonths(1).AddDays(-1) :
                mode == 2 ? new DateTime(anchor.Year, 12, 31) : from;
            _initializingOrderFilters = true;
            try
            {
                dtpOrdersFrom.Value = from;
                dtpOrdersTo.Value = to;
            }
            finally { _initializingOrderFilters = false; }
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

        private async Task LoadOrdersAsync()
        {
            if (_activeReportLoads.Contains("orders"))
            {
                _reloadOrders = true;
                return;
            }
            await RunReportActionAsync("orders", new Control[] { cmbOrderPeriod, dtpOrderAnchor, dtpOrdersFrom, dtpOrdersTo, btnLoadOrders,
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
                string url = $"orders?fromDate={from:yyyy-MM-dd}&toDate={to:yyyy-MM-dd}&pageNumber={_orderPage}&pageSize=5";
                var page = await GetReportDataAsync<OrderReportPage>(url, token);
                if (page.TotalPages > 0 && page.CurrentPage > page.TotalPages)
                {
                    _orderPage = page.TotalPages;
                    page = await GetReportDataAsync<OrderReportPage>(
                        $"orders?fromDate={from:yyyy-MM-dd}&toDate={to:yyyy-MM-dd}&pageNumber={_orderPage}&pageSize=5", token);
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
            if (!IsDisposed) ApplyOrderPeriod();
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
                    MessageBox.Show(this, ex.Message, "Đơn hàng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            finally
            {
                _activeReportLoads.Remove(key);
                if (!IsDisposed) foreach (var control in controls) control.Enabled = true;
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
        private static async Task<string> ReadErrorMessageAsync(HttpResponseMessage response)
        {
            if (response.StatusCode == HttpStatusCode.Unauthorized)
                return "Phiên đăng nhập đã hết hạn, vui lòng đăng nhập lại!";

            if (response.StatusCode == HttpStatusCode.Forbidden)
                return "Tài khoản chưa được cấp quyền xem đơn hàng!";

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

        private void ClearFailedReport(string key)
        {
            _bindingOrders = true;
            try { dgvOrders.DataSource = null; }
            finally { _bindingOrders = false; }
            dgvOrderDetails.DataSource = null;
            _orderTotalPages = 0;
            lblOrderPaging.Text = "Không tải được đơn hàng. Kiểm tra bộ lọc và nhấn Tải đơn hàng để thử lại.";
            lblOrderDetail.Text = "Chọn một đơn hàng để xem chi tiết.";
        }

    }

    // DTO đọc đơn hàng dùng cho danh sách và chi tiết.
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

}
