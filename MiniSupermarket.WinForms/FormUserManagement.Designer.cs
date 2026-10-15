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
            panelButtons = new Panel();
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
            panelRoot.Padding = new Padding(14, 16, 14, 14);
            panelRoot.Size = new Size(950, 620);
            panelRoot.TabIndex = 0;
            // 
            // tableLayoutPanelContent
            // 
            tableLayoutPanelContent.ColumnCount = 2;
            tableLayoutPanelContent.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelContent.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300F));
            tableLayoutPanelContent.Controls.Add(groupBox1, 0, 0);
            tableLayoutPanelContent.Controls.Add(panelDetail, 1, 0);
            tableLayoutPanelContent.Dock = DockStyle.Fill;
            tableLayoutPanelContent.Location = new Point(14, 16);
            tableLayoutPanelContent.Name = "tableLayoutPanelContent";
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
            groupBox1.Margin = new Padding(0, 0, 8, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(7);
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
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Dock = DockStyle.Fill;
            dgvUsers.Location = new Point(7, 27);
            dgvUsers.MultiSelect = false;
            dgvUsers.Name = "dgvUsers";
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
            panelDetail.Size = new Size(294, 584);
            panelDetail.TabIndex = 1;
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(btnAddUser);
            panelButtons.Controls.Add(btnResetPassword);
            panelButtons.Controls.Add(btnToggleLock);
            panelButtons.Controls.Add(btnUpdateUser);
            panelButtons.Controls.Add(btnReload);
            panelButtons.Dock = DockStyle.Top;
            panelButtons.Location = new Point(0, 324);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(294, 130);
            panelButtons.TabIndex = 1;
            // 
            // btnAddUser
            // 
            btnAddUser.Location = new Point(2, 10);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new Size(90, 31);
            btnAddUser.TabIndex = 4;
            btnAddUser.Text = "Thêm";
            btnAddUser.UseVisualStyleBackColor = true;
            btnAddUser.Click += btnAddUser_Click;
            // 
            // btnResetPassword
            // 
            btnResetPassword.Location = new Point(98, 10);
            btnResetPassword.Name = "btnResetPassword";
            btnResetPassword.Size = new Size(90, 31);
            btnResetPassword.TabIndex = 5;
            btnResetPassword.Text = "Đặt MK";
            btnResetPassword.UseVisualStyleBackColor = true;
            btnResetPassword.Click += btnResetPassword_Click;
            // 
            // btnToggleLock
            // 
            btnToggleLock.Location = new Point(194, 10);
            btnToggleLock.Name = "btnToggleLock";
            btnToggleLock.Size = new Size(104, 31);
            btnToggleLock.TabIndex = 6;
            btnToggleLock.Text = "Khóa/Mở";
            btnToggleLock.UseVisualStyleBackColor = true;
            btnToggleLock.Click += btnToggleLock_Click;
            // 
            // btnUpdateUser
            // 
            btnUpdateUser.Location = new Point(2, 49);
            btnUpdateUser.Name = "btnUpdateUser";
            btnUpdateUser.Size = new Size(296, 31);
            btnUpdateUser.TabIndex = 7;
            btnUpdateUser.Text = "Cập nhật họ tên / vai trò";
            btnUpdateUser.UseVisualStyleBackColor = true;
            btnUpdateUser.Click += btnUpdateUser_Click;
            // 
            // btnReload
            // 
            btnReload.Location = new Point(2, 88);
            btnReload.Name = "btnReload";
            btnReload.Size = new Size(296, 31);
            btnReload.TabIndex = 8;
            btnReload.Text = "Tải lại danh sách";
            btnReload.UseVisualStyleBackColor = true;
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
            groupBox2.Size = new Size(294, 324);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thông tin tài khoản";
            // 
            // cboRole
            // 
            cboRole.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRole.FormattingEnabled = true;
            cboRole.Location = new Point(11, 271);
            cboRole.Name = "cboRole";
            cboRole.Size = new Size(277, 28);
            cboRole.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(11, 245);
            label4.Name = "label4";
            label4.Size = new Size(52, 20);
            label4.TabIndex = 3;
            label4.Text = "Vai trò";
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPassword.Location = new Point(11, 200);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(277, 27);
            txtPassword.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 175);
            label3.Name = "label3";
            label3.Size = new Size(70, 20);
            label3.TabIndex = 2;
            label3.Text = "Mật khẩu";
            // 
            // txtFullName
            // 
            txtFullName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtFullName.Location = new Point(11, 129);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(277, 27);
            txtFullName.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 104);
            label2.Name = "label2";
            label2.Size = new Size(54, 20);
            label2.TabIndex = 1;
            label2.Text = "Họ tên";
            // 
            // txtUsername
            // 
            txtUsername.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtUsername.Location = new Point(11, 59);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(277, 27);
            txtUsername.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 33);
            label1.Name = "label1";
            label1.Size = new Size(107, 20);
            label1.TabIndex = 0;
            label1.Text = "Tên đăng nhập";
            // 
            // FormUserManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(950, 620);
            Controls.Add(panelRoot);
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

        private Panel panelButtons;
        private Button btnAddUser;
        private Button btnResetPassword;
        private Button btnToggleLock;
        private Button btnUpdateUser;

        private Button btnReload;
    }
}