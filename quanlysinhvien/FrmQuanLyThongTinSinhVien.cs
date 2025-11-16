using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlysinhvien
{
    public partial class FrmQuanLyThongTinSinhVien : Form
    {
        public FrmQuanLyThongTinSinhVien()
        {
            InitializeComponent();
        }

        private void btnThemSinhVien_Click(object sender, EventArgs e)
        {
            pnThemSua.Controls.Clear();
            FrmThemThongTinSinhVien frmThemThongTinSinhVien = new FrmThemThongTinSinhVien();
            frmThemThongTinSinhVien.TopLevel = false;
            frmThemThongTinSinhVien.Dock = DockStyle.Fill;
            this.pnThemSua.Controls.Add(frmThemThongTinSinhVien);
            frmThemThongTinSinhVien.Show();
        }

        private void btnChinhSuaThongTin_Click(object sender, EventArgs e)
        {
            pnThemSua.Controls.Clear();
            FrmSuaThongTinSinhVien frmSuaThongTinSinhVien = new FrmSuaThongTinSinhVien();
            frmSuaThongTinSinhVien.TopLevel = false;
            frmSuaThongTinSinhVien.Dock = DockStyle.Fill;
            this.pnThemSua.Controls.Add(frmSuaThongTinSinhVien);
            frmSuaThongTinSinhVien.Show();
        }

        private void btnTraPhong_Click(object sender, EventArgs e)
        {
            pnThemSua.Controls.Clear();
            FormQuanLyTraPhong formQuanLyTraPhong = new FormQuanLyTraPhong();
            formQuanLyTraPhong.TopLevel = false;
            formQuanLyTraPhong.Dock = DockStyle.Fill;
            this.pnThemSua.Controls.Add(formQuanLyTraPhong);
            formQuanLyTraPhong.Show();
            
        }
    }
}
