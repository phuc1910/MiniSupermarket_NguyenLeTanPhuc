namespace MiniSupermarket.WinForms
{
    partial class FormPOS
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            tableLayoutMain = new TableLayoutPanel();
            tableLayoutCheckout = new TableLayoutPanel();
            groupBox1 = new GroupBox();
            dgvCart = new DataGridView();
            colProductCode = new DataGridViewTextBoxColumn();
            colProductName = new DataGridViewTextBoxColumn();
            colUnitPrice = new DataGridViewTextBoxColumn();
            colQuantity = new DataGridViewTextBoxColumn();
            colAmount = new DataGridViewTextBoxColumn();
            txtBarcode = new TextBox();
            lblScanHint = new Label();
            groupBox2 = new GroupBox();
            lblCustomerName = new Label();
            lblCustomerPoints = new Label();
            chkUsePoints = new CheckBox();
            nudPointsToRedeem = new NumericUpDown();
            lblDiscountInfo = new Label();
            txtCustomerPhone = new TextBox();
            label3 = new Label();
            groupBox3 = new GroupBox();
            lblChange = new Label();
            label6 = new Label();
            txtCashReceived = new TextBox();
            label5 = new Label();
            lblTotalAmount = new Label();
            label4 = new Label();
            btnCheckout = new Button();
            btnClearCart = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPointsToRedeem).BeginInit();
            tableLayoutMain.SuspendLayout();
            tableLayoutCheckout.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // tableLayoutMain
            tableLayoutMain.ColumnCount = 2;
            tableLayoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 326F));
            tableLayoutMain.Controls.Add(groupBox1, 0, 0);
            tableLayoutMain.Controls.Add(tableLayoutCheckout, 1, 0);
            tableLayoutMain.Dock = DockStyle.Fill;
            tableLayoutMain.Name = "tableLayoutMain";
            tableLayoutMain.Padding = new Padding(12);
            tableLayoutMain.RowCount = 1;
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutMain.Size = new Size(917, 600);
            tableLayoutMain.TabIndex = 0;
            // groupBox1
            groupBox1.BackColor = Color.White;
            groupBox1.Controls.Add(dgvCart);
            groupBox1.Controls.Add(txtBarcode);
            groupBox1.Controls.Add(lblScanHint);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox1.ForeColor = Color.FromArgb(20, 42, 67);
            groupBox1.Margin = new Padding(0, 0, 12, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(16);
            groupBox1.Size = new Size(555, 576);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Giỏ hàng thanh toán";
            // txtBarcode
            txtBarcode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBarcode.BackColor = Color.FromArgb(248, 250, 252);
            txtBarcode.Font = new Font("Segoe UI", 12F);
            txtBarcode.ForeColor = Color.FromArgb(20, 42, 67);
            txtBarcode.Location = new Point(16, 34);
            txtBarcode.Name = "txtBarcode";
            txtBarcode.PlaceholderText = "Quét hoặc nhập mã vạch sản phẩm";
            txtBarcode.Size = new Size(523, 34);
            txtBarcode.TabIndex = 0;
            // lblScanHint
            lblScanHint.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblScanHint.Font = new Font("Segoe UI", 9F);
            lblScanHint.ForeColor = Color.FromArgb(100, 116, 139);
            lblScanHint.Location = new Point(16, 76);
            lblScanHint.Name = "lblScanHint";
            lblScanHint.Size = new Size(523, 22);
            lblScanHint.Text = "Nhấn Enter để thêm sản phẩm vào giỏ hàng.";
            // dgvCart
            dgvCart.AllowUserToAddRows = false;
            dgvCart.AllowUserToDeleteRows = false;
            dgvCart.AllowUserToResizeRows = false;
            dgvCart.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCart.AutoGenerateColumns = false;
            dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCart.BackgroundColor = Color.White;
            dgvCart.BorderStyle = BorderStyle.None;
            dgvCart.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCart.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(232, 239, 250);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(20, 42, 67);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(232, 239, 250);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(20, 42, 67);
            dataGridViewCellStyle1.Padding = new Padding(6, 0, 6, 0);
            dgvCart.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvCart.ColumnHeadersHeight = 44;
            dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvCart.Columns.AddRange(new DataGridViewColumn[] { colProductCode, colProductName, colUnitPrice, colQuantity, colAmount });
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(20, 42, 67);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(220, 234, 254);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(20, 42, 67);
            dataGridViewCellStyle2.Padding = new Padding(6, 0, 6, 0);
            dgvCart.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(248, 250, 252);
            dgvCart.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            dgvCart.EnableHeadersVisualStyles = false;
            dgvCart.Font = new Font("Segoe UI", 10F);
            dgvCart.GridColor = Color.FromArgb(226, 232, 240);
            dgvCart.Location = new Point(16, 108);
            dgvCart.MultiSelect = false;
            dgvCart.Name = "dgvCart";
            dgvCart.ReadOnly = true;
            dgvCart.RowHeadersVisible = false;
            dgvCart.RowTemplate.Height = 38;
            dgvCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCart.Size = new Size(523, 452);
            dgvCart.TabIndex = 1;
            // colProductCode
            colProductCode.DataPropertyName = "ProductId";
            colProductCode.HeaderText = "ID";
            colProductCode.Name = "colProductCode";
            colProductCode.FillWeight = 10F;
            colProductCode.MinimumWidth = 44;
            colProductCode.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colProductCode.DefaultCellStyle = dataGridViewCellStyle4;
            // colProductName
            colProductName.DataPropertyName = "ProductName";
            colProductName.HeaderText = "Sản phẩm";
            colProductName.Name = "colProductName";
            colProductName.FillWeight = 40F;
            colProductName.MinimumWidth = 130;
            colProductName.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colProductName.DefaultCellStyle = dataGridViewCellStyle5;
            // colUnitPrice
            colUnitPrice.DataPropertyName = "UnitPrice";
            colUnitPrice.HeaderText = "Đơn giá";
            colUnitPrice.Name = "colUnitPrice";
            colUnitPrice.FillWeight = 18F;
            colUnitPrice.MinimumWidth = 92;
            colUnitPrice.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            colUnitPrice.DefaultCellStyle = dataGridViewCellStyle6;
            // colQuantity
            colQuantity.DataPropertyName = "Quantity";
            colQuantity.HeaderText = "SL";
            colQuantity.Name = "colQuantity";
            colQuantity.FillWeight = 8F;
            colQuantity.MinimumWidth = 60;
            colQuantity.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N0";
            colQuantity.DefaultCellStyle = dataGridViewCellStyle7;
            // colAmount
            colAmount.DataPropertyName = "TotalPrice";
            colAmount.HeaderText = "Thành tiền";
            colAmount.Name = "colAmount";
            colAmount.FillWeight = 24F;
            colAmount.MinimumWidth = 128;
            colAmount.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N0";
            colAmount.DefaultCellStyle = dataGridViewCellStyle8;
            // tableLayoutCheckout
            tableLayoutCheckout.ColumnCount = 1;
            tableLayoutCheckout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutCheckout.Controls.Add(groupBox2, 0, 0);
            tableLayoutCheckout.Controls.Add(groupBox3, 0, 1);
            tableLayoutCheckout.Controls.Add(btnCheckout, 0, 2);
            tableLayoutCheckout.Controls.Add(btnClearCart, 0, 3);
            tableLayoutCheckout.Dock = DockStyle.Fill;
            tableLayoutCheckout.Margin = new Padding(0);
            tableLayoutCheckout.Name = "tableLayoutCheckout";
            tableLayoutCheckout.RowCount = 5;
            tableLayoutCheckout.RowStyles.Add(new RowStyle(SizeType.Absolute, 190F));
            tableLayoutCheckout.RowStyles.Add(new RowStyle(SizeType.Absolute, 230F));
            tableLayoutCheckout.RowStyles.Add(new RowStyle(SizeType.Absolute, 64F));
            tableLayoutCheckout.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
            tableLayoutCheckout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutCheckout.Size = new Size(326, 576);
            tableLayoutCheckout.TabIndex = 1;
            // groupBox2
            groupBox2.BackColor = Color.White;
            groupBox2.Controls.Add(nudPointsToRedeem);
            groupBox2.Controls.Add(chkUsePoints);
            groupBox2.Controls.Add(lblCustomerPoints);
            groupBox2.Controls.Add(lblCustomerName);
            groupBox2.Controls.Add(txtCustomerPhone);
            groupBox2.Controls.Add(label3);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox2.ForeColor = Color.FromArgb(20, 42, 67);
            groupBox2.Margin = new Padding(0, 0, 0, 8);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(16);
            groupBox2.Size = new Size(326, 182);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Khách hàng & điểm thưởng";
            // label3
            label3.Font = new Font("Segoe UI", 9F);
            label3.Location = new Point(16, 28);
            label3.Name = "label3";
            label3.Size = new Size(292, 22);
            label3.Text = "Số điện thoại khách hàng";
            // txtCustomerPhone
            txtCustomerPhone.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCustomerPhone.BackColor = Color.FromArgb(248, 250, 252);
            txtCustomerPhone.Font = new Font("Segoe UI", 11F);
            txtCustomerPhone.Location = new Point(16, 54);
            txtCustomerPhone.Name = "txtCustomerPhone";
            txtCustomerPhone.PlaceholderText = "Nhập số điện thoại";
            txtCustomerPhone.Size = new Size(292, 32);
            txtCustomerPhone.TabIndex = 0;
            // lblCustomerName
            lblCustomerName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblCustomerName.AutoEllipsis = true;
            lblCustomerName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCustomerName.ForeColor = Color.FromArgb(37, 99, 235);
            lblCustomerName.Location = new Point(16, 94);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(292, 25);
            lblCustomerName.Text = "Chưa chọn khách hàng";
            // lblCustomerPoints
            lblCustomerPoints.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblCustomerPoints.Font = new Font("Segoe UI", 9F);
            lblCustomerPoints.ForeColor = Color.FromArgb(15, 118, 110);
            lblCustomerPoints.Location = new Point(16, 120);
            lblCustomerPoints.Name = "lblCustomerPoints";
            lblCustomerPoints.Size = new Size(292, 22);
            // chkUsePoints
            chkUsePoints.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            chkUsePoints.Enabled = false;
            chkUsePoints.Font = new Font("Segoe UI", 9F);
            chkUsePoints.Location = new Point(16, 146);
            chkUsePoints.Name = "chkUsePoints";
            chkUsePoints.Size = new Size(180, 28);
            chkUsePoints.TabIndex = 1;
            chkUsePoints.Text = "Nhập điểm muốn đổi";
            chkUsePoints.UseVisualStyleBackColor = true;
            // nudPointsToRedeem
            nudPointsToRedeem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            nudPointsToRedeem.BorderStyle = BorderStyle.FixedSingle;
            nudPointsToRedeem.Enabled = false;
            nudPointsToRedeem.Font = new Font("Segoe UI", 9F);
            nudPointsToRedeem.Location = new Point(200, 147);
            nudPointsToRedeem.Maximum = 0;
            nudPointsToRedeem.Name = "nudPointsToRedeem";
            nudPointsToRedeem.Size = new Size(108, 27);
            nudPointsToRedeem.TabIndex = 2;
            nudPointsToRedeem.TextAlign = HorizontalAlignment.Right;
            nudPointsToRedeem.ThousandsSeparator = true;
            nudPointsToRedeem.ValueChanged += nudPointsToRedeem_ValueChanged;
            // groupBox3
            groupBox3.BackColor = Color.White;
            groupBox3.Controls.Add(lblDiscountInfo);
            groupBox3.Controls.Add(lblChange);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(txtCashReceived);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(lblTotalAmount);
            groupBox3.Controls.Add(label4);
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox3.ForeColor = Color.FromArgb(20, 42, 67);
            groupBox3.Margin = new Padding(0, 0, 0, 8);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(16);
            groupBox3.Size = new Size(326, 222);
            groupBox3.TabIndex = 1;
            groupBox3.TabStop = false;
            groupBox3.Text = "Thanh toán";
            // label4
            label4.Font = new Font("Segoe UI", 9F);
            label4.Location = new Point(16, 26);
            label4.Name = "label4";
            label4.Size = new Size(292, 22);
            label4.Text = "Tổng cần thanh toán";
            // lblTotalAmount
            lblTotalAmount.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTotalAmount.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTotalAmount.ForeColor = Color.FromArgb(15, 118, 110);
            lblTotalAmount.Location = new Point(16, 48);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(292, 48);
            lblTotalAmount.Text = "0 đ";
            lblTotalAmount.TextAlign = ContentAlignment.MiddleRight;
            // lblDiscountInfo
            lblDiscountInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblDiscountInfo.Font = new Font("Segoe UI", 9F);
            lblDiscountInfo.ForeColor = Color.FromArgb(15, 118, 110);
            lblDiscountInfo.Location = new Point(16, 98);
            lblDiscountInfo.Name = "lblDiscountInfo";
            lblDiscountInfo.Size = new Size(292, 22);
            lblDiscountInfo.TextAlign = ContentAlignment.MiddleRight;
            // label5
            label5.Font = new Font("Segoe UI", 9F);
            label5.Location = new Point(16, 122);
            label5.Name = "label5";
            label5.Size = new Size(292, 22);
            label5.Text = "Tiền khách đưa";
            // txtCashReceived
            txtCashReceived.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCashReceived.BackColor = Color.FromArgb(248, 250, 252);
            txtCashReceived.Font = new Font("Segoe UI", 11F);
            txtCashReceived.Location = new Point(16, 148);
            txtCashReceived.Name = "txtCashReceived";
            txtCashReceived.PlaceholderText = "Nhập số tiền";
            txtCashReceived.Size = new Size(292, 32);
            txtCashReceived.TabIndex = 0;
            txtCashReceived.TextAlign = HorizontalAlignment.Right;
            // label6
            label6.Font = new Font("Segoe UI", 9F);
            label6.Location = new Point(16, 190);
            label6.Name = "label6";
            label6.Size = new Size(90, 22);
            label6.Text = "Tiền thừa";
            // lblChange
            lblChange.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblChange.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblChange.ForeColor = Color.FromArgb(15, 118, 110);
            lblChange.Location = new Point(112, 182);
            lblChange.Name = "lblChange";
            lblChange.Size = new Size(196, 34);
            lblChange.Text = "0 đ";
            lblChange.TextAlign = ContentAlignment.MiddleRight;
            // btnCheckout
            btnCheckout.BackColor = Color.FromArgb(15, 118, 110);
            btnCheckout.Cursor = Cursors.Hand;
            btnCheckout.Dock = DockStyle.Fill;
            btnCheckout.FlatAppearance.BorderSize = 0;
            btnCheckout.FlatAppearance.MouseOverBackColor = Color.FromArgb(13, 102, 95);
            btnCheckout.FlatStyle = FlatStyle.Flat;
            btnCheckout.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCheckout.ForeColor = Color.White;
            btnCheckout.Margin = new Padding(0, 0, 0, 8);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.TabIndex = 2;
            btnCheckout.Text = "Thanh toán (F9)";
            btnCheckout.UseVisualStyleBackColor = false;
            // btnClearCart
            btnClearCart.BackColor = Color.FromArgb(254, 242, 242);
            btnClearCart.Cursor = Cursors.Hand;
            btnClearCart.Dock = DockStyle.Fill;
            btnClearCart.FlatAppearance.BorderColor = Color.FromArgb(254, 202, 202);
            btnClearCart.FlatAppearance.MouseOverBackColor = Color.FromArgb(254, 226, 226);
            btnClearCart.FlatStyle = FlatStyle.Flat;
            btnClearCart.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClearCart.ForeColor = Color.FromArgb(185, 28, 28);
            btnClearCart.Margin = new Padding(0, 0, 0, 8);
            btnClearCart.Name = "btnClearCart";
            btnClearCart.TabIndex = 3;
            btnClearCart.Text = "Hủy giỏ hàng";
            btnClearCart.UseVisualStyleBackColor = false;
            // FormPOS
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(242, 245, 250);
            ClientSize = new Size(917, 600);
            Controls.Add(tableLayoutMain);
            tableLayoutMain.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ForeColor = Color.FromArgb(20, 42, 67);
            MinimumSize = new Size(935, 624);
            Name = "FormPOS";
            Text = "Hana Shop | Quầy bán hàng";
            ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudPointsToRedeem).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tableLayoutCheckout.ResumeLayout(false);
            tableLayoutCheckout.PerformLayout();
            tableLayoutMain.ResumeLayout(false);
            tableLayoutMain.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutMain;
        private TableLayoutPanel tableLayoutCheckout;
        private GroupBox groupBox1;
        private DataGridView dgvCart;
        private DataGridViewTextBoxColumn colProductCode;
        private DataGridViewTextBoxColumn colProductName;
        private DataGridViewTextBoxColumn colUnitPrice;
        private DataGridViewTextBoxColumn colQuantity;
        private DataGridViewTextBoxColumn colAmount;
        private TextBox txtBarcode;
        private Label lblScanHint;
        private GroupBox groupBox2;
        private Label lblCustomerName;
        private Label lblCustomerPoints;
        private CheckBox chkUsePoints;
        private NumericUpDown nudPointsToRedeem;
        private Label lblDiscountInfo;
        private TextBox txtCustomerPhone;
        private Label label3;
        private GroupBox groupBox3;
        private Label lblChange;
        private Label label6;
        private TextBox txtCashReceived;
        private Label label5;
        private Label lblTotalAmount;
        private Label label4;
        private Button btnCheckout;
        private Button btnClearCart;
    }
}
