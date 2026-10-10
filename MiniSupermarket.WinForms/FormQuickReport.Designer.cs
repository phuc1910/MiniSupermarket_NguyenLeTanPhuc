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
            dtpReportDate = new DateTimePicker();
            groupBox2 = new GroupBox();
            btnRunReport = new Button();
            groupBox3 = new GroupBox();
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
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
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
            label1.Location = new Point(6, 38);
            label1.Name = "label1";
            label1.Size = new Size(105, 20);
            label1.TabIndex = 0;
            label1.Text = "Ngày báo cáo:";
            // 
            // dtpReportDate
            // 
            dtpReportDate.Location = new Point(126, 33);
            dtpReportDate.Name = "dtpReportDate";
            dtpReportDate.Size = new Size(253, 27);
            dtpReportDate.TabIndex = 1;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnRunReport);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(dtpReportDate);
            groupBox2.Location = new Point(6, 39);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(764, 84);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Bộ lọc báo cáo";
            // 
            // btnRunReport
            // 
            btnRunReport.Location = new Point(410, 31);
            btnRunReport.Name = "btnRunReport";
            btnRunReport.Size = new Size(112, 29);
            btnRunReport.TabIndex = 2;
            btnRunReport.Text = "Xem báo cáo";
            btnRunReport.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(panel3);
            groupBox3.Controls.Add(panel2);
            groupBox3.Controls.Add(panel1);
            groupBox3.Location = new Point(6, 142);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(764, 278);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Tổng quan doanh thu";
            // 
            // panel1
            // 
            panel1.Controls.Add(lblTotalOrders);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(15, 45);
            panel1.Name = "panel1";
            panel1.Size = new Size(238, 180);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(lblTotalRevenue);
            panel2.Controls.Add(label4);
            panel2.Location = new Point(263, 45);
            panel2.Name = "panel2";
            panel2.Size = new Size(238, 180);
            panel2.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Controls.Add(lblBestSeller);
            panel3.Controls.Add(label6);
            panel3.Location = new Point(511, 45);
            panel3.Name = "panel3";
            panel3.Size = new Size(238, 180);
            panel3.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(44, 24);
            label2.Name = "label2";
            label2.Size = new Size(145, 20);
            label2.TabIndex = 0;
            label2.Text = "TỔNG SỐ HÓA ĐƠN";
            // 
            // lblTotalOrders
            // 
            lblTotalOrders.AutoSize = true;
            lblTotalOrders.Location = new Point(111, 96);
            lblTotalOrders.Name = "lblTotalOrders";
            lblTotalOrders.Size = new Size(17, 20);
            lblTotalOrders.TabIndex = 1;
            lblTotalOrders.Text = "0";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(50, 24);
            label4.Name = "label4";
            label4.Size = new Size(140, 20);
            label4.TabIndex = 0;
            label4.Text = "TỔNG DOANH THU";
            // 
            // lblTotalRevenue
            // 
            lblTotalRevenue.AutoSize = true;
            lblTotalRevenue.Location = new Point(97, 96);
            lblTotalRevenue.Name = "lblTotalRevenue";
            lblTotalRevenue.Size = new Size(30, 20);
            lblTotalRevenue.TabIndex = 1;
            lblTotalRevenue.Text = "0 đ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(17, 24);
            label6.Name = "label6";
            label6.Size = new Size(206, 20);
            label6.TabIndex = 0;
            label6.Text = "MẶT HÀNG BÁN CHẠY NHẤT";
            // 
            // lblBestSeller
            // 
            lblBestSeller.AutoSize = true;
            lblBestSeller.Location = new Point(67, 96);
            lblBestSeller.Name = "lblBestSeller";
            lblBestSeller.Size = new Size(113, 20);
            lblBestSeller.TabIndex = 1;
            lblBestSeller.Text = "Chưa có dữ liệu";
            // 
            // FormQuickReport
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox1);
            Name = "FormQuickReport";
            Text = "FormQuickReport";
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
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
        private DateTimePicker dtpReportDate;
        private Label label1;
        private Button btnRunReport;
        private GroupBox groupBox3;
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