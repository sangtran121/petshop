using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pet_Shop_Management_System
{
    public partial class Pets : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\app\Pet Shop Management System\Pet Shop Management System\PetShopDatabase.mdf;Integrated Security=True");
        
        public Pets()
        {
            InitializeComponent();
        }

        private void Pets_Load(object sender, EventArgs e)
        {
            DisplayPets();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Reset()
        {
            txtPetName.Text = "";
            CBCategory.SelectedItem = -1;
            txtQuantity.Text = "";
            txtPrice.Text = "";
        }
        private void DisplayPets()
        {
            Con.Open();
            string query = "select * from PetsTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            DGVPets.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtPetName.Text == "" || CBCategory.SelectedIndex == -1 || txtQuantity.Text == "" || txtPrice.Text == "")
            {
                MessageBox.Show("Missing Information !");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into PetsTbl(PetName,Category,Quantity,Price)values (@Pname,@Cate,@Qty,@Price)",Con);
                    cmd.Parameters.AddWithValue("@Pname", txtPetName.Text);
                    cmd.Parameters.AddWithValue("@Cate", CBCategory.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Qty", txtQuantity.Text);
                    cmd.Parameters.AddWithValue("@Price", txtPrice.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Pet Added Successfully");
                    Con.Close();
                    DisplayPets();
                    Reset();

                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int Key = 0;
        private void DGVPets_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtPetName.Text = DGVPets.SelectedRows[0].Cells[1].Value.ToString();
            CBCategory.SelectedItem = DGVPets.SelectedRows[0].Cells[2].Value.ToString();
            txtQuantity.Text = DGVPets.SelectedRows[0].Cells[3].Value.ToString();
            txtPrice.Text = DGVPets.SelectedRows[0].Cells[4].Value.ToString();
            if(txtPetName.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(DGVPets.SelectedRows[0].Cells[0].Value.ToString());
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtPetName.Text == "" || CBCategory.SelectedIndex == -1 || txtQuantity.Text == "" || txtPrice.Text == "")
            {
                MessageBox.Show("Missing Information !");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Update PetsTbl Set PetName=@Pname,Category=@Cate,Quantity=@Qty,Price=@Price where PetId=@PId", Con);
                    cmd.Parameters.AddWithValue("@Pname", txtPetName.Text);
                    cmd.Parameters.AddWithValue("@Cate", CBCategory.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Qty", txtQuantity.Text);
                    cmd.Parameters.AddWithValue("@Price", txtPrice.Text);
                    cmd.Parameters.AddWithValue("@PId", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Pet Updated Successfully");
                    Con.Close();
                    DisplayPets();
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
            if(Key == 0)
            {
                MessageBox.Show("Please select Pet");

            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from PetsTbl where PetId=@PId", Con);
                    cmd.Parameters.AddWithValue("@PId", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Pet Has Been Deleted Successfully");
                    Con.Close();
                    DisplayPets();
                    Reset();

                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
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

        private void btnDashboard_Click(object sender, EventArgs e)
        {

            Dashboard obj = new Dashboard();
            obj.Show();
            this.Hide();
        }

        private void btnOut_Click(object sender, EventArgs e)
        {

            Admin_Login obj = new Admin_Login();
            obj.Show();
            this.Hide();
        }
    }
}
