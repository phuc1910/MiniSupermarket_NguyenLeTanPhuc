using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using MiniSupermarket.API.Data;
using System.Text;

// Tạo WebApplication Builder để cấu hình ứng dụng ASP.NET Core
var builder = WebApplication.CreateBuilder(args);

// Cấu hình dịch vụ xác thực JWT Bearer
// Lấy Secret Key từ appsettings.json
// Nếu không có thì sử dụng Secret Key mặc định
var jwtSecret = builder.Configuration["JwtSettings:Secret"] ?? "SupermarketSecretKeyDoAnMonHoc2026SecureString!!";

// Đăng ký Authentication Service cho ứng dụng
builder.Services.AddAuthentication(options => {
    // Xác định phương thức dùng để xác thực người dùng
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

    // Xác định phương thức được sử dụng khi người dùng chưa được xác thực
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
// Cấu hình xác thực bằng JWT Bearer Token
.AddJwtBearer(options =>
{
    // Cấu hình các tham số để kiểm tra JWT Token
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,

        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.ASCII.GetBytes(jwtSecret)
        ),

        ValidateIssuer = false,
        ValidateAudience = false,

        // Nên bật kiểm tra thời gian hết hạn
        ValidateLifetime = true
    };

    // Xử lý thông báo Authentication / Authorization
    options.Events = new JwtBearerEvents
    {
        // 401: Không có Token hoặc Token không hợp lệ
        OnChallenge = async context =>
        {
            // Không cho ASP.NET Core trả response mặc định
            context.HandleResponse();

            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            context.Response.ContentType = "application/json; charset=utf-8";

            await context.Response.WriteAsJsonAsync(new
            {
                success = false,
                message = "Bạn chưa đăng nhập hoặc Token không hợp lệ!"
            });
        },

        // 403: Có Token nhưng không có quyền
        OnForbidden = async context =>
        {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            context.Response.ContentType = "application/json; charset=utf-8";

            await context.Response.WriteAsJsonAsync(new
            {
                success = false,
                message = "Bạn không có quyền truy cập chức năng này!"
            });
        }
    };
});


// Đăng ký các Controller vào ứng dụng
builder.Services.AddControllers();

// Lấy chuỗi kết nối từ appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Đăng ký DbContext sử dụng SQL Server
builder.Services.AddDbContext<SupermarketDbContext>(options =>
    options.UseSqlServer(connectionString));


// Đăng ký dịch vụ hỗ trợ khám phá các API Endpoint
builder.Services.AddEndpointsApiExplorer();

// Đăng ký Swagger để tạo giao diện kiểm thử API
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Kiểm tra ứng dụng có đang chạy ở môi trường Development hay không
if (app.Environment.IsDevelopment())
{
    // Kích hoạt Swagger
    app.UseSwagger();

    // Kích hoạt giao diện Swagger UI
    app.UseSwaggerUI();
}

// Chuyển hướng các request HTTP sang HTTPS
app.UseHttpsRedirection();

// Bắt buộc gọi UseAuthentication trước UseAuthorization
// UseAuthentication: Xác thực người dùng dựa trên JWT Token
app.UseAuthentication();

// UseAuthorization: Kiểm tra quyền truy cập của người dùng
app.UseAuthorization();

// Ánh xạ các Controller vào hệ thống Routing
app.MapControllers();

// Chạy ứng dụng
app.Run();
