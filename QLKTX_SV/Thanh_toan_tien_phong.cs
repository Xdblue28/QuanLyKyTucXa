using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKTX_SV
{
    public partial class Thanh_toan_tien_phong : Form
    {
        SqlConnection conn = DBConnect.GetConnection();
        SqlCommand cmd;
        SqlDataAdapter ad;
        DataTable dt;
        
        bool ktGmail(string Gmail)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(Gmail, pattern);
        }

        bool ktSDT(string SDT)
        {
            string pattern = @"^[0-9]{10}$";
            return Regex.IsMatch(SDT, pattern);
        }
        bool ktCCCD(string cccd)
        {
            string pattern = @"^[0-9]{12}$";
            return Regex.IsMatch(cccd, pattern);
        }
        public Thanh_toan_tien_phong()
        {
            InitializeComponent();

        }
        void LoadData()
        {
            cmd = new SqlCommand("SELECT * FROM TienPhong", conn);
            ad = new SqlDataAdapter(cmd);
            dt = new DataTable();
            ad.Fill(dt);
            dgvThanhToan.DataSource = dt;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           // if (DBConnect.TestConnection())
             //   MessageBox.Show("Kết nối CSDL thành công!");


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txtDiaChi_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {


        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaSinhVien.Text.Trim() == "" )
                {
                    MessageBox.Show("Vui lòng nhập Mã sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtSoTienThanhToan.Text.Trim() == "")
                {
                    MessageBox.Show("Vui lòng nhập số tiền thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!ktGmail(txtGmail.Text.Trim()))
                {
                    MessageBox.Show("Email không đúng định dạng", "Lỗi");
                    return;
                }

                if (!ktSDT(txtSDT.Text.Trim()))
                {
                    MessageBox.Show("Số điện thoại phải đúng 10 số", "Lỗi");
                    return;
                }
                if (!ktCCCD(txtCCCD.Text.Trim()))
                {
                    MessageBox.Show("CCCD phải gồm 12 số", "Lỗi");
                    return;
                }

                using (SqlConnection conn = DBConnect.GetConnection())
                {
                    conn.Open();

                    string checkSql = @"SELECT COUNT (*) FROM TienPhong WHERE Masv = @Masv AND MONTH(Ngay) = MONTH(@Ngay)  AND YEAR(Ngay) = YEAR(@Ngay)";

                    SqlCommand cm = new SqlCommand(checkSql, conn);
                    cm.Parameters.AddWithValue("@Masv", txtMaSinhVien.Text.Trim());
                    cm.Parameters.AddWithValue("@Ngay", dateThanhToan.Value.Date);
                    int kt = (int)cm.ExecuteScalar();
                    if (kt > 0)
                    {
                        MessageBox.Show("Sinh viên đã thanh toán tháng này rồi", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string sql = @"INSERT INTO TienPhong (Masv, HoTen, SDT, Gmail, DiaChi, CCCD, MaPhong, Ngay, TienThanhToan)VALUES  (@Masv, @HoTen, @SDT, @Gmail, @DiaChi, @CCCD, @MaPhong, @Ngay, @TienThanhToan)";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Masv", txtMaSinhVien.Text);
                        cmd.Parameters.AddWithValue("@HoTen", txtHoVaTen.Text);
                        cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);
                        cmd.Parameters.AddWithValue("@Gmail", txtGmail.Text);
                        cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                        cmd.Parameters.AddWithValue("@CCCD", txtCCCD.Text);
                        cmd.Parameters.AddWithValue("@IDPhong", txtIDPhong.Text);
                        cmd.Parameters.AddWithValue("@Ngay", dateThanhToan.Value.Date);
                        try
                        {
                            decimal tien = decimal.Parse(txtSoTienThanhToan.Text.Trim());
                            cmd.Parameters.AddWithValue("@TienThanhToan", tien);
                        }
                        catch
                        {
                            MessageBox.Show("Số tiền không hợp lệ vui lòng nhập lại","Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("✅ Xác nhận thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xác nhận: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMaSinhVien.Clear();
            txtMSSV.Clear();
            txtHoVaTen.Clear();
            txtSDT.Clear();
            txtGmail.Clear();
            txtDiaChi.Clear();
            txtCCCD.Clear();
            txtSoTienThanhToan.Clear();
            txtIDPhong.Clear();
            dateThanhToan.Value = DateTime.Now;
        }

        private void btnTimKiem_Click_2(object sender, EventArgs e)
        {
            try
            {

                using (SqlConnection conn = DBConnect.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM TienPhong WHERE Masv = @Masv";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Masv", txtMaSinhVien.Text);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        // dgvThanhToan.DataSource = dt;
                        DataRow dr = dt.Rows[0];
                        txtMSSV.Text = dr["Masv"].ToString();
                        txtHoVaTen.Text = dr["HoTen"].ToString();
                        txtSDT.Text = dr["SDT"].ToString();
                        txtGmail.Text = dr["Gmail"].ToString();
                        txtDiaChi.Text = dr["DiaChi"].ToString();
                        txtCCCD.Text = dr["CCCD"].ToString();
                        txtIDPhong.Text = dr["MaPhong"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sinh viên có mã này!");
                        // dgvThanhToan.DataSource = null;
                        txtMSSV.Clear();
                        txtHoVaTen.Clear();
                        txtSDT.Clear();
                        txtGmail.Clear();
                        txtDiaChi.Clear();
                        txtCCCD.Clear();
                        txtIDPhong.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtSoTienThanhToan_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}

