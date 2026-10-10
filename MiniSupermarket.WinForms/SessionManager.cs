using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace MiniSupermarket.WinForms
{
    // Lưu thông tin phiên đăng nhập hiện tại
    public static class SessionManager
    {
        public static string JwtToken { get; set; } = string.Empty;
        public static string CurrentUsername { get; set; } = string.Empty;
        public static string CurrentRole { get; set; } = string.Empty;
    }

    public static class ApiClientService
    {
        // [SỬA LỖI CHÍNH] Dùng handler tự gắn token vào MỌI request.
        // Dù form đăng nhập lưu token bằng cách nào (miễn là gán SessionManager.JwtToken),
        // mọi request qua ApiClientService.Client đều tự có header Authorization.
        private class AuthHandler : DelegatingHandler
        {
            public AuthHandler() : base(new HttpClientHandler()) { }

            protected override Task<HttpResponseMessage> SendAsync(
                HttpRequestMessage request, CancellationToken cancellationToken)
            {
                if (!string.IsNullOrWhiteSpace(SessionManager.JwtToken))
                {
                    request.Headers.Authorization =
                        new AuthenticationHeaderValue("Bearer", SessionManager.JwtToken);
                }
                return base.SendAsync(request, cancellationToken);
            }
        }

        private static readonly HttpClient _client = new HttpClient(new AuthHandler())
        {
            // Lưu ý: BẮT BUỘC có dấu "/" ở cuối
            BaseAddress = new Uri("https://localhost:7251/api/")  // nhớ chỉnh port phù hợp
        };

        // Cho phép các Form khác sử dụng HttpClient
        public static HttpClient Client => _client;

        // Hàm gọi API đăng nhập lấy Token
        public static async Task<bool> LoginAsync(string username, string password)
        {
            var loginObj = new { Username = username, Password = password };
            var response = await _client.PostAsJsonAsync("auth/login", loginObj);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                using var doc = JsonDocument.Parse(jsonString);

                // Lưu thông tin phiên đăng nhập
                SessionManager.JwtToken = doc.RootElement.GetProperty("token").GetString() ?? string.Empty;
                SessionManager.CurrentRole = doc.RootElement.GetProperty("role").GetString() ?? string.Empty;
                SessionManager.CurrentUsername = username;

                // [SỬA LỖI CHÍNH] Gắn token vào header mặc định của _client.
                // Trước đây thiếu bước này nên mọi request từ ApiClientService.Client
                // đều không có Authorization -> API trả 401 -> "Lỗi nạp danh mục".
                // (Token sẽ được AuthHandler tự gắn vào các request sau)
                return true;
            }
            return false;
        }

        // [MỚI] Đăng xuất: xóa thông tin phiên và gỡ token khỏi client
        public static void Logout()
        {
            SessionManager.JwtToken = string.Empty;
            SessionManager.CurrentUsername = string.Empty;
            SessionManager.CurrentRole = string.Empty;
        }

        // Hàm gọi API lấy dữ liệu có gắn kèm Bearer Token bảo mật
        public static async Task<string> GetDataWithTokenAsync(string endpoint)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SessionManager.JwtToken);
            var response = await _client.GetAsync(endpoint);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new Exception("Phiên làm việc hết hạn hoặc chưa đăng nhập!");
            }
            throw new Exception("Lỗi khi gọi dữ liệu từ Server.");
        }

        public static async Task<HttpResponseMessage> SendWithTokenAsync(HttpRequestMessage request)
        {
            if (!string.IsNullOrWhiteSpace(SessionManager.JwtToken))
            {
                request.Headers.Authorization =
                    new AuthenticationHeaderValue("Bearer", SessionManager.JwtToken);
            }

            return await _client.SendAsync(request);
        }
    }
}