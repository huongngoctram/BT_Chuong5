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
    public partial class BT3 : Form
    {
        public BT3()
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

        private void BT3_Load(object sender, EventArgs e)
        {
            try
            {
                // Khởi động kết nối
                conn = new SqlConnection(strConnectionString);

                // Mở kết nối
                conn.Open();

                // Vận chuyển dữ liệu từ bảng SanPham
                string sql = "SELECT * FROM SanPham";
                da = new SqlDataAdapter(sql, conn);

                // Khởi tạo và Đổ dữ liệu vào DataSet
                ds = new DataSet();
                da.Fill(ds, "SanPham"); // Đặt tên cho bảng trong DataSet

                // Đưa dữ liệu lên ListBox 
                // 1. Gán nguồn dữ liệu (DataTable đầu tiên trong DataSet)
                cboSanPham.DataSource = ds.Tables["SanPham"];
                // 2. Thiết lập thuộc tính hiển thị (tên cột sẽ hiển thị cho người dùng)
                cboSanPham.DisplayMember = "TenSP";
                // 3. Thiết lập thuộc tính giá trị (tên cột sẽ được lấy khi chọn)
                cboSanPham.ValueMember = "MaSP";

                // Báo kết nối thành công (Tùy chọn)
                // MessageBox.Show("Tải dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                // Bẫy lỗi SQL Server 
                MessageBox.Show("Không lấy được dữ liệu, có lỗi rồi!\nKiểm tra chuỗi kết nối và trạng thái SQL Server.", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Thoát chương trình nếu không thể kết nối ngay khi khởi động
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
        private void BT3_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 1. Giải phóng tài nguyên DataSet
            if (ds != null)
            {
                ds.Dispose();
                ds = null;
            }

            // 2. Đóng và hủy kết nối (Đảm bảo chỉ đóng khi kết nối đang mở)
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
                conn = null;
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            // Khai báo biến traloi
            DialogResult traloi;

            // Hiện hộp thoại hỏi đáp
            traloi = MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi chương trình không?", "Xác nhận Thoát",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            // Kiểm tra có nhấp chọn nút xác nhận không?
            if (traloi == DialogResult.OK)
            {
                Application.Exit();
            }
            // Nếu người dùng chọn Thoát, chương trình tiếp tục chạy.
        }
    }
}
