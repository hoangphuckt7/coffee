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
                    Sessions.Sessions.MENU_COLOR, 0, ButtonBorderStyle.Solid, // left
                    Sessions.Sessions.MENU_COLOR, 1, ButtonBorderStyle.Solid, // top
                    Sessions.Sessions.MENU_COLOR, 0, ButtonBorderStyle.Solid, // right
                    Sessions.Sessions.MENU_COLOR, 0, ButtonBorderStyle.Solid);// bottom
                };
                borderPanel.Top = curTop - 10;

                //Name
                Label lbName = new();
                lbName.Text = Sessions.ItemSession.ItemData.First(f => f.Id == item.ItemId).Name;
                lbName.Top = curTop;
                lbName.Left = 2 * Width / 100;
                lbName.Font = Sessions.Sessions.NOMAL_FONT;

                //Quantity
                int itemQuantity = item.Quantity;
                NumericUpDown lbQuantity = new();
                lbQuantity.Text = itemQuantity.ToString();
                lbQuantity.Font = Sessions.Sessions.NOMAL_FONT;
                lbQuantity.Left = 40 * Width / 100;
                lbQuantity.Top = curTop;
                lbQuantity.ValueChanged += (sender, e) =>
                {
                    var curItem = Sessions.Order.CurrentOrder.OrderDetail.FirstOrDefault(f => f.ItemId == item.ItemId);
                    if (lbQuantity.Value > 0)
                    {
                        Sessions.Order.CurrentOrder.OrderDetail.Remove(curItem);

                        curItem.Quantity = int.Parse(lbQuantity.Value.ToString());
                        var numValue = JsonConvert.DeserializeObject<List<DetailValue>>(curItem.Description);
                        numValue.Add(new DetailValue() { Ice = 100, Sugar = 100 });
                        curItem.Description = JsonConvert.SerializeObject(numValue);

                        Sessions.Order.CurrentOrder.OrderDetail.Add(curItem);
                    }
                    else
                    {
                        Sessions.Order.CurrentOrder.OrderDetail.Remove(curItem);
                    }

                    _orderDataPanel.Controls.Clear();
                    OrderDataForm myForm = new OrderDataForm(_orderDataPanel);
                    myForm.TopLevel = false;
                    myForm.AutoScroll = true;
                    _orderDataPanel.Controls.Add(myForm);
                    myForm.Show();
                };
                lbQuantity.Width = 7 * Width / 100;

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
                for (int i = 0; i < lbQuantity.Value; i++)
                {
                    var numValue = JsonConvert.DeserializeObject<List<DetailValue>>(item.Description);

                    var curValuePos = i;
                    int iceValue = numValue[curValuePos].Ice;
                    int sgValue = numValue[curValuePos].Sugar;

                    Label lbsugar = new();
                    lbsugar.Text = "Đường";
                    lbsugar.Left = lbQuantity.Left;
                    lbsugar.Top = curTop;
                    lbsugar.Font = Sessions.Sessions.NOMAL_FONT;
                    lbsugar.Width = 7 * Width / 100;

                    NumericUpDown numSugar = new();
                    numSugar.Value = sgValue;
                    numSugar.Top = curTop;
                    numSugar.Left = lbsugar.Left + lbsugar.Width + 2;
                    numSugar.Font = Sessions.Sessions.NOMAL_FONT;
                    numSugar.Width = 7 * Width / 100;
                    numSugar.Maximum = 100;
                    numSugar.Minimum = 0;
                    numSugar.ValueChanged += (sender, e) =>
                    {
                        if (numSugar.Value > sgValue)
                        {
                            if (numSugar.Value != 0 && numSugar.Value != 25 && numSugar.Value != 50 && numSugar.Value != 75 && numSugar.Value != 100)
                            {
                                numSugar.Value += 24;
                                sgValue = int.Parse(numSugar.Value.ToString());

                                //Save change
                                var changedValue = new DetailValue() { Ice = iceValue, Sugar = sgValue };
                                numValue[curValuePos] = changedValue;
                                Sessions.Order.CurrentOrder.OrderDetail.Remove(item);
                                item.Description = JsonConvert.SerializeObject(numValue);
                                Sessions.Order.CurrentOrder.OrderDetail.Add(item);

                                this.oDataPanel.Focus();
                            }
                        }
                        else if (numSugar.Value < sgValue)
                        {
                            if (numSugar.Value != 0 && numSugar.Value != 25 && numSugar.Value != 50 && numSugar.Value != 75 && numSugar.Value != 100)
                            {
                                numSugar.Value -= 24;
                                sgValue = int.Parse(numSugar.Value.ToString());

                                //Save change
                                var changedValue = new DetailValue() { Ice = iceValue, Sugar = sgValue };
                                numValue[curValuePos] = changedValue;
                                Sessions.Order.CurrentOrder.OrderDetail.Remove(item);
                                item.Description = JsonConvert.SerializeObject(numValue);
                                Sessions.Order.CurrentOrder.OrderDetail.Add(item);

                                this.oDataPanel.Focus();
                            }
                        }
                    };

                    Label lbIce = new();
                    lbIce.Text = "Đá";
                    lbIce.Left = numSugar.Left + numSugar.Width;
                    lbIce.Top = curTop;
                    lbIce.Font = Sessions.Sessions.NOMAL_FONT;
                    lbIce.Width = 7 * Width / 100;
                    lbIce.TextAlign = ContentAlignment.MiddleRight;

                    NumericUpDown numIce = new();
                    numIce.Value = iceValue;
                    numIce.Top = curTop;
                    numIce.Left = lbIce.Left + lbIce.Width + 2;
                    numIce.Font = Sessions.Sessions.NOMAL_FONT;
                    numIce.Width = 7 * Width / 100;
                    numIce.Maximum = 100;
                    numIce.Minimum = 0;
                    numIce.ValueChanged += (sender, e) =>
                    {
                        if (numIce.Value > iceValue)
                        {
                            if (numIce.Value != 0 && numIce.Value != 25 && numIce.Value != 50 && numIce.Value != 75 && numIce.Value != 100)
                            {
                                numIce.Value += 24;
                                iceValue = int.Parse(numIce.Value.ToString());

                                //Save change
                                var changedValue = new DetailValue() { Ice = iceValue, Sugar = sgValue };
                                numValue[curValuePos] = changedValue;
                                Sessions.Order.CurrentOrder.OrderDetail.Remove(item);
                                item.Description = JsonConvert.SerializeObject(numValue);
                                Sessions.Order.CurrentOrder.OrderDetail.Add(item);

                                this.oDataPanel.Focus();
                            }
                        }
                        else if (numIce.Value < iceValue)
                        {
                            if (numIce.Value != 0 && numIce.Value != 25 && numIce.Value != 50 && numIce.Value != 75 && numIce.Value != 100)
                            {
                                numIce.Value -= 24;

                                iceValue = int.Parse(numIce.Value.ToString());

                                //Save change
                                var changedValue = new DetailValue() { Ice = iceValue, Sugar = sgValue };
                                numValue[curValuePos] = changedValue;
                                Sessions.Order.CurrentOrder.OrderDetail.Remove(item);
                                item.Description = JsonConvert.SerializeObject(numValue);
                                Sessions.Order.CurrentOrder.OrderDetail.Add(item);

                                this.oDataPanel.Focus();
                            }
                        }
                    };

                    pnData.Controls.Add(lbsugar);
                    pnData.Controls.Add(numSugar);
                    pnData.Controls.Add(lbIce);
                    pnData.Controls.Add(numIce);

                    curTop += lbsugar.Height + 10;
                }
                #endregion


                borderPanel.Height = curTop - borderPanel.Top;
                borderPanel.Left = 0;
                borderPanel.Width = this.Width;

                //Add to control
                pnData.Controls.Add(lbName);
                pnData.Controls.Add(lbQuantity);
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
    }
}
