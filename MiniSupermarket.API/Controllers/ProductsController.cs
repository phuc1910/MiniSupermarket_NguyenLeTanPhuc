// Import các thành phần dùng để xây dựng Controller API
using Microsoft.AspNetCore.Mvc;

// Import Entity Framework Core để truy vấn và thao tác với Database
using Microsoft.EntityFrameworkCore;

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

        // Tiêm DbContext vào Controller thông qua Dependency Injection
        public ProductsController(SupermarketDbContext context)
        {
            _context = context;
        }

        // GET: api/Products
        // Lấy danh sách toàn bộ sản phẩm
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Truy vấn danh sách sản phẩm
            // Include(Category) để lấy thêm thông tin nhóm hàng
            // AsNoTracking() tối ưu truy vấn chỉ đọc
            var products = await _context.Products
                .Include(p => p.Category)
                .AsNoTracking()
                .ToListAsync();

            // Trả về HTTP 200 OK cùng danh sách sản phẩm
            return Ok(products);
        }

        // GET: api/Products/1
        // Lấy thông tin sản phẩm theo ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            // Tìm sản phẩm theo khóa chính ProductId
            // Include(Category) để lấy thông tin nhóm hàng của sản phẩm
            var product = await _context.Products
                .Include(p => p.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.ProductId == id);

            // Kiểm tra sản phẩm có tồn tại hay không
            if (product == null)
            {
                // Trả về HTTP 404 Not Found nếu không tìm thấy
                return NotFound(new
                {
                    message = "Không tìm thấy sản phẩm!"
                });
            }

            // Trả về HTTP 200 OK cùng thông tin sản phẩm
            return Ok(product);
        }


        // GET: api/Products/search?keyword=893456789001
        // GET: api/Products/search?keyword=nuoc
        // GET: api/Products/search?categoryId=1
        // GET: api/Products/search?keyword=nuoc&categoryId=1

        // Khai báo API tìm kiếm sản phẩm.
        // keyword dùng để tìm theo mã vạch hoặc tên sản phẩm.
        // categoryId dùng để lọc sản phẩm theo nhóm hàng.
        [HttpGet("search")]
        public async Task<IActionResult> Search(
            [FromQuery] string? keyword, // Từ khóa tìm kiếm, có thể bỏ trống.
            [FromQuery] int? categoryId) // Mã nhóm hàng, có thể bỏ trống.
        {
            // Khởi tạo truy vấn lấy sản phẩm từ Database.
            var query = _context.Products

                // Lấy thêm thông tin nhóm hàng liên quan đến sản phẩm.
                .Include(p => p.Category)

                // Không theo dõi thay đổi vì chức năng này chỉ đọc dữ liệu.
                .AsNoTracking()

                // Cho phép bổ sung các điều kiện lọc trước khi truy vấn Database.
                .AsQueryable();

            // Kiểm tra người dùng có nhập từ khóa tìm kiếm hay không.
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                // Xóa khoảng trắng ở đầu và cuối từ khóa.
                keyword = keyword.Trim();

                // Tìm sản phẩm có mã vạch chứa từ khóa
                // HOẶC tên sản phẩm chứa từ khóa.
                query = query.Where(p =>
                    p.Barcode.Contains(keyword) ||
                    p.ProductName.Contains(keyword));
            }

            // Kiểm tra người dùng có chọn nhóm hàng để lọc hay không.
            if (categoryId.HasValue)
            {
                // Kiểm tra mã nhóm hàng phải lớn hơn 0.
                if (categoryId.Value <= 0)
                {
                    // Trả về HTTP 400 nếu mã nhóm hàng không hợp lệ.
                    return BadRequest(new
                    {
                        message = "Mã nhóm hàng không hợp lệ!"
                    });
                }

                // Chỉ lấy những sản phẩm thuộc nhóm hàng được chọn.
                query = query.Where(p =>
                    p.CategoryId == categoryId.Value);
            }

            // Thực thi truy vấn và lấy danh sách sản phẩm phù hợp.
            var products = await query.ToListAsync();

            // Trả về HTTP 200 cùng danh sách sản phẩm tìm được.
            // Nếu không có sản phẩm phù hợp, trả về danh sách rỗng.
            return Ok(products);
        }

        // POST: api/Products
        // Thêm sản phẩm mới
        // Chỉ tài khoản có vai trò Admin được thực hiện
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(
            [FromBody] Product newProduct)
        {
            // Kiểm tra dữ liệu gửi lên có hợp lệ theo Model hay không
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Kiểm tra mã vạch không được để trống
            if (string.IsNullOrWhiteSpace(newProduct.Barcode))
            {
                return BadRequest(new
                {
                    message = "Mã vạch không được để trống!"
                });
            }

            // Kiểm tra tên sản phẩm không được để trống
            if (string.IsNullOrWhiteSpace(newProduct.ProductName))
            {
                return BadRequest(new
                {
                    message = "Tên sản phẩm không được để trống!"
                });
            }

            // Kiểm tra giá bán không được âm
            if (newProduct.Price < 0)
            {
                return BadRequest(new
                {
                    message = "Đơn giá không được nhỏ hơn 0!"
                });
            }

            // Kiểm tra số lượng tồn kho không được âm
            if (newProduct.StockQuantity < 0)
            {
                return BadRequest(new
                {
                    message = "Số lượng tồn kho không được nhỏ hơn 0!"
                });
            }

            // Kiểm tra nhóm hàng có tồn tại trong Database hay không
            var categoryExists = await _context.Categories
                .AnyAsync(c => c.CategoryId == newProduct.CategoryId);

            if (!categoryExists)
            {
                return BadRequest(new
                {
                    message = "Nhóm hàng không tồn tại!"
                });
            }

            // Kiểm tra mã vạch đã được sử dụng hay chưa
            var barcodeExists = await _context.Products
                .AnyAsync(p => p.Barcode == newProduct.Barcode);

            if (barcodeExists)
            {
                return Conflict(new
                {
                    message = "Mã vạch đã tồn tại!"
                });
            }

            // Không nhận ProductId do client gửi lên
            // Database sẽ tự động sinh khóa chính
            newProduct.ProductId = 0;

            // Không gán đối tượng Category từ dữ liệu client gửi lên
            // Chỉ sử dụng CategoryId để liên kết với nhóm hàng trong Database
            newProduct.Category = null;

            // Thêm sản phẩm vào DbContext
            _context.Products.Add(newProduct);

            // Lưu sản phẩm vào Database
            await _context.SaveChangesAsync();

            // Trả về HTTP 201 Created
            // Đồng thời cung cấp đường dẫn lấy thông tin sản phẩm vừa tạo
            return CreatedAtAction(
                nameof(GetById),
                new { id = newProduct.ProductId },
                newProduct
            );
        }

        // PUT: api/Products/1
        // Cập nhật thông tin sản phẩm theo ID
        // Chỉ tài khoản có vai trò Admin được thực hiện
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] Product updateProduct)
        {
            // Kiểm tra dữ liệu gửi lên có hợp lệ theo Model hay không
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Tìm sản phẩm cần cập nhật trong Database
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.ProductId == id);

            // Kiểm tra sản phẩm có tồn tại hay không
            if (product == null)
            {
                return NotFound(new
                {
                    message = "Không tìm thấy sản phẩm cần sửa!"
                });
            }

            // Kiểm tra mã vạch không được để trống
            if (string.IsNullOrWhiteSpace(updateProduct.Barcode))
            {
                return BadRequest(new
                {
                    message = "Mã vạch không được để trống!"
                });
            }

            // Kiểm tra tên sản phẩm không được để trống
            if (string.IsNullOrWhiteSpace(updateProduct.ProductName))
            {
                return BadRequest(new
                {
                    message = "Tên sản phẩm không được để trống!"
                });
            }

            // Kiểm tra giá bán không được âm
            if (updateProduct.Price < 0)
            {
                return BadRequest(new
                {
                    message = "Đơn giá không được nhỏ hơn 0!"
                });
            }

            // Kiểm tra số lượng tồn kho không được âm
            if (updateProduct.StockQuantity < 0)
            {
                return BadRequest(new
                {
                    message = "Số lượng tồn kho không được nhỏ hơn 0!"
                });
            }

            // Kiểm tra nhóm hàng được chọn có tồn tại hay không
            var categoryExists = await _context.Categories
                .AnyAsync(c => c.CategoryId == updateProduct.CategoryId);

            if (!categoryExists)
            {
                return BadRequest(new
                {
                    message = "Nhóm hàng không tồn tại!"
                });
            }

            // Kiểm tra mã vạch có bị trùng với sản phẩm khác hay không
            // Loại trừ sản phẩm đang được cập nhật
            var barcodeExists = await _context.Products
                .AnyAsync(p =>
                    p.Barcode == updateProduct.Barcode &&
                    p.ProductId != id);

            if (barcodeExists)
            {
                return Conflict(new
                {
                    message = "Mã vạch đã được sử dụng bởi sản phẩm khác!"
                });
            }

            // Cập nhật mã vạch sản phẩm
            product.Barcode = updateProduct.Barcode.Trim();

            // Cập nhật tên sản phẩm
            product.ProductName = updateProduct.ProductName.Trim();

            // Cập nhật giá bán
            product.Price = updateProduct.Price;

            // Cập nhật số lượng tồn kho
            product.StockQuantity = updateProduct.StockQuantity;

            // Cập nhật nhóm hàng của sản phẩm
            product.CategoryId = updateProduct.CategoryId;

            // Lưu các thay đổi vào Database
            await _context.SaveChangesAsync();

            // Trả về HTTP 200 OK khi cập nhật thành công
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
