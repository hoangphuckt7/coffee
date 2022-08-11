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
    public partial class BillDataForm : Form
    {
        private const string RE_PRINT = "In lại";
        private const string CHECK_OUT = "Thanh toán";
        private readonly List<OrderViewModel>? _orders;
        private readonly Bitmap? _img;

        public BillDataForm(List<OrderViewModel>? orders, Bitmap? img)
        {
            InitializeComponent();
            _orders = orders;
            _img = img;
        }

        private void BillDataForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.MaximizeBox = false;

            if (_img == null)
            {
                SetupBillData(0);
            }
            else
            {
                oldBillPicture.Visible = true;

                oldBillPicture.Image = _img;
                oldBillPicture.Width = _img.Width;
                oldBillPicture.Height = _img.Height;

                oldBillPicture.Left = this.Width / 2 - oldBillPicture.Width / 2;

                oldBillPicture.Top = 5 * Height / 100;
            }

            dataPanel.Left = 0;
            dataPanel.Width = Width;

            lbName.Font = Sessions.Sessions.NORMAL_BOLD_FONT;
            lbPrice.Font = Sessions.Sessions.NORMAL_BOLD_FONT;
            lbQuan.Font = Sessions.Sessions.NORMAL_BOLD_FONT;
            lbSTT.Font = Sessions.Sessions.NORMAL_BOLD_FONT;
            lbTotal.Font = Sessions.Sessions.NORMAL_BOLD_FONT;

            lbName.Top = 1 * Height / 100;
            lbSTT.Top = lbName.Top;
            lbPrice.Top = lbName.Top;
            lbQuan.Top = lbName.Top;
            lbTotal.Top = lbName.Top;

            lbSTT.Left = 0;
            lbTotal.Left = this.Width - lbTotal.Width;
            lbQuan.Left = 50 * this.Width / 100;
            lbPrice.Left = lbQuan.Left + lbQuan.Width + 5 * Width / 100;
            lbName.Left = 10 * Width / 100;

            btnCheckout.Font = Sessions.Sessions.NORMAL_BOLD_FONT;
            btnCheckout.Top = Height - btnCheckout.Height - 10;
            btnCheckout.Width = dataPanel.Width - 4 * dataPanel.Width / 100;
            btnCheckout.Left = 2 * this.Width / 100;
            btnCheckout.BackColor = Sessions.Sessions.BUTTON_COLOR;

            dataPanel.Height = btnCheckout.Top - lbName.Top - lbName.Height;
            dataPanel.Top = lbName.Top + lbName.Height;

        }

        private void DisableCheckout()
        {
            lbName.Visible = false;
            lbQuan.Visible = false;
            lbPrice.Visible = false;
            lbSTT.Visible = false;
            lbTotal.Visible = false;

            btnCheckout.Text = RE_PRINT;
            oldBillPicture.Visible = true;
        }
        private void EnableCheckout()
        {
            lbName.Visible = true;
            lbQuan.Visible = true;
            lbPrice.Visible = true;
            lbSTT.Visible = true;
            lbTotal.Visible = true;

            btnCheckout.Text = CHECK_OUT;
            oldBillPicture.Visible = false;
        }
        public int SetupBillData(int curTop)
        {
            EnableCheckout();

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

            Panel split = new()
            {
                Top = curTop,
                Width = this.Width,
                Left = 0,
                Height = 1,
                BackColor = Color.FromKnownColor(KnownColor.Control)
            };

            curTop += split.Height;

            dataPanel.Controls.Add(split);

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


                dataPanel.Controls.Add(stt);
                dataPanel.Controls.Add(name);
                dataPanel.Controls.Add(quan);
                dataPanel.Controls.Add(price);
                dataPanel.Controls.Add(total);

                curTop += name.Height;
            }
            dataPanel.Update();
            return curTop;
        }
    }
}
