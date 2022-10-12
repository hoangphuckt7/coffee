using BlueBirdCoffeManager.DataAccessLayer;
using BlueBirdCoffeManager.Forms;
using BlueBirdCoffeManager.Models;
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
            txtUserName.Focus();

            this.Height = Screen.PrimaryScreen.WorkingArea.Height * 30 / 100;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width * 20 / 100;

            lbError.Text = "";
            txtPassword.PasswordChar = '*';
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
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
                lbError.Text = "Sai tên đăng nhập hoặc mật khẩu.";
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
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnLogin.PerformClick();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnLogin.PerformClick();
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnLogin.PerformClick();
        }
    }
}