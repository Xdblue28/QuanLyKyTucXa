
using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Register
{
    public partial class Registerform : Form
    {
        public IRegisterCallback Callback { get; set; }

        public Registerform()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = this.Controls["txtUsername"].Text.Trim();
            string password = this.Controls["txtPassword"].Text.Trim();
            string MaHoa = BCrypt.Net.BCrypt.HashPassword(password);
            string email = this.Controls["txtEmail"].Text.Trim();
            string pin = this.Controls["txtPin"].Text.Trim();
            string CODEPIN = "an123";

            if (username == "" || password == "" || email == "" || pin == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }       
            if(username.Length <=6)
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
            {;
                MessageBox.Show("Mật khẩu quá ngắn vui lòng nhập lớn hơn 6 ký tự!!");
                return;
            }
    
            // Kiểm tra PinCode
            if (pin != CODEPIN)
            {
                MessageBox.Show(
                    "PinCode không hợp lệ!\nVui lòng liên hệ thầy Trần Trung P201 nhà A để nhận code.\nEmail: DESIGNER_GBLUE@school.edu\nSĐT: 0708-484-678",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            try
            {
                using (SqlConnection conn = Connect.GetConnection())
                {
                    conn.Open();

                    // Kiểm tra username đã tồn tại
                    string checkQuery = "SELECT COUNT(*) FROM DangKy WHERE UserName=@u";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@u", username);
                    int TonTai = (int)checkCmd.ExecuteScalar();

                    if (TonTai > 0)
                    {
                        MessageBox.Show("Tài khoản đã tồn tại!");
                        return;
                    }

                    // Thêm người dùng mới
                    string insertQuery = "INSERT INTO DangKy (UserName, Password, Email) VALUES (@u, @p, @e)";
                    SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                    insertCmd.Parameters.AddWithValue("@u", username);
                    insertCmd.Parameters.AddWithValue("@p", MaHoa);
                    insertCmd.Parameters.AddWithValue("@e", email);
                    insertCmd.ExecuteNonQuery();

                    MessageBox.Show("Đăng ký thành công!");
                    
                    //quay lai login
                    this.Owner.Show();
                    this.Close(); // đóng form sau khi đăng ký
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBackLogin_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void Registerform_Load(object sender, EventArgs e)
        {

        }
    }
}
