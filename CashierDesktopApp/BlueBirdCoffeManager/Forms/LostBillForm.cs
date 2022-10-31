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
        public LostBillForm()
        {
            InitializeComponent();
        }

        private async void LostBillForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.MaximizeBox = false;

            dataPanel.Width = this.Width;
            dataPanel.Height = 50 * Height / 100;
            dataPanel.Left = 0;
            dataPanel.Top = 0;

            lostBillPanel.Top = dataPanel.Top + dataPanel.Height;
            lostBillPanel.Left = 0;
            lostBillPanel.Width = Width;
            lostBillPanel.Height = Height - lostBillPanel.Top;

            var rawData = await ApiBuilder.SendRequest<object>("api/Bill/MissingBillItemWithin48Hours", null, RequestMethod.GET);
            var data = JsonConvert.DeserializeObject<List<BillMissingItemViewModel>>(rawData);

            #region Data
            if (data != null && data.Count > 0 && string.IsNullOrEmpty(data.First().ItemMissingReason))
            {
                //Lastest data
                var lastestData = data.First();
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
                lbReason.Top = lostItems.Top + lostItems.Height + 10;
                lbReason.Left = 5;

                txtReason.Top = lbReason.Top;
                txtReason.Left = lbReason.Left + lbReason.Width;
                txtReason.Font = Sessions.Sessions.NORMAL_BOLD_FONT;

                btnSubmit.Top = lbReason.Top - (txtReason.Height * 60 / 100) / 2;
                btnSubmit.Width = 80 * btnSubmit.Width / 100;
                btnSubmit.Height = 80 * btnSubmit.Height / 100;
                btnSubmit.Left = Width - btnSubmit.Width - 5;

                txtReason.Width = Width - lbReason.Left - lbReason.Width - btnSubmit.Width - 10;
            }
            #endregion
        }
    }
}
