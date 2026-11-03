namespace MiniSupermarket.WinForms
{
    partial class FormUserManagement
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
            panelRoot = new Panel();
            tableLayoutPanelContent = new TableLayoutPanel();
            groupBox1 = new GroupBox();
            dgvUsers = new DataGridView();
            panelDetail = new Panel();
            panelButtons = new TableLayoutPanel();
            btnAddUser = new Button();
            btnResetPassword = new Button();
            btnToggleLock = new Button();
            btnUpdateUser = new Button();
            btnReload = new Button();
            groupBox2 = new GroupBox();
            cboRole = new ComboBox();
            label4 = new Label();
            txtPassword = new TextBox();
            label3 = new Label();
            txtFullName = new TextBox();
            label2 = new Label();
            txtUsername = new TextBox();
            label1 = new Label();
            panelRoot.SuspendLayout();
            tableLayoutPanelContent.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            panelDetail.SuspendLayout();
            panelButtons.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // panelRoot
            // 
            panelRoot.Controls.Add(tableLayoutPanelContent);
            panelRoot.Dock = DockStyle.Fill;
            panelRoot.Location = new Point(0, 0);
            panelRoot.Name = "panelRoot";
            panelRoot.BackColor = Color.FromArgb(242, 245, 250);
            panelRoot.Padding = new Padding(16);
            panelRoot.Size = new Size(950, 620);
            panelRoot.TabIndex = 0;
            // 
            // tableLayoutPanelContent
            // 
            tableLayoutPanelContent.ColumnCount = 2;
            tableLayoutPanelContent.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelContent.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 320F));
            tableLayoutPanelContent.Controls.Add(groupBox1, 0, 0);
            tableLayoutPanelContent.Controls.Add(panelDetail, 1, 0);
            tableLayoutPanelContent.Dock = DockStyle.Fill;
            tableLayoutPanelContent.Location = new Point(14, 16);
            tableLayoutPanelContent.Name = "tableLayoutPanelContent";
            tableLayoutPanelContent.Padding = new Padding(0);
            tableLayoutPanelContent.Margin = new Padding(0);
            tableLayoutPanelContent.RowCount = 1;
            tableLayoutPanelContent.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelContent.Size = new Size(922, 590);
            tableLayoutPanelContent.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgvUsers);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Margin = new Padding(0, 0, 12, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.ForeColor = Color.FromArgb(22, 54, 90);
            groupBox1.BackColor = Color.White;
            groupBox1.Padding = new Padding(12);
            groupBox1.Size = new Size(614, 590);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Danh sách tài khoản";
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.AllowUserToResizeRows = false;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvUsers.Dock = DockStyle.Fill;
            dgvUsers.Location = new Point(7, 27);
            dgvUsers.MultiSelect = false;
            dgvUsers.Name = "dgvUsers";
            dgvUsers.Margin = new Padding(0);
            dgvUsers.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dgvUsers.RowTemplate.Height = 36;
            dgvUsers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvUsers.GridColor = Color.FromArgb(235, 240, 247);
            dgvUsers.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 253);
            dgvUsers.DefaultCellStyle.Padding = new Padding(8, 0, 8, 0);
            dgvUsers.DefaultCellStyle.SelectionForeColor = Color.FromArgb(22, 54, 90);
            dgvUsers.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 234, 254);
            dgvUsers.DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dgvUsers.DefaultCellStyle.ForeColor = Color.FromArgb(31, 41, 55);
            dgvUsers.DefaultCellStyle.BackColor = Color.White;
            dgvUsers.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 0, 8, 0);
            dgvUsers.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(22, 54, 90);
            dgvUsers.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(232, 239, 250);
            dgvUsers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            dgvUsers.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(22, 54, 90);
            dgvUsers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(232, 239, 250);
            dgvUsers.ColumnHeadersHeight = 42;
            dgvUsers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvUsers.EnableHeadersVisualStyles = false;
            dgvUsers.BorderStyle = BorderStyle.None;
            dgvUsers.BackgroundColor = Color.White;
            dgvUsers.ReadOnly = true;
            dgvUsers.RowHeadersVisible = false;
            dgvUsers.RowHeadersWidth = 51;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.Size = new Size(600, 556);
            dgvUsers.TabIndex = 0;
            dgvUsers.CellClick += dgvUsers_CellClick;
            // 
            // panelDetail
            // 
            panelDetail.Controls.Add(panelButtons);
            panelDetail.Controls.Add(groupBox2);
            panelDetail.Dock = DockStyle.Fill;
            panelDetail.Location = new Point(625, 3);
            panelDetail.Name = "panelDetail";
            panelDetail.AutoScroll = true;
            panelDetail.BackColor = Color.White;
            panelDetail.Margin = new Padding(0);
            panelDetail.Size = new Size(320, 560);
            panelDetail.TabIndex = 1;
            // 
            // panelButtons
            // 
            panelButtons.Dock = DockStyle.Top;
            panelButtons.Location = new Point(0, 324);
            panelButtons.Name = "panelButtons";
            panelButtons.BackColor = Color.White;
            panelButtons.Padding = new Padding(12, 8, 12, 8);
            panelButtons.Margin = new Padding(0);
            panelButtons.ColumnCount = 2;
            panelButtons.RowCount = 4;
            panelButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            panelButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            panelButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            panelButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            panelButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            panelButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            panelButtons.Controls.Add(btnAddUser, 0, 0);
            panelButtons.Controls.Add(btnToggleLock, 1, 0);
            panelButtons.Controls.Add(btnResetPassword, 0, 1);
            panelButtons.SetColumnSpan(btnResetPassword, 2);
            panelButtons.Controls.Add(btnUpdateUser, 0, 2);
            panelButtons.SetColumnSpan(btnUpdateUser, 2);
            panelButtons.Controls.Add(btnReload, 0, 3);
            panelButtons.SetColumnSpan(btnReload, 2);
            panelButtons.Size = new Size(320, 200);
            panelButtons.TabIndex = 1;
            // 
            // btnAddUser
            // 
            btnAddUser.Location = new Point(2, 10);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Margin = new Padding(4);
            btnAddUser.Dock = DockStyle.Fill;
            btnAddUser.AutoSize = false;
            btnAddUser.Cursor = Cursors.Hand;
            btnAddUser.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 64, 175);
            btnAddUser.FlatAppearance.MouseOverBackColor = Color.FromArgb(29, 78, 216);
            btnAddUser.FlatAppearance.BorderSize = 0;
            btnAddUser.FlatStyle = FlatStyle.Flat;
            btnAddUser.ForeColor = Color.White;
            btnAddUser.BackColor = Color.FromArgb(37, 99, 235);
            btnAddUser.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnAddUser.Size = new Size(96, 38);
            btnAddUser.TabIndex = 4;
            btnAddUser.Text = "Thêm";
            btnAddUser.UseVisualStyleBackColor = false;
            btnAddUser.Click += btnAddUser_Click;
            // 
            // btnResetPassword
            // 
            btnResetPassword.Location = new Point(98, 10);
            btnResetPassword.Name = "btnResetPassword";
            btnResetPassword.Margin = new Padding(4);
            btnResetPassword.Dock = DockStyle.Fill;
            btnResetPassword.AutoSize = false;
            btnResetPassword.Cursor = Cursors.Hand;
            btnResetPassword.FlatAppearance.MouseDownBackColor = Color.FromArgb(203, 217, 235);
            btnResetPassword.FlatAppearance.MouseOverBackColor = Color.FromArgb(221, 230, 241);
            btnResetPassword.FlatAppearance.BorderSize = 0;
            btnResetPassword.FlatStyle = FlatStyle.Flat;
            btnResetPassword.ForeColor = Color.FromArgb(22, 54, 90);
            btnResetPassword.BackColor = Color.FromArgb(238, 242, 247);
            btnResetPassword.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnResetPassword.Size = new Size(96, 38);
            btnResetPassword.TabIndex = 5;
            btnResetPassword.Text = "Đặt lại mật khẩu";
            btnResetPassword.UseVisualStyleBackColor = false;
            btnResetPassword.Click += btnResetPassword_Click;
            // 
            // btnToggleLock
            // 
            btnToggleLock.Location = new Point(194, 10);
            btnToggleLock.Name = "btnToggleLock";
            btnToggleLock.Margin = new Padding(4);
            btnToggleLock.Dock = DockStyle.Fill;
            btnToggleLock.AutoSize = false;
            btnToggleLock.Cursor = Cursors.Hand;
            btnToggleLock.FlatAppearance.MouseDownBackColor = Color.FromArgb(252, 165, 165);
            btnToggleLock.FlatAppearance.MouseOverBackColor = Color.FromArgb(254, 202, 202);
            btnToggleLock.FlatAppearance.BorderSize = 0;
            btnToggleLock.FlatStyle = FlatStyle.Flat;
            btnToggleLock.ForeColor = Color.FromArgb(153, 27, 27);
            btnToggleLock.BackColor = Color.FromArgb(254, 226, 226);
            btnToggleLock.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnToggleLock.Size = new Size(96, 38);
            btnToggleLock.TabIndex = 6;
            btnToggleLock.Text = "Khóa / Mở";
            btnToggleLock.UseVisualStyleBackColor = false;
            btnToggleLock.Click += btnToggleLock_Click;
            // 
            // btnUpdateUser
            // 
            btnUpdateUser.Location = new Point(2, 49);
            btnUpdateUser.Name = "btnUpdateUser";
            btnUpdateUser.Margin = new Padding(4);
            btnUpdateUser.Dock = DockStyle.Fill;
            btnUpdateUser.AutoSize = false;
            btnUpdateUser.Cursor = Cursors.Hand;
            btnUpdateUser.FlatAppearance.MouseDownBackColor = Color.FromArgb(203, 217, 235);
            btnUpdateUser.FlatAppearance.MouseOverBackColor = Color.FromArgb(221, 230, 241);
            btnUpdateUser.FlatAppearance.BorderSize = 0;
            btnUpdateUser.FlatStyle = FlatStyle.Flat;
            btnUpdateUser.ForeColor = Color.FromArgb(22, 54, 90);
            btnUpdateUser.BackColor = Color.FromArgb(238, 242, 247);
            btnUpdateUser.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnUpdateUser.Size = new Size(96, 38);
            btnUpdateUser.TabIndex = 7;
            btnUpdateUser.Text = "Cập nhật họ tên / vai trò";
            btnUpdateUser.UseVisualStyleBackColor = false;
            btnUpdateUser.Click += btnUpdateUser_Click;
            // 
            // btnReload
            // 
            btnReload.Location = new Point(2, 88);
            btnReload.Name = "btnReload";
            btnReload.Margin = new Padding(4);
            btnReload.Dock = DockStyle.Fill;
            btnReload.AutoSize = false;
            btnReload.Cursor = Cursors.Hand;
            btnReload.FlatAppearance.MouseDownBackColor = Color.FromArgb(203, 217, 235);
            btnReload.FlatAppearance.MouseOverBackColor = Color.FromArgb(221, 230, 241);
            btnReload.FlatAppearance.BorderSize = 0;
            btnReload.FlatStyle = FlatStyle.Flat;
            btnReload.ForeColor = Color.FromArgb(22, 54, 90);
            btnReload.BackColor = Color.FromArgb(238, 242, 247);
            btnReload.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnReload.Size = new Size(96, 38);
            btnReload.TabIndex = 8;
            btnReload.Text = "Tải lại danh sách";
            btnReload.UseVisualStyleBackColor = false;
            btnReload.Click += btnReload_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(cboRole);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(txtPassword);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(txtFullName);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(txtUsername);
            groupBox2.Controls.Add(label1);
            groupBox2.Dock = DockStyle.Top;
            groupBox2.Location = new Point(0, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Margin = new Padding(0);
            groupBox2.Padding = new Padding(12);
            groupBox2.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox2.ForeColor = Color.FromArgb(22, 54, 90);
            groupBox2.BackColor = Color.White;
            groupBox2.Size = new Size(320, 294);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thông tin tài khoản";
            // 
            // cboRole
            // 
            cboRole.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRole.FormattingEnabled = true;
            cboRole.Location = new Point(16, 242);
            cboRole.Name = "cboRole";
            cboRole.Margin = new Padding(0);
            cboRole.FlatStyle = FlatStyle.Flat;
            cboRole.BackColor = Color.White;
            cboRole.ForeColor = Color.FromArgb(31, 41, 55);
            cboRole.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cboRole.Size = new Size(288, 28);
            cboRole.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 218);
            label4.Name = "label4";
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.FromArgb(22, 54, 90);
            label4.Size = new Size(52, 20);
            label4.TabIndex = 3;
            label4.Text = "Vai trò";
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPassword.Location = new Point(16, 180);
            txtPassword.Name = "txtPassword";
            txtPassword.Margin = new Padding(0);
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.BackColor = Color.White;
            txtPassword.ForeColor = Color.FromArgb(31, 41, 55);
            txtPassword.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(288, 28);
            txtPassword.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 156);
            label3.Name = "label3";
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.FromArgb(22, 54, 90);
            label3.Size = new Size(70, 20);
            label3.TabIndex = 2;
            label3.Text = "Mật khẩu";
            // 
            // txtFullName
            // 
            txtFullName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtFullName.Location = new Point(16, 118);
            txtFullName.Name = "txtFullName";
            txtFullName.Margin = new Padding(0);
            txtFullName.BorderStyle = BorderStyle.FixedSingle;
            txtFullName.BackColor = Color.White;
            txtFullName.ForeColor = Color.FromArgb(31, 41, 55);
            txtFullName.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtFullName.Size = new Size(288, 28);
            txtFullName.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 94);
            label2.Name = "label2";
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.FromArgb(22, 54, 90);
            label2.Size = new Size(54, 20);
            label2.TabIndex = 1;
            label2.Text = "Họ tên";
            // 
            // txtUsername
            // 
            txtUsername.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtUsername.Location = new Point(16, 56);
            txtUsername.Name = "txtUsername";
            txtUsername.Margin = new Padding(0);
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.BackColor = Color.White;
            txtUsername.ForeColor = Color.FromArgb(31, 41, 55);
            txtUsername.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtUsername.Size = new Size(288, 28);
            txtUsername.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 32);
            label1.Name = "label1";
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(22, 54, 90);
            label1.Size = new Size(107, 20);
            label1.TabIndex = 0;
            label1.Text = "Tên đăng nhập";
            // 
            // FormUserManagement
            // 
            Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            BackColor = Color.FromArgb(242, 245, 250);
            ForeColor = Color.FromArgb(31, 41, 55);
            StartPosition = FormStartPosition.CenterParent;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(950, 620);
            Controls.Add(panelRoot);
            panelRoot.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(930, 600);
            Name = "FormUserManagement";
            Text = "Quản lý tài khoản";
            Load += FormUserManagement_Load;
            panelRoot.ResumeLayout(false);
            tableLayoutPanelContent.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            panelDetail.ResumeLayout(false);
            panelButtons.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelRoot;
        private TableLayoutPanel tableLayoutPanelContent;
        private GroupBox groupBox1;
        private DataGridView dgvUsers;

        private Panel panelDetail;
        private GroupBox groupBox2;

        private Label label1;
        private TextBox txtUsername;

        private Label label2;
        private TextBox txtFullName;

        private Label label3;
        private TextBox txtPassword;

        private Label label4;
        private ComboBox cboRole;

        private TableLayoutPanel panelButtons;
        private Button btnAddUser;
        private Button btnResetPassword;
        private Button btnToggleLock;
        private Button btnUpdateUser;

        private Button btnReload;
    }
}
