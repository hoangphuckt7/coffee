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
    public partial class OrderDataForm : Form
    {
        private readonly Panel _orderDataPanel;
        List<TableViewModel> tables;
        public OrderDataForm(Panel orderDataPanel)
        {
            InitializeComponent();
            _orderDataPanel = orderDataPanel;
        }

        private async void OrderDataForm_Load(object sender, EventArgs e)
        {
            #region Order
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.MaximizeBox = false;

            if (Sessions.Order.CurrentOrder.OrderDetail.Count == 0) Sessions.Order.Option = new();

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
                lbName.AllowDrop = true;
                lbName.AutoSize = false;
                lbName.Text = Sessions.ItemSession.ItemData.First(f => f.Id == item.ItemId).Name;

                lbName.Top = curTop;
                lbName.Left = 2 * Width / 100;
                lbName.Font = Sessions.Sessions.NORMAL_BOLD_FONT;
                lbName.Width = 35 * Width / 100;
                var nameH = (int)Math.Round((lbName.Text.Length * lbName.Font.Size / lbName.Width), MidpointRounding.AwayFromZero);
                lbName.Height *= nameH > 1 ? nameH : 1;

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
                lbQuantity.Font = Sessions.Sessions.NORMAL_FONT;
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
                lbPrice.Text = itemPrice.ToString("#,###", Application.CurrentCulture.NumberFormat) + "₫";
                lbPrice.Font = Sessions.Sessions.NORMAL_FONT;
                lbPrice.Left = 60 * Width / 100;
                lbPrice.Top = curTop;
                lbPrice.TextAlign = ContentAlignment.MiddleRight;

                //Subtotal
                double subTotal = itemQuantity * itemPrice;
                Label lbSubtotal = new();
                lbSubtotal.Text = subTotal.ToString("#,###", Application.CurrentCulture.NumberFormat) + "₫";
                lbSubtotal.Font = Sessions.Sessions.NORMAL_FONT;
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
                            Left = lbName.Left,
                            Top = curTop,
                            Font = Sessions.Sessions.NORMAL_FONT,
                            Width = (7 * Width / 100 > Sessions.Sessions.MINIMUM_WIDTH * 1.7) ? 7 * Width / 100 : (int)(Sessions.Sessions.MINIMUM_WIDTH * 1.7)
                        };

                        Label numSugar = new();
                        TextBox note = new();

                        PictureBox plusSugar = new PictureBox();
                        plusSugar.Paint += (sender, e) =>
                        {
                            var plus_icon = Properties.Resources.plus_icon;
                            Bitmap bit_plus = new(plus_icon, new Size(20, 20));
                            e.Graphics.DrawImage(bit_plus, 0, 0);
                        };
                        plusSugar.Click += (sender, e) =>
                        {
                            ChangeSugarIceNum(item, curValuePos, true, false, numSugar, note.Text);
                        };
                        plusSugar.Top = curTop;
                        plusSugar.Left = lbsugar.Left + lbsugar.Width;
                        plusSugar.Width = roundButtonSize.Width;
                        plusSugar.Height = roundButtonSize.Width;

                        numSugar.Text = sgValue + "%";
                        numSugar.Top = curTop;
                        numSugar.Left = plusSugar.Left + plusSugar.Width;
                        numSugar.Font = Sessions.Sessions.NORMAL_FONT;
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
                            ChangeSugarIceNum(item, curValuePos, true, true, numSugar, note.Text);
                        };
                        minusSugar.Top = curTop;
                        minusSugar.Left = numSugar.Left + numSugar.Width;
                        minusSugar.Width = roundButtonSize.Width;
                        minusSugar.Height = roundButtonSize.Width;

                        Label lbsplit = new();
                        lbsplit.Text = "-";
                        lbsplit.Left = minusSugar.Left + minusSugar.Width;
                        lbsplit.Top = curTop;
                        lbsplit.Font = Sessions.Sessions.NORMAL_FONT;
                        lbsplit.Width = 10;

                        Label lbIce = new();
                        lbIce.Text = "Đá";
                        lbIce.Left = lbsplit.Left + lbsplit.Width;
                        lbIce.Top = curTop;
                        lbIce.Font = Sessions.Sessions.NORMAL_FONT;
                        lbIce.Width = (4 * Width / 100 > Sessions.Sessions.MINIMUM_WIDTH * 1) ? 4 * Width / 100 : (int)(Sessions.Sessions.MINIMUM_WIDTH * 1);

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
                            ChangeSugarIceNum(item, curValuePos, false, false, numIce, note.Text);
                        };
                        plusIce.Top = curTop;
                        plusIce.Left = lbIce.Left + lbIce.Width;
                        plusIce.Width = roundButtonSize.Width;
                        plusIce.Height = roundButtonSize.Width;

                        numIce.Text = iceValue + "%";
                        numIce.Top = curTop;
                        numIce.Left = plusIce.Left + plusIce.Width;
                        numIce.Font = Sessions.Sessions.NORMAL_FONT;
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
                            ChangeSugarIceNum(item, curValuePos, false, true, numIce, note.Text);
                        };
                        minusIce.Top = curTop;
                        minusIce.Left = numIce.Left + numIce.Width;
                        minusIce.Width = roundButtonSize.Width;
                        minusIce.Height = roundButtonSize.Width;

                        note.PlaceholderText = "Ghi chú";
                        note.Left = minusIce.Left + minusIce.Width + 10;
                        note.Top = curTop;
                        note.Text = numValue[curValuePos].Note;

                        note.Width = Width - note.Left - 5 * Width / 100;

                        note.TextChanged += (sender, e) =>
                        {
                            var changedValue = new DetailValue() { Ice = iceValue, Sugar = sgValue, Note = note.Text };

                            var curItem = Sessions.Order.CurrentOrder.OrderDetail.First(f => f.ItemId == item.ItemId);

                            Sessions.Order.CurrentOrder.OrderDetail.Remove(curItem);

                            var de = JsonConvert.DeserializeObject<List<DetailValue>>(curItem.Description);
                            de[curValuePos] = changedValue;
                            curItem.Description = JsonConvert.SerializeObject(de);

                            Sessions.Order.CurrentOrder.OrderDetail.Add(curItem);
                        };

                        pnData.Controls.Add(lbsugar);
                        pnData.Controls.Add(plusSugar);
                        pnData.Controls.Add(numSugar);
                        pnData.Controls.Add(minusSugar);
                        pnData.Controls.Add(lbsplit);
                        pnData.Controls.Add(lbIce);
                        pnData.Controls.Add(plusIce);
                        pnData.Controls.Add(numIce);
                        pnData.Controls.Add(minusIce);
                        pnData.Controls.Add(note);

                        curTop += lbsugar.Height + 10;
                    }
                }
                #endregion

                borderPanel.Height = curTop - borderPanel.Top;
                borderPanel.Left = 0;
                borderPanel.Width = this.Width;

                //Add to control

                pnData.Controls.Add(lbName);
                pnData.Controls.Add(lbQuantity);
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
            #endregion

            #region Data
            RoundedButton submitButton = new();
            ComboBox cbArea = new();
            ComboBox cbTable = new();

            //First section
            Label quanLable = new Label
            {
                Top = 1 * Height / 100,
                Left = 2 * Width / 100,
                Font = Sessions.Sessions.NORMAL_BOLD_FONT,
                Text = "Số lượng: "
            };

            Label quanDataLable = new()
            {
                Width = oFooterPanel.Width - quanLable.Width - quanLable.Left - 2 * Width / 100,
                Top = quanLable.Top,
                Left = quanLable.Left + quanLable.Width,
                Font = Sessions.Sessions.NORMAL_BOLD_FONT,
                Text = Sessions.Order.CurrentOrder.OrderDetail.Select(s => s.Quantity).Sum() + "",
                TextAlign = ContentAlignment.MiddleRight
            };

            double tt = 0;
            foreach (var item in Sessions.Order.CurrentOrder.OrderDetail)
            {
                var curItem = Sessions.ItemSession.ItemData.First(f => f.Id == item.ItemId);
                tt += item.Quantity * curItem.Price;
            }

            Label ttLabel = new()
            {
                Top = quanDataLable.Top + quanDataLable.Height + 10,
                Left = 2 * Width / 100,
                Font = Sessions.Sessions.NORMAL_BOLD_FONT,
                Text = "Tổng: ",
            };

            Label ttDataLabel = new()
            {
                Top = ttLabel.Top,
                Width = oFooterPanel.Width - ttLabel.Width - ttLabel.Left - 2 * Width / 100,
                Left = ttLabel.Left + ttLabel.Width,
                Font = Sessions.Sessions.NORMAL_BOLD_FONT,
                Text = (tt == 0 ? "0" : tt.ToString("#,###", Application.CurrentCulture.NumberFormat)) + "₫",
                TextAlign = ContentAlignment.MiddleRight
            };

            Panel splitPanel1 = new()
            {
                Width = oFooterPanel.Width * 96 / 100,
                Height = 1,
                Top = ttLabel.Top + ttLabel.Height + 10,
                Left = Width * 2 / 100,
                BackColor = Color.FromKnownColor(KnownColor.Control)
            };

            //Second Section
            Label type = new()
            {
                Text = "Hình thức:",
                Width = 90,
                Left = 2 * Width / 100,
                Top = ttLabel.Top + ttLabel.Height + 20,
                Font = Sessions.Sessions.NORMAL_BOLD_FONT,
                TextAlign = ContentAlignment.MiddleLeft
            };
            RadioButton isTable = new();
            RadioButton isTakeAway = new();
            RadioButton unknow = new();

            int reWidth = oFooterPanel.Width - type.Width - type.Left - 2 * Width / 100;

            if (!Sessions.Order.Option.Unknow && !Sessions.Order.Option.Table && !Sessions.Order.Option.TakeAway)
            {
                Sessions.Order.Option.Unknow = true;
            }

            isTable.Text = "Tại bàn";
            isTable.Width = 90;
            isTable.Top = type.Top;
            isTable.Checked = Sessions.Order.Option.Table;
            isTable.Font = Sessions.Sessions.NORMAL_BOLD_FONT;

            isTakeAway.Text = "Mang đi";
            isTakeAway.Width = 90;
            isTakeAway.Top = type.Top;
            isTakeAway.Checked = Sessions.Order.Option.TakeAway;
            isTakeAway.Font = Sessions.Sessions.NORMAL_BOLD_FONT;

            unknow.Text = "Chưa rõ bàn";
            unknow.Width = 120;
            unknow.Top = type.Top;
            unknow.Checked = Sessions.Order.Option.Unknow;
            unknow.Font = Sessions.Sessions.NORMAL_BOLD_FONT;

            isTable.Left = oFooterPanel.Width - reWidth;
            isTakeAway.Left = oFooterPanel.Width - (reWidth - reWidth / 3);
            unknow.Left = oFooterPanel.Width - (reWidth - (reWidth / 3) * 2);

            Label lableArea = new()
            {
                Top = unknow.Top + unknow.Height + 10,
                Left = 2 * Width / 100,
                Font = Sessions.Sessions.NORMAL_BOLD_FONT,
                Text = "Khu vực: ",
                TextAlign = ContentAlignment.MiddleLeft,
                Visible = false
            };

            cbArea.Top = unknow.Top + unknow.Height + 10;
            cbArea.Left = lableArea.Left + lableArea.Width;
            cbArea.DropDownStyle = ComboBoxStyle.DropDownList;
            cbArea.DataSource = Sessions.Area.Areas.Select(s => s.Description).ToList();
            cbArea.Font = Sessions.Sessions.NORMAL_BOLD_FONT;
            cbArea.Visible = Sessions.Order.Option.Table;

            cbArea.SelectedIndexChanged += async (sender, e) =>
            {
                var tableData = await ApiBuilder.SendRequest<List<TableViewModel>>("api/Table?floorId=" + Sessions.Area.Areas[cbArea.SelectedIndex].Id, null, RequestMethod.GET);
                tables = JsonConvert.DeserializeObject<List<TableViewModel>>(tableData);

                cbTable.DataSource = tables.Select(s => s.Description).ToList();
            };

            Label lableTable = new()
            {
                Top = unknow.Top + unknow.Height + 10,
                Left = cbArea.Left + cbArea.Width,
                Font = Sessions.Sessions.NORMAL_BOLD_FONT,
                Text = "Bàn: ",
                TextAlign = ContentAlignment.MiddleLeft,
                Visible = Sessions.Order.Option.Table
            };

            cbTable.Top = unknow.Top + unknow.Height + 10;
            cbTable.Left = lableTable.Left + lableTable.Width;
            cbTable.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTable.Font = Sessions.Sessions.NORMAL_BOLD_FONT;
            cbTable.Visible = Sessions.Order.Option.Table;

            var tableData = await ApiBuilder.SendRequest<List<TableViewModel>>("api/Table?floorId=" + Sessions.Area.Areas[0].Id, null, RequestMethod.GET);
            tables = JsonConvert.DeserializeObject<List<TableViewModel>>(tableData);

            cbTable.DataSource = tables.Select(s => s.Description).ToList();

            submitButton.Text = "Order";
            submitButton.Height = 13 * oFooterPanel.Height / 100;
            submitButton.Width = 96 * Width / 100;
            submitButton.Left = 2 * Width / 100;
            submitButton.Font = Sessions.Sessions.NORMAL_BOLD_FONT;
            submitButton.BackColor = Sessions.Sessions.BUTTON_COLOR;
            submitButton.Top = oFooterPanel.Height - submitButton.Height - 10;
            if (Sessions.Order.CurrentOrder.OrderDetail.Count < 1) { submitButton.Enabled = false; submitButton.BackColor = Color.Gray; }

            isTable.CheckedChanged += (sender, e) =>
            {
                submitButton.Text = "Order";
                cbArea.Visible = true;
                cbTable.Visible = true;
                lableTable.Visible = true;
                lableArea.Visible = true;
                Sessions.Order.Option.Table = true;
                Sessions.Order.Option.Unknow = false;
                Sessions.Order.Option.TakeAway = false;
            };

            isTakeAway.CheckedChanged += (sender, e) =>
            {
                submitButton.Text = "Thanh toán";
                cbArea.Visible = false;
                cbTable.Visible = false;
                lableTable.Visible = false;
                lableArea.Visible = false;
                Sessions.Order.Option.Table = false;
                Sessions.Order.Option.Unknow = false;
                Sessions.Order.Option.TakeAway = true;
            };

            unknow.CheckedChanged += (sender, e) =>
            {
                submitButton.Text = "Order";
                cbArea.Visible = false;
                cbTable.Visible = false;
                lableTable.Visible = false;
                lableArea.Visible = false;
                Sessions.Order.Option.Table = false;
                Sessions.Order.Option.Unknow = true;
                Sessions.Order.Option.TakeAway = false;
            };

            submitButton.Click += async (sender, ev) =>
            {
                if (Sessions.Order.CurrentOrder.OrderDetail.Count < 1)
                {
                    return;
                }

                const string messageEx = "Xác nhận thông tin order.";
                const string captionEx = "Xác nhận";
                var result = MessageBox.Show(messageEx, captionEx, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                // If the no button was pressed ...
                if (result == DialogResult.Cancel)
                {
                    return;
                }

                if (isTable.Checked) Sessions.Order.CurrentOrder.TableId = tables[cbTable.SelectedIndex < 0 ? 0 : cbTable.SelectedIndex].Id;

                if (isTakeAway.Checked) printBill.Print();

                if (!isTable.Checked) Sessions.Order.CurrentOrder.TableId = null;

                var data = await ApiBuilder.SendRequest("api/Order", Sessions.Order.CurrentOrder, RequestMethod.POST);

                //Refresh
                Sessions.Order.CurrentOrder.OrderDetail = new List<OrderDetailViewModel>();
                Sessions.Order.Option = new();

                _orderDataPanel.Controls.Clear();
                OrderDataForm myForm = new OrderDataForm(_orderDataPanel);
                myForm.TopLevel = false;
                myForm.AutoScroll = true;
                _orderDataPanel.Controls.Add(myForm);
                myForm.Show();
            };

            oFooterPanel.Controls.Add(quanLable);
            oFooterPanel.Controls.Add(quanDataLable);

            oFooterPanel.Controls.Add(ttLabel);
            oFooterPanel.Controls.Add(ttDataLabel);

            //Split
            oFooterPanel.Controls.Add(splitPanel1);

            oFooterPanel.Controls.Add(type);
            oFooterPanel.Controls.Add(isTable);
            oFooterPanel.Controls.Add(isTakeAway);
            oFooterPanel.Controls.Add(unknow);

            oFooterPanel.Controls.Add(lableArea);
            oFooterPanel.Controls.Add(cbArea);

            oFooterPanel.Controls.Add(lableTable);
            oFooterPanel.Controls.Add(cbTable);

            oFooterPanel.Controls.Add(submitButton);
            #endregion
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
        private void ChangeSugarIceNum(OrderDetailViewModel item, int curValuePos, bool sugar, bool minus, Label lb, string note)
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
            var changedValue = new DetailValue() { Ice = changedIce, Sugar = changedSugar, Note = note };
            numValue[curValuePos] = changedValue;
            Sessions.Order.CurrentOrder.OrderDetail.Remove(item);
            item.Description = JsonConvert.SerializeObject(numValue);
            Sessions.Order.CurrentOrder.OrderDetail.Add(item);

            this.oDataPanel.Focus();

        }

        private void printBill_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Sessions.Order.OldOrders.Add(new OrderHistoryModel()
            {
                DateCreated = DateTime.Now,
                OrderDetail = Sessions.Order.CurrentOrder.OrderDetail,
                TableId = Sessions.Order.CurrentOrder.TableId
            });
            var curImg = BillPrinter.SetupBill(Sessions.Order.CurrentOrder, null);
            //var final = ImageUtils.ResizeImage(curImg, curImg.Width / 2, curImg.Height / 2);
            e.Graphics.DrawImage(curImg, 0, 0);
        }
    }
}
