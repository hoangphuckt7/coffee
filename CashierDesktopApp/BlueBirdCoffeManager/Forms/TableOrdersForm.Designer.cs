namespace BlueBirdCoffeManager.Forms
{
    partial class TableOrdersForm
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
            this.mainData = new System.Windows.Forms.Panel();
            this.pnButton = new System.Windows.Forms.Panel();
            this.btnCheckoutAll = new BlueBirdCoffeManager.Utils.RoundedButton();
            this.btnCheckout = new BlueBirdCoffeManager.Utils.RoundedButton();
            this.btnEdit = new BlueBirdCoffeManager.Utils.RoundedButton();
            this.pnButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainData
            // 
            this.mainData.Location = new System.Drawing.Point(12, 24);
            this.mainData.Name = "mainData";
            this.mainData.Size = new System.Drawing.Size(329, 308);
            this.mainData.TabIndex = 0;
            this.mainData.Paint += new System.Windows.Forms.PaintEventHandler(this.mainData_Paint);
            // 
            // pnButton
            // 
            this.pnButton.Controls.Add(this.btnCheckoutAll);
            this.pnButton.Controls.Add(this.btnCheckout);
            this.pnButton.Controls.Add(this.btnEdit);
            this.pnButton.Location = new System.Drawing.Point(12, 338);
            this.pnButton.Name = "pnButton";
            this.pnButton.Size = new System.Drawing.Size(329, 100);
            this.pnButton.TabIndex = 1;
            // 
            // btnCheckoutAll
            // 
            this.btnCheckoutAll.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnCheckoutAll.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btnCheckoutAll.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnCheckoutAll.BorderRadius = 40;
            this.btnCheckoutAll.BorderSize = 0;
            this.btnCheckoutAll.FlatAppearance.BorderSize = 0;
            this.btnCheckoutAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckoutAll.ForeColor = System.Drawing.Color.White;
            this.btnCheckoutAll.Location = new System.Drawing.Point(3, 49);
            this.btnCheckoutAll.Name = "btnCheckoutAll";
            this.btnCheckoutAll.Size = new System.Drawing.Size(323, 40);
            this.btnCheckoutAll.TabIndex = 2;
            this.btnCheckoutAll.Text = "Thanh toán tất cả";
            this.btnCheckoutAll.TextColor = System.Drawing.Color.White;
            this.btnCheckoutAll.UseVisualStyleBackColor = false;
            this.btnCheckoutAll.Visible = false;
            this.btnCheckoutAll.Click += new System.EventHandler(this.btnCheckoutAll_Click);
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
            this.btnCheckout.Location = new System.Drawing.Point(176, 3);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(150, 40);
            this.btnCheckout.TabIndex = 1;
            this.btnCheckout.Text = "Thanh Toán";
            this.btnCheckout.TextColor = System.Drawing.Color.White;
            this.btnCheckout.UseVisualStyleBackColor = false;
            this.btnCheckout.Visible = false;
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);
            // 
            // btnRemove
            // 
            this.btnEdit.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnEdit.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btnEdit.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnEdit.BorderRadius = 40;
            this.btnEdit.BorderSize = 0;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(3, 3);
            this.btnEdit.Name = "btnRemove";
            this.btnEdit.Size = new System.Drawing.Size(167, 40);
            this.btnEdit.TabIndex = 0;
            this.btnEdit.Text = "Thêm món";
            this.btnEdit.TextColor = System.Drawing.Color.White;
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Visible = false;
            this.btnEdit.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // TableOrdersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 450);
            this.Controls.Add(this.pnButton);
            this.Controls.Add(this.mainData);
            this.Name = "TableOrdersForm";
            this.Text = "TableOrdersForm";
            this.Load += new System.EventHandler(this.TableOrdersForm_LoadAsync);
            this.pnButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel mainData;
        private Panel pnButton;
        private Utils.RoundedButton btnCheckoutAll;
        private Utils.RoundedButton btnCheckout;
        private Utils.RoundedButton btnEdit;
    }
}