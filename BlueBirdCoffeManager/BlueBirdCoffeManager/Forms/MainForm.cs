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
    public partial class MainForm : Form
    {
        private readonly Font MAIN_MENU_BUTTON_FONT = new Font("time new roman", 10, FontStyle.Bold);
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            #region screen setup
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.MaximizeBox = false;

            this.menuPanel.Left = 0;
            this.menuPanel.Top = 0;
            this.menuPanel.Size = new Size(Width, this.Height * 5 / 100);
            this.menuPanel.BackColor = Sessions.Sessions.MENU_COLOR;

            this.dataPanel.Left = 0;
            this.dataPanel.Top = menuPanel.Height;
            this.dataPanel.Size = new Size(Width, (Height - menuPanel.Height));

            this.btnTable.Top = 0;
            this.btnTable.ForeColor = Color.White;
            this.btnTable.Size = new Size(menuPanel.Width * 10 / 100, menuPanel.Height);
            this.btnTable.BackColor = Sessions.Sessions.MENU_COLOR;
            this.btnTable.FlatAppearance.BorderSize = 0;
            this.btnTable.TabStop = false;
            this.btnTable.FlatStyle = FlatStyle.Flat;
            this.btnTable.Font = MAIN_MENU_BUTTON_FONT;

            this.btnOrder.Top = 0;
            this.btnOrder.Left = btnTable.Left + btnTable.Width + (int)((0.07 * Width) / 100);
            this.btnOrder.ForeColor = Color.White;
            this.btnOrder.Size = new Size(menuPanel.Width * 10 / 100, menuPanel.Height);
            this.btnOrder.BackColor = Sessions.Sessions.MENU_COLOR;
            this.btnOrder.FlatAppearance.BorderSize = 0;
            this.btnOrder.TabStop = false;
            this.btnOrder.FlatStyle = FlatStyle.Flat;
            this.btnOrder.Font = MAIN_MENU_BUTTON_FONT;

            pictureBox1.Height = Height * 2 / 100;
            pictureBox1.Width = Width * 1 / 100;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Left = Width - pictureBox1.Width - (int)(0.5 * Width / 100);
            pictureBox1.Top = 57 * menuPanel.Height / 100 - lbDot.Height;

            lbDot.Font = new Font("", 10, FontStyle.Bold);
            lbDot.Text = "●";
            lbDot.ForeColor = Color.Green;
            lbDot.Top = 63 * menuPanel.Height / 100 - lbDot.Height;
            lbDot.Left = pictureBox1.Left - lbDot.Width - (int)(0.5 * Width / 100);

            lbUsername.Font = Sessions.Sessions.NOMAL_BOLD_FONT;
            lbUsername.Top = 63 * menuPanel.Height / 100 - lbDot.Height;
            lbUsername.Text = Sessions.Sessions.USER_NAME;
            lbUsername.ForeColor = Color.White;
            lbUsername.Left = lbDot.Left - lbUsername.Width - (int)(0.5 * Width / 100);
            #endregion

            dataPanel.Controls.Clear();
            TableForm myForm = new TableForm(dataPanel, null);
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            dataPanel.Controls.Add(myForm);
            myForm.Show();

            ActiveButton(this.btnTable);
        }

        private void btnTable_Click(object sender, EventArgs e)
        {
            ActiveButton(this.btnTable);
            DeactiveButton(this.btnOrder);

            dataPanel.Controls.Clear();
            TableForm myForm = new TableForm(dataPanel, null);
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            dataPanel.Controls.Add(myForm);
            myForm.Show();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            ActiveButton(this.btnOrder);
            DeactiveButton(this.btnTable);

            dataPanel.Controls.Clear();

            OrderForm myForm = new OrderForm();
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            dataPanel.Controls.Add(myForm);
            myForm.Show();
        }

        #region Helper
        private void DeactiveButton(Button btn)
        {
            btn.ForeColor = Color.White;
            btn.BackColor = Sessions.Sessions.MENU_COLOR;
        }

        private void ActiveButton(Button btn)
        {
            btn.ForeColor = Color.Black;
            btn.BackColor = Color.White;
        }
        #endregion

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            const string messageEx = "Bạn có thật sự muốn thoát ứng dụng?";
            const string captionEx = "Thông báo";
            var result = MessageBox.Show(messageEx, captionEx, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            // If the no button was pressed ...
            if (result == DialogResult.OK)
            {
                MainForm mainScreen = (MainForm)Application.OpenForms["MainForm"];
                mainScreen.Close();
            }
        }
    }
}
