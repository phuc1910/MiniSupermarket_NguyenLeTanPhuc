namespace MiniSupermarket.WinForms
{
    partial class FormQuickReport
    {
        private System.ComponentModel.IContainer components = null;

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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea cashierArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series cashierSeries = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Legend cashierLegend = new System.Windows.Forms.DataVisualization.Charting.Legend();
            groupCashierChart = new GroupBox();
            chartCashierShare = new System.Windows.Forms.DataVisualization.Charting.Chart();
            lblCashierChartEmpty = new Label();
            tabReports = new TabControl();
            tabOverview = new TabPage();
            tabDaily = new TabPage();
            tabCashiers = new TabPage();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            labelOverviewPeriod = new Label();
            cmbOverviewPeriod = new ComboBox();
            labelOverviewAnchor = new Label();
            dtpOverviewAnchor = new DateTimePicker();
            label1 = new Label();
            dtpFromDate = new DateTimePicker();
            label3 = new Label();
            dtpToDate = new DateTimePicker();
            btnRunReport = new Button();
            btnExportProducts = new Button();
            btnExportRevenue = new Button();
            groupBox3 = new GroupBox();
            tableLayoutPanelSummary = new FlowLayoutPanel();
            panel1 = new Panel();
            label2 = new Label();
            lblTotalOrders = new Label();
            lblOrdersToday = new Label();
            panel2 = new Panel();
            label4 = new Label();
            lblTotalRevenue = new Label();
            lblRevenueToday = new Label();
            panel3 = new Panel();
            label6 = new Label();
            lblBestSeller = new Label();
            panel4 = new Panel();
            label7 = new Label();
            lblNewCustomers = new Label();
            panel5 = new Panel();
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
            layoutDaily = new TableLayoutPanel();
            groupDailyFilter = new GroupBox();
            labelDailyPeriod = new Label();
            cmbDailyPeriod = new ComboBox();
            labelDailyAnchor = new Label();
            dtpDaily = new DateTimePicker();
            btnLoadDaily = new Button();
            layoutDailyCards = new TableLayoutPanel();
            panelDailyRevenue = new Panel();
            labelDailyRevenue = new Label();
            lblDailyRevenue = new Label();
            panelDailyOrders = new Panel();
            labelDailyOrders = new Label();
            lblDailyOrders = new Label();
            panelDailyBestSeller = new Panel();
            labelDailyBestSeller = new Label();
            lblDailyBestSeller = new Label();
            lblDailySummary = new Label();
            dgvDailyCashiers = new DataGridView();
            colDailyCashier = new DataGridViewTextBoxColumn();
            colDailyOrders = new DataGridViewTextBoxColumn();
            colDailyRevenue = new DataGridViewTextBoxColumn();
            colDailyPoints = new DataGridViewTextBoxColumn();
            layoutCashiers = new TableLayoutPanel();
            groupCashierFilter = new GroupBox();
            labelCashierPeriod = new Label();
            cmbCashierPeriod = new ComboBox();
            labelCashierAnchor = new Label();
            dtpCashierAnchor = new DateTimePicker();
            labelCashierFrom = new Label();
            dtpCashierFrom = new DateTimePicker();
            labelCashierTo = new Label();
            dtpCashierTo = new DateTimePicker();
            btnLoadCashiers = new Button();
            chkAllCashierHistory = new CheckBox();
            lblCashierSummary = new Label();
            dgvCashiers = new DataGridView();
            colCashierUsername = new DataGridViewTextBoxColumn();
            colCashierOrders = new DataGridViewTextBoxColumn();
            colCashierRevenue = new DataGridViewTextBoxColumn();
            colCashierPoints = new DataGridViewTextBoxColumn();
            tabReports.SuspendLayout();
            tabOverview.SuspendLayout();
            tabDaily.SuspendLayout();
            tabCashiers.SuspendLayout();
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
            groupBoxTop5.SuspendLayout();
            layoutDaily.SuspendLayout();
            groupDailyFilter.SuspendLayout();
            layoutDailyCards.SuspendLayout();
            panelDailyRevenue.SuspendLayout();
            panelDailyOrders.SuspendLayout();
            panelDailyBestSeller.SuspendLayout();
            layoutCashiers.SuspendLayout();
            groupCashierFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTopProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDailyCashiers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCashiers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartRevenue).BeginInit();
            groupCashierChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartCashierShare).BeginInit();
            SuspendLayout();
            //
            // tabReports
            //
            tabReports.Location = new Point(12, 12);
            tabReports.Name = "tabReports";
            tabReports.Size = new Size(1006, 589);
            tabReports.Dock = DockStyle.Fill;
            tabReports.TabIndex = 0;
            tabReports.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            tabReports.ItemSize = new Size(180, 38);
            tabReports.Padding = new Point(16, 10);
            tabReports.SelectedIndex = 0;
            tabReports.Controls.Add(tabOverview);
            //
            // tabOverview
            //
            tabOverview.Location = new Point(4, 42);
            tabOverview.Name = "tabOverview";
            tabOverview.Size = new Size(998, 543);
            tabOverview.Text = "Tổng quan";
            tabOverview.TabIndex = 1;
            tabOverview.BackColor = Color.FromArgb(242, 245, 250);
            tabOverview.Padding = new Padding(12);
            tabReports.Controls.Add(tabDaily);
            //
            // tabDaily
            //
            tabDaily.Location = new Point(4, 42);
            tabDaily.Name = "tabDaily";
            tabDaily.Size = new Size(998, 543);
            tabDaily.Text = "Doanh thu theo kỳ";
            tabDaily.TabIndex = 3;
            tabDaily.BackColor = Color.FromArgb(242, 245, 250);
            tabDaily.Padding = new Padding(12);
            tabReports.Controls.Add(tabCashiers);
            //
            // tabCashiers
            //
            tabCashiers.Location = new Point(4, 42);
            tabCashiers.Name = "tabCashiers";
            tabCashiers.Size = new Size(998, 543);
            tabCashiers.Text = "Doanh thu thu ngân";
            tabCashiers.TabIndex = 4;
            tabCashiers.BackColor = Color.FromArgb(242, 245, 250);
            tabCashiers.Padding = new Padding(12);
            tabOverview.AutoScroll = true;
            tabOverview.AutoScrollMargin = new Size(12, 12);
            tabOverview.Controls.Add(groupBox1);
            //
            // groupBox1
            //
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(954, 1270);
            groupBox1.Text = "Báo cáo doanh thu & Dashboard";
            groupBox1.TabIndex = 5;
            groupBox1.BackColor = Color.White;
            groupBox1.ForeColor = Color.FromArgb(22, 54, 90);
            groupBox1.Padding = new Padding(12);
            groupBox1.TabStop = false;
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.BackColor = Color.FromArgb(242, 245, 250);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Controls.Add(groupBox3);
            groupBox1.Controls.Add(tableLayoutPanelBottom);
            groupBox1.Controls.Add(groupCashierChart);
            // Biểu đồ tròn dùng cùng khoảng ngày với bộ lọc Tổng quan.
            groupCashierChart.Name = "groupCashierChart";
            groupCashierChart.Text = "Tỷ trọng doanh thu theo thu ngân";
            groupCashierChart.Location = new Point(16, 920);
            groupCashierChart.Size = new Size(922, 330);
            groupCashierChart.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupCashierChart.BackColor = Color.White;
            groupCashierChart.ForeColor = Color.FromArgb(22, 54, 90);
            groupCashierChart.Padding = new Padding(12);
            groupCashierChart.TabStop = false;
            groupCashierChart.Controls.Add(chartCashierShare);
            groupCashierChart.Controls.Add(lblCashierChartEmpty);
            chartCashierShare.Name = "chartCashierShare";
            chartCashierShare.Dock = DockStyle.Fill;
            chartCashierShare.BackColor = Color.White;
            chartCashierShare.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.BrightPastel;
            cashierArea.Name = "CashierArea";
            chartCashierShare.ChartAreas.Add(cashierArea);
            cashierSeries.Name = "Tỷ trọng";
            cashierSeries.ChartArea = "CashierArea";
            cashierSeries.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            cashierSeries.Label = "#PERCENT{P1}";
            cashierSeries.Font = new Font("Segoe UI", 9F);
            chartCashierShare.Series.Add(cashierSeries);
            cashierLegend.Name = "CashierLegend";
            cashierLegend.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Right;
            cashierLegend.Font = new Font("Segoe UI", 9F);
            chartCashierShare.Legends.Add(cashierLegend);
            lblCashierChartEmpty.Name = "lblCashierChartEmpty";
            lblCashierChartEmpty.Text = "Không có doanh thu trong khoảng ngày này.";
            lblCashierChartEmpty.Dock = DockStyle.Fill;
            lblCashierChartEmpty.TextAlign = ContentAlignment.MiddleCenter;
            lblCashierChartEmpty.ForeColor = Color.FromArgb(100, 116, 139);
            lblCashierChartEmpty.Visible = false;
            //
            // groupBox2
            //
            groupBox2.Location = new Point(16, 34);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(922, 158);
            groupBox2.Text = "Bộ lọc báo cáo";
            groupBox2.TabIndex = 6;
            groupBox2.BackColor = Color.White;
            groupBox2.ForeColor = Color.FromArgb(22, 54, 90);
            groupBox2.Padding = new Padding(12);
            groupBox2.TabStop = false;
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            //
            // labelOverviewPeriod
            //
            labelOverviewPeriod.Location = new Point(16, 29);
            labelOverviewPeriod.Name = "labelOverviewPeriod";
            labelOverviewPeriod.Size = new Size(82, 28);
            labelOverviewPeriod.Text = "Kỳ:";
            labelOverviewPeriod.TabIndex = 7;
            labelOverviewPeriod.AutoSize = false;
            labelOverviewPeriod.ForeColor = Color.FromArgb(22, 54, 90);
            labelOverviewPeriod.TextAlign = ContentAlignment.MiddleLeft;
            //
            // cmbOverviewPeriod
            //
            cmbOverviewPeriod.Location = new Point(104, 29);
            cmbOverviewPeriod.Name = "cmbOverviewPeriod";
            cmbOverviewPeriod.Size = new Size(140, 28);
            cmbOverviewPeriod.TabIndex = 8;
            cmbOverviewPeriod.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOverviewPeriod.FormattingEnabled = true;
            cmbOverviewPeriod.Items.AddRange(new object[] { "Ngày", "Tuần", "Tháng", "Năm", "Tùy chọn" });
            //
            // labelOverviewAnchor
            //
            labelOverviewAnchor.Location = new Point(258, 29);
            labelOverviewAnchor.Name = "labelOverviewAnchor";
            labelOverviewAnchor.Size = new Size(126, 28);
            labelOverviewAnchor.Text = "Mốc ngày:";
            labelOverviewAnchor.TabIndex = 9;
            labelOverviewAnchor.AutoSize = false;
            labelOverviewAnchor.ForeColor = Color.FromArgb(22, 54, 90);
            labelOverviewAnchor.TextAlign = ContentAlignment.MiddleLeft;
            //
            // dtpOverviewAnchor
            //
            dtpOverviewAnchor.Location = new Point(394, 29);
            dtpOverviewAnchor.Name = "dtpOverviewAnchor";
            dtpOverviewAnchor.Size = new Size(140, 28);
            dtpOverviewAnchor.TabIndex = 10;
            dtpOverviewAnchor.Format = DateTimePickerFormat.Custom;
            dtpOverviewAnchor.CustomFormat = "dd/MM/yyyy";
            dtpOverviewAnchor.CalendarForeColor = Color.FromArgb(22, 54, 90);
            dtpOverviewAnchor.CalendarTitleBackColor = Color.FromArgb(232, 239, 250);
            //
            // label1
            //
            label1.Location = new Point(16, 69);
            label1.Name = "label1";
            label1.Size = new Size(74, 28);
            label1.Text = "Từ:";
            label1.TabIndex = 11;
            label1.AutoSize = false;
            label1.ForeColor = Color.FromArgb(22, 54, 90);
            label1.TextAlign = ContentAlignment.MiddleLeft;
            //
            // dtpFromDate
            //
            dtpFromDate.Location = new Point(98, 69);
            dtpFromDate.Name = "dtpFromDate";
            dtpFromDate.Size = new Size(140, 28);
            dtpFromDate.TabIndex = 12;
            dtpFromDate.Format = DateTimePickerFormat.Custom;
            dtpFromDate.CustomFormat = "dd/MM/yyyy";
            dtpFromDate.CalendarForeColor = Color.FromArgb(22, 54, 90);
            dtpFromDate.CalendarTitleBackColor = Color.FromArgb(232, 239, 250);
            //
            // label3
            //
            label3.Location = new Point(258, 69);
            label3.Name = "label3";
            label3.Size = new Size(126, 28);
            label3.Text = "Đến:";
            label3.TabIndex = 13;
            label3.AutoSize = false;
            label3.ForeColor = Color.FromArgb(22, 54, 90);
            label3.TextAlign = ContentAlignment.MiddleLeft;
            //
            // dtpToDate
            //
            dtpToDate.Location = new Point(394, 69);
            dtpToDate.Name = "dtpToDate";
            dtpToDate.Size = new Size(140, 28);
            dtpToDate.TabIndex = 14;
            dtpToDate.Format = DateTimePickerFormat.Custom;
            dtpToDate.CustomFormat = "dd/MM/yyyy";
            dtpToDate.CalendarForeColor = Color.FromArgb(22, 54, 90);
            dtpToDate.CalendarTitleBackColor = Color.FromArgb(232, 239, 250);
            //
            // btnRunReport
            //
            btnRunReport.Location = new Point(16, 108);
            btnRunReport.Name = "btnRunReport";
            btnRunReport.Size = new Size(148, 36);
            btnRunReport.Text = "Xem báo cáo";
            btnRunReport.TabIndex = 15;
            btnRunReport.BackColor = Color.FromArgb(37, 99, 235);
            btnRunReport.ForeColor = Color.White;
            btnRunReport.FlatStyle = FlatStyle.Flat;
            btnRunReport.FlatAppearance.BorderSize = 0;
            btnRunReport.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnRunReport.UseVisualStyleBackColor = false;
            btnRunReport.Cursor = Cursors.Hand;
            //
            // btnExportProducts
            //
            btnExportProducts.Location = new Point(180, 108);
            btnExportProducts.Name = "btnExportProducts";
            btnExportProducts.Size = new Size(200, 36);
            btnExportProducts.Text = "Xuất tồn kho";
            btnExportProducts.TabIndex = 16;
            btnExportProducts.BackColor = Color.FromArgb(37, 99, 235);
            btnExportProducts.ForeColor = Color.White;
            btnExportProducts.FlatStyle = FlatStyle.Flat;
            btnExportProducts.FlatAppearance.BorderSize = 0;
            btnExportProducts.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnExportProducts.UseVisualStyleBackColor = false;
            btnExportProducts.Cursor = Cursors.Hand;
            //
            // btnExportRevenue
            //
            btnExportRevenue.Location = new Point(396, 108);
            btnExportRevenue.Name = "btnExportRevenue";
            btnExportRevenue.Size = new Size(220, 36);
            btnExportRevenue.Text = "Xuất doanh thu";
            btnExportRevenue.TabIndex = 17;
            btnExportRevenue.BackColor = Color.FromArgb(37, 99, 235);
            btnExportRevenue.ForeColor = Color.White;
            btnExportRevenue.FlatStyle = FlatStyle.Flat;
            btnExportRevenue.FlatAppearance.BorderSize = 0;
            btnExportRevenue.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnExportRevenue.UseVisualStyleBackColor = false;
            btnExportRevenue.Cursor = Cursors.Hand;
            groupBox2.Controls.Add(labelOverviewPeriod);
            groupBox2.Controls.Add(cmbOverviewPeriod);
            groupBox2.Controls.Add(labelOverviewAnchor);
            groupBox2.Controls.Add(dtpOverviewAnchor);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(dtpFromDate);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(dtpToDate);
            groupBox2.Controls.Add(btnRunReport);
            groupBox2.Controls.Add(btnExportProducts);
            groupBox2.Controls.Add(btnExportRevenue);
            //
            // groupBox3
            //
            groupBox3.Location = new Point(16, 206);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(922, 354);
            groupBox3.Text = "Tổng quan doanh thu";
            groupBox3.TabIndex = 18;
            groupBox3.BackColor = Color.White;
            groupBox3.ForeColor = Color.FromArgb(22, 54, 90);
            groupBox3.Padding = new Padding(12);
            groupBox3.TabStop = false;
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox3.Padding = new Padding(10, 28, 10, 10);
            //
            // tableLayoutPanelSummary
            //
            tableLayoutPanelSummary.Name = "tableLayoutPanelSummary";
            tableLayoutPanelSummary.Dock = DockStyle.Fill;
            tableLayoutPanelSummary.TabIndex = 19;
            tableLayoutPanelSummary.AutoScroll = true;
            tableLayoutPanelSummary.WrapContents = true;
            tableLayoutPanelSummary.FlowDirection = FlowDirection.LeftToRight;
            tableLayoutPanelSummary.BackColor = Color.White;
            groupBox3.Controls.Add(tableLayoutPanelSummary);
            //
            // panel1
            //
            panel1.Name = "panel1";
            panel1.Size = new Size(230, 140);
            panel1.TabIndex = 20;
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Margin = new Padding(6);
            panel1.Padding = new Padding(10);
            //
            // label2
            //
            label2.Location = new Point(10, 10);
            label2.Name = "label2";
            label2.Size = new Size(208, 34);
            label2.Text = "TỔNG SỐ HÓA ĐƠN";
            label2.TabIndex = 21;
            label2.AutoSize = false;
            label2.ForeColor = Color.FromArgb(22, 54, 90);
            label2.TextAlign = ContentAlignment.MiddleLeft;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            //
            // lblTotalOrders
            //
            lblTotalOrders.Location = new Point(10, 46);
            lblTotalOrders.Name = "lblTotalOrders";
            lblTotalOrders.Size = new Size(208, 50);
            lblTotalOrders.Text = "0";
            lblTotalOrders.TabIndex = 22;
            lblTotalOrders.AutoSize = false;
            lblTotalOrders.ForeColor = Color.FromArgb(22, 54, 90);
            lblTotalOrders.TextAlign = ContentAlignment.MiddleLeft;
            lblTotalOrders.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
            lblTotalOrders.TextAlign = ContentAlignment.MiddleCenter;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(lblTotalOrders);
            //
            // lblOrdersToday
            //
            lblOrdersToday.Location = new Point(10, 104);
            lblOrdersToday.Name = "lblOrdersToday";
            lblOrdersToday.Size = new Size(208, 26);
            lblOrdersToday.Text = "Hôm nay: 0";
            lblOrdersToday.TabIndex = 23;
            lblOrdersToday.AutoSize = false;
            lblOrdersToday.ForeColor = Color.FromArgb(22, 54, 90);
            lblOrdersToday.TextAlign = ContentAlignment.MiddleLeft;
            lblOrdersToday.ForeColor = Color.FromArgb(100, 116, 139);
            lblOrdersToday.TextAlign = ContentAlignment.MiddleCenter;
            panel1.Controls.Add(lblOrdersToday);
            lblOrdersToday.Text = "Hôm nay: 0 hóa đơn";
            //
            // panel2
            //
            panel2.Name = "panel2";
            panel2.Size = new Size(230, 140);
            panel2.TabIndex = 24;
            panel2.BackColor = Color.White;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Margin = new Padding(6);
            panel2.Padding = new Padding(10);
            //
            // label4
            //
            label4.Location = new Point(10, 10);
            label4.Name = "label4";
            label4.Size = new Size(208, 34);
            label4.Text = "TỔNG DOANH THU";
            label4.TabIndex = 25;
            label4.AutoSize = false;
            label4.ForeColor = Color.FromArgb(22, 54, 90);
            label4.TextAlign = ContentAlignment.MiddleLeft;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            //
            // lblTotalRevenue
            //
            lblTotalRevenue.Location = new Point(10, 46);
            lblTotalRevenue.Name = "lblTotalRevenue";
            lblTotalRevenue.Size = new Size(208, 50);
            lblTotalRevenue.Text = "0";
            lblTotalRevenue.TabIndex = 26;
            lblTotalRevenue.AutoSize = false;
            lblTotalRevenue.ForeColor = Color.FromArgb(22, 54, 90);
            lblTotalRevenue.TextAlign = ContentAlignment.MiddleLeft;
            lblTotalRevenue.Font = new Font("Segoe UI", 17F, FontStyle.Bold, GraphicsUnit.Point);
            lblTotalRevenue.TextAlign = ContentAlignment.MiddleCenter;
            panel2.Controls.Add(label4);
            panel2.Controls.Add(lblTotalRevenue);
            //
            // lblRevenueToday
            //
            lblRevenueToday.Location = new Point(10, 104);
            lblRevenueToday.Name = "lblRevenueToday";
            lblRevenueToday.Size = new Size(208, 26);
            lblRevenueToday.Text = "Hôm nay: 0";
            lblRevenueToday.TabIndex = 27;
            lblRevenueToday.AutoSize = false;
            lblRevenueToday.ForeColor = Color.FromArgb(22, 54, 90);
            lblRevenueToday.TextAlign = ContentAlignment.MiddleLeft;
            lblRevenueToday.ForeColor = Color.FromArgb(100, 116, 139);
            lblRevenueToday.TextAlign = ContentAlignment.MiddleCenter;
            panel2.Controls.Add(lblRevenueToday);
            lblTotalRevenue.Text = "0 đ";
            lblRevenueToday.Text = "Hôm nay: 0 đ";
            //
            // panel3
            //
            panel3.Name = "panel3";
            panel3.Size = new Size(230, 140);
            panel3.TabIndex = 28;
            panel3.BackColor = Color.White;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Margin = new Padding(6);
            panel3.Padding = new Padding(10);
            //
            // label6
            //
            label6.Location = new Point(10, 10);
            label6.Name = "label6";
            label6.Size = new Size(208, 34);
            label6.Text = "BÁN CHẠY NHẤT";
            label6.TabIndex = 29;
            label6.AutoSize = false;
            label6.ForeColor = Color.FromArgb(22, 54, 90);
            label6.TextAlign = ContentAlignment.MiddleLeft;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            //
            // lblBestSeller
            //
            lblBestSeller.Location = new Point(10, 46);
            lblBestSeller.Name = "lblBestSeller";
            lblBestSeller.Size = new Size(208, 50);
            lblBestSeller.Text = "0";
            lblBestSeller.TabIndex = 30;
            lblBestSeller.AutoSize = false;
            lblBestSeller.ForeColor = Color.FromArgb(22, 54, 90);
            lblBestSeller.TextAlign = ContentAlignment.MiddleLeft;
            lblBestSeller.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lblBestSeller.TextAlign = ContentAlignment.MiddleCenter;
            panel3.Controls.Add(label6);
            panel3.Controls.Add(lblBestSeller);
            lblBestSeller.Size = new Size(208, 80);
            lblBestSeller.Text = "Chưa có dữ liệu";
            //
            // panel4
            //
            panel4.Name = "panel4";
            panel4.Size = new Size(230, 140);
            panel4.TabIndex = 31;
            panel4.BackColor = Color.White;
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Margin = new Padding(6);
            panel4.Padding = new Padding(10);
            //
            // label7
            //
            label7.Location = new Point(10, 10);
            label7.Name = "label7";
            label7.Size = new Size(208, 34);
            label7.Text = "KHÁCH MỚI HÔM NAY";
            label7.TabIndex = 32;
            label7.AutoSize = false;
            label7.ForeColor = Color.FromArgb(22, 54, 90);
            label7.TextAlign = ContentAlignment.MiddleLeft;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            //
            // lblNewCustomers
            //
            lblNewCustomers.Location = new Point(10, 46);
            lblNewCustomers.Name = "lblNewCustomers";
            lblNewCustomers.Size = new Size(208, 50);
            lblNewCustomers.Text = "0";
            lblNewCustomers.TabIndex = 33;
            lblNewCustomers.AutoSize = false;
            lblNewCustomers.ForeColor = Color.FromArgb(22, 54, 90);
            lblNewCustomers.TextAlign = ContentAlignment.MiddleLeft;
            lblNewCustomers.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
            lblNewCustomers.TextAlign = ContentAlignment.MiddleCenter;
            panel4.Controls.Add(label7);
            panel4.Controls.Add(lblNewCustomers);
            lblNewCustomers.Size = new Size(208, 80);
            //
            // panel5
            //
            panel5.Name = "panel5";
            panel5.Size = new Size(230, 140);
            panel5.TabIndex = 34;
            panel5.BackColor = Color.White;
            panel5.BorderStyle = BorderStyle.FixedSingle;
            panel5.Margin = new Padding(6);
            panel5.Padding = new Padding(10);
            //
            // label8
            //
            label8.Location = new Point(10, 10);
            label8.Name = "label8";
            label8.Size = new Size(208, 34);
            label8.Text = "SẮP HẾT HÀNG";
            label8.TabIndex = 35;
            label8.AutoSize = false;
            label8.ForeColor = Color.FromArgb(22, 54, 90);
            label8.TextAlign = ContentAlignment.MiddleLeft;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            //
            // lblLowStock
            //
            lblLowStock.Location = new Point(10, 46);
            lblLowStock.Name = "lblLowStock";
            lblLowStock.Size = new Size(208, 50);
            lblLowStock.Text = "0";
            lblLowStock.TabIndex = 36;
            lblLowStock.AutoSize = false;
            lblLowStock.ForeColor = Color.FromArgb(22, 54, 90);
            lblLowStock.TextAlign = ContentAlignment.MiddleLeft;
            lblLowStock.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
            lblLowStock.TextAlign = ContentAlignment.MiddleCenter;
            panel5.Controls.Add(label8);
            panel5.Controls.Add(lblLowStock);
            //
            // lblLowStockSub
            //
            lblLowStockSub.Location = new Point(10, 104);
            lblLowStockSub.Name = "lblLowStockSub";
            lblLowStockSub.Size = new Size(208, 26);
            lblLowStockSub.Text = "Hôm nay: 0";
            lblLowStockSub.TabIndex = 37;
            lblLowStockSub.AutoSize = false;
            lblLowStockSub.ForeColor = Color.FromArgb(22, 54, 90);
            lblLowStockSub.TextAlign = ContentAlignment.MiddleLeft;
            lblLowStockSub.ForeColor = Color.FromArgb(100, 116, 139);
            lblLowStockSub.TextAlign = ContentAlignment.MiddleCenter;
            panel5.Controls.Add(lblLowStockSub);
            lblLowStockSub.Text = "Tồn kho <= 10";
            tableLayoutPanelSummary.Controls.Add(panel1);
            tableLayoutPanelSummary.Controls.Add(panel2);
            tableLayoutPanelSummary.Controls.Add(panel3);
            tableLayoutPanelSummary.Controls.Add(panel4);
            tableLayoutPanelSummary.Controls.Add(panel5);
            //
            // tableLayoutPanelBottom
            //
            tableLayoutPanelBottom.Location = new Point(16, 574);
            tableLayoutPanelBottom.Name = "tableLayoutPanelBottom";
            tableLayoutPanelBottom.Size = new Size(922, 330);
            tableLayoutPanelBottom.TabIndex = 38;
            tableLayoutPanelBottom.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanelBottom.ColumnCount = 2;
            tableLayoutPanelBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 58F));
            tableLayoutPanelBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42F));
            tableLayoutPanelBottom.RowCount = 1;
            tableLayoutPanelBottom.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelBottom.Controls.Add(groupBoxChart, 0, 0);
            tableLayoutPanelBottom.Controls.Add(groupBoxTop5, 1, 0);
            //
            // groupBoxChart
            //
            groupBoxChart.Location = new Point(0, 0);
            groupBoxChart.Name = "groupBoxChart";
            groupBoxChart.Size = new Size(530, 330);
            groupBoxChart.Text = "Doanh thu theo ngày (VNĐ)";
            groupBoxChart.TabIndex = 39;
            groupBoxChart.BackColor = Color.White;
            groupBoxChart.ForeColor = Color.FromArgb(22, 54, 90);
            groupBoxChart.Padding = new Padding(12);
            groupBoxChart.TabStop = false;
            groupBoxChart.Dock = DockStyle.Fill;
            groupBoxChart.Margin = new Padding(0, 0, 8, 0);
            groupBoxChart.Controls.Add(chartRevenue);
            //
            // chartRevenue
            //
            chartRevenue.Name = "chartRevenue";
            chartRevenue.Dock = DockStyle.Fill;
            chartRevenue.TabIndex = 40;
            chartRevenue.BackColor = Color.White;
            chartRevenue.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.BrightPastel;
            chartArea1.Name = "ChartArea1";
            chartArea1.BackColor = Color.White;
            chartArea1.AxisX.LabelStyle.Font = new Font("Segoe UI", 9F);
            chartArea1.AxisX.LabelStyle.ForeColor = Color.FromArgb(22, 54, 90);
            chartArea1.AxisY.LabelStyle.Font = new Font("Segoe UI", 9F);
            chartArea1.AxisY.LabelStyle.ForeColor = Color.FromArgb(22, 54, 90);
            chartArea1.AxisY.MajorGrid.LineColor = Color.FromArgb(232, 239, 250);
            chartRevenue.ChartAreas.Add(chartArea1);
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            series1.Name = "Doanh thu";
            series1.Color = Color.FromArgb(37, 99, 235);
            chartRevenue.Series.Add(series1);
            //
            // groupBoxTop5
            //
            groupBoxTop5.Location = new Point(0, 0);
            groupBoxTop5.Name = "groupBoxTop5";
            groupBoxTop5.Size = new Size(386, 330);
            groupBoxTop5.Text = "Top 5 sản phẩm bán chạy";
            groupBoxTop5.TabIndex = 41;
            groupBoxTop5.BackColor = Color.White;
            groupBoxTop5.ForeColor = Color.FromArgb(22, 54, 90);
            groupBoxTop5.Padding = new Padding(12);
            groupBoxTop5.TabStop = false;
            groupBoxTop5.Dock = DockStyle.Fill;
            groupBoxTop5.Margin = new Padding(8, 0, 0, 0);
            groupBoxTop5.Controls.Add(dgvTopProducts);
            tabDaily.Controls.Add(layoutDaily);
            //
            // layoutDaily
            //
            layoutDaily.Name = "layoutDaily";
            layoutDaily.Dock = DockStyle.Fill;
            layoutDaily.TabIndex = 72;
            layoutDaily.BackColor = Color.FromArgb(242, 245, 250);
            layoutDaily.Margin = new Padding(0);
            layoutDaily.ColumnCount = 1;
            layoutDaily.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutDaily.RowCount = 4;
            layoutDaily.RowStyles.Add(new RowStyle(SizeType.Absolute, 92F));
            layoutDaily.RowStyles.Add(new RowStyle(SizeType.Absolute, 136F));
            layoutDaily.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            layoutDaily.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutDaily.Controls.Add(groupDailyFilter, 0, 0);
            layoutDaily.Controls.Add(layoutDailyCards, 0, 1);
            layoutDaily.Controls.Add(lblDailySummary, 0, 2);
            layoutDaily.Controls.Add(dgvDailyCashiers, 0, 3);
            //
            // groupDailyFilter
            //
            groupDailyFilter.Location = new Point(0, 0);
            groupDailyFilter.Name = "groupDailyFilter";
            groupDailyFilter.Size = new Size(950, 80);
            groupDailyFilter.Text = "Chọn kỳ doanh thu";
            groupDailyFilter.TabIndex = 73;
            groupDailyFilter.BackColor = Color.White;
            groupDailyFilter.ForeColor = Color.FromArgb(22, 54, 90);
            groupDailyFilter.Padding = new Padding(12);
            groupDailyFilter.TabStop = false;
            groupDailyFilter.Dock = DockStyle.Fill;
            groupDailyFilter.Margin = new Padding(0, 0, 0, 12);
            //
            // labelDailyPeriod
            //
            labelDailyPeriod.Location = new Point(16, 32);
            labelDailyPeriod.Name = "labelDailyPeriod";
            labelDailyPeriod.Size = new Size(82, 28);
            labelDailyPeriod.Text = "Kỳ:";
            labelDailyPeriod.TabIndex = 74;
            labelDailyPeriod.AutoSize = false;
            labelDailyPeriod.ForeColor = Color.FromArgb(22, 54, 90);
            labelDailyPeriod.TextAlign = ContentAlignment.MiddleLeft;
            //
            // cmbDailyPeriod
            //
            cmbDailyPeriod.Location = new Point(104, 32);
            cmbDailyPeriod.Name = "cmbDailyPeriod";
            cmbDailyPeriod.Size = new Size(140, 28);
            cmbDailyPeriod.TabIndex = 75;
            cmbDailyPeriod.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDailyPeriod.FormattingEnabled = true;
            cmbDailyPeriod.Items.AddRange(new object[] { "Ngày", "Tuần", "Tháng", "Năm" });
            //
            // labelDailyAnchor
            //
            labelDailyAnchor.Location = new Point(254, 32);
            labelDailyAnchor.Name = "labelDailyAnchor";
            labelDailyAnchor.Size = new Size(126, 28);
            labelDailyAnchor.Text = "Mốc ngày:";
            labelDailyAnchor.TabIndex = 76;
            labelDailyAnchor.AutoSize = false;
            labelDailyAnchor.ForeColor = Color.FromArgb(22, 54, 90);
            labelDailyAnchor.TextAlign = ContentAlignment.MiddleLeft;
            //
            // dtpDaily
            //
            dtpDaily.Location = new Point(390, 32);
            dtpDaily.Name = "dtpDaily";
            dtpDaily.Size = new Size(140, 28);
            dtpDaily.TabIndex = 77;
            dtpDaily.Format = DateTimePickerFormat.Custom;
            dtpDaily.CustomFormat = "dd/MM/yyyy";
            dtpDaily.CalendarForeColor = Color.FromArgb(22, 54, 90);
            dtpDaily.CalendarTitleBackColor = Color.FromArgb(232, 239, 250);
            //
            // btnLoadDaily
            //
            btnLoadDaily.Location = new Point(542, 28);
            btnLoadDaily.Name = "btnLoadDaily";
            btnLoadDaily.Size = new Size(130, 36);
            btnLoadDaily.Text = "Xem báo cáo";
            btnLoadDaily.TabIndex = 78;
            btnLoadDaily.BackColor = Color.FromArgb(37, 99, 235);
            btnLoadDaily.ForeColor = Color.White;
            btnLoadDaily.FlatStyle = FlatStyle.Flat;
            btnLoadDaily.FlatAppearance.BorderSize = 0;
            btnLoadDaily.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnLoadDaily.UseVisualStyleBackColor = false;
            btnLoadDaily.Cursor = Cursors.Hand;
            groupDailyFilter.Controls.Add(labelDailyPeriod);
            groupDailyFilter.Controls.Add(cmbDailyPeriod);
            groupDailyFilter.Controls.Add(labelDailyAnchor);
            groupDailyFilter.Controls.Add(dtpDaily);
            groupDailyFilter.Controls.Add(btnLoadDaily);
            //
            // layoutDailyCards
            //
            layoutDailyCards.Name = "layoutDailyCards";
            layoutDailyCards.Dock = DockStyle.Fill;
            layoutDailyCards.TabIndex = 80;
            layoutDailyCards.BackColor = Color.FromArgb(242, 245, 250);
            layoutDailyCards.Margin = new Padding(0);
            layoutDailyCards.ColumnCount = 3;
            layoutDailyCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            layoutDailyCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23F));
            layoutDailyCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 44F));
            layoutDailyCards.RowCount = 1;
            layoutDailyCards.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutDailyCards.Controls.Add(panelDailyRevenue, 0, 0);
            //
            // panelDailyRevenue
            //
            panelDailyRevenue.Name = "panelDailyRevenue";
            panelDailyRevenue.Dock = DockStyle.Fill;
            panelDailyRevenue.TabIndex = 81;
            panelDailyRevenue.BackColor = Color.White;
            panelDailyRevenue.BorderStyle = BorderStyle.FixedSingle;
            panelDailyRevenue.Padding = new Padding(12);
            panelDailyRevenue.Margin = new Padding(0, 0, 12, 0);
            //
            // labelDailyRevenue
            //
            labelDailyRevenue.Name = "labelDailyRevenue";
            labelDailyRevenue.Size = new Size(230, 32);
            labelDailyRevenue.Text = "TỔNG DOANH THU";
            labelDailyRevenue.Dock = DockStyle.Top;
            labelDailyRevenue.TabIndex = 82;
            labelDailyRevenue.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labelDailyRevenue.ForeColor = Color.FromArgb(22, 54, 90);
            //
            // lblDailyRevenue
            //
            lblDailyRevenue.Name = "lblDailyRevenue";
            lblDailyRevenue.Text = "—";
            lblDailyRevenue.Dock = DockStyle.Fill;
            lblDailyRevenue.TabIndex = 83;
            lblDailyRevenue.Font = new Font("Segoe UI", 19F, FontStyle.Bold, GraphicsUnit.Point);
            lblDailyRevenue.ForeColor = Color.FromArgb(22, 54, 90);
            lblDailyRevenue.TextAlign = ContentAlignment.MiddleLeft;
            panelDailyRevenue.Controls.Add(lblDailyRevenue);
            panelDailyRevenue.Controls.Add(labelDailyRevenue);
            layoutDailyCards.Controls.Add(panelDailyOrders, 1, 0);
            //
            // panelDailyOrders
            //
            panelDailyOrders.Name = "panelDailyOrders";
            panelDailyOrders.Dock = DockStyle.Fill;
            panelDailyOrders.TabIndex = 84;
            panelDailyOrders.BackColor = Color.White;
            panelDailyOrders.BorderStyle = BorderStyle.FixedSingle;
            panelDailyOrders.Padding = new Padding(12);
            panelDailyOrders.Margin = new Padding(0, 0, 12, 0);
            //
            // labelDailyOrders
            //
            labelDailyOrders.Name = "labelDailyOrders";
            labelDailyOrders.Size = new Size(230, 32);
            labelDailyOrders.Text = "SỐ HÓA ĐƠN";
            labelDailyOrders.Dock = DockStyle.Top;
            labelDailyOrders.TabIndex = 85;
            labelDailyOrders.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labelDailyOrders.ForeColor = Color.FromArgb(22, 54, 90);
            //
            // lblDailyOrders
            //
            lblDailyOrders.Name = "lblDailyOrders";
            lblDailyOrders.Text = "—";
            lblDailyOrders.Dock = DockStyle.Fill;
            lblDailyOrders.TabIndex = 86;
            lblDailyOrders.Font = new Font("Segoe UI", 21F, FontStyle.Bold, GraphicsUnit.Point);
            lblDailyOrders.ForeColor = Color.FromArgb(22, 54, 90);
            lblDailyOrders.TextAlign = ContentAlignment.MiddleLeft;
            panelDailyOrders.Controls.Add(lblDailyOrders);
            panelDailyOrders.Controls.Add(labelDailyOrders);
            layoutDailyCards.Controls.Add(panelDailyBestSeller, 2, 0);
            //
            // panelDailyBestSeller
            //
            panelDailyBestSeller.Name = "panelDailyBestSeller";
            panelDailyBestSeller.Dock = DockStyle.Fill;
            panelDailyBestSeller.TabIndex = 87;
            panelDailyBestSeller.BackColor = Color.White;
            panelDailyBestSeller.BorderStyle = BorderStyle.FixedSingle;
            panelDailyBestSeller.Padding = new Padding(12);
            panelDailyBestSeller.Margin = new Padding(0);
            //
            // labelDailyBestSeller
            //
            labelDailyBestSeller.Name = "labelDailyBestSeller";
            labelDailyBestSeller.Size = new Size(230, 32);
            labelDailyBestSeller.Text = "SẢN PHẨM BÁN CHẠY";
            labelDailyBestSeller.Dock = DockStyle.Top;
            labelDailyBestSeller.TabIndex = 88;
            labelDailyBestSeller.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labelDailyBestSeller.ForeColor = Color.FromArgb(22, 54, 90);
            //
            // lblDailyBestSeller
            //
            lblDailyBestSeller.Name = "lblDailyBestSeller";
            lblDailyBestSeller.Text = "—";
            lblDailyBestSeller.Dock = DockStyle.Fill;
            lblDailyBestSeller.TabIndex = 89;
            lblDailyBestSeller.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lblDailyBestSeller.ForeColor = Color.FromArgb(22, 54, 90);
            lblDailyBestSeller.TextAlign = ContentAlignment.MiddleLeft;
            panelDailyBestSeller.Controls.Add(lblDailyBestSeller);
            panelDailyBestSeller.Controls.Add(labelDailyBestSeller);
            //
            // lblDailySummary
            //
            lblDailySummary.Location = new Point(0, 0);
            lblDailySummary.Name = "lblDailySummary";
            lblDailySummary.Size = new Size(940, 48);
            lblDailySummary.Text = "Doanh thu và số đơn theo thu ngân trong kỳ.";
            lblDailySummary.TabIndex = 90;
            lblDailySummary.AutoSize = false;
            lblDailySummary.ForeColor = Color.FromArgb(22, 54, 90);
            lblDailySummary.TextAlign = ContentAlignment.MiddleLeft;
            lblDailySummary.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblDailySummary.Dock = DockStyle.Fill;
            lblDailySummary.AutoEllipsis = true;
            lblDailySummary.Margin = new Padding(0, 4, 0, 4);
            tabCashiers.Controls.Add(layoutCashiers);
            //
            // layoutCashiers
            //
            layoutCashiers.Name = "layoutCashiers";
            layoutCashiers.Dock = DockStyle.Fill;
            layoutCashiers.TabIndex = 96;
            layoutCashiers.BackColor = Color.FromArgb(242, 245, 250);
            layoutCashiers.Margin = new Padding(0);
            layoutCashiers.ColumnCount = 1;
            layoutCashiers.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutCashiers.RowCount = 3;
            layoutCashiers.RowStyles.Add(new RowStyle(SizeType.Absolute, 160F));
            layoutCashiers.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
            layoutCashiers.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutCashiers.Controls.Add(groupCashierFilter, 0, 0);
            layoutCashiers.Controls.Add(lblCashierSummary, 0, 1);
            layoutCashiers.Controls.Add(dgvCashiers, 0, 2);
            //
            // groupCashierFilter
            //
            groupCashierFilter.Location = new Point(0, 0);
            groupCashierFilter.Name = "groupCashierFilter";
            groupCashierFilter.Size = new Size(950, 148);
            groupCashierFilter.Text = "Doanh thu theo thu ngân";
            groupCashierFilter.TabIndex = 97;
            groupCashierFilter.BackColor = Color.White;
            groupCashierFilter.ForeColor = Color.FromArgb(22, 54, 90);
            groupCashierFilter.Padding = new Padding(12);
            groupCashierFilter.TabStop = false;
            groupCashierFilter.Dock = DockStyle.Fill;
            groupCashierFilter.Margin = new Padding(0, 0, 0, 12);
            //
            // labelCashierPeriod
            //
            labelCashierPeriod.Location = new Point(16, 28);
            labelCashierPeriod.Name = "labelCashierPeriod";
            labelCashierPeriod.Size = new Size(82, 28);
            labelCashierPeriod.Text = "Kỳ:";
            labelCashierPeriod.TabIndex = 98;
            labelCashierPeriod.AutoSize = false;
            labelCashierPeriod.ForeColor = Color.FromArgb(22, 54, 90);
            labelCashierPeriod.TextAlign = ContentAlignment.MiddleLeft;
            //
            // cmbCashierPeriod
            //
            cmbCashierPeriod.Location = new Point(104, 28);
            cmbCashierPeriod.Name = "cmbCashierPeriod";
            cmbCashierPeriod.Size = new Size(140, 28);
            cmbCashierPeriod.TabIndex = 99;
            cmbCashierPeriod.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCashierPeriod.FormattingEnabled = true;
            cmbCashierPeriod.Items.AddRange(new object[] { "Ngày", "Tuần", "Tháng", "Năm", "Tùy chọn" });
            //
            // labelCashierAnchor
            //
            labelCashierAnchor.Location = new Point(258, 28);
            labelCashierAnchor.Name = "labelCashierAnchor";
            labelCashierAnchor.Size = new Size(126, 28);
            labelCashierAnchor.Text = "Mốc ngày:";
            labelCashierAnchor.TabIndex = 100;
            labelCashierAnchor.AutoSize = false;
            labelCashierAnchor.ForeColor = Color.FromArgb(22, 54, 90);
            labelCashierAnchor.TextAlign = ContentAlignment.MiddleLeft;
            //
            // dtpCashierAnchor
            //
            dtpCashierAnchor.Location = new Point(394, 28);
            dtpCashierAnchor.Name = "dtpCashierAnchor";
            dtpCashierAnchor.Size = new Size(140, 28);
            dtpCashierAnchor.TabIndex = 101;
            dtpCashierAnchor.Format = DateTimePickerFormat.Custom;
            dtpCashierAnchor.CustomFormat = "dd/MM/yyyy";
            dtpCashierAnchor.CalendarForeColor = Color.FromArgb(22, 54, 90);
            dtpCashierAnchor.CalendarTitleBackColor = Color.FromArgb(232, 239, 250);
            //
            // btnLoadCashiers
            //
            btnLoadCashiers.Location = new Point(554, 24);
            btnLoadCashiers.Name = "btnLoadCashiers";
            btnLoadCashiers.Size = new Size(164, 36);
            btnLoadCashiers.Text = "Xem doanh thu";
            btnLoadCashiers.TabIndex = 106;
            btnLoadCashiers.BackColor = Color.FromArgb(37, 99, 235);
            btnLoadCashiers.ForeColor = Color.White;
            btnLoadCashiers.FlatStyle = FlatStyle.Flat;
            btnLoadCashiers.FlatAppearance.BorderSize = 0;
            btnLoadCashiers.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnLoadCashiers.UseVisualStyleBackColor = false;
            btnLoadCashiers.Cursor = Cursors.Hand;
            //
            // labelCashierFrom
            //
            labelCashierFrom.Location = new Point(16, 67);
            labelCashierFrom.Name = "labelCashierFrom";
            labelCashierFrom.Size = new Size(74, 28);
            labelCashierFrom.Text = "Từ:";
            labelCashierFrom.TabIndex = 102;
            labelCashierFrom.AutoSize = false;
            labelCashierFrom.ForeColor = Color.FromArgb(22, 54, 90);
            labelCashierFrom.TextAlign = ContentAlignment.MiddleLeft;
            //
            // dtpCashierFrom
            //
            dtpCashierFrom.Location = new Point(98, 67);
            dtpCashierFrom.Name = "dtpCashierFrom";
            dtpCashierFrom.Size = new Size(140, 28);
            dtpCashierFrom.TabIndex = 103;
            dtpCashierFrom.Format = DateTimePickerFormat.Custom;
            dtpCashierFrom.CustomFormat = "dd/MM/yyyy";
            dtpCashierFrom.CalendarForeColor = Color.FromArgb(22, 54, 90);
            dtpCashierFrom.CalendarTitleBackColor = Color.FromArgb(232, 239, 250);
            //
            // labelCashierTo
            //
            labelCashierTo.Location = new Point(258, 67);
            labelCashierTo.Name = "labelCashierTo";
            labelCashierTo.Size = new Size(126, 28);
            labelCashierTo.Text = "Đến:";
            labelCashierTo.TabIndex = 104;
            labelCashierTo.AutoSize = false;
            labelCashierTo.ForeColor = Color.FromArgb(22, 54, 90);
            labelCashierTo.TextAlign = ContentAlignment.MiddleLeft;
            //
            // dtpCashierTo
            //
            dtpCashierTo.Location = new Point(394, 67);
            dtpCashierTo.Name = "dtpCashierTo";
            dtpCashierTo.Size = new Size(140, 28);
            dtpCashierTo.TabIndex = 105;
            dtpCashierTo.Format = DateTimePickerFormat.Custom;
            dtpCashierTo.CustomFormat = "dd/MM/yyyy";
            dtpCashierTo.CalendarForeColor = Color.FromArgb(22, 54, 90);
            dtpCashierTo.CalendarTitleBackColor = Color.FromArgb(232, 239, 250);
            //
            // chkAllCashierHistory
            //
            chkAllCashierHistory.Location = new Point(16, 108);
            chkAllCashierHistory.Name = "chkAllCashierHistory";
            chkAllCashierHistory.Size = new Size(370, 28);
            chkAllCashierHistory.Text = "Toàn bộ lịch sử bán hàng";
            chkAllCashierHistory.TabIndex = 107;
            chkAllCashierHistory.AutoSize = true;
            chkAllCashierHistory.UseVisualStyleBackColor = true;
            groupCashierFilter.Controls.Add(labelCashierPeriod);
            groupCashierFilter.Controls.Add(cmbCashierPeriod);
            groupCashierFilter.Controls.Add(labelCashierAnchor);
            groupCashierFilter.Controls.Add(dtpCashierAnchor);
            groupCashierFilter.Controls.Add(btnLoadCashiers);
            groupCashierFilter.Controls.Add(labelCashierFrom);
            groupCashierFilter.Controls.Add(dtpCashierFrom);
            groupCashierFilter.Controls.Add(labelCashierTo);
            groupCashierFilter.Controls.Add(dtpCashierTo);
            groupCashierFilter.Controls.Add(chkAllCashierHistory);
            //
            // lblCashierSummary
            //
            lblCashierSummary.Location = new Point(0, 0);
            lblCashierSummary.Name = "lblCashierSummary";
            lblCashierSummary.Size = new Size(940, 48);
            lblCashierSummary.Text = "Chọn khoảng thời gian để xem doanh thu theo thu ngân.";
            lblCashierSummary.TabIndex = 108;
            lblCashierSummary.AutoSize = false;
            lblCashierSummary.ForeColor = Color.FromArgb(22, 54, 90);
            lblCashierSummary.TextAlign = ContentAlignment.MiddleLeft;
            lblCashierSummary.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblCashierSummary.Dock = DockStyle.Fill;
            lblCashierSummary.AutoEllipsis = true;
            lblCashierSummary.Margin = new Padding(0, 4, 0, 4);
            //
            // dgvTopProducts
            //
            dgvTopProducts.Name = "dgvTopProducts";
            dgvTopProducts.Dock = DockStyle.Fill;
            dgvTopProducts.TabIndex = 42;
            dgvTopProducts.AllowUserToAddRows = false;
            dgvTopProducts.AllowUserToDeleteRows = false;
            dgvTopProducts.AllowUserToResizeRows = false;
            dgvTopProducts.AutoGenerateColumns = false;
            dgvTopProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTopProducts.BackgroundColor = Color.White;
            dgvTopProducts.BorderStyle = BorderStyle.None;
            dgvTopProducts.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvTopProducts.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvTopProducts.ColumnHeadersHeight = 40;
            dgvTopProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvTopProducts.EnableHeadersVisualStyles = false;
            dgvTopProducts.GridColor = Color.FromArgb(232, 239, 250);
            dgvTopProducts.MultiSelect = false;
            dgvTopProducts.ReadOnly = true;
            dgvTopProducts.RowHeadersVisible = false;
            dgvTopProducts.RowTemplate.Height = 36;
            dgvTopProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTopProducts.Margin = new Padding(0);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(22, 54, 90);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(220, 234, 254);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(22, 54, 90);
            dataGridViewCellStyle1.Padding = new Padding(8, 0, 8, 0);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(22, 54, 90);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(220, 234, 254);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(22, 54, 90);
            dataGridViewCellStyle2.Padding = new Padding(8, 0, 8, 0);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(22, 54, 90);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(220, 234, 254);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(22, 54, 90);
            dataGridViewCellStyle3.Padding = new Padding(8, 0, 8, 0);
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(232, 239, 250);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(248, 250, 253);
            dgvTopProducts.DefaultCellStyle = dataGridViewCellStyle1;
            dgvTopProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvTopProducts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            dgvTopProducts.Columns.AddRange(new DataGridViewColumn[] { colRank, colProductName, colTotalSold });
            //
            // colRank
            //
            colRank.Name = "colRank";
            colRank.HeaderText = "Hạng";
            colRank.FillWeight = 15F;
            colRank.MinimumWidth = 55;
            colRank.ReadOnly = true;
            //
            // colProductName
            //
            colProductName.Name = "colProductName";
            colProductName.HeaderText = "Tên sản phẩm";
            colProductName.FillWeight = 60F;
            colProductName.MinimumWidth = 150;
            colProductName.ReadOnly = true;
            //
            // colTotalSold
            //
            colTotalSold.Name = "colTotalSold";
            colTotalSold.HeaderText = "Đã bán";
            colTotalSold.FillWeight = 25F;
            colTotalSold.MinimumWidth = 75;
            colTotalSold.ReadOnly = true;
            colTotalSold.DefaultCellStyle.Format = "N0";
            colTotalSold.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //
            // dgvDailyCashiers
            //
            dgvDailyCashiers.Name = "dgvDailyCashiers";
            dgvDailyCashiers.Dock = DockStyle.Fill;
            dgvDailyCashiers.TabIndex = 91;
            dgvDailyCashiers.AllowUserToAddRows = false;
            dgvDailyCashiers.AllowUserToDeleteRows = false;
            dgvDailyCashiers.AllowUserToResizeRows = false;
            dgvDailyCashiers.AutoGenerateColumns = false;
            dgvDailyCashiers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDailyCashiers.BackgroundColor = Color.White;
            dgvDailyCashiers.BorderStyle = BorderStyle.None;
            dgvDailyCashiers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvDailyCashiers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvDailyCashiers.ColumnHeadersHeight = 40;
            dgvDailyCashiers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvDailyCashiers.EnableHeadersVisualStyles = false;
            dgvDailyCashiers.GridColor = Color.FromArgb(232, 239, 250);
            dgvDailyCashiers.MultiSelect = false;
            dgvDailyCashiers.ReadOnly = true;
            dgvDailyCashiers.RowHeadersVisible = false;
            dgvDailyCashiers.RowTemplate.Height = 36;
            dgvDailyCashiers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDailyCashiers.Margin = new Padding(0);
            dataGridViewCellStyle10.ForeColor = Color.FromArgb(22, 54, 90);
            dataGridViewCellStyle10.SelectionBackColor = Color.FromArgb(220, 234, 254);
            dataGridViewCellStyle10.SelectionForeColor = Color.FromArgb(22, 54, 90);
            dataGridViewCellStyle10.Padding = new Padding(8, 0, 8, 0);
            dataGridViewCellStyle11.ForeColor = Color.FromArgb(22, 54, 90);
            dataGridViewCellStyle11.SelectionBackColor = Color.FromArgb(220, 234, 254);
            dataGridViewCellStyle11.SelectionForeColor = Color.FromArgb(22, 54, 90);
            dataGridViewCellStyle11.Padding = new Padding(8, 0, 8, 0);
            dataGridViewCellStyle12.ForeColor = Color.FromArgb(22, 54, 90);
            dataGridViewCellStyle12.SelectionBackColor = Color.FromArgb(220, 234, 254);
            dataGridViewCellStyle12.SelectionForeColor = Color.FromArgb(22, 54, 90);
            dataGridViewCellStyle12.Padding = new Padding(8, 0, 8, 0);
            dataGridViewCellStyle10.BackColor = Color.White;
            dataGridViewCellStyle10.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.False;
            dataGridViewCellStyle11.BackColor = Color.FromArgb(232, 239, 250);
            dataGridViewCellStyle11.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle11.WrapMode = DataGridViewTriState.False;
            dataGridViewCellStyle12.BackColor = Color.FromArgb(248, 250, 253);
            dgvDailyCashiers.DefaultCellStyle = dataGridViewCellStyle10;
            dgvDailyCashiers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            dgvDailyCashiers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle12;
            dgvDailyCashiers.Columns.AddRange(new DataGridViewColumn[] { colDailyCashier, colDailyOrders, colDailyRevenue, colDailyPoints });
            //
            // colDailyCashier
            //
            colDailyCashier.Name = "colDailyCashier";
            colDailyCashier.HeaderText = "Thu ngân";
            colDailyCashier.DataPropertyName = "CashierUsername";
            colDailyCashier.FillWeight = 30F;
            colDailyCashier.MinimumWidth = 170;
            colDailyCashier.ReadOnly = true;
            //
            // colDailyOrders
            //
            colDailyOrders.Name = "colDailyOrders";
            colDailyOrders.HeaderText = "Số hóa đơn";
            colDailyOrders.DataPropertyName = "TotalOrders";
            colDailyOrders.FillWeight = 20F;
            colDailyOrders.MinimumWidth = 120;
            colDailyOrders.ReadOnly = true;
            colDailyOrders.DefaultCellStyle.Format = "N0";
            colDailyOrders.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //
            // colDailyRevenue
            //
            colDailyRevenue.Name = "colDailyRevenue";
            colDailyRevenue.HeaderText = "Doanh thu (đ)";
            colDailyRevenue.DataPropertyName = "TotalRevenue";
            colDailyRevenue.FillWeight = 30F;
            colDailyRevenue.MinimumWidth = 170;
            colDailyRevenue.ReadOnly = true;
            colDailyRevenue.DefaultCellStyle.Format = "N0";
            colDailyRevenue.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //
            // colDailyPoints
            //
            colDailyPoints.Name = "colDailyPoints";
            colDailyPoints.HeaderText = "Điểm tích lũy";
            colDailyPoints.DataPropertyName = "TotalPointsAwarded";
            colDailyPoints.FillWeight = 20F;
            colDailyPoints.MinimumWidth = 145;
            colDailyPoints.ReadOnly = true;
            colDailyPoints.DefaultCellStyle.Format = "N0";
            colDailyPoints.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //
            // dgvCashiers
            //
            dgvCashiers.Name = "dgvCashiers";
            dgvCashiers.Dock = DockStyle.Fill;
            dgvCashiers.TabIndex = 109;
            dgvCashiers.AllowUserToAddRows = false;
            dgvCashiers.AllowUserToDeleteRows = false;
            dgvCashiers.AllowUserToResizeRows = false;
            dgvCashiers.AutoGenerateColumns = false;
            dgvCashiers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCashiers.BackgroundColor = Color.White;
            dgvCashiers.BorderStyle = BorderStyle.None;
            dgvCashiers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCashiers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvCashiers.ColumnHeadersHeight = 40;
            dgvCashiers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvCashiers.EnableHeadersVisualStyles = false;
            dgvCashiers.GridColor = Color.FromArgb(232, 239, 250);
            dgvCashiers.MultiSelect = false;
            dgvCashiers.ReadOnly = true;
            dgvCashiers.RowHeadersVisible = false;
            dgvCashiers.RowTemplate.Height = 36;
            dgvCashiers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCashiers.Margin = new Padding(0);
            dataGridViewCellStyle13.ForeColor = Color.FromArgb(22, 54, 90);
            dataGridViewCellStyle13.SelectionBackColor = Color.FromArgb(220, 234, 254);
            dataGridViewCellStyle13.SelectionForeColor = Color.FromArgb(22, 54, 90);
            dataGridViewCellStyle13.Padding = new Padding(8, 0, 8, 0);
            dataGridViewCellStyle14.ForeColor = Color.FromArgb(22, 54, 90);
            dataGridViewCellStyle14.SelectionBackColor = Color.FromArgb(220, 234, 254);
            dataGridViewCellStyle14.SelectionForeColor = Color.FromArgb(22, 54, 90);
            dataGridViewCellStyle14.Padding = new Padding(8, 0, 8, 0);
            dataGridViewCellStyle15.ForeColor = Color.FromArgb(22, 54, 90);
            dataGridViewCellStyle15.SelectionBackColor = Color.FromArgb(220, 234, 254);
            dataGridViewCellStyle15.SelectionForeColor = Color.FromArgb(22, 54, 90);
            dataGridViewCellStyle15.Padding = new Padding(8, 0, 8, 0);
            dataGridViewCellStyle13.BackColor = Color.White;
            dataGridViewCellStyle13.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle13.WrapMode = DataGridViewTriState.False;
            dataGridViewCellStyle14.BackColor = Color.FromArgb(232, 239, 250);
            dataGridViewCellStyle14.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle14.WrapMode = DataGridViewTriState.False;
            dataGridViewCellStyle15.BackColor = Color.FromArgb(248, 250, 253);
            dgvCashiers.DefaultCellStyle = dataGridViewCellStyle13;
            dgvCashiers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            dgvCashiers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle15;
            dgvCashiers.Columns.AddRange(new DataGridViewColumn[] { colCashierUsername, colCashierOrders, colCashierRevenue, colCashierPoints });
            //
            // colCashierUsername
            //
            colCashierUsername.Name = "colCashierUsername";
            colCashierUsername.HeaderText = "Thu ngân";
            colCashierUsername.DataPropertyName = "CashierUsername";
            colCashierUsername.FillWeight = 30F;
            colCashierUsername.MinimumWidth = 170;
            colCashierUsername.ReadOnly = true;
            //
            // colCashierOrders
            //
            colCashierOrders.Name = "colCashierOrders";
            colCashierOrders.HeaderText = "Số hóa đơn";
            colCashierOrders.DataPropertyName = "TotalOrders";
            colCashierOrders.FillWeight = 20F;
            colCashierOrders.MinimumWidth = 120;
            colCashierOrders.ReadOnly = true;
            colCashierOrders.DefaultCellStyle.Format = "N0";
            colCashierOrders.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //
            // colCashierRevenue
            //
            colCashierRevenue.Name = "colCashierRevenue";
            colCashierRevenue.HeaderText = "Doanh thu (đ)";
            colCashierRevenue.DataPropertyName = "TotalRevenue";
            colCashierRevenue.FillWeight = 30F;
            colCashierRevenue.MinimumWidth = 170;
            colCashierRevenue.ReadOnly = true;
            colCashierRevenue.DefaultCellStyle.Format = "N0";
            colCashierRevenue.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //
            // colCashierPoints
            //
            colCashierPoints.Name = "colCashierPoints";
            colCashierPoints.HeaderText = "Điểm tích lũy";
            colCashierPoints.DataPropertyName = "TotalPointsAwarded";
            colCashierPoints.FillWeight = 20F;
            colCashierPoints.MinimumWidth = 145;
            colCashierPoints.ReadOnly = true;
            colCashierPoints.DefaultCellStyle.Format = "N0";
            colCashierPoints.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            tabReports.SelectedIndexChanged += tabReports_SelectedIndexChanged;
            btnRunReport.Click += btnRunReport_Click;
            btnExportProducts.Click += btnExportProducts_Click;
            btnExportRevenue.Click += btnExportRevenue_Click;
            btnLoadDaily.Click += btnLoadDaily_Click;
            btnLoadCashiers.Click += btnLoadCashiers_Click;
            chkAllCashierHistory.CheckedChanged += chkAllCashierHistory_CheckedChanged;
            cmbOverviewPeriod.SelectedIndexChanged += cmbOverviewPeriod_SelectedIndexChanged;
            dtpOverviewAnchor.ValueChanged += dtpOverviewAnchor_ValueChanged;
            cmbDailyPeriod.SelectedIndexChanged += cmbDailyPeriod_SelectedIndexChanged;
            dtpDaily.ValueChanged += dtpDaily_ValueChanged;
            cmbCashierPeriod.SelectedIndexChanged += cmbCashierPeriod_SelectedIndexChanged;
            dtpCashierAnchor.ValueChanged += dtpCashierAnchor_ValueChanged;
            dtpFromDate.ValueChanged += dtpFromDate_ValueChanged;
            dtpToDate.ValueChanged += dtpToDate_ValueChanged;
            //
            // FormQuickReport
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(242, 245, 250);
            ClientSize = new Size(1030, 613);
            Controls.Add(tabReports);
            Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ForeColor = Color.FromArgb(22, 54, 90);
            MinimumSize = new Size(900, 560);
            Name = "FormQuickReport";
            Padding = new Padding(12);
            Text = "Báo cáo doanh thu";
            Load += FormQuickReport_Load;
            FormClosed += FormQuickReport_FormClosed;
            groupCashierFilter.ResumeLayout(false);
            groupCashierFilter.PerformLayout();
            layoutCashiers.ResumeLayout(false);
            panelDailyBestSeller.ResumeLayout(false);
            panelDailyOrders.ResumeLayout(false);
            panelDailyRevenue.ResumeLayout(false);
            layoutDailyCards.ResumeLayout(false);
            groupDailyFilter.ResumeLayout(false);
            groupDailyFilter.PerformLayout();
            layoutDaily.ResumeLayout(false);
            groupBoxTop5.ResumeLayout(false);
            groupBoxChart.ResumeLayout(false);
            tableLayoutPanelBottom.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            tableLayoutPanelSummary.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            tabCashiers.ResumeLayout(false);
            tabDaily.ResumeLayout(false);
            tabOverview.ResumeLayout(false);
            tabReports.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTopProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDailyCashiers).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCashiers).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartRevenue).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartCashierShare).EndInit();
            groupCashierChart.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupCashierChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCashierShare;
        private Label lblCashierChartEmpty;
        private TabControl tabReports;
        private TabPage tabOverview;
        private TabPage tabDaily;
        private TabPage tabCashiers;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label labelOverviewPeriod;
        private ComboBox cmbOverviewPeriod;
        private Label labelOverviewAnchor;
        private DateTimePicker dtpOverviewAnchor;
        private Label label1;
        private DateTimePicker dtpFromDate;
        private Label label3;
        private DateTimePicker dtpToDate;
        private Button btnRunReport;
        private Button btnExportProducts;
        private Button btnExportRevenue;
        private GroupBox groupBox3;
        private FlowLayoutPanel tableLayoutPanelSummary;
        private Panel panel1;
        private Label label2;
        private Label lblTotalOrders;
        private Label lblOrdersToday;
        private Panel panel2;
        private Label label4;
        private Label lblTotalRevenue;
        private Label lblRevenueToday;
        private Panel panel3;
        private Label label6;
        private Label lblBestSeller;
        private Panel panel4;
        private Label label7;
        private Label lblNewCustomers;
        private Panel panel5;
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
        private TableLayoutPanel layoutDaily;
        private GroupBox groupDailyFilter;
        private Label labelDailyPeriod;
        private ComboBox cmbDailyPeriod;
        private Label labelDailyAnchor;
        private DateTimePicker dtpDaily;
        private Button btnLoadDaily;
        private TableLayoutPanel layoutDailyCards;
        private Panel panelDailyRevenue;
        private Label labelDailyRevenue;
        private Label lblDailyRevenue;
        private Panel panelDailyOrders;
        private Label labelDailyOrders;
        private Label lblDailyOrders;
        private Panel panelDailyBestSeller;
        private Label labelDailyBestSeller;
        private Label lblDailyBestSeller;
        private Label lblDailySummary;
        private DataGridView dgvDailyCashiers;
        private DataGridViewTextBoxColumn colDailyCashier;
        private DataGridViewTextBoxColumn colDailyOrders;
        private DataGridViewTextBoxColumn colDailyRevenue;
        private DataGridViewTextBoxColumn colDailyPoints;
        private TableLayoutPanel layoutCashiers;
        private GroupBox groupCashierFilter;
        private Label labelCashierPeriod;
        private ComboBox cmbCashierPeriod;
        private Label labelCashierAnchor;
        private DateTimePicker dtpCashierAnchor;
        private Label labelCashierFrom;
        private DateTimePicker dtpCashierFrom;
        private Label labelCashierTo;
        private DateTimePicker dtpCashierTo;
        private Button btnLoadCashiers;
        private CheckBox chkAllCashierHistory;
        private Label lblCashierSummary;
        private DataGridView dgvCashiers;
        private DataGridViewTextBoxColumn colCashierUsername;
        private DataGridViewTextBoxColumn colCashierOrders;
        private DataGridViewTextBoxColumn colCashierRevenue;
        private DataGridViewTextBoxColumn colCashierPoints;
    }
}
