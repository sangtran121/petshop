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
using System.Runtime.CompilerServices;
namespace Pet_Shop_Management_System
{
    public partial class Billings : Form
    {

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\app\Pet Shop Management System\Pet Shop Management System\PetShopDatabase.mdf;Integrated Security=True");

        public Billings()
        {
            InitializeComponent();
            DisplayPets();
            DisplayPetFoods();
            FillIdOfCustomer();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Billings_Load(object sender, EventArgs e)
        {
            DisplayPetFoods();
            DisplayPets();
        }

        

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrice_TextChanged_1(object sender, EventArgs e)
        {

        }
        
        int Key = 0, Stock = 0;
        private void Reset()
        {
            txtNameOfCustomer.Text = "";
            txtProductName.Text = "";
            txtPrice.Text = "";
            txtQuantity.Text = "";
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
        private void FillIdOfCustomer()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select CustId from CustomersTbl ", Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CustId", typeof(int));
            dt.Load(Rdr);
            CBIdOfCustomer.ValueMember = "CustId";
            CBIdOfCustomer.DataSource = dt;
            Con.Close();

        }
        private void GetNameOfCustomer()
        {
           
            if (Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }
            string query = "select * from CustomersTbl where CustId = " + CBIdOfCustomer.SelectedValue.ToString() ;
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                txtNameOfCustomer.Text = dr["CustName"].ToString();

            }
            Con.Close();


        }
        private void UpdatePets()
        {
            int NewQuantity = Stock - Convert.ToInt32(txtQuantity.Text);
            try
            {
                Con.Open();
                string query = "update PetsTbl set Quantity = " + NewQuantity + " where PetId=" + Key + ";";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Item is updated Successfully");
                Con.Close();
                DisplayPets();

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        private void UpdatePetFoods()
        {
            int NewQuantity = Stock - Convert.ToInt32(txtQuantity.Text);
            try
            {
                Con.Open();
                string query = "update PetFoodsTbl set Quantity = " + NewQuantity + "where FoodId =" + Key + ";";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Item is updated Successfully");
                Con.Close();
                DisplayPetFoods();

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        private void DGVPetFoods_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtProductName.Text = DGVPetFoods.SelectedRows[0].Cells[1].Value.ToString();
            txtPrice.Text = DGVPetFoods.SelectedRows[0].Cells[4].Value.ToString();
            if (txtProductName.Text == "")
            {
                Key = 0;
                Stock = 0;
            }
            else
            {
                Key = Convert.ToInt32(DGVPetFoods.SelectedRows[0].Cells[0].Value.ToString());
                Stock = Convert.ToInt32(DGVPetFoods.SelectedRows[0].Cells[3].Value.ToString());
            }
        }
        
        int n = 0;
        int totalAmnt = 0; 

        private void btnAddPetBill_Click(object sender, EventArgs e)
        {
            if (txtQuantity.Text == "" || txtPrice.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đủ Số lượng và Giá!");
            }
            else
            {
                try
                {
                    int total = Convert.ToInt32(txtPrice.Text) * Convert.ToInt32(txtQuantity.Text);
                    DataGridViewRow newRow = new DataGridViewRow();
                    newRow.CreateCells(DGVCustomerBill); 

                    newRow.Cells[0].Value = n + 1;
                    newRow.Cells[1].Value = txtProductName.Text;
                    newRow.Cells[2].Value = txtQuantity.Text;
                    newRow.Cells[3].Value = txtPrice.Text;
                    newRow.Cells[4].Value = total;

                    DGVCustomerBill.Rows.Add(newRow);

                    n++;
                    totalAmnt += total;
                    lblTotalAmount.Text = totalAmnt + " VNĐ";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnReset_Click_1(object sender, EventArgs e)
        {
            txtProductName.Text = "";
            txtQuantity.Text = "";
            txtPrice.Text = "";
        }

        private void btnPet_Click_1(object sender, EventArgs e)
        {

            Pets obj = new Pets();
            obj.Show();
            this.Hide();
        }

        private void btnPetFoods_Click_1(object sender, EventArgs e)
        {

            Pet_Foods obj = new Pet_Foods();
            obj.Show();
            this.Hide();
        }

        private void btnUsers_Click_1(object sender, EventArgs e)
        {

            Users obj = new Users();
            obj.Show();
            this.Hide();
        }

        private void btnCustomers_Click_1(object sender, EventArgs e)
        {

            Customers obj = new Customers();
            obj.Show();
            this.Hide();
        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {

            Transaction obj = new Transaction();
            obj.Show();
            this.Hide();
        }

        private void btnDashboard_Click_1(object sender, EventArgs e)
        {

            Dashboard obj = new Dashboard();
            obj.Show();
            this.Hide();
        }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {

            Users_Login obj = new Users_Login();
            obj.Show();
            this.Hide();
        }

        private void CBIdOfCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetNameOfCustomer();
        }

        private void btnPrintBill_Click(object sender, EventArgs e)
        {
            MessageBox.Show("In hóa đơn thành công cho khách: " + txtNameOfCustomer.Text);
            DGVCustomerBill.Rows.Clear();
            lblTotalAmount.Text = "0 VNĐ";
            totalAmnt = 0;
        }

        private void txtNameOfCustomer_TextChanged(object sender, EventArgs e)
        {
            if (CBIdOfCustomer.SelectedValue != null)
            {
                if (Con.State == ConnectionState.Closed)
                {
                    Con.Open();
                }

                string query = "select * from CustomersTbl where CustId = " + CBIdOfCustomer.SelectedValue.ToString();
                SqlCommand cmd = new SqlCommand(query, Con);
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    txtNameOfCustomer.Text = dr["CustName"].ToString();
                }
                Con.Close();
            }
          
        }

        private void btnAddPetFoodBill_Click(object sender, EventArgs e)
        {
            if (txtQuantity.Text == "" || txtPrice.Text == "")
            {
                MessageBox.Show("Vui lòng chọn thực phẩm thú cưng và nhập số lượng!");
            }
            else
            {
                try
                {
                    
                    int total = Convert.ToInt32(txtPrice.Text) * Convert.ToInt32(txtQuantity.Text);

                    
                    DataGridViewRow newRow = new DataGridViewRow();
                    newRow.CreateCells(DGVCustomerBill); 

                    newRow.Cells[0].Value = n + 1;             
                    newRow.Cells[1].Value = txtProductName.Text; 
                    newRow.Cells[2].Value = txtQuantity.Text;    
                    newRow.Cells[3].Value = txtPrice.Text;      
                    newRow.Cells[4].Value = total;             

               
                    DGVCustomerBill.Rows.Add(newRow);

                   
                    n++; 
                    totalAmnt += total; 

                 
                    lblTotalAmount.Text = totalAmnt + " VNĐ";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void DGVPets_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtProductName.Text = DGVPets.SelectedRows[0].Cells[1].Value.ToString();
            txtPrice.Text = DGVPets.SelectedRows[0].Cells[4].Value.ToString();
            if (txtProductName.Text == "")
            {
                Key = 0;
                Stock = 0;
            }
            else
            {
                Key = Convert.ToInt32(DGVPets.SelectedRows[0].Cells[0].Value.ToString());
                Stock = Convert.ToInt32(DGVPets.SelectedRows[0].Cells[3].Value.ToString());
            }
        }
    }
}
