using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhong1
{
    public partial class FormSua : Form
    {
        Modify modify = new Modify();
        private string maPhongCanSua;
        public FormSua(String maPhong)
        {
            InitializeComponent();
            this.maPhongCanSua= maPhong;
        }

        private void FormSua_Load(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT * FROM QuanLyPhong WHERE MaPhong = '" + this.maPhongCanSua + "'";
                DataTable dt = modify.Table(query);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    txtMa.Text = row["MaPhong"].ToString();
                    txtTen.Text = row["TenPhong"].ToString();
                    txtMax.Text = row["SLSVToiDa"].ToString();
                    CBox1.Checked = (bool)row["TinhTrangPhong"];
                    LoadSoLuongHienTai();
                    Box1.Text = row["SLSVHienTai"].ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
                this.Close(); // Đóng form nếu tải lỗi
            }
            ToggleEditMode(false);
        }
        private void ToggleEditMode(bool isEditable)
        {
            // Khóa/Mở khóa các control
            txtTen.ReadOnly = !isEditable;
            Box1.Enabled = isEditable && CBox1.Checked;
            CBox1.Enabled = isEditable;
            txtMax.ReadOnly = !isEditable;
            // (Mã phòng LUÔN LUÔN khóa)
            txtMa.ReadOnly = true;

            // Ẩn/Hiện các nút
            btnSua.Visible = !isEditable; // Nút "Sửa" chỉ hiện khi KHÔNG SỬA
            btnLuu.Visible = isEditable;       // Nút "Lưu" chỉ hiện khi ĐANG SỬA
                                               // btnHuy.Visible = isEditable;    // Nút "Hủy" cũng chỉ hiện khi ĐANG SỬA

           
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            ToggleEditMode(true);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string tenMoi = txtTen.Text;
            int sLTD = 0;
            if (txtMax.Text != null)
            {
                sLTD= int.Parse(txtMax.Text);
            }
            int soLuongMoi = 0;
            if(Box1.Text!="")
            {
                soLuongMoi =int.Parse(Box1.Text); //khong nhan null 
            }
            int trangThaiMoi = CBox1.Checked ? 1 : 0;

            string query = "UPDATE QuanLyPhong SET " +
                           "TenPhong = N'" + tenMoi + "', " +
                           "SLSVHienTai = " + soLuongMoi + ", " +
                           "SLSVToiDa = " +sLTD +","+
                           "TinhTrangPhong = " + trangThaiMoi + " " +
                           "WHERE MaPhong = '" + this.maPhongCanSua + "'";

            // 3. Thực thi
            try
            {
                modify.Command(query);
                MessageBox.Show("Cập nhật thành công!");
                this.Close(); // Đóng form sau khi cập nhật
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật: " + ex.Message);
            }
        }

        private void CBox1_CheckedChanged(object sender, EventArgs e)
        {
            LoadSoLuongHienTai();
        }
        private void LoadSoLuongHienTai()
        {
            int max;

            Box1.Items.Clear();

            if (!int.TryParse(txtMax.Text, out max) || max < 0)
                return;

            for (int i = 0; i <= max; i++)
            {
                Box1.Items.Add(i.ToString());
            }

            if (!CBox1.Checked)    // Nếu phòng không hoạt động → disable
            {
                Box1.SelectedIndex = -1;
                Box1.Enabled = false;
            }
            else
            {
                Box1.Enabled = true;
            }

        }

        private void txtMax_TextChanged(object sender, EventArgs e)
        {
            LoadSoLuongHienTai();
        }
    }
}
