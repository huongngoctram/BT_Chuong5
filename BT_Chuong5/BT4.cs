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
    public partial class BT4 : Form
    {
        public BT4()
        {
            InitializeComponent();
        }
        string strConnectionString = "Data Source=DESKTOP-JK67N6H\\DIENMAYCAM;Initial Catalog=QLBH;Integrated Security=True; User Id =sa; Password = 123456";
        // Đối tượng kết nối dữ liệu
        SqlConnection conn = null;
        // Đối tượng thực hiện vận chuyển dữ liệu
        SqlDataAdapter da = null;
        // Đối tượng chứa dữ liệu trong bộ nhớ
        DataSet ds = null;
        private void BT4_Load(object sender, EventArgs e)
        {
            try
            {
                // Khởi động kết nối
                conn = new SqlConnection(strConnectionString);
                conn.Open();

                // Vận chuyển dữ liệu từ bảng SanPham
                string sql = "SELECT * FROM SanPham";
                da = new SqlDataAdapter(sql, conn);

                // Khởi tạo chuyển dữ liệu vào DataSet
                ds = new DataSet();
                da.Fill(ds);

                // Đưa dữ liệu lên DataGridView
                // 1. Gán nguồn dữ liệu 
                dgSanPham.DataSource = ds.Tables[0];

                // 2. Thiết lập tiêu đề cột
                if (dgSanPham.Columns.Count >= 5)
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
                // Bẫy lỗi SQL Server 
                MessageBox.Show("Không lấy được dữ liệu, có lỗi rồi!\nKiểm tra chuỗi kết nối và trạng thái SQL Server.", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            catch (Exception ex)
            {
                // Bẫy lỗi chung khác
                MessageBox.Show($"Đã xảy ra lỗi không mong muốn: {ex.Message}", "Lỗi Chung", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Luôn đảm bảo đóng kết nối sau khi đã thực hiện xong các thao tác
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        private void BT4_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 1. Giải phóng tài nguyên DataSet
            if (ds != null)
            {
                ds.Dispose();
                ds = null;
            }

            // 2. Đóng và hủy kết nối
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
                conn = null;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi chương trình không?", "Xác nhận Thoát",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (traloi == DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
 }
