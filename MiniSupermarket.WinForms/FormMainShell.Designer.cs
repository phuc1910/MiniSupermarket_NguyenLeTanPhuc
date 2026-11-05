namespace MiniSupermarket.WinForms
{
    partial class FormMainShell
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelSidebar = new Panel();
            panelBrand = new Panel();
            panelNavigation = new FlowLayoutPanel();
            panel1 = new Panel();
            btnLogout = new Button();
            btnUserManage = new Button();
            btnProduct = new Button();
            btnCustomer = new Button();
            btnCategory = new Button();
            btnOrders = new Button();
            btnReports = new Button();
            btnPOS = new Button();
            label1 = new Label();
            lblBrandSubtitle = new Label();
            panelTopHeader = new Panel();
            panelHeaderRule = new Panel();
            lblUserInfo = new Label();
            lblTitle = new Label();
            panelMainContent = new Panel();
            panelSidebar.SuspendLayout();
            panelBrand.SuspendLayout();
            panelNavigation.SuspendLayout();
            panel1.SuspendLayout();
            panelTopHeader.SuspendLayout();
            SuspendLayout();
            // panelSidebar
            panelSidebar.BackColor = Color.FromArgb(20, 42, 67);
            panelSidebar.Controls.Add(panelNavigation);
            panelSidebar.Controls.Add(panel1);
            panelSidebar.Controls.Add(panelBrand);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(224, 673);
            panelSidebar.TabIndex = 0;
            // panelBrand
            panelBrand.BackColor = Color.FromArgb(20, 42, 67);
            panelBrand.Controls.Add(label1);
            panelBrand.Controls.Add(lblBrandSubtitle);
            panelBrand.Dock = DockStyle.Top;
            panelBrand.Name = "panelBrand";
            panelBrand.Size = new Size(224, 124);
            // label1
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(23, 26);
            label1.Name = "label1";
            label1.Size = new Size(186, 46);
            label1.Text = "Hana Shop";
            // lblBrandSubtitle
            lblBrandSubtitle.Font = new Font("Segoe UI", 9F);
            lblBrandSubtitle.ForeColor = Color.FromArgb(148, 163, 184);
            lblBrandSubtitle.Location = new Point(26, 78);
            lblBrandSubtitle.Name = "lblBrandSubtitle";
            lblBrandSubtitle.Size = new Size(174, 34);
            lblBrandSubtitle.Text = "Quản lý cửa hàng";
            // panelNavigation
            panelNavigation.AutoScroll = true;
            panelNavigation.Controls.Add(btnPOS);
            panelNavigation.Controls.Add(btnCategory);
            panelNavigation.Controls.Add(btnProduct);
            panelNavigation.Controls.Add(btnCustomer);
            panelNavigation.Controls.Add(btnOrders);
            panelNavigation.Controls.Add(btnReports);
            panelNavigation.Controls.Add(btnUserManage);
            panelNavigation.Dock = DockStyle.Fill;
            panelNavigation.FlowDirection = FlowDirection.TopDown;
            panelNavigation.Name = "panelNavigation";
            panelNavigation.Padding = new Padding(16, 8, 16, 8);
            panelNavigation.Size = new Size(224, 469);
            panelNavigation.TabIndex = 0;
            panelNavigation.WrapContents = false;
            // btnPOS
            btnPOS.BackColor = Color.FromArgb(20, 42, 67);
            btnPOS.Cursor = Cursors.Hand;
            btnPOS.FlatAppearance.BorderSize = 0;
            btnPOS.FlatAppearance.MouseOverBackColor = Color.FromArgb(32, 60, 90);
            btnPOS.FlatAppearance.MouseDownBackColor = Color.FromArgb(37, 99, 235);
            btnPOS.FlatStyle = FlatStyle.Flat;
            btnPOS.Font = new Font("Segoe UI", 10F);
            btnPOS.ForeColor = Color.FromArgb(226, 232, 240);
            btnPOS.Margin = new Padding(0, 0, 0, 8);
            btnPOS.Name = "btnPOS";
            btnPOS.Padding = new Padding(14, 0, 8, 0);
            btnPOS.Size = new Size(192, 48);
            btnPOS.TabIndex = 0;
            btnPOS.Text = "Bán hàng (POS)";
            btnPOS.TextAlign = ContentAlignment.MiddleLeft;
            btnPOS.UseVisualStyleBackColor = false;
            btnPOS.Click += btnPOS_Click;
            // btnCategory
            btnCategory.BackColor = Color.FromArgb(20, 42, 67);
            btnCategory.Cursor = Cursors.Hand;
            btnCategory.FlatAppearance.BorderSize = 0;
            btnCategory.FlatAppearance.MouseOverBackColor = Color.FromArgb(32, 60, 90);
            btnCategory.FlatAppearance.MouseDownBackColor = Color.FromArgb(37, 99, 235);
            btnCategory.FlatStyle = FlatStyle.Flat;
            btnCategory.Font = new Font("Segoe UI", 10F);
            btnCategory.ForeColor = Color.FromArgb(226, 232, 240);
            btnCategory.Margin = new Padding(0, 0, 0, 8);
            btnCategory.Name = "btnCategory";
            btnCategory.Padding = new Padding(14, 0, 8, 0);
            btnCategory.Size = new Size(192, 48);
            btnCategory.TabIndex = 1;
            btnCategory.Text = "Danh mục";
            btnCategory.TextAlign = ContentAlignment.MiddleLeft;
            btnCategory.UseVisualStyleBackColor = false;
            btnCategory.Click += btnCategory_Click;
            // btnProduct
            btnProduct.BackColor = Color.FromArgb(20, 42, 67);
            btnProduct.Cursor = Cursors.Hand;
            btnProduct.FlatAppearance.BorderSize = 0;
            btnProduct.FlatAppearance.MouseOverBackColor = Color.FromArgb(32, 60, 90);
            btnProduct.FlatAppearance.MouseDownBackColor = Color.FromArgb(37, 99, 235);
            btnProduct.FlatStyle = FlatStyle.Flat;
            btnProduct.Font = new Font("Segoe UI", 10F);
            btnProduct.ForeColor = Color.FromArgb(226, 232, 240);
            btnProduct.Margin = new Padding(0, 0, 0, 8);
            btnProduct.Name = "btnProduct";
            btnProduct.Padding = new Padding(14, 0, 8, 0);
            btnProduct.Size = new Size(192, 48);
            btnProduct.TabIndex = 2;
            btnProduct.Text = "Sản phẩm & tồn kho";
            btnProduct.TextAlign = ContentAlignment.MiddleLeft;
            btnProduct.UseVisualStyleBackColor = false;
            btnProduct.Click += btnProduct_Click;
            // btnCustomer
            btnCustomer.BackColor = Color.FromArgb(20, 42, 67);
            btnCustomer.Cursor = Cursors.Hand;
            btnCustomer.FlatAppearance.BorderSize = 0;
            btnCustomer.FlatAppearance.MouseOverBackColor = Color.FromArgb(32, 60, 90);
            btnCustomer.FlatAppearance.MouseDownBackColor = Color.FromArgb(37, 99, 235);
            btnCustomer.FlatStyle = FlatStyle.Flat;
            btnCustomer.Font = new Font("Segoe UI", 10F);
            btnCustomer.ForeColor = Color.FromArgb(226, 232, 240);
            btnCustomer.Margin = new Padding(0, 0, 0, 8);
            btnCustomer.Name = "btnCustomer";
            btnCustomer.Padding = new Padding(14, 0, 8, 0);
            btnCustomer.Size = new Size(192, 48);
            btnCustomer.TabIndex = 3;
            btnCustomer.Text = "Khách hàng";
            btnCustomer.TextAlign = ContentAlignment.MiddleLeft;
            btnCustomer.UseVisualStyleBackColor = false;
            btnCustomer.Click += btnCustomer_Click;
            // btnOrders
            btnOrders.BackColor = Color.FromArgb(20, 42, 67);
            btnOrders.Cursor = Cursors.Hand;
            btnOrders.FlatAppearance.BorderSize = 0;
            btnOrders.FlatAppearance.MouseOverBackColor = Color.FromArgb(32, 60, 90);
            btnOrders.FlatAppearance.MouseDownBackColor = Color.FromArgb(37, 99, 235);
            btnOrders.FlatStyle = FlatStyle.Flat;
            btnOrders.Font = new Font("Segoe UI", 10F);
            btnOrders.ForeColor = Color.FromArgb(226, 232, 240);
            btnOrders.Margin = new Padding(0, 0, 0, 8);
            btnOrders.Name = "btnOrders";
            btnOrders.Padding = new Padding(14, 0, 8, 0);
            btnOrders.Size = new Size(192, 48);
            btnOrders.TabIndex = 4;
            btnOrders.Text = "Đơn hàng & chi tiết";
            btnOrders.TextAlign = ContentAlignment.MiddleLeft;
            btnOrders.UseVisualStyleBackColor = false;
            btnOrders.Click += btnOrders_Click;
            // btnReports
            btnReports.BackColor = Color.FromArgb(20, 42, 67);
            btnReports.Cursor = Cursors.Hand;
            btnReports.FlatAppearance.BorderSize = 0;
            btnReports.FlatAppearance.MouseOverBackColor = Color.FromArgb(32, 60, 90);
            btnReports.FlatAppearance.MouseDownBackColor = Color.FromArgb(37, 99, 235);
            btnReports.FlatStyle = FlatStyle.Flat;
            btnReports.Font = new Font("Segoe UI", 10F);
            btnReports.ForeColor = Color.FromArgb(226, 232, 240);
            btnReports.Margin = new Padding(0, 0, 0, 8);
            btnReports.Name = "btnReports";
            btnReports.Padding = new Padding(14, 0, 8, 0);
            btnReports.Size = new Size(192, 48);
            btnReports.TabIndex = 5;
            btnReports.Text = "Báo cáo doanh thu";
            btnReports.TextAlign = ContentAlignment.MiddleLeft;
            btnReports.UseVisualStyleBackColor = false;
            btnReports.Click += btnReports_Click;
            // btnUserManage
            btnUserManage.BackColor = Color.FromArgb(20, 42, 67);
            btnUserManage.Cursor = Cursors.Hand;
            btnUserManage.FlatAppearance.BorderSize = 0;
            btnUserManage.FlatAppearance.MouseOverBackColor = Color.FromArgb(32, 60, 90);
            btnUserManage.FlatAppearance.MouseDownBackColor = Color.FromArgb(37, 99, 235);
            btnUserManage.FlatStyle = FlatStyle.Flat;
            btnUserManage.Font = new Font("Segoe UI", 10F);
            btnUserManage.ForeColor = Color.FromArgb(226, 232, 240);
            btnUserManage.Margin = new Padding(0, 0, 0, 8);
            btnUserManage.Name = "btnUserManage";
            btnUserManage.Padding = new Padding(14, 0, 8, 0);
            btnUserManage.Size = new Size(192, 48);
            btnUserManage.TabIndex = 6;
            btnUserManage.Text = "Tài khoản nhân viên";
            btnUserManage.TextAlign = ContentAlignment.MiddleLeft;
            btnUserManage.UseVisualStyleBackColor = false;
            btnUserManage.Click += btnUserManage_Click;
            // panel1
            panel1.Controls.Add(btnLogout);
            panel1.Dock = DockStyle.Bottom;
            panel1.Name = "panel1";
            panel1.Padding = new Padding(16, 12, 16, 16);
            panel1.Size = new Size(224, 80);
            panel1.TabIndex = 1;
            // btnLogout
            btnLogout.BackColor = Color.FromArgb(32, 60, 90);
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.Dock = DockStyle.Fill;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatAppearance.MouseOverBackColor = Color.FromArgb(48, 73, 104);
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.ForeColor = Color.FromArgb(226, 232, 240);
            btnLogout.Name = "btnLogout";
            btnLogout.Padding = new Padding(14, 0, 0, 0);
            btnLogout.TabIndex = 0;
            btnLogout.Text = "Đăng xuất";
            btnLogout.TextAlign = ContentAlignment.MiddleLeft;
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // panelTopHeader
            panelTopHeader.BackColor = Color.White;
            panelTopHeader.Controls.Add(lblUserInfo);
            panelTopHeader.Controls.Add(lblTitle);
            panelTopHeader.Controls.Add(panelHeaderRule);
            panelTopHeader.Dock = DockStyle.Top;
            panelTopHeader.Name = "panelTopHeader";
            panelTopHeader.Size = new Size(1038, 84);
            panelTopHeader.TabIndex = 1;
            // lblTitle
            lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTitle.AutoEllipsis = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(20, 42, 67);
            lblTitle.Location = new Point(24, 14);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(990, 34);
            lblTitle.Text = "BÀN LÀM VIỆC";
            // lblUserInfo
            lblUserInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblUserInfo.AutoEllipsis = true;
            lblUserInfo.Font = new Font("Segoe UI", 9F);
            lblUserInfo.ForeColor = Color.FromArgb(100, 116, 139);
            lblUserInfo.Location = new Point(26, 51);
            lblUserInfo.Name = "lblUserInfo";
            lblUserInfo.Size = new Size(986, 22);
            lblUserInfo.Text = "Thông tin nhân viên";
            // panelHeaderRule
            panelHeaderRule.BackColor = Color.FromArgb(226, 232, 240);
            panelHeaderRule.Dock = DockStyle.Bottom;
            panelHeaderRule.Name = "panelHeaderRule";
            panelHeaderRule.Size = new Size(1038, 1);
            // panelMainContent
            panelMainContent.BackColor = Color.FromArgb(242, 245, 250);
            panelMainContent.Dock = DockStyle.Fill;
            panelMainContent.Name = "panelMainContent";
            panelMainContent.Padding = new Padding(12);
            panelMainContent.Size = new Size(1038, 589);
            panelMainContent.TabIndex = 2;
            // FormMainShell
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(242, 245, 250);
            ClientSize = new Size(1262, 673);
            Controls.Add(panelMainContent);
            panelMainContent.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Controls.Add(panelTopHeader);
            panelTopHeader.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Controls.Add(panelSidebar);
            panelSidebar.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ForeColor = Color.FromArgb(20, 42, 67);
            MinimumSize = new Size(1100, 650);
            Name = "FormMainShell";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hana Shop | Quản lý cửa hàng";
            Load += FormMainShell_Load;
            panelTopHeader.ResumeLayout(false);
            panelTopHeader.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panelNavigation.ResumeLayout(false);
            panelNavigation.PerformLayout();
            panelBrand.ResumeLayout(false);
            panelBrand.PerformLayout();
            panelSidebar.ResumeLayout(false);
            panelSidebar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSidebar;
        private Panel panelBrand;
        private FlowLayoutPanel panelNavigation;
        private Panel panel1;
        private Button btnLogout;
        private Button btnUserManage;
        private Button btnProduct;
        private Button btnCustomer;
        private Button btnCategory;
        private Button btnOrders;
        private Button btnReports;
        private Button btnPOS;
        private Label label1;
        private Label lblBrandSubtitle;
        private Panel panelTopHeader;
        private Panel panelHeaderRule;
        private Label lblUserInfo;
        private Label lblTitle;
        private Panel panelMainContent;
    }
}
