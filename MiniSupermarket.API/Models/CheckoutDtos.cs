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

        // Danh sách mặt hàng cần thanh toán
        public List<CartItemCheckoutDto> Items { get; set; } = new();
    }
}
