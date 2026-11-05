# 🛒 HỆ THỐNG QUẢN LÝ SIÊU THỊ MINI (MINISUPERMARKET SYSTEM)
> **Đề tài:** Xây dựng Ứng dụng Quản lý Cửa hàng Tiện lợi với ASP.NET Core và Windows Forms — Tiệm Tạp hóa Mỹ phẩm Xách tay Hana Shop  
> **Môn học:** Lập trình Ứng dụng .NET Core (Mã môn: 229162)  
> **Nội dung thực hành:**
> - **Buổi 1:** Xây dựng Web API quản lý danh mục và kết nối WinForms Client (CRUD)
> - **Buổi 2:** Bảo mật & Phân quyền JWT cho Web API và WinForms Client
> - **Buổi 3:** Tích hợp SQL Server và Entity Framework Core Code-First
> - **Buổi 4:** Giao diện Shell hợp nhất, phân quyền 3 cấp (Admin / Cashier / Warehouse), đăng nhập và quản trị tài khoản bằng bảng `Users` thật, quản lý Sản phẩm
> - **Buổi 5:** ADO.NET nâng cao, Stored Procedure báo cáo doanh thu và thanh toán POS bằng giao dịch `SqlTransaction`
> - **Buổi 6:** EF Core nâng cao: phân trang LINQ `.Skip()/.Take()`, Eager Loading `.Include()`, `.AsNoTracking()`, `ApiClientService` dùng chung, phân trang và lọc nhóm hàng trên WinForms. **Bổ sung:** Dashboard, biểu đồ cột và tròn, Top 5, màn hình đơn hàng riêng, doanh thu theo kỳ và thu ngân, đổi điểm POS theo số điểm nhập, xuất CSV, ngày đăng ký khách hàng. **Điều chỉnh:** cảnh báo tồn kho do server quyết định; tách Request/Response DTO; kiểm tra đầu vào; Cashier được thêm khách, xem sản phẩm và đơn hàng; Tải lại xóa thông tin đang chọn; kiểm tra tiền khách đưa và cho thanh toán 0 đồng khi đổi đủ điểm; đồng bộ giao diện trong các file Designer có sẵn và giữ nguyên kích thước cửa sổ.

---

## 🏗️ 1. Mô hình Kiến trúc Hệ thống (Client - Server)
Dự án được xây dựng theo mô hình **Client – Server**, trong đó giao diện, Web API và cơ sở dữ liệu có trách nhiệm riêng:
* **`MiniSupermarket.API` (Backend):** Dự án ASP.NET Core Web API xử lý logic nghiệp vụ, kết nối **SQL Server** qua **Entity Framework Core** và **ADO.NET**, cung cấp các RESTful API chuẩn hóa, xác thực người dùng bằng bảng `Users` trong cơ sở dữ liệu và cấp phát JWT Token.
* **`MiniSupermarket.WinForms` (Frontend Client):** Ứng dụng Windows Forms với **giao diện Shell hợp nhất** (Sidebar + vùng nội dung động) đóng vai trò máy trạm POS tại quầy, có màn hình đăng nhập, lưu Token và đính kèm `Bearer Token` khi dùng `HttpClient` gọi API.

### Bối cảnh và mục tiêu của ứng dụng

Hana Shop kinh doanh các mặt hàng mỹ phẩm, sản phẩm chăm sóc cá nhân và hàng xách tay. Khi số lượng sản phẩm, khách hàng và hóa đơn tăng lên, việc ghi chép rời rạc khiến nhân viên khó tra cứu tồn kho, kiểm tra lịch sử bán hàng và tổng hợp doanh thu. Ứng dụng tập trung các thao tác này vào một hệ thống dùng chung dữ liệu SQL Server.

Các mục tiêu nghiệp vụ chính của đồ án gồm:

* **Quản lý hàng hóa:** tổ chức sản phẩm theo nhóm, tra cứu bằng mã vạch hoặc tên, theo dõi giá bán và tồn kho.
* **Hỗ trợ bán hàng:** lập giỏ hàng, tra khách hàng, đổi điểm, kiểm tra tiền khách đưa và tạo hóa đơn.
* **Quản lý khách hàng thân thiết:** lưu hồ sơ, điểm tích lũy, hạng thành viên và thời điểm đăng ký.
* **Tra cứu hoạt động bán hàng:** xem danh sách đơn hàng, bộ lọc thời gian, chi tiết từng hóa đơn và tổng thực thu.
* **Theo dõi hiệu quả kinh doanh:** xem Dashboard, doanh thu theo kỳ, doanh thu theo thu ngân, biểu đồ và sản phẩm bán chạy.
* **Phân công công việc:** cung cấp các chức năng phù hợp với Admin, Cashier và Warehouse; kiểm tra quyền tại API.

### Luồng trao đổi dữ liệu

```text
Người dùng thao tác trên Windows Forms
                 |
                 v
ApiClientService gửi HTTP/JSON và Bearer Token
                 |
                 v
ASP.NET Core kiểm tra xác thực, quyền và dữ liệu đầu vào
                 |
                 v
Controller xử lý bằng EF Core hoặc ADO.NET
                 |
                 v
SQL Server truy vấn hoặc cập nhật trong giao dịch
                 |
                 v
API trả JSON, mã HTTP và thông báo cho WinForms
                 |
                 v
WinForms cập nhật bảng, ô thông tin, số tiền và biểu đồ
```

WinForms gửi yêu cầu và trình bày kết quả. Các thao tác như **ghi hóa đơn, trừ tồn kho, kiểm tra số dư điểm, tổng hợp doanh thu và xác định cảnh báo tồn thấp** được xử lý ở server. Điều này giúp các màn hình dùng cùng một quy tắc khi đọc dữ liệu.

### Vai trò của Web API trong đồ án

Web API là trọng tâm kết nối các phần của ứng dụng. Cùng một endpoint có thể được gọi từ WinForms hoặc kiểm thử trực tiếp trên Swagger. Vì vậy, việc nút bị ẩn hoặc điều khiển bị khóa trên giao diện không thay thế cho kiểm tra quyền và kiểm tra dữ liệu phía server.

Ví dụ, Cashier được thêm khách hàng nhưng không được sửa hoặc xóa hồ sơ khách hàng qua API. Tương tự, yêu cầu thanh toán gửi số điểm vượt số dư sẽ bị server từ chối dù dữ liệu đó được nhập từ giao diện hay gửi trực tiếp trên Swagger.

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

### Công nghệ được áp dụng vào từng phần

| Công nghệ / thành phần | Cách sử dụng trong ứng dụng |
|-----------------------|----------------------------|
| ASP.NET Core Controllers | Tổ chức endpoint theo nhóm Auth, Users, Categories, Products, Customers, Orders, Reports và ADO.NET |
| Entity Framework Core | Ánh xạ các bảng, thực hiện CRUD, kiểm tra dữ liệu trùng và truy vấn danh sách |
| Code First và Migrations | Tạo cấu trúc database từ model, quản lý thay đổi như cột ngày đăng ký khách hàng |
| LINQ `Where`, `OrderBy`, `Skip`, `Take` | Lọc và phân trang ngay trong truy vấn server |
| `Include` | Nạp quan hệ sản phẩm – nhóm hàng ở những truy vấn cần thông tin nhóm |
| `AsNoTracking` | Đọc danh sách và báo cáo không cần theo dõi thay đổi entity |
| Request / Response DTO | Nhận đúng trường được phép gửi lên và trả dữ liệu phù hợp cho màn hình |
| Data Annotations | Khai báo yêu cầu bắt buộc, độ dài chuỗi, giá bán dương và tồn kho không âm |
| JWT Bearer | Xác thực request và truyền vai trò người dùng giữa client với API |
| `PasswordHasher<User>` | Tạo và kiểm tra mật khẩu băm cho tài khoản trong bảng Users |
| `SqlDataReader` | Đọc dữ liệu theo luồng khi tra sản phẩm, xử lý checkout và đọc báo cáo |
| `SqlDataAdapter`, `DataTable` | Minh họa xử lý dữ liệu theo chế độ disconnected trong nhóm API ADO.NET |
| `SqlTransaction` | Gộp hóa đơn, chi tiết, tồn kho và điểm khách hàng thành một giao dịch |
| Stored Procedure | Tổng hợp doanh thu theo thu ngân, khoảng ngày, từng ngày và Top 5 sản phẩm |
| Windows Forms | Xây dựng màn hình quản lý, giỏ hàng và thao tác thu ngân trên desktop |
| `HttpClient`, `System.Net.Http.Json` | Gửi request bất đồng bộ và chuyển đổi JSON thành DTO |
| `Chart` | Trình bày doanh thu bằng biểu đồ cột và tỷ trọng doanh thu bằng biểu đồ tròn |
| CSV UTF-8 BOM | Xuất tồn kho và doanh thu để mở bằng Excel |

### EF Core và ADO.NET phối hợp như thế nào?

EF Core được dùng ở những phần cần thao tác entity và kết hợp điều kiện truy vấn, chẳng hạn quản lý sản phẩm hoặc danh sách đơn hàng phân trang. ADO.NET được dùng ở phần thanh toán cần thực hiện nhiều lệnh SQL trong cùng một transaction và ở các bài thực hành đọc dữ liệu, gọi Stored Procedure.

Hai cách truy cập dữ liệu đều sử dụng chuỗi kết nối cấu hình cho API. Client không mở kết nối SQL trực tiếp. Khi bổ sung một thao tác ở WinForms, phần giao diện gọi endpoint tương ứng thay vì viết truy vấn database trong form.

### Bất đồng bộ và phản hồi giao diện

Các thao tác gọi API sử dụng `async/await` để chờ phản hồi mà không chủ động chặn luồng giao diện. Phần báo cáo và đơn hàng có kiểm soát trạng thái đang tải; các yêu cầu chi tiết đơn hàng được hủy khi lựa chọn thay đổi để hạn chế hiển thị kết quả của đơn đã chọn trước đó.

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
    ├── FormOrderManagement.cs            # Gọi API danh sách, phân trang và chi tiết đơn hàng
    ├── FormOrderManagement.Designer.cs   # Bộ lọc ngày, lưới đơn hàng và lưới chi tiết
    ├── PagingBar.cs                      # Thanh phân trang dùng chung
    └── Models/ProductDto.cs              # DTO sản phẩm và dữ liệu phân trang phía máy khách
```

### Trách nhiệm của các thư mục

| Vị trí | Trách nhiệm |
|--------|-------------|
| `MiniSupermarket.API/Controllers` | Tiếp nhận HTTP request, kiểm tra nghiệp vụ và tạo HTTP response |
| `MiniSupermarket.API/Models` | Entity, DTO nhận dữ liệu, DTO đọc danh sách và kết quả phân trang |
| `MiniSupermarket.API/Data` | DbContext, cấu hình chỉ mục và dữ liệu mẫu |
| `MiniSupermarket.API/Migrations` | Lịch sử thay đổi cấu trúc cơ sở dữ liệu |
| `MiniSupermarket.API/Scripts` | Các thủ tục SQL cần tạo trên database để chạy báo cáo |
| `MiniSupermarket.API/Properties` | Profile chạy API, địa chỉ HTTP/HTTPS và môi trường Development |
| `MiniSupermarket.WinForms` | Các form, sự kiện giao diện, lớp phiên làm việc và kết nối API |
| `MiniSupermarket.WinForms/Models` | Các kiểu dữ liệu client dùng khi đọc JSON sản phẩm và phân trang |

### Quy ước tổ chức form

* **`FormTenManHinh.Designer.cs`:** khai báo control, bố cục, màu sắc, font, kích thước thành phần và các sự kiện được gắn trong Designer.
* **`FormTenManHinh.cs`:** xử lý khi người dùng bấm nút, chọn dòng, nhập dữ liệu, gọi API và cập nhật kết quả.
* **`FormTenManHinh.resx`:** tài nguyên của form khi có sử dụng.
* **`SessionManager.cs`:** chứa thông tin phiên và `ApiClientService` dùng chung; các form không tự tạo một phiên đăng nhập riêng.

Riêng phần báo cáo được giữ trong cặp file `FormQuickReport.cs` và `FormQuickReport.Designer.cs`. Danh sách và chi tiết đơn hàng nằm trong `FormOrderManagement`, mở từ menu riêng để người dùng tra cứu hóa đơn mà không phải đi vào màn hình báo cáo tài chính.

---

## 🔐 4. Xác thực và Phân quyền

Khác với Buổi 2 (tài khoản hard-code trong code), từ Buổi 4 hệ thống xác thực bằng **bảng `Users` lưu trong SQL Server**: `AuthController` truy vấn `Users` để kiểm tra tài khoản/mật khẩu trước khi cấp JWT Token, và `UsersController` cho phép Admin tạo mới/quản lý tài khoản nhân viên ngay trên ứng dụng — không cần sửa code mỗi khi thêm nhân viên.

> Đây là tài khoản demo phục vụ học tập, không phải thông tin đăng nhập thật. Mật khẩu mẫu của các tài khoản là `123456` (lưu dạng chuỗi băm trong CSDL).

| Endpoint | Quyền truy cập |
|----------|----------------|
| `POST /api/auth/login` | Công khai |
| Đọc danh mục, sản phẩm, khách hàng | Phải đăng nhập (chưa đăng nhập → **401**) |
| Thêm, sửa, xóa danh mục, sản phẩm | Chỉ Admin; API kiểm tra quyền ghi |
| Thêm khách hàng | Admin, Cashier |
| Sửa, xóa khách hàng | Chỉ Admin |
| `GET /api/users` | Chỉ Admin |
| `POST /api/users` | Chỉ Admin — tạo tài khoản nhân viên mới |
| `POST /api/orders/checkout` | Admin, Cashier — thanh toán POS và đổi điểm (Buổi 5, 6) |
| `GET /api/orders`, `GET /api/orders/{id}` | Admin, Cashier — đọc danh sách và chi tiết đơn hàng |
| `DELETE /api/orders/cancel/{orderId}` | Chỉ Admin — hủy hóa đơn (Buổi 5) |
| `GET /api/reports/*` | Chỉ Admin — báo cáo, Dashboard, biểu đồ, Top 5 (Buổi 5, 6) |

### Phân quyền giao diện trên WinForms Shell

| Vai trò | Màn hình mặc định | Các màn hình được phép truy cập |
|---------|---------------------|----------------------------------|
| Admin | Quản lý Danh mục | Bán hàng (POS), Danh mục, Sản phẩm, Khách hàng, Đơn hàng & chi tiết, Báo cáo Doanh thu, Quản trị Tài khoản |
| Cashier | Quản lý Khách hàng | Bán hàng (POS), Sản phẩm (tra cứu), Khách hàng (xem, tìm kiếm, thêm mới), Đơn hàng & chi tiết |
| Warehouse | Quản lý Danh mục | Danh mục, Sản phẩm |

### Luồng đăng nhập và sử dụng JWT

1. Người dùng nhập tên đăng nhập và mật khẩu tại `FormLogin`.
2. Client gọi `POST /api/auth/login` bằng `ApiClientService`.
3. API tìm tài khoản trong bảng `Users` và kiểm tra mật khẩu bằng `PasswordHasher`.
4. Nếu mật khẩu đúng nhưng tài khoản bị khóa, API từ chối đăng nhập.
5. Nếu hợp lệ, server cấp token chứa tên tài khoản và vai trò; thời hạn trong mã nguồn hiện tại là **2 giờ**.
6. Client lưu `JwtToken`, `CurrentUsername`, `CurrentRole` vào `SessionManager`.
7. `AuthHandler` tự gắn token vào các request sau bằng header `Authorization: Bearer <token>`.
8. Shell hiển thị các menu phù hợp và mở màn hình mặc định của vai trò.

Khi đăng xuất, thông tin phiên tại client được xóa. Khi token hết hạn hoặc không hợp lệ, API trả **401** và người dùng cần đăng nhập lại để nhận token mới.

### Phân biệt quyền xem và quyền ghi

Việc một vai trò nhìn thấy màn hình không có nghĩa vai trò đó được thực hiện toàn bộ thao tác trên màn hình. Theo cấu hình API hiện tại, **chỉ Admin được thêm, sửa và xóa nhóm hàng, sản phẩm**. Cashier và Warehouse có thể dùng các API đọc được bảo vệ bằng yêu cầu đăng nhập, nhưng request ghi ngoài quyền sẽ nhận **403**.

Đối với khách hàng, Cashier được phép **thêm mới**, hỗ trợ đăng ký khách ngay tại quầy. Các thao tác sửa và xóa vẫn dành cho Admin. Đối với đơn hàng, Admin và Cashier được đọc danh sách và chi tiết; thao tác hủy hóa đơn tại API chỉ dành cho Admin.

### Quản trị tài khoản nhân viên

Admin có thể xem danh sách tài khoản, tạo tài khoản mới, cập nhật họ tên và vai trò, đặt lại mật khẩu, khóa hoặc mở khóa tài khoản. Các vai trò hợp lệ là `Admin`, `Cashier`, `Warehouse`. API yêu cầu mật khẩu tạo mới hoặc đặt lại có ít nhất **6 ký tự** và kiểm tra trùng tên đăng nhập.

Khi khóa/mở khóa, API không cho Admin tự khóa tài khoản đang dùng. Khóa tài khoản được kiểm tra ở bước đăng nhập; sau khi đổi vai trò hoặc trạng thái tài khoản, cần đăng nhập lại để kiểm tra phiên mới và menu tương ứng.

### Các mã HTTP thường gặp

| Mã | Ý nghĩa trong quá trình sử dụng |
|----|--------------------------------|
| `200 OK` | Đọc dữ liệu hoặc thực hiện thao tác thành công ở endpoint tương ứng |
| `201 Created` | Tạo mới thành công ở các endpoint CRUD sử dụng phản hồi Created |
| `400 Bad Request` | Dữ liệu không hợp lệ, khoảng ngày sai hoặc giao dịch bị từ chối theo quy tắc nghiệp vụ |
| `401 Unauthorized` | Chưa đăng nhập, thiếu token hoặc token không còn hợp lệ |
| `403 Forbidden` | Đã xác thực nhưng không có quyền; đăng nhập tài khoản bị khóa cũng bị từ chối |
| `404 Not Found` | Không có đối tượng phù hợp với ID hoặc mã vạch được yêu cầu |
| `409 Conflict` | Dữ liệu trùng hoặc thao tác xung đột với dữ liệu đang có ở endpoint tương ứng |
| `500 Internal Server Error` | Lỗi xử lý máy chủ, kết nối SQL hoặc thực thi truy vấn cần kiểm tra thêm |

Nội dung phản hồi phụ thuộc endpoint. Lỗi validation có thể trả danh sách lỗi theo trường, còn lỗi nghiệp vụ thường có `message`; checkout có thể trả thêm `errorDetail` để giải thích lý do Rollback.

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

### Quan hệ và dữ liệu lịch sử

* **Categories – Products:** một nhóm có nhiều sản phẩm; mỗi sản phẩm tham chiếu một `CategoryId`.
* **Customers – Orders:** một khách có thể có nhiều hóa đơn; hóa đơn khách vãng lai có thể không gắn khách hàng.
* **Orders – OrderDetails:** mỗi hóa đơn có các dòng hàng với sản phẩm, số lượng, đơn giá và thành tiền.
* **Products – OrderDetails:** một sản phẩm có thể xuất hiện ở nhiều hóa đơn.
* **Users và hóa đơn:** tài khoản nhân viên được quản lý trong bảng Users; hóa đơn hiện lưu tên thu ngân tại trường `CashierUsername`.

Đơn giá lưu trong `OrderDetails` là đơn giá của lần bán. Khi xem lại chi tiết hóa đơn, thông tin giá và thành tiền được đọc từ dữ liệu hóa đơn, giúp việc tra cứu phản ánh giao dịch đã phát sinh.

### Các ràng buộc dữ liệu chính

| Dữ liệu | Quy tắc kiểm tra |
|---------|-------------------|
| Tên nhóm hàng | Bắt buộc, không vượt độ dài cho phép và được kiểm tra trùng |
| Mã vạch | Bắt buộc, dùng để tra đúng sản phẩm và có Unique Index |
| Tên sản phẩm | Bắt buộc, giới hạn độ dài theo Request DTO |
| Giá bán | Phải lớn hơn 0 |
| Tồn kho | Không được âm trong thao tác thêm/sửa sản phẩm |
| Nhóm của sản phẩm | Phải tồn tại trước khi thêm hoặc cập nhật sản phẩm |
| Số điện thoại khách | Bắt buộc, kiểm tra trùng và dùng để tra hồ sơ khách thân thiết |
| Điểm khách hàng | Không được âm ở dữ liệu đầu vào quản lý khách hàng |
| Tên đăng nhập | Bắt buộc và không trùng tài khoản đã có |
| Số lượng bán | Mỗi dòng hàng phải có số lượng lớn hơn 0 |
| Giá gửi khi checkout | Phải khớp giá sản phẩm trong database; sai giá làm giao dịch bị hủy |

### Giao dịch thanh toán và tính nhất quán

Checkout thực hiện các bước có liên quan trong cùng `SqlTransaction`: tra khách, kiểm tra điểm, tính tiền giảm, kiểm tra tiền khách đưa, tạo hóa đơn, ghi chi tiết, đối chiếu giá/tồn, trừ hàng và cập nhật điểm. Chỉ khi các bước hợp lệ thì server mới **Commit**.

Nếu có bước thất bại, server **Rollback**, tránh tình trạng đã trừ hàng nhưng chưa có hóa đơn hoặc đã trừ điểm nhưng thanh toán không thành công. Các truy vấn kiểm tra khách và sản phẩm trong giao dịch có sử dụng khóa dòng để phối hợp cập nhật dữ liệu tại thời điểm bán.

Hủy hóa đơn cũng là một giao dịch: đọc hóa đơn và chi tiết, trả lại tồn kho, thu hồi điểm đã cộng, hoàn số điểm đã đổi rồi xóa chi tiết và hóa đơn. Vì mã hiện tại xóa hóa đơn khi hủy, các báo cáo đọc từ bảng Orders sẽ phản ánh dữ liệu sau khi hủy.

### Giá trị tính toán không cần thêm cột

`IsLowStock`, `StockStatus` và ngưỡng cảnh báo được suy ra từ tồn kho ở server. Việc thêm các thông tin phản hồi này không yêu cầu tạo cột tương ứng trong bảng Products. Tương tự, `CashReceived` và `PointsToRedeem` là dữ liệu của yêu cầu checkout; thay đổi ô nhập điểm ở POS không tự phát sinh một migration mới.

---

## 🖥️ 6. Giao diện Shell hợp nhất

Toàn bộ nghiệp vụ được điều hướng trong **một Form chính (`FormMainShell`)** thay vì mở nhiều cửa sổ rời rạc:

* **Sidebar bên trái:** chỉ hiển thị nút tương ứng với vai trò đang đăng nhập; nút đang chọn được làm nổi bật màu khác.
* **Vùng nội dung chính:** nhúng động Form nghiệp vụ (`TopLevel = false`, `Dock = Fill`).
* **Phân quyền ở giao diện và API:** menu được hiển thị theo vai trò; API tiếp tục kiểm tra quyền khi nhận request. Một số sự kiện như mở Báo cáo hoặc Đơn hàng có kiểm tra vai trò tại Shell.

### Giao diện thống nhất và giữ nguyên cấu trúc mã nguồn

* Các màn hình Đăng nhập, Shell, POS, Danh mục, Sản phẩm, Khách hàng, Tài khoản và Báo cáo dùng cùng kiểu chữ Segoe UI, nền sáng, nút xanh và bảng dữ liệu có tiêu đề rõ ràng.
* Giữ nguyên `ClientSize`, kích thước tối thiểu và trạng thái cửa sổ hiện có; bố cục chỉ được sắp xếp lại bên trong bằng các panel/layout của WinForms.
* Khai báo control, vị trí, màu sắc, kích thước thành phần và gắn sự kiện được viết trong `FormTenManHinh.Designer.cs`. Các hàm xử lý sự kiện và gọi API nằm trong `FormTenManHinh.cs`, theo cách tổ chức cũ.
* Mã báo cáo nằm trong `FormQuickReport.cs` và `FormQuickReport.Designer.cs`. Màn hình đơn hàng dùng `FormOrderManagement.cs` và `FormOrderManagement.Designer.cs`; DTO đọc hóa đơn phía client đặt cùng `FormOrderManagement.cs`, DTO báo cáo đặt cùng `FormQuickReport.cs`. DTO API đặt trong `CheckoutDtos.cs` có sẵn.
* Các thay đổi giao diện không đổi quy tắc checkout, đổi điểm, tồn kho, phân quyền, kiểm tra dữ liệu hay cách tính doanh thu ở server.
* **Tải lại / Tải lại danh sách** trên Danh mục, Sản phẩm, Khách hàng và Tài khoản sẽ nạp lại dữ liệu, bỏ chọn dòng và xóa các ô thông tin đang nhập; Sản phẩm bỏ chọn nhóm hàng, Tài khoản bỏ chọn vai trò. Các màn hình có tìm kiếm sẽ xóa từ khóa, trả bộ lọc về tất cả và quay về trang đầu. Cần chọn lại một dòng trước khi sửa/xóa hoặc nhập thông tin để thêm mới.

### Dashboard và báo cáo trên `FormQuickReport` — bổ sung Buổi 6

* **Thẻ tổng quan:** doanh thu hôm nay, số hóa đơn hôm nay, khách đăng ký mới hôm nay và số sản phẩm tồn thấp trên toàn kho.
* **Báo cáo theo khoảng ngày:** tổng hóa đơn, doanh thu và sản phẩm bán chạy nhất theo **Từ ngày – Đến ngày**; chọn hai ô cùng ngày để xem đúng một ngày.
* **Biểu đồ cột trên tab Tổng quan:** chọn đúng một ngày thì hiển thị đủ 24 giờ từ 00:00 đến 23:00 qua API `revenue-by-hour?date=yyyy-MM-dd`. Khoảng nhiều ngày dùng `revenue-by-day`; giờ/ngày chưa có đơn có doanh thu bằng 0. Máy chủ tổng hợp theo thời điểm `Orders.CreatedDate` đang lưu, lấy trọn ngày được chọn.
* **Biểu đồ tròn trên tab Tổng quan:** tỷ trọng doanh thu thực thu theo thu ngân, dùng API `revenue-by-cashier` với cùng khoảng ngày đang lọc. Chú giải ghi tên thu ngân, rê chuột xem tiền và tỷ lệ. Kỳ không có doanh thu hiển thị thông báo dữ liệu rỗng.
* **Top 5 sản phẩm bán chạy:** lấy từ API `best-sellers`, tính trên toàn bộ lịch sử bán hàng.
* **Xuất dữ liệu:** nút **Xuất tồn kho** xuất toàn bộ sản phẩm; nút **Xuất doanh thu** xuất theo khoảng ngày. CSV có UTF-8 BOM, dấu phân cách theo vùng, xử lý dấu ngoặc kép và dữ liệu có thể bị Excel hiểu là công thức.
* **Màn hình Đơn hàng & chi tiết:** mở từ menu riêng trên thanh bên. Chọn **Ngày**, **Tháng**, **Năm** và mốc tương ứng hoặc **Tùy chọn** khoảng Từ/Đến, rồi nhấn **Tải đơn hàng**. Danh sách phân trang **5 đơn/trang**, đổi bộ lọc sẽ đưa về trang đầu. Chọn đơn để xem khách hàng, thu ngân, thời điểm lập, tiền thực thu, điểm thưởng và từng dòng sản phẩm với số lượng, đơn giá lịch sử, thành tiền. Tổng thực thu phía dưới tính trên toàn bộ kết quả lọc. Màn hình chỉ tra cứu danh sách và chi tiết. Admin và Cashier được xem danh sách, lọc và đọc chi tiết đơn hàng; quyền này được kiểm tra tại API và menu WinForms.
* **Tab Doanh thu theo kỳ:** chọn **Ngày**, **Tuần**, **Tháng** hoặc **Năm** và mốc thời gian tương ứng; xem số đơn, tiền thực thu, sản phẩm bán chạy nhất và doanh thu từng thu ngân trong kỳ. Báo cáo có ba tab Tổng quan, Doanh thu theo kỳ và Doanh thu thu ngân.
* **Tab Doanh thu thu ngân:** hiển thị tài khoản thu ngân, số đơn, doanh thu thực thu và điểm đã cộng. Lọc theo ngày/tuần/tháng/năm, khoảng ngày tùy chọn hoặc **Toàn bộ lịch sử**.

Bộ lọc trên tab Tổng quan có **Ngày**, **Tuần**, **Tháng**, **Năm** và **Tùy chọn**; áp dụng cho báo cáo theo khoảng, biểu đồ và CSV doanh thu. Các thẻ hôm nay và Top 5 toàn lịch sử có phạm vi riêng. Các tab có bộ lọc độc lập. Kỳ không có đơn hiển thị 0 và danh sách rỗng.

Quy ước kỳ báo cáo: ngày được chọn; tuần từ **thứ Hai đến Chủ nhật** chứa ngày mốc; tháng từ ngày đầu đến ngày cuối tháng; năm từ **01/01 đến 31/12**. Client chỉ xác định hai mốc ngày gửi API; việc tổng hợp doanh thu và dữ liệu vẫn được thực hiện ở server.

### Đổi điểm thưởng tại POS — bổ sung Buổi 6

* Tra khách hàng bằng số điện thoại, hiển thị tên và số điểm hiện có tại POS; hồ sơ và hạng thành viên được quản lý ở màn hình Khách hàng.
* Chọn **Nhập điểm muốn đổi** để bật ô nhập số điểm nguyên. Tỷ lệ **1 điểm giảm 1.000 đồng**; số điểm tối đa bằng số nhỏ hơn giữa điểm hiện có của khách và `floor(tiền hàng / 1.000)`. Không còn giới hạn cố định một gói 50 điểm. Giao diện hiển thị điểm hiện có, mức đổi tối đa và tiền giảm; bỏ chọn đổi điểm hoặc đổi khách sẽ xóa số điểm đang nhập.
* Server xử lý đổi điểm trong giao dịch thanh toán, tính điểm thưởng theo `floor(FinalAmount / 10.000)` và hoàn lại điểm đã đổi khi hủy hóa đơn.
* WinForms cập nhật tiền phải trả và tiền thừa theo lựa chọn đổi điểm trước khi gửi checkout.
* Khi tổng sau đổi điểm **còn lớn hơn 0**, tiền khách đưa phải **lớn hơn tổng cần thanh toán**. Khi đổi điểm hết tiền hàng, tổng bằng **0 đồng** thì được nhập **0 đồng**, tiền thừa bằng 0. Để trống, nhập sai số hoặc số âm đều bị chặn; giỏ hàng được giữ lại để sửa. WinForms kiểm tra khi bấm Thanh toán hoặc F9, API kiểm tra lại trước khi lưu hóa đơn. Khi thử `POST /api/orders/checkout` trên Swagger, gửi `cashReceived`, `usePoints` và `pointsToRedeem` (không dùng điểm thì `usePoints: false`, `pointsToRedeem: 0`). Server từ chối số điểm vượt số dư hoặc tiền hàng và trừ điểm trong cùng giao dịch với hóa đơn, tồn kho.

### Cảnh báo tồn kho và dùng chung kết nối — bổ sung, điều chỉnh Buổi 6

* Server quyết định `isLowStock`, `stockStatus` và `lowStockThreshold` từ một quy tắc chung trong `Product`: tồn bằng 0 là **Hết hàng**, tồn từ 1 đến 10 là **Sắp hết hàng**, cao hơn ngưỡng là **Còn hàng**.
* API sản phẩm phân trang trả thêm `totalLowStockItems`: tổng sản phẩm cảnh báo trong toàn bộ bộ lọc từ khóa/nhóm hàng trước khi chia trang. Dashboard cũng đếm trên SQL Server.
* WinForms chỉ dùng `isLowStock` để tô màu, dùng tổng và ngưỡng do API trả để hiển thị cảnh báo; CSV dùng `stockStatus` từ server. Không còn phép so sánh ngưỡng tồn thấp hoặc đếm cảnh báo tại WinForms.
* Đăng nhập và các thao tác CRUD danh mục, khách hàng dùng `ApiClientService` chung, tránh tạo `HttpClient` riêng cho từng thao tác; bổ sung xử lý phản hồi lỗi khi nạp dữ liệu.

### Thao tác tại màn hình Danh mục

1. Mở **Danh mục** để xem danh sách nhóm hàng và thanh phân trang.
2. Nhập từ khóa để tìm theo tên nhóm; tìm kiếm mới bắt đầu từ trang 1.
3. Chọn một dòng để đưa mã, tên nhóm và mô tả lên vùng thông tin.
4. Với quyền Admin, nhập dữ liệu để thêm mới hoặc chọn đúng dòng trước khi sửa/xóa.
5. Nhấn **Tải lại** để xóa từ khóa, quay về trang đầu, bỏ chọn dòng và làm trống thông tin.

API chặn xóa nhóm còn sản phẩm. Vì vậy, nếu xóa thất bại cần đọc thông báo trả về thay vì chỉ dựa vào việc nút Xóa có hiển thị trên form.

### Thao tác tại màn hình Sản phẩm – tồn kho

Màn hình kết hợp vùng tìm kiếm, danh sách sản phẩm, bộ lọc nhóm và vùng thông tin. Bảng hiển thị mã sản phẩm, mã vạch, tên, giá, tồn kho, tên nhóm và trạng thái tồn.

* Tìm theo **mã vạch hoặc tên sản phẩm**, có thể kết hợp lọc một nhóm hàng.
* Mỗi trang giao diện lấy **5 sản phẩm** từ API, không tải toàn bộ danh sách về rồi tự chia trang.
* Chọn dòng để đọc hoặc chỉnh thông tin; quyền ghi cuối cùng được API kiểm tra.
* Nhấn **Tải lại** để nạp danh mục và sản phẩm mới nhất, trả bộ lọc về tất cả, bỏ chọn nhóm trong vùng nhập và xóa thông tin sản phẩm cũ.
* Màu cảnh báo được áp dụng từ cờ `isLowStock` server trả về; tổng cảnh báo tính trên toàn bộ kết quả khớp bộ lọc.

Ví dụ có 20 sản phẩm trong bộ lọc nhưng trang đầu chỉ hiển thị 5 dòng: tổng cảnh báo không chỉ đếm trong 5 dòng đang nhìn thấy. Khi chuyển trang, phạm vi cảnh báo vẫn là 20 sản phẩm của bộ lọc đó.

### Thao tác tại màn hình Khách hàng

Khách hàng được tìm theo tên hoặc số điện thoại. Chọn một dòng để đọc họ tên, số điện thoại, địa chỉ, điểm và hạng thành viên. Danh sách có phân trang và dùng API chung với các nghiệp vụ cần tra khách tại POS.

Admin được thêm/sửa/xóa; Cashier được thêm mới và tra cứu. Khi nhấn **Tải lại**, từ khóa được xóa, danh sách trở về trang đầu và các ô thông tin khách được làm trống. Số điện thoại trùng sẽ bị API từ chối để tránh một số điện thoại được đăng ký thành nhiều hồ sơ.

### Thao tác tại màn hình Tài khoản

Màn hình dành cho Admin, gồm bảng tài khoản và vùng nhập tên đăng nhập, họ tên, mật khẩu, vai trò. Khi chọn tài khoản cũ, mật khẩu không được đọc ngược từ database lên form. Để đặt lại mật khẩu, Admin nhập mật khẩu mới và dùng nút tương ứng.

Nút **Tải lại danh sách** xóa cả tài khoản đang chọn, ô mật khẩu và vai trò đang chọn. Muốn tạo tài khoản mới phải nhập lại thông tin cần thiết và chọn vai trò; muốn cập nhật, đặt lại mật khẩu hoặc khóa/mở cần chọn đúng tài khoản trước khi thao tác.

### Quy trình bán hàng và đổi điểm tại POS

1. Nhập hoặc quét mã vạch rồi nhấn **Enter** để thêm sản phẩm vào giỏ.
2. Quét lại cùng sản phẩm để tăng số lượng; giao diện kiểm tra sớm số lượng so với tồn kho nhận được.
3. Nếu khách có hồ sơ, nhập số điện thoại để tra tên và điểm; khách vãng lai có thể để trống số điện thoại.
4. Chọn **Nhập điểm muốn đổi** nếu muốn sử dụng điểm. Ô nhập chỉ được bật khi có điểm và tiền hàng đủ để quy đổi ít nhất một điểm.
5. Nhập số điểm nguyên trong giới hạn hiển thị. Tổng cần thanh toán và dòng tiền giảm được cập nhật theo lựa chọn.
6. Nhập tiền khách đưa; kiểm tra tiền thừa và bấm **Thanh toán** hoặc **F9**.
7. Khi thành công, đọc mã hóa đơn, tiền thực thu, điểm đã dùng và điểm cộng thêm trong thông báo; giỏ hàng được làm mới.

Nếu API từ chối, giỏ hàng được giữ để sửa lại. Đổi số điện thoại hoặc bỏ chọn sử dụng điểm sẽ xóa số điểm đang nhập; giảm tiền hàng hoặc thay đổi số dư sẽ giới hạn lại số điểm có thể dùng.

### Công thức và ví dụ đổi điểm

```text
Tiền hàng             = tổng (số lượng × đơn giá) của các dòng giỏ hàng
Điểm tối đa được đổi  = min(điểm hiện có, floor(tiền hàng / 1.000))
Tiền giảm             = số điểm muốn đổi × 1.000
Tổng cần thanh toán   = tiền hàng − tiền giảm
Điểm cộng thêm        = floor(tổng cần thanh toán / 10.000), khi hóa đơn có khách hàng
Điểm sau thanh toán   = điểm trước thanh toán − điểm đã đổi + điểm cộng thêm
```

| Điểm hiện có | Tiền hàng | Điểm muốn đổi | Kết quả |
|-------------:|----------:|--------------:|---------|
| 200 | 85.000 đ | 20 | Giảm 20.000 đ, còn thanh toán 65.000 đ |
| 200 | 85.000 đ | 85 | Giảm hết 85.000 đ, còn 0 đ và được nhập tiền khách đưa 0 đ |
| 200 | 85.000 đ | 86 | Không hợp lệ vì tiền giảm vượt tiền hàng |
| 10 | 85.000 đ | 20 | Không hợp lệ vì vượt số điểm hiện có |
| 200 | 85.500 đ | 85 | Giảm 85.000 đ, còn 500 đ; không được đổi 86 điểm |
| 0 | 85.000 đ | 1 | Không có điểm để đổi |

Khi tổng còn dương, ứng dụng giữ quy tắc tiền khách đưa phải **lớn hơn** tổng. Ví dụ còn 65.000 đ thì nhập 65.000 đ vẫn bị chặn, còn 65.001 đ thỏa điều kiện. Ngoại lệ hiện tại là tổng đã về **0 đ** sau đổi điểm: nhập **0 đ** được chấp nhận. Tiền âm và ô tiền không phải số không được chấp nhận.

### Tra cứu đơn hàng độc lập với báo cáo

Màn hình đơn hàng phục vụ việc kiểm tra một giao dịch cụ thể. Nhân viên chọn khoảng thời gian, tải danh sách, chuyển trang rồi chọn hóa đơn để xem khách, thu ngân, thời điểm lập và từng dòng sản phẩm. Bảng chi tiết dùng đơn giá lịch sử của hóa đơn.

Các bộ lọc có **Ngày, Tháng, Năm và Tùy chọn**. Danh sách lấy **5 đơn/trang**, sắp theo thời gian mới trước. Dòng tổng thực thu được server tính trên toàn bộ kết quả lọc, không phải cộng riêng các hóa đơn của trang hiện tại. Phần tra cứu này không cung cấp nút quản trị hủy hóa đơn; endpoint hủy vẫn được bảo vệ riêng cho Admin.

### Phạm vi số liệu của các phần báo cáo

| Thành phần | Phạm vi dữ liệu |
|------------|-----------------|
| Thẻ hôm nay | Ngày hiện tại theo dữ liệu/thời gian server đang dùng |
| Thẻ cảnh báo tồn | Sản phẩm tồn thấp trên toàn kho |
| Tổng đơn, tổng doanh thu theo khoảng | Khoảng ngày được chọn trên tab tương ứng |
| Biểu đồ cột một ngày | Đủ 24 giờ của ngày được chọn, giờ không có đơn bằng 0 |
| Biểu đồ cột nhiều ngày | Doanh thu từng ngày trong khoảng lọc |
| Biểu đồ tròn | Tỷ trọng doanh thu theo thu ngân trong cùng khoảng ngày đang lọc |
| Top 5 trên Tổng quan | Lịch sử bán hàng theo API `best-sellers` |
| Doanh thu theo kỳ | Ngày, tuần, tháng hoặc năm chứa ngày mốc |
| Doanh thu thu ngân toàn lịch sử | Toàn bộ dữ liệu khi chọn chế độ tương ứng |
| CSV tồn kho | Toàn bộ sản phẩm được tải cho chức năng xuất tồn kho |
| CSV doanh thu | Khoảng ngày của chức năng xuất doanh thu |

Các tab có bộ lọc độc lập. Vì phạm vi khác nhau nên Top 5 toàn lịch sử hoặc thẻ hôm nay có thể khác số liệu của một khoảng ngày tùy chọn; cần đọc đúng nhãn khi đối chiếu kết quả.

### Xuất dữ liệu và mở bằng Excel

Người dùng chọn nút xuất, chọn vị trí lưu và tên file trong hộp thoại lưu của Windows. File CSV dùng UTF-8 BOM để giữ dấu tiếng Việt và dấu phân cách theo thiết lập vùng. Trường có dấu phân cách, xuống dòng hoặc dấu ngoặc kép được xử lý khi ghi file; các giá trị có nguy cơ bị Excel hiểu là công thức được xử lý trong hàm xuất.

Chức năng xuất cung cấp dữ liệu dạng bảng. Biểu đồ trong ứng dụng vẫn là phần trình bày trên form; hai nút CSV hiện tại xuất tồn kho và doanh thu, không xuất nguyên giao diện báo cáo thành PDF hoặc ảnh.

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
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=TanPhucMiniSupermarketDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
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
6. Dùng Cashier mở **Khách hàng** để thêm khách mới, tìm kiếm và tra cứu hồ sơ; nút sửa/xóa dành cho Admin. Mở **Đơn hàng & chi tiết** để lọc và xem hóa đơn. Vào POS, nhập mã vạch và số điện thoại khách hoặc để trống với khách vãng lai. Chọn đổi điểm, nhập số điểm trong giới hạn và kiểm tra tiền phải trả, tiền thừa; thử đổi đủ để tổng về 0 rồi nhập tiền khách đưa là 0. Thanh toán bằng nút **THANH TOÁN** hoặc F9. Khi cần kiểm tra server Rollback do thiếu tồn, dùng Swagger trên database thử nghiệm vì WinForms có thể chặn số lượng trước khi gửi.
7. Dùng Admin mở **Đơn hàng & chi tiết** từ thanh bên, lọc ngày, đổi trang và chọn đơn để xem từng dòng hàng. Mở **Báo cáo doanh thu** và kiểm tra ba tab **Tổng quan**, **Doanh thu theo kỳ**, **Doanh thu thu ngân**; chuyển bộ lọc ngày/tuần/tháng/năm và khoảng tùy chọn; kiểm tra kỳ có/không có đơn và toàn lịch sử theo thu ngân. Tab Tổng quan có biểu đồ, Top 5 và hai nút xuất CSV. Tài khoản mẫu: `admin01`, `cashier01`, `ware01`; mật khẩu mẫu `123456`.
8. Tắt cả hai ứng dụng rồi mở lại — dữ liệu vẫn còn nguyên vì đã lưu trên SQL Server.

### Kiểm tra môi trường trước khi chạy

Mở PowerShell tại thư mục solution để kiểm tra SDK, khôi phục thư viện và biên dịch:

```powershell
Set-Location D:\MiniSupermarket_NguyenLeTanPhuc
dotnet --list-sdks
dotnet restore MiniSupermarket_NguyenLeTanPhuc.sln
dotnet build MiniSupermarket_NguyenLeTanPhuc.sln
```

Khi biên dịch lại, dừng phiên Debug đang giữ file thực thi để tránh lỗi không thể sao chép `.exe` hoặc `.dll`. Sau khi sửa đồng thời DTO và giao diện checkout, cần chạy lại **cả API và WinForms** để hai bên dùng cùng cấu trúc request.

Trong Visual Studio, **Package Manager Console** và **Developer PowerShell** là hai cửa sổ khác nhau. Lệnh `Update-Database` bên trên chạy trong Package Manager Console của Entity Framework; không sao chép lệnh đó vào PowerShell thông thường nếu môi trường chưa có công cụ tương ứng.

### Cấu hình chạy đồng thời hai dự án

Có thể chạy API trước rồi mở WinForms bằng **Debug → Start new instance**, hoặc cấu hình nhiều startup project trong thuộc tính solution. Khi cấu hình chạy đồng thời, đặt cả `MiniSupermarket.API` và `MiniSupermarket.WinForms` ở trạng thái **Start**, dùng profile API **https**.

| Thành phần | Địa chỉ / cấu hình trong source |
|------------|----------------------------------|
| API HTTPS | `https://localhost:7251` |
| Swagger | `https://localhost:7251/swagger` |

Swagger hiện được bật trong nhánh kiểm tra môi trường Development của `Program.cs`. Profile HTTP có cổng khác với HTTPS; client mặc định đang dùng HTTPS 7251 nên cần khởi chạy cấu hình phù hợp.

### Quy trình kiểm thử một endpoint trên Swagger

1. Chạy API và chờ máy chủ bắt đầu lắng nghe tại cổng cấu hình.
2. Mở Swagger, tìm nhóm controller cần thử.
3. Với endpoint đăng nhập, bấm **Try it out**, nhập JSON và **Execute**.
4. Copy giá trị `token` nhận được, mở **Authorize**, dán chuỗi token và xác nhận.
5. Gọi endpoint đọc dữ liệu trước để kiểm tra token và kết nối database.
6. Khi thử thêm/sửa/xóa hoặc checkout, chọn dữ liệu thử và đọc đầy đủ mã HTTP, body phản hồi.
7. Thử lại bằng tài khoản có vai trò khác để kiểm tra cả trường hợp được phép và bị từ chối.

Ví dụ đăng nhập với tài khoản mẫu đã được tạo trong database:

```json
{
  "username": "admin01",
  "password": "123456"
}
```

Phản hồi thành công chứa các trường `success`, `token`, `role`, `username`. Token là giá trị server sinh cho mỗi phiên; không lấy chuỗi minh họa hoặc mật khẩu để dán vào ô Authorize.

### Danh sách Web API theo nhóm chức năng

Các bảng sau mô tả **49 endpoint nghiệp vụ** trong tám controller của ứng dụng. Đường dẫn dùng tiền tố `/api`. `WeatherForecastController` là controller mẫu riêng, không tính vào nhóm nghiệp vụ cửa hàng.

**Nhóm Auth — đăng nhập**

| Phương thức | Endpoint | Nội dung | Quyền |
|-------------|----------|----------|-------|
| POST | `/api/auth/login` | Kiểm tra tài khoản, mật khẩu, trạng thái và cấp JWT | Công khai |

**Nhóm Categories — danh mục nhóm hàng**

| Phương thức | Endpoint | Nội dung | Quyền |
|-------------|----------|----------|-------|
| GET | `/api/categories` | Đọc danh sách nhóm hàng | Đã đăng nhập |
| GET | `/api/categories/{id}` | Đọc một nhóm theo ID | Đã đăng nhập |
| GET | `/api/categories/paged` | Lọc tên nhóm và phân trang | Đã đăng nhập |
| GET | `/api/categories/search` | Tìm nhóm theo từ khóa | Đã đăng nhập |
| POST | `/api/categories` | Thêm nhóm hàng | Admin |
| PUT | `/api/categories/{id}` | Cập nhật nhóm hàng | Admin |
| DELETE | `/api/categories/{id}` | Xóa nhóm theo điều kiện nghiệp vụ | Admin |
| GET | `/api/categories/admin-dashboard` | Endpoint minh họa quyền quản trị | Admin |
| GET | `/api/categories/staff-pos` | Endpoint minh họa quyền nhân viên bán hàng | Admin, Cashier |

**Nhóm Products — sản phẩm và tồn kho**

| Phương thức | Endpoint | Nội dung | Quyền |
|-------------|----------|----------|-------|
| GET | `/api/products` | Đọc danh sách sản phẩm | Đã đăng nhập |
| GET | `/api/products/{id}` | Đọc sản phẩm theo ID | Đã đăng nhập |
| GET | `/api/products/search` | Tìm theo tên/mã vạch và lọc nhóm | Đã đăng nhập |
| GET | `/api/products/paged` | Phân trang, lọc nhóm và trả tổng cảnh báo | Đã đăng nhập |
| GET | `/api/products/with-category` | Đọc sản phẩm kèm thông tin nhóm | Đã đăng nhập |
| GET | `/api/products/barcode/{barcode}` | Tra một sản phẩm theo mã vạch | Đã đăng nhập |
| POST | `/api/products` | Thêm sản phẩm | Admin |
| PUT | `/api/products/{id}` | Cập nhật sản phẩm | Admin |
| DELETE | `/api/products/{id}` | Xóa sản phẩm theo điều kiện nghiệp vụ | Admin |

**Nhóm Customers — khách hàng thân thiết**

| Phương thức | Endpoint | Nội dung | Quyền |
|-------------|----------|----------|-------|
| GET | `/api/customers` | Đọc danh sách khách hàng | Đã đăng nhập |
| GET | `/api/customers/{id}` | Đọc hồ sơ theo ID | Đã đăng nhập |
| GET | `/api/customers/paged` | Tìm theo tên/số điện thoại và phân trang | Đã đăng nhập |
| GET | `/api/customers/search` | Tìm khách, phục vụ tra cứu tại POS | Đã đăng nhập |
| POST | `/api/customers` | Đăng ký khách hàng | Admin, Cashier |
| PUT | `/api/customers/{id}` | Cập nhật hồ sơ | Admin |
| DELETE | `/api/customers/{id}` | Xóa hồ sơ theo điều kiện nghiệp vụ | Admin |

**Nhóm Users — tài khoản nhân viên**

| Phương thức | Endpoint | Nội dung | Quyền |
|-------------|----------|----------|-------|
| GET | `/api/users` | Đọc danh sách tài khoản | Admin |
| GET | `/api/users/{id}` | Đọc tài khoản theo ID | Admin |
| GET | `/api/users/search` | Tìm tài khoản | Admin |
| POST | `/api/users` | Tạo tài khoản mới, băm mật khẩu | Admin |
| PUT | `/api/users/{id}` | Cập nhật họ tên và vai trò | Admin |
| PUT | `/api/users/{id}/reset-password` | Đặt lại mật khẩu | Admin |
| PUT | `/api/users/{id}/toggle-lock` | Khóa hoặc mở khóa tài khoản | Admin |

**Nhóm Orders — hóa đơn và thanh toán**

| Phương thức | Endpoint | Nội dung | Quyền |
|-------------|----------|----------|-------|
| GET | `/api/orders` | Danh sách phân trang, lọc ngày, tổng thực thu toàn bộ bộ lọc | Admin, Cashier |
| GET | `/api/orders/{id}` | Đọc thông tin hóa đơn và các dòng chi tiết | Admin, Cashier |
| POST | `/api/orders/checkout` | Lập hóa đơn, đổi điểm, trừ kho và cập nhật điểm | Admin, Cashier |
| DELETE | `/api/orders/cancel/{orderId}` | Hủy hóa đơn, hoàn tồn và điều chỉnh điểm | Admin |

**Nhóm Reports — báo cáo và biểu đồ**

| Phương thức | Endpoint | Nội dung | Quyền |
|-------------|----------|----------|-------|
| GET | `/api/reports/dashboard-summary` | Số liệu tóm tắt Dashboard | Admin |
| GET | `/api/reports/revenue-by-day` | Doanh thu từng ngày trong khoảng | Admin |
| GET | `/api/reports/revenue-by-hour` | Doanh thu đủ 24 giờ của một ngày | Admin |
| GET | `/api/reports/best-sellers` | Danh sách sản phẩm bán chạy cho Tổng quan | Admin |
| GET | `/api/reports/revenue-by-cashier` | Doanh thu thu ngân có lọc ngày hoặc toàn lịch sử | Admin |
| GET | `/api/reports/revenue-by-date` | Doanh thu thu ngân theo khoảng qua Stored Procedure | Admin |
| GET | `/api/reports/top-products` | Top 5 sản phẩm qua Stored Procedure | Admin |
| GET | `/api/reports/quick-report` | Tổng đơn, tiền thực thu và sản phẩm bán chạy trong kỳ | Admin |

**Nhóm ADO.NET — bài thực hành truy vấn SQL**

| Phương thức | Endpoint | Nội dung | Quyền |
|-------------|----------|----------|-------|
| GET | `/api/ado-products/barcode/{barcode}` | Tra mã vạch bằng SqlDataReader | Đã đăng nhập |
| GET | `/api/ado-products/disconnected-cache` | Nạp DataTable bằng SqlDataAdapter rồi trả dữ liệu đọc từ bộ nhớ | Đã đăng nhập |
| GET | `/api/ado-products/filter-stock` | Lọc tồn kho theo ngưỡng `minStock` được truyền | Đã đăng nhập |
| GET | `/api/ado-products/count-by-category` | Thống kê số sản phẩm theo nhóm | Đã đăng nhập |

### Tham số phân trang và bộ lọc

| API | Tham số thường dùng | Ví dụ |
|-----|---------------------|-------|
| Categories phân trang | `keyword`, `pageNumber`, `pageSize` | `/api/categories/paged?keyword=da&pageNumber=1&pageSize=5` |
| Products phân trang | `keyword`, `categoryId`, `pageNumber`, `pageSize` | `/api/products/paged?categoryId=1&pageNumber=1&pageSize=5` |
| Customers phân trang | `keyword`, `pageNumber`, `pageSize` | `/api/customers/paged?keyword=090&pageNumber=1&pageSize=5` |
| Orders | `fromDate`, `toDate`, `pageNumber`, `pageSize` | `/api/orders?fromDate=2026-03-01&toDate=2026-03-31&pageNumber=1&pageSize=5` |
| Doanh thu theo giờ | `date` | `/api/reports/revenue-by-hour?date=2026-03-01` |
| Doanh thu từng ngày | `fromDate`, `toDate` | `/api/reports/revenue-by-day?fromDate=2026-03-01&toDate=2026-03-07` |
| Doanh thu thu ngân | `fromDate`, `toDate` tùy chọn | `/api/reports/revenue-by-cashier?fromDate=2026-03-01&toDate=2026-03-31` |
| Báo cáo nhanh | `fromDate`, `toDate` hoặc `date` | `/api/reports/quick-report?date=2026-03-01` |
| Lọc tồn ADO.NET | `minStock` | `/api/ado-products/filter-stock?minStock=10` |

Ngày trong query dùng dạng `yyyy-MM-dd`. Khi từ khóa chứa khoảng trắng hoặc dấu tiếng Việt, client mã hóa tham số bằng `Uri.EscapeDataString` trước khi gửi.

Các API phân trang danh mục, sản phẩm và khách hàng chuẩn hóa trang nhỏ hơn 1 về 1; kích thước trang mặc định là 5, tối đa theo quy tắc endpoint hiện tại là 50. API đơn hàng chấp nhận kích thước trang đến 100, còn giao diện đơn hàng dùng cố định 5. Một trang vượt số trang có dữ liệu có thể trả danh sách rỗng; cần đọc cả metadata của phản hồi.

Kết quả phân trang thường gồm `currentPage`, `pageSize`, `totalItems`, `totalPages`, `items`. Sản phẩm bổ sung `totalLowStockItems`, `lowStockThreshold`; đơn hàng bổ sung `totalRevenue` của toàn bộ kết quả lọc.

### Ví dụ JSON thêm sản phẩm

```json
{
  "barcode": "HANASHOP-DEMO-001",
  "productName": "Sản phẩm minh họa kiểm thử",
  "price": 85000,
  "stockQuantity": 10,
  "categoryId": 1
}
```

Ví dụ này cần token Admin và `categoryId` thực sự tồn tại. Nếu chạy lại với cùng mã vạch đã tạo, API trả lỗi trùng; có thể dùng một mã thử khác khi muốn tạo bản ghi mới. ID sản phẩm do database cấp, không giả định luôn bằng 1.

### Ví dụ JSON checkout có đổi điểm

Ví dụ sau minh họa sản phẩm giá **85.000 đ**, khách có ít nhất **20 điểm** và muốn đổi 20 điểm. Trước khi chạy, thay `productId`, số điện thoại và đơn giá cho đúng dữ liệu đang dùng:

```json
{
  "cashierUsername": "cashier01",
  "customerPhone": "0900000000",
  "cashReceived": 100000,
  "usePoints": true,
  "pointsToRedeem": 20,
  "items": [
    {
      "productId": 1,
      "quantity": 1,
      "unitPrice": 85000
    }
  ]
}
```

Với dữ liệu hợp lệ như giả định, tiền giảm là 20.000 đ, tiền thực thu là 65.000 đ và tiền khách đưa lớn hơn số phải trả. Server đối chiếu lại đơn giá thực tế, số dư điểm và tồn kho trước khi xác nhận giao dịch.

Để thử **thanh toán 0 đồng** cho cùng tiền hàng 85.000 đ, dùng khách có ít nhất 85 điểm, đổi `pointsToRedeem` thành `85` và `cashReceived` thành `0`. Khi không dùng điểm, gửi `usePoints: false`, `pointsToRedeem: 0`; tiền khách đưa vẫn phải đáp ứng quy tắc của tổng còn dương.

Phản hồi checkout thành công gồm mã đơn, ID đơn, tên khách, tổng số lượng, `subtotal`, `discountAmount`, `pointsRedeemed`, `finalAmount` và `rewardPointsAdded`. Khi bị từ chối, đọc `message` và `errorDetail` để biết nguyên nhân; không coi thông báo Rollback là một đơn đã thanh toán thành công.

### Các tình huống kiểm thử chức năng

| Nhóm | Thao tác kiểm thử | Kết quả cần đối chiếu |
|------|-------------------|-----------------------|
| Đăng nhập | Tài khoản đúng, mật khẩu đúng | Có token, Shell mở đúng vai trò |
| Đăng nhập | Sai mật khẩu hoặc tên tài khoản không có | Bị từ chối, không mở phiên mới |
| Tài khoản | Đăng nhập bằng tài khoản đã khóa | Bị từ chối ở API |
| Xác thực | Gọi endpoint bảo vệ khi chưa Authorize | Nhận 401 |
| Phân quyền | Cashier gọi API sửa/xóa khách hàng | Nhận 403 |
| Phân quyền | Warehouse gọi checkout hoặc báo cáo Admin | Nhận 403 |
| Danh mục | Xóa nhóm đang có sản phẩm | Bị từ chối theo ràng buộc |
| Sản phẩm | Thêm mã vạch trùng | Có thông báo xung đột |
| Sản phẩm | Giá bằng 0, giá âm hoặc tồn âm | Bị từ chối validation |
| Khách hàng | Đăng ký số điện thoại trùng | Không tạo hồ sơ thứ hai |
| Phân trang | Chuyển trang và tìm từ khóa mới | Dữ liệu đúng trang; tìm mới quay về trang 1 |
| Tải lại | Chọn dòng, sửa ô nhập rồi bấm Tải lại | Thông tin trống, bỏ chọn dòng, đặt lại tìm kiếm |
| Tồn kho | So sánh sản phẩm tồn 0, 1–10 và trên 10 | Trạng thái và màu dựa vào dữ liệu server |
| Tồn kho | Chuyển trang trong cùng bộ lọc | Tổng cảnh báo vẫn tính trên toàn bộ bộ lọc |
| POS | Quét sản phẩm nhiều lần | Tăng số lượng của dòng tương ứng |
| POS | Bán số lượng vượt tồn | Client chặn sớm hoặc API từ chối và Rollback |
| POS | Gửi giá khác giá trong database | Không ghi nhận giao dịch thành công |
| Đổi điểm | Bật đổi điểm nhưng nhập 0 điểm | Yêu cầu nhập số điểm lớn hơn 0 |
| Đổi điểm | Nhập vượt số dư hoặc tiền hàng | UI giới hạn; server từ chối request không hợp lệ |
| Đổi điểm | Đổi một số điểm khác 50 | Giảm đúng số điểm × 1.000 đ |
| Đổi điểm | Đổi đủ cho tổng về 0, tiền khách đưa 0 | Thanh toán được với dữ liệu hợp lệ |
| Đổi điểm | Tiền hàng có phần lẻ dưới 1.000 đ | Điểm tối đa lấy phần nguyên, vẫn còn phần tiền lẻ |
| Tiền khách đưa | Để trống, nhập chữ hoặc tiền âm | Không thanh toán |
| Tiền khách đưa | Tổng dương, nhập bằng đúng tổng | Bị chặn theo quy tắc hiện tại |
| Hủy đơn | Admin hủy hóa đơn đã đổi điểm | Tồn và số điểm đã đổi được hoàn; điểm cộng được điều chỉnh |
| Đơn hàng | Lọc khoảng ngày, chọn đơn, chuyển trang | Danh sách 5 đơn/trang và chi tiết đúng đơn |
| Báo cáo | Lọc đúng một ngày | Biểu đồ theo 24 giờ |
| Báo cáo | Lọc tuần, tháng, năm | Hai mốc ngày và số liệu đúng kỳ |
| Báo cáo | Chọn kỳ không có đơn | Tổng bằng 0, danh sách/biểu đồ thể hiện không có dữ liệu |
| Thu ngân | So sánh lọc ngày và toàn lịch sử | Mỗi chế độ tổng hợp theo đúng phạm vi |
| CSV | Mở file có tên sản phẩm tiếng Việt | Nội dung giữ dấu và các cột được phân tách phù hợp |

Bảng trên là các tình huống cần kiểm tra khi demo hoặc sau khi thay đổi chức năng. Khi thử checkout, hủy đơn hoặc CRUD, nên dùng database thử để có thể đối chiếu điểm, tồn kho và hóa đơn trước/sau một cách rõ ràng.

### Một số lỗi thường gặp khi chạy

| Hiện tượng | Phần cần kiểm tra |
|------------|--------------------|
| WinForms báo `connection refused` tại 7251 | API đã chạy chưa, profile có phải HTTPS không, máy chủ có dừng do lỗi khởi động không |
| Swagger không tự mở | Trạng thái API, `launchUrl: swagger`, môi trường Development; thử mở đúng URL sau khi API lắng nghe |
| Visual Studio báo lỗi khởi chạy | Đọc thông báo gốc và Output; phân biệt lỗi build với lỗi máy chủ chưa chạy |
| Windows báo Application Control chặn tệp | Kiểm tra chính sách cho tệp thực thi trên máy; sửa tên form hoặc JWT không giải quyết việc Windows chặn khởi chạy |
| Build không sao chép được `.exe` / `.dll` | Dừng phiên Debug hoặc ứng dụng đang giữ bản dựng rồi build lại |
| Lỗi đăng nhập SQL hoặc không thấy database | Tên SQL instance, kiểu xác thực, quyền truy cập và tên database trong chuỗi kết nối |
| Báo thiếu bảng hoặc thiếu `CreatedDate` | Database đang trỏ đúng chưa và đã áp dụng migration còn thiếu chưa |
| Báo không tìm thấy Stored Procedure | Chạy script trong Scripts trên đúng database sau bước migration |
| Các bảng trả lỗi 401 | Token đã gắn chưa; đăng nhập lại nếu phiên hết hạn |
| Một thao tác trả 403 | Đối chiếu vai trò với quyền của endpoint; không phải lỗi mất kết nối |
| Doanh thu theo ngày bị từ chối khoảng quá dài | API `revenue-by-day` hiện giới hạn độ chênh hai mốc tối đa 366 ngày |
| Checkout báo thiếu hoặc sai điểm đổi | Cả client và API phải là bản mới có `pointsToRedeem`; kiểm tra thêm `usePoints` và số dư |
| Báo cáo bằng 0 dù có dữ liệu mẫu | Chọn khoảng ngày chứa ngày hóa đơn mẫu; thẻ hôm nay và báo cáo lịch sử có phạm vi khác nhau |
| CSV mở một cột hoặc hiển thị khác vùng | Kiểm tra dấu phân cách vùng, cách mở/import file và mã hóa UTF-8 |

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

Các khối lệnh trong mục này dùng **PowerShell**. Tạo commit có tiêu đề và phần mô tả cụ thể. Ví dụ cho lần bổ sung nhập điểm và thanh toán 0 đồng:

```powershell
git commit -m "Buoi 6: nhập điểm muốn đổi và hỗ trợ thanh toán 0 đồng" -m "POS: thêm ô nhập điểm; giới hạn theo số dư và tiền hàng; cập nhật tiền giảm và tổng phải trả." -m "API: nhận pointsToRedeem, kiểm tra giới hạn trong transaction, cho cashReceived bằng 0 khi đổi hết tiền hàng và hoàn đúng điểm khi hủy đơn." -m "README: bổ sung chức năng, công nghệ, API, cách chạy, tình huống kiểm thử và quy trình Git."
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
git commit -m "Buoi 7: mô tả chức năng vừa bổ sung" -m "Ghi cụ thể màn hình hoặc API đã sửa, quy tắc mới và cách đã kiểm tra."
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
git commit -m "Buoi 7: mô tả lỗi vừa sửa" -m "Ghi điều kiện gây lỗi, hành vi sau khi sửa và phần đã kiểm tra lại."
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

### Quy trình ngắn cho mỗi lần làm xong

1. Lưu các file đã sửa trong Visual Studio.
2. Dừng chương trình và build lại các project bị ảnh hưởng.
3. Thử chức năng vừa thay đổi bằng dữ liệu phù hợp.
4. Cập nhật README nếu có thay đổi giao diện, API, quy tắc hoặc hướng dẫn chạy.
5. Xem nhánh và danh sách file thay đổi trước khi thêm vào staging.
6. Kiểm tra phần sẽ commit, viết mô tả rõ ràng rồi đẩy lên đúng nhánh.
7. Mở repository trên GitHub, chọn nhánh và kiểm tra commit mới đã xuất hiện.

```powershell
git branch --show-current
git status
git diff --stat
git add .
git diff --cached --stat
git diff --cached
git commit -m "Buoi 6: tên thay đổi cụ thể" -m "Mô tả chức năng, tệp hoặc API liên quan và kết quả kiểm tra."
git push
```

Đây là ví dụ quy trình; thay nội dung commit bằng phần thực sự vừa làm. `git add .` thêm các thay đổi trong thư mục hiện tại, vì vậy cần đọc `git status` và phần diff thay vì chỉ chạy liên tiếp các lệnh mà không xem danh sách file.

### Đưa riêng một số file vào commit

Nếu lần sửa chỉ liên quan POS, API checkout và tài liệu, có thể chọn đúng các file thay vì thêm toàn bộ thư mục:

```powershell
git add MiniSupermarket.WinForms/FormPOS.cs MiniSupermarket.WinForms/FormPOS.Designer.cs
git add MiniSupermarket.API/Controllers/OrdersController.cs MiniSupermarket.API/Models/CheckoutDtos.cs
git add README.md
git diff --cached --stat
```

`.gitignore` của dự án loại trừ các thư mục/tệp làm việc như `.vs`, `bin`, `obj` và thiết lập người dùng tương ứng. File báo cáo Word và ảnh minh họa phục vụ nộp bài được quản lý tại vị trí lưu báo cáo đã chọn, không cần chép vào source để tạo commit mã nguồn.

### Cách viết nội dung commit dễ đọc

| Thành phần | Nội dung nên ghi | Ví dụ |
|------------|------------------|-------|
| Tiêu đề | Buổi thực hành và thay đổi chính | `Buoi 6: nhập điểm muốn đổi và thanh toán 0 đồng` |
| Giao diện | Màn hình, nút hoặc ô nhập thay đổi | Thêm NumericUpDown nhập điểm trong Designer POS |
| API | Route, DTO và kiểm tra mới | Checkout nhận `pointsToRedeem`, chặn đổi vượt số dư |
| Nghiệp vụ | Trường hợp cụ thể và hành vi mới | Cho phép tiền khách đưa 0 khi tổng sau đổi điểm bằng 0 |
| Dữ liệu | Tác động cần biết | Trừ đúng điểm khi bán, hoàn đúng điểm khi hủy đơn |
| Kiểm tra | Những trường hợp đã thực sự thử | Đổi một phần, đổi hết, vượt giới hạn và hủy hóa đơn |

Một commit có thể có nhiều đoạn mô tả bằng cách thêm nhiều tham số `-m`. Các ví dụ ở trên ghi chuỗi trực tiếp trong dấu ngoặc kép; nội dung truyền vào `-m` chính là nội dung sẽ hiển thị trên GitHub.

### Kiểm tra sau khi push và khi gặp lỗi Git

```powershell
git status
git log -3 --oneline
git branch -vv
git remote -v
```

* **`nothing to commit, working tree clean`:** hiện không có thay đổi mới để tạo commit; xem log để biết mốc đã lưu gần nhất.
* **Nhánh đã tồn tại:** dùng `git checkout TEN-NHANH`, không tiếp tục tạo lại bằng `-b`.
* **Chưa có upstream:** dùng `git push -u origin TEN-NHANH` cho lần đẩy đầu của nhánh đó.
* **Push bị từ chối vì remote có commit mới:** kiểm tra lịch sử hai bên và đồng bộ trước; không dùng đẩy cưỡng bức như một bước thường lệ.
* **Có xung đột khi đồng bộ:** mở các file xung đột, giải quyết nội dung và hoàn tất thao tác Git đang thực hiện trước khi push tiếp.
* **Muốn đổi tên commit đã xuất hiện ở nhánh khác hoặc đã merge:** việc đó liên quan lịch sử của từng nhánh; sửa tên ở một nhánh không tự đổi commit cũ đã nằm trong nhánh khác.

Việc tạo commit trên `Buoi-6` không tự gộp thay đổi vào `main`. Nếu quy trình nộp bài cần cập nhật `main`, mở Pull Request trên GitHub với nhánh nguồn là nhánh buổi học, kiểm tra nội dung và thực hiện merge theo quy trình repository.

**Repository:** [MiniSupermarket_NguyenLeTanPhuc trên GitHub](https://github.com/phuc1910/MiniSupermarket_NguyenLeTanPhuc)

---

## 👨‍💻 9. Tác giả
* **Họ tên sinh viên:** Nguyễn Lê Tấn Phúc
* **Mã sinh viên:** 2124110108
* **Lớp học phần:** CCQ2411D
