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
        private readonly List<ItemViewModel> ITEMS = Sessions.ItemSession.ItemData;
        private List<ItemViewModel> _matchItem = new();
        private readonly Panel _orderDataPanel;

        public ItemDataForm(string searchItem, Guid? categoryId, Panel oDataPanel)
        {
            InitializeComponent();
            _searchItem = searchItem;
            _categoryId = categoryId;
            _orderDataPanel = oDataPanel;
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

            var itemWidth = 33 * (this.Width - curLeft * 2 - marLeft * 3) / 100;
            var itemHeigh = 30 * Height / 100;

            _matchItem = ITEMS.Where(s => s.Name.ToLower().Contains(_searchItem.ToLower())).Where(s => _categoryId == null || s.Category.Id == _categoryId.Value).ToList();

            var finalNameLines = 0;

            for (int i = 0; i < _matchItem.Count; i++)
            {
                var item = _matchItem[i];

                var curItemHeigh = itemHeigh;

                var sampLable = new Label();

                if (curPos == 0)
                {
                    finalNameLines = (int)Math.Ceiling((item.Name.Length * Sessions.Sessions.NORMAL_BOLD_FONT.Size / (itemWidth * 50 / 100)));
                    if (_matchItem.Count > i + 1)
                    {
                        var next = (int)Math.Ceiling(_matchItem[i + 1].Name.Length * Sessions.Sessions.NORMAL_BOLD_FONT.Size / (itemWidth * 50 / 100));
                        if (next > finalNameLines) finalNameLines = next;
                    }
                    if (_matchItem.Count > i + 2)
                    {
                        var x = _matchItem[i + 1].Name.Length * Sessions.Sessions.NORMAL_BOLD_FONT.Size / (itemWidth * 50 / 100);
                        var next = (int)Math.Ceiling(_matchItem[i + 1].Name.Length * Sessions.Sessions.NORMAL_BOLD_FONT.Size / (itemWidth * 50 / 100));
                        if (next > finalNameLines) finalNameLines = next;
                    }
                }
                Image? image = Sessions.ItemSession.Items.FirstOrDefault(s => s.Id == item.Id).Images.FirstOrDefault();

                //Panel
                Panel itemPanel = new();
                itemPanel.Width = itemWidth;

                itemPanel.Top = curTop;
                itemPanel.Left = curLeft;
                if (finalNameLines == 1)
                {
                    itemPanel.Height = curItemHeigh;
                }
                itemPanel.Height = curItemHeigh + sampLable.Height * (finalNameLines - 1);
                itemPanel.BackColor = Color.White;

                //Image
                PictureBox pictureBox = new();
                pictureBox.Width = itemPanel.Width;
                pictureBox.Height = itemPanel.Height - sampLable.Height * finalNameLines - 10;
                if (image != null) pictureBox.Image = ImageUtils.ResizeImage(image, pictureBox.Width, pictureBox.Height);
                pictureBox.Top = 0;
                pictureBox.Left = 0;

                //Name
                Label lbName = new();
                lbName.AllowDrop = true;
                lbName.AutoSize = false;
                lbName.Text = item.Name;
                lbName.Font = Sessions.Sessions.NORMAL_BOLD_FONT;
                lbName.Width = itemPanel.Width * 45 / 100;
                lbName.Height = itemPanel.Height - pictureBox.Height;
                lbName.Top = pictureBox.Height;
                lbName.TextAlign = ContentAlignment.MiddleLeft;
                lbName.Left = 0;

                Panel splitName = new Panel()
                {
                    Top = lbName.Top + 2,
                    Width = 1,
                    Height = lbName.Height - 4,
                    Left = lbName.Left + lbName.Width - 1,
                    BackColor = Color.FromKnownColor(KnownColor.Control)
                };

                //Price
                Label lbPrice = new();
                lbPrice.Text = "Giá:" + item.Price.ToString("#,###", Application.CurrentCulture.NumberFormat) + "₫";
                lbPrice.Font = Sessions.Sessions.NORMAL_BOLD_FONT;
                lbPrice.TextAlign = ContentAlignment.MiddleLeft;
                lbPrice.Width = (int)(Sessions.Sessions.NORMAL_BOLD_FONT.Size * lbPrice.Text.Length) - 10;
                lbPrice.Left = lbName.Width;
                lbPrice.Top = pictureBox.Height + (itemPanel.Height - pictureBox.Height) / 2 - lbPrice.Height / 2;

                //Button
                RoundedButton roundedButton = new();
                roundedButton.Text = "Thêm";
                roundedButton.Width = itemPanel.Width * 20 / 100;
                roundedButton.Left = itemPanel.Width - roundedButton.Width - itemPanel.Width * 1 / 100;
                roundedButton.BackColor = Sessions.Sessions.BUTTON_COLOR;
                roundedButton.Top = pictureBox.Height + (itemPanel.Height - pictureBox.Height) / 2 - roundedButton.Height / 2;
                roundedButton.Click += (sender, e) =>
                {
                    var curItem = Sessions.Order.CurrentOrder.OrderDetail.FirstOrDefault(f => f.ItemId == item.Id);
                    if (curItem != null)
                    {
                        Sessions.Order.CurrentOrder.OrderDetail.Remove(curItem);
                        curItem.Quantity += 1;
                        var numValues = JsonConvert.DeserializeObject<List<DetailValue>>(curItem.Description);
                        numValues.Add(new DetailValue() { Ice = 100, Sugar = 100 });
                        curItem.Description = JsonConvert.SerializeObject(numValues);
                        Sessions.Order.CurrentOrder.OrderDetail.Add(curItem);
                    }
                    else
                    {
                        var numValue = new List<DetailValue>() { new DetailValue() { Ice = 100, Sugar = 100 } };

                        OrderDetailViewModel orderDetailViewModel = new OrderDetailViewModel()
                        {
                            ItemId = item.Id,
                            Quantity = 1,
                            Description = JsonConvert.SerializeObject(numValue)
                        };
                        Sessions.Order.CurrentOrder.OrderDetail.Add(orderDetailViewModel);
                    }
                    _orderDataPanel.Controls.Clear();
                    OrderDataForm myForm = new OrderDataForm(_orderDataPanel);
                    myForm.TopLevel = false;
                    myForm.AutoScroll = true;
                    _orderDataPanel.Controls.Add(myForm);
                    myForm.Show();
                };

                //Add to panel
                itemPanel.Controls.Add(pictureBox);
                itemPanel.Controls.Add(splitName);
                itemPanel.Controls.Add(lbName);
                itemPanel.Controls.Add(lbPrice);
                itemPanel.Controls.Add(roundedButton);


                this.Controls.Add(itemPanel);

                if (curPos != 2)
                {
                    curLeft += itemWidth + marLeft;
                    curPos += 1;
                }
                else
                {
                    curTop += curItemHeigh + marTop;
                    curLeft = 1 * Width / 100;
                    curPos = 0;
                    finalNameLines = 0;
                }
            }
        }
    }
}
