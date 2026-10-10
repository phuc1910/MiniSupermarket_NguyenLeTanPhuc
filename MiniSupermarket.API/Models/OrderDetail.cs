// Import các thuộc tính dùng để khai báo validation cho Model
using System.ComponentModel.DataAnnotations;

// Import các thuộc tính dùng để cấu hình ánh xạ giữa Model và Database
using System.ComponentModel.DataAnnotations.Schema;

// Namespace chứa các Model của hệ thống MiniSupermarket
namespace MiniSupermarket.API.Models
{
    // Chỉ định class OrderDetail sẽ được ánh xạ tới bảng "OrderDetails" trong Database
    [Table("OrderDetails")]
    public class OrderDetail
    {
        // Đánh dấu OrderDetailId là khóa chính (Primary Key)
        [Key]

        // Cho biết OrderDetailId được Database tự động tăng (Identity)
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderDetailId { get; set; }

        // ID của hóa đơn chứa chi tiết này
        // Đây là khóa ngoại liên kết với bảng Orders
        [Required]
        public int OrderId { get; set; }

        // Thiết lập khóa ngoại OrderId
        // Mỗi chi tiết hóa đơn thuộc về một hóa đơn
        // Dấu ? cho biết đối tượng Order có thể nhận giá trị null
        [ForeignKey(nameof(OrderId))]
        public virtual Order? Order { get; set; }

        // ID của sản phẩm được mua trong hóa đơn
        // Đây là khóa ngoại liên kết với bảng Products
        [Required]
        public int ProductId { get; set; }

        // Thiết lập khóa ngoại ProductId
        // Mỗi chi tiết hóa đơn tham chiếu đến một sản phẩm
        // Dấu ? cho biết đối tượng Product có thể nhận giá trị null
        [ForeignKey(nameof(ProductId))]
        public virtual Product? Product { get; set; }

        // Số lượng sản phẩm khách hàng mua
        // Bắt buộc phải có giá trị và phải lớn hơn 0
        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        // Đơn giá bán của một sản phẩm tại thời điểm mua hàng
        // Lưu lại giá bán tại thời điểm lập hóa đơn
        // để không bị ảnh hưởng khi giá sản phẩm thay đổi sau này
        // Trong Database, trường này được lưu dưới dạng decimal(18,2)
        // Giá trị không được nhỏ hơn 0
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Range(typeof(decimal), "0", "9999999999999999.99")]
        public decimal UnitPrice { get; set; }

        // Thành tiền của chi tiết hóa đơn
        // Được tính bằng số lượng nhân với đơn giá
        // Công thức: LineTotal = Quantity * UnitPrice
        // Trong Database, trường này được lưu dưới dạng decimal(18,2)
        // Giá trị không được nhỏ hơn 0
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Range(typeof(decimal), "0", "9999999999999999.99")]
        public decimal LineTotal { get; set; }
    }
}