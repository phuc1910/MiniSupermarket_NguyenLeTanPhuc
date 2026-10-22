/*
 * Ho ten sinh vien: Nguyen Le Tan Phuc
 * Ma sinh vien: 2124110108
 * Mo ta: DTO hung ket qua thong ke tu Stored Procedure sp_GetRevenueByCashier
 */
namespace MiniSupermarket.API.Models
{
    public class CashierRevenueDto
    {
        // Tên đăng nhập thu ngân
        public string CashierUsername { get; set; } = string.Empty;

        // Tổng số hóa đơn đã lập
        public int TotalOrders { get; set; }

        // Tổng doanh thu (VND)
        public decimal TotalRevenue { get; set; }

        // Tổng điểm thưởng đã phát hành
        public int TotalPointsAwarded { get; set; }
    }
}
