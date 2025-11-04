namespace BT_Chuong5
{
    partial class BT4
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
            lblDM = new Label();
            bntThoat = new Button();
            ((System.ComponentModel.ISupportInitialize)dgSanPham).BeginInit();
            SuspendLayout();
            // 
            // dgSanPham
            // 
            dgSanPham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgSanPham.Location = new Point(72, 93);
            dgSanPham.Name = "dgSanPham";
            dgSanPham.RowHeadersWidth = 51;
            dgSanPham.Size = new Size(666, 266);
            dgSanPham.TabIndex = 0;
            // 
            // lblDM
            // 
            lblDM.AutoSize = true;
            lblDM.Font = new Font("Times New Roman", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDM.Location = new Point(257, 42);
            lblDM.Name = "lblDM";
            lblDM.Size = new Size(311, 33);
            lblDM.TabIndex = 1;
            lblDM.Text = "DANH MỤC SẢN PHẨM";
            // 
            // bntThoat
            // 
            bntThoat.Location = new Point(644, 379);
            bntThoat.Name = "bntThoat";
            bntThoat.Size = new Size(94, 29);
            bntThoat.TabIndex = 2;
            bntThoat.Text = "Thoát";
            bntThoat.UseVisualStyleBackColor = true;
            bntThoat.Click += btnThoat_Click;
            // 
            // BT4
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(bntThoat);
            Controls.Add(lblDM);
            Controls.Add(dgSanPham);
            Name = "BT4";
            Text = "Đưa dữ liệu vào DataGridVỉew";
            Load += BT4_Load;
            ((System.ComponentModel.ISupportInitialize)dgSanPham).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgSanPham;
        private Label lblDM;
        private Button bntThoat;
    }
}