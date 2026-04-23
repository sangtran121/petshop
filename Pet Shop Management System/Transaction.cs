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
    public partial class Transaction : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\app\Pet Shop Management System\Pet Shop Management System\PetShopDatabase.mdf;Integrated Security=True");
        public Transaction()
        {
            InitializeComponent();
        }
        private void DisplayTransaction()
        {
            Con.Open();
            string query = "select * from TransactionTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            DGVTransaction.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DGVTransaction_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Transaction_Load(object sender, EventArgs e)
        {
            DisplayTransaction();
        }
    }
}
