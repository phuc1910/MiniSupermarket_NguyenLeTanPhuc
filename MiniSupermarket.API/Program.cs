using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
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
.AddJwtBearer(options => {
    // Cấu hình các tham số để kiểm tra tính hợp lệ của JWT Token
    options.TokenValidationParameters = new TokenValidationParameters
    {
        // Kiểm tra chữ ký của JWT Token có hợp lệ hay không
        ValidateIssuerSigningKey = true,

        // Sử dụng Secret Key để kiểm tra chữ ký của Token
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSecret)),

        // Không kiểm tra Issuer của Token
        ValidateIssuer = false,

        // Không kiểm tra Audience của Token
        ValidateAudience = false
    };
});

// Đăng ký các Controller vào ứng dụng
builder.Services.AddControllers();

// Đăng ký dịch vụ hỗ trợ khám phá các API Endpoint
builder.Services.AddEndpointsApiExplorer();

// Đăng ký Swagger để tạo giao diện kiểm thử API
builder.Services.AddSwaggerGen(c => {
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Dán token vào đây (không cần gõ chữ Bearer)"
    });
    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme, Id = "Bearer" }
            },
            Array.Empty<string>()
        }
    });
});

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
