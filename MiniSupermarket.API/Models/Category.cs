using System.ComponentModel.DataAnnotations; // Kiểm tra dữ liệu
using System.ComponentModel.DataAnnotations.Schema; // Cấu hình bảng
using System.Text.Json.Serialization; // Cấu hình JSON

namespace MiniSupermarket.API.Models // Namespace chứa Model
{
    [Table("Categories")] // Tên bảng trong SQL
    public class Category // Model danh mục
    {
        [Key] // Khóa chính
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // ID tự tăng
        public int CategoryId { get; set; } // ID danh mục

        [Required(ErrorMessage = "Tên nhóm hàng không được để trống!")] // Bắt buộc nhập
        [StringLength(100, ErrorMessage = "Tên nhóm hàng không vượt quá 100 ký tự")] // Tối đa 100 ký tự
        public string CategoryName { get; set; } = string.Empty; // Tên danh mục

        [StringLength(255)] // Tối đa 255 ký tự
        public string? Description { get; set; } // Mô tả danh mục

        [JsonIgnore] // Tránh vòng lặp JSON
        public virtual ICollection<Product>? Products { get; set; } // Một danh mục có nhiều sản phẩm
    }
}
