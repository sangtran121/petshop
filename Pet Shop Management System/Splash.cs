using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Pet_Shop_Management_System
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }
        int startPoint = 0;
        private void Splash_Load(object sender, EventArgs e)
        {

        }
        

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            startPoint += 2; 

            
            MyProgressBar.Value = startPoint;

           
            PercentageLbl.Text = startPoint + "%";

            
            if (MyProgressBar.Value == 100)
            {
                MyProgressBar.Value = 0;
                timer1.Stop(); // Dừng đồng hồ

               
                Admin_Login obj = new Admin_Login();
                obj.Show();
                this.Hide(); 
            }
        }
    }
}
