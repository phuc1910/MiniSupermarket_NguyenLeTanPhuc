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
            groupBox1 = new GroupBox();
            dgvUsers = new DataGridView();
            groupBox2 = new GroupBox();
            cboRole = new ComboBox();
            label4 = new Label();
            txtPassword = new TextBox();
            label3 = new Label();
            txtFullName = new TextBox();
            label2 = new Label();
            txtUsername = new TextBox();
            label1 = new Label();
            btnAddUser = new Button();
            btnResetPassword = new Button();
            btnToggleLock = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgvUsers);
            groupBox1.Location = new Point(14, 16);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(594, 568);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Danh sách tài khoản";
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.AllowUserToResizeRows = false;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Location = new Point(7, 29);
            dgvUsers.Margin = new Padding(3, 4, 3, 4);
            dgvUsers.MultiSelect = false;
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.RowHeadersVisible = false;
            dgvUsers.RowHeadersWidth = 51;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.Size = new Size(581, 531);
            dgvUsers.TabIndex = 0;
            dgvUsers.CellClick += dgvUsers_CellClick;
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
            groupBox2.Location = new Point(615, 16);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(286, 324);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thông tin tài khoản";
            // 
            // cboRole
            // 
            cboRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRole.FormattingEnabled = true;
            cboRole.Location = new Point(11, 271);
            cboRole.Margin = new Padding(3, 4, 3, 4);
            cboRole.Name = "cboRole";
            cboRole.Size = new Size(262, 28);
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
            txtPassword.Location = new Point(11, 200);
            txtPassword.Margin = new Padding(3, 4, 3, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(262, 27);
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
            txtFullName.Location = new Point(11, 129);
            txtFullName.Margin = new Padding(3, 4, 3, 4);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(262, 27);
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
            txtUsername.Location = new Point(11, 59);
            txtUsername.Margin = new Padding(3, 4, 3, 4);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(262, 27);
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
            // btnAddUser
            // 
            btnAddUser.Location = new Point(617, 348);
            btnAddUser.Margin = new Padding(3, 4, 3, 4);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new Size(86, 31);
            btnAddUser.TabIndex = 4;
            btnAddUser.Text = "Thêm";
            btnAddUser.UseVisualStyleBackColor = true;
            btnAddUser.Click += btnAddUser_Click;
            // 
            // btnResetPassword
            // 
            btnResetPassword.Location = new Point(709, 348);
            btnResetPassword.Margin = new Padding(3, 4, 3, 4);
            btnResetPassword.Name = "btnResetPassword";
            btnResetPassword.Size = new Size(86, 31);
            btnResetPassword.TabIndex = 5;
            btnResetPassword.Text = "Đặt MK";
            btnResetPassword.UseVisualStyleBackColor = true;
            btnResetPassword.Click += btnResetPassword_Click;
            // 
            // btnToggleLock
            // 
            btnToggleLock.Location = new Point(802, 348);
            btnToggleLock.Margin = new Padding(3, 4, 3, 4);
            btnToggleLock.Name = "btnToggleLock";
            btnToggleLock.Size = new Size(101, 31);
            btnToggleLock.TabIndex = 6;
            btnToggleLock.Text = "Khóa/Mở";
            btnToggleLock.UseVisualStyleBackColor = true;
            btnToggleLock.Click += btnToggleLock_Click;
            // btnUpdateUser
            btnUpdateUser = new Button();
            btnUpdateUser.Location = new Point(617, 390);
            btnUpdateUser.Name = "btnUpdateUser";
            btnUpdateUser.Size = new Size(286, 31);
            btnUpdateUser.TabIndex = 7;
            btnUpdateUser.Text = "Cập nhật họ tên / vai trò";
            btnUpdateUser.UseVisualStyleBackColor = true;
            btnUpdateUser.Click += btnUpdateUser_Click;

            // btnReload
            btnReload = new Button();
            btnReload.Location = new Point(617, 432);
            btnReload.Name = "btnReload";
            btnReload.Size = new Size(286, 31);
            btnReload.TabIndex = 8;
            btnReload.Text = "Tải lại danh sách";
            btnReload.UseVisualStyleBackColor = true;
            btnReload.Click += btnReload_Click;
            // 
            // FormUserManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(btnUpdateUser);
            Controls.Add(btnReload);
            Controls.Add(btnToggleLock);
            Controls.Add(btnResetPassword);
            Controls.Add(btnAddUser);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormUserManagement";
            Text = "Quản lý tài khoản";
            Load += FormUserManagement_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private DataGridView dgvUsers;

        private GroupBox groupBox2;

        private Label label1;
        private TextBox txtUsername;

        private Label label2;
        private TextBox txtFullName;

        private Label label3;
        private TextBox txtPassword;

        private Label label4;
        private ComboBox cboRole;

        private Button btnAddUser;
        private Button btnResetPassword;
        private Button btnToggleLock;
        private Button btnUpdateUser;

        private Button btnReload;
    }
}