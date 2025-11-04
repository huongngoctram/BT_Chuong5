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
    public partial class BT9 : Form
    {
        public BT9()
        {
            InitializeComponent();
        }
        // Khai báo ở mức Class
        string strConnectionString = "Data Source=DESKTOP-JK67N6H\\DIENMAYCAM;Initial Catalog=QLBH;Integrated Security=True; User Id =sa; Password = 123456";

        SqlConnection conn = null;
        SqlDataAdapter da = null;
        DataSet ds = null;
        // Đối tượng tự động cập nhật dữ liệu (Không cần khai báo ở đây nếu dùng cục bộ)
        SqlCommandBuilder cmd = null;

        // Biến trạng thái để phân biệt nút Lưu là Thêm hay Sửa (Tùy chọn)
        // bool isAdding = false; 


        // Hàm LoadLoaiSanPham để đưa dữ liệu vào ComboBox
        void LoadLoaiSanPham()
        {
            try
            {
                // Mở kết nối nếu chưa mở
                if (conn.State != ConnectionState.Open) conn.Open();

                // Vận chuyển dữ liệu vào ComboBox
                da = new SqlDataAdapter("SELECT * FROM LoaiSanPham", conn);
                // Tạo một DataSet cục bộ cho loại sản phẩm (không dùng ds chung)
                DataSet dsLoai = new DataSet();
                da.Fill(dsLoai, "LoaiSanPham");

                cboLoaiSP.DataSource = dsLoai.Tables["LoaiSanPham"];
                cboLoaiSP.DisplayMember = "TenLoai";
                cboLoaiSP.ValueMember = "MaLoai";
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi tải Loại Sản phẩm: " + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hàm LoadSanPham để đưa dữ liệu vào DataGridView
        void LoadSanPham()
        {
            try
            {
                // Mở kết nối nếu chưa mở
                if (conn.State != ConnectionState.Open) conn.Open();

                // Vận chuyển dữ liệu vào DataSet/DataGridView
                da = new SqlDataAdapter("SELECT * FROM SanPham", conn);
                // Khởi tạo/Xóa DataSet chung
                ds = new DataSet();
                da.Fill(ds, "SanPham");

                dgSanPham.DataSource = ds.Tables["SanPham"];
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi tải Sản phẩm: " + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- SỰ KIỆN 1: Form Load ---
        private void BT9_Load(object sender, EventArgs e)
        {
            try
            {
                // Khởi tạo kết nối (conn sẽ được đóng lại trong LoadSanPham và LoadLoaiSanPham nếu cần)
                conn = new SqlConnection(strConnectionString);
                conn.Open();

                LoadLoaiSanPham();
                LoadSanPham();

                // Đóng kết nối sau khi tải xong cả hai bảng
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khởi tạo ứng dụng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        // --- SỰ KIỆN 2: DataGridView RowEnter (Hiển thị dữ liệu lên TextBox) ---
        private void dgSanPham_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra tránh lỗi khi dòng cuối cùng (dòng trống để thêm mới) được chọn
            if (e.RowIndex >= 0 && e.RowIndex < dgSanPham.Rows.Count - 1)
            {
                txtMaSP.Enabled = false; // Luôn khóa Mã SP khi xem/sửa
                txtMaSP.Text = dgSanPham.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTenSP.Text = dgSanPham.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtDVT.Text = dgSanPham.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtDonGia.Text = dgSanPham.Rows[e.RowIndex].Cells[3].Value.ToString();
                cboLoaiSP.SelectedValue = dgSanPham.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
        }

        // --- SỰ KIỆN 3: Nút Thêm ---
        private void btThem_Click(object sender, EventArgs e)
        {
            // isAdding = true; // Kích hoạt trạng thái thêm mới
            txtMaSP.Enabled = true; // Cho phép nhập Mã SP khi thêm mới
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtDVT.Text = "";
            txtDonGia.Text = "";
            cboLoaiSP.SelectedIndex = -1; // Chọn trống hoặc mục đầu tiên
            txtMaSP.Focus();
        }

        // --- SỰ KIỆN 4: Nút Lưu (Thêm Dữ liệu) ---
        private void btLuu_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Tạo đối tượng cập nhật tự động
                cmd = new SqlCommandBuilder(da);

                // 2. Thêm dòng mới vào DataTable trong DataSet
                DataRow row = ds.Tables["SanPham"].NewRow();
                row["MaSP"] = txtMaSP.Text;
                row["TenSP"] = txtTenSP.Text;
                row["DVTinh"] = txtDVT.Text;
                row["DonGia"] = txtDonGia.Text;
                row["MaLoai"] = cboLoaiSP.SelectedValue.ToString();
                ds.Tables["SanPham"].Rows.Add(row); // Thêm dòng mới vào bộ nhớ

                // 3. Cập nhật vào CSDL
                if (da.Update(ds, "SanPham") > 0)
                {
                    MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMaSP.Enabled = false; // Khóa Mã SP sau khi lưu
                }
                else
                {
                    MessageBox.Show("Lưu không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Cần load lại dữ liệu để DataGridView hiển thị chính xác và reset trạng thái của DataSet
                LoadSanPham();
            }
        }

        // --- SỰ KIỆN 5: Nút Sửa ---
        private void btSua_Click(object sender, EventArgs e)
        {
            try
            {
                // Đảm bảo có dòng đang được chọn
                if (dgSanPham.CurrentRow == null) return;

                // 1. Tạo đối tượng cập nhật tự động
                cmd = new SqlCommandBuilder(da);

                // 2. Tìm dòng hiện tại trong DataSet
                int pos = dgSanPham.CurrentRow.Index;
                DataRow row = ds.Tables["SanPham"].Rows[pos];

                // 3. Cập nhật các trường (Lưu ý: Không nên sửa Mã SP nếu nó là Primary Key)
                row["TenSP"] = txtTenSP.Text;
                row["DVTinh"] = txtDVT.Text;
                row["DonGia"] = txtDonGia.Text;
                row["MaLoai"] = cboLoaiSP.SelectedValue.ToString();
                row.EndEdit(); // Kết thúc chỉnh sửa dòng

                // 4. Cập nhật vào CSDL
                if (da.Update(ds, "SanPham") > 0)
                {
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Cập nhật không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                LoadSanPham();
            }
        }

        // --- SỰ KIỆN 6: Nút Xoá ---
        private void btXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Xác nhận trước khi xóa
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Xác nhận Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.No) return;

                // 1. Tạo đối tượng cập nhật tự động
                cmd = new SqlCommandBuilder(da);

                // 2. Đánh dấu dòng hiện tại để xóa
                int pos = dgSanPham.CurrentRow.Index;
                ds.Tables["SanPham"].Rows[pos].Delete();

                // 3. Cập nhật vào CSDL
                if (da.Update(ds, "SanPham") > 0)
                {
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xóa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                LoadSanPham();
            }
        }

        // --- SỰ KIỆN 7: Form Closing ---
        private void BT9_FormClosing(object sender, FormClosingEventArgs e)
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
        private void dgSanPham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // 1. Kiểm tra xem người dùng có double click vào một dòng hợp lệ không
            if (e.RowIndex >= 0 && e.RowIndex < dgSanPham.Rows.Count - 1)
            {
                // 2. Gọi lại logic đổ dữ liệu từ RowEnter
                dgSanPham_RowEnter(sender, e);
            }
        }
    }
}
