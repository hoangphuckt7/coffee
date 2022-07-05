using BlueBirdCoffeManager.DataAccessLayer;
using BlueBirdCoffeManager.Models;
using BlueBirdCoffeManager.Sessions;
using BlueBirdCoffeManager.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlueBirdCoffeManager.Forms
{
    public partial class OrderForm : Form
    {
        private List<DescriptionViewModel> CATEGORIES = new();
        private int CATEGORY_INDEX = 0;

        public OrderForm()
        {
            InitializeComponent();
        }

        private async void OrderForm_Load(object sender, EventArgs e)
        {
            #region Item screen setup
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.MaximizeBox = false;

            //Disable everything
            this.orderPanel.Visible = false;
            this.itemPanel.Visible = false;
            this.toolboxPanel.Visible = false;
            this.itemDataPanel.Visible = false;
            this.cbCategory.Visible = false;
            this.lbCategory.Visible = false;
            this.txtSearch.Visible = false;
            this.btnRemoveFilter.Visible = false;
            this.cbDetails.Visible = false;

            this.orderPanel.Left = 0;
            this.orderPanel.Top = 0;
            this.orderPanel.Size = new Size(Width * 30 / 100, Height);
            //this.orderPanel.BackColor = Color.Black;

            this.itemPanel.Left = orderPanel.Width;
            this.itemPanel.Top = 0;
            this.itemPanel.Size = new Size(Width - orderPanel.Width, Height);

            this.toolboxPanel.Top = 0;
            this.toolboxPanel.Left = 0;
            this.toolboxPanel.Width = itemPanel.Width;
            this.toolboxPanel.Height = 7 * itemPanel.Width / 100;

            this.itemDataPanel.Top = toolboxPanel.Height;
            this.itemDataPanel.Left = 0;
            this.itemDataPanel.Width = itemPanel.Width;
            this.itemDataPanel.Height = itemPanel.Height - toolboxPanel.Height;

            //Get data for cbCategory
            var categoriesRequest = await ApiBuilder.SendRequest<List<DescriptionViewModel>>("api/Category", null, RequestMethod.GET);
            CATEGORIES = JsonConvert.DeserializeObject<List<DescriptionViewModel>>(categoriesRequest);

            List<string> cbCategoryData = new();
            cbCategoryData.Add("Tất cả");
            foreach (var item in CATEGORIES)
            {
                cbCategoryData.Add(item.Description);
            }

            cbCategory.DataSource = cbCategoryData;
            cbCategory.SelectedIndex = CATEGORY_INDEX;

            this.lbCategory.Font = Sessions.Sessions.NOMAL_BOLD_FONT;
            this.lbSearch.Font = Sessions.Sessions.NOMAL_BOLD_FONT;

            this.cbCategory.Font = Sessions.Sessions.NOMAL_BOLD_FONT;
            this.txtSearch.Font = Sessions.Sessions.NOMAL_BOLD_FONT;

            this.lbCategory.Top = 50 * toolboxPanel.Height / 100 - lbCategory.Height * 50 / 100;
            this.lbSearch.Top = lbCategory.Top;
            this.txtSearch.Top = 50 * toolboxPanel.Height / 100 - txtSearch.Height * 50 / 100;
            this.cbCategory.Top = 50 * toolboxPanel.Height / 100 - cbCategory.Height * 50 / 100;

            this.lbSearch.Left = 2 * toolboxPanel.Width / 100;
            this.txtSearch.Left = lbSearch.Left + lbSearch.Width + 1 * toolboxPanel.Width / 100;
            this.lbCategory.Left = txtSearch.Left + txtSearch.Width + 4 * toolboxPanel.Width / 100;
            this.cbCategory.Left = lbCategory.Left + lbCategory.Width + 1 * toolboxPanel.Width / 100;

            this.cbCategory.DropDownStyle = ComboBoxStyle.DropDownList;

            if (ItemSession.ItemData.Count == 0)
            {
                var itemsRequest = await ApiBuilder.SendRequest<object>("api/Item", null, RequestMethod.GET);
                ItemSession.ItemData = JsonConvert.DeserializeObject<List<ItemViewModel>>(itemsRequest);
            }

            if (ItemSession.Items.Count == 0)
            {
                List<ItemImages> items = new List<ItemImages>();
                foreach (var item in ItemSession.ItemData)
                {
                    var itemImage = new ItemImages() { Id = item.Id };
                    foreach (var imageId in item.Images)
                    {
                        var imageRequest = await ApiBuilder.SendImageRequest("api/Item/Image/" + imageId);
                        Image image = ImageUtils.ByteArrayToImage(imageRequest);
                        itemImage.Images.Add(image);
                    }
                    items.Add(itemImage);
                }
                ItemSession.Items = items;
            }

            this.btnRemoveFilter.BackColor = Color.DarkGray;
            this.btnRemoveFilter.Text = "Xóa lọc";
            this.btnRemoveFilter.Width = (int)4 * Width / 100;
            this.btnRemoveFilter.Height = ((int)2.5 * Height / 100 > Sessions.Sessions.MINIMUM_HEIGH) ? (int)2.5 * Height / 100 : Sessions.Sessions.MINIMUM_HEIGH;
            this.btnRemoveFilter.Top = 50 * toolboxPanel.Height / 100 - btnRemoveFilter.Height * 50 / 100;
            this.btnRemoveFilter.Left = cbCategory.Left + cbCategory.Width + 5 * toolboxPanel.Width / 100;

            itemDataPanel.Controls.Clear();
            ItemDataForm myForm = new ItemDataForm(txtSearch.Text, null, oDataPanel);
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            itemDataPanel.Controls.Add(myForm);
            myForm.Show();

            //Enable everything
            this.orderPanel.Visible = true;
            this.itemPanel.Visible = true;
            this.toolboxPanel.Visible = true;
            this.itemDataPanel.Visible = true;
            this.cbCategory.Visible = true;
            this.lbCategory.Visible = true;
            this.txtSearch.Visible = true;
            this.btnRemoveFilter.Visible = true;
            this.cbDetails.Visible = true;

            this.txtSearch.Focus();
            #endregion
            #region Order Screen setup
            this.lbName.Font = Sessions.Sessions.NOMAL_BOLD_FONT;
            this.lbQuantity.Font = Sessions.Sessions.NOMAL_BOLD_FONT;
            this.lbPrice.Font = Sessions.Sessions.NOMAL_BOLD_FONT;
            this.lbSubTotal.Font = Sessions.Sessions.NOMAL_BOLD_FONT;
            this.cbDetails.Font = Sessions.Sessions.NOMAL_BOLD_FONT;

            this.oHeaderPanel.Top = 0;
            this.oHeaderPanel.Left = 0;
            this.oHeaderPanel.Width = orderPanel.Width;
            this.oHeaderPanel.Height = orderPanel.Height * 10 / 100;
            this.oHeaderPanel.BackColor = Color.White;

            this.oDataPanel.Top = oHeaderPanel.Height + 1;
            this.oDataPanel.Left = 0;
            this.oDataPanel.BackColor = Color.White;
            this.oDataPanel.Width = orderPanel.Width;
            this.oDataPanel.Height = orderPanel.Height * 90 / 100;

            //this.oFooterPanel.Top = oDataPanel.Top + oDataPanel.Height + 1;
            //this.oFooterPanel.Left = 0;
            //this.oFooterPanel.Width = orderPanel.Width;
            //this.oFooterPanel.Height = orderPanel.Height * 20 / 100;
            //this.oFooterPanel.BackColor = Color.White;

            this.lbName.Top = oHeaderPanel.Height - lbName.Height;
            this.lbQuantity.Top = oHeaderPanel.Height - lbName.Height;
            this.lbPrice.Top = oHeaderPanel.Height - lbName.Height;
            this.lbSubTotal.Top = oHeaderPanel.Height - lbName.Height;
            this.lbSubTotal.TextAlign = ContentAlignment.MiddleRight;
            this.cbDetails.Top = oHeaderPanel.Height - cbDetails.Height;

            this.lbName.Left = (int)2 * orderPanel.Width / 100;
            this.lbQuantity.Left = orderPanel.Width * 40 / 100;
            this.cbDetails.Left = lbQuantity.Left + lbQuantity.Width;
            this.lbPrice.Left = orderPanel.Width * 60 / 100;
            this.lbSubTotal.Left = orderPanel.Width - 20 * orderPanel.Width / 100;

            this.cbDetails.Checked = Sessions.Sessions.SHOW_ORDER_ITEM_DETAILS;

            oDataPanel.Controls.Clear();
            OrderDataForm orderDataForm = new OrderDataForm(oDataPanel);
            orderDataForm.TopLevel = false;
            orderDataForm.AutoScroll = true;
            oDataPanel.Controls.Add(orderDataForm);
            orderDataForm.Show();
            #endregion
        }

        private void toolboxPanel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, toolboxPanel.ClientRectangle,
            Sessions.Sessions.MENU_COLOR, 0, ButtonBorderStyle.Solid, // left
            Sessions.Sessions.MENU_COLOR, 0, ButtonBorderStyle.Solid, // top
            Sessions.Sessions.MENU_COLOR, 0, ButtonBorderStyle.Solid, // right
            Sessions.Sessions.MENU_COLOR, 0, ButtonBorderStyle.Solid);// bottom
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            CATEGORY_INDEX = cbCategory.SelectedIndex;

            Guid? categoryId = null;
            if (CATEGORY_INDEX > 0)
            {
                categoryId = CATEGORIES[CATEGORY_INDEX - 1].Id;
            }

            itemDataPanel.Controls.Clear();
            ItemDataForm myForm = new ItemDataForm(txtSearch.Text, categoryId, oDataPanel);
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            itemDataPanel.Controls.Add(myForm);
            myForm.Show();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            CATEGORY_INDEX = cbCategory.SelectedIndex;

            Guid? categoryId = null;
            if (CATEGORY_INDEX > 0)
            {
                categoryId = CATEGORIES[CATEGORY_INDEX - 1].Id;
            }
            itemDataPanel.Controls.Clear();
            ItemDataForm myForm = new ItemDataForm(txtSearch.Text, categoryId, oDataPanel);
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            itemDataPanel.Controls.Add(myForm);
            myForm.Show();
            txtSearch.Focus();
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != "" || this.cbCategory.SelectedIndex != 0)
            {
                this.txtSearch.Text = "";
                this.cbCategory.SelectedIndex = 0;

                itemDataPanel.Controls.Clear();
                ItemDataForm myForm = new ItemDataForm("", null, oDataPanel);
                myForm.TopLevel = false;
                myForm.AutoScroll = true;
                itemDataPanel.Controls.Add(myForm);
                myForm.Show();
                txtSearch.Focus();
            }
        }

        private void cbDetails_CheckedChanged(object sender, EventArgs e)
        {
            Sessions.Sessions.SHOW_ORDER_ITEM_DETAILS = cbDetails.Checked;

            oDataPanel.Controls.Clear();
            OrderDataForm orderDataForm = new(oDataPanel);
            orderDataForm.TopLevel = false;
            orderDataForm.AutoScroll = true;
            oDataPanel.Controls.Add(orderDataForm);
            orderDataForm.Show();
        }
    }
}
