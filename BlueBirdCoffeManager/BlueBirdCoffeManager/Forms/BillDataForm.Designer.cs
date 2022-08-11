namespace BlueBirdCoffeManager.Forms
{
    partial class BillDataForm
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
            this.btnCheckout = new BlueBirdCoffeManager.Utils.RoundedButton();
            this.oldBillPicture = new System.Windows.Forms.PictureBox();
            this.dataPanel = new System.Windows.Forms.Panel();
            this.lbTotal = new System.Windows.Forms.Label();
            this.lbSTT = new System.Windows.Forms.Label();
            this.lbQuan = new System.Windows.Forms.Label();
            this.lbPrice = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.oldBillPicture)).BeginInit();
            this.dataPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCheckout
            // 
            this.btnCheckout.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnCheckout.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btnCheckout.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnCheckout.BorderRadius = 40;
            this.btnCheckout.BorderSize = 0;
            this.btnCheckout.FlatAppearance.BorderSize = 0;
            this.btnCheckout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckout.ForeColor = System.Drawing.Color.White;
            this.btnCheckout.Location = new System.Drawing.Point(300, 463);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(150, 40);
            this.btnCheckout.TabIndex = 0;
            this.btnCheckout.Text = "Thanh toan";
            this.btnCheckout.TextColor = System.Drawing.Color.White;
            this.btnCheckout.UseVisualStyleBackColor = false;
            // 
            // oldBillPicture
            // 
            this.oldBillPicture.Location = new System.Drawing.Point(269, 201);
            this.oldBillPicture.Name = "oldBillPicture";
            this.oldBillPicture.Size = new System.Drawing.Size(100, 50);
            this.oldBillPicture.TabIndex = 5;
            this.oldBillPicture.TabStop = false;
            // 
            // dataPanel
            // 
            this.dataPanel.Controls.Add(this.oldBillPicture);
            this.dataPanel.Location = new System.Drawing.Point(71, 129);
            this.dataPanel.Name = "dataPanel";
            this.dataPanel.Size = new System.Drawing.Size(675, 311);
            this.dataPanel.TabIndex = 6;
            // 
            // lbTotal
            // 
            this.lbTotal.AutoSize = true;
            this.lbTotal.Location = new System.Drawing.Point(441, 81);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(34, 15);
            this.lbTotal.TabIndex = 10;
            this.lbTotal.Text = "Tổng";
            // 
            // lbSTT
            // 
            this.lbSTT.AutoSize = true;
            this.lbSTT.Location = new System.Drawing.Point(71, 81);
            this.lbSTT.Name = "lbSTT";
            this.lbSTT.Size = new System.Drawing.Size(25, 15);
            this.lbSTT.TabIndex = 9;
            this.lbSTT.Text = "STT";
            // 
            // lbQuan
            // 
            this.lbQuan.AutoSize = true;
            this.lbQuan.Location = new System.Drawing.Point(200, 81);
            this.lbQuan.Name = "lbQuan";
            this.lbQuan.Size = new System.Drawing.Size(54, 15);
            this.lbQuan.TabIndex = 8;
            this.lbQuan.Text = "Số lượng";
            // 
            // lbPrice
            // 
            this.lbPrice.AutoSize = true;
            this.lbPrice.Location = new System.Drawing.Point(327, 81);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(48, 15);
            this.lbPrice.TabIndex = 7;
            this.lbPrice.Text = "Đơn giá";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(144, 81);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(25, 15);
            this.lbName.TabIndex = 6;
            this.lbName.Text = "Tên";
            // 
            // BillDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 526);
            this.Controls.Add(this.lbTotal);
            this.Controls.Add(this.dataPanel);
            this.Controls.Add(this.lbSTT);
            this.Controls.Add(this.btnCheckout);
            this.Controls.Add(this.lbQuan);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.lbPrice);
            this.Name = "BillDataForm";
            this.Text = "BillDataForm";
            this.Load += new System.EventHandler(this.BillDataForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.oldBillPicture)).EndInit();
            this.dataPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Utils.RoundedButton btnCheckout;
        private PictureBox oldBillPicture;
        private Panel dataPanel;
        private Label lbSTT;
        private Label lbQuan;
        private Label lbPrice;
        private Label lbName;
        private Label lbTotal;
    }
}