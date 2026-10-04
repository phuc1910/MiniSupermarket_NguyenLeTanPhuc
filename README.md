# 🛒 HỆ THỐNG QUẢN LÝ SIÊU THỊ MINI (MINISUPERMARKET SYSTEM)
> **Đề tài:** Xây dựng Ứng dụng Quản lý Cửa hàng Tiện lợi với ASP.NET Core và Windows Forms — Tiệm Tạp hóa Mỹ phẩm Xách tay Hana Shop  
> **Môn học:** Lập trình Ứng dụng .NET Core (Mã môn: 229162)  
> **Nội dung thực hành:**
> - **Buổi 1:** Xây dựng Web API quản lý danh mục và kết nối WinForms Client (CRUD)
> - **Buổi 2:** Bảo mật & Phân quyền JWT cho Web API và WinForms Client
> - **Buổi 3:** Tích hợp SQL Server và Entity Framework Core Code-First

---

## 🏗️ 1. Mô hình Kiến trúc Hệ thống (Client - Server)
Dự án được xây dựng theo mô hình phân tầng hiện đại, tách biệt hoàn toàn giữa Backend và Frontend:
* **`MiniSupermarket.API` (Backend):** Dự án ASP.NET Core Web API xử lý logic nghiệp vụ, kết nối **SQL Server** qua **Entity Framework Core**, cung cấp các RESTful API chuẩn hóa, đồng thời cấp phát và xác thực JWT Token.
* **`MiniSupermarket.WinForms` (Frontend Client):** Ứng dụng Windows Forms đóng vai trò máy trạm POS tại quầy, có màn hình đăng nhập, lưu Token và đính kèm `Bearer Token` khi dùng `HttpClient` gọi API, hiển thị dữ liệu trực quan lên `DataGridView`.

---

## 🛠️ 2. Công nghệ Sử dụng
* **Ngôn ngữ:** C# (.NET 8.0)
* **Backend:** ASP.NET Core Web API, Entity Framework Core Code-First, LINQ bất đồng bộ (async/await)
* **Cơ sở dữ liệu:** Microsoft SQL Server (`TanPhucMiniSupermarketDb`)
* **Bảo mật:** JWT Bearer Authentication, `[Authorize]`, phân quyền theo Role (Admin / Cashier)
* **Frontend:** Windows Forms (.NET 8.0), `System.Net.Http.Json`
* **Công cụ kiểm thử:** Swagger UI, SQL Server Management Studio (SSMS)

---

## 📂 3. Cấu trúc Solution
```text
MiniSupermarketSystem/
│
├── MiniSupermarket.API/                 # Dự án Web API (Backend)
│   ├── Controllers/
│   │   ├── AuthController.cs            # Đăng nhập, cấp phát JWT Token (Buổi 2)
│   │   ├── CategoriesController.cs      # CRUD & Search Nhóm hàng (Buổi 1), EF Core (Buổi 3), [Authorize] (Buổi 2)
│   │   └── CustomersController.cs       # CRUD & Search Khách hàng thân thiết (Bài tập mở rộng Buổi 3)
│   ├── Models/
│   │   ├── Category.cs                  # Thực thể Nhóm hàng
│   │   ├── Product.cs                   # Thực thể Sản phẩm
│   │   └── Customer.cs                  # Thực thể Khách hàng (hạng thẻ, điểm tích lũy)
│   ├── Data/
│   │   └── SupermarketDbContext.cs      # DbContext, seed dữ liệu mẫu (Buổi 3)
│   ├── Migrations/                      # Lịch sử Migrations EF Core (Buổi 3)
│   └── Program.cs                       # Cấu hình DbContext, JwtBearer, Swagger, Middleware
│
└── MiniSupermarket.WinForms/             # Dự án Windows Forms (Frontend Client)
    ├── FormLogin.cs                      # Giao diện đăng nhập (Buổi 2)
    ├── SessionManager.cs                 # Lưu JWT Token và Role của phiên làm việc (Buổi 2)
    ├── FormCategoryManagement.cs         # Quản lý danh mục CRUD (gọi API kèm Token)
    └── FormCustomerManagement.cs         # Quản lý khách hàng thân thiết (Bài tập mở rộng Buổi 3)
```

---

## 🔐 4. Tài khoản Thử nghiệm và Phân quyền (Buổi 2)

| Tài khoản | Mật khẩu | Vai trò |
|-----------|----------|---------|
| `admin`   | `123456` | Admin   |
| `cashier` | `123456` | Cashier |

> Đây là tài khoản demo hard-code phục vụ học tập, không phải thông tin đăng nhập thật.

| Endpoint | Quyền truy cập |
|----------|----------------|
| `POST /api/auth/login` | Công khai |
| `GET /api/categories` (và các CRUD khác) | Phải đăng nhập (chưa đăng nhập → **401**) |
| `GET /api/categories/staff-pos` | Admin, Cashier |
| `GET /api/categories/admin-dashboard` | Chỉ Admin (Cashier gọi → **403**) |

---

## 🗄️ 5. Cơ sở dữ liệu `TanPhucMiniSupermarketDb` (Buổi 3)

| Bảng | Mô tả |
|------|-------|
| `Categories` | Nhóm hàng mỹ phẩm (Trang điểm, Chăm sóc da, Chăm sóc tóc & cơ thể, Nước hoa, Thực phẩm chức năng) |
| `Products` | Sản phẩm, liên kết khóa ngoại tới `Categories` |
| `Customers` | Khách hàng thân thiết: tên, số điện thoại, địa chỉ, hạng thẻ, điểm tích lũy |

Chuỗi kết nối cấu hình tại `appsettings.json`, cơ sở dữ liệu được khởi tạo bằng EF Core Migrations (`Add-Migration`, `Update-Database`), không cần viết `CREATE TABLE` thủ công.

---

## 🚀 6. Hướng dẫn Chạy và Kiểm thử Dự án

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
2. Mở **Package Manager Console**, chọn Default project là `MiniSupermarket.API`, chạy `Update-Database` để khởi tạo `TanPhucMiniSupermarketDb` (nếu chưa có).
3. Nhấp chuột phải project `MiniSupermarket.API` chọn **Set as Startup Project**.
4. Nhấn **F5** để chạy. Trình duyệt sẽ tự động mở Swagger UI để kiểm tra các phương thức GET, POST, PUT, DELETE.
5. Gọi `POST /api/auth/login` để lấy token, sau đó đính kèm token vào header `Authorization: Bearer <token>` để thử các endpoint Categories và Customers.

> ⚠️ Swagger mặc định **không có sẵn nút Authorize**. Cách xử lý: dùng extension **ModHeader** trên Chrome để tự động thêm header `Authorization: Bearer <token>` vào mỗi request khi test trên Swagger UI.

### Bước 2: Chạy phía Frontend (WinForms Client)
1. Đảm bảo cổng (Port) trong `HttpClient` của WinForms khớp với cổng `https://localhost:XXXXX` của Web API đang chạy.
2. Nhấp chuột phải project `MiniSupermarket.WinForms` chọn **Debug -> Start new instance**.
3. Đăng nhập bằng `admin` hoặc `cashier`.
4. Thử nghiệm Nhóm hàng: Tải danh sách, Thêm, Sửa, Xóa, Tìm kiếm.
5. Thử nghiệm Khách hàng: Tải danh sách, Thêm, Sửa, Xóa, Tìm kiếm theo tên hoặc số điện thoại.
6. Tắt cả hai ứng dụng rồi mở lại — dữ liệu vẫn còn nguyên vì đã lưu trên SQL Server (khác Buổi 1: mất dữ liệu khi tắt API).

---

## ✅ 7. Bài tập mở rộng đã hoàn thành
* **Phân hệ Khách hàng thân thiết (Buổi 3):** `Customer.cs`, `CustomersController.cs`, `FormCustomerManagement.cs` — CRUD và tìm kiếm khép kín từ Backend đến WinForms, theo đúng kiến trúc của phân hệ Nhóm hàng.

---

## 👨‍💻 8. Tác giả
* **Họ tên sinh viên:** Nguyễn Lê Tấn Phúc
* **Mã sinh viên:** 2124110108
* **Lớp học phần:** CCQ2411D
