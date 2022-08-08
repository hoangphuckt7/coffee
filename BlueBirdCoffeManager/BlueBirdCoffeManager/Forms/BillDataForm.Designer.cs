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
            this.dataBotPanel = new System.Windows.Forms.Panel();
            this.btnCheckout = new BlueBirdCoffeManager.Utils.RoundedButton();
            this.dataPanel = new System.Windows.Forms.Panel();
            this.lbTotal = new System.Windows.Forms.Label();
            this.oldBillPicture = new System.Windows.Forms.PictureBox();
            this.lbName = new System.Windows.Forms.Label();
            this.lbPrice = new System.Windows.Forms.Label();
            this.lbQuan = new System.Windows.Forms.Label();
            this.lbSTT = new System.Windows.Forms.Label();
            this.dataBotPanel.SuspendLayout();
            this.dataPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.oldBillPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // dataBotPanel
            // 
            this.dataBotPanel.Controls.Add(this.btnCheckout);
            this.dataBotPanel.Location = new System.Drawing.Point(52, 295);
            this.dataBotPanel.Name = "dataBotPanel";
            this.dataBotPanel.Size = new System.Drawing.Size(696, 143);
            this.dataBotPanel.TabIndex = 10;
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
            this.btnCheckout.Location = new System.Drawing.Point(272, 65);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(150, 40);
            this.btnCheckout.TabIndex = 6;
            this.btnCheckout.Text = "Thanh toán";
            this.btnCheckout.TextColor = System.Drawing.Color.White;
            this.btnCheckout.UseVisualStyleBackColor = false;
            // 
            // dataPanel
            // 
            this.dataPanel.Controls.Add(this.lbTotal);
            this.dataPanel.Controls.Add(this.oldBillPicture);
            this.dataPanel.Controls.Add(this.lbName);
            this.dataPanel.Controls.Add(this.lbPrice);
            this.dataPanel.Controls.Add(this.lbQuan);
            this.dataPanel.Controls.Add(this.lbSTT);
            this.dataPanel.Location = new System.Drawing.Point(52, 12);
            this.dataPanel.Name = "dataPanel";
            this.dataPanel.Size = new System.Drawing.Size(696, 277);
            this.dataPanel.TabIndex = 9;
            // 
            // lbTotal
            // 
            this.lbTotal.AutoSize = true;
            this.lbTotal.Location = new System.Drawing.Point(272, 23);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(34, 15);
            this.lbTotal.TabIndex = 4;
            this.lbTotal.Text = "Tổng";
            // 
            // oldBillPicture
            // 
            this.oldBillPicture.Location = new System.Drawing.Point(50, 114);
            this.oldBillPicture.Name = "oldBillPicture";
            this.oldBillPicture.Size = new System.Drawing.Size(100, 50);
            this.oldBillPicture.TabIndex = 5;
            this.oldBillPicture.TabStop = false;
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(201, 97);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(25, 15);
            this.lbName.TabIndex = 1;
            this.lbName.Text = "Tên";
            // 
            // lbPrice
            // 
            this.lbPrice.AutoSize = true;
            this.lbPrice.Location = new System.Drawing.Point(168, 23);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(48, 15);
            this.lbPrice.TabIndex = 3;
            this.lbPrice.Text = "Đơn giá";
            // 
            // lbQuan
            // 
            this.lbQuan.AutoSize = true;
            this.lbQuan.Location = new System.Drawing.Point(77, 23);
            this.lbQuan.Name = "lbQuan";
            this.lbQuan.Size = new System.Drawing.Size(54, 15);
            this.lbQuan.TabIndex = 2;
            this.lbQuan.Text = "Số lượng";
            // 
            // lbSTT
            // 
            this.lbSTT.AutoSize = true;
            this.lbSTT.Location = new System.Drawing.Point(-46, 23);
            this.lbSTT.Name = "lbSTT";
            this.lbSTT.Size = new System.Drawing.Size(25, 15);
            this.lbSTT.TabIndex = 0;
            this.lbSTT.Text = "STT";
            // 
            // BillDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 526);
            this.Controls.Add(this.dataBotPanel);
            this.Controls.Add(this.dataPanel);
            this.Name = "BillDataForm";
            this.Text = "BillDataForm";
            this.Load += new System.EventHandler(this.BillDataForm_Load);
            this.dataBotPanel.ResumeLayout(false);
            this.dataPanel.ResumeLayout(false);
            this.dataPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.oldBillPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel dataBotPanel;
        private Utils.RoundedButton btnCheckout;
        private Panel dataPanel;
        private Label lbTotal;
        private PictureBox oldBillPicture;
        private Label lbName;
        private Label lbPrice;
        private Label lbQuan;
        private Label lbSTT;
    }
}