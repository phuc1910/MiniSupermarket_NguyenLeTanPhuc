namespace MiniSupermarket.WinForms
{
    partial class FormLogin
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
            panelBrand = new Panel();
            lblBrand = new Label();
            lblBrandHeadline = new Label();
            lblBrandDescription = new Label();
            panelBrandAccent = new Panel();
            tableLayoutLogin = new TableLayoutPanel();
            groupBox1 = new GroupBox();
            lblWelcome = new Label();
            lblWelcomeDescription = new Label();
            btnLogin = new Button();
            txtPass = new TextBox();
            txtUser = new TextBox();
            label2 = new Label();
            label1 = new Label();
            lblLoginNote = new Label();
            panelBrand.SuspendLayout();
            tableLayoutLogin.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // panelBrand
            panelBrand.BackColor = Color.FromArgb(20, 42, 67);
            panelBrand.Controls.Add(lblBrand);
            panelBrand.Controls.Add(lblBrandHeadline);
            panelBrand.Controls.Add(lblBrandDescription);
            panelBrand.Controls.Add(panelBrandAccent);
            panelBrand.Dock = DockStyle.Left;
            panelBrand.Name = "panelBrand";
            panelBrand.Size = new Size(360, 600);
            panelBrand.TabIndex = 1;
            // lblBrand
            lblBrand.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblBrand.ForeColor = Color.White;
            lblBrand.Location = new Point(40, 56);
            lblBrand.Name = "lblBrand";
            lblBrand.Size = new Size(286, 64);
            lblBrand.Text = "Hana Shop";
            // panelBrandAccent
            panelBrandAccent.BackColor = Color.FromArgb(45, 212, 191);
            panelBrandAccent.Location = new Point(44, 137);
            panelBrandAccent.Name = "panelBrandAccent";
            panelBrandAccent.Size = new Size(54, 5);
            // lblBrandHeadline
            lblBrandHeadline.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblBrandHeadline.ForeColor = Color.White;
            lblBrandHeadline.Location = new Point(40, 184);
            lblBrandHeadline.Name = "lblBrandHeadline";
            lblBrandHeadline.Size = new Size(280, 168);
            lblBrandHeadline.Text = "Bán hàng thuận tiện.\nQuản lý trong tầm tay.";
            // lblBrandDescription
            lblBrandDescription.Font = new Font("Segoe UI", 11F);
            lblBrandDescription.ForeColor = Color.FromArgb(203, 213, 225);
            lblBrandDescription.Location = new Point(44, 372);
            lblBrandDescription.Name = "lblBrandDescription";
            lblBrandDescription.Size = new Size(270, 112);
            lblBrandDescription.Text = "Sản phẩm, khách hàng và hoạt động bán hàng được kết nối trong một không gian làm việc.";
            // tableLayoutLogin
            tableLayoutLogin.ColumnCount = 1;
            tableLayoutLogin.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutLogin.Controls.Add(groupBox1, 0, 0);
            tableLayoutLogin.Dock = DockStyle.Fill;
            tableLayoutLogin.Name = "tableLayoutLogin";
            tableLayoutLogin.Padding = new Padding(24);
            tableLayoutLogin.RowCount = 1;
            tableLayoutLogin.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutLogin.Size = new Size(554, 600);
            tableLayoutLogin.TabIndex = 0;
            // groupBox1
            groupBox1.Anchor = AnchorStyles.None;
            groupBox1.BackColor = Color.White;
            groupBox1.Controls.Add(lblWelcome);
            groupBox1.Controls.Add(lblWelcomeDescription);
            groupBox1.Controls.Add(btnLogin);
            groupBox1.Controls.Add(txtPass);
            groupBox1.Controls.Add(txtUser);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(lblLoginNote);
            groupBox1.Location = new Point(67, 76);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(24);
            groupBox1.Size = new Size(420, 448);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "";
            // lblWelcome
            lblWelcome.Font = new Font("Segoe UI", 23F, FontStyle.Bold);
            lblWelcome.ForeColor = Color.FromArgb(20, 42, 67);
            lblWelcome.Location = new Point(24, 26);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(372, 46);
            lblWelcome.Text = "Đăng nhập";
            // lblWelcomeDescription
            lblWelcomeDescription.ForeColor = Color.FromArgb(100, 116, 139);
            lblWelcomeDescription.Location = new Point(26, 80);
            lblWelcomeDescription.Name = "lblWelcomeDescription";
            lblWelcomeDescription.Size = new Size(368, 48);
            lblWelcomeDescription.Text = "Chào mừng bạn trở lại Hana Shop.";
            // label1
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(20, 42, 67);
            label1.Location = new Point(26, 145);
            label1.Name = "label1";
            label1.Size = new Size(368, 24);
            label1.Text = "Tài khoản";
            // txtUser
            txtUser.BackColor = Color.FromArgb(248, 250, 252);
            txtUser.Font = new Font("Segoe UI", 11F);
            txtUser.Location = new Point(26, 174);
            txtUser.Name = "txtUser";
            txtUser.PlaceholderText = "Nhập tài khoản của bạn";
            txtUser.Size = new Size(368, 32);
            txtUser.TabIndex = 0;
            // label2
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(20, 42, 67);
            label2.Location = new Point(26, 225);
            label2.Name = "label2";
            label2.Size = new Size(368, 24);
            label2.Text = "Mật khẩu";
            // txtPass
            txtPass.BackColor = Color.FromArgb(248, 250, 252);
            txtPass.Font = new Font("Segoe UI", 11F);
            txtPass.Location = new Point(26, 254);
            txtPass.Name = "txtPass";
            txtPass.PlaceholderText = "Nhập mật khẩu";
            txtPass.Size = new Size(368, 32);
            txtPass.TabIndex = 1;
            txtPass.UseSystemPasswordChar = true;
            // btnLogin
            btnLogin.BackColor = Color.FromArgb(37, 99, 235);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatAppearance.MouseOverBackColor = Color.FromArgb(29, 78, 216);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(26, 320);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(368, 48);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Đăng nhập hệ thống";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // lblLoginNote
            lblLoginNote.Font = new Font("Segoe UI", 9F);
            lblLoginNote.ForeColor = Color.FromArgb(100, 116, 139);
            lblLoginNote.Location = new Point(26, 390);
            lblLoginNote.Name = "lblLoginNote";
            lblLoginNote.Size = new Size(368, 38);
            lblLoginNote.Text = "Sử dụng tài khoản được cấp để đăng nhập.";
            // FormLogin
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(242, 245, 250);
            ClientSize = new Size(914, 600);
            Controls.Add(tableLayoutLogin);
            tableLayoutLogin.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Controls.Add(panelBrand);
            panelBrand.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ForeColor = Color.FromArgb(20, 42, 67);
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hana Shop | Đăng nhập";
            Load += FormLogin_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tableLayoutLogin.ResumeLayout(false);
            panelBrand.ResumeLayout(false);
            panelBrand.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelBrand;
        private Label lblBrand;
        private Label lblBrandHeadline;
        private Label lblBrandDescription;
        private Panel panelBrandAccent;
        private TableLayoutPanel tableLayoutLogin;
        private GroupBox groupBox1;
        private Label lblWelcome;
        private Label lblWelcomeDescription;
        private Button btnLogin;
        private TextBox txtPass;
        private TextBox txtUser;
        private Label label2;
        private Label label1;
        private Label lblLoginNote;
    }
}
