﻿using BlueBirdCoffeManager.DataAccessLayer;
using BlueBirdCoffeManager.Models;
using Newtonsoft.Json;
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
        private List<DescriptionViewModel> FLOORS = Sessions.Area.Areas;
        private readonly Panel _dataPanel;
        private readonly Guid? floorId;

        public TableForm(Panel dataPanel, Guid? floorId)
        {
            _dataPanel = dataPanel;
            this.floorId = floorId;
            InitializeComponent();
        }

        private async void TableForm_Load(object sender, EventArgs e)
        {
            try
            {
                #region screen setup

                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                this.MaximizeBox = false;

                this.floorPanel.Left = 0;
                this.floorPanel.Top = 0;
                this.floorPanel.Size = new Size(Width * 30 / 100, Height);
                this.floorPanel.BackColor = Color.White;

                this.tablePanel.Left = floorPanel.Width;
                this.tablePanel.Top = 0;
                this.tablePanel.Size = new Size(Width - floorPanel.Width, Height);

                lbArea.Font = Sessions.Sessions.NORMAL_BOLD_FONT;
                lbArea.Top = floorPanel.Height * 5 / 100;
                lbArea.Left = (floorPanel.Width - lbArea.Width) / 2;

                if (FLOORS == null || FLOORS.Count == 0)
                {
                    var rawData = await ApiBuilder.SendRequest<List<DescriptionViewModel>>("api/Floor", null, RequestMethod.GET);
                    FLOORS = JsonConvert.DeserializeObject<List<DescriptionViewModel>>(rawData);
                    Sessions.Area.Areas = FLOORS;
                }

                cbFloors.DataSource = FLOORS.Select(s => s.Description).ToList();
                this.cbFloors.Font = Sessions.Sessions.NORMAL_BOLD_FONT;
                this.cbFloors.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbFloors.Top = lbArea.Top + lbArea.Height + Height * 3 / 100;
                this.cbFloors.Left = (floorPanel.Width - cbFloors.Width) / 2;

                if (floorId != null)
                {
                    cbFloors.SelectedIndex = FLOORS.IndexOf(FLOORS.First(s => s.Id == floorId));
                }
                else
                {
                    cbFloors.SelectedIndex = FLOORS.IndexOf(FLOORS[0]);
                }
                areaPanel.Top = lbArea.Top + lbArea.Height / 2;
                areaPanel.Size = new Size(floorPanel.Width * 90 / 100, cbFloors.Height + lbArea.Height / 2 + Height * 3 / 100 + Height * 2 / 100);
                areaPanel.Left = floorPanel.Width * 5 / 100;

                tableOrderPanel.Top = areaPanel.Top + areaPanel.Height + 7 * Height / 100;
                tableOrderPanel.Size = new Size(floorPanel.Width * 90 / 100, Height - tableOrderPanel.Top - Height * 1 / 100);
                tableOrderPanel.Left = floorPanel.Width * 5 / 100;

                lbOrder.Font = Sessions.Sessions.NORMAL_BOLD_FONT;
                lbOrder.Top = areaPanel.Top + areaPanel.Height + 6 * Height / 100;
                lbOrder.Left = lbArea.Left;

                lbArea.Visible = true;
                areaPanel.Visible = true;
                cbFloors.Visible = true;

                tableOrderPanel.Visible = true;
                lbOrder.Visible = true;
                Refresh();
                #endregion
            }
            catch (Exception) { }
        }

        private void areaPanel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, areaPanel.ClientRectangle,
            Sessions.Sessions.MENU_COLOR, 1, ButtonBorderStyle.Solid, // left
            Sessions.Sessions.MENU_COLOR, 1, ButtonBorderStyle.Solid, // top
            Sessions.Sessions.MENU_COLOR, 1, ButtonBorderStyle.Solid, // right
            Sessions.Sessions.MENU_COLOR, 1, ButtonBorderStyle.Solid);// bottom
        }

        //Bitmap bmp = new Bitmap(500, 500);

        private void cbFloors_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                tablePanel.Controls.Clear();
                TableDataForm myForm = new TableDataForm(tablePanel, FLOORS[cbFloors.SelectedIndex].Id, tableOrderPanel, _dataPanel);
                myForm.TopLevel = false;
                myForm.AutoScroll = true;
                tablePanel.Controls.Add(myForm);
                myForm.Show();

                tableOrderPanel.Controls.Clear();
            }
            catch (Exception) { }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                tablePanel.Controls.Clear();
                UpdateTableForm myForm = new UpdateTableForm(FLOORS[cbFloors.SelectedIndex].Id, _dataPanel, tableOrderPanel);
                myForm.TopLevel = false;
                myForm.AutoScroll = true;
                tablePanel.Controls.Add(myForm);
                myForm.Show();
            }
            catch (Exception) { }
        }

        private void tableOrderPanel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, tableOrderPanel.ClientRectangle,
            Color.DimGray, 0, ButtonBorderStyle.Solid, // left
            Color.DimGray, 1, ButtonBorderStyle.Solid, // top
            Color.DimGray, 0, ButtonBorderStyle.Solid, // right
            Color.DimGray, 0, ButtonBorderStyle.Solid);// bottom
        }
    }
}
