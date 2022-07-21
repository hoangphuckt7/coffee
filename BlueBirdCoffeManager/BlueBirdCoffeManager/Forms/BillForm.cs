using BlueBirdCoffeManager.Models;
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
    public partial class BillForm : Form
    {
        private readonly List<OrderViewModel> _orders;
        public BillForm(List<OrderViewModel> orders)
        {
            InitializeComponent();
            _orders = orders;
        }

        private void BillForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.MaximizeBox = false;

            tablesPanel.Width = (int)(33.33 * Width / 100);
            mainPanel.Width = (int)(33.33 * Width / 100);
            lostBillPanel.Width = (int)(33.33 * Width / 100);

            tablesPanel.Height = Height;
            mainPanel.Height = Height;
            lostBillPanel.Height = Height;

            tablesPanel.BackColor = Color.Gray;
            mainPanel.BackColor = Color.White;
            lostBillPanel.BackColor = Color.Blue;

            lbName.Font = Sessions.Sessions.NORMAL_BOLD_FONT;
            lbPrice.Font = Sessions.Sessions.NORMAL_BOLD_FONT;
            lbQuan.Font = Sessions.Sessions.NORMAL_BOLD_FONT;
            lbSTT.Font = Sessions.Sessions.NORMAL_BOLD_FONT;
            lbTotal.Font = Sessions.Sessions.NORMAL_BOLD_FONT;

            lbSTT.Left = 0;
            lbTotal.Left = lostBillPanel.Width - lbTotal.Width;

            lbName.Top = 1 * Height / 100;
            lbSTT.Top = lbName.Top;
            lbPrice.Top = lbName.Top;
            lbQuan.Top = lbName.Top;
            lbTotal.Top = lbName.Top;

            lbQuan.Left = 50 * tablesPanel.Width / 100;
            lbPrice.Left = lbQuan.Left + lbQuan.Width + 5 * Width / 100;

            var curTop = lbSTT.Top + lbSTT.Height;

            var mergeOders = new List<OrderDetailViewModel>();

            if (_orders != null)
            {
                foreach (var order in _orders)
                {
                    foreach (var item in order.OrderDetails)
                    {
                        var curItem = mergeOders.FirstOrDefault(f => f.ItemId == item.ItemId);
                        if (curItem != null)
                        {
                            mergeOders.Remove(curItem);
                            curItem.Quantity += item.Quantity;
                            mergeOders.Add(curItem);
                        }
                        else
                        {
                            mergeOders.Add(item);
                        }
                    }
                }
            }

            Label split = new()
            {
                Top = curTop,
                Width = mainPanel.Width,
                Left = 0,
                Height = 1,
                BackColor = Color.FromKnownColor(KnownColor.Control)
            };

            curTop += split.Height;

            mainPanel.Controls.Add(split);

            for (int i = 0; i < mergeOders.Count; i++)
            {
                var order = mergeOders[i];
                var curItem = Sessions.ItemSession.ItemData.FirstOrDefault(f => f.Id == order.ItemId);

                Label stt = new()
                {
                    Text = i + 1 + "",
                    Top = curTop,
                    Left = lbSTT.Left,
                    Width = lbSTT.Width,
                    Font = Sessions.Sessions.NORMAL_BOLD_FONT
                };

                Label name = new()
                {
                    Text = curItem.Name,
                    Top = curTop,
                    Left = lbName.Left,
                    Font = Sessions.Sessions.NORMAL_BOLD_FONT,
                    Width = lbName.Width,
                    AllowDrop = true,
                    AutoSize = false
                };

                Label quan = new()
                {
                    Text = order.Quantity + "",
                    Top = curTop,
                    Left = lbQuan.Left + 17,
                    Font = Sessions.Sessions.NORMAL_FONT,
                    Width = lbQuan.Width,
                };

                Label price = new()
                {
                    Font = Sessions.Sessions.NORMAL_FONT,
                    Text = curItem.Price.ToString("#,###", Application.CurrentCulture.NumberFormat) + "₫",
                    Top = curTop,
                    Left = lbPrice.Left,
                };

                Label total = new()
                {
                    Font = Sessions.Sessions.NORMAL_FONT,
                    Text = (curItem.Price * order.Quantity).ToString("#,###", Application.CurrentCulture.NumberFormat) + "₫",
                    Top = curTop,
                    Left = lbTotal.Left
                };

                price.Width = (int)(price.Text.Length * price.Font.Size);


                mainPanel.Controls.Add(stt);
                mainPanel.Controls.Add(name);
                mainPanel.Controls.Add(quan);
                mainPanel.Controls.Add(price);
                mainPanel.Controls.Add(total);

                curTop += name.Height;
            }
        }
    }
}
