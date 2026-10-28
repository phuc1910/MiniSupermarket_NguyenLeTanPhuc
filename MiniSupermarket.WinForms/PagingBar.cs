/*
 * Họ tên sinh viên: Nguyễn Lê Tấn Phúc
 * Mã sinh viên: 2124110108
 * Mô tả: [BUỔI 6] Thanh chuyển trang dùng chung (Trang trước / Trang sau / nhãn "Trang x / y")
 *        cho màn hình Khách hàng và Nhóm hàng. Dựng bằng code, gắn dưới DataGridView.
 */
namespace MiniSupermarket.WinForms
{
    public class PagingBar : Panel
    {
        private readonly Button _btnPrev = new() { Text = "<< Trang trước", Size = new Size(130, 30) };
        private readonly Button _btnNext = new() { Text = "Trang sau >>", Size = new Size(130, 30) };
        private readonly Label _lbl = new() { AutoSize = false, Size = new Size(260, 30), TextAlign = ContentAlignment.MiddleCenter, Text = "Trang 1 / 1" };

        public int CurrentPage { get; private set; } = 1;
        public int TotalPages { get; private set; } = 1;

        public event EventHandler? PrevClicked;
        public event EventHandler? NextClicked;

        public PagingBar()
        {
            Dock = DockStyle.Bottom;
            Height = 40;
            _btnPrev.Location = new Point(3, 5);
            _lbl.Location = new Point(139, 5);
            _btnNext.Location = new Point(405, 5);
            _btnPrev.Click += (s, e) => PrevClicked?.Invoke(this, e);
            _btnNext.Click += (s, e) => NextClicked?.Invoke(this, e);
            Controls.AddRange(new Control[] { _btnPrev, _lbl, _btnNext });
        }

        // Cập nhật nhãn và bật/tắt nút theo dữ liệu trang API trả về
        public void UpdateState(int currentPage, int totalPages, int totalItems)
        {
            CurrentPage = currentPage;
            TotalPages = totalPages <= 0 ? 1 : totalPages;
            _lbl.Text = $"Trang {CurrentPage} / {TotalPages}  (Tổng: {totalItems})";
            _btnPrev.Enabled = CurrentPage > 1;
            _btnNext.Enabled = CurrentPage < TotalPages;
        }
    }
}
