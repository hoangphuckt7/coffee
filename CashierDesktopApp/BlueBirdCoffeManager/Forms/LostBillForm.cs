using BlueBirdCoffeManager.DataAccessLayer;
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
                var lastestData = data.First();
                var totalLost = 0;

                foreach (var order in lastestData.Orders)
                {
                    foreach (var item in order.Items)
                    {
                        totalLost += item.Quantity - item.FinalQuantity;
                    }
                }

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

                foreach (var item in lastestData.Orders)
                {

                }
            }
            #endregion
        }
    }
}
