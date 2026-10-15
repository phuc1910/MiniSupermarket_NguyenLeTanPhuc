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
            panelRoot = new Panel();
            tableLayoutPanelContent = new TableLayoutPanel();
            groupBox2 = new GroupBox();
            dgvProducts = new DataGridView();
            panelDetail = new Panel();
            panelButtons = new Panel();
            btnLoad = new Button();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
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
            groupBox1 = new GroupBox();
            panelSearchActions = new Panel();
            txtSearchBarcode = new TextBox();
            btnSearch = new Button();
            cboFilterCategory = new ComboBox();
            label2 = new Label();
            panelRoot.SuspendLayout();
            tableLayoutPanelContent.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            panelDetail.SuspendLayout();
            panelButtons.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPrice).BeginInit();
            groupBox1.SuspendLayout();
            panelSearchActions.SuspendLayout();
            SuspendLayout();
            // 
            // panelRoot
            // 
            panelRoot.Controls.Add(tableLayoutPanelContent);
            panelRoot.Controls.Add(groupBox1);
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
            tableLayoutPanelContent.Controls.Add(groupBox2, 0, 0);
            tableLayoutPanelContent.Controls.Add(panelDetail, 1, 0);
            tableLayoutPanelContent.Dock = DockStyle.Fill;
            tableLayoutPanelContent.Location = new Point(14, 92);
            tableLayoutPanelContent.Name = "tableLayoutPanelContent";
            tableLayoutPanelContent.Padding = new Padding(0, 8, 0, 0);
            tableLayoutPanelContent.RowCount = 1;
            tableLayoutPanelContent.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelContent.Size = new Size(922, 514);
            tableLayoutPanelContent.TabIndex = 1;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvProducts);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(0, 8);
            groupBox2.Margin = new Padding(0, 0, 8, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(7);
            groupBox2.Size = new Size(614, 506);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh sách sản phẩm";
            // 
            // dgvProducts
            // 
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.AllowUserToResizeRows = false;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Dock = DockStyle.Fill;
            dgvProducts.Location = new Point(7, 27);
            dgvProducts.MultiSelect = false;
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.RowHeadersVisible = false;
            dgvProducts.RowHeadersWidth = 51;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Size = new Size(600, 472);
            dgvProducts.TabIndex = 0;
            dgvProducts.CellClick += dgvProducts_CellClick;
            // 
            // panelDetail
            // 
            panelDetail.Controls.Add(panelButtons);
            panelDetail.Controls.Add(groupBox3);
            panelDetail.Dock = DockStyle.Fill;
            panelDetail.Location = new Point(625, 11);
            panelDetail.Name = "panelDetail";
            panelDetail.Size = new Size(294, 500);
            panelDetail.TabIndex = 1;
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(btnLoad);
            panelButtons.Controls.Add(btnAdd);
            panelButtons.Controls.Add(btnUpdate);
            panelButtons.Controls.Add(btnDelete);
            panelButtons.Dock = DockStyle.Top;
            panelButtons.Location = new Point(0, 372);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(294, 50);
            panelButtons.TabIndex = 1;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(6, 10);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(67, 31);
            btnLoad.TabIndex = 5;
            btnLoad.Text = "Tải lại";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(80, 10);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(67, 31);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(154, 10);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(67, 31);
            btnUpdate.TabIndex = 7;
            btnUpdate.Text = "Sửa";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(228, 10);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(63, 31);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
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
            groupBox3.Dock = DockStyle.Top;
            groupBox3.Location = new Point(0, 0);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(294, 372);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            groupBox3.Text = "Thông tin sản phẩm";
            // 
            // cboCategory
            // 
            cboCategory.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategory.FormattingEnabled = true;
            cboCategory.Location = new Point(12, 320);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(276, 28);
            cboCategory.TabIndex = 5;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 297);
            label8.Name = "label8";
            label8.Size = new Size(87, 20);
            label8.TabIndex = 5;
            label8.Text = "Nhóm hàng";
            // 
            // nudStock
            // 
            nudStock.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            nudStock.Location = new Point(12, 267);
            nudStock.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudStock.Name = "nudStock";
            nudStock.Size = new Size(276, 27);
            nudStock.TabIndex = 4;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(10, 244);
            label7.Name = "label7";
            label7.Size = new Size(62, 20);
            label7.TabIndex = 4;
            label7.Text = "Tồn kho";
            // 
            // nudPrice
            // 
            nudPrice.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            nudPrice.Location = new Point(12, 214);
            nudPrice.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nudPrice.Name = "nudPrice";
            nudPrice.Size = new Size(276, 27);
            nudPrice.TabIndex = 3;
            nudPrice.ThousandsSeparator = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 191);
            label6.Name = "label6";
            label6.Size = new Size(62, 20);
            label6.TabIndex = 3;
            label6.Text = "Đơn giá";
            // 
            // txtProductName
            // 
            txtProductName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtProductName.Location = new Point(10, 161);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(278, 27);
            txtProductName.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 138);
            label5.Name = "label5";
            label5.Size = new Size(100, 20);
            label5.TabIndex = 2;
            label5.Text = "Tên sản phẩm";
            // 
            // txtBarcode
            // 
            txtBarcode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBarcode.Location = new Point(12, 108);
            txtBarcode.Name = "txtBarcode";
            txtBarcode.Size = new Size(276, 27);
            txtBarcode.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(10, 85);
            label4.Name = "label4";
            label4.Size = new Size(64, 20);
            label4.TabIndex = 1;
            label4.Text = "Mã vạch";
            // 
            // txtId
            // 
            txtId.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtId.Location = new Point(10, 52);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(278, 27);
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
            // groupBox1
            // 
            groupBox1.Controls.Add(panelSearchActions);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(14, 16);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(8, 25, 8, 8);
            groupBox1.Size = new Size(922, 76);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tìm kiếm sản phẩm";
            // 
            // panelSearchActions
            // 
            panelSearchActions.Controls.Add(txtSearchBarcode);
            panelSearchActions.Controls.Add(btnSearch);
            panelSearchActions.Controls.Add(cboFilterCategory);
            panelSearchActions.Controls.Add(label2);
            panelSearchActions.Location = new Point(7, 26);
            panelSearchActions.Name = "panelSearchActions";
            panelSearchActions.Size = new Size(915, 44);
            panelSearchActions.TabIndex = 1;
            // 
            // txtSearchBarcode
            // 
            txtSearchBarcode.Location = new Point(3, 12);
            txtSearchBarcode.Name = "txtSearchBarcode";
            txtSearchBarcode.PlaceholderText = "Mã vạch hoặc tên sản phẩm...";
            txtSearchBarcode.Size = new Size(513, 27);
            txtSearchBarcode.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(809, 12);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(100, 28);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // cboFilterCategory
            // 
            cboFilterCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFilterCategory.FormattingEnabled = true;
            cboFilterCategory.Location = new Point(613, 13);
            cboFilterCategory.Name = "cboFilterCategory";
            cboFilterCategory.Size = new Size(190, 28);
            cboFilterCategory.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(523, 17);
            label2.Name = "label2";
            label2.Size = new Size(87, 20);
            label2.TabIndex = 1;
            label2.Text = "Nhóm hàng";
            // 
            // FormProductManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(950, 620);
            Controls.Add(panelRoot);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(930, 560);
            Name = "FormProductManagement";
            Text = "Quản lý sản phẩm & kho hàng";
            Load += FormProductManagement_Load;
            panelRoot.ResumeLayout(false);
            tableLayoutPanelContent.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            panelDetail.ResumeLayout(false);
            panelButtons.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPrice).EndInit();
            groupBox1.ResumeLayout(false);
            panelSearchActions.ResumeLayout(false);
            panelSearchActions.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelRoot;
        private GroupBox groupBox1;
        private Panel panelSearchActions;
        private Label label2;
        private ComboBox cboFilterCategory;
        private Button btnSearch;

        private TableLayoutPanel tableLayoutPanelContent;
        private GroupBox groupBox2;
        private DataGridView dgvProducts;

        private Panel panelDetail;
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

        private Panel panelButtons;
        private Button btnLoad;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private TextBox txtSearchBarcode;
    }
}