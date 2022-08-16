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

            this.BackColor = Color.White;
            dataPanel.Left = 0;
            dataPanel.Width = Width;
            dataPanel.Visible = false;

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

            lbSTT.Left = 5 * Width / 100;
            lbQuan.Left = 55 * this.Width / 100;
            lbPrice.Left = lbQuan.Left + lbQuan.Width + 10 * Width / 100;
            lbTotal.Left = this.Width - lbTotal.Width - lbSTT.Left;
            lbName.Left = 10 * Width / 100;

            btnCheckout.Font = Sessions.Sessions.NORMAL_BOLD_FONT;
            btnCheckout.Top = Height - btnCheckout.Height - 10;
            btnCheckout.Width = dataPanel.Width - 4 * dataPanel.Width / 100;
            btnCheckout.Left = 2 * this.Width / 100;
            btnCheckout.BackColor = Sessions.Sessions.BUTTON_COLOR;

            lbapCp.Font = Sessions.Sessions.NORMAL_BOLD_FONT;
            lbapDiscout.Font = Sessions.Sessions.NORMAL_BOLD_FONT;
            lbEx.Font = Sessions.Sessions.NORMAL_BOLD_FONT;
            lbCustomerP.Font = Sessions.Sessions.NORMAL_BOLD_FONT;
            lbCash.Font = Sessions.Sessions.NORMAL_BOLD_FONT;
            lbvoucher.Font = Sessions.Sessions.NORMAL_BOLD_FONT;
            lbDiscout.Font = Sessions.Sessions.NORMAL_BOLD_FONT;
            lbaTotal.Font = Sessions.Sessions.NORMAL_BOLD_FONT;
            txtapCoupon.Font = Sessions.Sessions.NORMAL_BOLD_FONT;
            txtapDiscout.Font = Sessions.Sessions.NORMAL_BOLD_FONT;
            txtEx.Font = Sessions.Sessions.NORMAL_BOLD_FONT;

            txtCustomerP.Font = Sessions.Sessions.NORMAL_BOLD_FONT;
            txtCash.Font = Sessions.Sessions.NORMAL_BOLD_FONT;
            txtVoucher.Font = Sessions.Sessions.NORMAL_BOLD_FONT;
            txtDiscout.Font = Sessions.Sessions.NORMAL_BOLD_FONT;
            total.Font = Sessions.Sessions.NORMAL_BOLD_FONT;

            lbapCp.Top = btnCheckout.Top - lbapCp.Height - 5 * Height / 100;
            lbapCp.Left = btnCheckout.Left;

            lbapDiscout.Top = lbapCp.Top - lbapDiscout.Height - 20;
            lbapDiscout.Left = btnCheckout.Left;

            lbEx.Top = lbapDiscout.Top - lbEx.Height - 3 * Height / 100;
            lbEx.Left = btnCheckout.Left;

            lbCustomerP.Top = lbEx.Top - lbCustomerP.Height - 20;
            lbCustomerP.Left = btnCheckout.Left;

            lbCash.Top = lbCustomerP.Top - lbCash.Height - 3 * Height / 100;
            lbCash.Left = btnCheckout.Left;

            lbvoucher.Top = lbCash.Top - lbvoucher.Height - 20;
            lbvoucher.Left = btnCheckout.Left;

            lbDiscout.Top = lbvoucher.Top - lbDiscout.Height - 20;
            lbDiscout.Left = btnCheckout.Left;

            lbaTotal.Top = lbDiscout.Top - lbaTotal.Height - 20;
            lbaTotal.Left = btnCheckout.Left;

            txtapCoupon.Top = lbapCp.Top;
            txtapCoupon.Left = btnCheckout.Left + btnCheckout.Width - txtapCoupon.Width;

            txtapDiscout.Top = lbapDiscout.Top;
            txtapDiscout.Left = btnCheckout.Left + btnCheckout.Width - txtapDiscout.Width;

            txtEx.Top = lbEx.Top;
            txtEx.Left = btnCheckout.Left + btnCheckout.Width - txtEx.Width;

            txtCustomerP.Top = lbCustomerP.Top;
            txtCustomerP.Left = btnCheckout.Left + btnCheckout.Width - txtCustomerP.Width;

            txtCash.Top = lbCash.Top;
            txtCash.Left = btnCheckout.Left + btnCheckout.Width - txtCash.Width;

            txtVoucher.Top = lbvoucher.Top;
            txtVoucher.Left = btnCheckout.Left + btnCheckout.Width - txtVoucher.Width;

            txtDiscout.Top = lbDiscout.Top;
            txtDiscout.Left = btnCheckout.Left + btnCheckout.Width - txtDiscout.Width;

            total.Top = lbaTotal.Top;
            total.Left = btnCheckout.Left + btnCheckout.Width - total.Width;

            dataPanel.Height = btnCheckout.Top - lbName.Top - lbName.Height;
            dataPanel.Top = lbName.Top + lbName.Height;

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
                Width = this.Width - lbSTT.Left - (this.Width - lbTotal.Left - lbTotal.Width),
                Left = lbSTT.Left,
                Height = 1,
                BackColor = Color.FromKnownColor(KnownColor.Control)
            };

            curTop += split.Height;

            dataPanel.Controls.Add(split);

            for (int i = 0; i < mergeOders.Count; i++)
            {
                var order = mergeOders[i];
                var curItem = Sessions.ItemSession.ItemData.FirstOrDefault(f => f.Id == order.ItemId);

                curTop += 5;

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
                    Width = lbQuan.Left - lbName.Left - 20,
                    AllowDrop = true,
                    AutoSize = false
                };
                var nameH = (int)Math.Round((name.Text.Length * name.Font.Size / name.Width), MidpointRounding.AwayFromZero);
                name.Height *= nameH > 1 ? nameH : 1;

                var roundButtonSize = new Size(20, 20);

                PictureBox plusButton = new PictureBox();
                plusButton.Paint += (sender, e) =>
                {
                    var plus_icon = Properties.Resources.plus_icon;
                    Bitmap bit_plus = new(plus_icon, new Size(20, 20));
                    e.Graphics.DrawImage(bit_plus, 0, 0);
                };
                plusButton.Click += (sender, e) =>
                {
                    ChangeQuantity(order.ItemId, false);
                };
                plusButton.Top = curTop;
                plusButton.Left = name.Width + name.Left + 10;
                plusButton.Width = roundButtonSize.Width;
                plusButton.Height = roundButtonSize.Width;

                Label quan = new()
                {
                    Text = order.Quantity + "",
                    Top = curTop,
                    Left = lbQuan.Left + 22,
                    Font = Sessions.Sessions.NORMAL_FONT,
                    Width = 30,
                };

                //Change quantity value
                PictureBox minusButton = new PictureBox();
                minusButton.Paint += (sender, e) =>
                {
                    var minus_icon = Properties.Resources.minus_icon;
                    Bitmap bit_minus = new(minus_icon, roundButtonSize);

                    e.Graphics.DrawImage(bit_minus, 0, 0);
                };
                minusButton.Click += (sender, e) =>
                {
                    ChangeQuantity(order.ItemId, true);
                };
                minusButton.Top = curTop;
                minusButton.Left = quan.Left + quan.Width;
                minusButton.Width = roundButtonSize.Width;
                minusButton.Height = roundButtonSize.Width;

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

                curTop += name.Height + 3;

                Panel borderPanel = new();
                borderPanel.Paint += (sender, e) =>
                {
                    ControlPaint.DrawBorder(e.Graphics, borderPanel.ClientRectangle,
                    Color.FromKnownColor(KnownColor.Control), 0, ButtonBorderStyle.Solid, // left
                    Color.FromKnownColor(KnownColor.Control), 1, ButtonBorderStyle.Solid, // top
                    Color.FromKnownColor(KnownColor.Control), 0, ButtonBorderStyle.Solid, // right
                    Color.FromKnownColor(KnownColor.Control), 0, ButtonBorderStyle.Solid);// bottom
                };
                borderPanel.Top = curTop - 1;
                borderPanel.Height = curTop - borderPanel.Top;
                borderPanel.Left = split.Left;
                borderPanel.Width = split.Width;

                dataPanel.Controls.Add(stt);
                dataPanel.Controls.Add(name);
                dataPanel.Controls.Add(plusButton);
                dataPanel.Controls.Add(quan);
                dataPanel.Controls.Add(minusButton);
                dataPanel.Controls.Add(price);
                dataPanel.Controls.Add(total);
                dataPanel.Controls.Add(borderPanel);
            }
            dataPanel.Update();
            return curTop;
        }
        private void ChangeQuantity(Guid itemId, bool minus)
        {
            var curItem = Sessions.Order.CurrentOrder.OrderDetail.FirstOrDefault(f => f.ItemId == itemId);

            Sessions.Order.CurrentOrder.OrderDetail.Remove(curItem);

            if (minus)
            {
                curItem.Quantity -= 1;
            }
            else
            {
                curItem.Quantity += 1;
            }
            var numValue = JsonConvert.DeserializeObject<List<DetailValue>>(curItem.Description);
            numValue.Add(new DetailValue() { Ice = 100, Sugar = 100 });
            curItem.Description = JsonConvert.SerializeObject(numValue);

            if (curItem.Quantity > 0)
            {
                Sessions.Order.CurrentOrder.OrderDetail.Add(curItem);
            }

            this.Controls.Clear();
            BillDataForm myForm = new BillDataForm(_orders, null);
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            this.Controls.Add(myForm);
            myForm.Show();
        }
    }
}
