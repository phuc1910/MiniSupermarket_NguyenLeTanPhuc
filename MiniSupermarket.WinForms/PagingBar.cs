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
            Height = 48;
            Font = new Font("Segoe UI", 10F);
            BackColor = Color.FromArgb(247, 250, 254);
            Padding = new Padding(8, 6, 8, 6);
            _btnPrev.Text = "Trang trước";
            _btnNext.Text = "Trang sau";
            _btnPrev.Size = new Size(110, 36);
            _btnNext.Size = new Size(110, 36);
            _btnPrev.Location = new Point(8, 6);
            _lbl.Location = new Point(124, 6);
            _lbl.Size = new Size(230, 36);
            _lbl.ForeColor = Color.FromArgb(30, 58, 95);
            _lbl.Font = new Font("Segoe UI", 9F);
            _btnNext.Location = new Point(360, 6);
            _btnPrev.FlatStyle = FlatStyle.Flat;
            _btnNext.FlatStyle = FlatStyle.Flat;
            _btnPrev.FlatAppearance.BorderSize = 0;
            _btnNext.FlatAppearance.BorderSize = 0;
            _btnPrev.BackColor = Color.FromArgb(232, 239, 250);
            _btnNext.BackColor = Color.FromArgb(37, 99, 235);
            _btnPrev.ForeColor = Color.FromArgb(30, 58, 95);
            _btnNext.ForeColor = Color.White;
            _btnPrev.Cursor = Cursors.Hand;
            _btnNext.Cursor = Cursors.Hand;
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
