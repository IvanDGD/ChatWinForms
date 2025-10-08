using System;
using System.Windows.Forms;

namespace ChatClientWinForms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private async void loginButton_Click(object sender, EventArgs e)
        {
            string email = emailTextBox.Text.Trim();
            string password = passwordTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Введите почту и пароль");
                return;
            }

            var user = UserStorage.GetUserByEmail(email, password);
            if (user == null)
            {
                MessageBox.Show("Неверная почта или пароль");
                return;
            }

            var client = new ClientConnection();
            bool connected = await client.ConnectAsync(user.Username, "127.0.0.1", 8888);

            if (connected)
            {
                var lobby = new LobbyForm(client);
                Hide();
                lobby.ShowDialog();
                Show();
            }
            else
            {
                MessageBox.Show("Не удалось подключиться к серверу");
            }
        }

        private void registerLinkLable_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var reg = new RegisterForm();
            Hide();
            reg.ShowDialog();
            Show();
        }
    }
}
