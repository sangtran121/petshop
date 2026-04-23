namespace Pet_Shop_Management_System
{
    partial class Chatbox
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.txtQuestion = new System.Windows.Forms.TextBox();
            this.btnAsk = new System.Windows.Forms.Button();
            this.rtbChatHistory = new System.Windows.Forms.RichTextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            // txtQuestion
            //
            this.txtQuestion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtQuestion.Location = new System.Drawing.Point(12, 12);
            this.txtQuestion.Multiline = true;
            this.txtQuestion.Name = "txtQuestion";
            this.txtQuestion.Size = new System.Drawing.Size(460, 45);
            this.txtQuestion.TabIndex = 0;
            //
            // btnAsk
            //
            this.btnAsk.Font = new System.Drawing.Font("Segoe UI", 9F,
            System.Drawing.FontStyle.Bold);
            this.btnAsk.Location = new System.Drawing.Point(478, 12);
            this.btnAsk.Name = "btnAsk";
            this.btnAsk.Size = new System.Drawing.Size(94, 45);
            this.btnAsk.TabIndex = 1;
            this.btnAsk.Text = "Hỏi Gemini";
            this.btnAsk.UseVisualStyleBackColor = true;
            //
            // rtbChatHistory
            //
            this.rtbChatHistory.BackColor = System.Drawing.Color.White;
            this.rtbChatHistory.Font = new System.Drawing.Font("Segoe UI", 9.75F,
            System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbChatHistory.Location = new System.Drawing.Point(12, 70);
            this.rtbChatHistory.Name = "rtbChatHistory";
            this.rtbChatHistory.ReadOnly = true;
            this.rtbChatHistory.Size = new System.Drawing.Size(560, 280);
            this.rtbChatHistory.TabIndex = 2;
            this.rtbChatHistory.Text = "";
            //
            // lblStatus
            //
            this.lblStatus.AutoSize = true;
            this.lblStatus.ForeColor = System.Drawing.Color.DimGray;
            this.lblStatus.Location = new System.Drawing.Point(12, 360);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(52, 13);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "Sẵn sàng";
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 386);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.rtbChatHistory);
            this.Controls.Add(this.btnAsk);
            this.Controls.Add(this.txtQuestion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gemini AI Desktop Assistant (REST API)";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
        private System.Windows.Forms.TextBox txtQuestion;
        private System.Windows.Forms.Button btnAsk;
        private System.Windows.Forms.RichTextBox rtbChatHistory;
        private System.Windows.Forms.Label lblStatus;
    }
}