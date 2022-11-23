using BlueBirdCoffeManager.DataAccessLayer;
using BlueBirdCoffeManager.Forms.DialogForms;
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
    public partial class TableOrdersForm : Form
    {
        private readonly Panel _mainPanel;
        private readonly Guid _tableId;
        public TableOrdersForm(Guid tableId, Panel mainPanel)
        {
            _tableId = tableId;
            InitializeComponent();
            this._mainPanel = mainPanel;
        }

        List<CheckSelected> checkSelecteds = new();
        List<OrderViewModel> orders;

        private async void TableOrdersForm_LoadAsync(object sender, EventArgs e)
        {
            this.BackColor = Color.White;

            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.MaximizeBox = false;

            mainData.Left = 0;
            mainData.Top = 0;

            mainData.Height = 90 * Height / 100;
            mainData.Width = 100 * this.Width / 100;

            pnButton.Left = 0;
            pnButton.Width = mainData.Width;

            pnButton.Height = btnCheckout.Height + btnEdit.Height + 3 * Height / 100;
            mainData.Height = Height - pnButton.Height;
            pnButton.Top = mainData.Height;

            btnCheckoutAll.Top = pnButton.Height - btnCheckout.Height;

            btnMove.Top = btnCheckoutAll.Top;
            btnMove.Left = 0;
            btnMove.Width = pnButton.Width * 30 / 100;
            btnMove.BackColor = Color.Gray;

            btnCheckoutAll.Width = pnButton.Width * 70 / 100;
            btnCheckoutAll.Left = btnMove.Left + btnMove.Width;

            btnEdit.Left = 0;
            btnEdit.Width = (int)(49.5 * Width / 100);
            btnEdit.Top = pnButton.Height - 1 * Height / 100 - btnCheckout.Height - btnEdit.Height;
            btnEdit.BackColor = Color.Gray;

            btnCheckout.Top = btnEdit.Top;
            btnCheckout.Width = btnEdit.Width;
            btnCheckout.Left = btnEdit.Width + btnEdit.Left + 1 * Width / 100;
            btnCheckout.BackColor = Color.Gray;

            mainData.AutoScroll = true;

            var data = await ApiBuilder.SendRequest<List<OrderViewModel>>("api/Order/Table/" + _tableId, null, RequestMethod.GET);
            orders = JsonConvert.DeserializeObject<List<OrderViewModel>>(data);

            if (orders == null) orders = new List<OrderViewModel>();

            if (orders.Count > 0)
            {
                btnCheckoutAll.BackColor = Sessions.Sessions.BUTTON_COLOR;
            }
            else
            {
                btnCheckoutAll.BackColor = Color.Gray;
            }

            int top = 1 * Height / 100;

            for (int i = 0; i < orders.Count; i++)
            {
                checkSelecteds.Add(new CheckSelected() { Index = i });
                var order = orders[i];

                Panel pnSlide = new Panel()
                {
                    MaximumSize = new Size(mainData.Width, this.Height * 50 / 100),
                    MinimumSize = new Size(mainData.Width, this.Height * 6 / 100),
                    Top = top,
                    Dock = DockStyle.Top,
                    BackColor = Color.FromArgb(249, 249, 249)
                };

                Panel orderData = new();
                orderData.Top = 0;
                orderData.Left = 0;
                orderData.Width = mainData.Width;
                orderData.Height = this.Height * 6 / 100;
                orderData.BackColor = Color.FromKnownColor(KnownColor.Control);

                orderData.BackColor = Color.FromArgb(238, 238, 238);

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
                lbQuan.Left = Width - lbQuan.Width;

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

                pnSlide.MaximumSize = new Size(mainData.Width, MinimumSize.Height + itemTop);

                #region Tick
                bool isCollapsed = true;
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
                    //else
                    //{
                    //    pnSlide.Height -= 50;
                    //    if (pnSlide.Height <= pnSlide.MinimumSize.Height)
                    //    {
                    //        timer.Stop();
                    //        isCollapsed = true;
                    //    }
                    //    Refresh();
                    //}
                };
                orderData.Click += (sender, e) =>
                {
                    timer.Start();
                };
                #endregion

                Label timeLb = new();
                timeLb.Font = Sessions.Sessions.NORMAL_BOLD_FONT;
                timeLb.Text = "Giờ vào: " + order.DateCreated.ToString("HH:mm");
                timeLb.Top = 0;
                timeLb.Left = 0;
                timeLb.Width = orderData.Width * 60 / 100;

                Label quantity = new();
                var quantityNumber = 0;

                foreach (var detail in order.OrderDetails)
                {
                    quantityNumber += detail.Quantity;
                }

                quantity.Font = Sessions.Sessions.NORMAL_BOLD_FONT;
                quantity.Text = "Số món: " + quantityNumber;
                quantity.Top = timeLb.Height;
                quantity.Left = 0;
                quantity.Width = orderData.Width * 60 / 100;

                CheckBox select = new();
                select.Left = Width - 50;
                select.Top = orderData.Height / 2 - select.Height / 2;

                select.CheckedChanged += (sender, e) =>
                {
                    if (select.Checked)
                    {
                        checkSelecteds[orders.IndexOf(order)].Check = true;
                    }
                    else
                    {
                        checkSelecteds[orders.IndexOf(order)].Check = false;
                    }

                    if (checkSelecteds.Any(f => f.Check))
                    {
                        btnCheckout.BackColor = Sessions.Sessions.BUTTON_COLOR;
                        btnMove.BackColor = Sessions.Sessions.BUTTON_COLOR;
                    }
                    else
                    {
                        btnCheckout.BackColor = Color.Gray;
                        btnMove.BackColor = Color.Gray;
                    }

                    if (checkSelecteds.Count(s => s.Check) == 1)
                    {
                        btnEdit.BackColor = Sessions.Sessions.BUTTON_COLOR;
                    }
                    else
                    {
                        btnEdit.BackColor = Color.Gray;
                    }

                    AutoDisableButton(btnEdit);
                    AutoDisableButton(btnCheckout);
                    AutoDisableButton(btnMove);
                };

                orderData.Controls.Add(timeLb);
                orderData.Controls.Add(quantity);
                orderData.Controls.Add(select);

                pnSlide.Controls.Add(orderData);

                mainData.Controls.Add(pnSlide);

                top += orderData.Height;
                timer.Start();
            }

            AutoDisableButton(btnEdit);
            AutoDisableButton(btnCheckout);
            AutoDisableButton(btnCheckoutAll);
            AutoDisableButton(btnMove);

            btnCheckout.Visible = true;
            btnCheckoutAll.Visible = true;
            btnEdit.Visible = true;
        }

        private void mainData_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, mainData.ClientRectangle,
            Color.DimGray, 0, ButtonBorderStyle.Solid, // left
            Color.DimGray, 1, ButtonBorderStyle.Solid, // top
            Color.DimGray, 0, ButtonBorderStyle.Solid, // right
            Color.DimGray, 0, ButtonBorderStyle.Solid);// bottom
        }

        private void btnCheckoutAll_Click(object sender, EventArgs e)
        {
            _mainPanel.Controls.Clear();

            BillForm myForm = new BillForm(orders);
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            _mainPanel.Controls.Add(myForm);
            myForm.Show();
        }

        private void AutoDisableButton(Button button)
        {
            if (button.BackColor == Color.Gray)
            {
                button.Enabled = false;
            }
            else
            {
                button.Enabled = true;
            }
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            _mainPanel.Controls.Clear();

            BillForm myForm = new BillForm(GetCheckedItem());
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            _mainPanel.Controls.Add(myForm);
            myForm.Show();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            var current = GetCheckedItem();
            OrderForm form = new OrderForm(current.FirstOrDefault());
            form.ShowDialog();

            this.Controls.Clear();
            this.InitializeComponent();
            TableOrdersForm_LoadAsync(sender, e);
        }

        private List<OrderViewModel> GetCheckedItem()
        {
            var checkedOrders = new List<OrderViewModel>();
            for (int i = 0; i < checkSelecteds.Count; i++)
            {
                if (checkSelecteds[i].Check)
                {
                    checkedOrders.Add(orders[checkSelecteds[i].Index]);
                }
            }
            return checkedOrders;
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            var current = GetCheckedItem();
            MoveOrder form = new MoveOrder(current.Select(s => s.Id).ToList());
            form.ShowDialog();

            this.Controls.Clear();
            this.InitializeComponent();
            TableOrdersForm_LoadAsync(sender, e);
        }
    }
    public class CheckSelected
    {
        public int Index { get; set; }
        public bool Check { get; set; }
    }
}
