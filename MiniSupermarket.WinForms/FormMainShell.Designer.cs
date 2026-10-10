namespace MiniSupermarket.WinForms
{
    partial class FormMainShell
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
            panelSidebar = new Panel();
            panel1 = new Panel();
            btnLogout = new Button();
            btnUserManage = new Button();
            btnProduct = new Button();
            btnCustomer = new Button();
            btnCategory = new Button();
            btnReports = new Button();
            btnPOS = new Button();
            label1 = new Label();
            panelTopHeader = new Panel();
            lblUserInfo = new Label();
            lblTitle = new Label();
            panelMainContent = new Panel();
            panelSidebar.SuspendLayout();
            panel1.SuspendLayout();
            panelTopHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.FromArgb(24, 30, 48);
            panelSidebar.Controls.Add(panel1);
            panelSidebar.Controls.Add(btnUserManage);
            panelSidebar.Controls.Add(btnProduct);
            panelSidebar.Controls.Add(btnCustomer);
            panelSidebar.Controls.Add(btnCategory);
            panelSidebar.Controls.Add(btnReports);
            panelSidebar.Controls.Add(btnPOS);
            panelSidebar.Controls.Add(label1);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(230, 673);
            panelSidebar.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnLogout);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 613);
            panel1.Name = "panel1";
            panel1.Size = new Size(230, 60);
            panel1.TabIndex = 7;
            // 
            // btnLogout
            // 
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(12, 3);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(207, 45);
            btnLogout.TabIndex = 8;
            btnLogout.Text = "🚪 Đăng xuất";
            btnLogout.TextAlign = ContentAlignment.MiddleLeft;
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnUserManage
            // 
            btnUserManage.FlatAppearance.BorderSize = 0;
            btnUserManage.FlatStyle = FlatStyle.Flat;
            btnUserManage.ForeColor = Color.White;
            btnUserManage.Location = new Point(12, 350);
            btnUserManage.Name = "btnUserManage";
            btnUserManage.Size = new Size(207, 45);
            btnUserManage.TabIndex = 6;
            btnUserManage.Text = "🛡 Quản trị Tài khoản";
            btnUserManage.TextAlign = ContentAlignment.MiddleLeft;
            btnUserManage.UseVisualStyleBackColor = true;
            btnUserManage.Click += btnUserManage_Click;
            // 
            // btnProduct
            // 
            btnProduct.FlatAppearance.BorderSize = 0;
            btnProduct.FlatStyle = FlatStyle.Flat;
            btnProduct.ForeColor = Color.White;
            btnProduct.Location = new Point(12, 185);
            btnProduct.Name = "btnProduct";
            btnProduct.Size = new Size(207, 45);
            btnProduct.TabIndex = 5;
            btnProduct.Text = "📦 Quản lý Sản phẩm";
            btnProduct.TextAlign = ContentAlignment.MiddleLeft;
            btnProduct.UseVisualStyleBackColor = true;
            btnProduct.Click += btnProduct_Click;
            // 
            // btnCustomer
            // 
            btnCustomer.FlatAppearance.BorderSize = 0;
            btnCustomer.FlatStyle = FlatStyle.Flat;
            btnCustomer.ForeColor = Color.White;
            btnCustomer.Location = new Point(12, 240);
            btnCustomer.Name = "btnCustomer";
            btnCustomer.Size = new Size(207, 45);
            btnCustomer.TabIndex = 4;
            btnCustomer.Text = "👥 Quản lý Khách hàng";
            btnCustomer.TextAlign = ContentAlignment.MiddleLeft;
            btnCustomer.UseVisualStyleBackColor = true;
            btnCustomer.Click += btnCustomer_Click;
            // 
            // btnCategory
            // 
            btnCategory.FlatAppearance.BorderSize = 0;
            btnCategory.FlatStyle = FlatStyle.Flat;
            btnCategory.ForeColor = Color.White;
            btnCategory.Location = new Point(12, 130);
            btnCategory.Name = "btnCategory";
            btnCategory.Size = new Size(207, 45);
            btnCategory.TabIndex = 3;
            btnCategory.Text = "📁 Quản lý Danh mục";
            btnCategory.TextAlign = ContentAlignment.MiddleLeft;
            btnCategory.UseVisualStyleBackColor = true;
            btnCategory.Click += btnCategory_Click;
            // 
            // btnReports
            // 
            btnReports.FlatAppearance.BorderSize = 0;
            btnReports.FlatStyle = FlatStyle.Flat;
            btnReports.ForeColor = Color.White;
            btnReports.Location = new Point(12, 295);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(207, 45);
            btnReports.TabIndex = 2;
            btnReports.Text = "📊 Báo cáo Doanh thu";
            btnReports.TextAlign = ContentAlignment.MiddleLeft;
            btnReports.UseVisualStyleBackColor = true;
            btnReports.Click += btnReports_Click;
            // 
            // btnPOS
            // 
            btnPOS.FlatAppearance.BorderSize = 0;
            btnPOS.FlatStyle = FlatStyle.Flat;
            btnPOS.ForeColor = Color.White;
            btnPOS.Location = new Point(12, 75);
            btnPOS.Name = "btnPOS";
            btnPOS.Size = new Size(207, 45);
            btnPOS.TabIndex = 1;
            btnPOS.Text = "\U0001f6d2 Bán hàng (POS)";
            btnPOS.TextAlign = ContentAlignment.MiddleLeft;
            btnPOS.UseVisualStyleBackColor = true;
            btnPOS.Click += btnPOS_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(3, 18);
            label1.Name = "label1";
            label1.Size = new Size(216, 32);
            label1.TabIndex = 0;
            label1.Text = "\U0001f6d2 MiniMart POS";
            // 
            // panelTopHeader
            // 
            panelTopHeader.Controls.Add(lblUserInfo);
            panelTopHeader.Controls.Add(lblTitle);
            panelTopHeader.Dock = DockStyle.Top;
            panelTopHeader.Location = new Point(230, 0);
            panelTopHeader.Name = "panelTopHeader";
            panelTopHeader.Size = new Size(1032, 60);
            panelTopHeader.TabIndex = 1;
            // 
            // lblUserInfo
            // 
            lblUserInfo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblUserInfo.AutoSize = true;
            lblUserInfo.Font = new Font("Segoe UI", 10F);
            lblUserInfo.Location = new Point(838, 18);
            lblUserInfo.Name = "lblUserInfo";
            lblUserInfo.Size = new Size(92, 23);
            lblUserInfo.TabIndex = 3;
            lblUserInfo.Text = "Xin chào:...";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 18);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(314, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "BÀN LÀM VIỆC HỆ THỐNG";
            // 
            // panelMainContent
            // 
            panelMainContent.BackColor = Color.FromArgb(244, 245, 247);
            panelMainContent.Dock = DockStyle.Fill;
            panelMainContent.Location = new Point(230, 60);
            panelMainContent.Name = "panelMainContent";
            panelMainContent.Size = new Size(1032, 613);
            panelMainContent.TabIndex = 2;
            // 
            // FormMainShell
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1262, 673);
            Controls.Add(panelMainContent);
            Controls.Add(panelTopHeader);
            Controls.Add(panelSidebar);
            Location = new Point(20, 18);
            Name = "FormMainShell";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hệ thống Quản lý Tiệm Tạp hóa Mỹ phẩm Xách tay Hana Shop";
            panelSidebar.ResumeLayout(false);
            panelSidebar.PerformLayout();
            panel1.ResumeLayout(false);
            panelTopHeader.ResumeLayout(false);
            panelTopHeader.PerformLayout();
            ResumeLayout(false);
            this.Load += new System.EventHandler(this.FormMainShell_Load);
        }

        #endregion

        private Panel panelSidebar;
        private Panel panelTopHeader;
        private Panel panelMainContent;
        private Label lblTitle;
        private Label lblUserInfo;
        private Label label1;
        private Button btnPOS;
        private Button btnUserManage;
        private Button btnProduct;
        private Button btnCustomer;
        private Button btnCategory;
        private Button btnReports;
        private Panel panel1;
        private Button btnLogout;
    }
}