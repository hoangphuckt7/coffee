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
    public partial class OrderDataForm : Form
    {
        private readonly Panel _orderDataPanel;
        public OrderDataForm(Panel orderDataPanel)
        {
            InitializeComponent();
            _orderDataPanel = orderDataPanel;
        }

        private void OrderDataForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.MaximizeBox = false;

            this.oDataPanel.Top = 0;
            this.oDataPanel.Left = 0;
            this.oDataPanel.BackColor = Color.White;
            this.oDataPanel.Width = this.Width;
            this.oDataPanel.Height = this.Height * 70 / 100;

            this.pnData.Top = 0;
            this.pnData.Left = 0;
            this.pnData.BackColor = Color.White;
            this.pnData.Width = this.Width;
            this.pnData.Height = this.Height * 70 / 100;

            this.oFooterPanel.Top = oDataPanel.Height + 1;
            this.oFooterPanel.Left = 0;
            this.oFooterPanel.Width = this.Width;
            this.oFooterPanel.Height = this.Height * 30 / 100;
            this.oFooterPanel.BackColor = Color.White;

            double total = 0;
            var curTop = 10;
            var currentOrders = Sessions.Order.CurrentOrder.OrderDetail.OrderBy(d => d.DateCreated);

            foreach (var item in currentOrders)
            {
                Panel borderPanel = new();
                borderPanel.Paint += (sender, e) =>
                {
                    ControlPaint.DrawBorder(e.Graphics, borderPanel.ClientRectangle,
                    Color.FromKnownColor(KnownColor.Control), 0, ButtonBorderStyle.Solid, // left
                    Color.FromKnownColor(KnownColor.Control), 1, ButtonBorderStyle.Solid, // top
                    Color.FromKnownColor(KnownColor.Control), 0, ButtonBorderStyle.Solid, // right
                    Color.FromKnownColor(KnownColor.Control), 0, ButtonBorderStyle.Solid);// bottom
                };
                borderPanel.Top = curTop - 10;

                //Name
                Label lbName = new();
                lbName.Text = Sessions.ItemSession.ItemData.First(f => f.Id == item.ItemId).Name;
                lbName.Top = curTop;
                lbName.Left = 2 * Width / 100;
                lbName.Font = Sessions.Sessions.NOMAL_FONT;

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
                    ChangeQuantity(item.ItemId, false);
                };
                plusButton.Top = curTop;
                plusButton.Left = 40 * Width / 100;
                plusButton.Width = roundButtonSize.Width;
                plusButton.Height = roundButtonSize.Width;

                //Quantity
                int itemQuantity = item.Quantity;
                Label lbQuantity = new();
                lbQuantity.Text = itemQuantity.ToString();
                lbQuantity.Font = Sessions.Sessions.NOMAL_FONT;
                lbQuantity.Left = plusButton.Left + plusButton.Width + 20;
                lbQuantity.Top = curTop;
                lbQuantity.Width = (5 * Width / 100 > Sessions.Sessions.MINIMUM_WIDTH) ? 5 * Width / 100 : Sessions.Sessions.MINIMUM_WIDTH;

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
                    ChangeQuantity(item.ItemId, true);
                };
                minusButton.Top = curTop;
                minusButton.Left = lbQuantity.Left + lbQuantity.Width;
                minusButton.Width = roundButtonSize.Width;
                minusButton.Height = roundButtonSize.Width;

                //Price
                double itemPrice = Sessions.ItemSession.ItemData.First(f => f.Id == item.ItemId).Price;
                Label lbPrice = new();
                lbPrice.Text = itemPrice.ToString("#,###", Application.CurrentCulture.NumberFormat) + "₫"; ;
                lbPrice.Font = Sessions.Sessions.NOMAL_FONT;
                lbPrice.Left = 60 * Width / 100;
                lbPrice.Top = curTop;
                lbPrice.TextAlign = ContentAlignment.MiddleRight;

                //Subtotal
                double subTotal = itemQuantity * itemPrice;
                Label lbSubtotal = new();
                lbSubtotal.Text = subTotal.ToString("#,###", Application.CurrentCulture.NumberFormat) + "₫";
                lbSubtotal.Font = Sessions.Sessions.NOMAL_FONT;
                lbSubtotal.Left = Width - 20 * Width / 100;
                lbSubtotal.Top = curTop;
                lbSubtotal.TextAlign = ContentAlignment.MiddleRight;

                curTop += lbName.Height + 10;

                #region Quantity
                if (Sessions.Sessions.SHOW_ORDER_ITEM_DETAILS)
                {
                    for (int i = 0; i < int.Parse(lbQuantity.Text); i++)
                    {
                        var numValue = JsonConvert.DeserializeObject<List<DetailValue>>(item.Description);

                        var curValuePos = i;
                        int iceValue = numValue[curValuePos].Ice;
                        int sgValue = numValue[curValuePos].Sugar;

                        Label lbsugar = new()
                        {
                            Text = "Đường",
                            Left = plusButton.Left,
                            Top = curTop,
                            Font = Sessions.Sessions.NOMAL_FONT,
                            Width = (7 * Width / 100 > Sessions.Sessions.MINIMUM_WIDTH * 1.5) ? 7 * Width / 100 : (int)(Sessions.Sessions.MINIMUM_WIDTH * 1.5)
                        };

                        Label numSugar = new();

                        PictureBox plusSugar = new PictureBox();
                        plusSugar.Paint += (sender, e) =>
                        {
                            var plus_icon = Properties.Resources.plus_icon;
                            Bitmap bit_plus = new(plus_icon, new Size(20, 20));
                            e.Graphics.DrawImage(bit_plus, 0, 0);
                        };
                        plusSugar.Click += (sender, e) =>
                        {
                            ChangeSugarIceNum(item, curValuePos, true, false, numSugar);
                        };
                        plusSugar.Top = curTop;
                        plusSugar.Left = lbsugar.Left + lbsugar.Width;
                        plusSugar.Width = roundButtonSize.Width;
                        plusSugar.Height = roundButtonSize.Width;

                        numSugar.Text = sgValue + "%";
                        numSugar.Top = curTop;
                        numSugar.Left = plusSugar.Left + plusSugar.Width + 10;
                        numSugar.Font = Sessions.Sessions.NOMAL_FONT;
                        numSugar.Width = (5 * Width / 100 > Sessions.Sessions.MINIMUM_WIDTH * 1.5) ? 5 * Width / 100 : (int)(Sessions.Sessions.MINIMUM_WIDTH * 1.5);

                        PictureBox minusSugar = new PictureBox();
                        minusSugar.Paint += (sender, e) =>
                        {
                            var minus_icon = Properties.Resources.minus_icon;
                            Bitmap bit_minus = new(minus_icon, roundButtonSize);

                            e.Graphics.DrawImage(bit_minus, 0, 0);
                        };
                        minusSugar.Click += (sender, e) =>
                        {
                            ChangeSugarIceNum(item, curValuePos, true, true, numSugar);
                        };
                        minusSugar.Top = curTop;
                        minusSugar.Left = numSugar.Left + numSugar.Width;
                        minusSugar.Width = roundButtonSize.Width;
                        minusSugar.Height = roundButtonSize.Width;

                        Label lbsplit = new();
                        lbsplit.Text = "/";
                        lbsplit.Left = minusSugar.Left + minusSugar.Width + 20;
                        lbsplit.Top = curTop;
                        lbsplit.Font = Sessions.Sessions.NOMAL_FONT;
                        lbsplit.Width = 10;

                        Label lbIce = new();
                        lbIce.Text = "Đá";
                        lbIce.Left = lbsplit.Left + lbsplit.Width + 5;
                        lbIce.Top = curTop;
                        lbIce.Font = Sessions.Sessions.NOMAL_FONT;
                        lbIce.Width = (4 * Width / 100 > Sessions.Sessions.MINIMUM_WIDTH * 1.5) ? 4 * Width / 100 : (int)(Sessions.Sessions.MINIMUM_WIDTH * 1.5);

                        Label numIce = new();

                        PictureBox plusIce = new PictureBox();
                        plusIce.Paint += (sender, e) =>
                        {
                            var plus_icon = Properties.Resources.plus_icon;
                            Bitmap bit_plus = new(plus_icon, new Size(20, 20));
                            e.Graphics.DrawImage(bit_plus, 0, 0);
                        };
                        plusIce.Click += (sender, e) =>
                        {
                            ChangeSugarIceNum(item, curValuePos, false, false, numIce);
                        };
                        plusIce.Top = curTop;
                        plusIce.Left = lbIce.Left + lbIce.Width;
                        plusIce.Width = roundButtonSize.Width;
                        plusIce.Height = roundButtonSize.Width;

                        numIce.Text = iceValue + "%";
                        numIce.Top = curTop;
                        numIce.Left = plusIce.Left + plusIce.Width + 10;
                        numIce.Font = Sessions.Sessions.NOMAL_FONT;
                        numIce.Width = (5 * Width / 100 > Sessions.Sessions.MINIMUM_WIDTH * 1.5) ? 5 * Width / 100 : (int)(Sessions.Sessions.MINIMUM_WIDTH * 1.5);

                        PictureBox minusIce = new PictureBox();
                        minusIce.Paint += (sender, e) =>
                        {
                            var minus_icon = Properties.Resources.minus_icon;
                            Bitmap bit_minus = new(minus_icon, roundButtonSize);

                            e.Graphics.DrawImage(bit_minus, 0, 0);
                        };
                        minusIce.Click += (sender, e) =>
                        {
                            ChangeSugarIceNum(item, curValuePos, false, true, numIce);
                        };
                        minusIce.Top = curTop;
                        minusIce.Left = numIce.Left + numIce.Width;
                        minusIce.Width = roundButtonSize.Width;
                        minusIce.Height = roundButtonSize.Width;

                        pnData.Controls.Add(lbsugar);
                        pnData.Controls.Add(plusSugar);
                        pnData.Controls.Add(numSugar);
                        pnData.Controls.Add(minusSugar);
                        pnData.Controls.Add(lbsplit);
                        pnData.Controls.Add(lbIce);
                        pnData.Controls.Add(plusIce);
                        pnData.Controls.Add(numIce);
                        pnData.Controls.Add(minusIce);

                        curTop += lbsugar.Height + 10;
                    }
                }
                #endregion

                borderPanel.Height = curTop - borderPanel.Top;
                borderPanel.Left = 0;
                borderPanel.Width = this.Width;

                //Add to control

                pnData.Controls.Add(lbQuantity);
                pnData.Controls.Add(lbName);
                pnData.Controls.Add(minusButton);
                pnData.Controls.Add(plusButton);
                pnData.Controls.Add(lbPrice);
                pnData.Controls.Add(lbSubtotal);
                pnData.Controls.Add(borderPanel);

                total += subTotal;
                curTop += 10;
            }
            this.oDataPanel.Focus();
            if (pnData.Height < curTop)
            {
                this.pnData.Height = curTop;
                pnData.AutoScroll = true;
                this.oDataPanel.AutoScroll = true;
            }
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

            _orderDataPanel.Controls.Clear();
            OrderDataForm myForm = new OrderDataForm(_orderDataPanel);
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            _orderDataPanel.Controls.Add(myForm);
            myForm.Show();
        }

        private void ChangeSugarIceNum(OrderDetailViewModel item, int curValuePos, bool sugar, bool minus, Label lb)
        {
            var numValue = JsonConvert.DeserializeObject<List<DetailValue>>(item.Description);

            int changedSugar = numValue[curValuePos].Sugar;
            int changedIce = numValue[curValuePos].Ice;

            if (sugar)
            {
                if (minus && changedSugar > 0) changedSugar -= 25;
                if (!minus) changedSugar += 25;
                lb.Text = changedSugar + "%";
            }
            else
            {
                if (minus && changedIce > 0) changedIce -= 25;
                if (!minus) changedIce += 25;
                lb.Text = changedIce + "%";
            }

            //Save change
            var changedValue = new DetailValue() { Ice = changedIce, Sugar = changedSugar };
            numValue[curValuePos] = changedValue;
            Sessions.Order.CurrentOrder.OrderDetail.Remove(item);
            item.Description = JsonConvert.SerializeObject(numValue);
            Sessions.Order.CurrentOrder.OrderDetail.Add(item);

            this.oDataPanel.Focus();
        }
    }
}
