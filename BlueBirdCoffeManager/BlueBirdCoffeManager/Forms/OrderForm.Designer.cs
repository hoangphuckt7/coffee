﻿namespace BlueBirdCoffeManager.Forms
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
            this.oHeaderPanel = new System.Windows.Forms.Panel();
            this.lbPrice = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.lbSubTotal = new System.Windows.Forms.Label();
            this.lbQuantity = new System.Windows.Forms.Label();
            this.oDataPanel = new System.Windows.Forms.Panel();
            this.itemPanel = new System.Windows.Forms.Panel();
            this.itemDataPanel = new System.Windows.Forms.Panel();
            this.toolboxPanel = new System.Windows.Forms.Panel();
            this.btnRemoveFilter = new BlueBirdCoffeManager.Utils.RoundedButton();
            this.lbCategory = new System.Windows.Forms.Label();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.lbSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.oFooterPanel = new System.Windows.Forms.Panel();
            this.orderPanel.SuspendLayout();
            this.oHeaderPanel.SuspendLayout();
            this.itemPanel.SuspendLayout();
            this.toolboxPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // orderPanel
            // 
            this.orderPanel.Controls.Add(this.oFooterPanel);
            this.orderPanel.Controls.Add(this.oHeaderPanel);
            this.orderPanel.Controls.Add(this.oDataPanel);
            this.orderPanel.Location = new System.Drawing.Point(18, 9);
            this.orderPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.orderPanel.Name = "orderPanel";
            this.orderPanel.Size = new System.Drawing.Size(219, 538);
            this.orderPanel.TabIndex = 0;
            // 
            // oHeaderPanel
            // 
            this.oHeaderPanel.Controls.Add(this.lbPrice);
            this.oHeaderPanel.Controls.Add(this.lbName);
            this.oHeaderPanel.Controls.Add(this.lbSubTotal);
            this.oHeaderPanel.Controls.Add(this.lbQuantity);
            this.oHeaderPanel.Location = new System.Drawing.Point(5, 35);
            this.oHeaderPanel.Name = "oHeaderPanel";
            this.oHeaderPanel.Size = new System.Drawing.Size(200, 25);
            this.oHeaderPanel.TabIndex = 5;
            // 
            // lbPrice
            // 
            this.lbPrice.AutoSize = true;
            this.lbPrice.Location = new System.Drawing.Point(104, 6);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(48, 15);
            this.lbPrice.TabIndex = 2;
            this.lbPrice.Text = "Đơn giá";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(3, 6);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(25, 15);
            this.lbName.TabIndex = 0;
            this.lbName.Text = "Tên";
            // 
            // lbSubTotal
            // 
            this.lbSubTotal.AutoSize = true;
            this.lbSubTotal.Location = new System.Drawing.Point(165, 6);
            this.lbSubTotal.Name = "lbSubTotal";
            this.lbSubTotal.Size = new System.Drawing.Size(34, 15);
            this.lbSubTotal.TabIndex = 3;
            this.lbSubTotal.Text = "Tổng";
            // 
            // lbQuantity
            // 
            this.lbQuantity.AutoSize = true;
            this.lbQuantity.Location = new System.Drawing.Point(44, 6);
            this.lbQuantity.Name = "lbQuantity";
            this.lbQuantity.Size = new System.Drawing.Size(54, 15);
            this.lbQuantity.TabIndex = 1;
            this.lbQuantity.Text = "Số lượng";
            // 
            // oDataPanel
            // 
            this.oDataPanel.Location = new System.Drawing.Point(5, 77);
            this.oDataPanel.Name = "oDataPanel";
            this.oDataPanel.Size = new System.Drawing.Size(199, 317);
            this.oDataPanel.TabIndex = 4;
            // 
            // itemPanel
            // 
            this.itemPanel.Controls.Add(this.itemDataPanel);
            this.itemPanel.Controls.Add(this.toolboxPanel);
            this.itemPanel.Location = new System.Drawing.Point(242, 9);
            this.itemPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemPanel.Name = "itemPanel";
            this.itemPanel.Size = new System.Drawing.Size(958, 538);
            this.itemPanel.TabIndex = 1;
            // 
            // itemDataPanel
            // 
            this.itemDataPanel.Location = new System.Drawing.Point(25, 93);
            this.itemDataPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemDataPanel.Name = "itemDataPanel";
            this.itemDataPanel.Size = new System.Drawing.Size(930, 424);
            this.itemDataPanel.TabIndex = 1;
            // 
            // toolboxPanel
            // 
            this.toolboxPanel.Controls.Add(this.btnRemoveFilter);
            this.toolboxPanel.Controls.Add(this.lbCategory);
            this.toolboxPanel.Controls.Add(this.cbCategory);
            this.toolboxPanel.Controls.Add(this.lbSearch);
            this.toolboxPanel.Controls.Add(this.txtSearch);
            this.toolboxPanel.Location = new System.Drawing.Point(25, 14);
            this.toolboxPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.toolboxPanel.Name = "toolboxPanel";
            this.toolboxPanel.Size = new System.Drawing.Size(930, 55);
            this.toolboxPanel.TabIndex = 0;
            this.toolboxPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.toolboxPanel_Paint);
            // 
            // btnRemoveFilter
            // 
            this.btnRemoveFilter.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnRemoveFilter.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btnRemoveFilter.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnRemoveFilter.BorderRadius = 40;
            this.btnRemoveFilter.BorderSize = 0;
            this.btnRemoveFilter.FlatAppearance.BorderSize = 0;
            this.btnRemoveFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveFilter.ForeColor = System.Drawing.Color.White;
            this.btnRemoveFilter.Location = new System.Drawing.Point(440, 6);
            this.btnRemoveFilter.Name = "btnRemoveFilter";
            this.btnRemoveFilter.Size = new System.Drawing.Size(150, 40);
            this.btnRemoveFilter.TabIndex = 4;
            this.btnRemoveFilter.Text = "Xóa lọc";
            this.btnRemoveFilter.TextColor = System.Drawing.Color.White;
            this.btnRemoveFilter.UseVisualStyleBackColor = false;
            this.btnRemoveFilter.Click += new System.EventHandler(this.roundedButton1_Click);
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
            // oFooterPanel
            // 
            this.oFooterPanel.Location = new System.Drawing.Point(8, 417);
            this.oFooterPanel.Name = "oFooterPanel";
            this.oFooterPanel.Size = new System.Drawing.Size(200, 100);
            this.oFooterPanel.TabIndex = 6;
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1212, 558);
            this.Controls.Add(this.itemPanel);
            this.Controls.Add(this.orderPanel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "OrderForm";
            this.Text = "OrderForm";
            this.Load += new System.EventHandler(this.OrderForm_Load);
            this.orderPanel.ResumeLayout(false);
            this.oHeaderPanel.ResumeLayout(false);
            this.oHeaderPanel.PerformLayout();
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
        private Utils.RoundedButton btnRemoveFilter;
        private Label lbSubTotal;
        private Label lbPrice;
        private Label lbQuantity;
        private Label lbName;
        private Panel oDataPanel;
        private Panel oHeaderPanel;
        private Panel oFooterPanel;
    }
}