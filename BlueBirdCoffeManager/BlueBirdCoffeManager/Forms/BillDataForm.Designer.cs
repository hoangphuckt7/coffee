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
            this.lbaTotal = new System.Windows.Forms.Label();
            this.total = new System.Windows.Forms.Label();
            this.lbapDiscout = new System.Windows.Forms.Label();
            this.lbapCp = new System.Windows.Forms.Label();
            this.txtapDiscout = new System.Windows.Forms.TextBox();
            this.txtapCoupon = new System.Windows.Forms.TextBox();
            this.lbDiscout = new System.Windows.Forms.Label();
            this.lbvoucher = new System.Windows.Forms.Label();
            this.txtDiscout = new System.Windows.Forms.Label();
            this.txtVoucher = new System.Windows.Forms.Label();
            this.lbCash = new System.Windows.Forms.Label();
            this.txtCash = new System.Windows.Forms.Label();
            this.lbCustomerP = new System.Windows.Forms.Label();
            this.lbEx = new System.Windows.Forms.Label();
            this.txtCustomerP = new System.Windows.Forms.TextBox();
            this.txtEx = new System.Windows.Forms.Label();
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
            this.btnCheckout.Location = new System.Drawing.Point(307, 622);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(150, 40);
            this.btnCheckout.TabIndex = 0;
            this.btnCheckout.Text = "Thanh toan";
            this.btnCheckout.TextColor = System.Drawing.Color.White;
            this.btnCheckout.UseVisualStyleBackColor = false;
            // 
            // oldBillPicture
            // 
            this.oldBillPicture.Location = new System.Drawing.Point(256, 31);
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
            this.dataPanel.Size = new System.Drawing.Size(675, 137);
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
            // lbaTotal
            // 
            this.lbaTotal.AutoSize = true;
            this.lbaTotal.Location = new System.Drawing.Point(97, 280);
            this.lbaTotal.Name = "lbaTotal";
            this.lbaTotal.Size = new System.Drawing.Size(34, 15);
            this.lbaTotal.TabIndex = 11;
            this.lbaTotal.Text = "Tổng";
            // 
            // total
            // 
            this.total.AutoSize = true;
            this.total.Location = new System.Drawing.Point(660, 280);
            this.total.Name = "total";
            this.total.Size = new System.Drawing.Size(20, 15);
            this.total.TabIndex = 12;
            this.total.Text = "0₫";
            // 
            // lbapDiscout
            // 
            this.lbapDiscout.AutoSize = true;
            this.lbapDiscout.Location = new System.Drawing.Point(104, 552);
            this.lbapDiscout.Name = "lbapDiscout";
            this.lbapDiscout.Size = new System.Drawing.Size(102, 15);
            this.lbapDiscout.TabIndex = 13;
            this.lbapDiscout.Text = "Áp dụng giảm giá";
            // 
            // lbapCp
            // 
            this.lbapCp.AutoSize = true;
            this.lbapCp.Location = new System.Drawing.Point(104, 585);
            this.lbapCp.Name = "lbapCp";
            this.lbapCp.Size = new System.Drawing.Size(122, 15);
            this.lbapCp.TabIndex = 14;
            this.lbapCp.Text = "Áp dụng mã giảm giá";
            // 
            // txtapDiscout
            // 
            this.txtapDiscout.Location = new System.Drawing.Point(638, 544);
            this.txtapDiscout.Name = "txtapDiscout";
            this.txtapDiscout.Size = new System.Drawing.Size(100, 23);
            this.txtapDiscout.TabIndex = 15;
            // 
            // txtapCoupon
            // 
            this.txtapCoupon.Location = new System.Drawing.Point(638, 577);
            this.txtapCoupon.Name = "txtapCoupon";
            this.txtapCoupon.Size = new System.Drawing.Size(100, 23);
            this.txtapCoupon.TabIndex = 16;
            // 
            // lbDiscout
            // 
            this.lbDiscout.AutoSize = true;
            this.lbDiscout.Location = new System.Drawing.Point(97, 311);
            this.lbDiscout.Name = "lbDiscout";
            this.lbDiscout.Size = new System.Drawing.Size(54, 15);
            this.lbDiscout.TabIndex = 17;
            this.lbDiscout.Text = "Giảm giá";
            // 
            // lbvoucher
            // 
            this.lbvoucher.AutoSize = true;
            this.lbvoucher.Location = new System.Drawing.Point(97, 342);
            this.lbvoucher.Name = "lbvoucher";
            this.lbvoucher.Size = new System.Drawing.Size(50, 15);
            this.lbvoucher.TabIndex = 18;
            this.lbvoucher.Text = "Voucher";
            // 
            // txtDiscout
            // 
            this.txtDiscout.AutoSize = true;
            this.txtDiscout.Location = new System.Drawing.Point(660, 309);
            this.txtDiscout.Name = "txtDiscout";
            this.txtDiscout.Size = new System.Drawing.Size(20, 15);
            this.txtDiscout.TabIndex = 19;
            this.txtDiscout.Text = "0₫";
            // 
            // txtVoucher
            // 
            this.txtVoucher.AutoSize = true;
            this.txtVoucher.Location = new System.Drawing.Point(659, 337);
            this.txtVoucher.Name = "txtVoucher";
            this.txtVoucher.Size = new System.Drawing.Size(20, 15);
            this.txtVoucher.TabIndex = 20;
            this.txtVoucher.Text = "0₫";
            // 
            // lbCash
            // 
            this.lbCash.AutoSize = true;
            this.lbCash.Location = new System.Drawing.Point(97, 373);
            this.lbCash.Name = "lbCash";
            this.lbCash.Size = new System.Drawing.Size(64, 15);
            this.lbCash.TabIndex = 21;
            this.lbCash.Text = "Tổng cộng";
            // 
            // txtCash
            // 
            this.txtCash.AutoSize = true;
            this.txtCash.Location = new System.Drawing.Point(660, 373);
            this.txtCash.Name = "txtCash";
            this.txtCash.Size = new System.Drawing.Size(20, 15);
            this.txtCash.TabIndex = 22;
            this.txtCash.Text = "0₫";
            // 
            // lbCustomerP
            // 
            this.lbCustomerP.AutoSize = true;
            this.lbCustomerP.Location = new System.Drawing.Point(99, 430);
            this.lbCustomerP.Name = "lbCustomerP";
            this.lbCustomerP.Size = new System.Drawing.Size(81, 15);
            this.lbCustomerP.TabIndex = 23;
            this.lbCustomerP.Text = "Tiền khách trả";
            // 
            // lbEx
            // 
            this.lbEx.AutoSize = true;
            this.lbEx.Location = new System.Drawing.Point(99, 474);
            this.lbEx.Name = "lbEx";
            this.lbEx.Size = new System.Drawing.Size(56, 15);
            this.lbEx.TabIndex = 24;
            this.lbEx.Text = "Tiền thừa";
            // 
            // txtCustomerP
            // 
            this.txtCustomerP.Location = new System.Drawing.Point(573, 422);
            this.txtCustomerP.Name = "txtCustomerP";
            this.txtCustomerP.Size = new System.Drawing.Size(100, 23);
            this.txtCustomerP.TabIndex = 25;
            // 
            // txtEx
            // 
            this.txtEx.AutoSize = true;
            this.txtEx.Location = new System.Drawing.Point(659, 474);
            this.txtEx.Name = "txtEx";
            this.txtEx.Size = new System.Drawing.Size(20, 15);
            this.txtEx.TabIndex = 26;
            this.txtEx.Text = "0₫";
            // 
            // BillDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 698);
            this.Controls.Add(this.txtEx);
            this.Controls.Add(this.txtCustomerP);
            this.Controls.Add(this.lbEx);
            this.Controls.Add(this.lbCustomerP);
            this.Controls.Add(this.txtCash);
            this.Controls.Add(this.lbCash);
            this.Controls.Add(this.txtVoucher);
            this.Controls.Add(this.txtDiscout);
            this.Controls.Add(this.lbvoucher);
            this.Controls.Add(this.lbDiscout);
            this.Controls.Add(this.txtapCoupon);
            this.Controls.Add(this.txtapDiscout);
            this.Controls.Add(this.lbapCp);
            this.Controls.Add(this.lbapDiscout);
            this.Controls.Add(this.total);
            this.Controls.Add(this.lbaTotal);
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
        private Label lbaTotal;
        private Label total;
        private Label lbapDiscout;
        private Label lbapCp;
        private TextBox txtapDiscout;
        private TextBox txtapCoupon;
        private Label lbDiscout;
        private Label lbvoucher;
        private Label txtDiscout;
        private Label txtVoucher;
        private Label lbCash;
        private Label txtCash;
        private Label lbCustomerP;
        private Label lbEx;
        private TextBox txtCustomerP;
        private Label txtEx;
    }
}