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
            panelSearchActions = new Panel();
            btnLoad = new Button();
            txtKeyword = new TextBox();
            btnSearch = new Button();
            tableLayoutPanelContent = new TableLayoutPanel();
            groupBox2 = new GroupBox();
            dgvCustomers = new DataGridView();
            panelDetail = new Panel();
            panelButtons = new Panel();
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
            panelRoot.Controls.Add(panelSearchActions);
            panelRoot.Controls.Add(tableLayoutPanelContent);
            panelRoot.Controls.Add(groupBox1);
            panelRoot.Dock = DockStyle.Fill;
            panelRoot.Location = new Point(0, 0);
            panelRoot.Margin = new Padding(3, 4, 3, 4);
            panelRoot.Name = "panelRoot";
            panelRoot.Padding = new Padding(11, 21, 11, 13);
            panelRoot.Size = new Size(1029, 667);
            panelRoot.TabIndex = 0;
            // 
            // panelSearchActions
            // 
            panelSearchActions.Controls.Add(btnLoad);
            panelSearchActions.Controls.Add(txtKeyword);
            panelSearchActions.Controls.Add(btnSearch);
            panelSearchActions.Location = new Point(11, 54);
            panelSearchActions.Margin = new Padding(3, 4, 3, 4);
            panelSearchActions.Name = "panelSearchActions";
            panelSearchActions.Size = new Size(1004, 52);
            panelSearchActions.TabIndex = 1;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(881, 12);
            btnLoad.Margin = new Padding(3, 4, 3, 4);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(120, 27);
            btnLoad.TabIndex = 2;
            btnLoad.Text = "Tải lại";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // txtKeyword
            // 
            txtKeyword.Location = new Point(7, 12);
            txtKeyword.Margin = new Padding(3, 4, 3, 4);
            txtKeyword.Name = "txtKeyword";
            txtKeyword.PlaceholderText = "Nhập từ khóa...";
            txtKeyword.Size = new Size(744, 27);
            txtKeyword.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(757, 12);
            btnSearch.Margin = new Padding(3, 4, 3, 4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(120, 27);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // tableLayoutPanelContent
            // 
            tableLayoutPanelContent.ColumnCount = 2;
            tableLayoutPanelContent.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelContent.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 263F));
            tableLayoutPanelContent.Controls.Add(groupBox2, 0, 0);
            tableLayoutPanelContent.Controls.Add(panelDetail, 1, 0);
            tableLayoutPanelContent.Dock = DockStyle.Fill;
            tableLayoutPanelContent.Location = new Point(11, 121);
            tableLayoutPanelContent.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanelContent.Name = "tableLayoutPanelContent";
            tableLayoutPanelContent.Padding = new Padding(0, 11, 0, 0);
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
            groupBox2.Margin = new Padding(0, 0, 9, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(7, 8, 7, 8);
            groupBox2.Size = new Size(735, 522);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh sách khách hàng";
            // 
            // dgvCustomers
            // 
            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomers.Dock = DockStyle.Fill;
            dgvCustomers.Location = new Point(7, 28);
            dgvCustomers.Margin = new Padding(3, 4, 3, 4);
            dgvCustomers.Name = "dgvCustomers";
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
            panelDetail.Margin = new Padding(3, 4, 3, 4);
            panelDetail.Name = "panelDetail";
            panelDetail.Size = new Size(257, 514);
            panelDetail.TabIndex = 1;
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(btnAdd);
            panelButtons.Controls.Add(btnUpdate);
            panelButtons.Controls.Add(btnDelete);
            panelButtons.Dock = DockStyle.Top;
            panelButtons.Location = new Point(0, 400);
            panelButtons.Margin = new Padding(3, 4, 3, 4);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(257, 67);
            panelButtons.TabIndex = 1;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(7, 13);
            btnAdd.Margin = new Padding(3, 4, 3, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(74, 40);
            btnAdd.TabIndex = 12;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(88, 13);
            btnUpdate.Margin = new Padding(3, 4, 3, 4);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(74, 40);
            btnUpdate.TabIndex = 13;
            btnUpdate.Text = "Sửa";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(169, 13);
            btnDelete.Margin = new Padding(3, 4, 3, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(74, 40);
            btnDelete.TabIndex = 14;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = true;
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
            groupBox4.Margin = new Padding(3, 4, 3, 4);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(3, 4, 3, 4);
            groupBox4.Size = new Size(257, 400);
            groupBox4.TabIndex = 0;
            groupBox4.TabStop = false;
            groupBox4.Text = "Thông tin khách hàng";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 29);
            label1.Name = "label1";
            label1.Size = new Size(57, 20);
            label1.TabIndex = 0;
            label1.Text = "Mã KH:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 100);
            label2.Name = "label2";
            label2.Size = new Size(63, 20);
            label2.TabIndex = 1;
            label2.Text = "Tên KH: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 159);
            label3.Name = "label3";
            label3.Size = new Size(39, 20);
            label3.TabIndex = 2;
            label3.Text = "SĐT:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(10, 217);
            label4.Name = "label4";
            label4.Size = new Size(62, 20);
            label4.TabIndex = 3;
            label4.Text = " Địa chỉ:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(10, 276);
            label5.Name = "label5";
            label5.Size = new Size(48, 20);
            label5.TabIndex = 4;
            label5.Text = "Điểm:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(10, 335);
            label6.Name = "label6";
            label6.Size = new Size(48, 20);
            label6.TabIndex = 5;
            label6.Text = "Hạng:";
            // 
            // txtCustomerId
            // 
            txtCustomerId.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCustomerId.Location = new Point(10, 55);
            txtCustomerId.Margin = new Padding(3, 4, 3, 4);
            txtCustomerId.Name = "txtCustomerId";
            txtCustomerId.Size = new Size(244, 27);
            txtCustomerId.TabIndex = 6;
            // 
            // txtCustomerName
            // 
            txtCustomerName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCustomerName.Location = new Point(10, 124);
            txtCustomerName.Margin = new Padding(3, 4, 3, 4);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.Size = new Size(244, 27);
            txtCustomerName.TabIndex = 7;
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPhoneNumber.Location = new Point(10, 183);
            txtPhoneNumber.Margin = new Padding(3, 4, 3, 4);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(244, 27);
            txtPhoneNumber.TabIndex = 8;
            // 
            // txtAddress
            // 
            txtAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtAddress.Location = new Point(10, 241);
            txtAddress.Margin = new Padding(3, 4, 3, 4);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(244, 27);
            txtAddress.TabIndex = 9;
            // 
            // txtRewardPoints
            // 
            txtRewardPoints.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtRewardPoints.Location = new Point(10, 300);
            txtRewardPoints.Margin = new Padding(3, 4, 3, 4);
            txtRewardPoints.Name = "txtRewardPoints";
            txtRewardPoints.Size = new Size(244, 27);
            txtRewardPoints.TabIndex = 10;
            // 
            // txtMembershipRank
            // 
            txtMembershipRank.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMembershipRank.Location = new Point(10, 359);
            txtMembershipRank.Margin = new Padding(3, 4, 3, 4);
            txtMembershipRank.Name = "txtMembershipRank";
            txtMembershipRank.Size = new Size(244, 27);
            txtMembershipRank.TabIndex = 11;
            // 
            // groupBox1
            // 
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(11, 21);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(9, 27, 9, 11);
            groupBox1.Size = new Size(1007, 100);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tìm kiếm";
            // 
            // FormCustomerManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1029, 667);
            Controls.Add(panelRoot);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(946, 624);
            Name = "FormCustomerManagement";
            Text = "FormCustomerManagement";
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
        private Panel panelSearchActions;
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
        private Panel panelButtons;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnAdd;
    }
}