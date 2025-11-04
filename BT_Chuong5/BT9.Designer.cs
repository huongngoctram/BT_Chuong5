namespace BT_Chuong5
{
    partial class BT9
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
            txtMaSP = new TextBox();
            txtTenSP = new TextBox();
            txtDVT = new TextBox();
            txtDonGia = new TextBox();
            cboLoaiSP = new ComboBox();
            dgSanPham = new DataGridView();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            btnLuu = new Button();
            ((System.ComponentModel.ISupportInitialize)dgSanPham).BeginInit();
            SuspendLayout();
            // 
            // txtMaSP
            // 
            txtMaSP.Location = new Point(186, 51);
            txtMaSP.Name = "txtMaSP";
            txtMaSP.Size = new Size(271, 27);
            txtMaSP.TabIndex = 0;
            // 
            // txtTenSP
            // 
            txtTenSP.Location = new Point(186, 93);
            txtTenSP.Name = "txtTenSP";
            txtTenSP.Size = new Size(271, 27);
            txtTenSP.TabIndex = 1;
            // 
            // txtDVT
            // 
            txtDVT.Location = new Point(186, 142);
            txtDVT.Name = "txtDVT";
            txtDVT.Size = new Size(271, 27);
            txtDVT.TabIndex = 2;
            // 
            // txtDonGia
            // 
            txtDonGia.Location = new Point(186, 190);
            txtDonGia.Name = "txtDonGia";
            txtDonGia.Size = new Size(271, 27);
            txtDonGia.TabIndex = 3;
            // 
            // cboLoaiSP
            // 
            cboLoaiSP.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoaiSP.FormattingEnabled = true;
            cboLoaiSP.Location = new Point(188, 243);
            cboLoaiSP.Name = "cboLoaiSP";
            cboLoaiSP.Size = new Size(269, 28);
            cboLoaiSP.TabIndex = 4;
            // 
            // dgSanPham
            // 
            dgSanPham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgSanPham.Location = new Point(12, 293);
            dgSanPham.Name = "dgSanPham";
            dgSanPham.RowHeadersWidth = 51;
            dgSanPham.Size = new Size(776, 136);
            dgSanPham.TabIndex = 5;
            dgSanPham.CellContentClick += dgSanPham_CellDoubleClick;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(573, 66);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 6;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(573, 178);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 29);
            btnSua.TabIndex = 7;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(573, 237);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 8;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btXoa_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 53);
            label1.Name = "label1";
            label1.Size = new Size(98, 20);
            label1.TabIndex = 9;
            label1.Text = "Mã sản phẩm";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 100);
            label2.Name = "label2";
            label2.Size = new Size(100, 20);
            label2.TabIndex = 10;
            label2.Text = "Tên sản phẩm";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(33, 150);
            label3.Name = "label3";
            label3.Size = new Size(81, 20);
            label3.TabIndex = 11;
            label3.Text = "Đơn vị tính";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(33, 197);
            label4.Name = "label4";
            label4.Size = new Size(62, 20);
            label4.TabIndex = 12;
            label4.Text = "Đơn giá";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(33, 246);
            label5.Name = "label5";
            label5.Size = new Size(105, 20);
            label5.TabIndex = 13;
            label5.Text = "Loại sản phẩm";
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(573, 122);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(94, 29);
            btnLuu.TabIndex = 14;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btLuu_Click;
            // 
            // BT9
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnLuu);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(dgSanPham);
            Controls.Add(cboLoaiSP);
            Controls.Add(txtDonGia);
            Controls.Add(txtDVT);
            Controls.Add(txtTenSP);
            Controls.Add(txtMaSP);
            Name = "BT9";
            Text = "Quản lý sản phẩm";
            Load += BT9_Load;
            ((System.ComponentModel.ISupportInitialize)dgSanPham).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtMaSP;
        private TextBox txtTenSP;
        private TextBox txtDVT;
        private TextBox txtDonGia;
        private ComboBox cboLoaiSP;
        private DataGridView dgSanPham;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btnLuu;
    }
}