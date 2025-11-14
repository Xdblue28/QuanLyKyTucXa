    using Register;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using BCrypt.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace Login
{
    public partial class LOGIN : Form
    {
        public LOGIN()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Registerform rg = new Registerform();
            rg.Owner = this; // Gán LOGIN làm "chủ sở hữu"
            this.Hide();     // Ẩn form login
            rg.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string username = this.Controls["txtUsername"].Text.Trim();
            string password = this.Controls["txtPassword"].Text.Trim();
            if (username == "" || password == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }
            if (username.Length <= 6)
            {
                MessageBox.Show("Tên đăng nhập quá ngắn vui lòng nhập nhiều hơn 6 ký tự");
                return;
            }
            if (!Regex.IsMatch(username, @"^[a-zA-Z0-9_]+$"))
            {
                MessageBox.Show(
                "Tên đăng nhập không hợp lệ!\nChỉ được sử dụng chữ cái không dấu, số và gạch dưới.",
                "Cảnh báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
                return;
            }
            if (password.Length <= 6)
            {
                ;
                MessageBox.Show("Mật khẩu quá ngắn vui lòng nhập lớn hơn 6 ký tự!!");
                return;
            }

            //xu ly su kien

            try
            {
                using (SqlConnection conn = Connect.GetConnection())
                {
                    conn.Open();

                    // Lấy mật khẩu hash từ database theo username
                    string query = "SELECT Password FROM DangKy WHERE UserName=@u";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@u", username);

                    object result = cmd.ExecuteScalar();

                    if (result == null)
                    {
                        MessageBox.Show("Tài khoản không tồn tại!");
                        return;
                    }

                    string hashedPasswordFromDB = result.ToString();

                    // So sánh mật khẩu nhập với hash
                    bool isValid = BCrypt.Net.BCrypt.Verify(password, hashedPasswordFromDB);

                    if (isValid)
                    {
                        MessageBox.Show("Đăng nhập thành công!");
                        // Ở đây có thể mở form chính của app
                        // Example:
                        // MainForm main = new MainForm();
                        // main.Show();
                        // this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu không đúng!");
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

       
    
