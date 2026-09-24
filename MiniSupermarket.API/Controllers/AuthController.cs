using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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
        // Đối tượng IConfiguration dùng để đọc cấu hình từ appsettings.json
        private readonly IConfiguration _configuration;

        // Constructor nhận IConfiguration thông qua Dependency Injection
        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Endpoint Đăng nhập: POST /api/auth/login 
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequestDto request)
        {
            // Kiểm tra tài khoản mẫu
            // Trong thực tế sẽ truy vấn tài khoản từ Database thông qua EF Core / SQL Server
            if (request.Username == "admin" && request.Password == "123456")
            {
                // Tạo JWT Token cho tài khoản Admin
                var token = GenerateJwtToken(request.Username, "Admin");

                // Trả về kết quả đăng nhập thành công cùng token và role
                return Ok(new { success = true, token = token, role = "Admin" });
            }
            else if (request.Username == "cashier" && request.Password == "123456")
            {
                // Tạo JWT Token cho tài khoản Cashier
                var token = GenerateJwtToken(request.Username, "Cashier");

                // Trả về kết quả đăng nhập thành công cùng token và role
                return Ok(new { success = true, token = token, role = "Cashier" });
            }

            // Nếu tài khoản hoặc mật khẩu không đúng thì trả về lỗi 401 Unauthorized
            return Unauthorized(new { success = false, message = "Sai tài khoản hoặc mật khẩu!" });
        }

        // Hàm tạo JWT Token
        private string GenerateJwtToken(string username, string role)
        {
            // Tạo đối tượng JwtSecurityTokenHandler để xử lý JWT
            var tokenHandler = new JwtSecurityTokenHandler();

            // Lấy khóa bí mật từ appsettings.json
            // Nếu không tìm thấy JwtSettings:Secret thì sử dụng khóa mặc định
            var key = Encoding.ASCII.GetBytes(_configuration["JwtSettings:Secret"] ?? "SupermarketSecretKeyDoAnMonHoc2026SecureString!!");

            // Khai báo các thông tin cấu hình cho JWT Token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                // Tạo Claims chứa thông tin username và quyền của người dùng
                Subject = new ClaimsIdentity(new[] { 
                    // Lưu tên người dùng vào Claim
                    new Claim(ClaimTypes.Name, username), 

                    // Lưu quyền của người dùng vào Claim
                    new Claim(ClaimTypes.Role, role)
                }),

                // Thời hạn của JWT Token là 2 tiếng kể từ thời điểm tạo
                Expires = DateTime.UtcNow.AddHours(2), // Thời hạn token là 2 tiếng 

                // Thiết lập khóa và thuật toán dùng để ký JWT Token
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            // Tạo JWT Token dựa trên các thông tin đã cấu hình
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // Chuyển JWT Token thành chuỗi để trả về cho client
            return tokenHandler.WriteToken(token);
        }
    }

    // DTO dùng để nhận thông tin đăng nhập từ client
    public class LoginRequestDto
    {
        // Tên tài khoản đăng nhập
        public string Username { get; set; } = string.Empty;

        // Mật khẩu đăng nhập
        public string Password { get; set; } = string.Empty;
    }
}
