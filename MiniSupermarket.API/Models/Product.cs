// Import các thuộc tính dùng để khai báo validation cho Model
using System.ComponentModel.DataAnnotations;

// Import các thuộc tính dùng để cấu hình ánh xạ giữa Model và Database
using System.ComponentModel.DataAnnotations.Schema;

// Namespace chứa các Model của hệ thống MiniSupermarket
namespace MiniSupermarket.API.Models
{
    // Chỉ định class Product sẽ được ánh xạ tới bảng "Products" trong Database
    [Table("Products")]
    public class Product
    {
        // Đánh dấu ProductId là khóa chính (Primary Key)
        [Key]

        // Cho biết ProductId được Database tự động tăng (Identity)
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        // Bắt buộc phải có mã sản phẩm
        // Không được để trống
        [Required, StringLength(50)]
        public string Barcode { get; set; } = string.Empty;

        // Bắt buộc phải có tên sản phẩm
        // Độ dài tối đa là 150 ký tự
        [Required, StringLength(150)]
        public string ProductName { get; set; } = string.Empty;

        // Giá bán của sản phẩm
        // Trong Database lưu dưới dạng decimal(18,2)
        // 18: tổng số chữ số
        // 2: số chữ số sau dấu thập phân
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        // Số lượng sản phẩm hiện có trong kho
        public int StockQuantity { get; set; }

        // ID của nhóm hàng mà sản phẩm thuộc về
        // Đây là Foreign Key liên kết với bảng Categories
        public int CategoryId { get; set; }

        // Thiết lập khóa ngoại CategoryId
        // Product thuộc về một Category
        [ForeignKey("CategoryId")]
        public virtual Category? Category { get; set; }
    }
}
