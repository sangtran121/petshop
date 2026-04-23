namespace Pet_Shop_Management_System
{
    partial class Splash
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Splash));
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.PercentageLbl = new System.Windows.Forms.Label();
            this.MyProgressBar = new Guna.UI2.WinForms.Guna2CircleProgressBar();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 15;
            this.guna2Elipse1.TargetControl = this;
            // 
            // PercentageLbl
            // 
            this.PercentageLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PercentageLbl.AutoSize = true;
            this.PercentageLbl.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PercentageLbl.ForeColor = System.Drawing.Color.White;
            this.PercentageLbl.Location = new System.Drawing.Point(238, 380);
            this.PercentageLbl.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.PercentageLbl.Name = "PercentageLbl";
            this.PercentageLbl.Size = new System.Drawing.Size(334, 25);
            this.PercentageLbl.TabIndex = 5;
            this.PercentageLbl.Text = "Aplication is loading..Please Wait!";
            this.PercentageLbl.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // MyProgressBar
            // 
            this.MyProgressBar.FillColor = System.Drawing.Color.Transparent;
            this.MyProgressBar.FillThickness = 10;
            this.MyProgressBar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.MyProgressBar.ForeColor = System.Drawing.Color.White;
            this.MyProgressBar.Image = ((System.Drawing.Image)(resources.GetObject("MyProgressBar.Image")));
            this.MyProgressBar.ImageSize = new System.Drawing.Size(280, 280);
            this.MyProgressBar.InnerColor = System.Drawing.Color.Transparent;
            this.MyProgressBar.Location = new System.Drawing.Point(253, 86);
            this.MyProgressBar.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MyProgressBar.Minimum = 0;
            this.MyProgressBar.Name = "MyProgressBar";
            this.MyProgressBar.ProgressColor = System.Drawing.Color.Yellow;
            this.MyProgressBar.ProgressColor2 = System.Drawing.Color.Yellow;
            this.MyProgressBar.ProgressThickness = 10;
            this.MyProgressBar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.MyProgressBar.Size = new System.Drawing.Size(282, 282);
            this.MyProgressBar.TabIndex = 4;
            this.MyProgressBar.Text = "guna2CircleProgressBar1";
            // 
            // guna2Button1
            // 
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.White;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.Maroon;
            this.guna2Button1.HoverState.FillColor = System.Drawing.Color.White;
            this.guna2Button1.HoverState.ForeColor = System.Drawing.Color.Maroon;
            this.guna2Button1.Location = new System.Drawing.Point(138, 4);
            this.guna2Button1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.ShadowDecoration.BorderRadius = 10;
            this.guna2Button1.Size = new System.Drawing.Size(475, 72);
            this.guna2Button1.TabIndex = 3;
            this.guna2Button1.Text = "Pet Shop Management System";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // Splash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(750, 450);
            this.Controls.Add(this.PercentageLbl);
            this.Controls.Add(this.MyProgressBar);
            this.Controls.Add(this.guna2Button1);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Splash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Splash_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.Label PercentageLbl;
        private Guna.UI2.WinForms.Guna2CircleProgressBar MyProgressBar;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private System.Windows.Forms.Timer timer1;
    }
}

