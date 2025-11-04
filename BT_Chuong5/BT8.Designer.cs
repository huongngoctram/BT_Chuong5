namespace BT_Chuong5
{
    partial class BT8
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
            lblMaSP = new Label();
            txtTenSP = new TextBox();
            txtDVT = new TextBox();
            txtDonGia = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            cboLoaiSP = new ComboBox();
            label4 = new Label();
            btFirst = new Button();
            btPrevious = new Button();
            btNext = new Button();
            btLast = new Button();
            SuspendLayout();
            // 
            // txtMaSP
            // 
            txtMaSP.Location = new Point(234, 41);
            txtMaSP.Name = "txtMaSP";
            txtMaSP.Size = new Size(341, 27);
            txtMaSP.TabIndex = 0;
            // 
            // lblMaSP
            // 
            lblMaSP.AutoSize = true;
            lblMaSP.Location = new Point(78, 44);
            lblMaSP.Name = "lblMaSP";
            lblMaSP.Size = new Size(98, 20);
            lblMaSP.TabIndex = 1;
            lblMaSP.Text = "Mã sản phẩm";
            // 
            // txtTenSP
            // 
            txtTenSP.Location = new Point(234, 105);
            txtTenSP.Name = "txtTenSP";
            txtTenSP.Size = new Size(341, 27);
            txtTenSP.TabIndex = 2;
            // 
            // txtDVT
            // 
            txtDVT.Location = new Point(234, 163);
            txtDVT.Name = "txtDVT";
            txtDVT.Size = new Size(341, 27);
            txtDVT.TabIndex = 3;
            // 
            // txtDonGia
            // 
            txtDonGia.Location = new Point(234, 217);
            txtDonGia.Name = "txtDonGia";
            txtDonGia.Size = new Size(341, 27);
            txtDonGia.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(78, 112);
            label1.Name = "label1";
            label1.Size = new Size(100, 20);
            label1.TabIndex = 5;
            label1.Text = "Tên sản phẩm";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(78, 170);
            label2.Name = "label2";
            label2.Size = new Size(81, 20);
            label2.TabIndex = 6;
            label2.Text = "Đơn vị tính";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(78, 224);
            label3.Name = "label3";
            label3.Size = new Size(62, 20);
            label3.TabIndex = 7;
            label3.Text = "Đơn giá";
            // 
            // cboLoaiSP
            // 
            cboLoaiSP.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoaiSP.FormattingEnabled = true;
            cboLoaiSP.Location = new Point(234, 266);
            cboLoaiSP.Name = "cboLoaiSP";
            cboLoaiSP.Size = new Size(341, 28);
            cboLoaiSP.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(78, 274);
            label4.Name = "label4";
            label4.Size = new Size(105, 20);
            label4.TabIndex = 9;
            label4.Text = "Loại sản phẩm";
            // 
            // btFirst
            // 
            btFirst.Location = new Point(152, 370);
            btFirst.Name = "btFirst";
            btFirst.Size = new Size(94, 29);
            btFirst.TabIndex = 10;
            btFirst.Text = "<<";
            btFirst.UseVisualStyleBackColor = true;
            btFirst.Click += btFirst_Click;
            // 
            // btPrevious
            // 
            btPrevious.Location = new Point(277, 370);
            btPrevious.Name = "btPrevious";
            btPrevious.Size = new Size(94, 29);
            btPrevious.TabIndex = 11;
            btPrevious.Text = "<";
            btPrevious.UseVisualStyleBackColor = true;
            btPrevious.Click += btPrevious_Click;
            // 
            // btNext
            // 
            btNext.Location = new Point(409, 370);
            btNext.Name = "btNext";
            btNext.Size = new Size(94, 29);
            btNext.TabIndex = 12;
            btNext.Text = ">";
            btNext.UseVisualStyleBackColor = true;
            btNext.Click += btNext_Click;
            // 
            // btLast
            // 
            btLast.Location = new Point(534, 370);
            btLast.Name = "btLast";
            btLast.Size = new Size(94, 29);
            btLast.TabIndex = 13;
            btLast.Text = ">>";
            btLast.UseVisualStyleBackColor = true;
            btLast.Click += btLast_Click;
            // 
            // BT8
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btLast);
            Controls.Add(btNext);
            Controls.Add(btPrevious);
            Controls.Add(btFirst);
            Controls.Add(label4);
            Controls.Add(cboLoaiSP);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtDonGia);
            Controls.Add(txtDVT);
            Controls.Add(txtTenSP);
            Controls.Add(lblMaSP);
            Controls.Add(txtMaSP);
            Name = "BT8";
            Text = "Đưa dữ liệu dạng phân trang";
            Load += BT8_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtMaSP;
        private Label lblMaSP;
        private TextBox txtTenSP;
        private TextBox txtDVT;
        private TextBox txtDonGia;
        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox cboLoaiSP;
        private Label label4;
        private Button btFirst;
        private Button btPrevious;
        private Button btNext;
        private Button btLast;
    }
}