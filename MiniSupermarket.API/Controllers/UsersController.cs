using Microsoft.AspNetCore.Authorization; // Phân quyền
using Microsoft.AspNetCore.Identity;      // PasswordHasher để băm mật khẩu
using Microsoft.AspNetCore.Mvc;           // Controller API
using Microsoft.EntityFrameworkCore;      // EF Core, async database
using MiniSupermarket.API.Data;           // DbContext
using MiniSupermarket.API.Models;         // Model User

namespace MiniSupermarket.API.Controllers
{
    [Route("api/[controller]")] // URL: api/Users
    [ApiController]             // Controller API
    [Authorize(Roles = "Admin")] // Toàn bộ quản lý tài khoản chỉ dành cho Admin
    public class UsersController : ControllerBase
    {
        private readonly SupermarketDbContext _context;      // Kết nối Database
        private readonly PasswordHasher<User> _passwordHasher; // Băm / kiểm tra mật khẩu

        // Các vai trò hợp lệ trong hệ thống
        private static readonly string[] ValidRoles = { "Admin", "Cashier", "Warehouse" };

        public UsersController(SupermarketDbContext context)
        {
            _context = context;
            _passwordHasher = new PasswordHasher<User>();
        }

        // Chuyển User (Model) -> đối tượng trả về cho client.
        // KHÔNG trả PasswordHash ra ngoài. Tên thuộc tính khớp với UserDto bên WinForms
        // (Id, Username, FullName, Email, Role, IsActive).
        private static object ToDto(User u) => new
        {
            Id = u.UserId,
            u.Username,
            u.FullName,
            Email = string.Empty, // Model User chưa có cột Email
            u.Role,
            u.IsActive
        };

        // GET: api/Users
        // Lấy danh sách tài khoản
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _context.Users
                .AsNoTracking()
                .OrderBy(u => u.UserId)
                .ToListAsync();

            return Ok(list.Select(ToDto));
        }

        // GET: api/Users/1
        // Lấy tài khoản theo ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.UserId == id);

            if (user == null)
            {
                return NotFound(new { message = "Không tìm thấy tài khoản!" });
            }

            return Ok(ToDto(user));
        }

        // GET: api/Users/search?keyword=admin
        // Tìm theo tên đăng nhập hoặc họ tên
        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string? keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return BadRequest(new { message = "Vui lòng nhập từ khóa!" });
            }

            keyword = keyword.Trim();

            var list = await _context.Users
                .AsNoTracking()
                .Where(u => u.Username.Contains(keyword) || u.FullName.Contains(keyword))
                .ToListAsync();

            return Ok(list.Select(ToDto));
        }

        // POST: api/Users
        // Tạo tài khoản mới
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string username = request.Username.Trim();

            if (string.IsNullOrWhiteSpace(username))
            {
                return BadRequest(new { message = "Tên đăng nhập không được để trống!" });
            }

            if (string.IsNullOrWhiteSpace(request.Password) || request.Password.Length < 6)
            {
                return BadRequest(new { message = "Mật khẩu phải có ít nhất 6 ký tự!" });
            }

            if (!ValidRoles.Contains(request.Role))
            {
                return BadRequest(new { message = "Vai trò không hợp lệ! (Admin, Cashier, Warehouse)" });
            }

            // Kiểm tra trùng tên đăng nhập
            var exists = await _context.Users.AnyAsync(u => u.Username == username);
            if (exists)
            {
                return Conflict(new { message = "Tên đăng nhập đã tồn tại!" });
            }

            var user = new User
            {
                Username = username,
                // Nếu bỏ trống họ tên thì dùng tên đăng nhập (vì FullName là bắt buộc)
                FullName = string.IsNullOrWhiteSpace(request.FullName) ? username : request.FullName.Trim(),
                Role = request.Role,
                IsActive = true
            };

            // Băm mật khẩu, không lưu mật khẩu thuần
            user.PasswordHash = _passwordHasher.HashPassword(user, request.Password);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = user.UserId }, ToDto(user));
        }

        // PUT: api/Users/1
        // Cập nhật họ tên và vai trò
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateUserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
            if (user == null)
            {
                return NotFound(new { message = "Không tìm thấy tài khoản cần sửa!" });
            }

            if (!ValidRoles.Contains(request.Role))
            {
                return BadRequest(new { message = "Vai trò không hợp lệ! (Admin, Cashier, Warehouse)" });
            }

            // Không cho Admin tự hạ quyền của chính mình (tránh mất quyền quản trị)
            if (user.Username == User.Identity?.Name && request.Role != "Admin")
            {
                return BadRequest(new { message = "Không thể tự đổi vai trò của tài khoản đang đăng nhập!" });
            }

            user.FullName = string.IsNullOrWhiteSpace(request.FullName) ? user.Username : request.FullName.Trim();
            user.Role = request.Role;

            await _context.SaveChangesAsync();

            return Ok(new { success = true, message = "Cập nhật tài khoản thành công!" });
        }

        // PUT: api/Users/1/reset-password
        // Đặt lại mật khẩu
        [HttpPut("{id}/reset-password")]
        public async Task<IActionResult> ResetPassword(int id, [FromBody] ResetPasswordRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
            if (user == null)
            {
                return NotFound(new { message = "Không tìm thấy tài khoản!" });
            }

            if (string.IsNullOrWhiteSpace(request.Password) || request.Password.Length < 6)
            {
                return BadRequest(new { message = "Mật khẩu mới phải có ít nhất 6 ký tự!" });
            }

            user.PasswordHash = _passwordHasher.HashPassword(user, request.Password);
            await _context.SaveChangesAsync();

            return Ok(new { success = true, message = "Đặt lại mật khẩu thành công!" });
        }

        // PUT: api/Users/1/toggle-lock
        // Khóa / mở khóa tài khoản
        [HttpPut("{id}/toggle-lock")]
        public async Task<IActionResult> ToggleLock(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
            if (user == null)
            {
                return NotFound(new { message = "Không tìm thấy tài khoản!" });
            }

            // Không cho Admin tự khóa chính mình
            if (user.Username == User.Identity?.Name)
            {
                return BadRequest(new { message = "Không thể tự khóa tài khoản đang đăng nhập!" });
            }

            user.IsActive = !user.IsActive;
            await _context.SaveChangesAsync();

            return Ok(new
            {
                success = true,
                isActive = user.IsActive,
                message = user.IsActive ? "Đã mở khóa tài khoản!" : "Đã khóa tài khoản!"
            });
        }
    }

    // ===== DTO nhận dữ liệu từ client =====

    // Dữ liệu tạo tài khoản mới (khớp với đối tượng FormUserManagement gửi lên)
    public class CreateUserRequest
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string? FullName { get; set; }
        public string Role { get; set; } = "Cashier";
    }

    // Dữ liệu cập nhật tài khoản
    public class UpdateUserRequest
    {
        public string? FullName { get; set; }
        public string Role { get; set; } = "Cashier";
    }

    // Dữ liệu đặt lại mật khẩu
    public class ResetPasswordRequest
    {
        public string Password { get; set; } = string.Empty;
    }
}