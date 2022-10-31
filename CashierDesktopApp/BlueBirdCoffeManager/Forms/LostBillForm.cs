using BlueBirdCoffeManager.DataAccessLayer;
using BlueBirdCoffeManager.Models;
using BlueBirdCoffeManager.Sessions;
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
    public partial class LostBillForm : Form
    {
        Guid? billId;
        public LostBillForm()
        {
            InitializeComponent();
        }

        private async void LostBillForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.MaximizeBox = false;

            this.BackColor = Color.White;

            dataPanel.Width = this.Width;
            dataPanel.Height = Height;
            dataPanel.Left = 0;
            dataPanel.Top = 0;

            lbEmpty.Font = Sessions.Sessions.NORMAL_FONT;
            lbEmpty.Width = (int)(lbEmpty.Text.Length * lbEmpty.Font.Size);
            lbEmpty.Top = Height / 2 - lbEmpty.Height / 2;
            lbEmpty.Left = Width / 2 - lbEmpty.Width / 2;

            var rawData = await ApiBuilder.SendRequest<object>("api/Bill/MissingBillItemWithin48Hours", null, RequestMethod.GET);
            var data = JsonConvert.DeserializeObject<List<BillMissingItemViewModel>>(rawData);
            
            dataPanel.Visible = false;

            #region Data
            if (data != null && data.Count > 0 && data.Any(f => f.ItemMissingReason == null))
            {
                lbEmpty.Visible = false;
                var lastestData = data.First(f => f.ItemMissingReason == null);
                billId = lastestData.Id;
                //Lastest data
                var totalLost = 0;

                foreach (var order in lastestData.Orders)
                {
                    foreach (var item in order.Items)
                    {
                        totalLost += item.Quantity - item.FinalQuantity;
                    }
                }

                //Setup header
                Label billNumber = new Label()
                {
                    Text = "Hóa đơn: #" + lastestData.BillNumber.ToString("000"),
                    Font = Sessions.Sessions.NORMAL_BOLD_FONT,
                    Width = (int)(Text.Length * Font.Size * 1.5),
                    Top = 0,
                    Left = 0
                };

                Label dateCreated = new Label()
                {
                    Text = "Thời gian: " + lastestData.DateCreated.ToString("HH:mmp - dd/MM/yyyy"),
                    Font = Sessions.Sessions.NORMAL_BOLD_FONT,
                    Width = Width - billNumber.Width,
                    Top = billNumber.Top,
                    Left = billNumber.Left + billNumber.Width
                };

                Label remain = new Label()
                {
                    Text = "Thất thoát: " + totalLost,
                    Font = Sessions.Sessions.NORMAL_BOLD_FONT,
                    Width = (int)(Text.Length * Font.Size),
                    Top = billNumber.Top + billNumber.Height,
                    Left = billNumber.Left
                };

                Panel headerPanel = new Panel()
                {
                    Top = 0,
                    Left = 0,
                    Height = billNumber.Height + dateCreated.Height,
                    Width = this.Width,
                    BackColor = Sessions.Sessions.SUB_BUTTON_COLOR
                };

                headerPanel.Controls.Add(billNumber);
                headerPanel.Controls.Add(dateCreated);
                headerPanel.Controls.Add(remain);

                dataPanel.Controls.Add(headerPanel);

                //Setup data
                lostItems.Top = headerPanel.Top + headerPanel.Height;
                lostItems.Width = this.Width;
                lostItems.Left = 0;
                lostItems.Font = Sessions.Sessions.NORMAL_BOLD_FONT;
                lostItems.ScrollBars = ScrollBars.Vertical;
                lostItems.BackgroundColor = dataPanel.BackColor;
                lostItems.BorderStyle = BorderStyle.None;

                foreach (var order in lastestData.Orders)
                {
                    foreach (var item in order.Items)
                    {
                        lostItems.Rows.Add("#" + order.OrderNumber.ToString("000"), ItemSession.ItemData.First(f => f.Id == item.ItemId).Name, (item.Quantity - item.FinalQuantity).ToString());
                    }
                }

                var height = 40;
                foreach (DataGridViewRow dr in lostItems.Rows)
                {
                    height += dr.Height;
                }
                lostItems.Height = height;

                txtReason.Focus();
                lostItems.ClearSelection();
                lostItems.Enabled = false;

                lbReason.Font = Sessions.Sessions.NORMAL_BOLD_FONT;
                lbReason.Top = this.Height - lbReason.Height - 20;
                lbReason.Left = 5;

                txtReason.Top = lbReason.Top;
                txtReason.Left = lbReason.Left + lbReason.Width;
                txtReason.Font = Sessions.Sessions.NORMAL_BOLD_FONT;

                btnSubmit.Top = lbReason.Top - (txtReason.Height * 60 / 100) / 2;
                btnSubmit.Width = 80 * btnSubmit.Width / 100;
                btnSubmit.Height = 80 * btnSubmit.Height / 100;
                btnSubmit.Left = Width - btnSubmit.Width - 5;

                txtReason.Width = Width - lbReason.Left - lbReason.Width - btnSubmit.Width - 10;
                dataPanel.Visible = true;
            }
            #endregion
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            if (billId == null) return;
            var model = new BillMissingItemUpdateModel()
            {
                Id = billId.Value,
                MissingItemReason = txtReason.Text
            };
            await ApiBuilder.SendRequest<object>("api/Bill/Reason", model, RequestMethod.PUT);

            this.Controls.Clear();
            this.InitializeComponent();
            LostBillForm_Load(sender, e);
        }
    }
}
