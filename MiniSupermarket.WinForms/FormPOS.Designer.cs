namespace MiniSupermarket.WinForms
{
    partial class FormPOS
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
            dgvCart = new DataGridView();
            colProductCode = new DataGridViewTextBoxColumn();
            colProductName = new DataGridViewTextBoxColumn();
            colUnitPrice = new DataGridViewTextBoxColumn();
            colQuantity = new DataGridViewTextBoxColumn();
            colAmount = new DataGridViewTextBoxColumn();
            txtBarcode = new TextBox();
            groupBox2 = new GroupBox();
            lblCustomerName = new Label();
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
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(dgvCart);
            groupBox1.Controls.Add(txtBarcode);
            groupBox1.Location = new Point(14, 16);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(583, 568);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Giỏ hàng thanh toán";
            // 
            // dgvCart
            // 
            dgvCart.AllowUserToAddRows = false;
            dgvCart.AllowUserToDeleteRows = false;
            dgvCart.AllowUserToResizeRows = false;
            dgvCart.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCart.Columns.AddRange(new DataGridViewColumn[] { colProductCode, colProductName, colUnitPrice, colQuantity, colAmount });
            dgvCart.Location = new Point(11, 73);
            dgvCart.Margin = new Padding(3, 4, 3, 4);
            dgvCart.MultiSelect = false;
            dgvCart.Name = "dgvCart";
            dgvCart.ReadOnly = true;
            dgvCart.RowHeadersVisible = false;
            dgvCart.RowHeadersWidth = 51;
            dgvCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCart.Size = new Size(558, 476);
            dgvCart.TabIndex = 2;
            // 
            // colProductCode
            // 
            colProductCode.HeaderText = "Mã SP";
            colProductCode.MinimumWidth = 6;
            colProductCode.Name = "colProductCode";
            colProductCode.ReadOnly = true;
            // 
            // colProductName
            // 
            colProductName.HeaderText = "Tên SP";
            colProductName.MinimumWidth = 6;
            colProductName.Name = "colProductName";
            colProductName.ReadOnly = true;
            // 
            // colUnitPrice
            // 
            colUnitPrice.HeaderText = "Đơn giá";
            colUnitPrice.MinimumWidth = 6;
            colUnitPrice.Name = "colUnitPrice";
            colUnitPrice.ReadOnly = true;
            // 
            // colQuantity
            // 
            colQuantity.HeaderText = "Số lượng";
            colQuantity.MinimumWidth = 6;
            colQuantity.Name = "colQuantity";
            colQuantity.ReadOnly = true;
            // 
            // colAmount
            // 
            colAmount.HeaderText = "Thành tiền";
            colAmount.MinimumWidth = 6;
            colAmount.Name = "colAmount";
            colAmount.ReadOnly = true;
            // 
            // txtBarcode
            // 
            txtBarcode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBarcode.Location = new Point(11, 29);
            txtBarcode.Margin = new Padding(3, 4, 3, 4);
            txtBarcode.Name = "txtBarcode";
            txtBarcode.PlaceholderText = "Quét hoặc nhập mã vạch...";
            txtBarcode.Size = new Size(557, 27);
            txtBarcode.TabIndex = 1;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox2.Controls.Add(lblCustomerName);
            groupBox2.Controls.Add(txtCustomerPhone);
            groupBox2.Controls.Add(label3);
            groupBox2.Location = new Point(603, 16);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(297, 160);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thông tin khách hàng";
            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCustomerName.ForeColor = Color.FromArgb(41, 100, 180);
            lblCustomerName.Location = new Point(11, 109);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(167, 20);
            lblCustomerName.TabIndex = 2;
            lblCustomerName.Text = "Chưa chọn khách hàng";
            // 
            // txtCustomerPhone
            // 
            txtCustomerPhone.Location = new Point(11, 67);
            txtCustomerPhone.Margin = new Padding(3, 4, 3, 4);
            txtCustomerPhone.Name = "txtCustomerPhone";
            txtCustomerPhone.PlaceholderText = "Nhập số điện thoại...";
            txtCustomerPhone.Size = new Size(274, 27);
            txtCustomerPhone.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(11, 37);
            label3.Name = "label3";
            label3.Size = new Size(125, 20);
            label3.TabIndex = 0;
            label3.Text = "SĐT khách hàng:";
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox3.Controls.Add(lblChange);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(txtCashReceived);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(lblTotalAmount);
            groupBox3.Controls.Add(label4);
            groupBox3.Location = new Point(603, 189);
            groupBox3.Margin = new Padding(3, 4, 3, 4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 4, 3, 4);
            groupBox3.Size = new Size(297, 253);
            groupBox3.TabIndex = 4;
            groupBox3.TabStop = false;
            groupBox3.Text = "Thông tin thanh toán";
            // 
            // lblChange
            // 
            lblChange.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblChange.ForeColor = Color.FromArgb(0, 128, 0);
            lblChange.Location = new Point(103, 187);
            lblChange.Name = "lblChange";
            lblChange.Size = new Size(183, 33);
            lblChange.TabIndex = 5;
            lblChange.Text = "0 đ";
            lblChange.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.Location = new Point(11, 193);
            label6.Name = "label6";
            label6.Size = new Size(80, 20);
            label6.TabIndex = 4;
            label6.Text = "Tiền thừa:";
            // 
            // txtCashReceived
            // 
            txtCashReceived.Location = new Point(11, 147);
            txtCashReceived.Margin = new Padding(3, 4, 3, 4);
            txtCashReceived.Name = "txtCashReceived";
            txtCashReceived.PlaceholderText = "Nhập số tiền...";
            txtCashReceived.Size = new Size(274, 27);
            txtCashReceived.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.Location = new Point(11, 120);
            label5.Name = "label5";
            label5.Size = new Size(119, 20);
            label5.TabIndex = 2;
            label5.Text = "Tiền khách đưa:";
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTotalAmount.ForeColor = Color.FromArgb(192, 0, 0);
            lblTotalAmount.Location = new Point(11, 64);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(274, 47);
            lblTotalAmount.TabIndex = 1;
            lblTotalAmount.Text = "0 đ";
            lblTotalAmount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(11, 37);
            label4.Name = "label4";
            label4.Size = new Size(80, 20);
            label4.TabIndex = 0;
            label4.Text = "Tổng tiền:";
            // 
            // btnCheckout
            // 
            btnCheckout.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCheckout.BackColor = Color.FromArgb(0, 128, 0);
            btnCheckout.FlatStyle = FlatStyle.Flat;
            btnCheckout.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCheckout.ForeColor = Color.White;
            btnCheckout.Location = new Point(603, 460);
            btnCheckout.Margin = new Padding(3, 4, 3, 4);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new Size(297, 60);
            btnCheckout.TabIndex = 5;
            btnCheckout.Text = "THANH TOÁN (F9)";
            btnCheckout.UseVisualStyleBackColor = false;
            // 
            // btnClearCart
            // 
            btnClearCart.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClearCart.BackColor = Color.FromArgb(192, 0, 0);
            btnClearCart.FlatStyle = FlatStyle.Flat;
            btnClearCart.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClearCart.ForeColor = Color.White;
            btnClearCart.Location = new Point(603, 527);
            btnClearCart.Margin = new Padding(3, 4, 3, 4);
            btnClearCart.Name = "btnClearCart";
            btnClearCart.Size = new Size(297, 57);
            btnClearCart.TabIndex = 6;
            btnClearCart.Text = "HỦY GIỎ HÀNG";
            btnClearCart.UseVisualStyleBackColor = false;
            // 
            // FormPOS
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(917, 600);
            Controls.Add(btnClearCart);
            Controls.Add(btnCheckout);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(935, 624);
            Name = "FormPOS";
            Text = "Bán hàng quầy POS";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtBarcode;
        private DataGridView dgvCart;

        private DataGridViewTextBoxColumn colProductCode;
        private DataGridViewTextBoxColumn colProductName;
        private DataGridViewTextBoxColumn colUnitPrice;
        private DataGridViewTextBoxColumn colQuantity;
        private DataGridViewTextBoxColumn colAmount;

        private GroupBox groupBox2;
        private Label label3;
        private TextBox txtCustomerPhone;
        private Label lblCustomerName;

        private GroupBox groupBox3;
        private Label label4;
        private Label lblTotalAmount;
        private Label label5;
        private TextBox txtCashReceived;
        private Label label6;
        private Label lblChange;

        private Button btnCheckout;
        private Button btnClearCart;
    }
}