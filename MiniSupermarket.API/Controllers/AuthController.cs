using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MiniSupermarket.API.Data;
using MiniSupermarket.API.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MiniSupermarket.API.Controllers
{
    // Controller xử lý các chức năng liên quan đến xác thực người dùng
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        // Đọc cấu hình từ appsettings.json
        private readonly IConfiguration _configuration;
        private readonly SupermarketDbContext _context;
        private readonly PasswordHasher<User> _passwordHasher;

        public AuthController(IConfiguration configuration, SupermarketDbContext context)
        {
            _configuration = configuration;
            _context = context;
            _passwordHasher = new PasswordHasher<User>();
        }

        // POST: api/auth/login
        // [SỬA] Đăng nhập bằng dữ liệu thật trong bảng Users (không còn danh sách tài khoản cứng)
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            string username = request.Username?.Trim() ?? string.Empty;

            // Tìm tài khoản theo tên đăng nhập
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == username);

            // Thông báo chung cho cả "không có tài khoản" và "sai mật khẩu"
            // để không lộ tài khoản nào tồn tại
            var invalid = Unauthorized(new
            {
                success = false,
                message = "Sai tài khoản hoặc mật khẩu!"
            });

            if (user == null)
            {
                return invalid;
            }

            // Kiểm tra mật khẩu với chuỗi băm đã lưu
            var verify = _passwordHasher.VerifyHashedPassword(
                user, user.PasswordHash, request.Password ?? string.Empty);

            if (verify == PasswordVerificationResult.Failed)
            {
                return invalid;
            }

            // Tài khoản bị khóa thì không cho đăng nhập (kiểm tra SAU khi đúng mật khẩu)
            if (!user.IsActive)
            {
                return StatusCode(StatusCodes.Status403Forbidden, new
                {
                    success = false,
                    message = "Tài khoản đã bị khóa!"
                });
            }

            // Nếu thuật toán băm đã cũ thì băm lại bằng chuẩn mới
            if (verify == PasswordVerificationResult.SuccessRehashNeeded)
            {
                user.PasswordHash = _passwordHasher.HashPassword(user, request.Password!);
                await _context.SaveChangesAsync();
            }

            // Tạo JWT Token chứa username và vai trò
            var token = GenerateJwtToken(user.Username, user.Role);

            // Giữ nguyên định dạng trả về để WinForms không phải sửa
            return Ok(new
            {
                success = true,
                token = token,
                role = user.Role,
                username = user.Username
            });
        }

        // Hàm tạo JWT Token
        private string GenerateJwtToken(string username, string role)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            // Khóa bí mật: PHẢI trùng với khóa cấu hình trong Program.cs
            var key = Encoding.ASCII.GetBytes(_configuration["JwtSettings:Secret"] ?? "SupermarketSecretKeyDoAnMonHoc2026SecureString!!");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, username), // Tên người dùng
                    new Claim(ClaimTypes.Role, role)      // Quyền của người dùng
                }),

                // Thời hạn token: 2 tiếng
                Expires = DateTime.UtcNow.AddHours(2),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }

    // DTO nhận thông tin đăng nhập từ client
    public class LoginRequestDto
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}