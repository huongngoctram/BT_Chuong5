namespace BT_Chuong5
{
    partial class BT2
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
            lstSanPham = new ListBox();
            btn_Thoat = new Button();
            lblDMSP = new Label();
            SuspendLayout();
            // 
            // lstSanPham
            // 
            lstSanPham.FormattingEnabled = true;
            lstSanPham.Location = new Point(44, 115);
            lstSanPham.Name = "lstSanPham";
            lstSanPham.Size = new Size(700, 204);
            lstSanPham.TabIndex = 0;
            // 
            // btn_Thoat
            // 
            btn_Thoat.Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_Thoat.Location = new Point(650, 381);
            btn_Thoat.Name = "btn_Thoat";
            btn_Thoat.Size = new Size(94, 29);
            btn_Thoat.TabIndex = 1;
            btn_Thoat.Text = "Thoát";
            btn_Thoat.UseVisualStyleBackColor = true;
            btn_Thoat.Click += btnThoat_Click;
            // 
            // lblDMSP
            // 
            lblDMSP.Font = new Font("Times New Roman", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDMSP.Location = new Point(236, 68);
            lblDMSP.Name = "lblDMSP";
            lblDMSP.Size = new Size(350, 44);
            lblDMSP.TabIndex = 2;
            lblDMSP.Text = "DANH MỤC SẢN PHẨM";
            // 
            // BT2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblDMSP);
            Controls.Add(btn_Thoat);
            Controls.Add(lstSanPham);
            Name = "BT2";
            Text = "Đưa dữ liệu vào ListBox";
            Load += BT2_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListBox lstSanPham;
        private Button btn_Thoat;
        private Label lblDMSP;
    }
}