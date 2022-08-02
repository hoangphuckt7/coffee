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
            this.leftPanel = new System.Windows.Forms.Panel();
            this.oldBillPanel = new System.Windows.Forms.Panel();
            this.pnHistoryTitle = new System.Windows.Forms.Panel();
            this.lbOldOrdersTilte = new System.Windows.Forms.Label();
            this.areaPanel = new System.Windows.Forms.Panel();
            this.areaToolPanel = new System.Windows.Forms.Panel();
            this.lbArea = new System.Windows.Forms.Label();
            this.lbTable = new System.Windows.Forms.Label();
            this.cbTable = new System.Windows.Forms.ComboBox();
            this.cbArea = new System.Windows.Forms.ComboBox();
            this.tableOrderDataPn = new System.Windows.Forms.Panel();
            this.lbTableTotal = new System.Windows.Forms.Label();
            this.lbTablePrice = new System.Windows.Forms.Label();
            this.lbTableQuan = new System.Windows.Forms.Label();
            this.lbTableName = new System.Windows.Forms.Label();
            this.btnAdd = new BlueBirdCoffeManager.Utils.RoundedButton();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.dataBotPanel = new System.Windows.Forms.Panel();
            this.btnCheckout = new BlueBirdCoffeManager.Utils.RoundedButton();
            this.dataPanel = new System.Windows.Forms.Panel();
            this.lbTotal = new System.Windows.Forms.Label();
            this.oldBillPicture = new System.Windows.Forms.PictureBox();
            this.lbName = new System.Windows.Forms.Label();
            this.lbPrice = new System.Windows.Forms.Label();
            this.lbQuan = new System.Windows.Forms.Label();
            this.lbSTT = new System.Windows.Forms.Label();
            this.lostBillPanel = new System.Windows.Forms.Panel();
            this.printBill = new System.Drawing.Printing.PrintDocument();
            this.leftPanel.SuspendLayout();
            this.oldBillPanel.SuspendLayout();
            this.pnHistoryTitle.SuspendLayout();
            this.areaPanel.SuspendLayout();
            this.areaToolPanel.SuspendLayout();
            this.tableOrderDataPn.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.dataBotPanel.SuspendLayout();
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
            this.leftPanel.Size = new System.Drawing.Size(492, 827);
            this.leftPanel.TabIndex = 0;
            // 
            // oldBillPanel
            // 
            this.oldBillPanel.Controls.Add(this.pnHistoryTitle);
            this.oldBillPanel.Location = new System.Drawing.Point(3, 472);
            this.oldBillPanel.Name = "oldBillPanel";
            this.oldBillPanel.Size = new System.Drawing.Size(463, 352);
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
            this.areaPanel.Controls.Add(this.areaToolPanel);
            this.areaPanel.Controls.Add(this.tableOrderDataPn);
            this.areaPanel.Controls.Add(this.btnAdd);
            this.areaPanel.Location = new System.Drawing.Point(0, 12);
            this.areaPanel.Name = "areaPanel";
            this.areaPanel.Size = new System.Drawing.Size(463, 426);
            this.areaPanel.TabIndex = 0;
            this.areaPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.areaPanel_Paint);
            // 
            // areaToolPanel
            // 
            this.areaToolPanel.Controls.Add(this.lbArea);
            this.areaToolPanel.Controls.Add(this.lbTable);
            this.areaToolPanel.Controls.Add(this.cbTable);
            this.areaToolPanel.Controls.Add(this.cbArea);
            this.areaToolPanel.Location = new System.Drawing.Point(16, 12);
            this.areaToolPanel.Name = "areaToolPanel";
            this.areaToolPanel.Size = new System.Drawing.Size(424, 70);
            this.areaToolPanel.TabIndex = 6;
            this.areaToolPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.areaToolPanel_Paint);
            // 
            // lbArea
            // 
            this.lbArea.AutoSize = true;
            this.lbArea.Location = new System.Drawing.Point(9, 23);
            this.lbArea.Name = "lbArea";
            this.lbArea.Size = new System.Drawing.Size(50, 15);
            this.lbArea.TabIndex = 0;
            this.lbArea.Text = "Khu vực";
            // 
            // lbTable
            // 
            this.lbTable.AutoSize = true;
            this.lbTable.Location = new System.Drawing.Point(220, 25);
            this.lbTable.Name = "lbTable";
            this.lbTable.Size = new System.Drawing.Size(27, 15);
            this.lbTable.TabIndex = 1;
            this.lbTable.Text = "Bàn";
            // 
            // cbTable
            // 
            this.cbTable.FormattingEnabled = true;
            this.cbTable.Location = new System.Drawing.Point(273, 23);
            this.cbTable.Name = "cbTable";
            this.cbTable.Size = new System.Drawing.Size(121, 23);
            this.cbTable.TabIndex = 3;
            // 
            // cbArea
            // 
            this.cbArea.FormattingEnabled = true;
            this.cbArea.Location = new System.Drawing.Point(65, 23);
            this.cbArea.Name = "cbArea";
            this.cbArea.Size = new System.Drawing.Size(121, 23);
            this.cbArea.TabIndex = 2;
            // 
            // tableOrderDataPn
            // 
            this.tableOrderDataPn.Controls.Add(this.lbTableTotal);
            this.tableOrderDataPn.Controls.Add(this.lbTablePrice);
            this.tableOrderDataPn.Controls.Add(this.lbTableQuan);
            this.tableOrderDataPn.Controls.Add(this.lbTableName);
            this.tableOrderDataPn.Location = new System.Drawing.Point(8, 97);
            this.tableOrderDataPn.Name = "tableOrderDataPn";
            this.tableOrderDataPn.Size = new System.Drawing.Size(424, 248);
            this.tableOrderDataPn.TabIndex = 5;
            // 
            // lbTableTotal
            // 
            this.lbTableTotal.AutoSize = true;
            this.lbTableTotal.Location = new System.Drawing.Point(321, 17);
            this.lbTableTotal.Name = "lbTableTotal";
            this.lbTableTotal.Size = new System.Drawing.Size(34, 15);
            this.lbTableTotal.TabIndex = 3;
            this.lbTableTotal.Text = "Tổng";
            // 
            // lbTablePrice
            // 
            this.lbTablePrice.AutoSize = true;
            this.lbTablePrice.Location = new System.Drawing.Point(73, 17);
            this.lbTablePrice.Name = "lbTablePrice";
            this.lbTablePrice.Size = new System.Drawing.Size(48, 15);
            this.lbTablePrice.TabIndex = 2;
            this.lbTablePrice.Text = "Đơn giá";
            // 
            // lbTableQuan
            // 
            this.lbTableQuan.AutoSize = true;
            this.lbTableQuan.Location = new System.Drawing.Point(177, 17);
            this.lbTableQuan.Name = "lbTableQuan";
            this.lbTableQuan.Size = new System.Drawing.Size(54, 15);
            this.lbTableQuan.TabIndex = 1;
            this.lbTableQuan.Text = "Số lượng";
            // 
            // lbTableName
            // 
            this.lbTableName.AutoSize = true;
            this.lbTableName.Location = new System.Drawing.Point(17, 17);
            this.lbTableName.Name = "lbTableName";
            this.lbTableName.Size = new System.Drawing.Size(25, 15);
            this.lbTableName.TabIndex = 0;
            this.lbTableName.Text = "Tên";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnAdd.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btnAdd.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnAdd.BorderRadius = 40;
            this.btnAdd.BorderSize = 0;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(25, 368);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(407, 40);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Thêm >>>";
            this.btnAdd.TextColor = System.Drawing.Color.White;
            this.btnAdd.UseVisualStyleBackColor = false;
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.dataBotPanel);
            this.mainPanel.Controls.Add(this.dataPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(492, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1295, 827);
            this.mainPanel.TabIndex = 1;
            // 
            // dataBotPanel
            // 
            this.dataBotPanel.Controls.Add(this.btnCheckout);
            this.dataBotPanel.Location = new System.Drawing.Point(44, 295);
            this.dataBotPanel.Name = "dataBotPanel";
            this.dataBotPanel.Size = new System.Drawing.Size(677, 143);
            this.dataBotPanel.TabIndex = 8;
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
            this.btnCheckout.Location = new System.Drawing.Point(98, 100);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(150, 40);
            this.btnCheckout.TabIndex = 6;
            this.btnCheckout.Text = "Thanh toán";
            this.btnCheckout.TextColor = System.Drawing.Color.White;
            this.btnCheckout.UseVisualStyleBackColor = false;
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);
            // 
            // dataPanel
            // 
            this.dataPanel.Controls.Add(this.lbTotal);
            this.dataPanel.Controls.Add(this.oldBillPicture);
            this.dataPanel.Controls.Add(this.lbName);
            this.dataPanel.Controls.Add(this.lbPrice);
            this.dataPanel.Controls.Add(this.lbQuan);
            this.dataPanel.Controls.Add(this.lbSTT);
            this.dataPanel.Location = new System.Drawing.Point(44, 12);
            this.dataPanel.Name = "dataPanel";
            this.dataPanel.Size = new System.Drawing.Size(696, 277);
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
            // lostBillPanel
            // 
            this.lostBillPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.lostBillPanel.Location = new System.Drawing.Point(1273, 0);
            this.lostBillPanel.Name = "lostBillPanel";
            this.lostBillPanel.Size = new System.Drawing.Size(514, 827);
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
            this.ClientSize = new System.Drawing.Size(1787, 827);
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
            this.areaPanel.ResumeLayout(false);
            this.areaToolPanel.ResumeLayout(false);
            this.areaToolPanel.PerformLayout();
            this.tableOrderDataPn.ResumeLayout(false);
            this.tableOrderDataPn.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.dataBotPanel.ResumeLayout(false);
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
        private Panel dataBotPanel;
        private ComboBox cbTable;
        private ComboBox cbArea;
        private Label lbTable;
        private Label lbArea;
        private Utils.RoundedButton btnAdd;
        private Panel tableOrderDataPn;
        private Panel areaToolPanel;
        private Label lbTableTotal;
        private Label lbTablePrice;
        private Label lbTableQuan;
        private Label lbTableName;
    }
}