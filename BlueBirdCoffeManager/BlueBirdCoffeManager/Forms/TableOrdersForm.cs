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
    public partial class TableOrdersForm : Form
    {
        private readonly Guid _tableId;
        public TableOrdersForm(Guid tableId)
        {
            _tableId = tableId;
            InitializeComponent();
        }

        private async void TableOrdersForm_LoadAsync(object sender, EventArgs e)
        {
            this.BackColor = Color.White;

            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.MaximizeBox = false;

            mainData.Left = 0;
            mainData.Top = 0;

            mainData.Width = 97 * this.Width / 100;

            var data = await ApiBuilder.SendRequest<List<OrderViewModel>>("api/Order/Table/" + _tableId, null, RequestMethod.GET);
            var orders = JsonConvert.DeserializeObject<List<OrderViewModel>>(data);

            int top = 1 * Height / 100;

            foreach (var order in orders)
            {
                Panel orderData = new();
                orderData.Top = top;
                orderData.Left = 0;
                orderData.Width = mainData.Width;
                orderData.Height = this.Height * 6 / 100;

                Label timeLb = new();
                timeLb.Font = Sessions.Sessions.NOMAL_BOLD_FONT;
                timeLb.Text = "Giờ vào: " + order.DateCreated.Hour + ":" + order.DateCreated.Minute;
                timeLb.Top = 0;
                timeLb.Left = 0;
                timeLb.Width = orderData.Width * 20 / 100;

                Label quantity = new();
                var quantityNumber = 0;
                foreach (var detail in order.OrderDetails)
                {
                    quantityNumber += detail.Quantity;
                }
                quantity.Font = Sessions.Sessions.NOMAL_BOLD_FONT;
                quantity.Text = "Số món: " + quantityNumber;
                quantity.Top = timeLb.Height;
                quantity.Left = 0;
                quantity.Width = orderData.Width * 20 / 100;

                orderData.Controls.Add(timeLb);
                orderData.Controls.Add(quantity);

                Panel space = new();
                space.Top = orderData.Top + orderData.Height;
                space.Left = 0;
                space.Width = Width;
                space.Height = this.Height * 1 / 100;
                space.BackColor = Color.White;

                mainData.Controls.Add(orderData);
                mainData.Controls.Add(space);

                top += orderData.Height;
                top += space.Height;
            }

            mainData.Height = top;
        }

        private void mainData_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, mainData.ClientRectangle,
            Color.DimGray, 0, ButtonBorderStyle.Solid, // left
            Color.DimGray, 3, ButtonBorderStyle.Solid, // top
            Color.DimGray, 0, ButtonBorderStyle.Solid, // right
            Color.DimGray, 0, ButtonBorderStyle.Solid);// bottom
        }
    }
}
