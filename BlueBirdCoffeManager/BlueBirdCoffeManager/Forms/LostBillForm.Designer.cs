namespace BlueBirdCoffeManager.Forms
{
    partial class LostBillForm
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
            this.dataPanel = new System.Windows.Forms.Panel();
            this.lostBillPanel = new System.Windows.Forms.Panel();
            this.btnSubmit = new BlueBirdCoffeManager.Utils.RoundedButton();
            this.dataPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataPanel
            // 
            this.dataPanel.Controls.Add(this.btnSubmit);
            this.dataPanel.Location = new System.Drawing.Point(174, 66);
            this.dataPanel.Name = "dataPanel";
            this.dataPanel.Size = new System.Drawing.Size(200, 100);
            this.dataPanel.TabIndex = 0;
            // 
            // lostBillPanel
            // 
            this.lostBillPanel.Location = new System.Drawing.Point(190, 261);
            this.lostBillPanel.Name = "lostBillPanel";
            this.lostBillPanel.Size = new System.Drawing.Size(200, 100);
            this.lostBillPanel.TabIndex = 1;
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnSubmit.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btnSubmit.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnSubmit.BorderRadius = 40;
            this.btnSubmit.BorderSize = 0;
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(54, 60);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(150, 40);
            this.btnSubmit.TabIndex = 0;
            this.btnSubmit.Text = "Hoàn tất";
            this.btnSubmit.TextColor = System.Drawing.Color.White;
            this.btnSubmit.UseVisualStyleBackColor = false;
            // 
            // LostBillForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 630);
            this.Controls.Add(this.lostBillPanel);
            this.Controls.Add(this.dataPanel);
            this.Name = "LostBillForm";
            this.Text = "LostBillForm";
            this.Load += new System.EventHandler(this.LostBillForm_Load);
            this.dataPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel dataPanel;
        private Utils.RoundedButton btnSubmit;
        private Panel lostBillPanel;
    }
}