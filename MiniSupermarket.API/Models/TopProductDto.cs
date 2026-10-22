/*
 * Ho ten sinh vien: Nguyen Le Tan Phuc
 * Ma sinh vien: 2124110108
 * Mo ta: DTO hung ket qua Stored Procedure sp_GetTop5SellingProducts (Bai tap 3.2)
 */
namespace MiniSupermarket.API.Models
{
    public class TopProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;

        // Tổng số lượng đã bán
        public int TotalSold { get; set; }

        // Tổng doanh thu của mặt hàng (VND)
        public decimal TotalRevenue { get; set; }
    }
}
