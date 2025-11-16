using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlysinhvien
{
    public partial class FrmSuaThongTinSinhVien : Form
    {
        public FrmSuaThongTinSinhVien()
        {
            InitializeComponent();
        }
        private String connectionString = @"Data Source=localhost;Initial Catalog=Quanlykytucxa;User ID=sa;Password=123";

        private void btnThemAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images files|*.jpg;*.jpeg;*png;*.bmp;*.gif";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                picAvatar.Image = new Bitmap(ofd.FileName);
            }
        }
        private bool ValidateInput()
        {
            if (String.IsNullOrWhiteSpace(txtMaSV.Text))
            {
                MessageBox.Show("Mã sinh viên không được để trống!");
                txtMaSV.Focus();
                return false;
            }

            if (String.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Họ và tên không được để trống!");
                txtHoTen.Focus();
                return false;
            }


            if (String.IsNullOrWhiteSpace(txtSDT.Text))
            {
                MessageBox.Show("Số điện thoại không được để trống!");
                txtSDT.Focus();
                return false;
            }
            else
            {
                Regex regSDT = new Regex(@"^(0|\+84)\d{9,10}$");
                if (!regSDT.IsMatch(txtSDT.Text.ToString()))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ!");
                    txtSDT.Focus();
                    return false;
                }
            }


            if (String.IsNullOrWhiteSpace(txtGmail.Text))
            {
                MessageBox.Show("Gmail không được để trống!");
                txtGmail.Focus();
                return false;
            }
            else
            {
                Regex regGmail = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-z0-9.-]+\.[a-zA-z]{2,}$");
                if (!regGmail.IsMatch(txtGmail.Text.ToString()))
                {
                    MessageBox.Show("Địa chỉ email không hợp lệ!");
                    txtGmail.Focus();
                    return false;
                }
            }


            if (cbGioiTinh.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn giới tính!");
                cbGioiTinh.Focus();
                return false;
            }


            if (dtpNgaySinh.Value >= DateTime.Now)
            {
                MessageBox.Show("Ngày sinh không hợp lệ!");
                dtpNgaySinh.Focus();
                return false;
            }


            if (String.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show("Địa chỉ không được để trống!");
                txtDiaChi.Focus();
                return false;
            }


            if (String.IsNullOrWhiteSpace(txtCCCD.Text))
            {
                MessageBox.Show("CCCD không được để trống!");
                txtCCCD.Focus();
                return false;
            }
            else
            {
                Regex regCCCD = new Regex(@"^\d{12}$");
                if (!regCCCD.IsMatch(txtCCCD.Text.ToString()))
                {
                    MessageBox.Show("CCCD phải có 12 số!");
                    txtCCCD.Focus();
                    return false;
                }
            }


            if (dtpNgayLamHD.Value.Date > dtpNgayKetThucHD.Value.Date)
            {
                MessageBox.Show("Ngày làm hợp đồng phải nhỏ hơn hoặc bằng ngày kết thúc hợp đồng!");
                dtpNgayLamHD.Focus();
                return false;
            }


            if (cbPhong.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn mã phòng!");
                cbPhong.Focus();
                return false;
            }

            return true;
        }
        private void LoadData()
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Quanlysinhvien", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dt.Columns.Remove("Anh");
                dgvThongTinSinhVien.DataSource = dt;
                conn.Close();

            }
            catch(SqlException ex)
            {
                MessageBox.Show("Không kết nối được tới cơ sở dữ liệu. Lỗi: " + ex.Message);
            }
        }

        private void FrmSuaThongTinSinhVien_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnTImKiem_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                SqlDataAdapter da = new SqlDataAdapter($"SELECT * FROM Quanlysinhvien WHERE Masv LIKE '{txtTimKiemMaSV.Text.ToString()}'", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dt.Columns.Remove("Anh");
                dgvThongTinSinhVien.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm sinh viên."+ex.Message);
            }
        }

        private void dgvThongTinSinhVien_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                txtMaSV.Text = dgvThongTinSinhVien.CurrentRow.Cells["Masv"].Value.ToString();
                txtHoTen.Text = dgvThongTinSinhVien.CurrentRow.Cells["Hovaten"].Value.ToString();
                txtSDT.Text = dgvThongTinSinhVien.CurrentRow.Cells["SDT"].Value.ToString();
                txtGmail.Text = dgvThongTinSinhVien.CurrentRow.Cells["Gmail"].Value.ToString();
                cbGioiTinh.Text = dgvThongTinSinhVien.CurrentRow.Cells["Gioitinh"].Value.ToString();
                dtpNgaySinh.Value = Convert.ToDateTime(dgvThongTinSinhVien.CurrentRow.Cells["Ngaysinh"].Value.ToString());
                txtDiaChi.Text = dgvThongTinSinhVien.CurrentRow.Cells["Diachi"].Value.ToString();
                dtpNgayLamHD.Value = Convert.ToDateTime(dgvThongTinSinhVien.CurrentRow.Cells["Ngaylamhopdong"].Value.ToString());
                dtpNgayKetThucHD.Value = Convert.ToDateTime(dgvThongTinSinhVien.CurrentRow.Cells["Ngayketthuchopdong"].Value.ToString());
                cbPhong.Text = dgvThongTinSinhVien.CurrentRow.Cells["Maphong"].Value.ToString();
                txtCCCD.Text = dgvThongTinSinhVien.CurrentRow.Cells["CCCD"].Value.ToString();
                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("SELECT Anh FROM Quanlysinhvien WHERE Masv = @MSSV", conn);
                cmd.Parameters.AddWithValue("@MSSV", txtMaSV.Text.ToString());
                conn.Open();
                byte[] anh = cmd.ExecuteScalar() as byte[];
                picAvatar.Image = ByteToImage(anh);
                conn.Close();
            }catch(SqlException ex)
            {
                MessageBox.Show("Lỗi kết nối tới cơ sở dữ liệu."+ex.Message);
            }catch(FormatException fex)
            {
                MessageBox.Show("Lỗi định dạng");
            }
            
        }
        private Image ByteToImage(byte[] anh)
        {
            if(anh == null || anh.Length == 0)
            {
                return null;
            }
            using (MemoryStream ms = new MemoryStream(anh))
            {
                using (Image image = Image.FromStream(ms))
                {
                    return Image.FromStream(ms);
                }
                    
            }
        }
        private byte[] ImageToByte(Image image)
        {
            if(image == null)
            {
                return null;
            }
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if(dgvThongTinSinhVien.CurrentRow!= null)
            {
                try {
                    if(ValidateInput() == false)
                    {
                        MessageBox.Show("Vui lòng kiểm tra lại thông tin nhập vào.");
                        return;
                    }
                    SqlConnection conn = new SqlConnection(connectionString);
                    SqlCommand cmd = new SqlCommand("UPDATE Quanlysinhvien SET Hovaten=@HoTen,SDT=@SDT,Gmail=@Gmail,Gioitinh=@GioiTinh,Ngaysinh=@NgaySinh,Diachi=@DiaChi,Ngaylamhopdong=@NgayLamHD,Ngayketthuchopdong=@NgayKetThucHD,Maphong=@MaPhong,CCCD=@CCCD,Anh=@Anh WHERE Masv=@MaSV", conn);
                    cmd.Parameters.AddWithValue("@MaSV", txtMaSV.Text.ToString());
                    cmd.Parameters.AddWithValue("@HoTen", txtHoTen.Text.ToString());
                    cmd.Parameters.AddWithValue("@SDT", txtSDT.Text.ToString());
                    cmd.Parameters.AddWithValue("@Gmail", txtGmail.Text.ToString());
                    cmd.Parameters.AddWithValue("@GioiTinh", cbGioiTinh.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value);
                    cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text.ToString());
                    cmd.Parameters.AddWithValue("@NgayLamHD", dtpNgayLamHD.Value);
                    cmd.Parameters.AddWithValue("@NgayKetThucHD", dtpNgayKetThucHD.Value);
                    cmd.Parameters.AddWithValue("@MaPhong", cbPhong.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@CCCD", txtCCCD.Text.ToString());
                    // Convert image to byte array
                    byte[] anh = ImageToByte(picAvatar.Image);
                    cmd.Parameters.AddWithValue("@Anh", anh);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật thông tin sinh viên thành công.");
                        
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thông tin sinh viên thất bại.");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Loi" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if(dgvThongTinSinhVien.CurrentRow == null || ValidateInput()==false)
                {
                    MessageBox.Show("Vui lòng chọn sinh viên để xóa.");
                    return;
                }
                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("DELETE FROM Quanlysinhvien WHERE Masv = @MSSV",conn);
                cmd.Parameters.AddWithValue("@MSSV", txtMaSV.Text.ToString());
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                LoadData();
                MessageBox.Show("Xóa sinh viên thành công.");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi xóa sinh viên."+ex.Message);
            }
        }

        private void btnHuyHD_Click(object sender, EventArgs e)
        {
            try
            {
                if(dgvThongTinSinhVien.CurrentRow == null || ValidateInput()==false)
                {
                    MessageBox.Show("Vui lòng chọn sinh viên để hủy hợp đồng.");
                    return;
                }
                if(dgvThongTinSinhVien.CurrentRow.Cells["Maphong"].Value.ToString().Trim() == "")
                {
                    MessageBox.Show("Sinh viên này chưa có hợp đồng thuê phòng.");
                    return;
                }
                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("UPDATE Quanlysinhvien SET Ngayketthuchopdong = @DateNow,Maphong =' '",conn);
                DateTime getNow = DateTime.Now;
                cmd.Parameters.AddWithValue("@DateNow", getNow);
                conn.Open();
                cmd.ExecuteNonQuery();
                SqlCommand cmd2 = new SqlCommand("INSERT INTO Traphong VALUES(@HOVATEN,@SDT,@GMAIL,@CCCD,@MAPHONG)",conn);
                cmd2.Parameters.AddWithValue("@HOVATEN", txtHoTen.Text.ToString());
                cmd2.Parameters.AddWithValue("@SDT", txtSDT.Text.ToString());
                cmd2.Parameters.AddWithValue("@GMAIL", txtGmail.Text.ToString());
                cmd2.Parameters.AddWithValue("@CCCD", txtCCCD.Text.ToString());
                cmd2.Parameters.AddWithValue("@MAPHONG", cbPhong.SelectedItem.ToString());
                cmd2.ExecuteNonQuery();
                conn.Close();
                LoadData();
                MessageBox.Show("Hủy hợp đồng thành công.");
                
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Lỗi kết nối tới cơ sở dữ liệu"+ex.Message);
            }
        }
    }
}
