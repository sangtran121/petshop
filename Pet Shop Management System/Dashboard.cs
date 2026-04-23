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
    public partial class Dashboard : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\app\Pet Shop Management System\Pet Shop Management System\PetShopDatabase.mdf;Integrated Security=True");
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void TotalDogs()
        {
            string Cat = "Dog";
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from PetsTbl where Category='" + Cat + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            lblTotalDogs.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void TotalCats()
        {
            string Cat = "Cat";
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from PetsTbl where Category='" + Cat + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            lblTotalCats.Text = dt.Rows[0][0].ToString();
            Con.Close();

        }
        private void TotalBirds()
        {
            string Cat = "Bird";
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from PetsTbl where Category='" + Cat + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            lblTotalBirds.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void TotalUsers()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(UserName) from UsersTbl ", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            lblTotalUsers.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void TotalCustomers()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(CustName) from CustomersTbl ", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            lblTotalCustomers.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void SumAmount()
        {

            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select sum(TotalAmount) from TransactionTbl ", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            lblTotalAmount.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void Dashboard_Load(object sender, EventArgs e)
        {
            TotalDogs();
            TotalCats();
            TotalBirds();
            TotalUsers();
            TotalCustomers();
            SumAmount();


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

        private void btnUsers_Click(object sender, EventArgs e)
        {

            Users obj = new Users();
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

        private void btnLogout_Click(object sender, EventArgs e)
        {

            Admin_Login obj = new Admin_Login();
            obj.Show();
            this.Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
