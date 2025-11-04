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
    public partial class BT5 : Form
    {
        public BT5()
        {
            InitializeComponent();
        }
        // Chuỗi kết nối của bạn 
        string strConnectionString = "Data Source=DESKTOP-JK67N6H\\DIENMAYCAM;Initial Catalog=QLBH;Integrated Security=True; User Id =sa; Password = 123456";

        // Đối tượng kết nối dữ liệu
        SqlConnection conn = null;
        // Đối tượng thực hiện vận chuyển dữ liệu
        SqlDataAdapter da = null;
        // Đối tượng chứa dữ liệu trong bộ nhớ
        DataSet ds = null;


        // Hàm Tìm kiếm
        void TimKiem(string keyword)
        {
            using (conn = new SqlConnection(strConnectionString))
            {
                try
                {
                    conn.Open();

                    // Khai báo câu truy vấn
                    string sql = "";
                    if (string.IsNullOrWhiteSpace(keyword))
                    {
                        // Nếu từ khóa rỗng, hiển thị toàn bộ
                        sql = "SELECT * FROM SanPham";
                    }
                    else
                    {
                        sql = "SELECT * FROM SanPham WHERE TenSP COLLATE SQL_Latin1_General_CP1_CI_AI LIKE N'%" + keyword + "%' COLLATE SQL_Latin1_General_CP1_CI_AI"; ;
                    }

                    // Vận chuyển dữ liệu
                    da = new SqlDataAdapter(sql, conn);
                    ds = new DataSet();
                    da.Fill(ds, "ABC");

                    // Đưa dữ liệu lên DataGridView dgSanPham
                    dgSanPham.DataSource = ds.Tables["ABC"];

                    // Tùy chỉnh HeaderText 
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
                    MessageBox.Show("Không lấy được dữ liệu, có lỗi rồi! Kiểm tra kết nối.", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi không mong muốn: {ex.Message}", "Lỗi Chung", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // Khối using tự động đóng kết nối (conn.Dispose/conn.Close)
            }
        }

        private void BT5_Load(object sender, EventArgs e)
        {
            // Hiển thị toàn bộ danh sách khi Form Load lần đầu
            TimKiem(txtKeyWord.Text);

        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            // Kích hoạt hàm tìm kiếm khi nhấn nút
            string keyword = txtKeyWord.Text;
            TimKiem(keyword);
            if (!string.IsNullOrWhiteSpace(keyword) && dgSanPham.Rows.Count == 0)
            {
                MessageBox.Show($"Không tìm thấy sản phẩm nào khớp với từ khóa '{keyword}'.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void txtKeyWord_KeyDown(object sender, KeyEventArgs e)
        {
            // Kiểm tra xem người dùng có nhấn phím Enter (Keys.Enter) hay không
            if (e.KeyCode == Keys.Enter)
            {
                // Lấy từ khóa
                string keyword = txtKeyWord.Text;

                // 1. Kích hoạt tìm kiếm
                TimKiem(keyword);

                // 2. Kiểm tra và thông báo (Giống như logic trong btnTimKiem_Click)
                if (!string.IsNullOrWhiteSpace(keyword) && dgSanPham.Rows.Count == 0)
                {
                    MessageBox.Show($"Không tìm thấy sản phẩm nào khớp với từ khóa '{keyword}'.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Ngăn chặn tiếng 'bíp' mặc định khi nhấn Enter trong TextBox
                e.SuppressKeyPress = true;
            }
        }

        // --- Quản lý Tài nguyên---

        private void BT5_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 1. Giải phóng tài nguyên DataSet
            if (ds != null)
            {
                ds.Dispose();
                ds = null;
            }
        }
    }
}
