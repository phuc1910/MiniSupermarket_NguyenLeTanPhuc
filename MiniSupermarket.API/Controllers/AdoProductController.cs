/*
 * Ho ten sinh vien: Nguyen Le Tan Phuc
 * Ma sinh vien: 2124110108
 * Mo ta: Controller ADO.NET thuan - Tra cuu ma vach sieu toc (SqlDataReader)
 *        va demo DataTable/SqlDataAdapter (Disconnected Mode)
 */
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace MiniSupermarket.API.Controllers
{
    // DTO tra cứu sản phẩm cho quầy POS
    public class ProductLookupDto
    {
        public int ProductId { get; set; }
        public string Barcode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
    }

    [Route("api/ado-products")]
    [ApiController]
    [Authorize] // Giống các controller khác: phải có JWT Token (gửi header Authorization: Bearer <token>)
    public class AdoProductController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        // Tiêm IConfiguration để đọc chuỗi kết nối từ appsettings.json
        public AdoProductController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // =========================================================================
        // THAO TÁC 1: TRA CỨU THEO MÃ VẠCH (CONNECTED MODE - SQLDATAREADER)
        // GET: api/ado-products/barcode/8809123456011
        // =========================================================================
        [HttpGet("barcode/{barcode}")]
        public IActionResult GetProductByBarcode(string barcode)
        {
            if (string.IsNullOrWhiteSpace(barcode))
            {
                return BadRequest(new { message = "Mã vạch không được để trống!" });
            }

            string connectionString = _configuration.GetConnectionString("DefaultConnection")!;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Tham số hóa @Barcode để chống SQL Injection
                string query = @"SELECT ProductId, Barcode, ProductName, Price, StockQuantity
                                 FROM Products
                                 WHERE Barcode = @Barcode";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Barcode", barcode.Trim());

                    try
                    {
                        connection.Open();

                        // Luồng đọc nhanh một chiều (Forward-Only), đọc đúng 1 dòng rồi đóng
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                var productDto = new ProductLookupDto
                                {
                                    ProductId = Convert.ToInt32(reader["ProductId"]),
                                    Barcode = reader["Barcode"].ToString() ?? string.Empty,
                                    ProductName = reader["ProductName"].ToString() ?? string.Empty,
                                    Price = Convert.ToDecimal(reader["Price"]),
                                    StockQuantity = Convert.ToInt32(reader["StockQuantity"])
                                };

                                return Ok(productDto);
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        return StatusCode(500, new { message = "Lỗi truy vấn SQL: " + ex.Message });
                    }
                }
            } // connection.Close() tự động được gọi tại đây

            // Không có dòng nào khớp -> 404
            return NotFound(new { message = $"Không tìm thấy sản phẩm có mã vạch: {barcode}" });
        }

        // =========================================================================
        // THAO TÁC 2: TẢI DANH SÁCH LƯU ĐỆM (DISCONNECTED MODE - DATATABLE & ADAPTER)
        // GET: api/ado-products/disconnected-cache
        // =========================================================================
        [HttpGet("disconnected-cache")]
        public IActionResult GetProductsDisconnected()
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection")!;

            // 1. Bảng ảo trên RAM
            DataTable productTable = new DataTable("CachedProducts");

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"SELECT ProductId, Barcode, ProductName, Price, StockQuantity
                                     FROM Products
                                     ORDER BY ProductId ASC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // 2. SqlDataAdapter làm cầu nối giữa Command và DataTable
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            // 3. Fill(): tự động Open -> đọc dữ liệu đổ vào DataTable -> tự động Close
                            //    (nên KHÔNG cần gọi connection.Open() ở đây)
                            adapter.Fill(productTable);
                        }
                    }
                } // Tại đây kết nối đã đóng hoàn toàn
            }
            catch (SqlException ex)
            {
                return StatusCode(500, new { message = "Lỗi truy vấn SQL: " + ex.Message });
            }

            // 4. Xử lý trên RAM, không còn kết nối tới SQL Server
            var resultList = new List<ProductLookupDto>();

            foreach (DataRow row in productTable.Rows)
            {
                resultList.Add(new ProductLookupDto
                {
                    ProductId = Convert.ToInt32(row["ProductId"]),
                    Barcode = row["Barcode"].ToString() ?? string.Empty,
                    ProductName = row["ProductName"].ToString() ?? string.Empty,
                    Price = Convert.ToDecimal(row["Price"]),
                    StockQuantity = Convert.ToInt32(row["StockQuantity"])
                });
            }

            return Ok(new
            {
                totalLoaded = productTable.Rows.Count,
                cachedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                data = resultList
            });
        }

        // =========================================================================
        // BÀI TẬP 2.1: CẢNH BÁO TỒN KHO THẤP (SqlDataReader + SqlParameter)
        // GET: api/ado-products/filter-stock?minStock=20
        // Trả về các sản phẩm có tồn kho <= minStock để nhắc nhập thêm hàng
        // =========================================================================
        [HttpGet("filter-stock")]
        public IActionResult FilterByStock([FromQuery] int minStock)
        {
            if (minStock < 0)
            {
                return BadRequest(new { message = "Ngưỡng tồn kho không được nhỏ hơn 0!" });
            }

            var list = new List<ProductLookupDto>();
            string connectionString = _configuration.GetConnectionString("DefaultConnection")!;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT ProductId, Barcode, ProductName, Price, StockQuantity
                                 FROM Products
                                 WHERE StockQuantity <= @MinStock
                                 ORDER BY StockQuantity ASC";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MinStock", minStock);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new ProductLookupDto
                                {
                                    ProductId = Convert.ToInt32(reader["ProductId"]),
                                    Barcode = reader["Barcode"].ToString() ?? string.Empty,
                                    ProductName = reader["ProductName"].ToString() ?? string.Empty,
                                    Price = Convert.ToDecimal(reader["Price"]),
                                    StockQuantity = Convert.ToInt32(reader["StockQuantity"])
                                });
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        return StatusCode(500, new { message = "Lỗi truy vấn SQL: " + ex.Message });
                    }
                }
            }

            return Ok(new { threshold = minStock, total = list.Count, data = list });
        }

        // =========================================================================
        // BÀI TẬP 2.2: ĐẾM SẢN PHẨM THEO NHÓM HÀNG (DataTable + SqlDataAdapter)
        // GET: api/ado-products/count-by-category
        // =========================================================================
        [HttpGet("count-by-category")]
        public IActionResult CountByCategory()
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection")!;
            DataTable table = new DataTable("CategoryCount");

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // JOIN thêm Categories để có tên nhóm hàng thay vì chỉ có CategoryId
                    string query = @"SELECT p.CategoryId, c.CategoryName, COUNT(*) AS Total
                                     FROM Products p
                                     INNER JOIN Categories c ON c.CategoryId = p.CategoryId
                                     GROUP BY p.CategoryId, c.CategoryName
                                     ORDER BY p.CategoryId";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        adapter.Fill(table); // Tự mở và đóng kết nối
                    }
                }
            }
            catch (SqlException ex)
            {
                return StatusCode(500, new { message = "Lỗi truy vấn SQL: " + ex.Message });
            }

            // Duyệt DataTable trên RAM
            var result = new List<object>();
            foreach (DataRow row in table.Rows)
            {
                result.Add(new
                {
                    categoryId = Convert.ToInt32(row["CategoryId"]),
                    categoryName = row["CategoryName"].ToString(),
                    total = Convert.ToInt32(row["Total"])
                });
            }

            return Ok(new { totalCategories = result.Count, data = result });
        }
    }
}
