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

namespace BlueBirdCoffeManager.Forms.DialogForms
{
    public partial class MoveOrder : Form
    {
        private readonly List<Guid> _ids;
        public MoveOrder(List<Guid> ids)
        {
            InitializeComponent();
            _ids = ids;
        }

        private void MoveOrder_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.CenterToScreen();

            lbArea.Top = 10 * Height / 100;
            lbArea.Left = 5 * Width / 100;
            lbArea.Font = Sessions.Sessions.NORMAL_BOLD_FONT;

            lbTable.Top = lbArea.Top + lbArea.Height + 10 * Height / 100;
            lbTable.Left = lbArea.Left;
            lbTable.Font = Sessions.Sessions.NORMAL_BOLD_FONT;

            cbArea.Top = lbArea.Top;
            cbArea.Left = lbArea.Left + lbArea.Width + 5 * Width / 100;
            cbArea.Font = Sessions.Sessions.NORMAL_BOLD_FONT;
            cbArea.DropDownStyle = ComboBoxStyle.DropDownList;

            cbTable.Top = lbTable.Top;
            cbTable.Left = cbArea.Left;
            cbTable.Font = Sessions.Sessions.NORMAL_BOLD_FONT;
            cbTable.DropDownStyle = ComboBoxStyle.DropDownList;

            this.Width = cbTable.Left + cbTable.Width + 10 * Width / 100;

            btnMove.Top = cbTable.Top + cbTable.Height + 10 * Height / 100;
            btnMove.Left = Width / 2 - btnMove.Width / 2;
            btnMove.BackColor = Sessions.Sessions.BUTTON_COLOR;

            this.Height = btnMove.Top + btnMove.Height + 20 * Height / 100;

            cbArea.DataSource = Sessions.Area.Areas.Select(s => s.Description).ToList();
        }

        List<TableViewModel> tables;

        private async void cbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tableData = await ApiBuilder.SendRequest<List<TableViewModel>>("api/Table?floorId=" + Sessions.Area.Areas[cbArea.SelectedIndex].Id, null, RequestMethod.GET);
            tables = JsonConvert.DeserializeObject<List<TableViewModel>>(tableData);
            cbTable.DataSource = tables.Select(s => s.Description).ToList();
        }

        private async void btnMove_Click(object sender, EventArgs e)
        {
            var tableId = tables[cbTable.SelectedIndex < 0 ? 0 : cbTable.SelectedIndex].Id;
            await ApiBuilder.SendRequest<ChangeOrdersTable>("api/Table/ChangeOrders", new ChangeOrdersTable() { NewTableId = tableId.Value, OrderIds = _ids }, RequestMethod.PUT);
            this.Close();
        }
    }
}
