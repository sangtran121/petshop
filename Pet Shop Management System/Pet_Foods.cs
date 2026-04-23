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
    public partial class Pet_Foods : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\app\Pet Shop Management System\Pet Shop Management System\PetShopDatabase.mdf;Integrated Security=True");
        public Pet_Foods()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Reset()
        {
            txtPetFoodName.Text = "";
            CBCategory.SelectedItem = -1;
            txtQuantity.Text = "";
            txtPrice.Text = "";
        }
        private void DisplayPetFoods()
        {
            Con.Open();
            string query = "select * from PetFoodsTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            DGVPetFoods.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPetFoodName.Text == "" || CBCategory.SelectedIndex == -1 || txtQuantity.Text == "" || txtPrice.Text == "")
            {
                MessageBox.Show("Missing Information !");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into PetFoodsTbl(FoodName,Category,Quantity,Price)values (@Fname,@Cate,@Qty,@Price)", Con);
                    cmd.Parameters.AddWithValue("@Fname", txtPetFoodName.Text);
                    cmd.Parameters.AddWithValue("@Cate", CBCategory.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Qty", txtQuantity.Text);
                    cmd.Parameters.AddWithValue("@Price", txtPrice.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Pet Food Added Successfully");
                    Con.Close();
                    DisplayPetFoods();
                    Reset();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int Key = 0;
        private void DGVPetFoods_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtPetFoodName.Text = DGVPetFoods.SelectedRows[0].Cells[1].Value.ToString();
            CBCategory.SelectedItem = DGVPetFoods.SelectedRows[0].Cells[2].Value.ToString();
            txtQuantity.Text = DGVPetFoods.SelectedRows[0].Cells[3].Value.ToString();
            txtPrice.Text = DGVPetFoods.SelectedRows[0].Cells[4].Value.ToString();
            if (txtPetFoodName.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(DGVPetFoods.SelectedRows[0].Cells[0].Value.ToString());
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (txtPetFoodName.Text == "" || CBCategory.SelectedIndex == -1 || txtQuantity.Text == "" || txtPrice.Text == "")
            {
                MessageBox.Show("Missing Information !");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Update PetFoodsTbl Set FoodName=@Fname,Category=@Cate,Quantity=@Qty,Price=@Price where FoodId=@FId", Con);
                    cmd.Parameters.AddWithValue("@Fname", txtPetFoodName.Text);
                    cmd.Parameters.AddWithValue("@Cate", CBCategory.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Qty", txtQuantity.Text);
                    cmd.Parameters.AddWithValue("@Price", txtPrice.Text);
                    cmd.Parameters.AddWithValue("@FId", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Pet Food Updated Successfully");
                    Con.Close();
                    DisplayPetFoods();
                    Reset();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void Pet_Foods_Load(object sender, EventArgs e)
        {
            DisplayPetFoods();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Please select Pet Food");

            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from PetFoodsTbl where FoodId=@FId", Con);
                    cmd.Parameters.AddWithValue("@FId", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Pet Food Has Been Deleted Successfully");
                    Con.Close();
                    DisplayPetFoods();
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

        private void btnLogout_Click(object sender, EventArgs e)
        {

            Admin_Login obj = new Admin_Login();
            obj.Show();
            this.Hide();
        }
    }
}

