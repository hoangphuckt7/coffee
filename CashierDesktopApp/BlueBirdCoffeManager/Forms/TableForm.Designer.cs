namespace BlueBirdCoffeManager.Forms
{
    partial class TableForm
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
            this.floorPanel = new System.Windows.Forms.Panel();
            this.lbOrder = new System.Windows.Forms.Label();
            this.lbArea = new System.Windows.Forms.Label();
            this.cbFloors = new System.Windows.Forms.ComboBox();
            this.areaPanel = new System.Windows.Forms.Panel();
            this.tableOrderPanel = new System.Windows.Forms.Panel();
            this.tablePanel = new System.Windows.Forms.Panel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.floorPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // floorPanel
            // 
            this.floorPanel.Controls.Add(this.lbOrder);
            this.floorPanel.Controls.Add(this.lbArea);
            this.floorPanel.Controls.Add(this.cbFloors);
            this.floorPanel.Controls.Add(this.areaPanel);
            this.floorPanel.Controls.Add(this.tableOrderPanel);
            this.floorPanel.Location = new System.Drawing.Point(46, 52);
            this.floorPanel.Name = "floorPanel";
            this.floorPanel.Size = new System.Drawing.Size(200, 378);
            this.floorPanel.TabIndex = 0;
            // 
            // lbOrder
            // 
            this.lbOrder.AutoSize = true;
            this.lbOrder.Location = new System.Drawing.Point(70, 107);
            this.lbOrder.Name = "lbOrder";
            this.lbOrder.Size = new System.Drawing.Size(53, 15);
            this.lbOrder.TabIndex = 4;
            this.lbOrder.Text = "Hóa đơn";
            this.lbOrder.Visible = false;
            // 
            // lbArea
            // 
            this.lbArea.AutoSize = true;
            this.lbArea.Location = new System.Drawing.Point(73, 14);
            this.lbArea.Name = "lbArea";
            this.lbArea.Size = new System.Drawing.Size(50, 15);
            this.lbArea.TabIndex = 1;
            this.lbArea.Text = "Khu vực";
            this.lbArea.Visible = false;
            // 
            // cbFloors
            // 
            this.cbFloors.FormattingEnabled = true;
            this.cbFloors.Location = new System.Drawing.Point(41, 46);
            this.cbFloors.Name = "cbFloors";
            this.cbFloors.Size = new System.Drawing.Size(121, 23);
            this.cbFloors.TabIndex = 0;
            this.cbFloors.Visible = false;
            this.cbFloors.SelectedIndexChanged += new System.EventHandler(this.cbFloors_SelectedIndexChanged);
            // 
            // areaPanel
            // 
            this.areaPanel.Location = new System.Drawing.Point(22, 32);
            this.areaPanel.Name = "areaPanel";
            this.areaPanel.Size = new System.Drawing.Size(155, 72);
            this.areaPanel.TabIndex = 2;
            this.areaPanel.Visible = false;
            this.areaPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.areaPanel_Paint);
            // 
            // tableOrderPanel
            // 
            this.tableOrderPanel.Location = new System.Drawing.Point(22, 129);
            this.tableOrderPanel.Name = "tableOrderPanel";
            this.tableOrderPanel.Size = new System.Drawing.Size(155, 231);
            this.tableOrderPanel.TabIndex = 3;
            this.tableOrderPanel.Visible = false;
            this.tableOrderPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.tableOrderPanel_Paint);
            // 
            // tablePanel
            // 
            this.tablePanel.Location = new System.Drawing.Point(268, 52);
            this.tablePanel.Name = "tablePanel";
            this.tablePanel.Size = new System.Drawing.Size(504, 378);
            this.tablePanel.TabIndex = 1;
            // 
            // TableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tablePanel);
            this.Controls.Add(this.floorPanel);
            this.Name = "TableForm";
            this.Text = "TableForm";
            this.Load += new System.EventHandler(this.TableForm_Load);
            this.floorPanel.ResumeLayout(false);
            this.floorPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel floorPanel;
        private Panel tablePanel;
        private ComboBox cbFloors;
        private Label lbArea;
        private Panel areaPanel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Panel tableOrderPanel;
        private Label lbOrder;
    }
}