namespace MiniSupermarket.WinForms
{
    partial class FormCategoryManagement
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
            dgvCategories = new DataGridView();
            panelDetail = new Panel();
            panelButtons = new TableLayoutPanel();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            groupBox3 = new GroupBox();
            label3 = new Label();
            label2 = new Label();
            txtDescription = new TextBox();
            txtCategoryName = new TextBox();
            txtId = new TextBox();
            label1 = new Label();
            groupBox1 = new GroupBox();
            panelSearchActions = new TableLayoutPanel();
            txtKeyword = new TextBox();
            btnSearch = new Button();
            btnLoad = new Button();
            panelRoot.SuspendLayout();
            tableLayoutPanelContent.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCategories).BeginInit();
            panelDetail.SuspendLayout();
            panelButtons.SuspendLayout();
            groupBox3.SuspendLayout();
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
            panelRoot.Margin = new Padding(3, 4, 3, 4);
            panelRoot.Name = "panelRoot";
            panelRoot.BackColor = Color.FromArgb(242, 245, 250);
            panelRoot.Padding = new Padding(16);
            panelRoot.Size = new Size(1029, 667);
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
            tableLayoutPanelContent.Location = new Point(14, 116);
            tableLayoutPanelContent.Margin = new Padding(0);
            tableLayoutPanelContent.Name = "tableLayoutPanelContent";
            tableLayoutPanelContent.Padding = new Padding(0, 12, 0, 0);
            tableLayoutPanelContent.RowCount = 1;
            tableLayoutPanelContent.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelContent.Size = new Size(1001, 535);
            tableLayoutPanelContent.TabIndex = 2;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvCategories);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(0, 11);
            groupBox2.Margin = new Padding(0, 0, 12, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox2.ForeColor = Color.FromArgb(22, 54, 90);
            groupBox2.BackColor = Color.White;
            groupBox2.Padding = new Padding(12);
            groupBox2.Size = new Size(672, 524);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh sách nhóm hàng";
            // 
            // dgvCategories
            // 
            dgvCategories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCategories.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvCategories.Dock = DockStyle.Fill;
            dgvCategories.Location = new Point(7, 28);
            dgvCategories.Margin = new Padding(0);
            dgvCategories.MultiSelect = false;
            dgvCategories.Name = "dgvCategories";
            dgvCategories.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dgvCategories.AllowUserToDeleteRows = false;
            dgvCategories.AllowUserToAddRows = false;
            dgvCategories.AllowUserToResizeRows = false;
            dgvCategories.RowTemplate.Height = 36;
            dgvCategories.RowHeadersVisible = false;
            dgvCategories.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCategories.GridColor = Color.FromArgb(235, 240, 247);
            dgvCategories.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 253);
            dgvCategories.DefaultCellStyle.Padding = new Padding(8, 0, 8, 0);
            dgvCategories.DefaultCellStyle.SelectionForeColor = Color.FromArgb(22, 54, 90);
            dgvCategories.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 234, 254);
            dgvCategories.DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dgvCategories.DefaultCellStyle.ForeColor = Color.FromArgb(31, 41, 55);
            dgvCategories.DefaultCellStyle.BackColor = Color.White;
            dgvCategories.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 0, 8, 0);
            dgvCategories.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(22, 54, 90);
            dgvCategories.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(232, 239, 250);
            dgvCategories.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            dgvCategories.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(22, 54, 90);
            dgvCategories.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(232, 239, 250);
            dgvCategories.ColumnHeadersHeight = 42;
            dgvCategories.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvCategories.EnableHeadersVisualStyles = false;
            dgvCategories.BorderStyle = BorderStyle.None;
            dgvCategories.BackgroundColor = Color.White;
            dgvCategories.ReadOnly = true;
            dgvCategories.RowHeadersWidth = 51;
            dgvCategories.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategories.Size = new Size(658, 488);
            dgvCategories.TabIndex = 0;
            dgvCategories.CellClick += dgvCategories_CellClick;
            // 
            // panelDetail
            // 
            panelDetail.Controls.Add(panelButtons);
            panelDetail.Controls.Add(groupBox3);
            panelDetail.Dock = DockStyle.Fill;
            panelDetail.Location = new Point(684, 15);
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
            panelButtons.Location = new Point(0, 265);
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
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(105, 13);
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
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(203, 13);
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
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label3);
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(txtDescription);
            groupBox3.Controls.Add(txtCategoryName);
            groupBox3.Controls.Add(txtId);
            groupBox3.Controls.Add(label1);
            groupBox3.Dock = DockStyle.Top;
            groupBox3.Location = new Point(0, 0);
            groupBox3.Margin = new Padding(0);
            groupBox3.Name = "groupBox3";
            groupBox3.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox3.ForeColor = Color.FromArgb(22, 54, 90);
            groupBox3.BackColor = Color.White;
            groupBox3.Padding = new Padding(12);
            groupBox3.Size = new Size(320, 304);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            groupBox3.Text = "Thông tin nhóm hàng";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 156);
            label3.Name = "label3";
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.FromArgb(22, 54, 90);
            label3.Size = new Size(48, 20);
            label3.TabIndex = 5;
            label3.Text = "Mô tả";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 94);
            label2.Name = "label2";
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.FromArgb(22, 54, 90);
            label2.Size = new Size(111, 20);
            label2.TabIndex = 4;
            label2.Text = "Tên nhóm hàng";
            label2.Click += label2_Click;
            // 
            // txtDescription
            // 
            txtDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDescription.Location = new Point(16, 180);
            txtDescription.Margin = new Padding(0);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.BorderStyle = BorderStyle.FixedSingle;
            txtDescription.BackColor = Color.White;
            txtDescription.ForeColor = Color.FromArgb(31, 41, 55);
            txtDescription.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtDescription.Size = new Size(288, 92);
            txtDescription.TabIndex = 3;
            // 
            // txtCategoryName
            // 
            txtCategoryName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCategoryName.Location = new Point(16, 118);
            txtCategoryName.Margin = new Padding(0);
            txtCategoryName.Name = "txtCategoryName";
            txtCategoryName.BorderStyle = BorderStyle.FixedSingle;
            txtCategoryName.BackColor = Color.White;
            txtCategoryName.ForeColor = Color.FromArgb(31, 41, 55);
            txtCategoryName.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtCategoryName.Size = new Size(288, 28);
            txtCategoryName.TabIndex = 2;
            txtCategoryName.TextChanged += textBox2_TextChanged;
            // 
            // txtId
            // 
            txtId.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtId.Location = new Point(16, 56);
            txtId.Margin = new Padding(0);
            txtId.Name = "txtId";
            txtId.BorderStyle = BorderStyle.FixedSingle;
            txtId.BackColor = Color.FromArgb(238, 242, 247);
            txtId.ForeColor = Color.FromArgb(31, 41, 55);
            txtId.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtId.Size = new Size(288, 28);
            txtId.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 32);
            label1.Name = "label1";
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(22, 54, 90);
            label1.Size = new Size(49, 20);
            label1.TabIndex = 0;
            label1.Text = "Mã ID";
            label1.Click += label1_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(panelSearchActions);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(14, 16);
            groupBox1.Margin = new Padding(0, 0, 12, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.ForeColor = Color.FromArgb(22, 54, 90);
            groupBox1.BackColor = Color.White;
            groupBox1.Padding = new Padding(16, 10, 16, 14);
            groupBox1.Size = new Size(968, 88);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tìm kiếm";
            // 
            // panelSearchActions
            // 
            panelSearchActions.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelSearchActions.Location = new Point(12, 34);
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
            panelSearchActions.Padding = new Padding(0);
            panelSearchActions.Dock = DockStyle.Fill;
            panelSearchActions.Size = new Size(986, 40);
            panelSearchActions.TabIndex = 1;
            // 
            // txtKeyword
            // 
            txtKeyword.Location = new Point(0, 7);
            txtKeyword.Margin = new Padding(0, 8, 12, 8);
            txtKeyword.Name = "txtKeyword";
            txtKeyword.Dock = DockStyle.Fill;
            txtKeyword.BorderStyle = BorderStyle.FixedSingle;
            txtKeyword.BackColor = Color.White;
            txtKeyword.ForeColor = Color.FromArgb(31, 41, 55);
            txtKeyword.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtKeyword.PlaceholderText = "Nhập từ khóa...";
            txtKeyword.Size = new Size(727, 27);
            txtKeyword.TabIndex = 0;
            txtKeyword.TextChanged += textBox1_TextChanged;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(737, 7);
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
            // btnLoad
            // 
            btnLoad.Location = new Point(857, 7);
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
            // FormCategoryManagement
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
            MinimumSize = new Size(935, 544);
            Name = "FormCategoryManagement";
            Text = "Quản lý danh mục nhóm hàng";
            Load += FormCategoryManagement_Load;
            panelRoot.ResumeLayout(false);
            tableLayoutPanelContent.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCategories).EndInit();
            panelDetail.ResumeLayout(false);
            panelButtons.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox1.ResumeLayout(false);
            panelSearchActions.ResumeLayout(false);
            panelSearchActions.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelRoot;
        private GroupBox groupBox1;
        private TableLayoutPanel panelSearchActions;
        private Button btnLoad;
        private Button btnSearch;
        private TextBox txtKeyword;
        private TableLayoutPanel tableLayoutPanelContent;
        private GroupBox groupBox2;
        private DataGridView dgvCategories;
        private Panel panelDetail;
        private GroupBox groupBox3;
        private Label label1;
        private TextBox txtId;
        private TextBox txtCategoryName;
        private TextBox txtDescription;
        private Label label3;
        private Label label2;
        private TableLayoutPanel panelButtons;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
    }
}