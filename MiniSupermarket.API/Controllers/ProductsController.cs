// Import các thành phần dùng để xây dựng Controller API
using Microsoft.AspNetCore.Mvc;

// Dùng Expression để tái sử dụng phép chiếu Entity -> DTO trong truy vấn LINQ
using System.Linq.Expressions;

// Import Entity Framework Core để truy vấn và thao tác với Database
using Microsoft.EntityFrameworkCore;

// [BUỔI 5] Import ADO.NET thuần để tra cứu mã vạch tốc độ cao
// (gói Microsoft.Data.SqlClient đã đi kèm EF Core SqlServer, không cần cài thêm)
using Microsoft.Data.SqlClient;

// Import các thuộc tính dùng để phân quyền truy cập API
using Microsoft.AspNetCore.Authorization;

// Import DbContext của hệ thống MiniSupermarket
using MiniSupermarket.API.Data;

// Import các Model của hệ thống
using MiniSupermarket.API.Models;

// Namespace chứa các Controller của hệ thống MiniSupermarket
namespace MiniSupermarket.API.Controllers
{
    // Thiết lập đường dẫn gốc cho Controller
    // URL: api/Products
    [Route("api/[controller]")]

    // Đánh dấu đây là Controller dành cho Web API
    [ApiController]

    // Yêu cầu người dùng phải có JWT Token hợp lệ để truy cập
    [Authorize]
    public class ProductsController : ControllerBase
    {
        // Khai báo DbContext để thao tác với Database
        private readonly SupermarketDbContext _context;

        // [BUỔI 5] Đọc chuỗi kết nối từ appsettings.json cho các hàm ADO.NET
        private readonly IConfiguration _configuration;

        // Tiêm DbContext và IConfiguration vào Controller thông qua Dependency Injection
        public ProductsController(SupermarketDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // Phép chiếu Entity -> DTO dùng chung: API không trả nguyên Entity CSDL ra ngoài
        private static readonly Expression<Func<Product, ProductItemDto>> ToDto = p => new ProductItemDto
        {
            ProductId = p.ProductId,
            Barcode = p.Barcode,
            ProductName = p.ProductName,
            Price = p.Price,
            StockQuantity = p.StockQuantity,
            CategoryId = p.CategoryId,
            CategoryName = p.Category != null ? p.Category.CategoryName : string.Empty
        };

        // GET: api/Products
        // Lấy danh sách toàn bộ sản phẩm (trả về DTO)
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Include(Category) để lấy tên nhóm hàng, AsNoTracking() tối ưu truy vấn chỉ đọc
            var products = await _context.Products
                .Include(p => p.Category)
                .AsNoTracking()
                .OrderBy(p => p.ProductId)
                .Select(ToDto)
                .ToListAsync();

            return Ok(products);
        }

        // GET: api/Products/1
        // Lấy thông tin sản phẩm theo ID (trả về DTO)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _context.Products
                .Include(p => p.Category)
                .AsNoTracking()
                .Where(p => p.ProductId == id)
                .Select(ToDto)
                .FirstOrDefaultAsync();

            if (product == null)
            {
                return NotFound(new
                {
                    message = "Không tìm thấy sản phẩm!"
                });
            }

            return Ok(product);
        }

        // GET: api/Products/search?keyword=nuoc&categoryId=1
        // keyword: tìm gần đúng theo mã vạch hoặc tên; categoryId: lọc theo nhóm hàng
        [HttpGet("search")]
        public async Task<IActionResult> Search(
            [FromQuery] string? keyword,
            [FromQuery] int? categoryId)
        {
            var query = _context.Products
                .Include(p => p.Category)
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.Trim();
                query = query.Where(p =>
                    p.Barcode.Contains(keyword) ||
                    p.ProductName.Contains(keyword));
            }

            if (categoryId.HasValue)
            {
                if (categoryId.Value <= 0)
                {
                    return BadRequest(new
                    {
                        message = "Mã nhóm hàng không hợp lệ!"
                    });
                }

                query = query.Where(p => p.CategoryId == categoryId.Value);
            }

            var products = await query
                .OrderBy(p => p.ProductId)
                .Select(ToDto)
                .ToListAsync();

            return Ok(products);
        }

        // [BUỔI 6] GET: api/Products/paged?keyword=sua&categoryId=2&pageNumber=1&pageSize=5
        // Phân trang phía máy chủ bằng LINQ .Skip() / .Take() + tìm kiếm gần đúng .Contains()
        // + lọc theo nhóm hàng. Trả về PagedResult<ProductItemDto> (DTO, không trả Entity)
        [HttpGet("paged")]
        public async Task<IActionResult> GetPagedProducts(
            [FromQuery] string? keyword,
            [FromQuery] int? categoryId,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 5)
        {
            if (pageNumber < 1) pageNumber = 1;
            if (pageSize < 1 || pageSize > 50) pageSize = 5; // Mặc định 5 dòng, tối đa 50 dòng

            var query = _context.Products
                .Include(p => p.Category)
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                string search = keyword.Trim().ToLower();
                query = query.Where(p => p.ProductName.ToLower().Contains(search)
                                      || p.Barcode.Contains(search));
            }

            if (categoryId.HasValue && categoryId.Value > 0)
            {
                query = query.Where(p => p.CategoryId == categoryId.Value);
            }

            int totalItems = await query.CountAsync();
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            // Skip + Take -> EF Core dịch thành OFFSET ... FETCH NEXT ... trên SQL Server
            var items = await query
                .OrderBy(p => p.ProductId) // Bắt buộc phải OrderBy trước khi Skip/Take
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(ToDto)
                .ToListAsync();

            return Ok(new PagedResult<ProductItemDto>
            {
                CurrentPage = pageNumber,
                PageSize = pageSize,
                TotalItems = totalItems,
                TotalPages = totalPages,
                Items = items
            });
        }

        // GET: api/Products/with-category
        // Danh sách sản phẩm kèm tên nhóm hàng (Eager Loading) - dùng cho xuất báo cáo tồn kho.
        // IsLowStock lấy theo ngưỡng chung Product.LowStockThreshold (tồn kho <= 10)
        [HttpGet("with-category")]
        public async Task<IActionResult> GetWithCategory()
        {
            var products = await _context.Products
                .Include(p => p.Category)
                .AsNoTracking()
                .OrderBy(p => p.ProductId)
                .Select(ToDto)
                .ToListAsync();

            return Ok(products);
        }

        // =========================================================================
        // [BUỔI 5] GET: api/Products/barcode/8809123456011
        // Tra cứu sản phẩm theo mã vạch bằng ADO.NET (Connected Mode - SqlDataReader)
        // FormPOS gọi sẵn đường dẫn này: products/barcode/{barcode}
        // =========================================================================
        [HttpGet("barcode/{barcode}")]
        public async Task<IActionResult> GetByBarcode(string barcode)
        {
            // Kiểm tra mã vạch đầu vào
            if (string.IsNullOrWhiteSpace(barcode))
            {
                return BadRequest(new { message = "Mã vạch không được để trống!" });
            }

            // Lấy chuỗi kết nối tới SQL Server
            string connectionString = _configuration.GetConnectionString("DefaultConnection")!;

            // using đảm bảo SqlConnection luôn được đóng dù có lỗi
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Câu SELECT có tham số @Barcode để chống SQL Injection
                string query = @"SELECT ProductId, Barcode, ProductName, Price, StockQuantity, CategoryId
                                 FROM Products
                                 WHERE Barcode = @Barcode";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Barcode", barcode.Trim());

                    try
                    {
                        await connection.OpenAsync();

                        // Luồng đọc nhanh một chiều, chỉ cần đọc đúng 1 dòng
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return Ok(new
                                {
                                    ProductId = Convert.ToInt32(reader["ProductId"]),
                                    Barcode = reader["Barcode"].ToString(),
                                    ProductName = reader["ProductName"].ToString(),
                                    Price = Convert.ToDecimal(reader["Price"]),
                                    StockQuantity = Convert.ToInt32(reader["StockQuantity"]),
                                    CategoryId = Convert.ToInt32(reader["CategoryId"])
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

            // Không có dòng nào khớp mã vạch -> 404
            return NotFound(new { message = $"Không tìm thấy sản phẩm có mã vạch: {barcode}" });
        }

        // POST: api/Products
        // Thêm sản phẩm mới - nhận ProductRequestDto (không nhận thẳng Entity)
        // Chỉ tài khoản có vai trò Admin được thực hiện
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] ProductRequestDto dto)
        {
            // Kiểm tra dữ liệu theo DataAnnotations của DTO
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string barcode = dto.Barcode.Trim();
            string productName = dto.ProductName.Trim();

            if (barcode.Length == 0)
            {
                return BadRequest(new { message = "Mã vạch không được để trống!" });
            }

            if (productName.Length == 0)
            {
                return BadRequest(new { message = "Tên sản phẩm không được để trống!" });
            }

            if (dto.Price <= 0)
            {
                return BadRequest(new { message = "Đơn giá phải lớn hơn 0!" });
            }

            if (dto.StockQuantity < 0)
            {
                return BadRequest(new { message = "Số lượng tồn kho không được nhỏ hơn 0!" });
            }

            // Kiểm tra nhóm hàng có tồn tại hay không (đồng thời lấy tên nhóm để trả về)
            var category = await _context.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.CategoryId == dto.CategoryId);

            if (category == null)
            {
                return BadRequest(new { message = "Nhóm hàng không tồn tại!" });
            }

            if (await _context.Products.AnyAsync(p => p.Barcode == barcode))
            {
                return Conflict(new { message = "Mã vạch đã tồn tại!" });
            }

            // Map DTO -> Entity (ProductId do CSDL tự sinh)
            var newProduct = new Product
            {
                Barcode = barcode,
                ProductName = productName,
                Price = dto.Price,
                StockQuantity = dto.StockQuantity,
                CategoryId = dto.CategoryId
            };

            _context.Products.Add(newProduct);
            await _context.SaveChangesAsync();

            // Trả về HTTP 201 Created cùng DTO của sản phẩm vừa tạo
            return CreatedAtAction(
                nameof(GetById),
                new { id = newProduct.ProductId },
                new ProductItemDto
                {
                    ProductId = newProduct.ProductId,
                    Barcode = newProduct.Barcode,
                    ProductName = newProduct.ProductName,
                    Price = newProduct.Price,
                    StockQuantity = newProduct.StockQuantity,
                    CategoryId = newProduct.CategoryId,
                    CategoryName = category.CategoryName
                });
        }

        // PUT: api/Products/1
        // Cập nhật sản phẩm theo ID - nhận ProductRequestDto
        // Chỉ tài khoản có vai trò Admin được thực hiện
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductRequestDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.ProductId == id);

            if (product == null)
            {
                return NotFound(new { message = "Không tìm thấy sản phẩm cần sửa!" });
            }

            string barcode = dto.Barcode.Trim();
            string productName = dto.ProductName.Trim();

            if (barcode.Length == 0)
            {
                return BadRequest(new { message = "Mã vạch không được để trống!" });
            }

            if (productName.Length == 0)
            {
                return BadRequest(new { message = "Tên sản phẩm không được để trống!" });
            }

            if (dto.Price <= 0)
            {
                return BadRequest(new { message = "Đơn giá phải lớn hơn 0!" });
            }

            if (dto.StockQuantity < 0)
            {
                return BadRequest(new { message = "Số lượng tồn kho không được nhỏ hơn 0!" });
            }

            if (!await _context.Categories.AnyAsync(c => c.CategoryId == dto.CategoryId))
            {
                return BadRequest(new { message = "Nhóm hàng không tồn tại!" });
            }

            // Mã vạch không được trùng với sản phẩm khác
            if (await _context.Products.AnyAsync(p => p.Barcode == barcode && p.ProductId != id))
            {
                return Conflict(new { message = "Mã vạch đã được sử dụng bởi sản phẩm khác!" });
            }

            product.Barcode = barcode;
            product.ProductName = productName;
            product.Price = dto.Price;
            product.StockQuantity = dto.StockQuantity;
            product.CategoryId = dto.CategoryId;

            await _context.SaveChangesAsync();

            return Ok(new
            {
                success = true,
                message = "Cập nhật sản phẩm thành công!"
            });
        }

        // DELETE: api/Products/1
        // Xóa sản phẩm theo ID
        // Chỉ tài khoản có vai trò Admin được thực hiện
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            // Tìm sản phẩm cần xóa trong Database
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.ProductId == id);

            // Kiểm tra sản phẩm có tồn tại hay không
            if (product == null)
            {
                return NotFound(new
                {
                    message = "Không tìm thấy sản phẩm cần xóa!"
                });
            }

            // Kiểm tra sản phẩm đã xuất hiện trong chi tiết hóa đơn hay chưa
            // Không xóa sản phẩm đang được tham chiếu bởi hóa đơn
            var hasOrderDetails = await _context.OrderDetails
                .AnyAsync(od => od.ProductId == id);

            if (hasOrderDetails)
            {
                return Conflict(new
                {
                    message = "Không thể xóa sản phẩm đã có trong hóa đơn!"
                });
            }

            // Đánh dấu sản phẩm cần xóa khỏi Database
            _context.Products.Remove(product);

            // Lưu thay đổi vào Database
            await _context.SaveChangesAsync();

            // Trả về HTTP 200 OK khi xóa thành công
            return Ok(new
            {
                success = true,
                message = "Xóa sản phẩm thành công!"
            });
        }
    }
}
