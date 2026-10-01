using Microsoft.AspNetCore.Mvc; // Controller API
using Microsoft.EntityFrameworkCore; // EF Core, async database
using Microsoft.AspNetCore.Authorization; // Phân quyền
using MiniSupermarket.API.Data; // DbContext
using MiniSupermarket.API.Models; // Model Category

namespace MiniSupermarket.API.Controllers
{
    [Route("api/[controller]")] // URL: api/Categories
    [ApiController] // Controller API
    [Authorize] // Phải có JWT Token
    public class CategoriesController : ControllerBase
    {
        private readonly SupermarketDbContext _context; // Kết nối Database

        // Tiêm DbContext vào Controller
        public CategoriesController(SupermarketDbContext context)
        {
            _context = context;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Lấy danh sách Category từ SQL Server
            var list = await _context.Categories
                .AsNoTracking()
                .ToListAsync();

            return Ok(list);
        }

        // GET: api/Categories/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            // Tìm Category theo ID
            var cat = await _context.Categories.FindAsync(id);

            if (cat == null)
            {
                return NotFound(new
                {
                    message = "Không tìm thấy nhóm hàng!"
                });
            }

            return Ok(cat);
        }

        // GET: api/Categories/search?keyword=sữa
        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return BadRequest(new
                {
                    message = "Vui lòng nhập từ khóa!"
                });
            }

            // Tìm kiếm trực tiếp trên SQL Server
            var result = await _context.Categories
                .Where(c => c.CategoryName.Contains(keyword))
                .ToListAsync();

            return Ok(result);
        }

        // POST: api/Categories
        // Chỉ Admin được thêm
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] Category newCat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Thêm Category vào Database
            _context.Categories.Add(newCat);

            // Lưu thay đổi
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetById),
                new { id = newCat.CategoryId },
                newCat
            );
        }

        // PUT: api/Categories/1
        // Chỉ Admin được sửa
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] Category updateCat)
        {
            var cat = await _context.Categories.FindAsync(id);

            if (cat == null)
            {
                return NotFound(new
                {
                    message = "Không tìm thấy nhóm hàng cần sửa!"
                });
            }

            cat.CategoryName = updateCat.CategoryName;
            cat.Description = updateCat.Description;

            await _context.SaveChangesAsync();

            return Ok(new
            {
                success = true,
                message = "Cập nhật nhóm hàng thành công!"
            });
        }

        // DELETE: api/Categories/1
        // Chỉ Admin được xóa
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var cat = await _context.Categories.FindAsync(id);

            if (cat == null)
            {
                return NotFound(new
                {
                    message = "Không tìm thấy nhóm hàng cần xóa!"
                });
            }

            // Xóa Category
            _context.Categories.Remove(cat);

            // Lưu thay đổi vào Database
            await _context.SaveChangesAsync();

            return Ok(new
            {
                success = true,
                message = "Xóa nhóm hàng thành công!"
            });
        }

        // GET: api/Categories/admin-dashboard
        // Chỉ Admin
        [HttpGet("admin-dashboard")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAdminDashboard()
        {
            return Ok(new
            {
                message = "Chào mừng Admin! Bạn có toàn quyền quản trị hệ thống."
            });
        }

        // GET: api/Categories/staff-pos
        // Admin và Cashier đều được sử dụng
        [HttpGet("staff-pos")]
        [Authorize(Roles = "Admin,Cashier")]
        public IActionResult GetStaffPos()
        {
            return Ok(new
            {
                message = "Màn hình POS Thu ngân sẵn sàng phục vụ bán hàng."
            });
        }
    }
}
