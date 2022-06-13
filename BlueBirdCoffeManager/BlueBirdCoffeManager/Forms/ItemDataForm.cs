using BlueBirdCoffeManager.DataAccessLayer;
using BlueBirdCoffeManager.Models;
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
            var curPos = 0;
            var curTop = (int)(1 * Height / 100);
            var marTop = curTop;

            var itemWidth = 25 * (this.Width - curLeft * 2 - marLeft * 3) / 100;
            var itemHeigh = 30 * Height / 100;

            _matchItem = ITEMS.Where(s => s.Name.Contains(_searchItem)).Where(s => _categoryId == null || s.Category.Id == _categoryId.Value).ToList();

            foreach (var item in _matchItem)
            {
                Image image = Sessions.ItemSession.Items.FirstOrDefault(s => s.Id == item.Id).Images.First();

                Panel itemPanel = new();
                itemPanel.Top = curTop;
                itemPanel.Left = curLeft;
                itemPanel.Width = itemWidth;
                itemPanel.Height = itemHeigh;
                itemPanel.BackColor = Color.Aqua;

                PictureBox pictureBox = new();
                pictureBox.Width = itemPanel.Width;
                pictureBox.Height = this.Height * 25 / 100;
                pictureBox.Image = image;
                pictureBox.Top = 0;
                pictureBox.Left = 0;
                itemPanel.Controls.Add(pictureBox);

                Label lbName = new();
                lbName.Text = item.Name;
                lbName.Font = Sessions.Sessions.NOMAL_BOLD_FONT;
                lbName.Width = itemWidth;
                lbName.Height = 5 * this.Height / 100;
                lbName.Top = pictureBox.Height;
                lbName.TextAlign = ContentAlignment.MiddleLeft;
                lbName.Left = 0;

                itemPanel.Controls.Add(lbName);

                RoundedButton roundedButton = new RoundedButton();
                roundedButton.Text = "Thêm";
                roundedButton.Click += (sender, e) =>
                {
                    var x = item.Id;
                    MessageBox.Show("Hihi" + item.Id);
                };
                roundedButton.Top = pictureBox.Height;
                roundedButton.Left = 0;
                //roundedButton.Click += new EventHandler(rbtnEdit_Click_1(item.Id));

                itemPanel.Controls.Add(roundedButton);

                this.Controls.Add(itemPanel);

                if (curPos != 3)
                {
                    curLeft += itemWidth + marLeft;
                    curPos += 1;
                }
                else
                {
                    curTop += itemHeigh + marTop;
                    curLeft = 1 * Width / 100;
                    curPos = 0;
                }

            }
        }
    }
}
