namespace BT_Chuong5
{
    partial class BT3
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
            cboSanPham = new ComboBox();
            lblDMSP = new Label();
            btnThoat = new Button();
            SuspendLayout();
            // 
            // cboSanPham
            // 
            cboSanPham.FormattingEnabled = true;
            cboSanPham.Location = new Point(71, 164);
            cboSanPham.Name = "cboSanPham";
            cboSanPham.Size = new Size(485, 28);
            cboSanPham.TabIndex = 0;
            // 
            // lblDMSP
            // 
            lblDMSP.AutoSize = true;
            lblDMSP.Font = new Font("Times New Roman", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDMSP.Location = new Point(165, 118);
            lblDMSP.Name = "lblDMSP";
            lblDMSP.Size = new Size(311, 33);
            lblDMSP.TabIndex = 1;
            lblDMSP.Text = "DANH MỤC SẢN PHẨM";
            // 
            // btnThoat
            // 
            btnThoat.Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnThoat.Location = new Point(599, 163);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(94, 29);
            btnThoat.TabIndex = 2;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // BT3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnThoat);
            Controls.Add(lblDMSP);
            Controls.Add(cboSanPham);
            Name = "BT3";
            Text = "Đưa dữ liệu vào ComboBox";
            Load += BT3_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboSanPham;
        private Label lblDMSP;
        private Button btnThoat;
    }
}