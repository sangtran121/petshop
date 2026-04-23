using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Pet_Shop_Management_System
{
    public partial class Users_Login : Form
    {
        string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\app\Pet Shop Management System\Pet Shop Management System\PetShopDatabase.mdf"";Integrated Security=True;Connect Timeout=30;Encrypt=False";
        public Users_Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
          

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string user = txtUsername.Text;
                    string pass = txtPassword.Text;

                    // Truy vấn kiểm tra với Role là 'User'
                    string sql = "SELECT * FROM UsersTbl WHERE Username=@user AND Password=@pass ";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@user", user);
                    cmd.Parameters.AddWithValue("@pass", pass);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        MessageBox.Show("Người dùng đăng nhập thành công!");
                        Dashboard main = new Dashboard(); // Form giao diện chính cho User
                        main.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Sai tài khoản, mật khẩu hoặc bạn không có quyền User!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                txtPassword.PasswordChar = '\0'; // Hiện mật khẩu
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.PasswordChar = '*'; // Ẩn mật khẩu
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Forget_Password forget = new Forget_Password();
            forget.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            Users reg = new Users();
            reg.Show();
            this.Hide();
        }

        private void Users_Login_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
