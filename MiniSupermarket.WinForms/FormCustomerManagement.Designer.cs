namespace MiniSupermarket.WinForms
{
    partial class FormCustomerManagement
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
            panelSearchActions = new TableLayoutPanel();
            btnLoad = new Button();
            txtKeyword = new TextBox();
            btnSearch = new Button();
            tableLayoutPanelContent = new TableLayoutPanel();
            groupBox2 = new GroupBox();
            dgvCustomers = new DataGridView();
            panelDetail = new Panel();
            panelButtons = new TableLayoutPanel();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            groupBox4 = new GroupBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtCustomerId = new TextBox();
            txtCustomerName = new TextBox();
            txtPhoneNumber = new TextBox();
            txtAddress = new TextBox();
            txtRewardPoints = new TextBox();
            txtMembershipRank = new TextBox();
            groupBox1 = new GroupBox();
            panelRoot.SuspendLayout();
            panelSearchActions.SuspendLayout();
            tableLayoutPanelContent.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
            panelDetail.SuspendLayout();
            panelButtons.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // panelRoot
            // 
            panelRoot.Controls.Add(tableLayoutPanelContent);
            panelRoot.Controls.Add(groupBox1);
            panelRoot.Dock = DockStyle.Fill;
            panelRoot.Location = new Point(0, 0);
            panelRoot.Margin = new Padding(3, 4, 3, 4);
            panelRoot.Name = "panelRoot";
            panelRoot.BackColor = Color.FromArgb(242, 245, 250);
            panelRoot.Padding = new Padding(16);
            panelRoot.Size = new Size(1029, 667);
            panelRoot.TabIndex = 0;
            // 
            // panelSearchActions
            // 
            panelSearchActions.Location = new Point(11, 54);
            panelSearchActions.Margin = new Padding(0);
            panelSearchActions.Name = "panelSearchActions";
            panelSearchActions.ColumnCount = 3;
            panelSearchActions.RowCount = 1;
            panelSearchActions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            panelSearchActions.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 128F));
            panelSearchActions.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 112F));
            panelSearchActions.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            panelSearchActions.Controls.Add(txtKeyword, 0, 0);
            panelSearchActions.Controls.Add(btnSearch, 1, 0);
            panelSearchActions.Controls.Add(btnLoad, 2, 0);
            panelSearchActions.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelSearchActions.Padding = new Padding(0);
            panelSearchActions.Dock = DockStyle.Fill;
            panelSearchActions.Size = new Size(1004, 52);
            panelSearchActions.TabIndex = 1;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(881, 12);
            btnLoad.Margin = new Padding(0, 3, 8, 3);
            btnLoad.Name = "btnLoad";
            btnLoad.Dock = DockStyle.Fill;
            btnLoad.AutoSize = false;
            btnLoad.Cursor = Cursors.Hand;
            btnLoad.FlatAppearance.MouseDownBackColor = Color.FromArgb(203, 217, 235);
            btnLoad.FlatAppearance.MouseOverBackColor = Color.FromArgb(221, 230, 241);
            btnLoad.FlatAppearance.BorderSize = 0;
            btnLoad.FlatStyle = FlatStyle.Flat;
            btnLoad.ForeColor = Color.FromArgb(22, 54, 90);
            btnLoad.BackColor = Color.FromArgb(238, 242, 247);
            btnLoad.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnLoad.Size = new Size(96, 38);
            btnLoad.TabIndex = 2;
            btnLoad.Text = "Tải lại";
            btnLoad.UseVisualStyleBackColor = false;
            btnLoad.Click += btnLoad_Click;
            // 
            // txtKeyword
            // 
            txtKeyword.Location = new Point(7, 12);
            txtKeyword.Margin = new Padding(0, 8, 12, 8);
            txtKeyword.Name = "txtKeyword";
            txtKeyword.Dock = DockStyle.Fill;
            txtKeyword.BorderStyle = BorderStyle.FixedSingle;
            txtKeyword.BackColor = Color.White;
            txtKeyword.ForeColor = Color.FromArgb(31, 41, 55);
            txtKeyword.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtKeyword.PlaceholderText = "Nhập từ khóa...";
            txtKeyword.Size = new Size(744, 27);
            txtKeyword.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(757, 12);
            btnSearch.Margin = new Padding(0, 3, 8, 3);
            btnSearch.Name = "btnSearch";
            btnSearch.Dock = DockStyle.Fill;
            btnSearch.AutoSize = false;
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 64, 175);
            btnSearch.FlatAppearance.MouseOverBackColor = Color.FromArgb(29, 78, 216);
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.ForeColor = Color.White;
            btnSearch.BackColor = Color.FromArgb(37, 99, 235);
            btnSearch.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnSearch.Size = new Size(96, 38);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // tableLayoutPanelContent
            // 
            tableLayoutPanelContent.ColumnCount = 2;
            tableLayoutPanelContent.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelContent.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 320F));
            tableLayoutPanelContent.Controls.Add(groupBox2, 0, 0);
            tableLayoutPanelContent.Controls.Add(panelDetail, 1, 0);
            tableLayoutPanelContent.Dock = DockStyle.Fill;
            tableLayoutPanelContent.Location = new Point(11, 121);
            tableLayoutPanelContent.Margin = new Padding(0);
            tableLayoutPanelContent.Name = "tableLayoutPanelContent";
            tableLayoutPanelContent.Padding = new Padding(0, 12, 0, 0);
            tableLayoutPanelContent.RowCount = 1;
            tableLayoutPanelContent.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelContent.Size = new Size(1007, 533);
            tableLayoutPanelContent.TabIndex = 1;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvCustomers);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(0, 11);
            groupBox2.Margin = new Padding(0, 0, 12, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox2.ForeColor = Color.FromArgb(22, 54, 90);
            groupBox2.BackColor = Color.White;
            groupBox2.Padding = new Padding(12);
            groupBox2.Size = new Size(735, 522);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh sách khách hàng";
            // 
            // dgvCustomers
            // 
            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvCustomers.Dock = DockStyle.Fill;
            dgvCustomers.Location = new Point(7, 28);
            dgvCustomers.Margin = new Padding(0);
            dgvCustomers.Name = "dgvCustomers";
            dgvCustomers.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dgvCustomers.AllowUserToDeleteRows = false;
            dgvCustomers.AllowUserToAddRows = false;
            dgvCustomers.AllowUserToResizeRows = false;
            dgvCustomers.RowTemplate.Height = 36;
            dgvCustomers.RowHeadersVisible = false;
            dgvCustomers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCustomers.GridColor = Color.FromArgb(235, 240, 247);
            dgvCustomers.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 253);
            dgvCustomers.DefaultCellStyle.Padding = new Padding(8, 0, 8, 0);
            dgvCustomers.DefaultCellStyle.SelectionForeColor = Color.FromArgb(22, 54, 90);
            dgvCustomers.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 234, 254);
            dgvCustomers.DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dgvCustomers.DefaultCellStyle.ForeColor = Color.FromArgb(31, 41, 55);
            dgvCustomers.DefaultCellStyle.BackColor = Color.White;
            dgvCustomers.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 0, 8, 0);
            dgvCustomers.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(22, 54, 90);
            dgvCustomers.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(232, 239, 250);
            dgvCustomers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            dgvCustomers.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(22, 54, 90);
            dgvCustomers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(232, 239, 250);
            dgvCustomers.ColumnHeadersHeight = 42;
            dgvCustomers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvCustomers.EnableHeadersVisualStyles = false;
            dgvCustomers.BorderStyle = BorderStyle.None;
            dgvCustomers.BackgroundColor = Color.White;
            dgvCustomers.RowHeadersWidth = 51;
            dgvCustomers.Size = new Size(721, 486);
            dgvCustomers.TabIndex = 0;
            dgvCustomers.CellClick += dgvCustomers_CellClick;
            // 
            // panelDetail
            // 
            panelDetail.Controls.Add(panelButtons);
            panelDetail.Controls.Add(groupBox4);
            panelDetail.Dock = DockStyle.Fill;
            panelDetail.Location = new Point(747, 15);
            panelDetail.Margin = new Padding(0);
            panelDetail.Name = "panelDetail";
            panelDetail.AutoScroll = true;
            panelDetail.BackColor = Color.White;
            panelDetail.Size = new Size(320, 560);
            panelDetail.TabIndex = 1;
            // 
            // panelButtons
            // 
            panelButtons.Dock = DockStyle.Top;
            panelButtons.Location = new Point(0, 400);
            panelButtons.Margin = new Padding(0);
            panelButtons.Name = "panelButtons";
            panelButtons.BackColor = Color.White;
            panelButtons.Padding = new Padding(12, 8, 12, 8);
            panelButtons.ColumnCount = 3;
            panelButtons.RowCount = 1;
            panelButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.333333333333336F));
            panelButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.333333333333336F));
            panelButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.333333333333336F));
            panelButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            panelButtons.Controls.Add(btnAdd, 0, 0);
            panelButtons.Controls.Add(btnUpdate, 1, 0);
            panelButtons.Controls.Add(btnDelete, 2, 0);
            panelButtons.Size = new Size(320, 64);
            panelButtons.TabIndex = 1;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(7, 13);
            btnAdd.Margin = new Padding(4);
            btnAdd.Name = "btnAdd";
            btnAdd.Dock = DockStyle.Fill;
            btnAdd.AutoSize = false;
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 64, 175);
            btnAdd.FlatAppearance.MouseOverBackColor = Color.FromArgb(29, 78, 216);
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.ForeColor = Color.White;
            btnAdd.BackColor = Color.FromArgb(37, 99, 235);
            btnAdd.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnAdd.Size = new Size(96, 38);
            btnAdd.TabIndex = 12;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(88, 13);
            btnUpdate.Margin = new Padding(4);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Dock = DockStyle.Fill;
            btnUpdate.AutoSize = false;
            btnUpdate.Cursor = Cursors.Hand;
            btnUpdate.FlatAppearance.MouseDownBackColor = Color.FromArgb(203, 217, 235);
            btnUpdate.FlatAppearance.MouseOverBackColor = Color.FromArgb(221, 230, 241);
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.ForeColor = Color.FromArgb(22, 54, 90);
            btnUpdate.BackColor = Color.FromArgb(238, 242, 247);
            btnUpdate.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnUpdate.Size = new Size(96, 38);
            btnUpdate.TabIndex = 13;
            btnUpdate.Text = "Sửa";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(169, 13);
            btnDelete.Margin = new Padding(4);
            btnDelete.Name = "btnDelete";
            btnDelete.Dock = DockStyle.Fill;
            btnDelete.AutoSize = false;
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatAppearance.MouseDownBackColor = Color.FromArgb(252, 165, 165);
            btnDelete.FlatAppearance.MouseOverBackColor = Color.FromArgb(254, 202, 202);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.ForeColor = Color.FromArgb(153, 27, 27);
            btnDelete.BackColor = Color.FromArgb(254, 226, 226);
            btnDelete.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnDelete.Size = new Size(96, 38);
            btnDelete.TabIndex = 14;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(label1);
            groupBox4.Controls.Add(label2);
            groupBox4.Controls.Add(label3);
            groupBox4.Controls.Add(label4);
            groupBox4.Controls.Add(label5);
            groupBox4.Controls.Add(label6);
            groupBox4.Controls.Add(txtCustomerId);
            groupBox4.Controls.Add(txtCustomerName);
            groupBox4.Controls.Add(txtPhoneNumber);
            groupBox4.Controls.Add(txtAddress);
            groupBox4.Controls.Add(txtRewardPoints);
            groupBox4.Controls.Add(txtMembershipRank);
            groupBox4.Dock = DockStyle.Top;
            groupBox4.Location = new Point(0, 0);
            groupBox4.Margin = new Padding(0);
            groupBox4.Name = "groupBox4";
            groupBox4.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox4.ForeColor = Color.FromArgb(22, 54, 90);
            groupBox4.BackColor = Color.White;
            groupBox4.Padding = new Padding(12);
            groupBox4.Size = new Size(320, 340);
            groupBox4.TabIndex = 0;
            groupBox4.TabStop = false;
            groupBox4.Text = "Thông tin khách hàng";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 28);
            label1.Name = "label1";
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(22, 54, 90);
            label1.Size = new Size(57, 20);
            label1.TabIndex = 0;
            label1.Text = "Mã khách hàng";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 88);
            label2.Name = "label2";
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.FromArgb(22, 54, 90);
            label2.Size = new Size(63, 20);
            label2.TabIndex = 1;
            label2.Text = "Họ và tên";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 148);
            label3.Name = "label3";
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.FromArgb(22, 54, 90);
            label3.Size = new Size(39, 20);
            label3.TabIndex = 2;
            label3.Text = "Số điện thoại";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 208);
            label4.Name = "label4";
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.FromArgb(22, 54, 90);
            label4.Size = new Size(62, 20);
            label4.TabIndex = 3;
            label4.Text = "Địa chỉ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(16, 268);
            label5.Name = "label5";
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.FromArgb(22, 54, 90);
            label5.Size = new Size(48, 20);
            label5.TabIndex = 4;
            label5.Text = "Điểm tích lũy";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(168, 268);
            label6.Name = "label6";
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label6.ForeColor = Color.FromArgb(22, 54, 90);
            label6.Size = new Size(48, 20);
            label6.TabIndex = 5;
            label6.Text = "Hạng thành viên";
            // 
            // txtCustomerId
            // 
            txtCustomerId.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCustomerId.Location = new Point(16, 54);
            txtCustomerId.Margin = new Padding(0);
            txtCustomerId.Name = "txtCustomerId";
            txtCustomerId.BorderStyle = BorderStyle.FixedSingle;
            txtCustomerId.BackColor = Color.FromArgb(238, 242, 247);
            txtCustomerId.ForeColor = Color.FromArgb(31, 41, 55);
            txtCustomerId.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtCustomerId.Size = new Size(288, 28);
            txtCustomerId.TabIndex = 6;
            // 
            // txtCustomerName
            // 
            txtCustomerName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCustomerName.Location = new Point(16, 114);
            txtCustomerName.Margin = new Padding(0);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.BorderStyle = BorderStyle.FixedSingle;
            txtCustomerName.BackColor = Color.White;
            txtCustomerName.ForeColor = Color.FromArgb(31, 41, 55);
            txtCustomerName.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtCustomerName.Size = new Size(288, 28);
            txtCustomerName.TabIndex = 7;
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPhoneNumber.Location = new Point(16, 174);
            txtPhoneNumber.Margin = new Padding(0);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.BorderStyle = BorderStyle.FixedSingle;
            txtPhoneNumber.BackColor = Color.White;
            txtPhoneNumber.ForeColor = Color.FromArgb(31, 41, 55);
            txtPhoneNumber.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtPhoneNumber.Size = new Size(288, 28);
            txtPhoneNumber.TabIndex = 8;
            // 
            // txtAddress
            // 
            txtAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtAddress.Location = new Point(16, 234);
            txtAddress.Margin = new Padding(0);
            txtAddress.Name = "txtAddress";
            txtAddress.BorderStyle = BorderStyle.FixedSingle;
            txtAddress.BackColor = Color.White;
            txtAddress.ForeColor = Color.FromArgb(31, 41, 55);
            txtAddress.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtAddress.Size = new Size(288, 28);
            txtAddress.TabIndex = 9;
            // 
            // txtRewardPoints
            // 
            txtRewardPoints.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtRewardPoints.Location = new Point(16, 294);
            txtRewardPoints.Margin = new Padding(0);
            txtRewardPoints.Name = "txtRewardPoints";
            txtRewardPoints.BorderStyle = BorderStyle.FixedSingle;
            txtRewardPoints.BackColor = Color.White;
            txtRewardPoints.ForeColor = Color.FromArgb(31, 41, 55);
            txtRewardPoints.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtRewardPoints.Size = new Size(136, 28);
            txtRewardPoints.TabIndex = 10;
            // 
            // txtMembershipRank
            // 
            txtMembershipRank.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMembershipRank.Location = new Point(168, 294);
            txtMembershipRank.Margin = new Padding(0);
            txtMembershipRank.Name = "txtMembershipRank";
            txtMembershipRank.BorderStyle = BorderStyle.FixedSingle;
            txtMembershipRank.BackColor = Color.White;
            txtMembershipRank.ForeColor = Color.FromArgb(31, 41, 55);
            txtMembershipRank.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtMembershipRank.Size = new Size(136, 28);
            txtMembershipRank.TabIndex = 11;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(panelSearchActions);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(11, 21);
            groupBox1.Margin = new Padding(0, 0, 12, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.ForeColor = Color.FromArgb(22, 54, 90);
            groupBox1.BackColor = Color.White;
            groupBox1.Padding = new Padding(16, 10, 16, 14);
            groupBox1.Size = new Size(968, 88);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tìm kiếm";
            // 
            // FormCustomerManagement
            // 
            Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            BackColor = Color.FromArgb(242, 245, 250);
            ForeColor = Color.FromArgb(31, 41, 55);
            StartPosition = FormStartPosition.CenterParent;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1029, 667);
            Controls.Add(panelRoot);
            panelRoot.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(946, 624);
            Name = "FormCustomerManagement";
            Text = "Quản lý khách hàng thân thiết";
            Load += FormCustomerManagement_Load;
            panelRoot.ResumeLayout(false);
            panelSearchActions.ResumeLayout(false);
            panelSearchActions.PerformLayout();
            tableLayoutPanelContent.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
            panelDetail.ResumeLayout(false);
            panelButtons.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelRoot;
        private GroupBox groupBox1;
        private TableLayoutPanel panelSearchActions;
        private TextBox txtKeyword;
        private Button btnSearch;
        private Button btnLoad;
        private TableLayoutPanel tableLayoutPanelContent;
        private GroupBox groupBox2;
        private DataGridView dgvCustomers;
        private Panel panelDetail;
        private GroupBox groupBox4;
        private TextBox txtMembershipRank;
        private TextBox txtRewardPoints;
        private TextBox txtAddress;
        private TextBox txtPhoneNumber;
        private TextBox txtCustomerName;
        private TextBox txtCustomerId;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TableLayoutPanel panelButtons;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnAdd;
    }
}
