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
            label1 = new Label();

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
            groupBox1.Controls.Add(dgvCart);
            groupBox1.Controls.Add(txtBarcode);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(510, 426);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Giỏ hàng thanh toán";

            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(10, 25);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 0;
            label1.Text = "Mã vạch:";

            // 
            // txtBarcode
            // 
            txtBarcode.Location = new Point(78, 22);
            txtBarcode.Name = "txtBarcode";
            txtBarcode.PlaceholderText = "Quét hoặc nhập mã vạch...";
            txtBarcode.Size = new Size(420, 23);
            txtBarcode.TabIndex = 1;

            // 
            // dgvCart
            // 
            dgvCart.AllowUserToAddRows = false;
            dgvCart.AllowUserToDeleteRows = false;
            dgvCart.AllowUserToResizeRows = false;
            dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCart.Columns.AddRange(new DataGridViewColumn[]
            {
                colProductCode,
                colProductName,
                colUnitPrice,
                colQuantity,
                colAmount
            });
            dgvCart.Location = new Point(10, 55);
            dgvCart.MultiSelect = false;
            dgvCart.Name = "dgvCart";
            dgvCart.ReadOnly = true;
            dgvCart.RowHeadersVisible = false;
            dgvCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCart.Size = new Size(488, 357);
            dgvCart.TabIndex = 2;

            // 
            // colProductCode
            // 
            colProductCode.HeaderText = "Mã SP";
            colProductCode.Name = "colProductCode";
            colProductCode.ReadOnly = true;

            // 
            // colProductName
            // 
            colProductName.HeaderText = "Tên SP";
            colProductName.Name = "colProductName";
            colProductName.ReadOnly = true;

            // 
            // colUnitPrice
            // 
            colUnitPrice.HeaderText = "Đơn giá";
            colUnitPrice.Name = "colUnitPrice";
            colUnitPrice.ReadOnly = true;

            // 
            // colQuantity
            // 
            colQuantity.HeaderText = "Số lượng";
            colQuantity.Name = "colQuantity";
            colQuantity.ReadOnly = true;

            // 
            // colAmount
            // 
            colAmount.HeaderText = "Thành tiền";
            colAmount.Name = "colAmount";
            colAmount.ReadOnly = true;

            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lblCustomerName);
            groupBox2.Controls.Add(txtCustomerPhone);
            groupBox2.Controls.Add(label3);
            groupBox2.Location = new Point(528, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(260, 120);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thông tin khách hàng";

            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(10, 28);
            label3.Name = "label3";
            label3.Size = new Size(101, 15);
            label3.TabIndex = 0;
            label3.Text = "SĐT khách hàng:";

            // 
            // txtCustomerPhone
            // 
            txtCustomerPhone.Location = new Point(10, 50);
            txtCustomerPhone.Name = "txtCustomerPhone";
            txtCustomerPhone.PlaceholderText = "Nhập số điện thoại...";
            txtCustomerPhone.Size = new Size(240, 23);
            txtCustomerPhone.TabIndex = 1;

            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCustomerName.ForeColor = Color.FromArgb(41, 100, 180);
            lblCustomerName.Location = new Point(10, 82);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(137, 15);
            lblCustomerName.TabIndex = 2;
            lblCustomerName.Text = "Chưa chọn khách hàng";

            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(lblChange);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(txtCashReceived);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(lblTotalAmount);
            groupBox3.Controls.Add(label4);
            groupBox3.Location = new Point(528, 142);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(260, 190);
            groupBox3.TabIndex = 4;
            groupBox3.TabStop = false;
            groupBox3.Text = "Thông tin thanh toán";

            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(10, 28);
            label4.Name = "label4";
            label4.Size = new Size(66, 15);
            label4.TabIndex = 0;
            label4.Text = "Tổng tiền:";

            // 
            // lblTotalAmount
            // 
            lblTotalAmount.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTotalAmount.ForeColor = Color.FromArgb(192, 0, 0);
            lblTotalAmount.Location = new Point(10, 48);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(240, 35);
            lblTotalAmount.TabIndex = 1;
            lblTotalAmount.Text = "0 đ";
            lblTotalAmount.TextAlign = ContentAlignment.MiddleRight;

            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.Location = new Point(10, 90);
            label5.Name = "label5";
            label5.Size = new Size(92, 15);
            label5.TabIndex = 2;
            label5.Text = "Tiền khách đưa:";

            // 
            // txtCashReceived
            // 
            txtCashReceived.Location = new Point(10, 110);
            txtCashReceived.Name = "txtCashReceived";
            txtCashReceived.PlaceholderText = "Nhập số tiền...";
            txtCashReceived.Size = new Size(240, 23);
            txtCashReceived.TabIndex = 3;

            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.Location = new Point(10, 145);
            label6.Name = "label6";
            label6.Size = new Size(66, 15);
            label6.TabIndex = 4;
            label6.Text = "Tiền thừa:";

            // 
            // lblChange
            // 
            lblChange.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblChange.ForeColor = Color.FromArgb(0, 128, 0);
            lblChange.Location = new Point(90, 140);
            lblChange.Name = "lblChange";
            lblChange.Size = new Size(160, 25);
            lblChange.TabIndex = 5;
            lblChange.Text = "0 đ";
            lblChange.TextAlign = ContentAlignment.MiddleRight;

            // 
            // btnCheckout
            // 
            btnCheckout.BackColor = Color.FromArgb(0, 128, 0);
            btnCheckout.FlatStyle = FlatStyle.Flat;
            btnCheckout.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCheckout.ForeColor = Color.White;
            btnCheckout.Location = new Point(528, 345);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new Size(260, 45);
            btnCheckout.TabIndex = 5;
            btnCheckout.Text = "THANH TOÁN (F9)";
            btnCheckout.UseVisualStyleBackColor = false;

            // 
            // btnClearCart
            // 
            btnClearCart.BackColor = Color.FromArgb(192, 0, 0);
            btnClearCart.FlatStyle = FlatStyle.Flat;
            btnClearCart.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClearCart.ForeColor = Color.White;
            btnClearCart.Location = new Point(528, 395);
            btnClearCart.Name = "btnClearCart";
            btnClearCart.Size = new Size(260, 43);
            btnClearCart.TabIndex = 6;
            btnClearCart.Text = "HỦY GIỎ HÀNG";
            btnClearCart.UseVisualStyleBackColor = false;

            // 
            // FormPOS
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnClearCart);
            Controls.Add(btnCheckout);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
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
        private Label label1;
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