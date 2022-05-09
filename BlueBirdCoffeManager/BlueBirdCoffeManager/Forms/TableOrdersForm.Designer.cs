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
            this.SuspendLayout();
            // 
            // mainData
            // 
            this.mainData.Location = new System.Drawing.Point(91, 73);
            this.mainData.Name = "mainData";
            this.mainData.Size = new System.Drawing.Size(200, 100);
            this.mainData.TabIndex = 0;
            this.mainData.Paint += new System.Windows.Forms.PaintEventHandler(this.mainData_Paint);
            // 
            // TableOrdersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainData);
            this.Name = "TableOrdersForm";
            this.Text = "TableOrdersForm";
            this.Load += new System.EventHandler(this.TableOrdersForm_LoadAsync);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel mainData;
    }
}