namespace BlueBirdCoffeManager.Forms.DialogForms
{
    partial class SetMissingOrderForm
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
            this.btnSubmit = new BlueBirdCoffeManager.Utils.RoundedButton();
            this.lbReason = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
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
            this.btnSubmit.Location = new System.Drawing.Point(316, 361);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(150, 40);
            this.btnSubmit.TabIndex = 0;
            this.btnSubmit.Text = "Xác nhận";
            this.btnSubmit.TextColor = System.Drawing.Color.White;
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lbReason
            // 
            this.lbReason.AutoSize = true;
            this.lbReason.Location = new System.Drawing.Point(148, 196);
            this.lbReason.Name = "lbReason";
            this.lbReason.Size = new System.Drawing.Size(35, 15);
            this.lbReason.TabIndex = 1;
            this.lbReason.Text = "Lý do";
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(316, 196);
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(100, 23);
            this.txtReason.TabIndex = 2;
            // 
            // SetMissingOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtReason);
            this.Controls.Add(this.lbReason);
            this.Controls.Add(this.btnSubmit);
            this.Name = "SetMissingOrderForm";
            this.Text = "Nhập lý do hủy đơn";
            this.Load += new System.EventHandler(this.SetMissingOrderForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Utils.RoundedButton btnSubmit;
        private Label lbReason;
        private TextBox txtReason;
    }
}