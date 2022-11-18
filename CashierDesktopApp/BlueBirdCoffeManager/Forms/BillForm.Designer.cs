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
            this.oldBillPanel = new System.Windows.Forms.Panel();
            this.areaPanel = new System.Windows.Forms.Panel();
            this.btnSetMissing = new BlueBirdCoffeManager.Utils.RoundedButton();
            this.areaToolPanel = new System.Windows.Forms.Panel();
            this.lbArea = new System.Windows.Forms.Label();
            this.lbTable = new System.Windows.Forms.Label();
            this.cbTable = new System.Windows.Forms.ComboBox();
            this.cbArea = new System.Windows.Forms.ComboBox();
            this.tableOrderDataPn = new System.Windows.Forms.Panel();
            this.btnAdd = new BlueBirdCoffeManager.Utils.RoundedButton();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.lostBillPanel = new System.Windows.Forms.Panel();
            this.areaPanel.SuspendLayout();
            this.areaToolPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // oldBillPanel
            // 
            this.oldBillPanel.Location = new System.Drawing.Point(1264, 79);
            this.oldBillPanel.Name = "oldBillPanel";
            this.oldBillPanel.Size = new System.Drawing.Size(440, 192);
            this.oldBillPanel.TabIndex = 1;
            // 
            // areaPanel
            // 
            this.areaPanel.Controls.Add(this.btnSetMissing);
            this.areaPanel.Controls.Add(this.areaToolPanel);
            this.areaPanel.Controls.Add(this.tableOrderDataPn);
            this.areaPanel.Controls.Add(this.btnAdd);
            this.areaPanel.Location = new System.Drawing.Point(120, 24);
            this.areaPanel.Name = "areaPanel";
            this.areaPanel.Size = new System.Drawing.Size(440, 407);
            this.areaPanel.TabIndex = 0;
            // 
            // btnSetMissing
            // 
            this.btnSetMissing.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnSetMissing.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btnSetMissing.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnSetMissing.BorderRadius = 40;
            this.btnSetMissing.BorderSize = 0;
            this.btnSetMissing.FlatAppearance.BorderSize = 0;
            this.btnSetMissing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetMissing.ForeColor = System.Drawing.Color.White;
            this.btnSetMissing.Location = new System.Drawing.Point(0, 364);
            this.btnSetMissing.Name = "btnSetMissing";
            this.btnSetMissing.Size = new System.Drawing.Size(90, 40);
            this.btnSetMissing.TabIndex = 7;
            this.btnSetMissing.Text = "Hủy đơn";
            this.btnSetMissing.TextColor = System.Drawing.Color.White;
            this.btnSetMissing.UseVisualStyleBackColor = false;
            this.btnSetMissing.Click += new System.EventHandler(this.btnSetMissing_Click);
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
            this.cbTable.SelectedIndexChanged += new System.EventHandler(this.cbTable_SelectedIndexChanged);
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
            this.tableOrderDataPn.Location = new System.Drawing.Point(8, 97);
            this.tableOrderDataPn.Name = "tableOrderDataPn";
            this.tableOrderDataPn.Size = new System.Drawing.Size(424, 248);
            this.tableOrderDataPn.TabIndex = 5;
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
            this.btnAdd.Location = new System.Drawing.Point(96, 368);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(336, 40);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Thêm toàn bộ>>>";
            this.btnAdd.TextColor = System.Drawing.Color.White;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Location = new System.Drawing.Point(667, 118);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(464, 407);
            this.mainPanel.TabIndex = 1;
            // 
            // lostBillPanel
            // 
            this.lostBillPanel.Location = new System.Drawing.Point(120, 467);
            this.lostBillPanel.Name = "lostBillPanel";
            this.lostBillPanel.Size = new System.Drawing.Size(446, 312);
            this.lostBillPanel.TabIndex = 2;
            // 
            // BillForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1787, 827);
            this.Controls.Add(this.oldBillPanel);
            this.Controls.Add(this.lostBillPanel);
            this.Controls.Add(this.areaPanel);
            this.Controls.Add(this.mainPanel);
            this.Name = "BillForm";
            this.Text = "BillForm";
            this.Load += new System.EventHandler(this.BillForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.BillForm_Paint);
            this.areaPanel.ResumeLayout(false);
            this.areaToolPanel.ResumeLayout(false);
            this.areaToolPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Panel mainPanel;
        private Panel lostBillPanel;
        private Panel oldBillPanel;
        private Panel areaPanel;
        private ComboBox cbTable;
        private ComboBox cbArea;
        private Label lbTable;
        private Label lbArea;
        private Utils.RoundedButton btnAdd;
        private Panel tableOrderDataPn;
        private Panel areaToolPanel;
        private Utils.RoundedButton btnSetMissing;
    }
}