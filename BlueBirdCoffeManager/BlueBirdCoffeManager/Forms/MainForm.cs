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
        private readonly Color MENU_BACK_COLOR = Color.FromArgb(38, 37, 37);
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
            this.menuPanel.BackColor = MENU_BACK_COLOR;

            this.dataPanel.Left = 0;
            this.dataPanel.Top = menuPanel.Height;
            this.dataPanel.Size = new Size(Width, (Height - menuPanel.Height));
            //this.dataPanel.BackColor = Color.FromArgb(192, 210, 240);
            this.dataPanel.BackColor = Color.White;

            this.btnTable.Top = 0;
            this.btnTable.ForeColor = Color.White;
            this.btnTable.Size = new Size(menuPanel.Width * 10 / 100, menuPanel.Height);
            this.btnTable.BackColor = MENU_BACK_COLOR;
            this.btnTable.FlatAppearance.BorderSize = 0;
            this.btnTable.TabStop = false;
            this.btnTable.FlatStyle = FlatStyle.Flat;
            this.btnTable.Font = MAIN_MENU_BUTTON_FONT;

            this.btnOrder.Top = 0;
            this.btnOrder.Left = btnTable.Left + btnTable.Width;
            this.btnOrder.ForeColor = Color.White;
            this.btnOrder.Size = new Size(menuPanel.Width * 10 / 100, menuPanel.Height);
            this.btnOrder.BackColor = MENU_BACK_COLOR;
            this.btnOrder.FlatAppearance.BorderSize = 0;
            this.btnOrder.TabStop = false;
            this.btnOrder.FlatStyle = FlatStyle.Flat;
            this.btnOrder.Font = MAIN_MENU_BUTTON_FONT;
            #endregion
        }

        private void btnTable_Click(object sender, EventArgs e)
        {
            ActiveButton(this.btnTable);
            DeactiveButton(this.btnOrder);
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            ActiveButton(this.btnOrder);
            DeactiveButton(this.btnTable);
        }

        #region Helper
        private void DeactiveButton(Button btn)
        {
            btn.ForeColor = Color.White;
            btn.BackColor = MENU_BACK_COLOR;
        }

        private void ActiveButton(Button btn)
        {
            btn.ForeColor = Color.Black;
            btn.BackColor = Color.White;
        }
        #endregion
    }
}
