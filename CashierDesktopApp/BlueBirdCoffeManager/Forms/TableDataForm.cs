using BlueBirdCoffeManager.DataAccessLayer;
using BlueBirdCoffeManager.Models;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlueBirdCoffeManager.Forms
{
    public partial class TableDataForm : Form
    {
        private readonly Panel _dataPanel;
        private readonly Panel _tablePanel;
        private readonly Panel _tableOrderPanel;
        private readonly Guid floorId;

        List<TableViewModel> tables = new List<TableViewModel>();
        List<Rectangle> rectangles = new List<Rectangle>();

        HubConnection connection;

        public TableDataForm(Panel tablePanel, Guid floorId, Panel tableOrderPanel, Panel dataPanel)
        {
            _tablePanel = tablePanel;
            this.floorId = floorId;
            _tableOrderPanel = tableOrderPanel;
            _dataPanel = dataPanel;

            InitializeComponent();

            var urlSignalR = Sessions.Sessions.HOST + "tableHub";

            connection = new HubConnectionBuilder()
               .WithUrl(urlSignalR, opt =>
               {
                   opt.AccessTokenProvider = () => Task.FromResult(Sessions.Sessions.TOKEN);
               })
               .Build();

            connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await connection.StartAsync();
            };

            connection.On<TableViewModel>("ChangeStatus", (model) =>
            {
                this.Invoke((Action)(() =>
                {
                    var table = tables.First(f => f.Id == model.Id);
                    tables.Remove(table);
                    tables.Add(model);
                    Refresh();
                }));
            });
        }

        private async void TableDataForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.MaximizeBox = false;

            pictureBox.Top = 0;
            pictureBox.Left = 0;
            pictureBox.Size = new Size(Width, Height - 10 * Height / 100);

            if (Sessions.Sessions.TABLE_WORK_SPACE == null)
            {
                Sessions.Sessions.TABLE_WORK_SPACE = new Point(pictureBox.Width, pictureBox.Height);
            }

            var tableData = await ApiBuilder.SendRequest<List<TableViewModel>>("api/Table?floorId=" + floorId, null, RequestMethod.GET);
            tables = JsonConvert.DeserializeObject<List<TableViewModel>>(tableData);

            var firstIndex = -1;

            for (int i = 0; i < tables.Count; i++)
            {
                tables[i].ConvertToRectangle();
                if (tables[i].CurrentOrder > 0) firstIndex = i;
            }

            if (firstIndex == -1 && tables.Count > 0) firstIndex = 0;

            rectangles = tables.Select(s => s.Rectangle.Value).ToList();

            rbtnEdit.BackColor = Sessions.Sessions.BUTTON_COLOR;
            rbtnEdit.Text = "Chỉnh sửa";
            rbtnEdit.Top = this.Height - rbtnEdit.Height - 2 * Height / 100;
            rbtnEdit.Left = this.Width - rbtnEdit.Width - 2 * Height / 100;
            rbtnEdit.Visible = true;

            try
            {
                await connection.StartAsync();
            }
            catch (Exception)
            {
                //listBox1.Items.Add(ex.Message);
            }

            if (firstIndex != -1) ShowFirst(firstIndex);

            Refresh();
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.DrawImage(Properties.Resources._2px, 0, 0);
            //e.Graphics.DrawImage(Utils.ImagUtils.RotateImage(Properties.Resources.door, 180), 150, 150, 50, 50);

            for (int i = 0; i < rectangles.Count; i++)
            {
                var item = rectangles[i];

                StringFormat sf = new StringFormat();
                sf.LineAlignment = StringAlignment.Center;
                sf.Alignment = StringAlignment.Center;

                Bitmap? table_image = null;
                var tlbSize = tables[i].Size.Split("-");

                int w = (int)(double.Parse(tlbSize[0]) * Sessions.Sessions.TABLE_WORK_SPACE.Value.X / 100);
                int h = (int)(double.Parse(tlbSize[1]) * Sessions.Sessions.TABLE_WORK_SPACE.Value.Y / 100);

                //int w = int.Parse(tlbSize[0]);
                //int h = int.Parse(tlbSize[1]);

                if (tables[i].Rotation == 90 || tables[i].Rotation == 270)
                {
                    h = w;
                }

                switch (tables[i].Shape)
                {
                    case "Rectangle":
                        if (tables[i].CurrentOrder == 0)
                        {
                            table_image = new Bitmap(Properties.Resources.table_rect_black, new Size(w, h));
                        }
                        else if (tables[i].CurrentOrder == 1)
                        {
                            table_image = new Bitmap(Properties.Resources.table_rect_green, new Size(w, h));
                        }
                        else
                        {
                            table_image = new Bitmap(Properties.Resources.table_rect_red, new Size(w, h));
                        }
                        break;
                    case "Ellipse":
                        if (tables[i].CurrentOrder == 0)
                        {
                            table_image = new Bitmap(Properties.Resources.table_round_black, new Size(w, h));
                        }
                        else if (tables[i].CurrentOrder == 1)
                        {
                            table_image = new Bitmap(Properties.Resources.table_round_green, new Size(w, h));
                        }
                        else
                        {
                            table_image = new Bitmap(Properties.Resources.table_round_red, new Size(w, h));
                        }
                        break;
                    default: break;
                }

                e.Graphics.DrawImage(Utils.ImagUtils.RotateImage(table_image, tables[i].Rotation), Rectangle.Round(item));
                e.Graphics.DrawString(tables[i].Description, Sessions.Sessions.NORMAL_FONT, Brushes.Black, item, sf);
            }
        }

        private void rbtnEdit_Click_1(object sender, EventArgs e)
        {
            _tablePanel.Controls.Clear();
            UpdateTableForm myForm = new UpdateTableForm(floorId, _tablePanel, _tableOrderPanel);
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            _tablePanel.Controls.Add(myForm);
            myForm.Show();
        }

        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            int selectedIndex = -1;
            for (int i = 0; i < rectangles.Count; i++)
            {
                var item = rectangles[i];

                if (item.Contains(e.Location))
                {
                    selectedIndex = i;
                };
            }
            if (selectedIndex > -1)
            {
                _tableOrderPanel.Controls.Clear();
                TableOrdersForm myForm = new TableOrdersForm(tables[selectedIndex].Id.Value, _dataPanel);
                myForm.TopLevel = false;
                myForm.AutoScroll = true;
                _tableOrderPanel.Controls.Add(myForm);
                myForm.Show();
            }
        }

        private void ShowFirst(int select)
        {
            _tableOrderPanel.Controls.Clear();
            TableOrdersForm myForm = new TableOrdersForm(tables[select].Id.Value, _dataPanel);
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            _tableOrderPanel.Controls.Add(myForm);
            myForm.Show();
        }
    }
}
