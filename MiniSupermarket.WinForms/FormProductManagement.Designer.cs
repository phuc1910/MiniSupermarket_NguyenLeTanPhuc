namespace MiniSupermarket.WinForms
{
    partial class FormProductManagement
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
            btnSearch = new Button();
            cboFilterCategory = new ComboBox();
            txtSearchBarcode = new TextBox();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            dgvProducts = new DataGridView();
            groupBox3 = new GroupBox();
            cboCategory = new ComboBox();
            label8 = new Label();
            nudStock = new NumericUpDown();
            label7 = new Label();
            nudPrice = new NumericUpDown();
            label6 = new Label();
            txtProductName = new TextBox();
            label5 = new Label();
            txtBarcode = new TextBox();
            label4 = new Label();
            txtId = new TextBox();
            label3 = new Label();
            btnLoad = new Button();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPrice).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnSearch);
            groupBox1.Controls.Add(cboFilterCategory);
            groupBox1.Controls.Add(txtSearchBarcode);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(14, 16);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(887, 76);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tìm kiếm sản phẩm";
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(709, 29);
            btnSearch.Margin = new Padding(3, 4, 3, 4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(86, 31);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // cboFilterCategory
            // 
            cboFilterCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFilterCategory.FormattingEnabled = true;
            cboFilterCategory.Location = new Point(422, 29);
            cboFilterCategory.Margin = new Padding(3, 4, 3, 4);
            cboFilterCategory.Name = "cboFilterCategory";
            cboFilterCategory.Size = new Size(262, 28);
            cboFilterCategory.TabIndex = 1;
            // 
            // txtSearchBarcode
            // 
            txtSearchBarcode.Location = new Point(69, 29);
            txtSearchBarcode.Margin = new Padding(3, 4, 3, 4);
            txtSearchBarcode.Name = "txtSearchBarcode";
            txtSearchBarcode.PlaceholderText = "Nhập mã vạch...";
            txtSearchBarcode.Size = new Size(251, 27);
            txtSearchBarcode.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(337, 33);
            label2.Name = "label2";
            label2.Size = new Size(87, 20);
            label2.TabIndex = 1;
            label2.Text = "Nhóm hàng";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 33);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 0;
            label1.Text = "Mã vạch";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvProducts);
            groupBox2.Location = new Point(14, 100);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(594, 484);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh sách sản phẩm";
            // 
            // dgvProducts
            // 
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.AllowUserToResizeRows = false;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Location = new Point(7, 29);
            dgvProducts.Margin = new Padding(3, 4, 3, 4);
            dgvProducts.MultiSelect = false;
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.RowHeadersVisible = false;
            dgvProducts.RowHeadersWidth = 51;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Size = new Size(581, 447);
            dgvProducts.TabIndex = 0;
            dgvProducts.CellClick += dgvProducts_CellClick;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(cboCategory);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(nudStock);
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(nudPrice);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(txtProductName);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(txtBarcode);
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(txtId);
            groupBox3.Controls.Add(label3);
            groupBox3.Location = new Point(615, 100);
            groupBox3.Margin = new Padding(3, 4, 3, 4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 4, 3, 4);
            groupBox3.Size = new Size(286, 303);
            groupBox3.TabIndex = 4;
            groupBox3.TabStop = false;
            groupBox3.Text = "Thông tin sản phẩm";
            // 
            // cboCategory
            // 
            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategory.FormattingEnabled = true;
            cboCategory.Location = new Point(97, 252);
            cboCategory.Margin = new Padding(3, 4, 3, 4);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(179, 28);
            cboCategory.TabIndex = 5;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(7, 256);
            label8.Name = "label8";
            label8.Size = new Size(87, 20);
            label8.TabIndex = 5;
            label8.Text = "Nhóm hàng";
            // 
            // nudStock
            // 
            nudStock.Location = new Point(97, 207);
            nudStock.Margin = new Padding(3, 4, 3, 4);
            nudStock.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudStock.Name = "nudStock";
            nudStock.Size = new Size(179, 27);
            nudStock.TabIndex = 4;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(7, 211);
            label7.Name = "label7";
            label7.Size = new Size(62, 20);
            label7.TabIndex = 4;
            label7.Text = "Tồn kho";
            // 
            // nudPrice
            // 
            nudPrice.Location = new Point(97, 161);
            nudPrice.Margin = new Padding(3, 4, 3, 4);
            nudPrice.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nudPrice.Name = "nudPrice";
            nudPrice.Size = new Size(179, 27);
            nudPrice.TabIndex = 3;
            nudPrice.ThousandsSeparator = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(7, 165);
            label6.Name = "label6";
            label6.Size = new Size(62, 20);
            label6.TabIndex = 3;
            label6.Text = "Đơn giá";
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(97, 116);
            txtProductName.Margin = new Padding(3, 4, 3, 4);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(179, 27);
            txtProductName.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(7, 120);
            label5.Name = "label5";
            label5.Size = new Size(100, 20);
            label5.TabIndex = 2;
            label5.Text = "Tên sản phẩm";
            // 
            // txtBarcode
            // 
            txtBarcode.Location = new Point(97, 71);
            txtBarcode.Margin = new Padding(3, 4, 3, 4);
            txtBarcode.Name = "txtBarcode";
            txtBarcode.Size = new Size(179, 27);
            txtBarcode.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(7, 75);
            label4.Name = "label4";
            label4.Size = new Size(64, 20);
            label4.TabIndex = 1;
            label4.Text = "Mã vạch";
            // 
            // txtId
            // 
            txtId.Location = new Point(97, 25);
            txtId.Margin = new Padding(3, 4, 3, 4);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(179, 27);
            txtId.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(7, 29);
            label3.Name = "label3";
            label3.Size = new Size(49, 20);
            label3.TabIndex = 0;
            label3.Text = "Mã ID";
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(615, 420);
            btnLoad.Margin = new Padding(3, 4, 3, 4);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(67, 31);
            btnLoad.TabIndex = 5;
            btnLoad.Text = "Tải lại";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(689, 420);
            btnAdd.Margin = new Padding(3, 4, 3, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(67, 31);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(763, 420);
            btnUpdate.Margin = new Padding(3, 4, 3, 4);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(67, 31);
            btnUpdate.TabIndex = 7;
            btnUpdate.Text = "Sửa";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(838, 420);
            btnDelete.Margin = new Padding(3, 4, 3, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(63, 31);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // FormProductManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(btnLoad);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormProductManagement";
            Text = "Quản lý sản phẩm & kho hàng";
            Load += FormProductManagement_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPrice).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private TextBox txtSearchBarcode;
        private Label label2;
        private ComboBox cboFilterCategory;
        private Button btnSearch;

        private GroupBox groupBox2;
        private DataGridView dgvProducts;

        private GroupBox groupBox3;
        private Label label3;
        private TextBox txtId;
        private Label label4;
        private TextBox txtBarcode;
        private Label label5;
        private TextBox txtProductName;
        private Label label6;
        private NumericUpDown nudPrice;
        private Label label7;
        private NumericUpDown nudStock;
        private Label label8;
        private ComboBox cboCategory;

        private Button btnLoad;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
    }
}