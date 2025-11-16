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

namespace QLKTX_SV
{
    public partial class Quan_ly_thiet_bi_phong : Form
    {
        SqlConnection conn = DBConnect.GetConnection();
        SqlCommand cmd;
        DataTable tb;
        SqlDataAdapter ad;
        void LoadData()
        {
            cmd = new SqlCommand("SELECT * FROM QuanLyThietBiPhong", conn);
            ad = new SqlDataAdapter(cmd);
            tb = new DataTable();
            ad.Fill(tb);
            dgvQuanLyThietBiPhong.DataSource = tb;
        }
        void Xoa()
        {
            txtMaThietBi.Clear();
            txtTenThietBi.Clear();
            txtIDPhong.Clear();
            nudSoLuongHong.Value = 0;
            nudSoLuongThietBi.Value = 0;
            nudSoLuongToiDa.Value = 0;  
        }

       
        public Quan_ly_thiet_bi_phong()
        {
            InitializeComponent();
        }

        private void Quan_ly_thiet_bi_phong_Load(object sender, EventArgs e)
        {
            if (DBConnect.TestConnection())
            {
                MessageBox.Show("Kết nối cơ sở dữ liệu thành công!");
                LoadData();
            }

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnTimMaPhong_Click(object sender, EventArgs e)
        {

            if (txtTimIDPhong.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mã hóa đơn cần tìm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = DBConnect.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM QuanLyThietBiPhong WHERE IDPhong = @IDPhong";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@IDPhong", txtTimIDPhong.Text.Trim());

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        dgvQuanLyThietBiPhong.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy ID Phòng này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvQuanLyThietBiPhong.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        private void btnThem_Click(object sender, EventArgs e)

        {
            if(txtMaThietBi.Text == "" || txtTenThietBi.Text == "" || txtIDPhong.Text == "")
            {
                MessageBox.Show("Hãy nhập đầy đủ các thông tin","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;

            }
            if (nudSoLuongThietBi.Value <= 0)
            {
                MessageBox.Show("Số lượng thiết bị phải lớn hơn 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nudSoLuongToiDa.Value < nudSoLuongThietBi.Value)
            {
                MessageBox.Show("Số lượng tối đa không được nhỏ hơn số lượng thiết bị hiện có", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nudSoLuongHong.Value > nudSoLuongThietBi.Value)
            {
                MessageBox.Show("Số lượng hỏng không được vượt quá tổng số thiết bị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                using (SqlConnection conn = DBConnect.GetConnection())
                {
                    conn.Open();
                    string checkSql = "SELECT COUNT(*) FROM QuanLyThietBiPhong WHERE MaThietBi = @MaThietBi AND IDPhong = @IDPhong";
                    SqlCommand checkCmd = new SqlCommand(checkSql, conn);
                    checkCmd.Parameters.AddWithValue("@MaThietBi", txtMaThietBi.Text);
                    checkCmd.Parameters.AddWithValue("@IDPhong", txtIDPhong.Text);

                    int count = (int)checkCmd.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("Thiết bị này đã tồn tại trong phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    string sql = "INSERT INTO QuanLyThietBiPhong(MaThietBi, TenThietBi, IDPhong, SoLuongHong,SoLuongToiDa, SoLuongThietBi) VALUES(@MaThietBi, @TenThietBi, @IDPhong, @SoLuongHong, @SoLuongToiDa, @SoLuongThietBi)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@MaThietBi", txtMaThietBi.Text);
                    cmd.Parameters.AddWithValue("@TenThietBi", txtTenThietBi.Text);
                    cmd.Parameters.AddWithValue("@IDPhong", txtIDPhong.Text);
                    cmd.Parameters.AddWithValue("@SoLuongHong", nudSoLuongHong.Value);
                    cmd.Parameters.AddWithValue("@SoLuongToiDa", nudSoLuongToiDa.Value);
                    cmd.Parameters.AddWithValue("@SoLuongThietBi", nudSoLuongThietBi.Value);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Thêm thành công!");
                    Xoa();
                    LoadData();
                }

            }
            catch (Exception ex) {
                MessageBox.Show(" lỗi: "+ ex.Message);
            }
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaThietBi.Text))
                {
                    MessageBox.Show("Vui lòng nhập Mã thiết bị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (nudSoLuongThietBi.Value <= 0)
                {
                    MessageBox.Show("Số lượng thiết bị phải lớn hơn 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (nudSoLuongToiDa.Value < nudSoLuongThietBi.Value)
                {
                    MessageBox.Show("Số lượng tối đa không được nhỏ hơn số lượng hiện có!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection conn = DBConnect.GetConnection())
                {
                    conn.Open();

                    string sql = @"UPDATE QuanLyThietBiPhong SET TenThietBi = @TenThietBi, SoLuongThietBi = @SoLuongThietBi, SoLuongToiDa = @SoLuongToiDa, SoLuongHong = @SoLuongHong WHERE MaThietBi = @MaThietBi AND IDPhong = @IDPhong";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@MaThietBi", txtMaThietBi.Text);
                    cmd.Parameters.AddWithValue("@TenThietBi", txtTenThietBi.Text);
                    cmd.Parameters.AddWithValue("@IDPhong", txtIDPhong.Text);
                    cmd.Parameters.AddWithValue("@SoLuongThietBi", nudSoLuongThietBi.Value);
                    cmd.Parameters.AddWithValue("@SoLuongToiDa", nudSoLuongToiDa.Value);
                    cmd.Parameters.AddWithValue("@SoLuongHong", nudSoLuongHong.Value);


                    int kt = cmd.ExecuteNonQuery();
                    if (kt > 0)
                    {
                        MessageBox.Show("Sửa dữ liệu thành công!");
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thiết bị để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtTimMaPhong_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtHoVaTen_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnQuanLyThietBi_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {

        }

        private void cmbSoPhong_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnQuanLyNhanVien_Click(object sender, EventArgs e)
        {

        }

        private void nudThietBiToiDa_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtMSSV_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnQuanLyPhong_Click(object sender, EventArgs e)
        {

        }

        private void btnQuanLyToaNha_Click(object sender, EventArgs e)
        {

        }

        private void nudSoLuongThietBi_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void nudThietBiHong_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnQuanLySinhVien_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (txtMaThietBi.Text == "" || txtIDPhong.Text == "")
            {
                MessageBox.Show("Vui lòng nhập Mã thiết bị và ID phòng cần xóa!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = DBConnect.GetConnection())
                {
                    conn.Open();

                    string sql = "DELETE FROM QuanLyThietBiPhong WHERE MaThietBi = @MaThietBi AND IDPhong = @IDPhong";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@MaThietBi", txtMaThietBi.Text);
                    cmd.Parameters.AddWithValue("@IDPhong", txtIDPhong.Text);

                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Xoa();
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thiết bị để xóa. Vui lòng kiểm tra lại!",
                                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
