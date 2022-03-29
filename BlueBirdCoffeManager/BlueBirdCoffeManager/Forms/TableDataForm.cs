using BlueBirdCoffeManager.DataAccessLayer;
using BlueBirdCoffeManager.Models;
using Microsoft.AspNetCore.SignalR.Client;
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
    public partial class TableDataForm : Form
    {
        private readonly Panel _tablePanel;
        private readonly Guid floorId;

        List<TableViewModel> tables = new List<TableViewModel>();
        List<Rectangle> rectangles = new List<Rectangle>();

        public TableDataForm(Panel dataPanel, Guid floorId)
        {
            _tablePanel = dataPanel;
            this.floorId = floorId;
            InitializeComponent();
        }

        private async void TableDataForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.MaximizeBox = false;

            var tableData = await ApiBuilder.SendRequest<List<TableViewModel>>("api/Table?floorId=" + floorId, null, RequestMethod.GET);
            tables = JsonConvert.DeserializeObject<List<TableViewModel>>(tableData);
            foreach (var item in tables)
            {
                item.ConvertToRectangle();
            }
            rectangles = tables.Select(s => s.Rectangle.Value).ToList();

            pictureBox.Size = new Size(_tablePanel.Width - 5 * Width / 100, _tablePanel.Height - 15 * Height / 100);
            pictureBox.Top = 10 * Height / 100;

            rbtnEdit.BackColor = Sessions.Sessions.BUTTON_COLOR;
            rbtnEdit.Text = "Chỉnh sửa";
            rbtnEdit.Top = this.Height - rbtnEdit.Height - 2 * Height / 100;
            rbtnEdit.Left = this.Width - rbtnEdit.Width - 2 * Height / 100;


            var urlSignalR = Sessions.Sessions.HOST + "/tableHub";

            var connection = new HubConnectionBuilder()
                .WithUrl(urlSignalR)
                .Build();

            connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await connection.StartAsync();
            };

            connection.On<Guid>("ChangeStatus", (tableId) =>
            {
                this.Invoke((Action)(() =>
                {
                    var table = tables.First(f => f.Id == tableId);
                    tables.Remove(table);
                    table.IsAvailable = false;
                    tables.Add(table);
                }));
            });

            try
            {
                await connection.StartAsync();
            }
            catch (Exception)
            {
                //messagesList.Items.Add(ex.Message);
            }

            Refresh();
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < rectangles.Count; i++)
            {
                var item = rectangles[i];

                StringFormat sf = new StringFormat();
                sf.LineAlignment = StringAlignment.Center;
                sf.Alignment = StringAlignment.Center;

                Pen penAvai = new(Sessions.Sessions.MENU_COLOR);
                Pen penActive = new(Sessions.Sessions.BUTTON_COLOR);

                switch (tables[i].Shape)
                {
                    case "Rectangle":
                        if (tables[i].IsAvailable == true)
                        {
                            e.Graphics.FillRectangle(new SolidBrush(Sessions.Sessions.MENU_COLOR), item);
                            e.Graphics.DrawRectangle(penAvai, Rectangle.Round(item));
                        }
                        else
                        {
                            e.Graphics.FillRectangle(new SolidBrush(Sessions.Sessions.BUTTON_COLOR), item);
                            e.Graphics.DrawRectangle(penActive, Rectangle.Round(item));
                        }
                        break;
                    case "Ellipse":
                        if (tables[i].IsAvailable == true)
                        {
                            e.Graphics.FillEllipse(new SolidBrush(Sessions.Sessions.MENU_COLOR), item);
                            e.Graphics.DrawEllipse(penAvai, Rectangle.Round(item));
                        }
                        else
                        {
                            e.Graphics.FillEllipse(new SolidBrush(Sessions.Sessions.BUTTON_COLOR), item);
                            e.Graphics.DrawEllipse(penActive, Rectangle.Round(item));
                        }
                        break;
                    default: break;
                }
                e.Graphics.DrawString(tables[i].Description, Sessions.Sessions.NOMAL_FONT, Brushes.White, item, sf);
            }
        }

        private void rbtnEdit_Click_1(object sender, EventArgs e)
        {
            _tablePanel.Controls.Clear();
            UpdateTableForm myForm = new UpdateTableForm(floorId, _tablePanel);
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            _tablePanel.Controls.Add(myForm);
            myForm.Show();
        }
    }
}
