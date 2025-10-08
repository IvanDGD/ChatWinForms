using System;
using System.Windows.Forms;

namespace ChatClientWinForms
{
    public partial class LobbyForm : Form
    {
        private readonly ClientConnection client;

        public LobbyForm(ClientConnection client)
        {
            InitializeComponent();
            this.client = client;

            client.MessageReceived += ShowMessage;
            client.UserListsUpdated += UpdateUserLists;
        }

        private void ShowMessage(string msg)
        {
            if (InvokeRequired)
                Invoke(() => MessageTextBox.AppendText(msg + Environment.NewLine));
            else
                MessageTextBox.AppendText(msg + Environment.NewLine);
        }

        private void UpdateUserLists(string[] online, string[] offline)
        {
            if (InvokeRequired)
            {
                Invoke(() => UpdateUserLists(online, offline));
                return;
            }

            onlineTextBox.Text = string.Join(Environment.NewLine, online);
            offlineTextBox.Text = string.Join(Environment.NewLine, offline);
        }

        private async void sendButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(sendTextBox.Text))
            {
                await client.SendMessageAsync(sendTextBox.Text);
                sendTextBox.Clear();
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            sendTextBox.Clear();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            client.Disconnect();
            Close();
        }
    }
}
