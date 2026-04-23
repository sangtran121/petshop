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
    public partial class Admin_Login : Form
    {
        static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=...";
        public Admin_Login()
        {
            InitializeComponent();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            Users_Login obj = new Users_Login();
            obj.Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {


            string user = txtUsername.Text.Trim();
            string pass = txtPassword.Text.Trim();

            // KIỂM TRA TRỐNG
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu!");
                return;
            }

           
            if (user == "admin" && pass == "admin123")
            {
                MessageBox.Show("Chào mừng Quản trị viên!");
                Dashboard obj = new Dashboard(); 
                obj.Show();
                this.Hide();
            }
            // 2. TÀI KHOẢN NHÂN VIÊN (Kiểm tra trong PetShopDatabase.mdf)
            else
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(Admin_Login.connectionString))
                    {
                        conn.Open();
                        // Vì không dùng Role, mình chỉ cần đếm xem có User đó không
                        string query = "SELECT COUNT(*) FROM UsersTbl WHERE UName = @user AND UPass = @pass";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@user", user);
                            cmd.Parameters.AddWithValue("@pass", pass);

                            int result = (int)cmd.ExecuteScalar();

                            if (result > 0)
                            {
                                MessageBox.Show("Đăng nhập Nhân viên thành công!");
                                // Bạn có thể mở form bán hàng hoặc form người dùng ở đây
                                Billings obj = new Billings();
                                obj.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối Database: " + ex.Message);
                }
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                
                txtPassword.PasswordChar = '\0';
                
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
              
                txtPassword.PasswordChar = '*';
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void lblForgetPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Forget_Password forgetForm = new Forget_Password();

            
            forgetForm.ShowDialog();
        }

        private void Admin_Login_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }
    }
    
}
