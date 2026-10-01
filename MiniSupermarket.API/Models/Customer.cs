using System.ComponentModel.DataAnnotations; // Validation dữ liệu
using System.ComponentModel.DataAnnotations.Schema; // Cấu hình Database

namespace MiniSupermarket.API.Models
{
    [Table("Customers")] // Tên bảng trong SQL Server
    public class Customer
    {
        [Key] // Khóa chính
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // ID tự tăng
        public int CustomerId { get; set; } // ID khách hàng

        [Required(ErrorMessage = "Tên khách hàng không được để trống!")] // Bắt buộc nhập
        [StringLength(100)] // Tối đa 100 ký tự
        public string CustomerName { get; set; } = string.Empty; // Tên khách hàng

        [Required(ErrorMessage = "Số điện thoại không được để trống!")] // Bắt buộc nhập
        [StringLength(15)] // Tối đa 15 ký tự
        public string PhoneNumber { get; set; } = string.Empty; // Số điện thoại

        [StringLength(200)] // Tối đa 200 ký tự
        public string? Address { get; set; } // Địa chỉ, có thể trống

        public int RewardPoints { get; set; } = 0; // Điểm tích lũy, mặc định 0

        [StringLength(50)] // Tối đa 50 ký tự
        public string MembershipRank { get; set; } = "Chuẩn"; // Hạng thành viên
    }
}
