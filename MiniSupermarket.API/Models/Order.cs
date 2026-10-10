// Import các thuộc tính dùng để khai báo validation cho Model
using System.ComponentModel.DataAnnotations;

// Import các thuộc tính dùng để cấu hình ánh xạ giữa Model và Database
using System.ComponentModel.DataAnnotations.Schema;

// Namespace chứa các Model của hệ thống MiniSupermarket
namespace MiniSupermarket.API.Models
{
    // Chỉ định class Order sẽ được ánh xạ tới bảng "Orders" trong Database
    [Table("Orders")]
    public class Order
    {
        // Đánh dấu OrderId là khóa chính (Primary Key)
        [Key]

        // Cho biết OrderId được Database tự động tăng (Identity)
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        // Bắt buộc phải có mã hóa đơn
        // Độ dài tối đa là 50 ký tự
        // Trong Database, trường này được lưu dưới dạng varchar(50)
        [Required]
        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string OrderCode { get; set; } = string.Empty;

        // Thời điểm lập hóa đơn
        // Giá trị mặc định được gán theo thời gian hiện tại của hệ thống
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // Bắt buộc phải có tên tài khoản nhân viên thu ngân lập hóa đơn
        // Độ dài tối đa là 50 ký tự
        [Required]
        [StringLength(50)]
        public string CashierUsername { get; set; } = string.Empty;

        // ID của khách hàng mua hàng
        // Đây là khóa ngoại liên kết với bảng Customers
        [Required]
        public int CustomerId { get; set; }

        // Thiết lập khóa ngoại CustomerId
        // Mỗi hóa đơn thuộc về một khách hàng
        // Dấu ? cho biết đối tượng Customer có thể nhận giá trị null
        [ForeignKey(nameof(CustomerId))]
        public virtual Customer? Customer { get; set; }

        // Tổng số lượng sản phẩm trong hóa đơn
        // Bắt buộc phải có giá trị và không được nhỏ hơn 0
        [Required]
        [Range(0, int.MaxValue)]
        public int TotalItems { get; set; }

        // Tổng số tiền khách hàng phải thanh toán sau khi áp dụng giảm giá
        // Bắt buộc phải có giá trị
        // Trong Database, trường này được lưu dưới dạng decimal(18,2)
        // Giá trị không được nhỏ hơn 0
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Range(typeof(decimal), "0", "9999999999999999.99")]
        public decimal FinalAmount { get; set; }

        // Số điểm thưởng khách hàng nhận được từ hóa đơn này
        // Giá trị mặc định khi khởi tạo đối tượng là 0
        public int RewardPoints { get; set; } = 0;

        // Danh sách chi tiết hóa đơn thuộc hóa đơn hiện tại
        // Quan hệ một Order có nhiều OrderDetail
        // Khởi tạo danh sách rỗng để tránh giá trị null khi sử dụng
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
            = new List<OrderDetail>();
    }
}