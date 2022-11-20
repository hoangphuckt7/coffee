using BlueBirdCoffeManager.DataAccessLayer;
using BlueBirdCoffeManager.Models;
using BlueBirdCoffeManager.Sessions;
using BlueBirdCoffeManager.Utils;
using Newtonsoft.Json;

namespace BlueBirdCoffeManager.Forms
{
    public partial class OrderForm : Form
    {
        private int CATEGORY_INDEX = 0;
        private readonly OrderViewModel? _editOrder;

        public OrderForm(OrderViewModel? isEdit)
        {
            InitializeComponent();
            _editOrder = isEdit;
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            #region Item screen setup

            if (_editOrder == null)
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                this.MaximizeBox = false;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.MaximizeBox = false;
                this.MinimizeBox = false;
                this.Height = Screen.PrimaryScreen.WorkingArea.Height * 80 / 100;
                this.Width = Screen.PrimaryScreen.WorkingArea.Width * 80 / 100;

                this.BackColor = Color.LightGray;

                this.ControlBox = false;
                this.CenterToScreen();
            }

            //Disable everything
            this.orderPanel.Visible = false;
            this.itemPanel.Visible = false;
            this.toolboxPanel.Visible = false;
            this.itemDataPanel.Visible = false;
            this.cbCategory.Visible = false;
            this.lbCategory.Visible = false;
            this.txtSearch.Visible = false;
            this.btnRemoveFilter.Visible = false;
            this.cbDetails.Visible = false;

            this.orderPanel.Left = 1;
            this.orderPanel.Top = 1;
            this.orderPanel.Size = new Size(Width * 30 / 100, Height - 2);
            //this.orderPanel.BackColor = Color.Black;

            this.itemPanel.Left = orderPanel.Width - 1;
            this.itemPanel.Top = 1;
            this.itemPanel.Size = new Size(Width - orderPanel.Width, Height - 2);

            this.toolboxPanel.Top = 0;
            this.toolboxPanel.Left = 0;
            this.toolboxPanel.Width = itemPanel.Width;
            this.toolboxPanel.Height = 7 * itemPanel.Width / 100;

            this.itemDataPanel.Top = toolboxPanel.Height;
            this.itemDataPanel.Left = 0;
            this.itemDataPanel.Width = itemPanel.Width;
            this.itemDataPanel.Height = itemPanel.Height - toolboxPanel.Height;

            //Get data for cbCategory
            List<string> cbCategoryData = new();
            cbCategoryData.Add("Tất cả");
            foreach (var item in ItemSession.Categories)
            {
                cbCategoryData.Add(item.Description);
            }

            cbCategory.DataSource = cbCategoryData;
            cbCategory.SelectedIndex = CATEGORY_INDEX;

            this.lbCategory.Font = Sessions.Sessions.NORMAL_BOLD_FONT;
            this.lbSearch.Font = Sessions.Sessions.NORMAL_BOLD_FONT;

            this.cbCategory.Font = Sessions.Sessions.NORMAL_BOLD_FONT;
            this.txtSearch.Font = Sessions.Sessions.NORMAL_BOLD_FONT;

            this.lbCategory.Top = 50 * toolboxPanel.Height / 100 - lbCategory.Height * 50 / 100;
            this.lbSearch.Top = lbCategory.Top;
            this.txtSearch.Top = 50 * toolboxPanel.Height / 100 - txtSearch.Height * 50 / 100;
            this.cbCategory.Top = 50 * toolboxPanel.Height / 100 - cbCategory.Height * 50 / 100;

            this.lbSearch.Left = 2 * toolboxPanel.Width / 100;
            this.txtSearch.Left = lbSearch.Left + lbSearch.Width + 1 * toolboxPanel.Width / 100;
            this.lbCategory.Left = txtSearch.Left + txtSearch.Width + 4 * toolboxPanel.Width / 100;
            this.cbCategory.Left = lbCategory.Left + lbCategory.Width + 1 * toolboxPanel.Width / 100;

            this.cbCategory.DropDownStyle = ComboBoxStyle.DropDownList;

            this.btnRemoveFilter.BackColor = Color.DarkGray;
            this.btnRemoveFilter.Text = "Xóa lọc";
            this.btnRemoveFilter.Width = (int)4 * Width / 100;
            this.btnRemoveFilter.Height = ((int)2.5 * Height / 100 > Sessions.Sessions.MINIMUM_HEIGH) ? (int)2.5 * Height / 100 : Sessions.Sessions.MINIMUM_HEIGH;
            this.btnRemoveFilter.Top = 50 * toolboxPanel.Height / 100 - btnRemoveFilter.Height * 50 / 100;
            this.btnRemoveFilter.Left = cbCategory.Left + cbCategory.Width + 5 * toolboxPanel.Width / 100;

            itemDataPanel.Controls.Clear();
            ItemDataForm myForm = new ItemDataForm(txtSearch.Text, null, oDataPanel, _editOrder);
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            itemDataPanel.Controls.Add(myForm);
            myForm.Show();

            //Enable everything
            this.orderPanel.Visible = true;
            this.itemPanel.Visible = true;
            this.toolboxPanel.Visible = true;
            this.itemDataPanel.Visible = true;
            this.cbCategory.Visible = true;
            this.lbCategory.Visible = true;
            this.txtSearch.Visible = true;
            this.btnRemoveFilter.Visible = true;
            this.cbDetails.Visible = true;

            this.txtSearch.Focus();
            #endregion
            #region Order Screen setup
            this.lbName.Font = Sessions.Sessions.NORMAL_BOLD_FONT;
            this.lbQuantity.Font = Sessions.Sessions.NORMAL_BOLD_FONT;
            this.lbPrice.Font = Sessions.Sessions.NORMAL_BOLD_FONT;
            this.lbSubTotal.Font = Sessions.Sessions.NORMAL_BOLD_FONT;
            this.cbDetails.Font = Sessions.Sessions.NORMAL_BOLD_FONT;

            this.oHeaderPanel.Top = 0;
            this.oHeaderPanel.Left = 0;
            this.oHeaderPanel.Width = orderPanel.Width;
            this.oHeaderPanel.Height = orderPanel.Height * 10 / 100;
            this.oHeaderPanel.BackColor = Color.White;

            this.oDataPanel.Top = oHeaderPanel.Height + 1;
            this.oDataPanel.Left = 0;
            this.oDataPanel.BackColor = Color.White;
            this.oDataPanel.Width = orderPanel.Width;
            this.oDataPanel.Height = orderPanel.Height * 90 / 100;

            this.lbName.Top = oHeaderPanel.Height - lbName.Height;
            this.lbQuantity.Top = oHeaderPanel.Height - lbName.Height;
            this.lbPrice.Top = oHeaderPanel.Height - lbName.Height;
            this.lbSubTotal.Top = oHeaderPanel.Height - lbName.Height;
            this.lbSubTotal.TextAlign = ContentAlignment.MiddleRight;
            this.cbDetails.Top = oHeaderPanel.Height - cbDetails.Height;

            this.lbName.Left = (int)2 * orderPanel.Width / 100;
            this.lbQuantity.Left = orderPanel.Width * 40 / 100;
            this.cbDetails.Left = lbQuantity.Left + lbQuantity.Width;
            this.lbPrice.Left = orderPanel.Width * 60 / 100;
            this.lbSubTotal.Left = orderPanel.Width - 20 * orderPanel.Width / 100;

            this.cbDetails.Checked = Sessions.Sessions.SHOW_ORDER_ITEM_DETAILS;

            oDataPanel.Controls.Clear();
            OrderDataForm orderDataForm = new OrderDataForm(oDataPanel, _editOrder);
            orderDataForm.TopLevel = false;
            orderDataForm.AutoScroll = true;
            oDataPanel.Controls.Add(orderDataForm);
            orderDataForm.Show();
            #endregion
        }

        private void toolboxPanel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, toolboxPanel.ClientRectangle,
            Sessions.Sessions.MENU_COLOR, 0, ButtonBorderStyle.Solid, // left
            Sessions.Sessions.MENU_COLOR, 0, ButtonBorderStyle.Solid, // top
            Sessions.Sessions.MENU_COLOR, 0, ButtonBorderStyle.Solid, // right
            Sessions.Sessions.MENU_COLOR, 0, ButtonBorderStyle.Solid);// bottom
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            CATEGORY_INDEX = cbCategory.SelectedIndex;

            Guid? categoryId = null;
            if (CATEGORY_INDEX > 0)
            {
                categoryId = ItemSession.Categories[CATEGORY_INDEX - 1].Id;
            }

            itemDataPanel.Controls.Clear();
            ItemDataForm myForm = new ItemDataForm(txtSearch.Text, categoryId, oDataPanel, _editOrder);
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            itemDataPanel.Controls.Add(myForm);
            myForm.Show();
        }

        TypeAssistant assistant;

        public class TypeAssistant
        {
            public event EventHandler Idled = delegate { };
            public int WaitingMilliSeconds { get; set; }
            System.Threading.Timer waitingTimer;

            public TypeAssistant(int waitingMilliSeconds)
            {
                WaitingMilliSeconds = waitingMilliSeconds;
                waitingTimer = new System.Threading.Timer(p =>
                {
                    Idled(this, EventArgs.Empty);
                });
            }
            public void TextChanged()
            {
                waitingTimer.Change(WaitingMilliSeconds, Timeout.Infinite);
            }
        }
        string currentSearch = "";
        void assistant_Idled(object sender, EventArgs e)
        {
            string x = txtSearch.Text;
            if (currentSearch.Length == txtSearch.Text.Length)
            {
                this.Invoke(
            new MethodInvoker(() =>
            {
                CATEGORY_INDEX = cbCategory.SelectedIndex;

                Guid? categoryId = null;
                if (CATEGORY_INDEX > 0)
                {
                    categoryId = ItemSession.Categories[CATEGORY_INDEX - 1].Id;
                }
                itemDataPanel.Controls.Clear();
                ItemDataForm myForm = new ItemDataForm(txtSearch.Text, categoryId, oDataPanel, _editOrder);
                myForm.TopLevel = false;
                myForm.AutoScroll = true;
                itemDataPanel.Controls.Add(myForm);
                myForm.Show();
                txtSearch.Focus();
            }));
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            int delay = 700;
            assistant = new TypeAssistant(delay);
            assistant.Idled += assistant_Idled;
            assistant.TextChanged();
            currentSearch = txtSearch.Text;
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != "" || this.cbCategory.SelectedIndex != 0)
            {
                this.txtSearch.Text = "";
                this.cbCategory.SelectedIndex = 0;

                itemDataPanel.Controls.Clear();
                ItemDataForm myForm = new ItemDataForm("", null, oDataPanel, _editOrder);
                myForm.TopLevel = false;
                myForm.AutoScroll = true;
                itemDataPanel.Controls.Add(myForm);
                myForm.Show();
                txtSearch.Focus();
            }
        }

        private void cbDetails_CheckedChanged(object sender, EventArgs e)
        {
            Sessions.Sessions.SHOW_ORDER_ITEM_DETAILS = cbDetails.Checked;

            oDataPanel.Controls.Clear();
            OrderDataForm orderDataForm = new(oDataPanel, _editOrder);
            orderDataForm.TopLevel = false;
            orderDataForm.AutoScroll = true;
            oDataPanel.Controls.Add(orderDataForm);
            orderDataForm.Show();
        }
    }
}
