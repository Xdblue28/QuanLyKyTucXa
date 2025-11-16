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
    public partial class FormThem : Form
    {
        QuanLyPhong ql;
        Modify modify = new Modify();
        public FormThem()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormThem_Load(object sender, EventArgs e)
        {
            txtMa.Text = "";
            txtTen.Text = "";
            Box1.SelectedIndex = -1;
            CBox1.Checked = true;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            String Ma = txtMa.Text;
            try
            {
                if (Ma.Length != 4)
                {
                    MessageBox.Show("Vui lòng nhập đủ 4 kí tự!");
                    txtMa.Text = "";
                    return;
                }

                String Phong = txtTen.Text;
                if (Phong == null)
                {
                    MessageBox.Show("Vui lòng không để trống thông tin!");
                    return;
                }
                if (Box1.SelectedIndex == -1 && CBox1.Checked == true)
                {
                    MessageBox.Show("Vui lòng không để trống thông tin!");
                    return;
                }
                int Sl = 0;
                if (CBox1.Checked == true)
                {
                    Sl = int.Parse(Box1.Text);
                }
                int Slmax = 0;
                if (txtToiDa != null)
                {
                    Slmax = int.Parse(txtToiDa.Text);
                }
                bool TT = CBox1.Checked;

                ql = new QuanLyPhong(Ma, Phong, Sl, Slmax, TT);
                int TT1 = ql.HD ? 1 : 0;
                String query = ("INSERT INTO QuanLyPhong VALUES ('" + ql.MaPhong + "',N'" + ql.TenPhong + "'," + ql.SoLuong + "," + ql.SoLuongMax + "," + TT1 + ")");

                modify.Command(query);
                MessageBox.Show("Thêm thành công!");
                guna2Button2_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: "+ex.Message);
                guna2Button2_Click(sender, e);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            txtMa.Text = "";
            txtTen.Text = "";
            Box1.SelectedIndex = -1;
            CBox1.Checked = true;
        }

        private void CBox1_CheckedChanged(object sender, EventArgs e)
        {
            LoadSoLuongHienTai();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            LoadSoLuongHienTai();
        }
        private void LoadSoLuongHienTai()
        {
            int max;

            Box1.Items.Clear();

            if (!int.TryParse(txtToiDa.Text, out max) || max < 0)
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

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
