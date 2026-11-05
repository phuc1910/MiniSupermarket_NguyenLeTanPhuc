/*
 * Ho ten sinh vien: Nguyen Le Tan Phuc
 * Ma sinh vien: 2124110108
 * Mo ta: Cac lop DTO phuc vu nghiep vu thanh toan gio hang POS
 */
namespace MiniSupermarket.API.Models
{
    // Một dòng sản phẩm trong giỏ hàng
    public class CartItemCheckoutDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }

    // Yêu cầu thanh toán gửi từ FormPOS
    // FormPOS gửi CustomerPhone (không phải CustomerId) nên API tự tra khách hàng theo SĐT
    public class CheckoutRequestDto
    {
        // Tài khoản thu ngân đang trực ca
        public string CashierUsername { get; set; } = string.Empty;

        // SĐT khách hàng - để trống hoặc không tìm thấy = khách vãng lai
        public string? CustomerPhone { get; set; }

        // Tổng sau đổi điểm bằng 0 thì tiền khách đưa được bằng 0; tổng dương phải đưa lớn hơn tổng.
        public decimal CashReceived { get; set; }

        // Bật đổi điểm cho khách hàng đã tra theo số điện thoại.
        public bool UsePoints { get; set; } = false;

        // Số điểm nguyên muốn đổi; 1 điểm = 1.000 đồng, không vượt điểm hiện có hoặc tiền hàng.
        public int PointsToRedeem { get; set; }

        // Danh sách mặt hàng cần thanh toán
        public List<CartItemCheckoutDto> Items { get; set; } = new();
    }

    // DTO đọc danh sách và chi tiết hóa đơn.
    // Thông tin hóa đơn dùng chung cho danh sách và phần đầu của báo cáo chi tiết.
    public class OrderReportItemDto
    {
        public int OrderId { get; set; }
        public string OrderCode { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public string CashierUsername { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerPhone { get; set; } = string.Empty;
        public int TotalItems { get; set; }
        public decimal FinalAmount { get; set; }
        public int RewardPoints { get; set; }
    }

    public class PagedOrderReportDto
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }

        // Tổng tiền của toàn bộ kết quả sau lọc, không chỉ của trang đang xem.
        public decimal TotalRevenue { get; set; }
        public List<OrderReportItemDto> Items { get; set; } = new();
    }

    public class OrderDetailReportDto : OrderReportItemDto
    {
        public List<OrderLineReportDto> Items { get; set; } = new();
    }

    public class OrderLineReportDto
    {
        public int ProductId { get; set; }
        public string Barcode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineTotal { get; set; }
    }
}
