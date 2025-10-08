using System;
using System.Windows.Forms;

namespace ChatClientWinForms
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            string email = emailTextBox.Text.Trim();
            string username = userTextBox.Text.Trim();
            string password = passwordTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Заполните все поля");
                return;
            }

            if (UserStorage.EmailExists(email))
            {
                MessageBox.Show("Пользователь с такой почтой уже существует");
                return;
            }

            UserStorage.AddUser(new User
            {
                Email = email,
                Username = username,
                Password = password
            });

            MessageBox.Show($"Пользователь {username} зарегистрирован!");
            Close();
        }

        private void loginLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            Hide();
        }
    }
}
