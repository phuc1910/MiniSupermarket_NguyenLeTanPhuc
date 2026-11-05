namespace MiniSupermarket.WinForms
{
    partial class FormOrderManagement
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            labelOrderPeriod = new Label();
            cmbOrderPeriod = new ComboBox();
            labelOrderAnchor = new Label();
            dtpOrderAnchor = new DateTimePicker();
            layoutOrders = new TableLayoutPanel();
            groupOrdersFilter = new GroupBox();
            labelOrdersFrom = new Label();
            dtpOrdersFrom = new DateTimePicker();
            labelOrdersTo = new Label();
            dtpOrdersTo = new DateTimePicker();
            btnLoadOrders = new Button();
            btnOrderDetail = new Button();
            dgvOrders = new DataGridView();
            colOrderCode = new DataGridViewTextBoxColumn();
            colOrderCreatedDate = new DataGridViewTextBoxColumn();
            colOrderCashier = new DataGridViewTextBoxColumn();
            colOrderCustomer = new DataGridViewTextBoxColumn();
            colOrderItems = new DataGridViewTextBoxColumn();
            colOrderAmount = new DataGridViewTextBoxColumn();
            panelOrderPaging = new Panel();
            btnOrderPrevious = new Button();
            btnOrderNext = new Button();
            lblOrderPaging = new Label();
            lblOrderDetail = new Label();
            dgvOrderDetails = new DataGridView();
            colDetailBarcode = new DataGridViewTextBoxColumn();
            colDetailProductName = new DataGridViewTextBoxColumn();
            colDetailQuantity = new DataGridViewTextBoxColumn();
            colDetailUnitPrice = new DataGridViewTextBoxColumn();
            colDetailLineTotal = new DataGridViewTextBoxColumn();
            layoutOrders.SuspendLayout();
            groupOrdersFilter.SuspendLayout();
            panelOrderPaging.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvOrderDetails).BeginInit();
            SuspendLayout();
            Controls.Add(layoutOrders);
            //
            // layoutOrders
            //
            layoutOrders.Name = "layoutOrders";
            layoutOrders.Dock = DockStyle.Fill;
            layoutOrders.TabIndex = 46;
            layoutOrders.BackColor = Color.FromArgb(242, 245, 250);
            layoutOrders.Margin = new Padding(0);
            layoutOrders.ColumnCount = 1;
            layoutOrders.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutOrders.RowCount = 5;
            layoutOrders.RowStyles.Add(new RowStyle(SizeType.Absolute, 136F));
            layoutOrders.RowStyles.Add(new RowStyle(SizeType.Percent, 52F));
            layoutOrders.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            layoutOrders.RowStyles.Add(new RowStyle(SizeType.Absolute, 64F));
            layoutOrders.RowStyles.Add(new RowStyle(SizeType.Percent, 48F));
            layoutOrders.Controls.Add(groupOrdersFilter, 0, 0);
            layoutOrders.Controls.Add(dgvOrders, 0, 1);
            layoutOrders.Controls.Add(panelOrderPaging, 0, 2);
            layoutOrders.Controls.Add(lblOrderDetail, 0, 3);
            layoutOrders.Controls.Add(dgvOrderDetails, 0, 4);
            //
            // groupOrdersFilter
            //
            groupOrdersFilter.Location = new Point(0, 0);
            groupOrdersFilter.Name = "groupOrdersFilter";
            groupOrdersFilter.Size = new Size(950, 86);
            groupOrdersFilter.Text = "Tra cứu đơn hàng";
            groupOrdersFilter.TabIndex = 47;
            groupOrdersFilter.BackColor = Color.White;
            groupOrdersFilter.ForeColor = Color.FromArgb(22, 54, 90);
            groupOrdersFilter.Padding = new Padding(12);
            groupOrdersFilter.TabStop = false;
            groupOrdersFilter.Dock = DockStyle.Fill;
            groupOrdersFilter.Margin = new Padding(0, 0, 0, 12);
            //
            // labelOrdersFrom
            //
            labelOrdersFrom.Location = new Point(16, 76);
            labelOrdersFrom.Name = "labelOrdersFrom";
            labelOrdersFrom.Size = new Size(68, 28);
            labelOrdersFrom.Text = "Từ:";
            labelOrdersFrom.TabIndex = 48;
            labelOrdersFrom.AutoSize = false;
            labelOrdersFrom.ForeColor = Color.FromArgb(22, 54, 90);
            labelOrdersFrom.TextAlign = ContentAlignment.MiddleLeft;
            //
            // dtpOrdersFrom
            //
            dtpOrdersFrom.Location = new Point(86, 76);
            dtpOrdersFrom.Name = "dtpOrdersFrom";
            dtpOrdersFrom.Size = new Size(140, 28);
            dtpOrdersFrom.TabIndex = 49;
            dtpOrdersFrom.Format = DateTimePickerFormat.Custom;
            dtpOrdersFrom.CustomFormat = "dd/MM/yyyy";
            dtpOrdersFrom.CalendarForeColor = Color.FromArgb(22, 54, 90);
            dtpOrdersFrom.CalendarTitleBackColor = Color.FromArgb(232, 239, 250);
            //
            // labelOrdersTo
            //
            labelOrdersTo.Location = new Point(242, 76);
            labelOrdersTo.Name = "labelOrdersTo";
            labelOrdersTo.Size = new Size(80, 28);
            labelOrdersTo.Text = "Đến:";
            labelOrdersTo.TabIndex = 50;
            labelOrdersTo.AutoSize = false;
            labelOrdersTo.ForeColor = Color.FromArgb(22, 54, 90);
            labelOrdersTo.TextAlign = ContentAlignment.MiddleLeft;
            //
            // dtpOrdersTo
            //
            dtpOrdersTo.Location = new Point(324, 76);
            dtpOrdersTo.Name = "dtpOrdersTo";
            dtpOrdersTo.Size = new Size(140, 28);
            dtpOrdersTo.TabIndex = 51;
            dtpOrdersTo.Format = DateTimePickerFormat.Custom;
            dtpOrdersTo.CustomFormat = "dd/MM/yyyy";
            dtpOrdersTo.CalendarForeColor = Color.FromArgb(22, 54, 90);
            dtpOrdersTo.CalendarTitleBackColor = Color.FromArgb(232, 239, 250);
            //
            // btnLoadOrders
            //
            btnLoadOrders.Location = new Point(484, 72);
            btnLoadOrders.Name = "btnLoadOrders";
            btnLoadOrders.Size = new Size(144, 36);
            btnLoadOrders.Text = "Tải đơn hàng";
            btnLoadOrders.TabIndex = 52;
            btnLoadOrders.BackColor = Color.FromArgb(37, 99, 235);
            btnLoadOrders.ForeColor = Color.White;
            btnLoadOrders.FlatStyle = FlatStyle.Flat;
            btnLoadOrders.FlatAppearance.BorderSize = 0;
            btnLoadOrders.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnLoadOrders.UseVisualStyleBackColor = false;
            btnLoadOrders.Cursor = Cursors.Hand;
            //
            // btnOrderDetail
            //
            btnOrderDetail.Location = new Point(644, 72);
            btnOrderDetail.Name = "btnOrderDetail";
            btnOrderDetail.Size = new Size(154, 36);
            btnOrderDetail.Text = "Xem chi tiết";
            btnOrderDetail.TabIndex = 53;
            btnOrderDetail.BackColor = Color.FromArgb(37, 99, 235);
            btnOrderDetail.ForeColor = Color.White;
            btnOrderDetail.FlatStyle = FlatStyle.Flat;
            btnOrderDetail.FlatAppearance.BorderSize = 0;
            btnOrderDetail.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnOrderDetail.UseVisualStyleBackColor = false;
            btnOrderDetail.Cursor = Cursors.Hand;
            labelOrderPeriod.Text = "Lọc theo:";
            labelOrderPeriod.Name = "labelOrderPeriod";
            labelOrderPeriod.Location = new Point(16, 32);
            labelOrderPeriod.Size = new Size(68, 28);
            labelOrderPeriod.TextAlign = ContentAlignment.MiddleLeft;
            cmbOrderPeriod.Name = "cmbOrderPeriod";
            cmbOrderPeriod.Location = new Point(86, 32);
            cmbOrderPeriod.Size = new Size(140, 28);
            cmbOrderPeriod.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOrderPeriod.Items.AddRange(new object[] { "Ngày", "Tháng", "Năm", "Tùy chọn" });
            cmbOrderPeriod.TabIndex = 0;
            labelOrderAnchor.Name = "labelOrderAnchor";
            labelOrderAnchor.Text = "Mốc ngày:";
            labelOrderAnchor.Location = new Point(242, 32);
            labelOrderAnchor.Size = new Size(80, 28);
            labelOrderAnchor.TextAlign = ContentAlignment.MiddleLeft;
            dtpOrderAnchor.Name = "dtpOrderAnchor";
            dtpOrderAnchor.Location = new Point(324, 32);
            dtpOrderAnchor.Size = new Size(140, 28);
            dtpOrderAnchor.Format = DateTimePickerFormat.Custom;
            dtpOrderAnchor.CustomFormat = "dd/MM/yyyy";
            dtpOrderAnchor.TabIndex = 1;
            groupOrdersFilter.Controls.Add(labelOrderPeriod);
            groupOrdersFilter.Controls.Add(cmbOrderPeriod);
            groupOrdersFilter.Controls.Add(labelOrderAnchor);
            groupOrdersFilter.Controls.Add(dtpOrderAnchor);
            cmbOrderPeriod.SelectedIndexChanged += OrderFilter_ValueChanged;
            dtpOrderAnchor.ValueChanged += OrderFilter_ValueChanged;
            dtpOrdersFrom.ValueChanged += OrderFilter_ValueChanged;
            dtpOrdersTo.ValueChanged += OrderFilter_ValueChanged;
            groupOrdersFilter.Controls.Add(labelOrdersFrom);
            groupOrdersFilter.Controls.Add(dtpOrdersFrom);
            groupOrdersFilter.Controls.Add(labelOrdersTo);
            groupOrdersFilter.Controls.Add(dtpOrdersTo);
            groupOrdersFilter.Controls.Add(btnLoadOrders);
            groupOrdersFilter.Controls.Add(btnOrderDetail);
            //
            // panelOrderPaging
            //
            panelOrderPaging.Name = "panelOrderPaging";
            panelOrderPaging.Dock = DockStyle.Fill;
            panelOrderPaging.TabIndex = 61;
            panelOrderPaging.Margin = new Padding(0, 4, 0, 4);
            panelOrderPaging.BackColor = Color.FromArgb(242, 245, 250);
            //
            // btnOrderPrevious
            //
            btnOrderPrevious.Location = new Point(0, 0);
            btnOrderPrevious.Name = "btnOrderPrevious";
            btnOrderPrevious.Size = new Size(116, 36);
            btnOrderPrevious.Text = "Trang trước";
            btnOrderPrevious.TabIndex = 62;
            btnOrderPrevious.BackColor = Color.FromArgb(37, 99, 235);
            btnOrderPrevious.ForeColor = Color.White;
            btnOrderPrevious.FlatStyle = FlatStyle.Flat;
            btnOrderPrevious.FlatAppearance.BorderSize = 0;
            btnOrderPrevious.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnOrderPrevious.UseVisualStyleBackColor = false;
            btnOrderPrevious.Cursor = Cursors.Hand;
            //
            // btnOrderNext
            //
            btnOrderNext.Location = new Point(128, 0);
            btnOrderNext.Name = "btnOrderNext";
            btnOrderNext.Size = new Size(116, 36);
            btnOrderNext.Text = "Trang sau";
            btnOrderNext.TabIndex = 63;
            btnOrderNext.BackColor = Color.FromArgb(37, 99, 235);
            btnOrderNext.ForeColor = Color.White;
            btnOrderNext.FlatStyle = FlatStyle.Flat;
            btnOrderNext.FlatAppearance.BorderSize = 0;
            btnOrderNext.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnOrderNext.UseVisualStyleBackColor = false;
            btnOrderNext.Cursor = Cursors.Hand;
            //
            // lblOrderPaging
            //
            lblOrderPaging.Location = new Point(264, 0);
            lblOrderPaging.Name = "lblOrderPaging";
            lblOrderPaging.Size = new Size(680, 36);
            lblOrderPaging.Text = "Chưa tải danh sách đơn hàng.";
            lblOrderPaging.TabIndex = 64;
            lblOrderPaging.AutoSize = false;
            lblOrderPaging.ForeColor = Color.FromArgb(22, 54, 90);
            lblOrderPaging.TextAlign = ContentAlignment.MiddleLeft;
            lblOrderPaging.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelOrderPaging.Controls.Add(btnOrderPrevious);
            panelOrderPaging.Controls.Add(btnOrderNext);
            panelOrderPaging.Controls.Add(lblOrderPaging);
            //
            // lblOrderDetail
            //
            lblOrderDetail.Location = new Point(0, 0);
            lblOrderDetail.Name = "lblOrderDetail";
            lblOrderDetail.Size = new Size(940, 60);
            lblOrderDetail.Text = "Chọn một đơn hàng để xem chi tiết.";
            lblOrderDetail.TabIndex = 65;
            lblOrderDetail.AutoSize = false;
            lblOrderDetail.ForeColor = Color.FromArgb(22, 54, 90);
            lblOrderDetail.TextAlign = ContentAlignment.MiddleLeft;
            lblOrderDetail.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblOrderDetail.Dock = DockStyle.Fill;
            lblOrderDetail.AutoEllipsis = true;
            lblOrderDetail.Margin = new Padding(0);
            //
            // dgvOrders
            //
            dgvOrders.Name = "dgvOrders";
            dgvOrders.Dock = DockStyle.Fill;
            dgvOrders.TabIndex = 54;
            dgvOrders.AllowUserToAddRows = false;
            dgvOrders.AllowUserToDeleteRows = false;
            dgvOrders.AllowUserToResizeRows = false;
            dgvOrders.AutoGenerateColumns = false;
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrders.BackgroundColor = Color.White;
            dgvOrders.BorderStyle = BorderStyle.None;
            dgvOrders.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvOrders.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvOrders.ColumnHeadersHeight = 40;
            dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvOrders.EnableHeadersVisualStyles = false;
            dgvOrders.GridColor = Color.FromArgb(232, 239, 250);
            dgvOrders.MultiSelect = false;
            dgvOrders.ReadOnly = true;
            dgvOrders.RowHeadersVisible = false;
            dgvOrders.RowTemplate.Height = 36;
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.Margin = new Padding(0);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(22, 54, 90);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(220, 234, 254);
            dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(22, 54, 90);
            dataGridViewCellStyle4.Padding = new Padding(8, 0, 8, 0);
            dataGridViewCellStyle5.ForeColor = Color.FromArgb(22, 54, 90);
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(220, 234, 254);
            dataGridViewCellStyle5.SelectionForeColor = Color.FromArgb(22, 54, 90);
            dataGridViewCellStyle5.Padding = new Padding(8, 0, 8, 0);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(22, 54, 90);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(220, 234, 254);
            dataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(22, 54, 90);
            dataGridViewCellStyle6.Padding = new Padding(8, 0, 8, 0);
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(232, 239, 250);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(248, 250, 253);
            dgvOrders.DefaultCellStyle = dataGridViewCellStyle4;
            dgvOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvOrders.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            dgvOrders.Columns.AddRange(new DataGridViewColumn[] { colOrderCode, colOrderCreatedDate, colOrderCashier, colOrderCustomer, colOrderItems, colOrderAmount });
            //
            // colOrderCode
            //
            colOrderCode.Name = "colOrderCode";
            colOrderCode.HeaderText = "Mã đơn";
            colOrderCode.DataPropertyName = "OrderCode";
            colOrderCode.FillWeight = 18F;
            colOrderCode.MinimumWidth = 120;
            colOrderCode.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colOrderCode.ReadOnly = true;
            //
            // colOrderCreatedDate
            //
            colOrderCreatedDate.Name = "colOrderCreatedDate";
            colOrderCreatedDate.HeaderText = "Thời gian";
            colOrderCreatedDate.DataPropertyName = "CreatedDate";
            colOrderCreatedDate.FillWeight = 23F;
            colOrderCreatedDate.MinimumWidth = 155;
            colOrderCreatedDate.ReadOnly = true;
            colOrderCreatedDate.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            colOrderCreatedDate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //
            // colOrderCashier
            //
            colOrderCashier.Name = "colOrderCashier";
            colOrderCashier.HeaderText = "Thu ngân";
            colOrderCashier.DataPropertyName = "CashierUsername";
            colOrderCashier.FillWeight = 17F;
            colOrderCashier.MinimumWidth = 120;
            colOrderCashier.ReadOnly = true;
            //
            // colOrderCustomer
            //
            colOrderCustomer.Name = "colOrderCustomer";
            colOrderCustomer.HeaderText = "Khách hàng";
            colOrderCustomer.DataPropertyName = "CustomerName";
            colOrderCustomer.FillWeight = 20F;
            colOrderCustomer.MinimumWidth = 140;
            colOrderCustomer.ReadOnly = true;
            //
            // colOrderItems
            //
            colOrderItems.Name = "colOrderItems";
            colOrderItems.HeaderText = "SL";
            colOrderItems.DataPropertyName = "TotalItems";
            colOrderItems.FillWeight = 11F;
            colOrderItems.MinimumWidth = 85;
            colOrderItems.ReadOnly = true;
            colOrderItems.DefaultCellStyle.Format = "N0";
            colOrderItems.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //
            // colOrderAmount
            //
            colOrderAmount.Name = "colOrderAmount";
            colOrderAmount.HeaderText = "Thực thu";
            colOrderAmount.DataPropertyName = "FinalAmount";
            colOrderAmount.FillWeight = 18F;
            colOrderAmount.MinimumWidth = 120;
            colOrderAmount.ReadOnly = true;
            colOrderAmount.DefaultCellStyle.Format = "N0";
            colOrderAmount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //
            // dgvOrderDetails
            //
            dgvOrderDetails.Name = "dgvOrderDetails";
            dgvOrderDetails.Dock = DockStyle.Fill;
            dgvOrderDetails.TabIndex = 66;
            dgvOrderDetails.AllowUserToAddRows = false;
            dgvOrderDetails.AllowUserToDeleteRows = false;
            dgvOrderDetails.AllowUserToResizeRows = false;
            dgvOrderDetails.AutoGenerateColumns = false;
            dgvOrderDetails.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dgvOrderDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrderDetails.BackgroundColor = Color.White;
            dgvOrderDetails.BorderStyle = BorderStyle.None;
            dgvOrderDetails.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvOrderDetails.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvOrderDetails.ColumnHeadersHeight = 40;
            dgvOrderDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvOrderDetails.EnableHeadersVisualStyles = false;
            dgvOrderDetails.GridColor = Color.FromArgb(232, 239, 250);
            dgvOrderDetails.MultiSelect = false;
            dgvOrderDetails.ReadOnly = true;
            dgvOrderDetails.RowHeadersVisible = false;
            dgvOrderDetails.RowTemplate.Height = 36;
            dgvOrderDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrderDetails.Margin = new Padding(0);
            dataGridViewCellStyle7.ForeColor = Color.FromArgb(22, 54, 90);
            dataGridViewCellStyle7.SelectionBackColor = Color.FromArgb(220, 234, 254);
            dataGridViewCellStyle7.SelectionForeColor = Color.FromArgb(22, 54, 90);
            dataGridViewCellStyle7.Padding = new Padding(8, 0, 8, 0);
            dataGridViewCellStyle8.ForeColor = Color.FromArgb(22, 54, 90);
            dataGridViewCellStyle8.SelectionBackColor = Color.FromArgb(220, 234, 254);
            dataGridViewCellStyle8.SelectionForeColor = Color.FromArgb(22, 54, 90);
            dataGridViewCellStyle8.Padding = new Padding(8, 0, 8, 0);
            dataGridViewCellStyle9.ForeColor = Color.FromArgb(22, 54, 90);
            dataGridViewCellStyle9.SelectionBackColor = Color.FromArgb(220, 234, 254);
            dataGridViewCellStyle9.SelectionForeColor = Color.FromArgb(22, 54, 90);
            dataGridViewCellStyle9.Padding = new Padding(8, 0, 8, 0);
            dataGridViewCellStyle7.BackColor = Color.White;
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.False;
            dataGridViewCellStyle8.BackColor = Color.FromArgb(232, 239, 250);
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            dataGridViewCellStyle9.BackColor = Color.FromArgb(248, 250, 253);
            dgvOrderDetails.DefaultCellStyle = dataGridViewCellStyle7;
            dgvOrderDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            dgvOrderDetails.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            dgvOrderDetails.Columns.AddRange(new DataGridViewColumn[] { colDetailBarcode, colDetailProductName, colDetailQuantity, colDetailUnitPrice, colDetailLineTotal });
            //
            // colDetailBarcode
            //
            colDetailBarcode.Name = "colDetailBarcode";
            colDetailBarcode.HeaderText = "Mã vạch";
            colDetailBarcode.DataPropertyName = "Barcode";
            colDetailBarcode.FillWeight = 20F;
            colDetailBarcode.MinimumWidth = 130;
            colDetailBarcode.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colDetailBarcode.ReadOnly = true;
            //
            // colDetailProductName
            //
            colDetailProductName.Name = "colDetailProductName";
            colDetailProductName.HeaderText = "Tên sản phẩm";
            colDetailProductName.DataPropertyName = "ProductName";
            colDetailProductName.FillWeight = 35F;
            colDetailProductName.MinimumWidth = 180;
            colDetailProductName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colDetailProductName.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            colDetailProductName.ReadOnly = true;
            //
            // colDetailQuantity
            //
            colDetailQuantity.Name = "colDetailQuantity";
            colDetailQuantity.HeaderText = "Số lượng";
            colDetailQuantity.DataPropertyName = "Quantity";
            colDetailQuantity.FillWeight = 12F;
            colDetailQuantity.MinimumWidth = 95;
            colDetailQuantity.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colDetailQuantity.ReadOnly = true;
            colDetailQuantity.DefaultCellStyle.Format = "N0";
            colDetailQuantity.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //
            // colDetailUnitPrice
            //
            colDetailUnitPrice.Name = "colDetailUnitPrice";
            colDetailUnitPrice.HeaderText = "Đơn giá (đ)";
            colDetailUnitPrice.DataPropertyName = "UnitPrice";
            colDetailUnitPrice.FillWeight = 16F;
            colDetailUnitPrice.MinimumWidth = 125;
            colDetailUnitPrice.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colDetailUnitPrice.ReadOnly = true;
            colDetailUnitPrice.DefaultCellStyle.Format = "N0";
            colDetailUnitPrice.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //
            // colDetailLineTotal
            //
            colDetailLineTotal.Name = "colDetailLineTotal";
            colDetailLineTotal.HeaderText = "Thành tiền (đ)";
            colDetailLineTotal.DataPropertyName = "LineTotal";
            colDetailLineTotal.FillWeight = 17F;
            colDetailLineTotal.MinimumWidth = 140;
            colDetailLineTotal.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colDetailLineTotal.ReadOnly = true;
            colDetailLineTotal.DefaultCellStyle.Format = "N0";
            colDetailLineTotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            btnLoadOrders.Click += btnLoadOrders_Click;
            btnOrderPrevious.Click += btnOrderPrevious_Click;
            btnOrderNext.Click += btnOrderNext_Click;
            btnOrderDetail.Click += btnOrderDetail_Click;
            dgvOrders.SelectionChanged += dgvOrders_SelectionChanged;
            dgvOrders.CellDoubleClick += dgvOrders_CellDoubleClick;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(242, 245, 250);
            ClientSize = new Size(1030, 613);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.FromArgb(22, 54, 90);
            MinimumSize = new Size(900, 560);
            Name = "FormOrderManagement";
            Padding = new Padding(12);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hana Shop | Đơn hàng & chi tiết";
            Load += FormOrderManagement_Load;
            FormClosed += FormOrderManagement_FormClosed;
            panelOrderPaging.ResumeLayout(false);
            groupOrdersFilter.ResumeLayout(false);
            layoutOrders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvOrderDetails).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label labelOrderPeriod;
        private ComboBox cmbOrderPeriod;
        private Label labelOrderAnchor;
        private DateTimePicker dtpOrderAnchor;
        private TableLayoutPanel layoutOrders;
        private GroupBox groupOrdersFilter;
        private Label labelOrdersFrom;
        private DateTimePicker dtpOrdersFrom;
        private Label labelOrdersTo;
        private DateTimePicker dtpOrdersTo;
        private Button btnLoadOrders;
        private Button btnOrderDetail;
        private DataGridView dgvOrders;
        private DataGridViewTextBoxColumn colOrderCode;
        private DataGridViewTextBoxColumn colOrderCreatedDate;
        private DataGridViewTextBoxColumn colOrderCashier;
        private DataGridViewTextBoxColumn colOrderCustomer;
        private DataGridViewTextBoxColumn colOrderItems;
        private DataGridViewTextBoxColumn colOrderAmount;
        private Panel panelOrderPaging;
        private Button btnOrderPrevious;
        private Button btnOrderNext;
        private Label lblOrderPaging;
        private Label lblOrderDetail;
        private DataGridView dgvOrderDetails;
        private DataGridViewTextBoxColumn colDetailBarcode;
        private DataGridViewTextBoxColumn colDetailProductName;
        private DataGridViewTextBoxColumn colDetailQuantity;
        private DataGridViewTextBoxColumn colDetailUnitPrice;
        private DataGridViewTextBoxColumn colDetailLineTotal;
    }
}
