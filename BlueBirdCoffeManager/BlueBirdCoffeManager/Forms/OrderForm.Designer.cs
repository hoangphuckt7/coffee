namespace BlueBirdCoffeManager.Forms
{
    partial class OrderForm
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
            this.orderPanel = new System.Windows.Forms.Panel();
            this.itemPanel = new System.Windows.Forms.Panel();
            this.itemDataPanel = new System.Windows.Forms.Panel();
            this.toolboxPanel = new System.Windows.Forms.Panel();
            this.lbCategory = new System.Windows.Forms.Label();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.lbSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.itemPanel.SuspendLayout();
            this.toolboxPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // orderPanel
            // 
            this.orderPanel.Location = new System.Drawing.Point(18, 9);
            this.orderPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.orderPanel.Name = "orderPanel";
            this.orderPanel.Size = new System.Drawing.Size(219, 320);
            this.orderPanel.TabIndex = 0;
            // 
            // itemPanel
            // 
            this.itemPanel.Controls.Add(this.itemDataPanel);
            this.itemPanel.Controls.Add(this.toolboxPanel);
            this.itemPanel.Location = new System.Drawing.Point(242, 9);
            this.itemPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemPanel.Name = "itemPanel";
            this.itemPanel.Size = new System.Drawing.Size(447, 320);
            this.itemPanel.TabIndex = 1;
            // 
            // itemDataPanel
            // 
            this.itemDataPanel.Location = new System.Drawing.Point(38, 100);
            this.itemDataPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemDataPanel.Name = "itemDataPanel";
            this.itemDataPanel.Size = new System.Drawing.Size(219, 94);
            this.itemDataPanel.TabIndex = 1;
            // 
            // toolboxPanel
            // 
            this.toolboxPanel.Controls.Add(this.lbCategory);
            this.toolboxPanel.Controls.Add(this.cbCategory);
            this.toolboxPanel.Controls.Add(this.lbSearch);
            this.toolboxPanel.Controls.Add(this.txtSearch);
            this.toolboxPanel.Location = new System.Drawing.Point(25, 14);
            this.toolboxPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.toolboxPanel.Name = "toolboxPanel";
            this.toolboxPanel.Size = new System.Drawing.Size(419, 55);
            this.toolboxPanel.TabIndex = 0;
            this.toolboxPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.toolboxPanel_Paint);
            // 
            // lbCategory
            // 
            this.lbCategory.AutoSize = true;
            this.lbCategory.Location = new System.Drawing.Point(239, 16);
            this.lbCategory.Name = "lbCategory";
            this.lbCategory.Size = new System.Drawing.Size(29, 15);
            this.lbCategory.TabIndex = 3;
            this.lbCategory.Text = "Loại";
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(276, 14);
            this.cbCategory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(133, 23);
            this.cbCategory.TabIndex = 2;
            this.cbCategory.SelectedIndexChanged += new System.EventHandler(this.cbCategory_SelectedIndexChanged);
            // 
            // lbSearch
            // 
            this.lbSearch.AutoSize = true;
            this.lbSearch.Location = new System.Drawing.Point(13, 19);
            this.lbSearch.Name = "lbSearch";
            this.lbSearch.Size = new System.Drawing.Size(56, 15);
            this.lbSearch.TabIndex = 1;
            this.lbSearch.Text = "Tìm kiếm";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(80, 14);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(110, 23);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 338);
            this.Controls.Add(this.itemPanel);
            this.Controls.Add(this.orderPanel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "OrderForm";
            this.Text = "OrderForm";
            this.Load += new System.EventHandler(this.OrderForm_Load);
            this.itemPanel.ResumeLayout(false);
            this.toolboxPanel.ResumeLayout(false);
            this.toolboxPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel orderPanel;
        private Panel itemPanel;
        private Panel itemDataPanel;
        private Panel toolboxPanel;
        private Label lbCategory;
        private ComboBox cbCategory;
        private Label lbSearch;
        private TextBox txtSearch;
    }
}