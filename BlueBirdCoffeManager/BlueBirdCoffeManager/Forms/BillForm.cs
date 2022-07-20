using BlueBirdCoffeManager.Models;
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
    public partial class BillForm : Form
    {
        private readonly List<OrderViewModel> _orders;
        public BillForm(List<OrderViewModel> orders)
        {
            InitializeComponent();
            _orders = orders;
        }

        private void BillForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.MaximizeBox = false;

            tablesPanel.Width = (int)(33.33 * Width / 100);
            mainPanel.Width = (int)(33.33 * Width / 100);
            lostBillPanel.Width = (int)(33.33 * Width / 100);

            tablesPanel.Height = Height;
            mainPanel.Height = Height;
            lostBillPanel.Height = Height;

            tablesPanel.BackColor = Color.Gray;
            mainPanel.BackColor = Color.Red;
            lostBillPanel.BackColor = Color.Blue;

            lbName.Font = Sessions.Sessions.NOMAL_BOLD_FONT;
            lbPrice.Font = Sessions.Sessions.NOMAL_BOLD_FONT;
            lbQuan.Font = Sessions.Sessions.NOMAL_BOLD_FONT;
            lbSTT.Font = Sessions.Sessions.NOMAL_BOLD_FONT;
            lbTotal.Font = Sessions.Sessions.NOMAL_BOLD_FONT;

            lbSTT.Left = 0;
            lbTotal.Left = lostBillPanel.Width - lbTotal.Width;

            lbName.Top = 1 * Height / 100;
            lbPrice.Top = lbName.Top;
            lbQuan.Top = lbName.Top;
            lbSTT.Top = lbName.Top;
            lbTotal.Top = lbName.Top;

            var curTop = lbSTT.Top + lbSTT.Height;


            //foreach (var item in collection)
            //{

            //}

            for (int i = 0; i < _orders.Count; i++)
            {
                var order = _orders[i];
                Label stt = new()
                {
                    Text = i + 1 + "",
                    Top = curTop,
                    Left = lbSTT.Left
                };

                Label name = new()
                {
                    //Text = Sessions.ItemSession.ItemData.FirstOrDefault(f=>f.Id == order.)
                };
            }
        }
    }
}
