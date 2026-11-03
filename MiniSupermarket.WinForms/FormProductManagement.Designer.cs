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
            _lblStockWarning = new Label();
            panelRoot = new Panel();
            panelPaging = new TableLayoutPanel();
            btnPrev = new Button();
            lblPaging = new Label();
            btnNext = new Button();
            tableLayoutPanelContent = new TableLayoutPanel();
            groupBox2 = new GroupBox();
            dgvProducts = new DataGridView();
            panelDetail = new Panel();
            panelButtons = new TableLayoutPanel();
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
            panelSearchActions = new TableLayoutPanel();
            txtSearchBarcode = new TextBox();
            btnSearch = new Button();
            cboFilterCategory = new ComboBox();
            label2 = new Label();
            panelRoot.SuspendLayout();
            tableLayoutPanelContent.SuspendLayout();
            groupBox2.SuspendLayout();
            panelPaging.SuspendLayout();
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
            _lblStockWarning.Name = "_lblStockWarning";
            _lblStockWarning.Text = "Trạng thái tồn kho từ máy chủ";
            _lblStockWarning.ForeColor = Color.FromArgb(153, 27, 27);
            _lblStockWarning.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            _lblStockWarning.TextAlign = ContentAlignment.MiddleCenter;
            _lblStockWarning.Margin = new Padding(0);
            _lblStockWarning.Dock = DockStyle.Fill;
            // 
            panelRoot.Controls.Add(tableLayoutPanelContent);
            panelRoot.Controls.Add(groupBox1);
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
            tableLayoutPanelContent.Controls.Add(groupBox2, 0, 0);
            tableLayoutPanelContent.Controls.Add(panelDetail, 1, 0);
            tableLayoutPanelContent.Dock = DockStyle.Fill;
            tableLayoutPanelContent.Location = new Point(14, 92);
            tableLayoutPanelContent.Name = "tableLayoutPanelContent";
            tableLayoutPanelContent.Margin = new Padding(0);
            tableLayoutPanelContent.Padding = new Padding(0, 12, 0, 0);
            tableLayoutPanelContent.RowCount = 1;
            tableLayoutPanelContent.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelContent.Size = new Size(922, 514);
            tableLayoutPanelContent.TabIndex = 1;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvProducts);
            groupBox2.Controls.Add(panelPaging);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(0, 8);
            groupBox2.Margin = new Padding(0, 0, 12, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox2.ForeColor = Color.FromArgb(22, 54, 90);
            groupBox2.BackColor = Color.White;
            groupBox2.Padding = new Padding(12);
            groupBox2.Size = new Size(614, 506);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh sách sản phẩm";
            // 
            // panelPaging: thanh chuyển trang (Buổi 6)
            panelPaging.Dock = DockStyle.Bottom;
            panelPaging.Name = "panelPaging";
            panelPaging.BackColor = Color.White;
            panelPaging.Padding = new Padding(0, 4, 0, 0);
            panelPaging.Margin = new Padding(0);
            panelPaging.ColumnCount = 3;
            panelPaging.RowCount = 2;
            panelPaging.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 132F));
            panelPaging.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            panelPaging.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 132F));
            panelPaging.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            panelPaging.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            panelPaging.Controls.Add(btnPrev, 0, 0);
            panelPaging.Controls.Add(lblPaging, 1, 0);
            panelPaging.Controls.Add(btnNext, 2, 0);
            panelPaging.Controls.Add(_lblStockWarning, 0, 1);
            panelPaging.SetColumnSpan(_lblStockWarning, 3);
            panelPaging.Size = new Size(320, 82);
            panelPaging.TabIndex = 1;
            // btnPrev
            btnPrev.Location = new Point(3, 5);
            btnPrev.Name = "btnPrev";
            btnPrev.Margin = new Padding(4);
            btnPrev.Dock = DockStyle.Fill;
            btnPrev.AutoSize = false;
            btnPrev.Cursor = Cursors.Hand;
            btnPrev.FlatAppearance.MouseDownBackColor = Color.FromArgb(203, 217, 235);
            btnPrev.FlatAppearance.MouseOverBackColor = Color.FromArgb(221, 230, 241);
            btnPrev.FlatAppearance.BorderSize = 0;
            btnPrev.FlatStyle = FlatStyle.Flat;
            btnPrev.ForeColor = Color.FromArgb(22, 54, 90);
            btnPrev.BackColor = Color.FromArgb(238, 242, 247);
            btnPrev.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnPrev.Size = new Size(96, 38);
            btnPrev.TabIndex = 0;
            btnPrev.Text = "Trang trước";
            btnPrev.UseVisualStyleBackColor = false;
            btnPrev.Click += btnPrev_Click;
            // lblPaging
            lblPaging.AutoSize = false;
            lblPaging.Location = new Point(139, 5);
            lblPaging.Name = "lblPaging";
            lblPaging.Margin = new Padding(0);
            lblPaging.Dock = DockStyle.Fill;
            lblPaging.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblPaging.ForeColor = Color.FromArgb(22, 54, 90);
            lblPaging.Size = new Size(200, 30);
            lblPaging.TabIndex = 1;
            lblPaging.Text = "Trang 1 / 1";
            lblPaging.TextAlign = ContentAlignment.MiddleCenter;
            // btnNext
            btnNext.Location = new Point(345, 5);
            btnNext.Name = "btnNext";
            btnNext.Margin = new Padding(4);
            btnNext.Dock = DockStyle.Fill;
            btnNext.AutoSize = false;
            btnNext.Cursor = Cursors.Hand;
            btnNext.FlatAppearance.MouseDownBackColor = Color.FromArgb(203, 217, 235);
            btnNext.FlatAppearance.MouseOverBackColor = Color.FromArgb(221, 230, 241);
            btnNext.FlatAppearance.BorderSize = 0;
            btnNext.FlatStyle = FlatStyle.Flat;
            btnNext.ForeColor = Color.FromArgb(22, 54, 90);
            btnNext.BackColor = Color.FromArgb(238, 242, 247);
            btnNext.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnNext.Size = new Size(96, 38);
            btnNext.TabIndex = 2;
            btnNext.Text = "Trang sau";
            btnNext.UseVisualStyleBackColor = false;
            btnNext.Click += btnNext_Click;
            // dgvProducts
            // 
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.AllowUserToResizeRows = false;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvProducts.Dock = DockStyle.Fill;
            dgvProducts.Location = new Point(7, 27);
            dgvProducts.MultiSelect = false;
            dgvProducts.Name = "dgvProducts";
            dgvProducts.Margin = new Padding(0);
            dgvProducts.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dgvProducts.RowTemplate.Height = 36;
            dgvProducts.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvProducts.GridColor = Color.FromArgb(235, 240, 247);
            dgvProducts.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 253);
            dgvProducts.DefaultCellStyle.Padding = new Padding(8, 0, 8, 0);
            dgvProducts.DefaultCellStyle.SelectionForeColor = Color.FromArgb(22, 54, 90);
            dgvProducts.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 234, 254);
            dgvProducts.DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dgvProducts.DefaultCellStyle.ForeColor = Color.FromArgb(31, 41, 55);
            dgvProducts.DefaultCellStyle.BackColor = Color.White;
            dgvProducts.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 0, 8, 0);
            dgvProducts.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(22, 54, 90);
            dgvProducts.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(232, 239, 250);
            dgvProducts.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            dgvProducts.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(22, 54, 90);
            dgvProducts.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(232, 239, 250);
            dgvProducts.ColumnHeadersHeight = 42;
            dgvProducts.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvProducts.EnableHeadersVisualStyles = false;
            dgvProducts.BorderStyle = BorderStyle.None;
            dgvProducts.BackgroundColor = Color.White;
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
            panelDetail.AutoScroll = true;
            panelDetail.BackColor = Color.White;
            panelDetail.Margin = new Padding(0);
            panelDetail.Size = new Size(320, 560);
            panelDetail.TabIndex = 1;
            // 
            // panelButtons
            // 
            panelButtons.Dock = DockStyle.Top;
            panelButtons.Location = new Point(0, 372);
            panelButtons.Name = "panelButtons";
            panelButtons.BackColor = Color.White;
            panelButtons.Padding = new Padding(12, 0, 12, 0);
            panelButtons.Margin = new Padding(0);
            panelButtons.ColumnCount = 2;
            panelButtons.RowCount = 2;
            panelButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            panelButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            panelButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            panelButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            panelButtons.Controls.Add(btnAdd, 0, 0);
            panelButtons.Controls.Add(btnUpdate, 1, 0);
            panelButtons.Controls.Add(btnLoad, 0, 1);
            panelButtons.Controls.Add(btnDelete, 1, 1);
            panelButtons.Size = new Size(320, 88);
            panelButtons.TabIndex = 1;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(6, 10);
            btnLoad.Name = "btnLoad";
            btnLoad.Margin = new Padding(0, 3, 8, 3);
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
            btnLoad.TabIndex = 5;
            btnLoad.Text = "Tải lại";
            btnLoad.UseVisualStyleBackColor = false;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(80, 10);
            btnAdd.Name = "btnAdd";
            btnAdd.Margin = new Padding(4);
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
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(154, 10);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Margin = new Padding(4);
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
            btnUpdate.TabIndex = 7;
            btnUpdate.Text = "Sửa";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(228, 10);
            btnDelete.Name = "btnDelete";
            btnDelete.Margin = new Padding(4);
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
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = false;
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
            groupBox3.Margin = new Padding(0);
            groupBox3.Padding = new Padding(12);
            groupBox3.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox3.ForeColor = Color.FromArgb(22, 54, 90);
            groupBox3.BackColor = Color.White;
            groupBox3.Size = new Size(320, 400);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            groupBox3.Text = "Thông tin sản phẩm";
            // 
            // cboCategory
            // 
            cboCategory.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategory.FormattingEnabled = true;
            cboCategory.Location = new Point(16, 354);
            cboCategory.Name = "cboCategory";
            cboCategory.Margin = new Padding(0);
            cboCategory.FlatStyle = FlatStyle.Flat;
            cboCategory.BackColor = Color.White;
            cboCategory.ForeColor = Color.FromArgb(31, 41, 55);
            cboCategory.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cboCategory.Size = new Size(288, 28);
            cboCategory.TabIndex = 5;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(16, 328);
            label8.Name = "label8";
            label8.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label8.ForeColor = Color.FromArgb(22, 54, 90);
            label8.Size = new Size(87, 20);
            label8.TabIndex = 5;
            label8.Text = "Nhóm hàng";
            // 
            // nudStock
            // 
            nudStock.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            nudStock.Location = new Point(16, 294);
            nudStock.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudStock.Name = "nudStock";
            nudStock.TextAlign = HorizontalAlignment.Right;
            nudStock.Margin = new Padding(0);
            nudStock.BackColor = Color.White;
            nudStock.ForeColor = Color.FromArgb(31, 41, 55);
            nudStock.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            nudStock.Size = new Size(288, 28);
            nudStock.TabIndex = 4;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(16, 268);
            label7.Name = "label7";
            label7.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label7.ForeColor = Color.FromArgb(22, 54, 90);
            label7.Size = new Size(62, 20);
            label7.TabIndex = 4;
            label7.Text = "Tồn kho";
            // 
            // nudPrice
            // 
            nudPrice.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            nudPrice.Location = new Point(16, 234);
            nudPrice.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nudPrice.Name = "nudPrice";
            nudPrice.TextAlign = HorizontalAlignment.Right;
            nudPrice.Margin = new Padding(0);
            nudPrice.BackColor = Color.White;
            nudPrice.ForeColor = Color.FromArgb(31, 41, 55);
            nudPrice.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            nudPrice.Size = new Size(288, 28);
            nudPrice.TabIndex = 3;
            nudPrice.ThousandsSeparator = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(16, 208);
            label6.Name = "label6";
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label6.ForeColor = Color.FromArgb(22, 54, 90);
            label6.Size = new Size(62, 20);
            label6.TabIndex = 3;
            label6.Text = "Đơn giá";
            // 
            // txtProductName
            // 
            txtProductName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtProductName.Location = new Point(16, 174);
            txtProductName.Name = "txtProductName";
            txtProductName.Margin = new Padding(0);
            txtProductName.BorderStyle = BorderStyle.FixedSingle;
            txtProductName.BackColor = Color.White;
            txtProductName.ForeColor = Color.FromArgb(31, 41, 55);
            txtProductName.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtProductName.Size = new Size(288, 28);
            txtProductName.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(16, 148);
            label5.Name = "label5";
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.FromArgb(22, 54, 90);
            label5.Size = new Size(100, 20);
            label5.TabIndex = 2;
            label5.Text = "Tên sản phẩm";
            // 
            // txtBarcode
            // 
            txtBarcode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBarcode.Location = new Point(16, 114);
            txtBarcode.Name = "txtBarcode";
            txtBarcode.Margin = new Padding(0);
            txtBarcode.BorderStyle = BorderStyle.FixedSingle;
            txtBarcode.BackColor = Color.White;
            txtBarcode.ForeColor = Color.FromArgb(31, 41, 55);
            txtBarcode.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtBarcode.Size = new Size(288, 28);
            txtBarcode.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 88);
            label4.Name = "label4";
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.FromArgb(22, 54, 90);
            label4.Size = new Size(64, 20);
            label4.TabIndex = 1;
            label4.Text = "Mã vạch";
            // 
            // txtId
            // 
            txtId.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtId.Location = new Point(16, 54);
            txtId.Name = "txtId";
            txtId.Margin = new Padding(0);
            txtId.BorderStyle = BorderStyle.FixedSingle;
            txtId.BackColor = Color.FromArgb(238, 242, 247);
            txtId.ForeColor = Color.FromArgb(31, 41, 55);
            txtId.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtId.ReadOnly = true;
            txtId.Size = new Size(288, 28);
            txtId.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 28);
            label3.Name = "label3";
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.FromArgb(22, 54, 90);
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
            groupBox1.Margin = new Padding(0, 0, 12, 0);
            groupBox1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.ForeColor = Color.FromArgb(22, 54, 90);
            groupBox1.BackColor = Color.White;
            groupBox1.Padding = new Padding(16, 10, 16, 14);
            groupBox1.Size = new Size(968, 88);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tìm kiếm sản phẩm";
            // 
            // panelSearchActions
            // 
            panelSearchActions.Location = new Point(7, 26);
            panelSearchActions.Name = "panelSearchActions";
            panelSearchActions.Margin = new Padding(0);
            panelSearchActions.ColumnCount = 4;
            panelSearchActions.RowCount = 1;
            panelSearchActions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            panelSearchActions.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 112F));
            panelSearchActions.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            panelSearchActions.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 128F));
            panelSearchActions.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            panelSearchActions.Controls.Add(txtSearchBarcode, 0, 0);
            panelSearchActions.Controls.Add(label2, 1, 0);
            panelSearchActions.Controls.Add(cboFilterCategory, 2, 0);
            panelSearchActions.Controls.Add(btnSearch, 3, 0);
            panelSearchActions.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelSearchActions.Padding = new Padding(0);
            panelSearchActions.Dock = DockStyle.Fill;
            panelSearchActions.Size = new Size(915, 44);
            panelSearchActions.TabIndex = 1;
            // 
            // txtSearchBarcode
            // 
            txtSearchBarcode.Location = new Point(3, 12);
            txtSearchBarcode.Name = "txtSearchBarcode";
            txtSearchBarcode.Margin = new Padding(0, 8, 12, 8);
            txtSearchBarcode.Dock = DockStyle.Fill;
            txtSearchBarcode.BorderStyle = BorderStyle.FixedSingle;
            txtSearchBarcode.BackColor = Color.White;
            txtSearchBarcode.ForeColor = Color.FromArgb(31, 41, 55);
            txtSearchBarcode.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtSearchBarcode.PlaceholderText = "Mã vạch hoặc tên sản phẩm...";
            txtSearchBarcode.Size = new Size(513, 27);
            txtSearchBarcode.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(809, 12);
            btnSearch.Name = "btnSearch";
            btnSearch.Margin = new Padding(0, 3, 8, 3);
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
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // cboFilterCategory
            // 
            cboFilterCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFilterCategory.FormattingEnabled = true;
            cboFilterCategory.Location = new Point(613, 13);
            cboFilterCategory.Name = "cboFilterCategory";
            cboFilterCategory.Margin = new Padding(0, 8, 12, 8);
            cboFilterCategory.Dock = DockStyle.Fill;
            cboFilterCategory.FlatStyle = FlatStyle.Flat;
            cboFilterCategory.BackColor = Color.White;
            cboFilterCategory.ForeColor = Color.FromArgb(31, 41, 55);
            cboFilterCategory.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cboFilterCategory.Size = new Size(190, 28);
            cboFilterCategory.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = false;
            label2.Location = new Point(523, 17);
            label2.Name = "label2";
            label2.Margin = new Padding(0);
            label2.TextAlign = ContentAlignment.MiddleLeft;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.FromArgb(22, 54, 90);
            label2.Size = new Size(87, 20);
            label2.TabIndex = 1;
            label2.Text = "Nhóm hàng";
            // 
            // FormProductManagement
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
            MinimumSize = new Size(930, 560);
            Name = "FormProductManagement";
            Text = "Quản lý sản phẩm & kho hàng";
            Load += FormProductManagement_Load;
            panelRoot.ResumeLayout(false);
            tableLayoutPanelContent.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            panelPaging.ResumeLayout(false);
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

        private TableLayoutPanel panelPaging;
        private Button btnPrev;
        private Label lblPaging;
        private Button btnNext;
        private Label _lblStockWarning;
        private Panel panelRoot;
        private GroupBox groupBox1;
        private TableLayoutPanel panelSearchActions;
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

        private TableLayoutPanel panelButtons;
        private Button btnLoad;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private TextBox txtSearchBarcode;
    }
}
