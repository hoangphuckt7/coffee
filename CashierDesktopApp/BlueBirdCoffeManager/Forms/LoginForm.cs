using BlueBirdCoffeManager.DataAccessLayer;
using BlueBirdCoffeManager.Forms;
using BlueBirdCoffeManager.Models;
using BlueBirdCoffeManager.Properties;
using Newtonsoft.Json;

namespace BlueBirdCoffeManager
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.CenterToScreen();

            txtUserName.Focus();
            this.BackColor = Color.White;

            this.Height = Screen.PrimaryScreen.WorkingArea.Height * 40 / 100;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width * 30 / 100;

            this.BackgroundImage = Resources.background;

            lbTitle.Top = 10 * this.Height / 100;
            lbTitle.Font = new Font("edwardian script itc", 35, FontStyle.Bold);
            lbTitle.Width = (int)(lbTitle.Text.Length * lbTitle.Font.Size);
            lbTitle.Left = Width / 2 - lbTitle.Width / 2;
            lbTitle.BackColor = System.Drawing.Color.Transparent;

            lbUsername.Top = 35 * this.Height / 100;
            lbUsername.Font = Sessions.Sessions.NORMAL_BOLD_FONT;
            lbUsername.Left = 10 * Width / 100;
            lbUsername.BackColor = System.Drawing.Color.Transparent;

            txtUserName.Top = lbUsername.Top;
            txtUserName.Left = lbUsername.Left + lbUsername.Width + 10;

            lbPassword.Top = lbUsername.Top + lbUsername.Height + 10 * Height / 100;
            lbPassword.Font = Sessions.Sessions.NORMAL_BOLD_FONT;
            lbPassword.Left = lbUsername.Left;
            lbPassword.BackColor = System.Drawing.Color.Transparent;

            txtPassword.Top = lbPassword.Top;
            txtPassword.Left = txtUserName.Left;

            txtPassword.PasswordChar = '*';

            btnLogin.Top = Height - (btnLogin.Height) - (20 * Height / 100);
            btnLogin.Left = Width / 2 - btnLogin.Width / 2;
            //btnLogin.BackColor = Sessions.Sessions.BUTTON_COLOR;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.Length == 0 || txtUserName.Text.Length == 0)
            {
                string message = "Vui lòng điền đầy đủ thông tin đăng nhập";
                string caption = "Thông báo";
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            btnLogin.Enabled = false;

            var login = new UserLoginModel()
            {
                Password = txtPassword.Text,
                Phone = txtUserName.Text
            };

            var response = await ApiBuilder.SendRequest("api/user/login", login, RequestMethod.POST);

            if (string.IsNullOrEmpty(response))
            {
                txtPassword.Text = "";
            }
            else
            {
                var data = JsonConvert.DeserializeObject<LoginSuccessViewModel>(response);

                Sessions.Sessions.USER_NAME = data.FullName;
                Sessions.Sessions.TOKEN = data.Token.ToString();
                Sessions.Sessions.ROLE = data.Role;

                this.Hide();
                var mainScreen = new MainForm();
                mainScreen.Closed += (s, args) => this.Close();
                mainScreen.Visible = true;
                mainScreen.Show();
            }
            btnLogin.Enabled = true;
            txtPassword.Focus();
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            };
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            };
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            };
        }
    }
}