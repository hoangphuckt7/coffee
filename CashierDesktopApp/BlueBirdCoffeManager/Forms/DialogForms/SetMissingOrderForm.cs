using BlueBirdCoffeManager.DataAccessLayer;
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

namespace BlueBirdCoffeManager.Forms.DialogForms
{
    public partial class SetMissingOrderForm : Form
    {
        private readonly Guid _OrderId;

        public SetMissingOrderForm(Guid orderId)
        {
            InitializeComponent();
            _OrderId = orderId;
        }

        private void SetMissingOrderForm_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.CenterToScreen();

            txtReason.Focus();

            this.Height = Screen.PrimaryScreen.WorkingArea.Height * 15 / 100;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width * 20 / 100;

            lbReason.Top = 10 * Height / 100;
            lbReason.Left = 5 * Width / 100;
            lbReason.Font = Sessions.Sessions.NORMAL_BOLD_FONT;

            txtReason.Top = lbReason.Top;
            txtReason.Font = Sessions.Sessions.NORMAL_FONT;
            txtReason.Width = 90 * Width / 100 - lbReason.Width;
            txtReason.Left = lbReason.Left + lbReason.Width;


            btnSubmit.Top = this.Height - 2 * Height / 100 - btnSubmit.Height * 2;
            btnSubmit.Left = Width / 2 - btnSubmit.Width / 2;
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtReason.Text))
            {
                MessageBox.Show("Nội dung không được để trống");
                return;
            }
            await ApiBuilder.SendRequest("api/order/MissingOrders", new SetMissingOrders { Reason = txtReason.Text, OrderId = _OrderId }, RequestMethod.PUT);

            this.Close();
        }
    }
}
