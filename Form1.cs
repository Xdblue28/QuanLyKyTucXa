using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DangNhap
{
    public partial class LOGINFRAME : Form
    {
        public LOGINFRAME()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (username == "" || password == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            try
            {
                using (SqlConnection conn = Connect.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Users WHERE Username=@u AND Password=@p";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@u", username);
                    cmd.Parameters.AddWithValue("@p", password);

                    int count = (int)cmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Đăng nhập thành công!");
                        MainForm main = new MainForm();
                        main.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message);
            }
        }
    }
}
