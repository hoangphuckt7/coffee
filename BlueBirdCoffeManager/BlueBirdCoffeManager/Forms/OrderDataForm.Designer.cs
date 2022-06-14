namespace BlueBirdCoffeManager.Forms
{
    partial class OrderDataForm
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
            this.oFooterPanel = new System.Windows.Forms.Panel();
            this.oDataPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // oFooterPanel
            // 
            this.oFooterPanel.Location = new System.Drawing.Point(302, 345);
            this.oFooterPanel.Name = "oFooterPanel";
            this.oFooterPanel.Size = new System.Drawing.Size(200, 100);
            this.oFooterPanel.TabIndex = 8;
            // 
            // oDataPanel
            // 
            this.oDataPanel.Location = new System.Drawing.Point(299, 5);
            this.oDataPanel.Name = "oDataPanel";
            this.oDataPanel.Size = new System.Drawing.Size(199, 317);
            this.oDataPanel.TabIndex = 7;
            // 
            // OrderDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.oFooterPanel);
            this.Controls.Add(this.oDataPanel);
            this.Name = "OrderDataForm";
            this.Text = "OrderDataForm";
            this.Load += new System.EventHandler(this.OrderDataForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel oFooterPanel;
        private Panel oDataPanel;
    }
}