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
            groupBox1 = new GroupBox();
            txtKeyword = new TextBox();
            btnSearch = new Button();
            btnLoad = new Button();
            groupBox2 = new GroupBox();
            dgvCustomers = new DataGridView();
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
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnLoad);
            groupBox1.Controls.Add(btnSearch);
            groupBox1.Controls.Add(txtKeyword);
            groupBox1.Location = new Point(10, 16);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(610, 56);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tìm kiếm";
            // 
            // txtKeyword
            // 
            txtKeyword.Location = new Point(6, 22);
            txtKeyword.Name = "txtKeyword";
            txtKeyword.PlaceholderText = "Nhập từ khóa...";
            txtKeyword.Size = new Size(440, 23);
            txtKeyword.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(452, 22);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(73, 23);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(531, 22);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(73, 23);
            btnLoad.TabIndex = 2;
            btnLoad.Text = "Tải lại";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvCustomers);
            groupBox2.Location = new Point(9, 78);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(591, 343);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh sách khách hàng";
            // 
            // dgvCustomers
            // 
            dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomers.Location = new Point(7, 22);
            dgvCustomers.Name = "dgvCustomers";
            dgvCustomers.Size = new Size(583, 315);
            dgvCustomers.TabIndex = 0;
            dgvCustomers.CellClick += dgvCustomers_CellClick;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(btnDelete);
            groupBox4.Controls.Add(btnUpdate);
            groupBox4.Controls.Add(btnAdd);
            groupBox4.Controls.Add(txtMembershipRank);
            groupBox4.Controls.Add(txtRewardPoints);
            groupBox4.Controls.Add(txtAddress);
            groupBox4.Controls.Add(txtPhoneNumber);
            groupBox4.Controls.Add(txtCustomerName);
            groupBox4.Controls.Add(txtCustomerId);
            groupBox4.Controls.Add(label6);
            groupBox4.Controls.Add(label5);
            groupBox4.Controls.Add(label4);
            groupBox4.Controls.Add(label3);
            groupBox4.Controls.Add(label2);
            groupBox4.Controls.Add(label1);
            groupBox4.Location = new Point(605, 78);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(195, 343);
            groupBox4.TabIndex = 3;
            groupBox4.TabStop = false;
            groupBox4.Text = "Thông tin khách hàng";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 22);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 0;
            label1.Text = "Mã KH:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 75);
            label2.Name = "label2";
            label2.Size = new Size(50, 15);
            label2.TabIndex = 1;
            label2.Text = "Tên KH: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(9, 119);
            label3.Name = "label3";
            label3.Size = new Size(30, 15);
            label3.TabIndex = 2;
            label3.Text = "SĐT:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(9, 163);
            label4.Name = "label4";
            label4.Size = new Size(49, 15);
            label4.TabIndex = 3;
            label4.Text = " Địa chỉ:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(9, 207);
            label5.Name = "label5";
            label5.Size = new Size(38, 15);
            label5.TabIndex = 4;
            label5.Text = "Điểm:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(9, 251);
            label6.Name = "label6";
            label6.Size = new Size(39, 15);
            label6.TabIndex = 5;
            label6.Text = "Hạng:";
            // 
            // txtCustomerId
            // 
            txtCustomerId.Location = new Point(9, 41);
            txtCustomerId.Name = "txtCustomerId";
            txtCustomerId.Size = new Size(174, 23);
            txtCustomerId.TabIndex = 6;
            // 
            // txtCustomerName
            // 
            txtCustomerName.Location = new Point(9, 93);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.Size = new Size(174, 23);
            txtCustomerName.TabIndex = 7;
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(9, 137);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(174, 23);
            txtPhoneNumber.TabIndex = 8;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(9, 181);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(174, 23);
            txtAddress.TabIndex = 9;
            // 
            // txtRewardPoints
            // 
            txtRewardPoints.Location = new Point(9, 225);
            txtRewardPoints.Name = "txtRewardPoints";
            txtRewardPoints.Size = new Size(174, 23);
            txtRewardPoints.TabIndex = 10;
            // 
            // txtMembershipRank
            // 
            txtMembershipRank.Location = new Point(9, 269);
            txtMembershipRank.Name = "txtMembershipRank";
            txtMembershipRank.Size = new Size(174, 23);
            txtMembershipRank.TabIndex = 11;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(6, 312);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(59, 23);
            btnAdd.TabIndex = 12;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(71, 312);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(58, 23);
            btnUpdate.TabIndex = 13;
            btnUpdate.Text = "Sửa";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(135, 312);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(59, 23);
            btnDelete.TabIndex = 14;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // FormCustomerManagement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(807, 450);
            Controls.Add(groupBox4);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "FormCustomerManagement";
            Text = "FormCustomerManagement";
            Load += FormCustomerManagement_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtKeyword;
        private Button btnSearch;
        private Button btnLoad;
        private GroupBox groupBox2;
        private DataGridView dgvCustomers;
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
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnAdd;
    }
}