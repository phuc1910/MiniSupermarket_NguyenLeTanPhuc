// Import các thuộc tính dùng để khai báo validation cho Model
using System.ComponentModel.DataAnnotations;

// Import các thuộc tính dùng để cấu hình ánh xạ giữa Model và Database
using System.ComponentModel.DataAnnotations.Schema;

// Namespace chứa các Model của hệ thống MiniSupermarket
namespace MiniSupermarket.API.Models
{
    // Chỉ định class User sẽ được ánh xạ tới bảng "Users" trong Database
    [Table("Users")]
    public class User
    {
        // Đánh dấu UserId là khóa chính (Primary Key)
        [Key]

        // Cho biết UserId được Database tự động tăng (Identity)
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        // Bắt buộc phải có tên tài khoản đăng nhập
        // Độ dài tối đa là 50 ký tự
        [Required]
        [StringLength(50)]
        public string Username { get; set; } = string.Empty;

        // Bắt buộc phải có mật khẩu đã được băm (Hash)
        // Không lưu mật khẩu dạng văn bản thuần
        // Không khai báo StringLength vì trường PasswordHash có thể chứa chuỗi băm dài
        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        // Bắt buộc phải có họ và tên nhân viên
        // Độ dài tối đa là 100 ký tự
        [Required]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        // Bắt buộc phải có vai trò của nhân viên trong hệ thống
        // Ví dụ: Admin, Cashier, Warehouse
        // Độ dài tối đa là 50 ký tự
        [Required]
        [StringLength(50)]
        public string Role { get; set; } = string.Empty;

        // Trạng thái hoạt động của tài khoản
        // true (1): Tài khoản đang hoạt động
        // false (0): Tài khoản bị khóa hoặc ngừng hoạt động
        // Giá trị mặc định khi khởi tạo đối tượng là true
        public bool IsActive { get; set; } = true;
    }
}