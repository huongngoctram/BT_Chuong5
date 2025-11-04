using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BT_Chuong5
{
    public partial class BT6 : Form
    {
        public BT6()
        {
            InitializeComponent();
        }
        string strConnectionString = "Data Source=DESKTOP-JK67N6H\\DIENMAYCAM;Initial Catalog=QLBH;Integrated Security=True; User Id =sa; Password = 123456";

        // Đối tượng kết nối dữ liệu 
        SqlConnection conn = null;
        SqlDataAdapter da = null;
        DataSet ds = null;

        // --- HÀM 1: Tải Sản phẩm theo Mã loại ---
        void LoadSanPham(string maloai)
        {

            try
            {
                // Vận chuyển dữ liệu vào DataGridView
                string sql = "SELECT * FROM SanPham WHERE MaLoai='" + maloai + "'";

                // Khởi tạo đối tượng DataAdapter mới
                da = new SqlDataAdapter(sql, conn);
                ds = new DataSet();
                da.Fill(ds, "SanPham");

                dgSanPham.DataSource = ds.Tables["SanPham"];
                
                if (ds.Tables["SanPham"].Rows.Count == 0)
                {
                    // Lấy tên loại sản phẩm đang được chọn để hiển thị trong thông báo
                    string tenLoai = cboLoaiSP.Text;
                    MessageBox.Show($"Không tìm thấy sản phẩm nào thuộc loại: {tenLoai}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                // HeaderText 
                if (dgSanPham.Columns.Count >= 5 && dgSanPham.Columns[0].HeaderText != "Mã sản phẩm")
                {
                    dgSanPham.Columns[0].HeaderText = "Mã sản phẩm";
                    dgSanPham.Columns[1].HeaderText = "Tên sản phẩm";
                    dgSanPham.Columns[2].HeaderText = "Đơn vị tính";
                    dgSanPham.Columns[3].HeaderText = "Đơn giá";
                    dgSanPham.Columns[4].HeaderText = "Mã loại sản phẩm";
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được dữ liệu Sản phẩm, có lỗi rồi!", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- SỰ KIỆN 1: Form Load ---
        private void BT6_Load(object sender, EventArgs e)
        {
            try
            {
                // Khởi động kết nối
                conn = new SqlConnection(strConnectionString);
                // Mở kết nối (Giữ kết nối mở cho DataAdapter)
                conn.Open();

                // 1. Vận chuyển dữ liệu Loại Sản phẩm vào ComboBox
                da = new SqlDataAdapter("SELECT * FROM LoaiSanPham", conn);
                ds = new DataSet();
                da.Fill(ds, "LoaiSanPham");

                cboLoaiSP.DataSource = ds.Tables["LoaiSanPham"];
                cboLoaiSP.DisplayMember = "TenLoai";
                cboLoaiSP.ValueMember = "MaLoai";

                // 2. Tải sản phẩm của loại đầu tiên trong ComboBox
                if (cboLoaiSP.Items.Count > 0)
                {
                    cboLoaiSP.SelectedIndex = 0; // Chọn mục đầu tiên
                    LoadSanPham(cboLoaiSP.SelectedValue.ToString());
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Không lấy được dữ liệu Loại Sản phẩm! " + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        // --- SỰ KIỆN 2: Nút Lọc (Tải Sản phẩm theo Mã Loại được chọn) ---
        private void btnLoc_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã có mục nào được chọn chưa
            if (cboLoaiSP.SelectedValue != null)
            {
                LoadSanPham(cboLoaiSP.SelectedValue.ToString());
            }
        }

        // --- SỰ KIỆN 3: Form Closing ---
        private void BT6_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ds != null)
            {
                ds.Dispose();
                ds = null;
            }
            // Đóng kết nối đã được mở trong Form_Load
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
                conn = null;
            }
        }
    }
}
