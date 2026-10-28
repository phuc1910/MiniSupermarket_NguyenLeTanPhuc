/*
 * Họ tên sinh viên: Nguyễn Lê Tấn Phúc
 * Mã sinh viên: 2124110108
 * Mô tả: [BUỔI 6] Các lớp DTO phân trang phía máy chủ (Server-side Pagination)
 */
namespace MiniSupermarket.API.Models
{
    // DTO chi tiết từng sản phẩm trả về kèm tên nhóm hàng
    public class ProductItemDto
    {
        public int ProductId { get; set; }
        public string Barcode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty; // Lấy từ bảng Categories qua Eager Loading
    }

    // DTO khách hàng trả về cho API phân trang (Bài tập 6.1)
    public class CustomerItemDto
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string? Address { get; set; }
        public int RewardPoints { get; set; }
        public string MembershipRank { get; set; } = string.Empty;
    }

    // DTO nhóm hàng trả về cho API phân trang
    public class CategoryItemDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string? Description { get; set; }
    }

    // DTO bao bọc kết quả phân trang
    public class PagedResult<T>
    {
        public int CurrentPage { get; set; }        // Trang hiện tại (1, 2, 3...)
        public int PageSize { get; set; }           // Số phần tử trên mỗi trang
        public int TotalItems { get; set; }         // Tổng số bản ghi thỏa mãn điều kiện
        public int TotalPages { get; set; }         // Tổng số trang = Ceiling(TotalItems / PageSize)
        public List<T> Items { get; set; } = new(); // Danh sách dữ liệu của trang hiện hành
    }
}
