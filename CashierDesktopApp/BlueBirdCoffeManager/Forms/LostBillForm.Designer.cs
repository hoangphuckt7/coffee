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
            this.txtReason = new System.Windows.Forms.TextBox();
            this.lbReason = new System.Windows.Forms.Label();
            this.lostItems = new System.Windows.Forms.DataGridView();
            this.Order = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSubmit = new BlueBirdCoffeManager.Utils.RoundedButton();
            this.lbEmpty = new System.Windows.Forms.Label();
            this.dataPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lostItems)).BeginInit();
            this.SuspendLayout();
            // 
            // dataPanel
            // 
            this.dataPanel.Controls.Add(this.txtReason);
            this.dataPanel.Controls.Add(this.lbReason);
            this.dataPanel.Controls.Add(this.lostItems);
            this.dataPanel.Controls.Add(this.btnSubmit);
            this.dataPanel.Location = new System.Drawing.Point(174, 66);
            this.dataPanel.Name = "dataPanel";
            this.dataPanel.Size = new System.Drawing.Size(413, 330);
            this.dataPanel.TabIndex = 0;
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(115, 226);
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(100, 23);
            this.txtReason.TabIndex = 3;
            // 
            // lbReason
            // 
            this.lbReason.AutoSize = true;
            this.lbReason.Location = new System.Drawing.Point(44, 229);
            this.lbReason.Name = "lbReason";
            this.lbReason.Size = new System.Drawing.Size(38, 15);
            this.lbReason.TabIndex = 2;
            this.lbReason.Text = "Lý do:";
            // 
            // lostItems
            // 
            this.lostItems.AllowUserToAddRows = false;
            this.lostItems.AllowUserToDeleteRows = false;
            this.lostItems.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.lostItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lostItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Order,
            this.name,
            this.quantity});
            this.lostItems.Location = new System.Drawing.Point(80, 23);
            this.lostItems.Name = "lostItems";
            this.lostItems.ReadOnly = true;
            this.lostItems.RowTemplate.Height = 25;
            this.lostItems.Size = new System.Drawing.Size(240, 150);
            this.lostItems.TabIndex = 1;
            // 
            // Order
            // 
            this.Order.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Order.HeaderText = "Order";
            this.Order.Name = "Order";
            this.Order.ReadOnly = true;
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.name.HeaderText = "Tên món";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // quantity
            // 
            this.quantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.quantity.HeaderText = "Số lượng";
            this.quantity.Name = "quantity";
            this.quantity.ReadOnly = true;
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
            this.btnSubmit.Location = new System.Drawing.Point(135, 268);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(150, 40);
            this.btnSubmit.TabIndex = 0;
            this.btnSubmit.Text = "Hoàn tất";
            this.btnSubmit.TextColor = System.Drawing.Color.White;
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lbEmpty
            // 
            this.lbEmpty.AutoSize = true;
            this.lbEmpty.Location = new System.Drawing.Point(327, 520);
            this.lbEmpty.Name = "lbEmpty";
            this.lbEmpty.Size = new System.Drawing.Size(95, 15);
            this.lbEmpty.TabIndex = 1;
            this.lbEmpty.Text = "Không có lịch sử";
            // 
            // LostBillForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 630);
            this.Controls.Add(this.lbEmpty);
            this.Controls.Add(this.dataPanel);
            this.Name = "LostBillForm";
            this.Text = "f";
            this.Load += new System.EventHandler(this.LostBillForm_Load);
            this.dataPanel.ResumeLayout(false);
            this.dataPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lostItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel dataPanel;
        private Utils.RoundedButton btnSubmit;
        private DataGridView lostItems;
        private DataGridViewTextBoxColumn Order;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn quantity;
        private Label lbReason;
        private TextBox txtReason;
        private Label lbEmpty;
    }
}