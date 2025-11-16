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
    public partial class FrmThemThongTinSinhVien : Form
    {
        public FrmThemThongTinSinhVien()
        {
            InitializeComponent();
        }
        private String connectionString = @"Data Source=localhost;Initial Catalog=Quanlykytucxa;User ID=sa;Password=123";

       
        private bool ValidateInput()
        {
            if(String.IsNullOrWhiteSpace(txtMaSV.Text))
            {
                MessageBox.Show("Mã sinh viên không được để trống!");
                txtMaSV.Focus();
                return false;
            }
            else
            {
                Regex regMssv = new Regex(@"^\d+$");
                if (!regMssv.IsMatch(txtMaSV.Text.ToString()))
                {
                    MessageBox.Show("Mã sinh viên chỉ được chứa chữ số!");
                    txtMaSV.Focus();
                    return false;
                }
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
                Regex regGmail = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
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
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=Quanlykytucxa;User ID=sa;Password=123");
                SqlCommand cmd = new SqlCommand("INSERT INTO Quanlysinhvien VALUES(@MSSV,@HOVATEN,@SODIENTHOAI,@GMAIL,@GIOITINH,@NGAYSINH,@DIACHI,@CCCD,@NGAYLAMHD,@NGAYKETTHUCHD,@MAPHONG,@ANH)", conn);
                cmd.Parameters.AddWithValue("@MSSV", txtMaSV.Text.ToString());
                cmd.Parameters.AddWithValue("@HOVATEN", txtHoTen.Text.ToString());
                cmd.Parameters.AddWithValue("@SODIENTHOAI", txtSDT.Text.ToString());
                cmd.Parameters.AddWithValue("@GMAIL", txtGmail.Text.ToString());
                cmd.Parameters.AddWithValue("@GIOITINH", cbGioiTinh.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@NGAYSINH", dtpNgaySinh.Value);
                cmd.Parameters.AddWithValue("@DIACHI", txtDiaChi.Text.ToString());
                cmd.Parameters.AddWithValue("@CCCD", txtCCCD.Text.ToString());
                cmd.Parameters.AddWithValue("@NGAYLAMHD", dtpNgayLamHD.Value);
                cmd.Parameters.AddWithValue("@NGAYKETTHUCHD", dtpNgayKetThucHD.Value);
                cmd.Parameters.AddWithValue("@MAPHONG", cbPhong.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@ANH", ImagetoByte(picAvatar.Image));
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm sinh viên thành công!");
                conn.Close();
            }
        }

        private void btnThemAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                picAvatar.Image = new Bitmap(openFileDialog.FileName);
            }
        }
        private byte[] ImagetoByte(Image image)
        {
            using(MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtMaSV.Text= "";
            txtHoTen.Text= "";
            txtSDT.Text= "";
            txtGmail.Text= "";
            cbGioiTinh.SelectedItem= null;
            dtpNgaySinh.Value= DateTime.Now;
            txtDiaChi.Text= "";
            txtCCCD.Text= "";
            dtpNgayLamHD.Value= DateTime.Now;
            dtpNgayKetThucHD.Value= DateTime.Now;
            cbPhong.SelectedItem= null;
            picAvatar.Image= null;
        }

        private void FrmThemThongTinSinhVien_Load(object sender, EventArgs e)
        {

        }

    }
}
