namespace BlueBirdCoffeManager.Forms
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
            this.tablesPanel = new System.Windows.Forms.Panel();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.lbTotal = new System.Windows.Forms.Label();
            this.lbPrice = new System.Windows.Forms.Label();
            this.lbQuan = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.lbSTT = new System.Windows.Forms.Label();
            this.lostBillPanel = new System.Windows.Forms.Panel();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tablesPanel
            // 
            this.tablesPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.tablesPanel.Location = new System.Drawing.Point(0, 0);
            this.tablesPanel.Name = "tablesPanel";
            this.tablesPanel.Size = new System.Drawing.Size(200, 450);
            this.tablesPanel.TabIndex = 0;
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.lbTotal);
            this.mainPanel.Controls.Add(this.lbPrice);
            this.mainPanel.Controls.Add(this.lbQuan);
            this.mainPanel.Controls.Add(this.lbName);
            this.mainPanel.Controls.Add(this.lbSTT);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(200, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(600, 450);
            this.mainPanel.TabIndex = 1;
            // 
            // lbTotal
            // 
            this.lbTotal.AutoSize = true;
            this.lbTotal.Location = new System.Drawing.Point(348, 42);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(34, 15);
            this.lbTotal.TabIndex = 4;
            this.lbTotal.Text = "Tổng";
            // 
            // lbPrice
            // 
            this.lbPrice.AutoSize = true;
            this.lbPrice.Location = new System.Drawing.Point(244, 42);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(48, 15);
            this.lbPrice.TabIndex = 3;
            this.lbPrice.Text = "Đơn giá";
            // 
            // lbQuan
            // 
            this.lbQuan.AutoSize = true;
            this.lbQuan.Location = new System.Drawing.Point(153, 42);
            this.lbQuan.Name = "lbQuan";
            this.lbQuan.Size = new System.Drawing.Size(54, 15);
            this.lbQuan.TabIndex = 2;
            this.lbQuan.Text = "Số lượng";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(91, 42);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(25, 15);
            this.lbName.TabIndex = 1;
            this.lbName.Text = "Tên";
            // 
            // lbSTT
            // 
            this.lbSTT.AutoSize = true;
            this.lbSTT.Location = new System.Drawing.Point(30, 42);
            this.lbSTT.Name = "lbSTT";
            this.lbSTT.Size = new System.Drawing.Size(25, 15);
            this.lbSTT.TabIndex = 0;
            this.lbSTT.Text = "STT";
            // 
            // lostBillPanel
            // 
            this.lostBillPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.lostBillPanel.Location = new System.Drawing.Point(615, 0);
            this.lostBillPanel.Name = "lostBillPanel";
            this.lostBillPanel.Size = new System.Drawing.Size(185, 450);
            this.lostBillPanel.TabIndex = 2;
            // 
            // BillForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lostBillPanel);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.tablesPanel);
            this.Name = "BillForm";
            this.Text = "BillForm";
            this.Load += new System.EventHandler(this.BillForm_Load);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel tablesPanel;
        private Panel mainPanel;
        private Panel lostBillPanel;
        private Label lbSTT;
        private Label lbTotal;
        private Label lbPrice;
        private Label lbQuan;
        private Label lbName;
    }
}