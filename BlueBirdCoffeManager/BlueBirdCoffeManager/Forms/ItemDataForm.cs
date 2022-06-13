using BlueBirdCoffeManager.DataAccessLayer;
using BlueBirdCoffeManager.Models;
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
    public partial class ItemDataForm : Form
    {
        private readonly string _searchItem;
        private readonly Guid? _categoryId;
        private readonly List<ItemViewModel> ITEMS = new();
        private List<ItemViewModel> _matchItem = new();

        public ItemDataForm(List<ItemViewModel> items, string searchItem, Guid? categoryId)
        {
            InitializeComponent();
            ITEMS = items;
            _searchItem = searchItem;
            _categoryId = categoryId;
        }

        private void ItemDataForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.MaximizeBox = false;

            var curLeft = 1 * Width / 100;
            var marLeft = (int)(0.5 * Width / 100);

            var itemWidth = 25 * (this.Width - curLeft * 2 - marLeft * 3) / 100;
            var itemHeigh = 20 * Height / 100;

            _matchItem = ITEMS.Where(s => s.Name.Contains(_searchItem)).Where(s => _categoryId == null || s.Category.Id == _categoryId.Value).ToList();

            foreach (var item in _matchItem)
            {
                Image image = Sessions.ItemSession.Items.FirstOrDefault(s => s.Id == item.Id).Images.First();

                Panel itemPanel = new();
                itemPanel.Top = 0;
                itemPanel.Left = curLeft;
                itemPanel.Width = itemWidth;
                itemPanel.Height = itemHeigh;
                itemPanel.BackgroundImage = image;

                this.Controls.Add(itemPanel);
            }
        }
    }
}
