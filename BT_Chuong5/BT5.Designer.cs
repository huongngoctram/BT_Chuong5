namespace BT_Chuong5
{
    partial class BT5
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
            dgSanPham = new DataGridView();
            lblKetQua = new Label();
            label1 = new Label();
            txtKeyWord = new TextBox();
            btnTimKiem = new Button();
            ((System.ComponentModel.ISupportInitialize)dgSanPham).BeginInit();
            SuspendLayout();
            // 
            // dgSanPham
            // 
            dgSanPham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgSanPham.Location = new Point(68, 128);
            dgSanPham.Name = "dgSanPham";
            dgSanPham.RowHeadersWidth = 51;
            dgSanPham.Size = new Size(662, 252);
            dgSanPham.TabIndex = 0;
            // 
            // lblKetQua
            // 
            lblKetQua.AutoSize = true;
            lblKetQua.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblKetQua.Location = new Point(68, 94);
            lblKetQua.Name = "lblKetQua";
            lblKetQua.Size = new Size(71, 22);
            lblKetQua.TabIndex = 1;
            lblKetQua.Text = "Kết quả";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(68, 36);
            label1.Name = "label1";
            label1.Size = new Size(226, 22);
            label1.TabIndex = 2;
            label1.Text = "Nhập tên sản phẩm cần tìm:";
            // 
            // txtKeyWord
            // 
            txtKeyWord.Location = new Point(300, 36);
            txtKeyWord.Name = "txtKeyWord";
            txtKeyWord.Size = new Size(307, 27);
            txtKeyWord.TabIndex = 3;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(636, 36);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(94, 29);
            btnTimKiem.TabIndex = 4;
            btnTimKiem.Text = "Tìm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            btnTimKiem.KeyDown += txtKeyWord_KeyDown;
            // 
            // BT5
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnTimKiem);
            Controls.Add(txtKeyWord);
            Controls.Add(label1);
            Controls.Add(lblKetQua);
            Controls.Add(dgSanPham);
            Name = "BT5";
            Text = "Tìm kiếm";
            Load += BT5_Load;
            ((System.ComponentModel.ISupportInitialize)dgSanPham).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgSanPham;
        private Label lblKetQua;
        private Label label1;
        private TextBox txtKeyWord;
        private Button btnTimKiem;
    }
}