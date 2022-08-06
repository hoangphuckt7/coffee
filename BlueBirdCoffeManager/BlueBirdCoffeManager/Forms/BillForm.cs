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
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlueBirdCoffeManager.Forms
{
    public partial class BillForm : Form
    {
        Label split;
        private readonly List<OrderViewModel>? _orders;
        private const string RE_PRINT = "In lại";
        private const string CHECK_OUT = "Thanh toán";
        private List<DescriptionViewModel> FLOORS = Sessions.Area.Areas;
        List<CheckSelected> checkSelecteds = new();
        List<TableViewModel> tables;

        private readonly Guid? floorId;
        private readonly Guid? tableId;

        public BillForm(List<OrderViewModel>? orders, Guid? fl, Guid? tb)
        {
            InitializeComponent();
            _orders = orders;
            floorId = fl;
            tableId = tb;
        }

        private async void BillForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.MaximizeBox = false;

            oldBillPicture.Visible = false;

            leftPanel.Width = (int)(33.33 * Width / 100);
            mainPanel.Width = (int)(33.33 * Width / 100);
            lostBillPanel.Width = (int)(33.33 * Width / 100);

            dataPanel.Width = mainPanel.Width;

            //dataBotPanel.top

            btnCheckout.Font = Sessions.Sessions.NORMAL_BOLD_FONT;
            btnCheckout.Top = Height - btnCheckout.Height - 10;
            btnCheckout.Width = leftPanel.Width - 4 * leftPanel.Width / 100;
            btnCheckout.Left = 2 * leftPanel.Width / 100;
            btnCheckout.BackColor = Sessions.Sessions.BUTTON_COLOR;

            dataPanel.Top = 0;
            dataPanel.Left = 0;
            dataPanel.Height = btnCheckout.Top;

            areaPanel.Top = 0;
            areaPanel.Left = 0;
            areaPanel.Width = leftPanel.Width - 1;
            areaPanel.Height = 50 * leftPanel.Height / 100;
            areaPanel.BackColor = Color.White;

            oldBillPanel.Top = areaPanel.Top + areaPanel.Height;
            oldBillPanel.Left = 0;
            oldBillPanel.Height = leftPanel.Height - areaPanel.Height;
            oldBillPanel.Width = leftPanel.Width - 1;
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

            #region Area Setup
            areaToolPanel.Left = 0;
            areaToolPanel.Top = 0;
            areaToolPanel.Width = areaPanel.Width;
            areaToolPanel.BackColor = Color.FromKnownColor(KnownColor.Control);

            lbArea.Top = 2 * Height / 100;
            lbArea.Left = 1 * Width / 100;
            lbArea.Font = Sessions.Sessions.NORMAL_BOLD_FONT;
            lbArea.Width = (int)(lbArea.Font.Size * lbArea.Text.Length);

            cbArea.Top = lbArea.Top;
            cbArea.Left = lbArea.Left + lbArea.Width;

            lbTable.Top = lbArea.Top;
            lbTable.Left = cbArea.Left + cbArea.Width + 5 * Width / 100;
            lbTable.Font = Sessions.Sessions.NORMAL_BOLD_FONT;
            lbTable.Width = (int)(lbTable.Font.Size * lbTable.Text.Length);

            cbTable.Top = lbArea.Top;
            cbTable.Left = lbTable.Left + lbTable.Width;

            areaToolPanel.Height = lbArea.Top * 2 + lbArea.Height;

            btnAdd.Left = 2 * areaPanel.Width / 100;
            btnAdd.Width = 96 * areaPanel.Width / 100;
            btnAdd.Top = areaPanel.Height - btnAdd.Height - 1 * Height / 100;
            btnAdd.BackColor = Sessions.Sessions.BUTTON_COLOR;

            tableOrderDataPn.Top = areaToolPanel.Top + areaToolPanel.Height;
            tableOrderDataPn.Height = areaPanel.Height - tableOrderDataPn.Top - btnAdd.Height - (int)(1.5 * Height / 100);
            tableOrderDataPn.Left = 0;
            tableOrderDataPn.Width = areaToolPanel.Width;

            if (FLOORS == null || FLOORS.Count == 0)
            {
                var rawData = await ApiBuilder.SendRequest<List<DescriptionViewModel>>("api/Floor", null, RequestMethod.GET);
                FLOORS = JsonConvert.DeserializeObject<List<DescriptionViewModel>>(rawData);
                Sessions.Area.Areas = FLOORS;
            }

            cbArea.DataSource = FLOORS.Select(s => s.Description).ToList();
            cbArea.DropDownStyle = ComboBoxStyle.DropDownList;
            cbArea.Font = Sessions.Sessions.NORMAL_BOLD_FONT;

            var tableData = await ApiBuilder.SendRequest<List<TableViewModel>>("api/Table?floorId=" + Sessions.Area.Areas[0].Id, null, RequestMethod.GET);
            tables = JsonConvert.DeserializeObject<List<TableViewModel>>(tableData);
            cbTable.DataSource = tables.Select(s => s.Description).ToList();

            cbArea.SelectedIndexChanged += async (sender, e) =>
            {
                var tableData = await ApiBuilder.SendRequest<List<TableViewModel>>("api/Table?floorId=" + Sessions.Area.Areas[cbArea.SelectedIndex].Id, null, RequestMethod.GET);
                tables = JsonConvert.DeserializeObject<List<TableViewModel>>(tableData);

                cbTable.DataSource = tables.Select(s => s.Description).ToList();
            };

            cbTable.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTable.Font = Sessions.Sessions.NORMAL_BOLD_FONT;

            if (floorId != null)
            {
                cbArea.SelectedIndex = FLOORS.IndexOf(FLOORS.FirstOrDefault(f => f.Id == floorId.Value));

                var x = await ApiBuilder.SendRequest<List<TableViewModel>>("api/Table?floorId=" + floorId, null, RequestMethod.GET);
                tables = JsonConvert.DeserializeObject<List<TableViewModel>>(x);
                cbTable.DataSource = tables.Select(s => s.Description).ToList();
            }

            if (tableId != null)
            {
                cbTable.SelectedIndex = tables.IndexOf(tables.FirstOrDefault(f => f.Id == tableId.Value));
            }

            tableOrderDataPn.AutoScroll = true;
            #endregion

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

            split = new()
            {
                Top = curTop,
                Width = mainPanel.Width,
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

            lbOldOrdersTilte.Font = Sessions.Sessions.NORMAL_BOLD_FONT;
            lbOldOrdersTilte.Left = leftPanel.Width / 2 - lbOldOrdersTilte.Width / 2;
            lbOldOrdersTilte.Top = 10;

            pnHistoryTitle.Top = 0;
            pnHistoryTitle.Left = 0;
            pnHistoryTitle.BackColor = Color.FromKnownColor(KnownColor.Control);
            pnHistoryTitle.Width = leftPanel.Width - 1;
            pnHistoryTitle.Height = lbOldOrdersTilte.Height + lbOldOrdersTilte.Top + lbOldOrdersTilte.Top;

            curTop = pnHistoryTitle.Height + pnHistoryTitle.Top + 5;

            var oldOrdersData = Sessions.Order.OldOrders.OrderByDescending(f => f.DateCreated);

            foreach (var item in oldOrdersData)
            {
                var total = item.OrderDetail.Select(s => Sessions.ItemSession.ItemData.First(f => f.Id == s.ItemId).Price * s.Quantity).Sum();

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
                    Text = "Thời gian: " + BillPrinter.FormatDate(item.DateCreated) + " - Tổng: " + BillPrinter.FormatPrice(total) + "₫",
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
                    ControlPaint.DrawBorder(e.Graphics, borderPanel.ClientRectangle,
                    Color.FromKnownColor(KnownColor.Control), 0, ButtonBorderStyle.Solid, // left
                    Color.FromKnownColor(KnownColor.Control), 0, ButtonBorderStyle.Solid, // top
                    Color.FromKnownColor(KnownColor.DarkGray), 1, ButtonBorderStyle.Solid, // right
                    Color.FromKnownColor(KnownColor.DarkGray), 1, ButtonBorderStyle.Solid);// bottom
                };

                #region mouse move
                borderPanel.MouseMove += (sender, e) =>
                {
                    borderPanel.BackColor = Color.FromKnownColor(KnownColor.DarkGray);
                };

                borderPanel.MouseEnter += (sender, e) =>
                {
                    borderPanel.BackColor = Color.FromKnownColor(KnownColor.DarkGray);
                };

                borderPanel.MouseLeave += (sender, e) =>
                {
                    borderPanel.BackColor = Color.FromKnownColor(KnownColor.Control);
                };

                timeLabel.MouseMove += (sender, e) =>
                {
                    borderPanel.BackColor = Color.FromKnownColor(KnownColor.DarkGray);
                };

                timeLabel.MouseLeave += (sender, e) =>
                {
                    borderPanel.BackColor = Color.FromKnownColor(KnownColor.Control);
                };

                typeLabel.MouseMove += (sender, e) =>
                {
                    borderPanel.BackColor = Color.FromKnownColor(KnownColor.DarkGray);
                };

                typeLabel.MouseLeave += (sender, e) =>
                {
                    borderPanel.BackColor = Color.FromKnownColor(KnownColor.Control);
                };
                #endregion

                #region Click
                borderPanel.Click += (sender, e) =>
                {
                    curImg = BillPrinter.SetupBill(item, item.DateCreated);

                    oldBillPicture.Image = curImg;
                    oldBillPicture.Width = curImg.Width;
                    oldBillPicture.Height = curImg.Height;

                    oldBillPicture.Left = leftPanel.Width / 2 - oldBillPicture.Width / 2;

                    oldBillPicture.Top = 5 * Height / 100;

                    DisableCheckout();
                };

                timeLabel.Click += (sender, e) =>
                {
                    curImg = BillPrinter.SetupBill(item, item.DateCreated);

                    oldBillPicture.Image = curImg;
                    oldBillPicture.Width = curImg.Width;
                    oldBillPicture.Height = curImg.Height;

                    oldBillPicture.Left = leftPanel.Width / 2 - oldBillPicture.Width / 2;

                    oldBillPicture.Top = 5 * Height / 100;

                    DisableCheckout();
                };

                typeLabel.Click += (sender, e) =>
                {
                    curImg = BillPrinter.SetupBill(item, item.DateCreated);

                    oldBillPicture.Image = curImg;
                    oldBillPicture.Width = curImg.Width;
                    oldBillPicture.Height = curImg.Height;

                    oldBillPicture.Left = leftPanel.Width / 2 - oldBillPicture.Width / 2;

                    oldBillPicture.Top = 5 * Height / 100;

                    DisableCheckout();
                };
                #endregion

                borderPanel.Controls.Add(timeLabel);
                borderPanel.Controls.Add(typeLabel);

                oldBillPanel.Controls.Add(borderPanel);
            }

        }

        Bitmap curImg;

        private void DisableCheckout()
        {
            lbName.Visible = false;
            lbQuan.Visible = false;
            lbPrice.Visible = false;
            lbSTT.Visible = false;
            lbTotal.Visible = false;
            split.Visible = false;

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
            split.Visible = true;

            btnCheckout.Text = CHECK_OUT;
            oldBillPicture.Visible = false;
        }

        private void oldBillPicture_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, oldBillPicture.ClientRectangle,
                    Color.FromKnownColor(KnownColor.Black), 1, ButtonBorderStyle.Solid, // left
                    Color.FromKnownColor(KnownColor.Black), 1, ButtonBorderStyle.Solid, // top
                    Color.FromKnownColor(KnownColor.Black), 1, ButtonBorderStyle.Solid, // right
                    Color.FromKnownColor(KnownColor.Black), 1, ButtonBorderStyle.Solid);// bottom
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (btnCheckout.Text == RE_PRINT)
            {
                printBill.Print();
            }
        }

        private void printBill_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(curImg, 0, 0);
        }

        private void pnHistoryTitle_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, pnHistoryTitle.ClientRectangle,
                                Color.FromKnownColor(KnownColor.Black), 0, ButtonBorderStyle.Solid, // left
                                Color.FromKnownColor(KnownColor.Black), 1, ButtonBorderStyle.Solid, // top
                                Color.FromKnownColor(KnownColor.Black), 1, ButtonBorderStyle.Solid, // right
                                Color.FromKnownColor(KnownColor.Black), 1, ButtonBorderStyle.Solid);// bottom
        }

        private void areaPanel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, pnHistoryTitle.ClientRectangle,
                                Color.FromKnownColor(KnownColor.Control), 0, ButtonBorderStyle.Solid, // left
                                Color.FromKnownColor(KnownColor.Control), 0, ButtonBorderStyle.Solid, // top
                                Color.FromKnownColor(KnownColor.Control), 1, ButtonBorderStyle.Solid, // right
                                Color.FromKnownColor(KnownColor.Control), 0, ButtonBorderStyle.Solid);// bottom
        }

        private void areaToolPanel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, areaToolPanel.ClientRectangle,
                    Color.FromKnownColor(KnownColor.Black), 0, ButtonBorderStyle.Solid, // left
                    Color.FromKnownColor(KnownColor.Black), 0, ButtonBorderStyle.Solid, // top
                    Color.FromKnownColor(KnownColor.Black), 1, ButtonBorderStyle.Solid, // right
                    Color.FromKnownColor(KnownColor.Black), 1, ButtonBorderStyle.Solid);// bottom
        }

        private async void cbTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            tableOrderDataPn.Controls.Clear();

            var data = await ApiBuilder.SendRequest<List<OrderViewModel>>("api/Order/Table/" + tables[cbTable.SelectedIndex].Id, null, RequestMethod.GET);
            var tableOrders = JsonConvert.DeserializeObject<List<OrderViewModel>>(data);

            int top = 1 * Height / 100;
            checkSelecteds = new List<CheckSelected>();
            for (int i = 0; i < tableOrders.Count; i++)
            {
                checkSelecteds.Add(new CheckSelected() { Index = i });
                var order = tableOrders[i];

                Panel pnSlide = new Panel()
                {
                    MaximumSize = new Size(tableOrderDataPn.Width, this.Height * 50 / 100),
                    MinimumSize = new Size(tableOrderDataPn.Width, this.Height * 6 / 100),
                    Top = top,
                    Dock = DockStyle.Top,
                    BackColor = Color.FromArgb(249, 249, 249)
                };

                Panel orderData = new();
                orderData.Top = 0;
                orderData.Left = 0;
                orderData.Width = tableOrderDataPn.Width;
                Label sampLable = new();
                orderData.Height = (int)(sampLable.Height * 2.5);
                orderData.BackColor = Color.FromKnownColor(KnownColor.Control);

                orderData.BackColor = Color.FromArgb(238, 238, 238);

                bool isCollapsed = true;
                System.Windows.Forms.Timer timer = new();

                #region Title
                Label lbStt = new()
                {
                    Font = Sessions.Sessions.NORMAL_BOLD_FONT,
                    Left = 0,
                    Text = "STT",
                    Top = orderData.Top + orderData.Height
                };
                lbStt.Width = (int)(lbStt.Font.Size * 4);

                Label lbName = new()
                {
                    Font = Sessions.Sessions.NORMAL_BOLD_FONT,
                    Left = lbStt.Left + lbStt.Width,
                    Text = "Tên món",
                    Top = orderData.Top + orderData.Height
                };

                Label lbQuan = new()
                {
                    Font = Sessions.Sessions.NORMAL_BOLD_FONT,
                    Text = "Số lượng",
                    Top = orderData.Top + orderData.Height,
                };
                lbQuan.Width = (int)(Sessions.Sessions.NORMAL_BOLD_FONT.Size * 8);
                lbQuan.Left = tableOrderDataPn.Width - lbQuan.Width;

                pnSlide.Controls.Add(lbStt);
                pnSlide.Controls.Add(lbName);
                pnSlide.Controls.Add(lbQuan);
                #endregion

                int itemTop = lbStt.Top + lbStt.Height;

                for (int j = 0; j < order.OrderDetails.Count; j++)
                {
                    var item = order.OrderDetails[j];

                    Label stt = new()
                    {
                        Font = Sessions.Sessions.NORMAL_FONT,
                        Top = itemTop,
                        Left = 0,
                        Text = "" + (j + 1),
                        Width = lbStt.Width
                    };
                    var itemName = Sessions.ItemSession.ItemData.FirstOrDefault(f => f.Id == item.ItemId).Name;
                    Label name = new()
                    {
                        Font = Sessions.Sessions.NORMAL_FONT,
                        Top = itemTop,
                        Left = lbName.Left,
                        Text = itemName,
                        Width = (int)(Font.Size * itemName.Length)
                    };

                    Label quan = new()
                    {
                        Font = Sessions.Sessions.NORMAL_FONT,
                        Top = itemTop,
                        Left = lbQuan.Left + lbQuan.Width / 3,
                        Text = item.Quantity + "",
                        Width = (int)(Font.Size * itemName.Length)
                    };

                    itemTop += name.Height;

                    pnSlide.Controls.Add(stt);
                    pnSlide.Controls.Add(name);
                    pnSlide.Controls.Add(quan);
                }

                pnSlide.MaximumSize = new Size(tableOrderDataPn.Width, MinimumSize.Height + itemTop);

                #region Tick
                timer.Tick += (sender, e) =>
                {
                    if (isCollapsed)
                    {
                        pnSlide.Height += 50;
                        if (pnSlide.Height >= pnSlide.MaximumSize.Height)
                        {
                            timer.Stop();
                            isCollapsed = false;
                        }
                        Refresh();
                    }
                    else
                    {
                        pnSlide.Height -= 50;
                        if (pnSlide.Height <= pnSlide.MinimumSize.Height)
                        {
                            timer.Stop();
                            isCollapsed = true;
                        }
                        Refresh();
                    }
                };
                //orderData.Click += (sender, e) =>
                //{
                //    timer.Start();
                //};
                #endregion

                Label timeLb = new();
                timeLb.Font = Sessions.Sessions.NORMAL_BOLD_FONT;
                timeLb.Text = "Giờ vào: " + order.DateCreated.Hour + ":" + order.DateCreated.Minute;
                timeLb.Top = 5;
                timeLb.Left = 0;
                timeLb.Width = orderData.Width * 20 / 100;

                Label quantity = new();
                var quantityNumber = 0;

                foreach (var detail in order.OrderDetails)
                {
                    quantityNumber += detail.Quantity;
                }

                quantity.Font = Sessions.Sessions.NORMAL_BOLD_FONT;
                quantity.Text = "Số món: " + quantityNumber;
                quantity.Top = timeLb.Height + timeLb.Top;
                quantity.Left = 0;
                quantity.Width = orderData.Width * 20 / 100;

                CheckBox select = new();
                select.Left = tableOrderDataPn.Width - 50;
                select.Top = orderData.Height / 2 - select.Height / 2;
                if (_orders != null && _orders.Any(f => f.Id == order.Id))
                {
                    select.Checked = true;
                }

                select.CheckedChanged += async (sender, e) =>
                {
                    if (select.Checked)
                    {
                        //checkSelecteds[orders.IndexOf(order)].Check = true;
                        await CheckedRefresh(order);
                    }
                    else
                    {
                        //checkSelecteds[orders.IndexOf(order)].Check = false;
                        await RemoveRefresh(order);
                    }

                    //if (checkSelecteds.Any(f => f.Check))
                    //{
                    //    btnRemove.BackColor = Color.FromArgb(142, 142, 142);
                    //    btnCheckout.BackColor = Sessions.Sessions.BUTTON_COLOR;
                    //}
                    //else
                    //{
                    //    btnRemove.BackColor = Color.Gray;
                    //    btnCheckout.BackColor = Color.Gray;
                    //}
                };

                orderData.Controls.Add(timeLb);
                orderData.Controls.Add(quantity);
                orderData.Controls.Add(select);

                pnSlide.Controls.Add(orderData);

                tableOrderDataPn.Controls.Add(pnSlide);

                top += orderData.Height;
                timer.Start();
            }
            Refresh();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            BillForm myForm = new BillForm(_orders, FLOORS[cbArea.SelectedIndex].Id, tables[cbArea.SelectedIndex].Id);

            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            this.Controls.Add(myForm);
            myForm.Show();
        }

        private async Task CheckedRefresh(OrderViewModel model)
        {
            var nextOrders = new List<OrderViewModel>();
            if (_orders != null) nextOrders.AddRange(_orders);

            if (!nextOrders.Any(f => f.Id == model.Id))
            {
                nextOrders.Add(model);
            }

            this.Controls.Clear();
            BillForm myForm = new(await GetOrders(nextOrders), FLOORS[cbArea.SelectedIndex].Id, tables[cbTable.SelectedIndex].Id)
            {
                TopLevel = false,
                AutoScroll = true
            };
            this.Controls.Add(myForm);
            myForm.Show();
        }

        private async Task RemoveRefresh(OrderViewModel model)
        {
            var nextOrders = new List<OrderViewModel>();
            if (_orders != null) nextOrders.AddRange(_orders);

            var o = nextOrders.First(f => f.Id == model.Id);
            nextOrders.Remove(o);

            this.Controls.Clear();
            BillForm myForm = new(await GetOrders(nextOrders), FLOORS[cbArea.SelectedIndex].Id, tables[cbTable.SelectedIndex].Id)
            {
                TopLevel = false,
                AutoScroll = true
            };
            this.Controls.Add(myForm);
            myForm.Show();
        }

        private async Task<List<OrderViewModel>> GetOrders(List<OrderViewModel> orders)
        {
            var path = "api/Order?ids=";
            for (int i = 0; i < orders.Count; i++)
            {
                if (i > 0)
                {
                    path += "&ids=";
                }
                path += orders[i].Id;
            }

            var data = await ApiBuilder.SendRequest(path, new object(), RequestMethod.GET);
            return JsonConvert.DeserializeObject<List<OrderViewModel>>(data);
        }
    }
}
