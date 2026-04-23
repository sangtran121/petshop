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
    public partial class Forget_Password : Form
    {
        string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\app\Pet Shop Management System\Pet Shop Management System\PetShopDatabase.mdf"";Integrated Security=True";
        public Forget_Password()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Forget_Password_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                  
                    string sql = "SELECT COUNT(*) FROM UsersTbl WHERE Username=@user AND PhoneNumber=@Phone";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@user", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@Phone", txtPhoneNumber.Text);

                    int count = (int)cmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Xác minh thành công! Vui lòng nhập mật khẩu mới.");
                      
                        btnChangePassword.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("Thông tin không chính xác!");
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                // Cập nhật mật khẩu mới dựa trên Username đã nhập ở trên
                string sql = "UPDATE UsersTbl SET Password=@pass WHERE Username=@users";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@pass", txtNewPassword.Text);
                cmd.Parameters.AddWithValue("@users", txtUsername.Text);

                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Mật khẩu đã được thay đổi thành công!");
                    this.Close(); 
                }
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtNewPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '*';
        }

        private void lblback_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        
    }
    
}
