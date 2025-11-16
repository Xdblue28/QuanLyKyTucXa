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

namespace QLKTX_SV
{
    public partial class Quan_ly_hoa_don_dien_nuoc : Form
    {

        SqlConnection conn = DBConnect.GetConnection();
        SqlCommand cmd;
        SqlDataAdapter ad;
        DataTable dt;
        void LoadData()
        {
            cmd = new SqlCommand("SELECT * FROM HoaDonDienNuoc", conn);
            ad = new SqlDataAdapter(cmd);
            dt = new DataTable();
            ad.Fill(dt);
            dgvHoaDonDienNuoc.DataSource = dt;
            dgvHoaDonDienNuoc.ClearSelection();
            dgvHoaDonDienNuoc.CurrentCell = null;
        }
        void Xoa()
        {
            txtMaHoaDon.Clear();
            txtTenHoaDon.Clear();
            txtTienDien.Clear();
            txtTienNuoc.Clear();
            txtIDPhong.Clear();
            cmbTinhTrangHoaDon.SelectedIndex = 0;
            NgayTaoHoaDon.Value = DateTime.Now;

            

        }
        public Quan_ly_hoa_don_dien_nuoc()
        {

            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Quan_ly_hoa_don_dien_nuoc_Load(object sender, EventArgs e)
        {
           // if (DBConnect.TestConnection())
            
              //  MessageBox.Show("Kết nối cơ sở dữ liệu thành công!");
                LoadData();
            
            cmbTinhTrangHoaDon.Items.Clear();
            cmbTinhTrangHoaDon.Items.Add("Đã thanh toán");
            cmbTinhTrangHoaDon.Items.Add("Chưa thanh toán");
            cmbTinhTrangHoaDon.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTinhTrangHoaDon.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtIDPhong.Text == "" || txtMaHoaDon.Text == "" || txtTenHoaDon.Text == "" || txtTienDien.Text == "" || txtTienNuoc.Text == "" || cmbTinhTrangHoaDon.Text == "")
            {
                MessageBox.Show("Nhập đầy đủ các thông tin");
                return;
            }
            try
            {
                using (SqlConnection conn = DBConnect.GetConnection())
                {
                    conn.Open();
                    string check = @"SELECT COUNT (*) FROM HoaDonDienNuoc WHERE MaHoaDon = @MaHoaDon";
                    SqlCommand cmdCheck = new SqlCommand(check, conn);
                    cmdCheck.Parameters.AddWithValue("@MaHoaDon", txtMaHoaDon.Text);
                    int dem = (int)cmdCheck.ExecuteScalar();
                    if(dem > 0)
                    {
                        MessageBox.Show("Trùng hóa đơn kh thêm đc", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    }
                    else
                    {
                        string sql = "INSERT INTO HoaDonDienNuoc(MaHoaDon, TenHoaDon, TienDien, TienNuoc, NgayTaoHoaDon, IDPhong, TinhTrangHoaDon)VALUES(@MaHoaDon,@TenHoaDon, @TienDien, @TienNuoc, @NgayTaoHoaDon, @IDPhong, @TinhTrangHoaDon)";
                        SqlCommand cmd = new SqlCommand(sql,conn);
                        cmd.Parameters.AddWithValue("@MaHoaDon", txtMaHoaDon.Text.Trim());
                        cmd.Parameters.AddWithValue("@TenHoaDon", txtTenHoaDon.Text.Trim());
                        cmd.Parameters.AddWithValue("@TienDien", decimal.Parse(txtTienDien.Text.Trim()));
                        cmd.Parameters.AddWithValue("@TienNuoc", decimal.Parse(txtTienNuoc.Text.Trim()));
                        cmd.Parameters.AddWithValue("@NgayTaoHoaDon", NgayTaoHoaDon.Value.Date);
                        cmd.Parameters.AddWithValue("@IDPhong", txtIDPhong.Text.Trim());
                        cmd.Parameters.AddWithValue("@TinhTrangHoaDon", cmbTinhTrangHoaDon.SelectedItem.ToString());
                        int row = cmd.ExecuteNonQuery();
                        if (row > 0) { 
                            MessageBox.Show("Thêm Thành Công!!!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            Xoa();
                            LoadData();

                        }
                    }


                }
            }
            catch (FormatException)

            {
                MessageBox.Show("Lỗi Nhập Tiền Điện Hoặc Tiền Nước", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi: ",ex.Message);
            }
        }

        private void cmbTinhTrangHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                using(SqlConnection conn = DBConnect.GetConnection())
                {
                    conn.Open();
                    string sql = @"DELETE FROM HoaDonDienNuoc WHERE MaHoaDon = @MaHoaDon";
                    SqlCommand cmd = new SqlCommand(sql,conn);
                    cmd.Parameters.AddWithValue("@MaHoaDon",txtMaHoaDon.Text.Trim());
                    int row = cmd.ExecuteNonQuery();
                    if (row > 0)
                    {
                        MessageBox.Show("Xóa Thành Công");
                        Xoa();
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy hóa đơn này để xóa","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    }
                }

            }
            catch (Exception ex) { 
                MessageBox.Show("Lỗi: " +  ex.Message);

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if(txtMaHoaDon.Text == "")
            {
                MessageBox.Show("Hãy nhập mã hóa đơn cần sửa","Thông Báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                using (SqlConnection conn = DBConnect.GetConnection())
                {
                    conn.Open();
                    string oldMaHoaDon = txtMaHoaDon.Text.Trim();
                    string sql = @"UPDATE HoaDonDienNuoc SET MaHoaDon = @MaHoaDon, TenHoaDon = @TenHoaDon, TienDien = @TienDien, TienNuoc =@TienNuoc, NgayTaoHoaDon = @NgayTaoHoaDon, MaPhong =@MaPhong, TinhTrangHoaDon = @TinhTrangHoaDon WHERE MaHoaDon = @OldMaHoaDon";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@MaHoaDon", txtMaHoaDon.Text.Trim());
                    cmd.Parameters.AddWithValue("@TenHoaDon", txtTenHoaDon.Text.Trim());
                    cmd.Parameters.AddWithValue("@TienDien", decimal.Parse(txtTienDien.Text.Trim()));
                    cmd.Parameters.AddWithValue("@TienNuoc", decimal.Parse(txtTienNuoc.Text.Trim()));
                    cmd.Parameters.AddWithValue("@NgayTaoHoaDon", NgayTaoHoaDon.Value.Date);
                    cmd.Parameters.AddWithValue("@MaPhong", txtIDPhong.Text.Trim());
                    cmd.Parameters.AddWithValue("@TinhTrangHoaDon", cmbTinhTrangHoaDon.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@OldMaHoaDon", oldMaHoaDon);
                    int kt = cmd.ExecuteNonQuery();
                    if (kt > 0)
                    {
                        MessageBox.Show("Sửa Thành Công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Xoa();
                        LoadData();

                    }
                    else
                    {
                        MessageBox.Show("Sửa Thất bại");
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show("Lỗi ơ: " + ex.Message); 
            }
            }

        private void btnTimMaPhong_Click(object sender, EventArgs e)
        {
             

            if (txtTimIDPhong.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mã phòng cần tìm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = DBConnect.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM HoaDonDienNuoc WHERE RTRIM(MaPhong) = @MaPhong";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@MaPhong", txtTimIDPhong.Text.Trim());

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        dgvHoaDonDienNuoc.DataSource = dt;
                        dgvHoaDonDienNuoc.ClearSelection();
                        dgvHoaDonDienNuoc.CurrentCell = null;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy phòng có mã này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvHoaDonDienNuoc.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTienNuoc_TextChanged(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }
    }
    }

