﻿namespace BlueBirdCoffeManager.Forms
{
    partial class BillForm
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
            this.leftPanel = new System.Windows.Forms.Panel();
            this.oldBillPanel = new System.Windows.Forms.Panel();
            this.pnHistoryTitle = new System.Windows.Forms.Panel();
            this.lbOldOrdersTilte = new System.Windows.Forms.Label();
            this.areaPanel = new System.Windows.Forms.Panel();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.dataPanel = new System.Windows.Forms.Panel();
            this.lbTotal = new System.Windows.Forms.Label();
            this.oldBillPicture = new System.Windows.Forms.PictureBox();
            this.lbName = new System.Windows.Forms.Label();
            this.lbPrice = new System.Windows.Forms.Label();
            this.lbQuan = new System.Windows.Forms.Label();
            this.lbSTT = new System.Windows.Forms.Label();
            this.btnCheckout = new BlueBirdCoffeManager.Utils.RoundedButton();
            this.lostBillPanel = new System.Windows.Forms.Panel();
            this.printBill = new System.Drawing.Printing.PrintDocument();
            this.leftPanel.SuspendLayout();
            this.oldBillPanel.SuspendLayout();
            this.pnHistoryTitle.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.dataPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.oldBillPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // leftPanel
            // 
            this.leftPanel.Controls.Add(this.oldBillPanel);
            this.leftPanel.Controls.Add(this.areaPanel);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftPanel.Location = new System.Drawing.Point(0, 0);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(200, 450);
            this.leftPanel.TabIndex = 0;
            // 
            // oldBillPanel
            // 
            this.oldBillPanel.Controls.Add(this.pnHistoryTitle);
            this.oldBillPanel.Location = new System.Drawing.Point(0, 235);
            this.oldBillPanel.Name = "oldBillPanel";
            this.oldBillPanel.Size = new System.Drawing.Size(200, 203);
            this.oldBillPanel.TabIndex = 1;
            // 
            // pnHistoryTitle
            // 
            this.pnHistoryTitle.Controls.Add(this.lbOldOrdersTilte);
            this.pnHistoryTitle.Location = new System.Drawing.Point(3, 3);
            this.pnHistoryTitle.Name = "pnHistoryTitle";
            this.pnHistoryTitle.Size = new System.Drawing.Size(191, 38);
            this.pnHistoryTitle.TabIndex = 1;
            this.pnHistoryTitle.Paint += new System.Windows.Forms.PaintEventHandler(this.pnHistoryTitle_Paint);
            // 
            // lbOldOrdersTilte
            // 
            this.lbOldOrdersTilte.AutoSize = true;
            this.lbOldOrdersTilte.Location = new System.Drawing.Point(66, 11);
            this.lbOldOrdersTilte.Name = "lbOldOrdersTilte";
            this.lbOldOrdersTilte.Size = new System.Drawing.Size(44, 15);
            this.lbOldOrdersTilte.TabIndex = 0;
            this.lbOldOrdersTilte.Text = "Lịch sử";
            // 
            // areaPanel
            // 
            this.areaPanel.Location = new System.Drawing.Point(0, 12);
            this.areaPanel.Name = "areaPanel";
            this.areaPanel.Size = new System.Drawing.Size(200, 217);
            this.areaPanel.TabIndex = 0;
            this.areaPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.areaPanel_Paint);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.dataPanel);
            this.mainPanel.Controls.Add(this.btnCheckout);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(200, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(600, 450);
            this.mainPanel.TabIndex = 1;
            // 
            // dataPanel
            // 
            this.dataPanel.Controls.Add(this.lbTotal);
            this.dataPanel.Controls.Add(this.oldBillPicture);
            this.dataPanel.Controls.Add(this.lbName);
            this.dataPanel.Controls.Add(this.lbPrice);
            this.dataPanel.Controls.Add(this.lbQuan);
            this.dataPanel.Controls.Add(this.lbSTT);
            this.dataPanel.Location = new System.Drawing.Point(44, 52);
            this.dataPanel.Name = "dataPanel";
            this.dataPanel.Size = new System.Drawing.Size(330, 301);
            this.dataPanel.TabIndex = 7;
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
            this.oldBillPicture.Paint += new System.Windows.Forms.PaintEventHandler(this.oldBillPicture_Paint);
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
            this.btnCheckout.Location = new System.Drawing.Point(107, 382);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(150, 40);
            this.btnCheckout.TabIndex = 6;
            this.btnCheckout.Text = "Thanh toán";
            this.btnCheckout.TextColor = System.Drawing.Color.White;
            this.btnCheckout.UseVisualStyleBackColor = false;
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);
            // 
            // lostBillPanel
            // 
            this.lostBillPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.lostBillPanel.Location = new System.Drawing.Point(615, 0);
            this.lostBillPanel.Name = "lostBillPanel";
            this.lostBillPanel.Size = new System.Drawing.Size(185, 450);
            this.lostBillPanel.TabIndex = 2;
            // 
            // printBill
            // 
            this.printBill.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printBill_PrintPage);
            // 
            // BillForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lostBillPanel);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.leftPanel);
            this.Name = "BillForm";
            this.Text = "BillForm";
            this.Load += new System.EventHandler(this.BillForm_Load);
            this.leftPanel.ResumeLayout(false);
            this.oldBillPanel.ResumeLayout(false);
            this.pnHistoryTitle.ResumeLayout(false);
            this.pnHistoryTitle.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.dataPanel.ResumeLayout(false);
            this.dataPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.oldBillPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel leftPanel;
        private Panel mainPanel;
        private Panel lostBillPanel;
        private Panel oldBillPanel;
        private Panel areaPanel;
        private Label lbOldOrdersTilte;
        private Utils.RoundedButton btnCheckout;
        private Panel dataPanel;
        private Label lbTotal;
        private PictureBox oldBillPicture;
        private Label lbPrice;
        private Label lbQuan;
        private Label lbSTT;
        private Label lbName;
        private System.Drawing.Printing.PrintDocument printBill;
        private Panel pnHistoryTitle;
    }
}