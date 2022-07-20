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
    public partial class UpdateTableForm : Form
    {
        List<TableViewModel> tables = new List<TableViewModel>();
        List<Rectangle> rectangles = new List<Rectangle>();
        List<Guid> deletedItem = new List<Guid>();

        bool isMouseDown = false;
        Rectangle selected_item;
        int selected_index;

        int x = 0;
        int y = 0;

        private readonly Panel _dataPanel;
        private readonly Panel _tableOrderPanel;
        private readonly Guid floorId;

        public UpdateTableForm(Guid id, Panel dataPanel, Panel tableOrderPanel)
        {
            _dataPanel = dataPanel;
            floorId = id;
            _tableOrderPanel = tableOrderPanel;
            InitializeComponent();
        }

        private async void UpdateTableForm_Load(object sender, EventArgs e)
        {
            var tableData = await ApiBuilder.SendRequest<List<TableViewModel>>("api/Table?floorId=" + floorId, null, RequestMethod.GET);
            tables = JsonConvert.DeserializeObject<List<TableViewModel>>(tableData);

            foreach (var item in tables)
            {
                item.ConvertToRectangle();
            }
            rectangles = tables.Select(s => s.Rectangle.Value).ToList();

            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.MaximizeBox = false;

            this.pictureBox.Top = 0;
            this.pictureBox.Left = 0;

            this.btnMove.Checked = true;

            pnTool.Height = 10 * Height / 100;
            pnTool.Top = Height - pnTool.Height;
            pnTool.Width = Width;
            pnTool.Left = 0;

            this.pictureBox.Size = new Size(this.Width, this.Height - pnTool.Height);

            btnCancel.Top = pnTool.Height - btnCancel.Height - ((int)(0.5 * Height) / 100);
            btnCancel.Left = pnTool.Width - btnCancel.Width - ((int)(0.5 * Width) / 100);

            btnSave.Left = btnCancel.Left - ((int)(0.5 * Width) / 100) - btnSave.Width;
            btnSave.Top = btnCancel.Top;
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < rectangles.Count; i++)
            {
                var item = rectangles[i];

                StringFormat sf = new();
                sf.LineAlignment = StringAlignment.Center;
                sf.Alignment = StringAlignment.Center;

                var tlbSize = tables[i].Size.Split("-");

                int w = (int)(double.Parse(tlbSize[0]) * Sessions.Sessions.TABLE_WORK_SPACE.Value.X / 100);
                int h = (int)(double.Parse(tlbSize[1]) * Sessions.Sessions.TABLE_WORK_SPACE.Value.Y / 100);

                if (tables[i].Rotation == 90 || tables[i].Rotation == 270)
                {
                    h = w;
                }

                Bitmap? bit_table_round_black = null;
                switch (tables[i].Shape)
                {
                    case "Rectangle":
                        var table_rect_black = Properties.Resources.table_rect_black;
                        bit_table_round_black = new Bitmap(table_rect_black, new Size(w, h));
                        break;
                    case "Ellipse":
                        var table_round_black = Properties.Resources.table_round_black;
                        bit_table_round_black = new Bitmap(table_round_black, new Size(w, h));
                        break;
                    default: break;
                }
                e.Graphics.DrawImage(Utils.ImagUtils.RotateImage(bit_table_round_black, tables[i].Rotation), Rectangle.Round(item));
                e.Graphics.DrawString(tables[i].Description, Sessions.Sessions.NOMAL_FONT, Brushes.Black, item, sf);
            }
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < rectangles.Count; i++)
            {
                var item = rectangles[i];

                if (item.Contains(e.Location))
                {
                    selected_item = rectangles[i];
                    selected_index = i;
                };
            }

            isMouseDown = true;
        }

        int? mCurX;
        int? mCurY;

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown == true && selected_index != -1 && btnMove.Checked)
            {
                if (mCurX == null) mCurX = e.X;
                if (mCurY == null) mCurY = e.Y;

                selected_item.X -= mCurX.Value - e.X;
                selected_item.Y -= mCurY.Value - e.Y;

                mCurX = e.X;
                mCurY = e.Y;

                if (selected_item.Right > pictureBox.Width)
                {
                    selected_item.X = pictureBox.Width - selected_item.Width;
                }
                if (selected_item.Top < 0)
                {
                    selected_item.Y = 0;
                }
                if (selected_item.Left < 0)
                {
                    selected_item.X = 0;
                }
                if (selected_item.Bottom > pictureBox.Height)
                {
                    selected_item.Y = pictureBox.Height - selected_item.Height;
                }
                rectangles[selected_index] = selected_item;

                Refresh();
            }
            else if (isMouseDown == true && selected_index != -1 && btnResize.Checked)
            {
                if (x == 0)
                {
                    x = e.X;
                }
                if (y == 0)
                {
                    y = e.Y;
                }

                if (selected_item.Width + e.X - x >= 20)
                {
                    selected_item.Width += (e.X - x);
                }

                if (selected_item.Height + e.Y - y >= 20)
                {
                    selected_item.Height += (e.Y - y);
                }

                x = e.X;
                y = e.Y;

                rectangles[selected_index] = selected_item;

                Refresh();
            }
            else if (isMouseDown == true && selected_index != -1 && rbRotate.Checked)
            {
                if (selected_index > -1 && tables[selected_index].Shape.Equals("Rectangle"))
                {
                    tables[selected_index].Rotation += 90;
                    if (tables[selected_index].Rotation == 360) tables[selected_index].Rotation = 0;
                    Refresh();
                }
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            selected_index = -1;
            x = 0;
            y = 0;
            mCurX = null;
            mCurY = null;
        }

        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (isMouseDown == true && selected_index != -1 && rbDelete.Checked)
            {
                var name = tables[selected_index].Description;
                string message = "Bạn có thực sự muốn xóa bàn " + name;
                const string caption = "Xác nhận";
                var rr = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                // If the no button was pressed ...
                if (rr == DialogResult.Yes)
                {
                    if (tables[selected_index].Id != Guid.Empty && tables[selected_index].Id != null)
                    {
                        deletedItem.Add(tables[selected_index].Id.Value);
                    }

                    rectangles.Remove(rectangles[selected_index]);
                    tables.Remove(tables[selected_index]);
                    Refresh();
                }
                else
                {

                }
            }
            selected_index = -1;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            const string message = "Hủy bỏ thay đổi?";
            const string caption = "Xác nhận";
            var rr = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            // If the no button was pressed ...
            if (rr == DialogResult.Yes)
            {
                _dataPanel.Controls.Clear();
                TableDataForm myForm = new(_dataPanel, floorId, _tableOrderPanel, _dataPanel);
                myForm.TopLevel = false;
                myForm.AutoScroll = true;
                _dataPanel.Controls.Add(myForm);
                myForm.Show();
            }
            else
            {

            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            const string message = "Lưu thay đổi?";
            const string caption = "Xác nhận";
            var rr = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            // If the no button was pressed ...
            if (rr == DialogResult.Yes)
            {
                var models = new List<TableUpdateModel>();
                for (int i = 0; i < rectangles.Count; i++)
                {
                    var tableUpdate = new TableUpdateModel()
                    {
                        Id = (tables[i].Id == null || tables[i].Id == Guid.Empty) ? Guid.NewGuid() : tables[i].Id,
                        Description = tables[i].Description,
                        FloorId = floorId,
                        Position = ((double)rectangles[i].X * 100) / Sessions.Sessions.TABLE_WORK_SPACE.Value.X + "-" + ((double)rectangles[i].Y * 100) / Sessions.Sessions.TABLE_WORK_SPACE.Value.Y,
                        Shape = tables[i].Shape,
                        Size = ((double)rectangles[i].Width * 100) / Sessions.Sessions.TABLE_WORK_SPACE.Value.X + "-" + ((double)rectangles[i].Height * 100) / Sessions.Sessions.TABLE_WORK_SPACE.Value.Y,
                        Rotation = tables[i].Rotation
                    };
                    models.Add(tableUpdate);
                }

                if (deletedItem != null || deletedItem.Count > 0)
                {
                    await ApiBuilder.SendRequest("api/Table/Remove", deletedItem, RequestMethod.PUT);
                }

                await ApiBuilder.SendRequest("api/Table/UpdateOrAdd", models, RequestMethod.PUT);

                _dataPanel.Controls.Clear();
                TableDataForm myForm = new(_dataPanel, floorId, _tableOrderPanel, _dataPanel);
                myForm.TopLevel = false;
                myForm.AutoScroll = true;
                _dataPanel.Controls.Add(myForm);
                myForm.Show();
            }
        }

        private void AddShape(string shape)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                const string message = "Vui lòng nhập tên bàn";
                const string caption = "Thông tin";
                var rr = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                // If the no button was pressed ...
                if (rr == DialogResult.OK)
                {
                }
                return;
            }
            int x = 0;
            int y = 0;

            int width = 4;
            int height = 6;

            var table = new TableViewModel()
            {
                Description = txtName.Text,
                Position = x + "," + y,
                Shape = shape,
                Size = width + "," + height,
                Rectangle = new Rectangle(x, y, width, height)
            };
            tables.Add(table);
            rectangles.Add(table.Rectangle.Value);

            txtName.Text = "";
        }

        private void btnAddRec_Click(object sender, EventArgs e)
        {
            AddShape("Rectangle");
            Refresh();
        }

        private void btnAddElipse_Click(object sender, EventArgs e)
        {
            AddShape("Ellipse");
            Refresh();
        }

        private void pnTool_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, pnTool.ClientRectangle,
            Color.DimGray, 3, ButtonBorderStyle.Solid, // left
            Color.DimGray, 3, ButtonBorderStyle.Solid, // top
            Color.DimGray, 3, ButtonBorderStyle.Solid, // right
            Color.DimGray, 3, ButtonBorderStyle.Solid);// bottom
        }
    }
}
