using BlueBirdCoffeManager.Models;
using BlueBirdCoffeManager.Utils;
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
        private readonly List<OrderViewModel>? _orders;
        public BillForm(List<OrderViewModel>? orders)
        {
            InitializeComponent();
            _orders = orders;
        }

        private void BillForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.MaximizeBox = false;

            leftPanel.Width = (int)(33.33 * Width / 100);
            mainPanel.Width = (int)(33.33 * Width / 100);
            lostBillPanel.Width = (int)(33.33 * Width / 100);

            areaPanel.Top = 0;
            areaPanel.Left = 0;
            areaPanel.Width = leftPanel.Width;
            areaPanel.Height = 50 * leftPanel.Height / 100;
            areaPanel.BackColor = Color.Black;

            oldBillPanel.Top = areaPanel.Top + areaPanel.Height;
            oldBillPanel.Left = 0;
            oldBillPanel.Height = leftPanel.Height - areaPanel.Height;
            oldBillPanel.Width = leftPanel.Width-1;
            oldBillPanel.AutoScroll = true;
            oldBillPanel.BackColor = Color.White;
            oldBillPanel.Paint += (sender, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, oldBillPanel.ClientRectangle,
                        Color.FromKnownColor(KnownColor.Control), 1, ButtonBorderStyle.Solid, // left
                        Color.FromKnownColor(KnownColor.Control), 1, ButtonBorderStyle.Solid, // top
                        Color.FromKnownColor(KnownColor.DarkGray), 0, ButtonBorderStyle.Solid, // right
                        Color.FromKnownColor(KnownColor.DarkGray), 0, ButtonBorderStyle.Solid);// bottom
            };

            leftPanel.Height = Height;
            mainPanel.Height = Height;
            lostBillPanel.Height = Height;

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

            lbQuan.Left = 50 * leftPanel.Width / 100;
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

            lbOldOrdersTilte.Font = Sessions.Sessions.NORMAL_BOLD_FONT;
            lbOldOrdersTilte.Left = leftPanel.Width / 2 - lbOldOrdersTilte.Width / 2;
            lbOldOrdersTilte.Top = 10;

            curTop = lbOldOrdersTilte.Height + lbOldOrdersTilte.Top;

            var oldOrdersData = Sessions.Order.OldOrders.OrderByDescending(f => f.DateCreated);

            foreach (var item in oldOrdersData)
            {
                var borderPanel = new Panel()
                {
                    Top = curTop,
                    Width = oldBillPanel.Width - 5,
                    Left = 0
                };

                var timeLabel = new Label()
                {
                    Font = Sessions.Sessions.NORMAL_FONT,
                    Top = 1,
                    Text = "Thời gian: " + BillPrinter.FormatDate(item.DateCreated),
                };
                timeLabel.Width = (int)(timeLabel.Text.Length * timeLabel.Font.Size);

                var typeLabel = new Label()
                {
                    Font = Sessions.Sessions.NORMAL_FONT,
                    Top = timeLabel.Top + timeLabel.Height,
                    Text = item.TableId != null ? "Bàn số: " + item.TableId.ToString() : "Hình thức: Mang đi"
                };
                typeLabel.Width = (int)(typeLabel.Text.Length * typeLabel.Font.Size);

                borderPanel.Height = typeLabel.Height + timeLabel.Height + 5;

                curTop += borderPanel.Height + 5;

                borderPanel.BackColor = Color.FromKnownColor(KnownColor.Control);
                borderPanel.Paint += (sender, e) =>
                {
                    //Panel? panel = sender as Panel;
                    //Rectangle rect = panel.ClientRectangle;
                    //rect.Width--;
                    //rect.Height--;
                    //e.Graphics.DrawRectangle(Pens.Red, rect);

                    ControlPaint.DrawBorder(e.Graphics, borderPanel.ClientRectangle,
                    Color.FromKnownColor(KnownColor.Control), 0, ButtonBorderStyle.Solid, // left
                    Color.FromKnownColor(KnownColor.Control), 0, ButtonBorderStyle.Solid, // top
                    Color.FromKnownColor(KnownColor.DarkGray), 1, ButtonBorderStyle.Solid, // right
                    Color.FromKnownColor(KnownColor.DarkGray), 1, ButtonBorderStyle.Solid);// bottom
                };

                borderPanel.MouseMove += (sender, e) =>
                {
                    borderPanel.BackColor = Color.FromKnownColor(KnownColor.DarkGray);
                };

                borderPanel.MouseLeave += (sender, e) =>
                {
                    borderPanel.BackColor = Color.FromKnownColor(KnownColor.Control);
                };


                borderPanel.Controls.Add(timeLabel);
                borderPanel.Controls.Add(typeLabel);


                oldBillPanel.Controls.Add(borderPanel);
            }
        }
    }
}
