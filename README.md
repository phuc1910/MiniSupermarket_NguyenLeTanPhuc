# 💄 HANA SHOP - TIỆM TẠP HÓA MỸ PHẨM XÁCH TAY
> **Môn học:** Lập trình Ứng dụng .NET Core (Mã môn: 229162)  
> **Buổi thực hành:** Buổi 3 - Tích hợp SQL Server và Entity Framework Core Code-First

---

## 🏗️ 1. Mô hình Kiến trúc Hệ thống (Client - Server)
Dự án được xây dựng theo mô hình phân tầng hiện đại, tách biệt hoàn toàn giữa Backend và Frontend:
* **`MiniSupermarket.API` (Backend):** Dự án ASP.NET Core Web API xử lý nghiệp vụ, kết nối **SQL Server** qua **Entity Framework Core**, bảo mật bằng JWT.
* **`MiniSupermarket.WinForms` (Frontend Client):** Ứng dụng Windows Forms, có màn hình đăng nhập, gọi API qua `HttpClient` kèm Bearer Token.

---

## 🛠️ 2. Công nghệ Sử dụng
* **Ngôn ngữ:** C# (.NET 8.0)
* **Backend:** ASP.NET Core Web API, Entity Framework Core Code-First, LINQ bất đồng bộ (async/await)
* **Cơ sở dữ liệu:** Microsoft SQL Server (`HanaShopDb`)
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
│   │   ├── AuthController.cs            # Đăng nhập, cấp phát JWT Token
│   │   ├── CategoriesController.cs      # CRUD & Search Nhóm hàng dùng EF Core, [Authorize]
│   │   └── CustomersController.cs       # CRUD & Search Khách hàng thân thiết (Bài tập mở rộng)
│   ├── Models/
│   │   ├── Category.cs                  # Thực thể Nhóm hàng
│   │   ├── Product.cs                   # Thực thể Sản phẩm (có Origin, ExpiryDate)
│   │   └── Customer.cs                  # Thực thể Khách hàng (hạng thẻ, điểm tích lũy)
│   ├── Data/
│   │   └── SupermarketDbContext.cs      # DbContext, seed dữ liệu mẫu
│   ├── Migrations/                      # Lịch sử Migrations EF Core
│   └── Program.cs                       # Cấu hình DbContext, JwtBearer, Swagger
│
└── MiniSupermarket.WinForms/             # Dự án Windows Forms (Frontend Client)
    ├── FormLogin.cs                      # Giao diện đăng nhập
    ├── SessionManager.cs                 # Lưu JWT Token và Role của phiên làm việc
    ├── FormCategoryManagement.cs         # Quản lý danh mục CRUD (gọi API kèm Token)
    └── FormCustomerManagement.cs         # Quản lý khách hàng thân thiết (Bài tập mở rộng)
```

---

## 🗄️ 4. Cơ sở dữ liệu `HanaShopDb`

| Bảng | Mô tả |
|------|-------|
| `Categories` | Nhóm hàng mỹ phẩm (Trang điểm, Chăm sóc da, Chăm sóc tóc & cơ thể, Nước hoa, Thực phẩm chức năng) |
| `Products` | Sản phẩm, liên kết khóa ngoại tới `Categories`, có thêm `Origin` (xuất xứ) và `ExpiryDate` (hạn sử dụng) |
| `Customers` | Khách hàng thân thiết: tên, số điện thoại, địa chỉ, hạng thẻ, điểm tích lũy |

Chuỗi kết nối cấu hình tại `appsettings.json`, cơ sở dữ liệu được khởi tạo bằng EF Core Migrations (`Add-Migration`, `Update-Database`), không cần viết `CREATE TABLE` thủ công.

---

## 🚀 5. Hướng dẫn Chạy và Kiểm thử Dự án
**Bước 1: Chạy phía Backend (Web API)**
1. Mở Solution bằng Visual Studio 2022.
2. Mở **Package Manager Console**, chọn Default project là `MiniSupermarket.API`, chạy `Update-Database` để khởi tạo `HanaShopDb` (nếu chưa có).
3. Nhấp chuột phải project `MiniSupermarket.API` chọn **Set as Startup Project**, nhấn **F5**.
4. Trên Swagger UI, đăng nhập lấy token, bấm **Authorize**, dán token để thử các endpoint Categories và Customers.

**Bước 2: Chạy phía Frontend (WinForms Client)**
1. Đảm bảo cổng (Port) trong `HttpClient` của WinForms khớp với cổng `https://localhost:XXXXX` của Web API đang chạy.
2. Nhấp chuột phải project `MiniSupermarket.WinForms` chọn **Debug -> Start new instance**.
3. Đăng nhập bằng `admin` hoặc `cashier`.
4. Thử nghiệm Nhóm hàng: Tải danh sách, Thêm, Sửa, Xóa, Tìm kiếm.
5. Thử nghiệm Khách hàng: Tải danh sách, Thêm, Sửa, Xóa, Tìm kiếm theo tên hoặc số điện thoại.
6. Tắt cả hai ứng dụng rồi mở lại — dữ liệu vẫn còn nguyên vì đã lưu trên SQL Server (khác Buổi 1: mất dữ liệu khi tắt API).

---

## ✅ 6. Bài tập mở rộng đã hoàn thành
* **Phân hệ Khách hàng thân thiết:** `Customer.cs`, `CustomersController.cs`, `FormCustomerManagement.cs` — CRUD và tìm kiếm khép kín từ Backend đến WinForms, theo đúng kiến trúc của phân hệ Nhóm hàng.

---

## 👨‍💻 7. Tác giả
* **Họ tên sinh viên:** [Điền tên của bạn vào đây]
* **Mã sinh viên:** [Điền MSSV]
* **Lớp học phần:** [Điền tên lớp]
