using BlueBirdCoffeManager.DataAccessLayer;
using BlueBirdCoffeManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlueBirdCoffeManager.Forms
{
    public partial class TableForm : Form
    {
        private List<DescriptionViewModel> FLOORS = new List<DescriptionViewModel>();
        public TableForm()
        {
            InitializeComponent();
        }

        private async void TableForm_Load(object sender, EventArgs e)
        {
            #region screen setup
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.MaximizeBox = false;

            this.floorPanel.Left = 0;
            this.floorPanel.Top = 0;
            this.floorPanel.Size = new Size(Width * 20 / 100, Height);
            this.floorPanel.BackColor = Color.White;

            lbArea.Font = Sessions.Sessions.NOMAL_BOLD_FONT;
            lbArea.Top = floorPanel.Height * 5 / 100;
            lbArea.Left = (floorPanel.Width - lbArea.Width) / 2;

            FLOORS = await ApiBuilder.SendRequest<List<DescriptionViewModel>>("api/Floor", null, RequestMethod.GET);
            cbFloors.DataSource = FLOORS.Select(s => s.Description).ToList();
            this.cbFloors.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbFloors.Font = Sessions.Sessions.NOMAL_FONT;
            this.cbFloors.Top = lbArea.Top + lbArea.Height + Height * 3 / 100;
            this.cbFloors.Left = (floorPanel.Width - cbFloors.Width) / 2;

            this.tablePanel.Left = floorPanel.Width;
            this.tablePanel.Top = 0;
            this.tablePanel.Size = new Size(Width - floorPanel.Width, Height);
            #endregion
        }

        private void areaPanel_Paint(object sender, PaintEventArgs e)
        {
            areaPanel.Top = lbArea.Top + lbArea.Height / 2;
            areaPanel.Size = new Size(floorPanel.Width * 90 / 100, cbFloors.Height + lbArea.Height / 2 + Height * 3 / 100 + Height * 2 / 100);
            areaPanel.Left = floorPanel.Width * 5 / 100;

            ControlPaint.DrawBorder(e.Graphics, areaPanel.ClientRectangle,
            Color.DimGray, 1, ButtonBorderStyle.Solid, // left
            Color.DimGray, 1, ButtonBorderStyle.Solid, // top
            Color.DimGray, 1, ButtonBorderStyle.Solid, // right
            Color.DimGray, 1, ButtonBorderStyle.Solid);// bottom
        }

        Bitmap bmp = new Bitmap(500, 500);

        private async void cbFloors_SelectedIndexChanged(object sender, EventArgs e)
        {
            bmp = new Bitmap(tablePanel.Width, tablePanel.Height);
            var tables = await ApiBuilder.SendRequest<List<DescriptionViewModel>>("api/Table?floorId=" + FLOORS[cbFloors.SelectedIndex].Id, null, RequestMethod.GET);

            foreach (var table in tables)
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    g.Clear(Color.White);
                    
                    g.FillEllipse(Brushes.Red, new Rectangle(10, 10, 32, 32));
                    g.FillEllipse(Brushes.Red, new Rectangle(50, 50, 32, 32));
                }
                tablePanel.Invalidate();
            }
        }

        private void tablePanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bmp, new Point(0, 0));
        }
    }
}
