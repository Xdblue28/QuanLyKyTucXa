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

namespace quanlysinhvien
{
    public partial class FormQuanLyTraPhong : Form
    {
        public FormQuanLyTraPhong()
        {
            InitializeComponent();
        }

        private String connectString = @"Data Source=localhost;Initial Catalog=Quanlykytucxa;User ID=sa;Password=123";
        private void FormQuanLyTraPhong_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connectString);
            SqlDataAdapter da = new SqlDataAdapter("select * from Traphong",conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvDanhSachNguoiTraPhong.DataSource = dt;
            conn.Close();
        }
    }
}
