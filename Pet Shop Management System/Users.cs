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
using System.Drawing.Drawing2D;

namespace Pet_Shop_Management_System
{
    public partial class Users : Form
    {

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\app\Pet Shop Management System\Pet Shop Management System\PetShopDatabase.mdf;Integrated Security=True");

        public Users()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Reset()
        {
            txtUserName.Text = "";
            DOB.Text = "";
            CBGender.SelectedItem = -1;
            txtPhoneNumber.Text = "";
            txtFullAddress.Text = "";
            txtPassword.Text = "";

        }
        private void DisplayUsers()
        {
            Con.Open();
            string query = "select * from UsersTbl ";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            DGVUsers.DataSource = ds.Tables[0];
            Con.Close();



        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "" || CBGender.SelectedIndex == -1 || txtPhoneNumber.Text == "" || txtFullAddress.Text == ""||txtPassword.Text==""|| DOB.Value.Date >= DateTime.Today)
            {
                MessageBox.Show("Missing Information !");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into UsersTbl(UserName,DOB,Gender,PhoneNumber,Address,Password)values (@Uname,@Dob,@UGender,@Phone,@Add,@Pass)", Con);
                    cmd.Parameters.AddWithValue("@Uname", txtUserName.Text);
                    cmd.Parameters.AddWithValue("@Dob", DOB.Value.Date);
                    cmd.Parameters.AddWithValue("@UGender", CBGender.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Phone", txtPhoneNumber.Text);
                    cmd.Parameters.AddWithValue("@Add", txtFullAddress.Text);
                    cmd.Parameters.AddWithValue("@Pass", txtPassword.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Added Successfully");
                    Con.Close();
                    DisplayUsers();
                    Reset();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int Key = 0;
        private void DGVUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUserName.Text = DGVUsers.SelectedRows[0].Cells[1].Value.ToString();
            DOB.Text = DGVUsers.SelectedRows[0].Cells[2].Value.ToString();
            CBGender.SelectedItem = DGVUsers.SelectedRows[0].Cells[3].Value.ToString();
            txtPhoneNumber.Text = DGVUsers.SelectedRows[0].Cells[4].Value.ToString();
            txtFullAddress.Text = DGVUsers.SelectedRows[0].Cells[5].Value.ToString();
            if (txtUserName.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(DGVUsers.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void Users_Load(object sender, EventArgs e)
        {
            DisplayUsers();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "" || CBGender.SelectedIndex == -1 || txtPhoneNumber.Text == "" || txtFullAddress.Text == "" || txtPassword.Text == "" || DOB.Value.Date >= DateTime.Today)
            {
                MessageBox.Show("Missing Information !");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Update UsersTbl Set UserName=@Uname,DOB=@Dob,Gender=@UGender,PhoneNumber=@Phone,Address=@Add,Password=@Pass", Con);
                    cmd.Parameters.AddWithValue("@Uname", txtUserName.Text);
                    cmd.Parameters.AddWithValue("@Dob", DOB.Value.Date);
                    cmd.Parameters.AddWithValue("@UGender", CBGender.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Phone", txtPhoneNumber.Text);
                    cmd.Parameters.AddWithValue("@Add", txtFullAddress.Text);
                    cmd.Parameters.AddWithValue("@Pass", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@UId", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Updated Successfully");
                    Con.Close();
                    DisplayUsers();
                    Reset();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Please select User");

            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from UsersTbl where UserId=@UId", Con);
                    cmd.Parameters.AddWithValue("@UId", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Has Been Deleted Successfully");
                    Con.Close();
                    DisplayUsers();
                    Reset();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnPet_Click(object sender, EventArgs e)
        {

            Pets obj = new Pets();
            obj.Show();
            this.Hide();
        }

        private void btnPetFoods_Click(object sender, EventArgs e)
        {

            Pet_Foods obj = new Pet_Foods();
            obj.Show();
            this.Hide();
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {

            Customers obj = new Customers();
            obj.Show();
            this.Hide();
        }

        private void btnBillings_Click(object sender, EventArgs e)
        {

            Billings obj = new Billings();
            obj.Show();
            this.Hide();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {

            Dashboard obj = new Dashboard();
            obj.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {

            Admin_Login obj = new Admin_Login();
            obj.Show();
            this.Hide();
        }
    }
}
