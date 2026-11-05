/*
 * Ho ten sinh vien: Nguyen Le Tan Phuc
 * Ma sinh vien: 2124110108
 * Mo ta: Controller ADO.NET goi Stored Procedure xuat bao cao doanh thu theo thu ngan
 */
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MiniSupermarket.API.Data;
using MiniSupermarket.API.Models;
using System.Data;

namespace MiniSupermarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")] // Chỉ Admin xem được dữ liệu tài chính (khớp FormMainShell.btnReports_Click)
    public class ReportsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly SupermarketDbContext _context; // [TC 46] dùng LINQ cho Top 5 bán chạy

        public ReportsController(IConfiguration configuration, SupermarketDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        // =========================================================================
        // [TC 44] GET: api/Reports/dashboard-summary
        // Trả về 4 chỉ số tổng quan cho Dashboard bằng ADO.NET ExecuteScalar:
        //   1. Doanh thu hôm nay (VNĐ)
        //   2. Tổng số hóa đơn đã xuất (kèm số hóa đơn hôm nay)
        //   3. Số khách hàng mới đăng ký hôm nay
        //   4. Số mặt hàng sắp hết hàng (tồn kho <= 10)
        // =========================================================================
        [HttpGet("dashboard-summary")]
        public async Task<IActionResult> GetDashboardSummary()
        {
            const int lowStockThreshold = Product.LowStockThreshold;
            DateTime today = DateTime.Today;
            DateTime tomorrow = today.AddDays(1);

            string connectionString = _configuration.GetConnectionString("DefaultConnection")!;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    // Hàm cục bộ: chạy 1 câu lệnh trả về đúng 1 giá trị (ExecuteScalar), dùng tham số chống SQL Injection
                    async Task<object?> ScalarAsync(string sql, params (string Name, object Value)[] parameters)
                    {
                        using (SqlCommand cmd = new SqlCommand(sql, connection))
                        {
                            foreach (var p in parameters)
                            {
                                cmd.Parameters.AddWithValue(p.Name, p.Value);
                            }
                            return await cmd.ExecuteScalarAsync();
                        }
                    }

                    decimal revenueToday = Convert.ToDecimal(await ScalarAsync(
                        @"SELECT ISNULL(SUM(FinalAmount), 0) FROM Orders
                          WHERE CreatedDate >= @From AND CreatedDate < @To",
                        ("@From", today), ("@To", tomorrow)));

                    int totalInvoices = Convert.ToInt32(await ScalarAsync(
                        "SELECT COUNT(*) FROM Orders"));

                    int invoicesToday = Convert.ToInt32(await ScalarAsync(
                        "SELECT COUNT(*) FROM Orders WHERE CreatedDate >= @From AND CreatedDate < @To",
                        ("@From", today), ("@To", tomorrow)));

                    int newCustomersToday = Convert.ToInt32(await ScalarAsync(
                        "SELECT COUNT(*) FROM Customers WHERE CreatedDate >= @From AND CreatedDate < @To",
                        ("@From", today), ("@To", tomorrow)));

                    int lowStockProducts = Convert.ToInt32(await ScalarAsync(
                        "SELECT COUNT(*) FROM Products WHERE StockQuantity <= @Threshold",
                        ("@Threshold", lowStockThreshold)));

                    return Ok(new
                    {
                        success = true,
                        revenueToday,
                        totalInvoices,
                        invoicesToday,
                        newCustomersToday,
                        lowStockProducts,
                        lowStockThreshold
                    });
                }
            }
            catch (SqlException ex)
            {
                return StatusCode(500, new { success = false, message = "Lỗi truy vấn dashboard: " + ex.Message });
            }
        }

        // =========================================================================
        // [TC 45] GET: api/Reports/revenue-by-day?fromDate=2026-10-01&toDate=2026-10-31
        // Gọi Stored Procedure sp_GetRevenueByDay (GROUP BY CAST(CreatedDate AS DATE))
        // để WinForms vẽ biểu đồ cột doanh thu từng ngày.
        // =========================================================================
        [HttpGet("revenue-by-day")]
        public async Task<IActionResult> GetRevenueByDay([FromQuery] DateTime? fromDate, [FromQuery] DateTime? toDate)
        {
            DateTime fromDay = (fromDate ?? DateTime.Today.AddDays(-6)).Date;
            DateTime toDay = (toDate ?? DateTime.Today).Date;

            if (fromDay > toDay)
            {
                return BadRequest(new { success = false, message = "Từ ngày không được lớn hơn đến ngày!" });
            }
            if ((toDay - fromDay).TotalDays > 366)
            {
                return BadRequest(new { success = false, message = "Chỉ xem tối đa 366 ngày mỗi lần!" });
            }

            var data = new List<object>();
            string connectionString = _configuration.GetConnectionString("DefaultConnection")!;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand("sp_GetRevenueByDay", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FromDate", fromDay);
                    command.Parameters.AddWithValue("@ToDate", toDay);

                    await connection.OpenAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            data.Add(new
                            {
                                date = Convert.ToDateTime(reader["OrderDate"]).ToString("yyyy-MM-dd"),
                                totalOrders = Convert.ToInt32(reader["TotalOrders"]),
                                totalRevenue = Convert.ToDecimal(reader["TotalRevenue"])
                            });
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                // Thường do chưa chạy script tạo sp_GetRevenueByDay trong StoredProcedures.sql
                return StatusCode(500, new { success = false, message = "Lỗi thực thi Stored Procedure: " + ex.Message });
            }

            return Ok(new { success = true, data });
        }

        // GET: api/Reports/revenue-by-hour?date=2026-11-05
        [HttpGet("revenue-by-hour")]
        public async Task<IActionResult> GetRevenueByHour([FromQuery] DateTime? date)
        {
            DateTime day = (date ?? DateTime.Today).Date;
            if (day == DateTime.MaxValue.Date)
            {
                return BadRequest(new { success = false, message = "Ngày phải nhỏ hơn ngày 31/12/9999!" });
            }

            DateTime nextDay = day.AddDays(1);
            var hourly = await _context.Orders.AsNoTracking()
                .Where(o => o.CreatedDate >= day && o.CreatedDate < nextDay)
                .GroupBy(o => o.CreatedDate.Hour)
                .Select(g => new
                {
                    hour = g.Key,
                    totalOrders = g.Count(),
                    totalRevenue = g.Sum(o => o.FinalAmount)
                })
                .ToListAsync(HttpContext.RequestAborted);

            var byHour = hourly.ToDictionary(row => row.hour);
            var data = Enumerable.Range(0, 24).Select(hour => new
            {
                hour,
                totalOrders = byHour.TryGetValue(hour, out var row) ? row.totalOrders : 0,
                totalRevenue = byHour.TryGetValue(hour, out var revenue) ? revenue.totalRevenue : 0m
            });
            return Ok(new { success = true, date = day.ToString("yyyy-MM-dd"), data });
        }

        // =========================================================================
        // [TC 46] GET: api/Reports/best-sellers
        // Top 5 mặt hàng bán chạy nhất bằng LINQ: GroupBy -> OrderByDescending(Sum Quantity) -> Take(5)
        // =========================================================================
        [HttpGet("best-sellers")]
        public async Task<IActionResult> GetBestSellers()
        {
            var top5 = await _context.OrderDetails
                .AsNoTracking()
                .GroupBy(od => od.ProductId)
                .Select(g => new
                {
                    ProductId = g.Key,
                    TotalSold = g.Sum(od => od.Quantity),
                    TotalRevenue = g.Sum(od => od.LineTotal)
                })
                .OrderByDescending(x => x.TotalSold)
                .Take(5)
                .ToListAsync();

            // Lấy tên sản phẩm bằng 1 truy vấn riêng (tránh join phức tạp sau GroupBy)
            var ids = top5.Select(x => x.ProductId).ToList();
            var names = await _context.Products
                .AsNoTracking()
                .Where(p => ids.Contains(p.ProductId))
                .ToDictionaryAsync(p => p.ProductId, p => p.ProductName);

            var data = top5.Select(x => new TopProductDto
            {
                ProductId = x.ProductId,
                ProductName = names.TryGetValue(x.ProductId, out var name) ? name : "(Đã xóa)",
                TotalSold = x.TotalSold,
                TotalRevenue = x.TotalRevenue
            }).ToList();

            return Ok(new { success = true, data });
        }

        // GET: api/Reports/revenue-by-cashier
        // Không truyền ngày: giữ báo cáo toàn lịch sử qua Stored Procedure.
        // Có bộ lọc ngày: tổng hợp tại SQL Server bằng EF Core, lấy trọn ngày cuối.
        [HttpGet("revenue-by-cashier")]
        public async Task<IActionResult> GetRevenueByCashier(
            [FromQuery] DateTime? fromDate,
            [FromQuery] DateTime? toDate)
        {
            DateTime? fromDay = fromDate?.Date;
            DateTime? toDay = toDate?.Date;
            if (fromDay.HasValue && toDay.HasValue && fromDay.Value > toDay.Value)
            {
                return BadRequest(new { success = false, message = "Từ ngày không được lớn hơn đến ngày!" });
            }
            if (toDay == DateTime.MaxValue.Date)
            {
                return BadRequest(new { success = false, message = "Đến ngày phải nhỏ hơn ngày 31/12/9999!" });
            }

            if (fromDay.HasValue || toDay.HasValue)
            {
                var query = _context.Orders.AsNoTracking().AsQueryable();
                if (fromDay.HasValue)
                {
                    DateTime fromValue = fromDay.Value;
                    query = query.Where(o => o.CreatedDate >= fromValue);
                }
                if (toDay.HasValue)
                {
                    DateTime toExclusive = toDay.Value.AddDays(1);
                    query = query.Where(o => o.CreatedDate < toExclusive);
                }

                var filteredReport = await query
                    .GroupBy(o => o.CashierUsername)
                    .Select(g => new CashierRevenueDto
                    {
                        CashierUsername = g.Key,
                        TotalOrders = g.Count(),
                        TotalRevenue = g.Sum(o => o.FinalAmount),
                        TotalPointsAwarded = g.Sum(o => o.RewardPoints)
                    })
                    .OrderByDescending(r => r.TotalRevenue)
                    .ThenBy(r => r.CashierUsername)
                    .ToListAsync();

                return Ok(new
                {
                    success = true,
                    generatedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    totalCashiers = filteredReport.Count,
                    grandTotalRevenue = filteredReport.Sum(r => r.TotalRevenue),
                    data = filteredReport
                });
            }

            var reportList = new List<CashierRevenueDto>();
            string connectionString = _configuration.GetConnectionString("DefaultConnection")!;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // CommandText là TÊN thủ tục, không phải câu SQL
                using (SqlCommand command = new SqlCommand("sp_GetRevenueByCashier", connection))
                {
                    // BẮT BUỘC: nếu thiếu dòng này SQL Server hiểu nhầm là câu SQL thường và báo lỗi cú pháp
                    command.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                reportList.Add(new CashierRevenueDto
                                {
                                    CashierUsername = reader["CashierUsername"].ToString() ?? string.Empty,
                                    TotalOrders = Convert.ToInt32(reader["TotalOrders"]),
                                    TotalRevenue = Convert.ToDecimal(reader["TotalRevenue"]),
                                    // Cột tổng hợp có thể là NULL nên phải kiểm tra DBNull
                                    TotalPointsAwarded = reader["TotalPointsAwarded"] != DBNull.Value
                                        ? Convert.ToInt32(reader["TotalPointsAwarded"])
                                        : 0
                                });
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        // Thường do chưa tạo Stored Procedure hoặc tạo nhầm database
                        return StatusCode(500, new
                        {
                            success = false,
                            message = "Lỗi thực thi Stored Procedure trên SQL Server: " + ex.Message
                        });
                    }
                }
            }

            return Ok(new
            {
                success = true,
                generatedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                totalCashiers = reportList.Count,
                grandTotalRevenue = reportList.Sum(x => x.TotalRevenue),
                data = reportList
            });
        }

        // =========================================================================
        // BÀI TẬP 3.1: GET api/Reports/revenue-by-date?fromDate=2026-03-01&toDate=2026-03-03
        // Gọi sp_GetRevenueByDateRange có 2 tham số (CommandType.StoredProcedure + SqlParameter)
        // =========================================================================
        [HttpGet("revenue-by-date")]
        public async Task<IActionResult> GetRevenueByDate([FromQuery] DateTime fromDate, [FromQuery] DateTime toDate)
        {
            if (fromDate > toDate)
            {
                return BadRequest(new { success = false, message = "Từ ngày không được lớn hơn đến ngày!" });
            }

            // Người dùng chọn ngày (00:00) -> tính hết cả ngày cuối: đến 23:59:59
            DateTime fromValue = fromDate.Date;
            DateTime toValue = toDate.Date.AddDays(1).AddSeconds(-1);

            var reportList = new List<CashierRevenueDto>();
            string connectionString = _configuration.GetConnectionString("DefaultConnection")!;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_GetRevenueByDateRange", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FromDate", fromValue);
                    command.Parameters.AddWithValue("@ToDate", toValue);

                    try
                    {
                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                reportList.Add(new CashierRevenueDto
                                {
                                    CashierUsername = reader["CashierUsername"].ToString() ?? string.Empty,
                                    TotalOrders = Convert.ToInt32(reader["TotalOrders"]),
                                    TotalRevenue = Convert.ToDecimal(reader["TotalRevenue"]),
                                    TotalPointsAwarded = reader["TotalPointsAwarded"] != DBNull.Value
                                        ? Convert.ToInt32(reader["TotalPointsAwarded"])
                                        : 0
                                });
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        return StatusCode(500, new
                        {
                            success = false,
                            message = "Lỗi thực thi Stored Procedure trên SQL Server: " + ex.Message
                        });
                    }
                }
            }

            return Ok(new
            {
                success = true,
                from = fromValue.ToString("yyyy-MM-dd HH:mm:ss"),
                to = toValue.ToString("yyyy-MM-dd HH:mm:ss"),
                totalCashiers = reportList.Count,
                grandTotalRevenue = reportList.Sum(x => x.TotalRevenue),
                data = reportList
            });
        }

        // =========================================================================
        // BÀI TẬP 3.2: GET api/Reports/top-products
        // Gọi sp_GetTop5SellingProducts - phục vụ Dashboard Admin
        // =========================================================================
        [HttpGet("top-products")]
        public async Task<IActionResult> GetTopProducts()
        {
            var list = new List<TopProductDto>();
            string connectionString = _configuration.GetConnectionString("DefaultConnection")!;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_GetTop5SellingProducts", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                list.Add(new TopProductDto
                                {
                                    ProductId = Convert.ToInt32(reader["ProductId"]),
                                    ProductName = reader["ProductName"].ToString() ?? string.Empty,
                                    TotalSold = Convert.ToInt32(reader["TotalSold"]),
                                    TotalRevenue = Convert.ToDecimal(reader["TotalRevenue"])
                                });
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        return StatusCode(500, new
                        {
                            success = false,
                            message = "Lỗi thực thi Stored Procedure trên SQL Server: " + ex.Message
                        });
                    }
                }
            }

            return Ok(new { success = true, total = list.Count, data = list });
        }

        // =========================================================================
        // GET api/Reports/quick-report?fromDate=2026-03-01&toDate=2026-03-07
        // Báo cáo nhanh theo KHOẢNG NGÀY cho FormQuickReport: số hóa đơn, doanh thu, mặt hàng bán chạy nhất
        // - Chỉ truyền fromDate  -> báo cáo đúng 1 ngày đó
        // - Không truyền gì      -> báo cáo hôm nay
        // - Vẫn hỗ trợ ?date=... (tham số cũ) để không làm hỏng chỗ nào đang gọi theo kiểu cũ
        // =========================================================================
        [HttpGet("quick-report")]
        public async Task<IActionResult> GetQuickReport(
            [FromQuery] DateTime? fromDate,
            [FromQuery] DateTime? toDate,
            [FromQuery] DateTime? date)
        {
            DateTime fromDay = (fromDate ?? date ?? DateTime.Today).Date;
            DateTime toDay = (toDate ?? fromDate ?? date ?? DateTime.Today).Date;

            if (fromDay > toDay)
            {
                return BadRequest(new { success = false, message = "Từ ngày không được lớn hơn đến ngày!" });
            }

            // Khoảng thời gian nửa mở [00:00 ngày bắt đầu, 00:00 ngày SAU ngày kết thúc)
            // -> tính trọn cả ngày cuối mà không bị sót hóa đơn lúc 23:59:59.x
            DateTime fromValue = fromDay;
            DateTime toValue = toDay.AddDays(1);

            int totalOrders = 0;
            decimal totalRevenue = 0;
            object? bestSeller = null;

            string connectionString = _configuration.GetConnectionString("DefaultConnection")!;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    await connection.OpenAsync();

                    // Truy vấn 1: tổng số hóa đơn và tổng doanh thu trong khoảng ngày
                    string summarySql = @"SELECT COUNT(*) AS TotalOrders, ISNULL(SUM(FinalAmount), 0) AS TotalRevenue
                                          FROM Orders
                                          WHERE CreatedDate >= @From AND CreatedDate < @To";

                    using (SqlCommand cmdSummary = new SqlCommand(summarySql, connection))
                    {
                        cmdSummary.Parameters.AddWithValue("@From", fromValue);
                        cmdSummary.Parameters.AddWithValue("@To", toValue);

                        using (SqlDataReader reader = await cmdSummary.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                totalOrders = Convert.ToInt32(reader["TotalOrders"]);
                                totalRevenue = Convert.ToDecimal(reader["TotalRevenue"]);
                            }
                        }
                    }

                    // Truy vấn 2: mặt hàng bán nhiều nhất trong khoảng ngày (bằng nhau thì lấy doanh thu cao hơn)
                    // Cột OrderId có ở cả Orders và OrderDetails nên PHẢI ghi rõ bí danh (o. / od.)
                    string bestSql = @"SELECT TOP 1 p.ProductId, p.ProductName, SUM(od.Quantity) AS TotalSold
                                       FROM OrderDetails od
                                       INNER JOIN Orders o ON o.OrderId = od.OrderId
                                       INNER JOIN Products p ON p.ProductId = od.ProductId
                                       WHERE o.CreatedDate >= @From AND o.CreatedDate < @To
                                       GROUP BY p.ProductId, p.ProductName
                                       ORDER BY SUM(od.Quantity) DESC, SUM(od.LineTotal) DESC";

                    using (SqlCommand cmdBest = new SqlCommand(bestSql, connection))
                    {
                        cmdBest.Parameters.AddWithValue("@From", fromValue);
                        cmdBest.Parameters.AddWithValue("@To", toValue);

                        using (SqlDataReader reader = await cmdBest.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                bestSeller = new
                                {
                                    productId = Convert.ToInt32(reader["ProductId"]),
                                    productName = reader["ProductName"].ToString(),
                                    totalSold = Convert.ToInt32(reader["TotalSold"])
                                };
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    return StatusCode(500, new
                    {
                        success = false,
                        message = "Lỗi truy vấn SQL Server: " + ex.Message
                    });
                }
            }

            return Ok(new
            {
                success = true,
                date = fromValue.ToString("yyyy-MM-dd"), // giữ lại cho tương thích với bản cũ
                fromDate = fromDay.ToString("yyyy-MM-dd"),
                toDate = toDay.ToString("yyyy-MM-dd"),
                totalOrders = totalOrders,
                totalRevenue = totalRevenue,
                bestSeller = bestSeller
            });
        }
    }
}
