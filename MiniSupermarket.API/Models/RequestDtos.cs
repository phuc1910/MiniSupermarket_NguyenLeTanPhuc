/*
 * Họ tên sinh viên: Nguyễn Lê Tấn Phúc
 * Mã sinh viên: 2124110108
 * Mô tả: DTO nhận dữ liệu từ Client cho các thao tác Thêm/Sửa (không nhận thẳng Entity CSDL)
 */
using System.ComponentModel.DataAnnotations;

namespace MiniSupermarket.API.Models
{
    // DTO thêm/sửa nhóm hàng
    public class CategoryRequestDto
    {
        [Required(ErrorMessage = "Tên nhóm hàng không được để trống!")]
        [StringLength(100, ErrorMessage = "Tên nhóm hàng không vượt quá 100 ký tự")]
        public string CategoryName { get; set; } = string.Empty;

        [StringLength(255, ErrorMessage = "Mô tả không vượt quá 255 ký tự")]
        public string? Description { get; set; }
    }

    // DTO thêm/sửa sản phẩm
    public class ProductRequestDto
    {
        [Required(ErrorMessage = "Mã vạch không được để trống!")]
        [StringLength(50)]
        public string Barcode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Tên sản phẩm không được để trống!")]
        [StringLength(150)]
        public string ProductName { get; set; } = string.Empty;

        [Range(typeof(decimal), "0.01", "9999999999999999.99", ErrorMessage = "Đơn giá phải lớn hơn 0!")]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Số lượng tồn kho không được nhỏ hơn 0!")]
        public int StockQuantity { get; set; }

        public int CategoryId { get; set; }
    }

    // DTO thêm/sửa khách hàng
    public class CustomerRequestDto
    {
        [Required(ErrorMessage = "Tên khách hàng không được để trống!")]
        [StringLength(100)]
        public string CustomerName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Số điện thoại không được để trống!")]
        [StringLength(15)]
        public string PhoneNumber { get; set; } = string.Empty;

        [StringLength(200)]
        public string? Address { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Điểm tích lũy không được âm!")]
        public int RewardPoints { get; set; } = 0;

        [StringLength(50)]
        public string MembershipRank { get; set; } = "Chuẩn";
    }
}
