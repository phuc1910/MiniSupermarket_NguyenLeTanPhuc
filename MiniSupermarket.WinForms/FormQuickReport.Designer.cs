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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            groupBox1 = new GroupBox();
            label1 = new Label();
            dtpFromDate = new DateTimePicker();
            label3 = new Label();
            dtpToDate = new DateTimePicker();
            groupBox2 = new GroupBox();
            btnRunReport = new Button();
            btnExportProducts = new Button();
            btnExportRevenue = new Button();
            groupBox3 = new GroupBox();
            tableLayoutPanelSummary = new TableLayoutPanel();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            panel5 = new Panel();
            label2 = new Label();
            lblTotalOrders = new Label();
            lblOrdersToday = new Label();
            label4 = new Label();
            lblTotalRevenue = new Label();
            lblRevenueToday = new Label();
            label6 = new Label();
            lblBestSeller = new Label();
            label7 = new Label();
            lblNewCustomers = new Label();
            label8 = new Label();
            lblLowStock = new Label();
            lblLowStockSub = new Label();
            tableLayoutPanelBottom = new TableLayoutPanel();
            groupBoxChart = new GroupBox();
            chartRevenue = new System.Windows.Forms.DataVisualization.Charting.Chart();
            groupBoxTop5 = new GroupBox();
            dgvTopProducts = new DataGridView();
            colRank = new DataGridViewTextBoxColumn();
            colProductName = new DataGridViewTextBoxColumn();
            colTotalSold = new DataGridViewTextBoxColumn();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            tableLayoutPanelSummary.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            tableLayoutPanelBottom.SuspendLayout();
            groupBoxChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartRevenue).BeginInit();
            groupBoxTop5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTopProducts).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            // [RESPONSIVE] Bao toàn bộ Form -> dãn theo cả 4 chiều khi resize
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(tableLayoutPanelBottom);
            groupBox1.Controls.Add(groupBox3);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1006, 589);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Báo cáo doanh thu & Dashboard";
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
            groupBox2.Controls.Add(btnExportRevenue);
            groupBox2.Controls.Add(btnExportProducts);
            groupBox2.Controls.Add(btnRunReport);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(dtpFromDate);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(dtpToDate);
            groupBox2.Location = new Point(6, 39);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(994, 84);
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
            // btnExportProducts
            // [TC 48] Xuất danh sách toàn bộ mặt hàng kèm tồn kho ra CSV (mở được bằng Excel)
            // 
            btnExportProducts.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExportProducts.Location = new Point(590, 31);
            btnExportProducts.Name = "btnExportProducts";
            btnExportProducts.Size = new Size(190, 29);
            btnExportProducts.TabIndex = 5;
            btnExportProducts.Text = "📥 Xuất tồn kho (Excel)";
            btnExportProducts.UseVisualStyleBackColor = true;
            // 
            // btnExportRevenue
            // [TC 48] Xuất doanh thu từng ngày trong khoảng đang chọn ra CSV
            // 
            btnExportRevenue.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExportRevenue.Location = new Point(790, 31);
            btnExportRevenue.Name = "btnExportRevenue";
            btnExportRevenue.Size = new Size(195, 29);
            btnExportRevenue.TabIndex = 6;
            btnExportRevenue.Text = "📥 Xuất doanh thu (Excel)";
            btnExportRevenue.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            // [DASHBOARD] Khung các thẻ tổng quan: dãn theo chiều ngang, chiều cao cố định
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox3.Controls.Add(tableLayoutPanelSummary);
            groupBox3.Location = new Point(6, 129);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(994, 172);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Tổng quan doanh thu";
            // 
            // tableLayoutPanelSummary
            // 
            // [RESPONSIVE] TableLayoutPanel 5 cột tỉ lệ bằng nhau (20% mỗi cột):
            // 3 thẻ báo cáo theo khoảng ngày + 2 thẻ Dashboard (khách mới, sắp hết hàng).
            tableLayoutPanelSummary.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanelSummary.ColumnCount = 5;
            tableLayoutPanelSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanelSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanelSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanelSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanelSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanelSummary.RowCount = 1;
            tableLayoutPanelSummary.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelSummary.Controls.Add(panel1, 0, 0);
            tableLayoutPanelSummary.Controls.Add(panel2, 1, 0);
            tableLayoutPanelSummary.Controls.Add(panel3, 2, 0);
            tableLayoutPanelSummary.Controls.Add(panel4, 3, 0);
            tableLayoutPanelSummary.Controls.Add(panel5, 4, 0);
            tableLayoutPanelSummary.Location = new Point(15, 29);
            tableLayoutPanelSummary.Name = "tableLayoutPanelSummary";
            tableLayoutPanelSummary.Padding = new Padding(0, 4, 0, 4);
            tableLayoutPanelSummary.Size = new Size(964, 133);
            tableLayoutPanelSummary.TabIndex = 3;
            // 
            // panel1
            // 
            // [DASHBOARD] Dock Fill trong ô TableLayoutPanel -> thẻ tự co giãn; nhãn dùng Dock nên luôn căn giữa
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(lblTotalOrders);
            panel1.Controls.Add(lblOrdersToday);
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Fill;
            panel1.Margin = new Padding(6, 0, 6, 0);
            panel1.Name = "panel1";
            panel1.TabIndex = 0;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Name = "label2";
            label2.Size = new Size(150, 32);
            label2.TabIndex = 0;
            label2.Text = "TỔNG SỐ HÓA ĐƠN";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTotalOrders
            // 
            lblTotalOrders.Dock = DockStyle.Fill;
            lblTotalOrders.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
            lblTotalOrders.Name = "lblTotalOrders";
            lblTotalOrders.TabIndex = 1;
            lblTotalOrders.Text = "0";
            lblTotalOrders.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblOrdersToday
            // 
            lblOrdersToday.Dock = DockStyle.Bottom;
            lblOrdersToday.ForeColor = Color.DimGray;
            lblOrdersToday.Name = "lblOrdersToday";
            lblOrdersToday.Size = new Size(150, 26);
            lblOrdersToday.TabIndex = 2;
            lblOrdersToday.Text = "Hôm nay: 0 hóa đơn";
            lblOrdersToday.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            // [DASHBOARD] Dock Fill trong ô TableLayoutPanel -> thẻ tự co giãn; nhãn dùng Dock nên luôn căn giữa
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(lblTotalRevenue);
            panel2.Controls.Add(lblRevenueToday);
            panel2.Controls.Add(label4);
            panel2.Dock = DockStyle.Fill;
            panel2.Margin = new Padding(6, 0, 6, 0);
            panel2.Name = "panel2";
            panel2.TabIndex = 1;
            // 
            // label4
            // 
            label4.Dock = DockStyle.Top;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Name = "label4";
            label4.Size = new Size(150, 32);
            label4.TabIndex = 0;
            label4.Text = "TỔNG DOANH THU";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTotalRevenue
            // 
            lblTotalRevenue.Dock = DockStyle.Fill;
            lblTotalRevenue.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblTotalRevenue.ForeColor = Color.ForestGreen;
            lblTotalRevenue.Name = "lblTotalRevenue";
            lblTotalRevenue.TabIndex = 1;
            lblTotalRevenue.Text = "0";
            lblTotalRevenue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblRevenueToday
            // 
            lblRevenueToday.Dock = DockStyle.Bottom;
            lblRevenueToday.ForeColor = Color.DimGray;
            lblRevenueToday.Name = "lblRevenueToday";
            lblRevenueToday.Size = new Size(150, 26);
            lblRevenueToday.TabIndex = 2;
            lblRevenueToday.Text = "Hôm nay: 0 đ";
            lblRevenueToday.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            // [DASHBOARD] Dock Fill trong ô TableLayoutPanel -> thẻ tự co giãn; nhãn dùng Dock nên luôn căn giữa
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(lblBestSeller);
            panel3.Controls.Add(label6);
            panel3.Dock = DockStyle.Fill;
            panel3.Margin = new Padding(6, 0, 6, 0);
            panel3.Name = "panel3";
            panel3.TabIndex = 2;
            // 
            // label6
            // 
            label6.Dock = DockStyle.Top;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Name = "label6";
            label6.Size = new Size(150, 32);
            label6.TabIndex = 0;
            label6.Text = "BÁN CHẠY NHẤT";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBestSeller
            // 
            lblBestSeller.Dock = DockStyle.Fill;
            lblBestSeller.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lblBestSeller.Name = "lblBestSeller";
            lblBestSeller.TabIndex = 1;
            lblBestSeller.Text = "0";
            lblBestSeller.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            // [DASHBOARD] Dock Fill trong ô TableLayoutPanel -> thẻ tự co giãn; nhãn dùng Dock nên luôn căn giữa
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(lblNewCustomers);
            panel4.Controls.Add(label7);
            panel4.Dock = DockStyle.Fill;
            panel4.Margin = new Padding(6, 0, 6, 0);
            panel4.Name = "panel4";
            panel4.TabIndex = 3;
            // 
            // label7
            // 
            label7.Dock = DockStyle.Top;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Name = "label7";
            label7.Size = new Size(150, 32);
            label7.TabIndex = 0;
            label7.Text = "KHÁCH HÀNG MỚI HÔM NAY";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblNewCustomers
            // 
            lblNewCustomers.Dock = DockStyle.Fill;
            lblNewCustomers.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
            lblNewCustomers.ForeColor = Color.DarkOrchid;
            lblNewCustomers.Name = "lblNewCustomers";
            lblNewCustomers.TabIndex = 1;
            lblNewCustomers.Text = "0";
            lblNewCustomers.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            // [DASHBOARD] Dock Fill trong ô TableLayoutPanel -> thẻ tự co giãn; nhãn dùng Dock nên luôn căn giữa
            panel5.BorderStyle = BorderStyle.FixedSingle;
            panel5.Controls.Add(lblLowStock);
            panel5.Controls.Add(lblLowStockSub);
            panel5.Controls.Add(label8);
            panel5.Dock = DockStyle.Fill;
            panel5.Margin = new Padding(6, 0, 6, 0);
            panel5.Name = "panel5";
            panel5.TabIndex = 4;
            // 
            // label8
            // 
            label8.Dock = DockStyle.Top;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Name = "label8";
            label8.Size = new Size(150, 32);
            label8.TabIndex = 0;
            label8.Text = "SẮP HẾT HÀNG";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblLowStock
            // 
            lblLowStock.Dock = DockStyle.Fill;
            lblLowStock.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
            lblLowStock.ForeColor = Color.Firebrick;
            lblLowStock.Name = "lblLowStock";
            lblLowStock.TabIndex = 1;
            lblLowStock.Text = "0";
            lblLowStock.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblLowStockSub
            // 
            lblLowStockSub.Dock = DockStyle.Bottom;
            lblLowStockSub.ForeColor = Color.DimGray;
            lblLowStockSub.Name = "lblLowStockSub";
            lblLowStockSub.Size = new Size(150, 26);
            lblLowStockSub.TabIndex = 2;
            lblLowStockSub.Text = "Tồn kho <= 10";
            lblLowStockSub.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanelBottom
            // 
            // [DASHBOARD] Hàng dưới: biểu đồ cột (64%) + Top 5 bán chạy (36%), dãn theo cả 2 chiều
            tableLayoutPanelBottom.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanelBottom.ColumnCount = 2;
            tableLayoutPanelBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 64F));
            tableLayoutPanelBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 36F));
            tableLayoutPanelBottom.Controls.Add(groupBoxChart, 0, 0);
            tableLayoutPanelBottom.Controls.Add(groupBoxTop5, 1, 0);
            tableLayoutPanelBottom.Location = new Point(6, 307);
            tableLayoutPanelBottom.Name = "tableLayoutPanelBottom";
            tableLayoutPanelBottom.RowCount = 1;
            tableLayoutPanelBottom.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelBottom.Size = new Size(994, 276);
            tableLayoutPanelBottom.TabIndex = 4;
            // 
            // groupBoxChart
            // 
            groupBoxChart.Controls.Add(chartRevenue);
            groupBoxChart.Dock = DockStyle.Fill;
            groupBoxChart.Name = "groupBoxChart";
            groupBoxChart.TabIndex = 0;
            groupBoxChart.TabStop = false;
            groupBoxChart.Text = "Doanh thu theo ngày (VNĐ)";
            // 
            // chartRevenue
            // 
            chartArea1.Name = "ChartArea1";
            chartRevenue.ChartAreas.Add(chartArea1);
            chartRevenue.Dock = DockStyle.Fill;
            chartRevenue.Name = "chartRevenue";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            series1.Name = "Doanh thu";
            chartRevenue.Series.Add(series1);
            chartRevenue.TabIndex = 0;
            chartRevenue.Text = "chartRevenue";
            // 
            // groupBoxTop5
            // 
            groupBoxTop5.Controls.Add(dgvTopProducts);
            groupBoxTop5.Dock = DockStyle.Fill;
            groupBoxTop5.Name = "groupBoxTop5";
            groupBoxTop5.TabIndex = 1;
            groupBoxTop5.TabStop = false;
            groupBoxTop5.Text = "Top 5 sản phẩm bán chạy";
            // 
            // dgvTopProducts
            // 
            dgvTopProducts.AllowUserToAddRows = false;
            dgvTopProducts.AllowUserToDeleteRows = false;
            dgvTopProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTopProducts.BackgroundColor = SystemColors.Window;
            dgvTopProducts.BorderStyle = BorderStyle.None;
            dgvTopProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTopProducts.Columns.AddRange(new DataGridViewColumn[] { colRank, colProductName, colTotalSold });
            dgvTopProducts.Dock = DockStyle.Fill;
            dgvTopProducts.Name = "dgvTopProducts";
            dgvTopProducts.ReadOnly = true;
            dgvTopProducts.RowHeadersVisible = false;
            dgvTopProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTopProducts.TabIndex = 0;
            // 
            // colRank
            // 
            colRank.FillWeight = 15F;
            colRank.HeaderText = "Hạng";
            colRank.Name = "colRank";
            colRank.ReadOnly = true;
            // 
            // colProductName
            // 
            colProductName.FillWeight = 60F;
            colProductName.HeaderText = "Tên sản phẩm";
            colProductName.Name = "colProductName";
            colProductName.ReadOnly = true;
            // 
            // colTotalSold
            // 
            colTotalSold.FillWeight = 25F;
            colTotalSold.HeaderText = "Đã bán";
            colTotalSold.Name = "colTotalSold";
            colTotalSold.ReadOnly = true;
            // 
            // FormQuickReport
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1030, 613);
            // [RESPONSIVE] Tránh co quá nhỏ khiến các thẻ tổng quan bị đè lên nhau
            MinimumSize = new Size(900, 560);
            Controls.Add(groupBox1);
            Name = "FormQuickReport";
            Text = "FormQuickReport";
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            tableLayoutPanelSummary.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel5.ResumeLayout(false);
            tableLayoutPanelBottom.ResumeLayout(false);
            groupBoxChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartRevenue).EndInit();
            groupBoxTop5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTopProducts).EndInit();
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
        private Button btnExportProducts;
        private Button btnExportRevenue;
        private GroupBox groupBox3;
        private TableLayoutPanel tableLayoutPanelSummary;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Label label2;
        private Label lblTotalOrders;
        private Label lblOrdersToday;
        private Label label4;
        private Label lblTotalRevenue;
        private Label lblRevenueToday;
        private Label label6;
        private Label lblBestSeller;
        private Label label7;
        private Label lblNewCustomers;
        private Label label8;
        private Label lblLowStock;
        private Label lblLowStockSub;
        private TableLayoutPanel tableLayoutPanelBottom;
        private GroupBox groupBoxChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRevenue;
        private GroupBox groupBoxTop5;
        private DataGridView dgvTopProducts;
        private DataGridViewTextBoxColumn colRank;
        private DataGridViewTextBoxColumn colProductName;
        private DataGridViewTextBoxColumn colTotalSold;
    }
}