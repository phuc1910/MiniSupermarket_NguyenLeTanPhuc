# 🛒 HỆ THỐNG QUẢN LÝ SIÊU THỊ MINI (MINISUPERMARKET SYSTEM)
> **Môn học:** Lập trình Ứng dụng .NET Core (Mã môn: 229162)  
> **Nội dung thực hành:**
> - **Buổi 1:** Xây dựng Web API quản lý danh mục và kết nối WinForms Client (CRUD)
> - **Buổi 2:** Bảo mật & Phân quyền JWT cho Web API và WinForms Client

---

## 🏗️ 1. Mô hình Kiến trúc Hệ thống (Client - Server)
Dự án được xây dựng theo mô hình phân tầng hiện đại, tách biệt hoàn toàn giữa Backend và Frontend:
* **`MiniSupermarket.API` (Backend):** Dự án ASP.NET Core Web API xử lý logic nghiệp vụ, quản lý dữ liệu, cung cấp các RESTful API chuẩn hóa, đồng thời cấp phát và xác thực JWT Token.
* **`MiniSupermarket.WinForms` (Frontend Client):** Ứng dụng Windows Forms đóng vai trò máy trạm POS tại quầy, có màn hình đăng nhập, lưu Token và đính kèm `Bearer Token` khi dùng `HttpClient` gọi API, hiển thị dữ liệu trực quan lên `DataGridView`.

---

## 🛠️ 2. Công nghệ Sử dụng
* **Ngôn ngữ:** C# (.NET 8.0)
* **Backend:** ASP.NET Core Web API, Controllers, In-Memory Data, LINQ
* **Bảo mật:** JWT Bearer Authentication, `[Authorize]`, phân quyền theo Role (Admin / Cashier)
* **Frontend:** Windows Forms (.NET 8.0), `System.Net.Http.Json`
* **Công cụ kiểm thử:** Swagger UI

---

## 📂 3. Cấu trúc Solution
```text
MiniSupermarketSystem/
│
├── MiniSupermarket.API/              # Dự án Web API (Backend)
│   ├── Controllers/
│   │   ├── AuthController.cs         # Đăng nhập, cấp phát JWT Token (Buổi 2)
│   │   └── CategoriesController.cs   # CRUD & Search (Buổi 1), bảo vệ bằng [Authorize] (Buổi 2)
│   ├── Models/                       # Lớp thực thể Category.cs
│   └── Program.cs                    # Cấu hình dịch vụ, JwtBearer, Swagger, Middleware
│
└── MiniSupermarket.WinForms/         # Dự án Windows Forms (Frontend Client)
    ├── FormLogin.cs                  # Giao diện đăng nhập (Buổi 2)
    ├── SessionManager.cs             # Lưu JWT Token và Role của phiên làm việc (Buổi 2)
    └── FormCategoryManagement.cs     # Quản lý danh mục CRUD (gọi API kèm Token)
```

---

## 🔐 4. Tài khoản Thử nghiệm và Phân quyền (Buổi 2)

| Tài khoản | Mật khẩu | Vai trò |
|-----------|----------|---------|
| `admin`   | `123456` | Admin   |
| `cashier` | `123456` | Cashier |

| Endpoint | Quyền truy cập |
|----------|----------------|
| `POST /api/auth/login` | Công khai |
| `GET /api/categories` (và các CRUD khác) | Phải đăng nhập (chưa đăng nhập → **401**) |
| `GET /api/categories/staff-pos` | Admin, Cashier |
| `GET /api/categories/admin-dashboard` | Chỉ Admin (Cashier gọi → **403**) |

---

## 🚀 5. Hướng dẫn Chạy và Kiểm thử Dự án

### Bước 1: Chạy phía Backend (Web API)
1. Mở Solution bằng Visual Studio 2022.
2. Nhấp chuột phải project `MiniSupermarket.API` chọn **Set as Startup Project**.
3. Nhấn **F5** để chạy. Trình duyệt sẽ tự động mở Swagger UI để kiểm tra các phương thức GET, POST, PUT, DELETE.
4. Gọi `POST /api/auth/login` để lấy token, bấm **Authorize** và dán token để thử các endpoint được bảo vệ.

### Bước 2: Chạy phía Frontend (WinForms Client)
1. Đảm bảo cổng (Port) trong `HttpClient` của WinForms khớp với cổng `https://localhost:XXXXX` của Web API đang chạy.
2. Nhấp chuột phải project `MiniSupermarket.WinForms` chọn **Debug -> Start new instance**.
3. Đăng nhập bằng `admin` hoặc `cashier`, sau đó thử các chức năng: Tải danh sách, Thêm mới, Sửa, Xóa và Tìm kiếm nhóm hàng.

---

## 👨‍💻 6. Tác giả
* **Họ tên sinh viên:** Nguyễn Lê Tấn Phúc
* **Mã sinh viên:** 2124110108
* **Lớp học phần:** CCQ2411D
