namespace BlueBirdCoffeManager.Forms
{
    partial class TableDataForm
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.rbtnEdit = new BlueBirdCoffeManager.Utils.RoundedButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(12, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(786, 435);
            this.pictureBox.TabIndex = 2;
            this.pictureBox.TabStop = false;
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
            // 
            // rbtnEdit
            // 
            this.rbtnEdit.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.rbtnEdit.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.rbtnEdit.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rbtnEdit.BorderRadius = 40;
            this.rbtnEdit.BorderSize = 0;
            this.rbtnEdit.FlatAppearance.BorderSize = 0;
            this.rbtnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnEdit.ForeColor = System.Drawing.Color.White;
            this.rbtnEdit.Location = new System.Drawing.Point(595, 362);
            this.rbtnEdit.Name = "rbtnEdit";
            this.rbtnEdit.Size = new System.Drawing.Size(150, 40);
            this.rbtnEdit.TabIndex = 3;
            this.rbtnEdit.Text = "roundedButton1";
            this.rbtnEdit.TextColor = System.Drawing.Color.White;
            this.rbtnEdit.UseVisualStyleBackColor = false;
            this.rbtnEdit.Click += new System.EventHandler(this.rbtnEdit_Click_1);
            // 
            // TableDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 458);
            this.Controls.Add(this.rbtnEdit);
            this.Controls.Add(this.pictureBox);
            this.Name = "TableDataForm";
            this.Text = "TableDataForm";
            this.Load += new System.EventHandler(this.TableDataForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private PictureBox pictureBox;
        private Utils.RoundedButton rbtnEdit;
    }
}