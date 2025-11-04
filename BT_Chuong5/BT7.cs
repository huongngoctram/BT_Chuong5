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
    public partial class BT7 : Form
    {
        public BT7()
        {
            InitializeComponent();
        }
        string strConnectionString = "Data Source=DESKTOP-JK67N6H\\DIENMAYCAM;Initial Catalog=QLBH;Integrated Security=True; User Id =sa; Password = 123456";

        // Đối tượng kết nối dữ liệu (Khai báo ở cấp lớp)
        SqlConnection conn = null;
        SqlDataAdapter da = null;
        DataSet ds = null;

        // --- HÀM 1: Tải Sản phẩm theo Mã loại ---
        void LoadSanPham(string maloai)
        {
            try
            {
                // Mở kết nối nếu nó đang đóng
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                // Vận chuyển dữ liệu vào DataGridView
                string sql = "SELECT * FROM SanPham WHERE MaLoai='" + maloai + "'";

                // Khởi tạo đối tượng DataAdapter mới
                da = new SqlDataAdapter(sql, conn);
                ds = new DataSet();
                da.Fill(ds, "SanPham");

                dgSanPham.DataSource = ds.Tables["SanPham"];

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
            // if (conn.State == ConnectionState.Open) conn.Close();
        }

        // --- SỰ KIỆN 1: Form Load  ---
        private void BT7_Load(object sender, EventArgs e)
        {
            try
            {
                // Khởi tạo kết nối
                conn = new SqlConnection(strConnectionString);
                // Mở kết nối (Cần mở để DataAdapter thực hiện truy vấn)
                conn.Open();

                // 1. Vận chuyển dữ liệu Loại Sản phẩm
                da = new SqlDataAdapter("SELECT * FROM LoaiSanPham", conn);
                ds = new DataSet();
                da.Fill(ds, "LoaiSanPham");

                // 2. Đưa dữ liệu lên TreeView
                trvLoaiSanPham.Nodes.Clear();
                TreeNode node;

                foreach (DataRow dr in ds.Tables["LoaiSanPham"].Rows)
                {
                    node = new TreeNode();
                    node.Text = dr["TenLoai"].ToString(); // Tên hiển thị
                    node.Tag = dr["MaLoai"].ToString();  // Giá trị khi được chọn
                    trvLoaiSanPham.Nodes.Add(node);
                }

                // Chọn node đầu tiên và tải sản phẩm lần đầu
                if (trvLoaiSanPham.Nodes.Count > 0)
                {
                    trvLoaiSanPham.SelectedNode = trvLoaiSanPham.Nodes[0];
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Không lấy được dữ liệu Loại Sản phẩm! " + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            finally
            {
                // Đóng kết nối sau khi đã tải xong dữ liệu
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        // --- SỰ KIỆN 2: TreeView After Select  ---
        private void trvLoaiSanPham_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Kiểm tra node được chọn có giá trị Tag (MaLoai) hay không
            if (trvLoaiSanPham.SelectedNode != null && trvLoaiSanPham.SelectedNode.Tag != null)
            {
                LoadSanPham(trvLoaiSanPham.SelectedNode.Tag.ToString());
            }
        }

        // --- SỰ KIỆN 3: Form Closing ---
        private void BT7_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ds != null)
            {
                ds.Dispose();
                ds = null;
            }
            // Đóng kết nối nếu nó đang mở
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
                conn = null;
            }
        }
    }
}
