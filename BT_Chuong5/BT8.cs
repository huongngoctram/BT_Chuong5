using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BT_Chuong5
{
    public partial class BT8 : Form
    {
        public BT8()
        {
            InitializeComponent();
        }
        string strConnectionString = "Data Source=DESKTOP-JK67N6H\\DIENMAYCAM;Initial Catalog=QLBH;Integrated Security=True; User Id =sa; Password = 123456";

        // Đối tượng kết nối dữ liệu (Khai báo ở cấp lớp)
        SqlConnection conn = null;
        SqlDataAdapter da = null;
        DataSet ds = null;

        // Bảng chứa Sản phẩm để thuận tiện trong quá trình di chuyển mẩu tin
        DataTable dtSP;
        // Biến lưu vị trí dòng
        int vitri = -1;

        // Hàm LoadLoaiSanPham để đưa dữ liệu vào ComboBox
        void LoadLoaiSanPham()
        {
            try
            {
                da = new SqlDataAdapter("SELECT * FROM LoaiSanPham", conn);
                ds = new DataSet();
                da.Fill(ds, "LoaiSanPham");

                cboLoaiSP.DataSource = ds.Tables["LoaiSanPham"];
                cboLoaiSP.DisplayMember = "TenLoai";
                cboLoaiSP.ValueMember = "MaLoai";
            }
            catch (SqlException)
            {
                MessageBox.Show("Không tải được dữ liệu Loại Sản phẩm!", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- SỰ KIỆN 1: Form Load ---
        private void BT8_Load(object sender, EventArgs e)
        {
            try
            {
                // Khởi tạo kết nối
                conn = new SqlConnection(strConnectionString);
                // Mở kết nối
                conn.Open();

                // Đưa dữ liệu vào Bảng sản phẩm dtSP
                da = new SqlDataAdapter("SELECT * FROM SanPham", conn);
                ds = new DataSet();
                da.Fill(ds, "SanPham");

                dtSP = ds.Tables["SanPham"];

                // Đưa dữ liệu Loại sản phẩm vào ComboBox
                LoadLoaiSanPham();

                // Thực hiện chọn nút First đầu tiên để hiển thị mẫu tin đầu tiên
                btFirst.PerformClick();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu sản phẩm: " + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        // --- SỰ KIỆN 2: Nút First (<<) ---
        private void btFirst_Click(object sender, EventArgs e)
        {
            if (dtSP.Rows.Count == 0) return;

            vitri = 0;

            txtMaSP.Text = dtSP.Rows[vitri]["MaSP"].ToString();
            txtTenSP.Text = dtSP.Rows[vitri]["TenSP"].ToString();
            txtDVT.Text = dtSP.Rows[vitri]["DVTinh"].ToString();
            txtDonGia.Text = dtSP.Rows[vitri]["DonGia"].ToString();
            cboLoaiSP.SelectedValue = dtSP.Rows[vitri]["MaLoai"].ToString();
        }

        // --- SỰ KIỆN 3: Nút Last (>>) ---
        private void btLast_Click(object sender, EventArgs e)
        {
            if (dtSP.Rows.Count == 0) return;

            vitri = dtSP.Rows.Count - 1;

            txtMaSP.Text = dtSP.Rows[vitri]["MaSP"].ToString();
            txtTenSP.Text = dtSP.Rows[vitri]["TenSP"].ToString();
            txtDVT.Text = dtSP.Rows[vitri]["DVTinh"].ToString();
            txtDonGia.Text = dtSP.Rows[vitri]["DonGia"].ToString();
            cboLoaiSP.SelectedValue = dtSP.Rows[vitri]["MaLoai"].ToString();
        }

        // --- SỰ KIỆN 4: Nút Next (>) ---
        private void btNext_Click(object sender, EventArgs e)
        {
            if (dtSP.Rows.Count == 0) return;

            vitri++;
            // Ngăn chặn vitri vượt quá giới hạn
            if (vitri > dtSP.Rows.Count - 1) vitri = dtSP.Rows.Count - 1;

            txtMaSP.Text = dtSP.Rows[vitri]["MaSP"].ToString();
            txtTenSP.Text = dtSP.Rows[vitri]["TenSP"].ToString();
            txtDVT.Text = dtSP.Rows[vitri]["DVTinh"].ToString();
            txtDonGia.Text = dtSP.Rows[vitri]["DonGia"].ToString();
            cboLoaiSP.SelectedValue = dtSP.Rows[vitri]["MaLoai"].ToString();
        }

        // --- SỰ KIỆN 5: Nút Previous (<) ---
        private void btPrevious_Click(object sender, EventArgs e)
        {
            if (dtSP.Rows.Count == 0) return;

            vitri--;
            // Ngăn chặn vitri nhỏ hơn 0
            if (vitri < 0) vitri = 0;

            txtMaSP.Text = dtSP.Rows[vitri]["MaSP"].ToString();
            txtTenSP.Text = dtSP.Rows[vitri]["TenSP"].ToString();
            txtDVT.Text = dtSP.Rows[vitri]["DVTinh"].ToString();
            txtDonGia.Text = dtSP.Rows[vitri]["DonGia"].ToString();
            cboLoaiSP.SelectedValue = dtSP.Rows[vitri]["MaLoai"].ToString();
        }

        // --- SỰ KIỆN 6: Form Closing ---
        private void BT8_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ds != null)
            {
                ds.Dispose();
                ds = null;
            }
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
                conn = null;
            }
        }
    }
}
