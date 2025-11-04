using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BT_Chuong5
{
    public partial class BT1 : Form
    {
        // Khai báo biến ở cấp lớp (scope toàn form)
        string strConnectionString = "Data Source=DESKTOP-JK67N6H\\DIENMAYCAM;Initial Catalog=QLBH;Integrated Security=True";

        // Đối tượng kết nối dữ liệu
        SqlConnection conn = null;
        // Đối tượng vận chuyển dữ liệu
        SqlDataAdapter da = null;
        // Đối tượng chứa dữ liệu trong bộ nhớ
        DataSet ds = null;

        public BT1()
        {
            InitializeComponent();
        }

        private void BT1_Load(object sender, EventArgs e)
        {
            try
            {
                // Khởi động kết nối
                conn = new SqlConnection(strConnectionString);
                conn.Open();

                // Báo kết nối thành công=
                MessageBox.Show("Kết nối Cơ sở dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Lấy dữ liệu từ bảng Sản phẩm
                string sql = "SELECT * FROM SanPham";

                // Vận chuyển dữ liệu vào đối tượng DataSet ds
                da = new SqlDataAdapter(sql, conn);
                ds = new DataSet();
                da.Fill(ds);
            }
            catch (SqlException ex)
            {
                // Báo kết nối thất bại và hiển thị chi tiết lỗi
                MessageBox.Show($"Lỗi kết nối CSDL: Server không tìm thấy hoặc không truy cập được.\n\nChi tiết lỗi: {ex.Message}", "Lỗi Kết Nối", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Tắt ứng dụng nếu kết nối thất bại nghiêm trọng
                this.Close();
            }
            catch (Exception ex)
            {
                // Bắt các lỗi khác 
                MessageBox.Show($"Đã xảy ra lỗi không mong muốn: {ex.Message}", "Lỗi Chung", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BT1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Giải phóng tài nguyên
            if (ds != null)
            {
                ds.Dispose();
                ds = null;
            }

            // Đóng và hủy kết nối
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
                conn = null;
            }
        }
    }
}