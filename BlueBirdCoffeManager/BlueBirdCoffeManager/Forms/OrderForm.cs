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
        private List<ItemViewModel> ITEMS = new();

        public OrderForm()
        {
            InitializeComponent();
        }

        private async void OrderForm_Load(object sender, EventArgs e)
        {
            #region screen setup
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.MaximizeBox = false;

            this.orderPanel.Left = 0;
            this.orderPanel.Top = 0;
            this.orderPanel.Size = new Size(Width * 30 / 100, Height);
            this.orderPanel.BackColor = Color.White;

            this.itemPanel.Left = orderPanel.Width;
            this.itemPanel.Top = 0;
            this.itemPanel.Size = new Size(Width - orderPanel.Width, Height);

            this.toolboxPanel.Top = 0;
            this.toolboxPanel.Left = 0;
            this.toolboxPanel.Width = itemPanel.Width;
            this.toolboxPanel.Height = 7 * itemPanel.Width / 100;
            //this.toolboxPanel.BackColor = Color.;

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
            this.txtSearch.Focus();

            var itemsRequest = await ApiBuilder.SendRequest<object>("api/Item", null, RequestMethod.GET);
            ITEMS = JsonConvert.DeserializeObject<List<ItemViewModel>>(itemsRequest);

            if (ItemSession.Items.Count == 0)
            {
                List<ItemImages> items = new List<ItemImages>();
                foreach (var item in ITEMS)
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

            itemDataPanel.Controls.Clear();
            ItemDataForm myForm = new ItemDataForm(ITEMS, txtSearch.Text, null);
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            itemDataPanel.Controls.Add(myForm);
            myForm.Show();

            #endregion
        }

        private void toolboxPanel_Paint(object sender, PaintEventArgs e)
        {
            //ControlPaint.DrawBorder(e.Graphics, toolboxPanel.ClientRectangle,
            //Sessions.Sessions.MENU_COLOR, 3, ButtonBorderStyle.Solid, // left
            //Sessions.Sessions.MENU_COLOR, 3, ButtonBorderStyle.Solid, // top
            //Sessions.Sessions.MENU_COLOR, 0, ButtonBorderStyle.Solid, // right
            //Sessions.Sessions.MENU_COLOR, 3, ButtonBorderStyle.Solid);// bottom
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
            ItemDataForm myForm = new ItemDataForm(ITEMS, txtSearch.Text, categoryId);
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
            ItemDataForm myForm = new ItemDataForm(ITEMS, txtSearch.Text, categoryId);
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            itemDataPanel.Controls.Add(myForm);
            myForm.Show();
            txtSearch.Focus();
        }
    }
}
