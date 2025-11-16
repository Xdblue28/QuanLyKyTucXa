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
    public partial class Form1 : Form
    {
        DataTable originalTable;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        Modify modify = new Modify();
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                originalTable = modify.Table("SELECT * FROM QuanLyPhong");
                guna2DataGridView1.DataSource = originalTable;
                guna2DataGridView1.Columns["MaPhong"].HeaderText = "Mã phòng";
                guna2DataGridView1.Columns["TenPhong"].HeaderText = "Tên phòng";
                guna2DataGridView1.Columns["SLSVHienTai"].HeaderText = "Số lượng sinh viên hiện tại";
                guna2DataGridView1.Columns["SLSVToiDa"].HeaderText = "Số lượng sinh viên tối đa";
                guna2DataGridView1.Columns["TinhTrangPhong"].HeaderText = "Hoạt động";
                foreach (DataGridViewColumn column in guna2DataGridView1.Columns)
                {
                    // Chế độ này: tắt nhấn header, nhưng cho phép code Sort()
                    column.SortMode = DataGridViewColumnSortMode.Programmatic;
                }
            }
            catch(Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            string name = guna2TextBox1.Text.Trim();
            if (name== "")
            {
                Form1_Load(sender, e);
            }
            else
            {
                string query = "SELECT * FROM QuanLyPhong WHERE MaPhong LIKE '%" + name + "%'";
                guna2DataGridView1.DataSource = modify.Table(query);
            }
        }

        private void guna2HtmlLabel1_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = guna2ComboBox1.SelectedItem.ToString();

            if (selected == "Giảm dần")
            {
                DataTable reversedTable = originalTable.Clone(); // tạo clone cung cau truc
                for (int i = originalTable.Rows.Count - 1; i >= 0; i--)
                {
                    reversedTable.ImportRow(originalTable.Rows[i]);//Them tung dong cua bang goc van bang moi tu duoi len
                }

                guna2DataGridView1.DataSource = reversedTable;//Hien thi bang
            }
            else if (selected == "Tăng dần")
            {
                guna2DataGridView1.DataSource = originalTable;
            }
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
   
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            FormThem formThem = new FormThem();
            formThem.ShowDialog();
            Form1_Load(sender, e );
        }

        private void guna2DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string maPhong = guna2DataGridView1.Rows[e.RowIndex].Cells["MaPhong"].Value.ToString();
            FormSua formSua = new FormSua(maPhong);
            formSua.ShowDialog();
            Form1_Load(sender, e );
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.Rows.Count < 1)
            {
                MessageBox.Show("Vui lòng chọn phòng cần xóa!");
            }
            else
            {
                string choose = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string query = "DELETE QuanLyPhong WHERE MaPhong = '" + choose + "'";
                try
                {
                    if (MessageBox.Show("Bạn chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        modify.Table(query);
                        MessageBox.Show("Xóa thành công!");
                        Form1_Load(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa!");
                }
            }
        }
    }
}
