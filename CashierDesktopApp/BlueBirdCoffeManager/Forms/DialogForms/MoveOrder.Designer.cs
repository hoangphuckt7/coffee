namespace BlueBirdCoffeManager.Forms.DialogForms
{
    partial class MoveOrder
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
            this.lbArea = new System.Windows.Forms.Label();
            this.lbTable = new System.Windows.Forms.Label();
            this.cbArea = new System.Windows.Forms.ComboBox();
            this.cbTable = new System.Windows.Forms.ComboBox();
            this.btnMove = new BlueBirdCoffeManager.Utils.RoundedButton();
            this.SuspendLayout();
            // 
            // lbArea
            // 
            this.lbArea.AutoSize = true;
            this.lbArea.Location = new System.Drawing.Point(183, 132);
            this.lbArea.Name = "lbArea";
            this.lbArea.Size = new System.Drawing.Size(50, 15);
            this.lbArea.TabIndex = 0;
            this.lbArea.Text = "Khu vực";
            // 
            // lbTable
            // 
            this.lbTable.AutoSize = true;
            this.lbTable.Location = new System.Drawing.Point(194, 208);
            this.lbTable.Name = "lbTable";
            this.lbTable.Size = new System.Drawing.Size(27, 15);
            this.lbTable.TabIndex = 1;
            this.lbTable.Text = "Bàn";
            // 
            // cbArea
            // 
            this.cbArea.FormattingEnabled = true;
            this.cbArea.Location = new System.Drawing.Point(317, 129);
            this.cbArea.Name = "cbArea";
            this.cbArea.Size = new System.Drawing.Size(121, 23);
            this.cbArea.TabIndex = 2;
            this.cbArea.SelectedIndexChanged += new System.EventHandler(this.cbArea_SelectedIndexChanged);
            // 
            // cbTable
            // 
            this.cbTable.FormattingEnabled = true;
            this.cbTable.Location = new System.Drawing.Point(317, 208);
            this.cbTable.Name = "cbTable";
            this.cbTable.Size = new System.Drawing.Size(121, 23);
            this.cbTable.TabIndex = 3;
            // 
            // btnMove
            // 
            this.btnMove.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnMove.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btnMove.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnMove.BorderRadius = 40;
            this.btnMove.BorderSize = 0;
            this.btnMove.FlatAppearance.BorderSize = 0;
            this.btnMove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMove.ForeColor = System.Drawing.Color.White;
            this.btnMove.Location = new System.Drawing.Point(306, 297);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(150, 40);
            this.btnMove.TabIndex = 4;
            this.btnMove.Text = "Chuyển";
            this.btnMove.TextColor = System.Drawing.Color.White;
            this.btnMove.UseVisualStyleBackColor = false;
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // MoveOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnMove);
            this.Controls.Add(this.cbTable);
            this.Controls.Add(this.cbArea);
            this.Controls.Add(this.lbTable);
            this.Controls.Add(this.lbArea);
            this.Name = "MoveOrder";
            this.Text = "Chuyển đơn tới bàn";
            this.Load += new System.EventHandler(this.MoveOrder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lbArea;
        private Label lbTable;
        private ComboBox cbArea;
        private ComboBox cbTable;
        private Utils.RoundedButton btnMove;
    }
}