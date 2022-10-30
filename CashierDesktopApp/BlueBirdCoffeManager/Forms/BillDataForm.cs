using BlueBirdCoffeManager.DataAccessLayer;
using BlueBirdCoffeManager.Models;
using BlueBirdCoffeManager.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
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
        private Bitmap? _img;
        private readonly Form? _billForm;

        public BillDataForm(List<OrderViewModel>? orders, Bitmap? img, Form? billForm)
        {
            InitializeComponent();
            _orders = orders;
            _img = img;
            _billForm = billForm;
        }

        private void BillDataForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.MaximizeBox = false;
            this.AutoScroll = false;

            this.BackColor = Color.White;
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
            btnCheckout.Enabled = false;
            btnCheckout.BackColor = Color.Gray;


            if (_orders != null && _orders.Count > 0)
            {
                SetupBillData(0);
            }

            if (_img != null)
            {
                DisableCheckout();
                oldBillPicture.Visible = true;

                oldBillPicture.Image = _img;
                oldBillPicture.Width = _img.Width;
                oldBillPicture.Height = _img.Height;

                oldBillPicture.Left = this.Width / 2 - oldBillPicture.Width / 2;

                oldBillPicture.Top = 5 * Height / 100;
            }
            else
            {
                SetupBillData(0);

                //Bottom Data
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

                Panel s01 = new()
                {
                    Width = this.Width - lbSTT.Left - (this.Width - lbTotal.Left - lbTotal.Width),
                    Height = 1,
                    Top = lbapDiscout.Top - lbEx.Height,
                    Left = lbSTT.Left,
                    BackColor = Color.FromKnownColor(KnownColor.Control)
                };
                this.Controls.Add(s01);
                lbEx.Top = lbapDiscout.Top - lbEx.Height - 3 * Height / 100;
                lbEx.Left = btnCheckout.Left;

                lbCustomerP.Top = lbEx.Top - lbCustomerP.Height - 20;
                lbCustomerP.Left = btnCheckout.Left;

                Panel s02 = new()
                {
                    Width = this.Width - lbSTT.Left - (this.Width - lbTotal.Left - lbTotal.Width),
                    Height = 1,
                    Top = lbCustomerP.Top - lbCash.Height,
                    Left = lbSTT.Left,
                    BackColor = Color.FromKnownColor(KnownColor.Control)
                };
                this.Controls.Add(s02);

                lbCash.Top = lbCustomerP.Top - lbCash.Height - 3 * Height / 100;
                lbCash.Left = btnCheckout.Left;

                lbvoucher.Top = lbCash.Top - lbvoucher.Height - 20;
                lbvoucher.Left = btnCheckout.Left;

                lbDiscout.Top = lbvoucher.Top - lbDiscout.Height - 20;
                lbDiscout.Left = btnCheckout.Left;

                lbaTotal.Top = lbDiscout.Top - lbaTotal.Height - 20;
                lbaTotal.Left = btnCheckout.Left;

                txtapCoupon.Top = lbapCp.Top;

                btnApplyCode.Width = (int)(btnApplyCode.Font.Size * btnApplyCode.Text.Length) + 20;
                btnApplyCode.Top = lbapCp.Top - txtapCoupon.Height / 2;
                btnApplyCode.Left = btnCheckout.Left + btnCheckout.Width - btnApplyCode.Width;
                btnApplyCode.BackColor = Sessions.Sessions.BUTTON_COLOR;

                txtapCoupon.Left = btnCheckout.Left + btnCheckout.Width - txtapCoupon.Width - btnApplyCode.Width;

                txtapDiscout.Top = lbapDiscout.Top;
                txtapDiscout.Left = txtapCoupon.Left;
                txtapDiscout.Width = txtapCoupon.Width + btnApplyCode.Width;

                txtapDiscout.RightToLeft = RightToLeft.Yes;
                txtapCoupon.RightToLeft = RightToLeft.Yes;

                txtEx.Top = lbEx.Top;
                txtEx.Left = btnCheckout.Left + btnCheckout.Width - txtEx.Width;

                txtCustomerP.Top = lbCustomerP.Top;
                txtCustomerP.Left = btnCheckout.Left + btnCheckout.Width - txtCustomerP.Width;
                txtCustomerP.RightToLeft = RightToLeft.Yes;

                txtCash.Top = lbCash.Top;
                txtCash.Left = btnCheckout.Left + btnCheckout.Width - txtCash.Width;

                txtVoucher.Top = lbvoucher.Top;
                txtVoucher.Left = btnCheckout.Left + btnCheckout.Width - txtVoucher.Width;

                txtDiscout.Top = lbDiscout.Top;
                txtDiscout.Left = btnCheckout.Left + btnCheckout.Width - txtDiscout.Width;

                total.Top = lbaTotal.Top;
                total.Left = btnCheckout.Left + btnCheckout.Width - total.Width;

                Panel s2 = new()
                {
                    Width = this.Width,
                    Height = 1,
                    Top = total.Top - lbName.Top - lbName.Height,
                    Left = 0,
                    BackColor = Color.FromKnownColor(KnownColor.Control)
                };

                dataPanel.Height = s2.Top - lbName.Top - lbName.Height;
                dataPanel.Top = lbName.Top + lbName.Height;
                dataPanel.AutoScroll = true;
                this.Controls.Add(s2);
                oldBillPicture.Visible = false;
            }
        }

        private void DisableCheckout()
        {
            this.Controls.Clear();
            this.Controls.Add(oldBillPicture);
            this.Controls.Add(btnCheckout);

            btnCheckout.Text = RE_PRINT;
            btnCheckout.Enabled = true;
            btnCheckout.BackColor = Sessions.Sessions.BUTTON_COLOR;
        }

        List<OrderDetailViewModel> _mergeOders = new();
        List<ItemCheckoutModel> removed = new();

        public void SetupBillData(int curTop)
        {
            if (_orders != null && (_mergeOders == null || _mergeOders.Count == 0))
            {
                btnCheckout.Enabled = true;
                btnCheckout.BackColor = Sessions.Sessions.BUTTON_COLOR;

                foreach (var order in _orders)
                {
                    foreach (var item in order.OrderDetails)
                    {
                        var curItem = _mergeOders.FirstOrDefault(f => f.ItemId == item.ItemId);
                        if (curItem != null)
                        {
                            _mergeOders.Remove(curItem);
                            curItem.Quantity += item.Quantity;
                            _mergeOders.Add(curItem);
                        }
                        else
                        {
                            _mergeOders.Add(item);
                        }
                    }
                }
            }

            Panel split = new()
            {
                Top = curTop,
                Width = Width,
                Left = 0,
                Height = 1,
                BackColor = Color.FromKnownColor(KnownColor.Control)
            };

            curTop += split.Height;

            dataPanel.Controls.Add(split);

            for (int i = 0; i < _mergeOders.Count; i++)
            {
                var order = _mergeOders[i];
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
                total.Width = (int)(total.Font.Size * total.Text.Length);

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
                borderPanel.Left = lbSTT.Left;
                borderPanel.Width = this.Width - lbSTT.Left - (this.Width - lbTotal.Left - lbTotal.Width);

                dataPanel.Controls.Add(stt);
                dataPanel.Controls.Add(name);
                dataPanel.Controls.Add(plusButton);
                dataPanel.Controls.Add(quan);
                dataPanel.Controls.Add(minusButton);
                dataPanel.Controls.Add(price);
                dataPanel.Controls.Add(total);
                dataPanel.Controls.Add(borderPanel);
            }
            total.Text = _mergeOders.Sum(s => s.Quantity * Sessions.ItemSession.ItemData.First(f => f.Id == s.ItemId).Price).ToString("#,###", Application.CurrentCulture.NumberFormat) + "₫";

            var totalPrice = total.Text.Replace("₫", "");
            totalPrice = totalPrice.Replace(".", "");

            var totalDiscout = txtDiscout.Text.Replace("₫", "");
            totalDiscout = totalDiscout.Replace(".", "");

            var totalVoucher = txtVoucher.Text.Replace("₫", "");
            totalVoucher = totalVoucher.Replace(".", "");

            try
            {
                txtCash.Text = (int.Parse(totalPrice) - int.Parse(totalDiscout) - int.Parse(totalVoucher)).ToString("#,###", Application.CurrentCulture.NumberFormat) + "₫";
            }
            catch (Exception) { };
        }
        private void ChangeQuantity(Guid itemId, bool minus)
        {
            var curItem = _mergeOders.FirstOrDefault(f => f.ItemId == itemId);

            var index = _mergeOders.IndexOf(curItem);

            if (minus)
            {
                if (_mergeOders[index].Quantity > 1)
                {
                    _mergeOders[index].Quantity -= 1;
                }
                else
                {
                    _mergeOders.Remove(curItem);
                }

                var existed = removed.FirstOrDefault(f => f.ItemId == curItem.ItemId);
                if (existed != null)
                {
                    existed.Quantity += 1;
                }
                else
                {
                    removed.Add(new() { ItemId = curItem.ItemId, Quantity = 1 });
                }
            }
            else
            {
                _mergeOders[index].Quantity += 1;
            }

            //if (curItem.Quantity > 0)
            //{
            //    _mergeOders.Add(curItem);
            //}

            dataPanel.Controls.Clear();
            SetupBillData(0);
            dataPanel.Update();
            //BillDataForm myForm = new BillDataForm(_orders, null);
            //myForm.TopLevel = false;
            //myForm.AutoScroll = false;
            //this.Controls.Add(myForm);
            //myForm.Show();
        }

        private void txtCustomerP_TextChanged(object sender, EventArgs e)
        {
            CultureInfo culture = new CultureInfo("vi-VN");
            if (txtCustomerP.Text.Length == 0)
            {
                txtCustomerP.Text = "0";
            }
            else
            {
                decimal value = decimal.Parse(txtCustomerP.Text, NumberStyles.AllowThousands);
                txtCustomerP.Text = String.Format(culture, "{0:N0}", value);
                txtCustomerP.Select(txtCustomerP.Text.Length, 0);
            }

            var totalCash = txtCash.Text.Replace("₫", "");
            totalCash = totalCash.Replace(".", "");
            var pay = double.Parse(txtCustomerP.Text);
            var cash = int.Parse(totalCash);
            if (pay >= cash)
            {
                txtEx.Text = (pay - cash).ToString("#,###", Application.CurrentCulture.NumberFormat) + "₫";
                txtEx.Left = btnCheckout.Left + btnCheckout.Width - txtEx.Width;
            }
            else
            {
                txtEx.Text = "0₫";
                txtEx.Left = btnCheckout.Left + btnCheckout.Width - txtEx.Width;
            }
        }

        private void txtapDiscout_TextChanged(object sender, EventArgs e)
        {
            if (total.Text.Length == 1)
            {
                txtapDiscout.Text = "0";
            }
            else
            {
                CultureInfo culture = new CultureInfo("vi-VN");
                if (txtapDiscout.Text.Length == 0)
                {
                    txtapDiscout.Text = "0";
                }
                else
                {
                    decimal value = decimal.Parse(txtapDiscout.Text, NumberStyles.AllowThousands);
                    txtapDiscout.Text = String.Format(culture, "{0:N0}", value);
                    txtapDiscout.Select(txtapDiscout.Text.Length, 0);
                }

                CalculateTotal(null);
            }
        }

        private async void btnCheckout_Click(object sender, EventArgs e)
        {
            if (btnCheckout.Text == CHECK_OUT)
            {
                if (_orders.Count == 0)
                {
                    return;
                }
                const string message = "Hoàn tất hóa đơn?";
                const string caption = "Thông báo";
                var rr = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                // If the no button was pressed ...
                if (rr == DialogResult.Yes)
                {
                    CheckoutModel model = new()
                    {
                        Orders = _orders.Select(s => s.Id).ToList(),
                        RemovedItems = removed,
                        Coupon = btnApplyCode.Enabled == false ? txtapCoupon.Text : null,
                        Discout = txtapDiscout.Text.Length != 0 ? double.Parse(txtapDiscout.Text.Replace(".", "")) : 0,
                        IsTakeAway = false
                    };

                    var response = await ApiBuilder.SendRequest("api/Bill/Checkout", model, RequestMethod.POST);
                    var billData = JsonConvert.DeserializeObject<BillViewModel>(response);
                    var data = BillPrinter.MergeOldBill(billData);

                    _img = BillPrinter.SetupBill(data, billData.DateCreated);
                    printDocument1.Print();

                    _billForm.Controls.Clear();
                    BillForm myForm = new BillForm(null);
                    myForm.TopLevel = false;
                    myForm.AutoScroll = true;
                    _billForm.Controls.Add(myForm);
                    myForm.Show();
                }
            }
            else
            {
                printDocument1.Print();
            }
        }

        private void oldBillPicture_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, oldBillPicture.ClientRectangle,
                   Color.Black, 1, ButtonBorderStyle.Solid, // left
                   Color.Black, 1, ButtonBorderStyle.Solid, // top
                   Color.Black, 1, ButtonBorderStyle.Solid, // right
                   Color.Black, 1, ButtonBorderStyle.Solid);// bottom
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(_img, 0, 0);
        }

        private async void btnApplyCode_Click(object sender, EventArgs e)
        {
            if (total.Text.Length == 1)
            {
                return;
            }
            var totalCash = total.Text.Replace("₫", "");
            totalCash = totalCash.Replace(".", "");

            double discout;
            try
            {
                var rawData = await ApiBuilder.SendRequest<object>($"api/Coupon/Check?coupon={txtapCoupon.Text}&total={totalCash}", null, RequestMethod.GET);
                discout = JsonConvert.DeserializeObject<double>(rawData);
            }
            catch (Exception) { return; }

            txtVoucher.Text = discout.ToString("#,###", Application.CurrentCulture.NumberFormat) + "₫";

            txtapDiscout.Enabled = false;
            txtapCoupon.Enabled = false;
            btnApplyCode.Enabled = false;

            txtVoucher.Left = btnCheckout.Left + btnCheckout.Width - txtVoucher.Width;

            CalculateTotal(discout);
        }

        private void CalculateTotal(double? voucher)
        {
            var totalCash = total.Text.Replace("₫", "");
            totalCash = totalCash.Replace(".", "");

            var discout = double.Parse(txtapDiscout.Text);
            txtDiscout.Text = discout.ToString("#,###", Application.CurrentCulture.NumberFormat) + "₫";

            var cash = int.Parse(totalCash);

            double voucherValue = voucher == null ? 0 : voucher.Value;

            if ((discout + voucherValue) <= cash)
            {
                txtCash.Text = (cash - discout - voucherValue).ToString("#,###", Application.CurrentCulture.NumberFormat) + "₫";
            }
            else
            {
                txtCash.Text = "0₫";
            }

            txtCash.Left = btnCheckout.Left + btnCheckout.Width - txtCash.Width;
            txtDiscout.Left = btnCheckout.Left + btnCheckout.Width - txtDiscout.Width;

            var temp = txtCustomerP.Text;
            txtCustomerP.Text = "0";
            txtCustomerP.Text = temp;
        }
    }
}
