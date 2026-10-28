/*
 * Ho ten sinh vien: Nguyen Le Tan Phuc
 * Ma sinh vien: 2124110108
 * Mo ta: Controller ADO.NET goi Stored Procedure xuat bao cao doanh thu theo thu ngan
 */
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
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

        public ReportsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: api/Reports/revenue-by-cashier
        // Gọi Stored Procedure sp_GetRevenueByCashier bằng SqlDataReader
        [HttpGet("revenue-by-cashier")]
        public async Task<IActionResult> GetRevenueByCashier()
        {
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