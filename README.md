# 🛒 HỆ THỐNG QUẢN LÝ SIÊU THỊ MINI (MINISUPERMARKET SYSTEM)
> **Đề tài:** Xây dựng Ứng dụng Quản lý Cửa hàng Tiện lợi với ASP.NET Core và Windows Forms — Tiệm Tạp hóa Mỹ phẩm Xách tay Hana Shop  
> **Môn học:** Lập trình Ứng dụng .NET Core (Mã môn: 229162)  
> **Nội dung thực hành:**
> - **Buổi 1:** Xây dựng Web API quản lý danh mục và kết nối WinForms Client (CRUD)
> - **Buổi 2:** Bảo mật & Phân quyền JWT cho Web API và WinForms Client
> - **Buổi 3:** Tích hợp SQL Server và Entity Framework Core Code-First
> - **Buổi 4:** Giao diện Shell hợp nhất, phân quyền 3 cấp (Admin / Cashier / Warehouse), đăng nhập và quản trị tài khoản bằng bảng `Users` thật, quản lý Sản phẩm

---

## 🏗️ 1. Mô hình Kiến trúc Hệ thống (Client - Server)
Dự án được xây dựng theo mô hình phân tầng hiện đại, tách biệt hoàn toàn giữa Backend và Frontend:
* **`MiniSupermarket.API` (Backend):** Dự án ASP.NET Core Web API xử lý logic nghiệp vụ, kết nối **SQL Server** qua **Entity Framework Core**, cung cấp các RESTful API chuẩn hóa, xác thực người dùng bằng bảng `Users` trong cơ sở dữ liệu và cấp phát JWT Token.
* **`MiniSupermarket.WinForms` (Frontend Client):** Ứng dụng Windows Forms với **giao diện Shell hợp nhất** (Sidebar + vùng nội dung động) đóng vai trò máy trạm POS tại quầy, có màn hình đăng nhập, lưu Token và đính kèm `Bearer Token` khi dùng `HttpClient` gọi API.

---

## 🛠️ 2. Công nghệ Sử dụng
* **Ngôn ngữ:** C# (.NET 8.0)
* **Backend:** ASP.NET Core Web API, Entity Framework Core Code-First, LINQ bất đồng bộ (async/await)
* **Cơ sở dữ liệu:** Microsoft SQL Server (`TanPhucMiniSupermarketDb`)
* **Bảo mật:** JWT Bearer Authentication, `[Authorize]`, phân quyền theo Role (Admin / Cashier / Warehouse), xác thực tài khoản qua bảng `Users` trong CSDL
* **Frontend:** Windows Forms (.NET 8.0), `System.Net.Http.Json`, kiến trúc Single-Form Shell (nhúng Form con động)
* **Công cụ kiểm thử:** Swagger UI, SQL Server Management Studio (SSMS)

---

## 📂 3. Cấu trúc Solution
```text
MiniSupermarketSystem/
│
├── MiniSupermarket.API/                 # Dự án Web API (Backend)
│   ├── Controllers/
│   │   ├── AuthController.cs            # Đăng nhập, cấp phát JWT Token — xác thực qua bảng Users (Buổi 4)
│   │   ├── UsersController.cs           # CRUD tài khoản, quản trị phân quyền (Buổi 4)
│   │   ├── CategoriesController.cs      # CRUD & Search Nhóm hàng (Buổi 1), EF Core (Buổi 3), [Authorize] (Buổi 2)
│   │   ├── ProductsController.cs        # CRUD & tra cứu Sản phẩm, liên kết Category (Buổi 4)
│   │   └── CustomersController.cs       # CRUD & Search Khách hàng thân thiết (Bài tập mở rộng Buổi 3)
│   ├── Models/
│   │   ├── Category.cs                  # Thực thể Nhóm hàng
│   │   ├── Product.cs                   # Thực thể Sản phẩm
│   │   ├── Customer.cs                  # Thực thể Khách hàng (hạng thẻ, điểm tích lũy)
│   │   └── User.cs                      # Thực thể Tài khoản nhân viên (Username, Password, Role) (Buổi 4)
│   ├── Data/
│   │   └── SupermarketDbContext.cs      # DbContext, seed dữ liệu mẫu (Category, Product, Customer, User)
│   ├── Migrations/                      # Lịch sử Migrations EF Core
│   └── Program.cs                       # Cấu hình DbContext, JwtBearer, Swagger, Middleware
│
└── MiniSupermarket.WinForms/             # Dự án Windows Forms (Frontend Client)
    ├── FormLogin.cs                      # Giao diện đăng nhập, xác thực qua API /auth/login (Buổi 2, 4)
    ├── SessionManager.cs                 # Lưu JWT Token, Username và Role của phiên làm việc
    ├── FormMainShell.cs                  # Khung giao diện chính: Sidebar + nhúng Form động (Buổi 4)
    ├── FormCategoryManagement.cs         # Quản lý danh mục CRUD (gọi API kèm Token)
    ├── FormCustomerManagement.cs         # Quản lý khách hàng thân thiết (Bài tập mở rộng Buổi 3)
    ├── FormProductManagement.cs          # Quản lý sản phẩm & tồn kho, lọc theo nhóm hàng (Buổi 4)
    └── FormUserManagement.cs             # Quản trị tài khoản nhân viên, chỉ dành cho Admin (Buổi 4)
```

---

## 🔐 4. Xác thực và Phân quyền

Khác với Buổi 2 (tài khoản hard-code trong code), từ Buổi 4 hệ thống xác thực bằng **bảng `Users` lưu trong SQL Server**: `AuthController` truy vấn `Users` để kiểm tra tài khoản/mật khẩu trước khi cấp JWT Token, và `UsersController` cho phép Admin tạo mới/quản lý tài khoản nhân viên ngay trên ứng dụng — không cần sửa code mỗi khi thêm nhân viên.

| Endpoint | Quyền truy cập |
|----------|----------------|
| `POST /api/auth/login` | Công khai |
| `GET /api/categories`, `GET /api/products` (và các CRUD khác) | Phải đăng nhập (chưa đăng nhập → **401**) |
| `GET /api/users` | Chỉ Admin |
| `POST /api/users` | Chỉ Admin — tạo tài khoản nhân viên mới |

### Phân quyền giao diện trên WinForms Shell

| Vai trò | Màn hình mặc định | Các màn hình được phép truy cập |
|---------|---------------------|----------------------------------|
| Admin | Quản lý Danh mục | Bán hàng (POS), Danh mục, Sản phẩm, Khách hàng, Báo cáo Doanh thu, Quản trị Tài khoản |
| Cashier | Bán hàng (POS) | Bán hàng (POS), Khách hàng |
| Warehouse | Quản lý Sản phẩm | Danh mục, Sản phẩm |

---

## 🗄️ 5. Cơ sở dữ liệu `TanPhucMiniSupermarketDb`

| Bảng | Mô tả |
|------|-------|
| `Categories` | Nhóm hàng mỹ phẩm (Trang điểm, Chăm sóc da, Chăm sóc tóc & cơ thể, Nước hoa, Thực phẩm chức năng) |
| `Products` | Sản phẩm, liên kết khóa ngoại tới `Categories`, có mã vạch (Barcode) và số lượng tồn kho |
| `Customers` | Khách hàng thân thiết: tên, số điện thoại, địa chỉ, hạng thẻ, điểm tích lũy |
| `Users` | Tài khoản nhân viên: tên đăng nhập, mật khẩu, họ tên, vai trò (Admin/Cashier/Warehouse) |

Chuỗi kết nối cấu hình tại `appsettings.json`, cơ sở dữ liệu được khởi tạo bằng EF Core Migrations (`Add-Migration`, `Update-Database`), không cần viết `CREATE TABLE` thủ công.

---

## 🖥️ 6. Giao diện Shell hợp nhất

Toàn bộ nghiệp vụ được điều hướng trong **một Form chính (`FormMainShell`)** thay vì mở nhiều cửa sổ rời rạc:

* **Sidebar bên trái:** chỉ hiển thị nút tương ứng với vai trò đang đăng nhập; nút đang chọn được làm nổi bật màu khác.
* **Vùng nội dung chính:** nhúng động Form nghiệp vụ (`TopLevel = false`, `Dock = Fill`).
* **Bảo vệ 2 lớp:** một số chức năng (Báo cáo Doanh thu, Quản trị Tài khoản) vừa bị ẩn khỏi Sidebar theo vai trò, vừa được kiểm tra lại quyền ngay trong xử lý sự kiện.

---

## 🚀 7. Hướng dẫn Chạy và Kiểm thử Dự án

### Yêu cầu hệ thống
* Visual Studio 2022 (cài workload **ASP.NET and web development** và **.NET desktop development**)
* .NET 8.0 SDK
* SQL Server (LocalDB, Express hoặc bản đầy đủ đều được)

### Cấu hình chuỗi kết nối
Mở `appsettings.json` trong project `MiniSupermarket.API`, kiểm tra/sửa lại cho khớp với SQL Server trên máy bạn:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=TanPhucMiniSupermarketDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

Nếu dùng SQL Express, đổi `Server=localhost` thành `Server=.\SQLEXPRESS`. Nếu đăng nhập bằng tài khoản `sa`, thay cụm `Trusted_Connection=True` bằng `User Id=sa;Password=<mật khẩu của bạn>`.

### Bước 1: Chạy phía Backend (Web API)
1. Mở Solution bằng Visual Studio 2022.
2. Mở **Package Manager Console**, chọn Default project là `MiniSupermarket.API`, chạy `Update-Database` để khởi tạo `TanPhucMiniSupermarketDb` (nếu chưa có) — bước này sẽ tạo luôn bảng `Users` kèm tài khoản mẫu.
3. Nhấp chuột phải project `MiniSupermarket.API` chọn **Set as Startup Project**, nhấn **F5**.
4. Gọi `POST /api/auth/login` để lấy token, đính kèm token vào header `Authorization: Bearer <token>` để thử các endpoint Categories, Products, Customers, Users.

> ⚠️ Swagger mặc định **không có sẵn nút Authorize**. Cách xử lý: dùng extension **ModHeader** trên Chrome để tự động thêm header `Authorization: Bearer <token>` vào mỗi request khi test trên Swagger UI.

### Bước 2: Chạy phía Frontend (WinForms Client)
1. Đảm bảo cổng (Port) trong `HttpClient` của WinForms khớp với cổng `https://localhost:XXXXX` của Web API đang chạy.
2. Nhấp chuột phải project `MiniSupermarket.WinForms` chọn **Debug -> Start new instance**.
3. Đăng nhập bằng các tài khoản có vai trò khác nhau (lấy từ bảng `Users` trong SQL Server) để kiểm tra Sidebar hiển thị đúng chức năng theo từng vai trò.
4. Thử nghiệm Danh mục, Sản phẩm, Khách hàng: Tải danh sách, Thêm, Sửa, Xóa, Tìm kiếm.
5. Với tài khoản Admin, thử tạo tài khoản nhân viên mới trong màn hình Quản trị Tài khoản.
6. Tắt cả hai ứng dụng rồi mở lại — dữ liệu vẫn còn nguyên vì đã lưu trên SQL Server.

---

## ✅ 8. Tiến độ đã hoàn thành
* **Phân hệ Khách hàng thân thiết (Buổi 3):** CRUD và tìm kiếm khép kín từ Backend đến WinForms.
* **Giao diện Shell phân quyền 3 cấp (Buổi 4):** điều hướng động, ẩn/hiện chức năng và bảo vệ 2 lớp theo vai trò Admin / Cashier / Warehouse.
* **Đăng nhập bằng bảng `Users` thật (Buổi 4):** thay thế hoàn toàn tài khoản hard-code bằng dữ liệu trong SQL Server.
* **`UsersController` và `ProductsController` (Buổi 4):** API quản lý tài khoản và sản phẩm, có truy vấn và xác thực dữ liệu từ CSDL.

---

## 👨‍💻 9. Tác giả
* **Họ tên sinh viên:** Nguyễn Lê Tấn Phúc
* **Mã sinh viên:** 2124110108
* **Lớp học phần:** CCQ2411D
