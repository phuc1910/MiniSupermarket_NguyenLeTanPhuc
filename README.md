# 🛒 HỆ THỐNG QUẢN LÝ SIÊU THỊ MINI (MINISUPERMARKET SYSTEM)
> **Đề tài:** Xây dựng Ứng dụng Quản lý Cửa hàng Tiện lợi với ASP.NET Core và Windows Forms — Tiệm Tạp hóa Mỹ phẩm Xách tay Hana Shop  
> **Môn học:** Lập trình Ứng dụng .NET Core (Mã môn: 229162)  
> **Nội dung thực hành:**
> - **Buổi 1:** Xây dựng Web API quản lý danh mục và kết nối WinForms Client (CRUD)
> - **Buổi 2:** Bảo mật & Phân quyền JWT cho Web API và WinForms Client
> - **Buổi 3:** Tích hợp SQL Server và Entity Framework Core Code-First
> - **Buổi 4:** Giao diện Shell hợp nhất, phân quyền 3 cấp (Admin / Cashier / Warehouse), đăng nhập và quản trị tài khoản bằng bảng `Users` thật, quản lý Sản phẩm
> - **Buổi 5:** ADO.NET nâng cao, Stored Procedure báo cáo doanh thu và thanh toán POS bằng giao dịch `SqlTransaction`
> - **Buổi 6:** EF Core nâng cao: phân trang LINQ `.Skip()/.Take()`, Eager Loading `.Include()`, `.AsNoTracking()`, `ApiClientService` dùng chung, phân trang và lọc nhóm hàng trên WinForms. **Bổ sung:** Dashboard, biểu đồ, Top 5, danh sách và chi tiết đơn hàng, lọc doanh thu theo ngày/tuần/tháng/năm và theo thu ngân, đổi điểm POS, xuất CSV, ngày đăng ký khách hàng. **Điều chỉnh:** cảnh báo tồn kho do server quyết định; tách Request/Response DTO, kiểm tra dữ liệu đầu vào, chặn xóa nhóm còn sản phẩm; đồng bộ giao diện WinForms trong các file Designer có sẵn và giữ nguyên kích thước cửa sổ.

---

## 🏗️ 1. Mô hình Kiến trúc Hệ thống (Client - Server)
Dự án được xây dựng theo mô hình phân tầng hiện đại, tách biệt hoàn toàn giữa Backend và Frontend:
* **`MiniSupermarket.API` (Backend):** Dự án ASP.NET Core Web API xử lý logic nghiệp vụ, kết nối **SQL Server** qua **Entity Framework Core** và **ADO.NET**, cung cấp các RESTful API chuẩn hóa, xác thực người dùng bằng bảng `Users` trong cơ sở dữ liệu và cấp phát JWT Token.
* **`MiniSupermarket.WinForms` (Frontend Client):** Ứng dụng Windows Forms với **giao diện Shell hợp nhất** (Sidebar + vùng nội dung động) đóng vai trò máy trạm POS tại quầy, có màn hình đăng nhập, lưu Token và đính kèm `Bearer Token` khi dùng `HttpClient` gọi API.

---

## 🛠️ 2. Công nghệ Sử dụng
* **Ngôn ngữ:** C# (.NET 8.0)
* **Backend:** ASP.NET Core Web API, Entity Framework Core Code-First, LINQ bất đồng bộ (async/await), ADO.NET (`Microsoft.Data.SqlClient`), Stored Procedure, `SqlTransaction`
* **Cơ sở dữ liệu:** Microsoft SQL Server (`TanPhucMiniSupermarketDb`)
* **Bảo mật:** JWT Bearer Authentication, `[Authorize]`, phân quyền theo Role (Admin / Cashier / Warehouse), xác thực tài khoản qua bảng `Users` trong CSDL
* **Frontend:** Windows Forms (.NET 8.0), `System.Net.Http.Json`, kiến trúc Single-Form Shell (nhúng Form con động)
* **Biểu đồ (bổ sung Buổi 6):** điều khiển `Chart` qua gói `HIC.System.Windows.Forms.DataVisualization` 1.0.1.
* **Xuất báo cáo (bổ sung Buổi 6):** CSV UTF-8 có BOM, dùng dấu phân cách theo thiết lập vùng và mở được bằng Excel.
* **Công cụ kiểm thử:** Swagger UI với nút **Authorize**, SQL Server Management Studio (SSMS)

---

## 📂 3. Cấu trúc Solution
```text
MiniSupermarket_NguyenLeTanPhuc/
│
├── MiniSupermarket_NguyenLeTanPhuc.sln
├── MiniSupermarket.API/                 # Dự án Web API (Backend)
│   ├── Controllers/
│   │   ├── AuthController.cs            # Đăng nhập bằng bảng Users, cấp JWT (Buổi 4)
│   │   ├── UsersController.cs           # Quản lý tài khoản, vai trò, khóa/mở khóa (Buổi 4)
│   │   ├── CategoriesController.cs      # CRUD, Search, phân trang; DTO và validation (Buổi 1, 3, 6)
│   │   ├── ProductsController.cs        # CRUD, lọc nhóm, phân trang, mã vạch, IsLowStock (Buổi 4, 5, 6)
│   │   ├── CustomersController.cs       # CRUD, Search, phân trang, CreatedDate (Buổi 3, 6)
│   │   ├── AdoProductController.cs      # SqlDataReader, SqlDataAdapter, lọc tồn kho (Buổi 5)
│   │   ├── OrdersController.cs          # Danh sách/chi tiết đơn, checkout, đổi điểm, hủy đơn (Buổi 5, 6)
│   │   ├── ReportsController.cs         # Stored Procedure, Dashboard, doanh thu ngày, Top 5 (Buổi 5, 6)
│   │   └── WeatherForecastController.cs # Controller mẫu, không thuộc nghiệp vụ cửa hàng
│   ├── Models/
│   │   ├── Category.cs, Product.cs      # Nhóm hàng, sản phẩm và cờ IsLowStock
│   │   ├── Customer.cs                  # Khách hàng, hạng thẻ, điểm, CreatedDate
│   │   ├── User.cs                      # Username, PasswordHash, Role, IsActive
│   │   ├── Order.cs, OrderDetail.cs     # Hóa đơn và chi tiết hóa đơn
│   │   ├── CheckoutDtos.cs              # DTO thanh toán, UsePoints và DTO đọc đơn hàng (Buổi 5, 6)
│   │   ├── RequestDtos.cs               # DTO đầu vào danh mục, sản phẩm, khách hàng (Buổi 6)
│   │   └── PagedResponseDto.cs, CashierRevenueDto.cs, TopProductDto.cs
│   ├── Data/SupermarketDbContext.cs      # DbContext, Unique Index và dữ liệu mẫu
│   ├── Migrations/                      # AddDatabase, AddCreatedDate và Check
│   ├── Scripts/StoredProcedures.sql     # Bốn Stored Procedure, chạy riêng bằng SSMS
│   └── Program.cs                       # DbContext, JWT, CORS, Swagger và Middleware
│
└── MiniSupermarket.WinForms/             # Dự án Windows Forms (Frontend Client)
    ├── FormLogin.cs                      # Đăng nhập qua ApiClientService dùng chung (Buổi 6)
    ├── SessionManager.cs                 # Phiên đăng nhập, HttpClient và Bearer Token
    ├── FormMainShell.cs                  # Sidebar và nhúng Form động (Buổi 4)
    ├── FormCategoryManagement.cs         # CRUD, tìm kiếm, phân trang danh mục
    ├── FormCustomerManagement.cs         # Khách hàng, điểm và phân trang
    ├── FormProductManagement.cs          # Phân trang, lọc nhóm, tô màu tồn thấp (Buổi 6)
    ├── FormUserManagement.cs             # Quản trị tài khoản, chỉ Admin
    ├── FormPOS.cs                        # Giỏ hàng, tra khách, đổi điểm, checkout (Buổi 5, 6)
    ├── FormQuickReport.cs                # Sự kiện, gọi API, DTO báo cáo và bộ lọc kỳ
    ├── FormQuickReport.Designer.cs       # Bố cục, khai báo control, bảng, thẻ và các tab báo cáo
    ├── PagingBar.cs                      # Thanh phân trang dùng chung
    └── Models/ProductDto.cs              # DTO sản phẩm và dữ liệu phân trang phía máy khách
```

---

## 🔐 4. Xác thực và Phân quyền

Khác với Buổi 2 (tài khoản hard-code trong code), từ Buổi 4 hệ thống xác thực bằng **bảng `Users` lưu trong SQL Server**: `AuthController` truy vấn `Users` để kiểm tra tài khoản/mật khẩu trước khi cấp JWT Token, và `UsersController` cho phép Admin tạo mới/quản lý tài khoản nhân viên ngay trên ứng dụng — không cần sửa code mỗi khi thêm nhân viên.

> Đây là tài khoản demo phục vụ học tập, không phải thông tin đăng nhập thật. Mật khẩu mẫu của các tài khoản là `123456` (lưu dạng chuỗi băm trong CSDL).

| Endpoint | Quyền truy cập |
|----------|----------------|
| `POST /api/auth/login` | Công khai |
| Đọc danh mục, sản phẩm, khách hàng | Phải đăng nhập (chưa đăng nhập → **401**) |
| Thêm, sửa, xóa danh mục, sản phẩm, khách hàng | Chỉ Admin; API kiểm tra quyền ghi |
| `GET /api/users` | Chỉ Admin |
| `POST /api/users` | Chỉ Admin — tạo tài khoản nhân viên mới |
| `POST /api/orders/checkout` | Admin, Cashier — thanh toán POS và đổi điểm (Buổi 5, 6) |
| `GET /api/orders`, `GET /api/orders/{id}` | Chỉ Admin — đọc danh sách và chi tiết đơn hàng |
| `DELETE /api/orders/cancel/{orderId}` | Chỉ Admin — hủy hóa đơn (Buổi 5) |
| `GET /api/reports/*` | Chỉ Admin — báo cáo, Dashboard, biểu đồ, Top 5 (Buổi 5, 6) |

### Phân quyền giao diện trên WinForms Shell

| Vai trò | Màn hình mặc định | Các màn hình được phép truy cập |
|---------|---------------------|----------------------------------|
| Admin | Quản lý Danh mục | Bán hàng (POS), Danh mục, Sản phẩm, Khách hàng, Báo cáo Doanh thu, Quản trị Tài khoản |
| Cashier | Quản lý Khách hàng | Bán hàng (POS), Khách hàng |
| Warehouse | Quản lý Danh mục | Danh mục, Sản phẩm |

---

## 🗄️ 5. Cơ sở dữ liệu `TanPhucMiniSupermarketDb`

| Bảng | Mô tả |
|------|-------|
| `Categories` | Nhóm hàng mỹ phẩm (Trang điểm, Chăm sóc da, Chăm sóc tóc & cơ thể, Nước hoa, Thực phẩm chức năng) |
| `Products` | Sản phẩm, liên kết khóa ngoại tới `Categories`, có mã vạch (Barcode) và số lượng tồn kho |
| `Customers` | Khách hàng thân thiết: tên, số điện thoại, địa chỉ, hạng thẻ, điểm tích lũy và ngày đăng ký `CreatedDate` (bổ sung Buổi 6) |
| `Users` | Tài khoản nhân viên: tên đăng nhập, mật khẩu băm, họ tên, vai trò và trạng thái hoạt động |
| `Orders` | Mã hóa đơn, ngày lập, thu ngân, khách hàng (có thể NULL), `FinalAmount` sau giảm điểm và điểm thưởng (Buổi 5, 6) |
| `OrderDetails` | Chi tiết hóa đơn: sản phẩm, số lượng, đơn giá, thành tiền (Buổi 5) |

Chuỗi kết nối cấu hình tại `appsettings.json`. Chạy `Update-Database` để áp dụng các migration còn thiếu; các cột `Username`, `CategoryName`, `Barcode`, `PhoneNumber`, `OrderCode` có ràng buộc duy nhất (Unique Index). Source hiện có `AddDatabase`, `AddCreatedDate` và `Check`; migration `Check` có `Up`/`Down` rỗng.

**Bổ sung Buổi 6:** `Customers.CreatedDate` phục vụ thống kê khách đăng ký mới; Request DTO tách khỏi Entity và các Item DTO dùng cho phản hồi/phân trang. API kiểm tra trùng tên nhóm, mã vạch, số điện thoại; kiểm tra giá dương, tồn không âm và chặn xóa nhóm hàng còn sản phẩm.

**Stored Procedure phải tạo riêng:** sau `Update-Database`, mở `MiniSupermarket.API/Scripts/StoredProcedures.sql` bằng SSMS và chạy trên database `TanPhucMiniSupermarketDb`. Các thủ tục này không được tạo bởi migration hiện có.

| Stored Procedure | Chức năng và API |
|------------------|------------------|
| `sp_GetRevenueByCashier` | Doanh thu theo thu ngân toàn lịch sử — `/api/reports/revenue-by-cashier` khi không truyền ngày |
| `sp_GetRevenueByDateRange` | Doanh thu theo thu ngân trong khoảng ngày — `/api/reports/revenue-by-date` |
| `sp_GetTop5SellingProducts` | Top 5 sản phẩm bán chạy — `/api/reports/top-products` |
| `sp_GetRevenueByDay` | Doanh thu từng ngày cho biểu đồ và CSV — `/api/reports/revenue-by-day` (bổ sung Buổi 6) |

`dashboard-summary`, `quick-report` và `best-sellers` truy vấn dữ liệu trực tiếp trong controller, không gọi bốn thủ tục trên.

API `revenue-by-cashier` nhận thêm `fromDate`/`toDate` tùy chọn. Khi lọc ngày, server dùng LINQ để nhóm theo thu ngân; khi bỏ cả hai tham số, API giữ cách gọi Stored Procedure toàn lịch sử. Ngày cuối của bộ lọc lấy trọn ngày bằng điều kiện nhỏ hơn đầu ngày kế tiếp.

---

## 🖥️ 6. Giao diện Shell hợp nhất

Toàn bộ nghiệp vụ được điều hướng trong **một Form chính (`FormMainShell`)** thay vì mở nhiều cửa sổ rời rạc:

* **Sidebar bên trái:** chỉ hiển thị nút tương ứng với vai trò đang đăng nhập; nút đang chọn được làm nổi bật màu khác.
* **Vùng nội dung chính:** nhúng động Form nghiệp vụ (`TopLevel = false`, `Dock = Fill`).
* **Bảo vệ 2 lớp:** một số chức năng (Báo cáo Doanh thu, Quản trị Tài khoản) vừa bị ẩn khỏi Sidebar theo vai trò, vừa được kiểm tra lại quyền ngay trong xử lý sự kiện.

### Giao diện thống nhất và giữ nguyên cấu trúc mã nguồn

* Các màn hình Đăng nhập, Shell, POS, Danh mục, Sản phẩm, Khách hàng, Tài khoản và Báo cáo dùng cùng kiểu chữ Segoe UI, nền sáng, nút xanh và bảng dữ liệu có tiêu đề rõ ràng.
* Giữ nguyên `ClientSize`, kích thước tối thiểu và trạng thái cửa sổ hiện có; bố cục chỉ được sắp xếp lại bên trong bằng các panel/layout của WinForms.
* Khai báo control, vị trí, màu sắc, kích thước thành phần và gắn sự kiện được viết trong `FormTenManHinh.Designer.cs`. Các hàm xử lý sự kiện và gọi API nằm trong `FormTenManHinh.cs`, theo cách tổ chức cũ.
* Mã báo cáo được gộp vào `FormQuickReport.cs` và `FormQuickReport.Designer.cs`; không dùng file partial báo cáo bổ sung. DTO đọc hóa đơn đặt trong `CheckoutDtos.cs` có sẵn; DTO phản hồi phía client đặt cùng `FormQuickReport.cs`.
* Các thay đổi giao diện không đổi quy tắc checkout, đổi điểm, tồn kho, phân quyền, kiểm tra dữ liệu hay cách tính doanh thu ở server.

### Dashboard và báo cáo trên `FormQuickReport` — bổ sung Buổi 6

* **Thẻ tổng quan:** doanh thu hôm nay, số hóa đơn hôm nay, khách đăng ký mới hôm nay và số sản phẩm tồn thấp trên toàn kho.
* **Báo cáo theo khoảng ngày:** tổng hóa đơn, doanh thu và sản phẩm bán chạy nhất theo **Từ ngày – Đến ngày**; chọn hai ô cùng ngày để xem đúng một ngày.
* **Biểu đồ cột:** doanh thu từng ngày từ API `revenue-by-day`; ngày không có hóa đơn được hiển thị bằng 0 trên biểu đồ.
* **Top 5 sản phẩm bán chạy:** lấy từ API `best-sellers`, tính trên toàn bộ lịch sử bán hàng.
* **Xuất dữ liệu:** nút **Xuất tồn kho** xuất toàn bộ sản phẩm; nút **Xuất doanh thu** xuất theo khoảng ngày. CSV có UTF-8 BOM, dấu phân cách theo vùng, xử lý dấu ngoặc kép và dữ liệu có thể bị Excel hiểu là công thức.
* **Tab Đơn hàng & chi tiết:** chọn khoảng ngày, xem danh sách có phân trang 20 đơn/trang. Chọn một đơn để xem khách hàng, thu ngân, thời điểm lập, tiền thực thu, điểm thưởng và từng dòng sản phẩm với số lượng, đơn giá lịch sử, thành tiền. Tổng thực thu phía dưới tính trên toàn bộ kết quả lọc, không chỉ trang đang xem.
* **Tab Doanh thu theo kỳ:** chọn **Ngày**, **Tuần**, **Tháng** hoặc **Năm** và mốc thời gian tương ứng; xem số đơn, tiền thực thu, sản phẩm bán chạy nhất và doanh thu từng thu ngân trong kỳ. Nút xem đơn hàng chuyển sang danh sách đơn với cùng khoảng ngày.
* **Tab Doanh thu thu ngân:** hiển thị tài khoản thu ngân, số đơn, doanh thu thực thu và điểm đã cộng. Lọc theo ngày/tuần/tháng/năm, khoảng ngày tùy chọn hoặc **Toàn bộ lịch sử**.

Bộ lọc trên tab Tổng quan có **Ngày**, **Tuần**, **Tháng**, **Năm** và **Tùy chọn**; áp dụng cho báo cáo theo khoảng, biểu đồ và CSV doanh thu. Các thẻ hôm nay và Top 5 toàn lịch sử có phạm vi riêng. Các tab có bộ lọc độc lập. Kỳ không có đơn hiển thị 0 và danh sách rỗng.

Quy ước kỳ báo cáo: ngày được chọn; tuần từ **thứ Hai đến Chủ nhật** chứa ngày mốc; tháng từ ngày đầu đến ngày cuối tháng; năm từ **01/01 đến 31/12**. Client chỉ xác định hai mốc ngày gửi API; việc tổng hợp doanh thu và dữ liệu vẫn được thực hiện ở server.

### Đổi điểm thưởng tại POS — bổ sung Buổi 6

* Tra khách hàng bằng số điện thoại, hiển thị số điểm và hạng thành viên.
* Khách có ít nhất 50 điểm và hóa đơn từ 50.000 đồng có thể dùng **50 điểm giảm 50.000 đồng**, tối đa một gói cho mỗi hóa đơn.
* Server xử lý đổi điểm trong giao dịch thanh toán, tính điểm thưởng theo `floor(FinalAmount / 10.000)` và hoàn lại điểm đã đổi khi hủy hóa đơn.
* WinForms cập nhật tiền phải trả và tiền thừa theo lựa chọn đổi điểm trước khi gửi checkout.

### Cảnh báo tồn kho và dùng chung kết nối — bổ sung, điều chỉnh Buổi 6

* Server quyết định `isLowStock`, `stockStatus` và `lowStockThreshold` từ một quy tắc chung trong `Product`: tồn bằng 0 là **Hết hàng**, tồn từ 1 đến 10 là **Sắp hết hàng**, cao hơn ngưỡng là **Còn hàng**.
* API sản phẩm phân trang trả thêm `totalLowStockItems`: tổng sản phẩm cảnh báo trong toàn bộ bộ lọc từ khóa/nhóm hàng trước khi chia trang. Dashboard cũng đếm trên SQL Server.
* WinForms chỉ dùng `isLowStock` để tô màu, dùng tổng và ngưỡng do API trả để hiển thị cảnh báo; CSV dùng `stockStatus` từ server. Không còn phép so sánh ngưỡng tồn thấp hoặc đếm cảnh báo tại WinForms.
* Đăng nhập và các thao tác CRUD danh mục, khách hàng dùng `ApiClientService` chung, tránh tạo `HttpClient` riêng cho từng thao tác; bổ sung xử lý phản hồi lỗi khi nạp dữ liệu.

---

## 🚀 7. Hướng dẫn Chạy và Kiểm thử Dự án

### Yêu cầu hệ thống
* Microsoft Visual Studio 2026 (cài workload **ASP.NET and web development** và **.NET desktop development**)
* .NET 8.0 SDK
* SQL Server (LocalDB, Express hoặc bản đầy đủ đều được)
* SQL Server Management Studio (SSMS) để chạy Stored Procedure

### Cấu hình chuỗi kết nối
Mở `appsettings.json` trong project `MiniSupermarket.API`, kiểm tra/sửa lại cho khớp với SQL Server trên máy bạn:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=TanPhucMiniSupermarketDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

Nếu dùng SQL Express, đổi `Server=localhost` thành `Server=.\\SQLEXPRESS` trong chuỗi JSON. Nếu đăng nhập bằng tài khoản `sa`, thay cụm `Trusted_Connection=True` bằng `User Id=sa;Password=<mật khẩu của bạn>`.

### Bước 1: Chạy phía Backend (Web API)
1. Mở Solution bằng Microsoft Visual Studio 2026.
2. Mở **Package Manager Console**, chọn Default project là `MiniSupermarket.API`, chạy `Update-Database` để tạo database và áp dụng migration còn thiếu. Database hiện có không cần xóa để chạy lại ứng dụng.
3. Mở `MiniSupermarket.API/Scripts/StoredProcedures.sql` bằng SSMS, chọn database `TanPhucMiniSupermarketDb`, nhấn **Execute** để tạo/cập nhật bốn Stored Procedure. Bước này cần cho các API `revenue-by-cashier`, `revenue-by-date`, `top-products` và `revenue-by-day`.
4. Nhấp chuột phải project `MiniSupermarket.API` chọn **Set as Startup Project**, chọn profile **https** (cổng `7251`), nhấn **F5**.
5. Gọi `POST /api/auth/login` để lấy token, đính kèm token vào header `Authorization: Bearer <token>` để thử các endpoint Categories, Products, Customers, Users, Orders, Reports.

> 🔐 Swagger đã có nút ổ khóa **Authorize**: gọi `POST /api/auth/login`, copy chuỗi `token`, bấm **Authorize** rồi dán token (không cần gõ chữ `Bearer`) để gọi các API được bảo vệ. Thử phân trang tại `GET /api/products/paged?pageNumber=1&pageSize=5`.

### Bước 2: Chạy phía Frontend (WinForms Client)
1. Kiểm tra `ApiClientService` trong `SessionManager.cs` dùng địa chỉ `https://localhost:7251/api/`, khớp với cổng API đang chạy.
2. Khôi phục các gói NuGet, gồm `HIC.System.Windows.Forms.DataVisualization`, rồi nhấp phải `MiniSupermarket.WinForms` chọn **Debug -> Start new instance**.
3. Đăng nhập bằng các tài khoản có vai trò khác nhau (lấy từ bảng `Users` trong SQL Server) để kiểm tra Sidebar hiển thị đúng chức năng theo từng vai trò.
4. Dùng Admin kiểm tra Danh mục, Sản phẩm, Khách hàng: tải danh sách, thêm, sửa, xóa, tìm kiếm và phân trang. Màn hình Sản phẩm có nút **<< Trang trước / Trang sau >>**, lọc nhóm và tô màu tồn thấp (Buổi 6); quyền ghi được kiểm tra tại API.
5. Với tài khoản Admin, thử tạo tài khoản nhân viên mới trong màn hình Quản trị Tài khoản.
6. Dùng Cashier mở POS, nhập mã vạch và số điện thoại khách hoặc để trống với khách vãng lai. Kiểm tra đổi 50 điểm, tiền phải trả, tiền thừa và thanh toán bằng nút **THANH TOÁN** hoặc F9. Khi cần kiểm tra server Rollback do thiếu tồn, dùng Swagger trên database thử nghiệm vì WinForms có thể chặn số lượng trước khi gửi.
7. Dùng Admin mở **Báo cáo Doanh thu** và kiểm tra bốn tab: **Tổng quan**, **Đơn hàng & chi tiết**, **Doanh thu theo kỳ**, **Doanh thu thu ngân**. Kiểm tra đổi trang đơn hàng, chọn đơn để xem các dòng hàng; chuyển bộ lọc ngày/tuần/tháng/năm và khoảng tùy chọn; kiểm tra kỳ có/không có đơn và toàn lịch sử theo thu ngân. Tab Tổng quan vẫn có biểu đồ, Top 5 và hai nút xuất CSV. Tài khoản mẫu: `admin01`, `cashier01`, `ware01`; mật khẩu mẫu `123456`.
8. Tắt cả hai ứng dụng rồi mở lại — dữ liệu vẫn còn nguyên vì đã lưu trên SQL Server.

---

## 💾 8. Cách lưu bài và đẩy lên GitHub

Mở **Terminal/PowerShell** tại thư mục dự án. `git commit` lưu một mốc thay đổi trên máy; `git push` mới đưa commit đó lên GitHub.

### Lưu và đẩy bài hiện tại lên `Buoi-6`

Nhánh `Buoi-6` đã tồn tại. Dùng `git checkout Buoi-6` để chọn nhánh; chỉ dùng `-b` khi tạo nhánh mới.

```powershell
Set-Location D:\MiniSupermarket_NguyenLeTanPhuc
git checkout Buoi-6
git status
git add .
git diff --cached --stat
```

Tạo commit có tiêu đề và nội dung chi tiết về những phần vừa bổ sung, điều chỉnh:

```powershell
$commitMessage = @'
Buoi 6: đồng bộ Designer WinForms, lọc doanh thu theo kỳ và báo cáo đơn hàng

- API đơn hàng: thêm danh sách phân trang, lọc ngày, tổng thực thu toàn bộ kết quả và chi tiết từng đơn; chỉ Admin được đọc.
- Báo cáo: revenue-by-cashier hỗ trợ lọc ngày, giữ báo cáo toàn lịch sử khi bỏ tham số ngày.
- WinForms: tab Đơn hàng & chi tiết, Doanh thu theo kỳ và Doanh thu thu ngân; lọc ngày/tuần/tháng/năm, giữ Dashboard và xuất CSV.
- Tồn kho: server trả cờ, trạng thái, ngưỡng và tổng cảnh báo của toàn bộ bộ lọc; WinForms dùng dữ liệu API để tô màu và xuất CSV.
- Giao diện: đồng bộ Login, Shell, POS và các màn hình quản lý; giữ nguyên kích thước cửa sổ và xử lý nghiệp vụ.
- Cấu trúc: gộp báo cáo vào FormQuickReport.cs/Designer.cs, chuyển control về Designer và dùng các file DTO có sẵn.
- README: cập nhật cấu trúc, giao diện, các kỳ báo cáo và quy trình lưu bài.
'@
git commit -m $commitMessage
git push -u origin Buoi-6
```

`git diff --cached --stat` cho biết các tệp sẽ được đưa vào commit. Sau khi push thành công, mở repository trên GitHub và chọn nhánh **Buoi-6** để xem bài.

### Tạo nhánh cho buổi tiếp theo, ví dụ `Buoi-7`

Sau khi đã commit và push xong Buoi-6, tạo nhánh mới từ bài hiện tại:

```powershell
git checkout Buoi-6
git checkout -b Buoi-7
```

Làm bài và lưu các tệp trên nhánh mới. Khi hoàn tất, chạy:

```powershell
git status
git add .
git diff --cached --stat
git commit -m "Buoi 7: ghi ro chuc nang vua them va loi vua sua"
git push -u origin Buoi-7
```

Thay nội dung commit bằng mô tả cụ thể của bài vừa làm. Buổi tiếp theo có thể tạo `Buoi-8` từ `Buoi-7` theo cùng cách.

### Sửa bổ sung trên nhánh đã có

Ví dụ muốn lưu lần sửa tiếp theo của Buoi-7:

```powershell
git checkout Buoi-7
# Sua code va luu tep truoc khi chay cac lenh tiep theo.
git status
git add .
git commit -m "Buoi 7: mo ta cu the phan vua bo sung hoac sua loi"
git push
```

Lần đầu dùng `git push -u origin TEN-NHANH` để liên kết nhánh với remote; các lần sau trên nhánh đó có thể dùng `git push`.

### Ý nghĩa các lệnh Git thường dùng

| Lệnh | Chức năng |
|------|-----------|
| `git branch --show-current` | Xem nhánh đang làm |
| `git checkout Buoi-6` | Chuyển sang nhánh đã tồn tại |
| `git checkout -b Buoi-7` | Tạo nhánh mới và chuyển sang nhánh đó |
| `git status` | Xem tệp đã sửa, tệp mới và trạng thái staging |
| `git add .` | Đưa thay đổi trong thư mục hiện tại vào staging |
| `git diff --cached --stat` | Kiểm tra danh sách tệp chuẩn bị commit |
| `git commit -m "Noi dung"` | Lưu mốc thay đổi trong repository trên máy |
| `git push -u origin Buoi-6` | Đẩy commit lên GitHub và liên kết nhánh |
| `git push` | Đẩy commit tiếp theo của nhánh đã liên kết |

Commit xong bài đang làm trước khi chuyển sang buổi khác. Chỉ dùng `git checkout -b` nếu nhánh mới chưa tồn tại.

**Repository:** https://github.com/phuc1910/MiniSupermarket_NguyenLeTanPhuc

---

## 👨‍💻 9. Tác giả
* **Họ tên sinh viên:** Nguyễn Lê Tấn Phúc
* **Mã sinh viên:** 2124110108
* **Lớp học phần:** CCQ2411D
