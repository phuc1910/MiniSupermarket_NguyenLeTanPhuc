namespace MiniSupermarket.WinForms
{
    partial class FormQuickReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            label1 = new Label();
            dtpFromDate = new DateTimePicker();
            label3 = new Label();
            dtpToDate = new DateTimePicker();
            groupBox2 = new GroupBox();
            btnRunReport = new Button();
            groupBox3 = new GroupBox();
            tableLayoutPanelSummary = new TableLayoutPanel();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            label2 = new Label();
            lblTotalOrders = new Label();
            label4 = new Label();
            lblTotalRevenue = new Label();
            label6 = new Label();
            lblBestSeller = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            tableLayoutPanelSummary.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            // [RESPONSIVE] Bao toàn bộ Form -> dãn theo cả 4 chiều khi resize
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(groupBox3);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(776, 426);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Báo cáo doanh thu";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 38);
            label1.Name = "label1";
            label1.Size = new Size(68, 20);
            label1.TabIndex = 0;
            label1.Text = "Từ ngày:";
            // 
            // dtpFromDate
            // 
            dtpFromDate.Location = new Point(84, 33);
            dtpFromDate.Name = "dtpFromDate";
            dtpFromDate.Size = new Size(140, 27);
            dtpFromDate.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(240, 38);
            label3.Name = "label3";
            label3.Size = new Size(76, 20);
            label3.TabIndex = 3;
            label3.Text = "Đến ngày:";
            // 
            // dtpToDate
            // 
            dtpToDate.Location = new Point(322, 33);
            dtpToDate.Name = "dtpToDate";
            dtpToDate.Size = new Size(140, 27);
            dtpToDate.TabIndex = 4;
            // 
            // groupBox2
            // 
            // [RESPONSIVE] Thanh bộ lọc dãn theo chiều rộng, giữ nguyên ở trên
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(btnRunReport);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(dtpFromDate);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(dtpToDate);
            groupBox2.Location = new Point(6, 39);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(764, 84);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Bộ lọc báo cáo";
            // 
            // btnRunReport
            // 
            btnRunReport.Location = new Point(482, 31);
            btnRunReport.Name = "btnRunReport";
            btnRunReport.Size = new Size(112, 29);
            btnRunReport.TabIndex = 2;
            btnRunReport.Text = "Xem báo cáo";
            btnRunReport.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            // [RESPONSIVE] Khung 3 thẻ tổng quan: dãn theo cả 2 chiều, chiếm phần không gian còn lại
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox3.Controls.Add(tableLayoutPanelSummary);
            groupBox3.Location = new Point(6, 142);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(764, 278);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Tổng quan doanh thu";
            // 
            // tableLayoutPanelSummary
            // 
            // [RESPONSIVE] Dùng TableLayoutPanel 3 cột tỉ lệ bằng nhau (33.33% mỗi cột) thay cho
            // Location/Size cố định của panel1/panel2/panel3 -> 3 thẻ luôn chia đều không gian,
            // không bị dư khoảng trống hay lệch khi Form co giãn ở mọi kích thước màn hình.
            tableLayoutPanelSummary.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanelSummary.ColumnCount = 3;
            tableLayoutPanelSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tableLayoutPanelSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tableLayoutPanelSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.34F));
            tableLayoutPanelSummary.RowCount = 1;
            tableLayoutPanelSummary.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelSummary.Controls.Add(panel1, 0, 0);
            tableLayoutPanelSummary.Controls.Add(panel2, 1, 0);
            tableLayoutPanelSummary.Controls.Add(panel3, 2, 0);
            tableLayoutPanelSummary.Location = new Point(15, 29);
            tableLayoutPanelSummary.Name = "tableLayoutPanelSummary";
            tableLayoutPanelSummary.Padding = new Padding(0, 16, 0, 16);
            tableLayoutPanelSummary.Size = new Size(734, 234);
            tableLayoutPanelSummary.TabIndex = 3;
            // 
            // panel1
            // 
            // [RESPONSIVE] Dock Fill bên trong ô TableLayoutPanel -> tự co giãn theo cột
            panel1.Controls.Add(lblTotalOrders);
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Fill;
            panel1.Margin = new Padding(8, 0, 8, 0);
            panel1.Name = "panel1";
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(lblTotalRevenue);
            panel2.Controls.Add(label4);
            panel2.Dock = DockStyle.Fill;
            panel2.Margin = new Padding(8, 0, 8, 0);
            panel2.Name = "panel2";
            panel2.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Controls.Add(lblBestSeller);
            panel3.Controls.Add(label6);
            panel3.Dock = DockStyle.Fill;
            panel3.Margin = new Padding(8, 0, 8, 0);
            panel3.Name = "panel3";
            panel3.TabIndex = 2;
            // 
            // label2
            // 
            // [RESPONSIVE] Căn giữa theo chiều ngang của Panel thay vì tọa độ cố định
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Location = new Point(44, 24);
            label2.Name = "label2";
            label2.Size = new Size(145, 20);
            label2.TabIndex = 0;
            label2.Text = "TỔNG SỐ HÓA ĐƠN";
            // 
            // lblTotalOrders
            // 
            lblTotalOrders.Anchor = AnchorStyles.Top;
            lblTotalOrders.AutoSize = true;
            lblTotalOrders.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTotalOrders.Location = new Point(90, 70);
            lblTotalOrders.Name = "lblTotalOrders";
            lblTotalOrders.Size = new Size(30, 37);
            lblTotalOrders.TabIndex = 1;
            lblTotalOrders.Text = "0";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.AutoSize = true;
            label4.Location = new Point(50, 24);
            label4.Name = "label4";
            label4.Size = new Size(140, 20);
            label4.TabIndex = 0;
            label4.Text = "TỔNG DOANH THU";
            // 
            // lblTotalRevenue
            // 
            lblTotalRevenue.Anchor = AnchorStyles.Top;
            lblTotalRevenue.AutoSize = true;
            lblTotalRevenue.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTotalRevenue.Location = new Point(55, 70);
            lblTotalRevenue.Name = "lblTotalRevenue";
            lblTotalRevenue.Size = new Size(60, 30);
            lblTotalRevenue.TabIndex = 1;
            lblTotalRevenue.Text = "0 đ";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top;
            label6.AutoSize = true;
            label6.Location = new Point(17, 24);
            label6.Name = "label6";
            label6.Size = new Size(206, 20);
            label6.TabIndex = 0;
            label6.Text = "MẶT HÀNG BÁN CHẠY NHẤT";
            // 
            // lblBestSeller
            // 
            lblBestSeller.Anchor = AnchorStyles.Top;
            lblBestSeller.AutoSize = true;
            lblBestSeller.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblBestSeller.Location = new Point(45, 70);
            lblBestSeller.Name = "lblBestSeller";
            lblBestSeller.Size = new Size(150, 25);
            lblBestSeller.TabIndex = 1;
            lblBestSeller.Text = "Chưa có dữ liệu";
            // 
            // FormQuickReport
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            // [RESPONSIVE] Tránh co quá nhỏ khiến 3 thẻ tổng quan bị đè lên nhau
            MinimumSize = new Size(820, 420);
            Controls.Add(groupBox1);
            Name = "FormQuickReport";
            Text = "FormQuickReport";
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            tableLayoutPanelSummary.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private DateTimePicker dtpFromDate;
        private DateTimePicker dtpToDate;
        private Label label1;
        private Label label3;
        private Button btnRunReport;
        private GroupBox groupBox3;
        private TableLayoutPanel tableLayoutPanelSummary;
        private Panel panel3;
        private Panel panel2;
        private Panel panel1;
        private Label lblBestSeller;
        private Label label6;
        private Label lblTotalRevenue;
        private Label label4;
        private Label lblTotalOrders;
        private Label label2;
    }
}