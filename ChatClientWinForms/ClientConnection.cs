using System;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace ChatClientWinForms
{
    public class ClientConnection
    {
        private TcpClient client;
        private StreamReader reader;
        private StreamWriter writer;

        public string UserName { get; private set; }
        public event Action<string>? MessageReceived;
        public event Action<string[], string[]>? UserListsUpdated;

        public async Task<bool> ConnectAsync(string userName, string host = "127.0.0.1", int port = 8888)
        {
            try
            {
                client = new TcpClient();
                await client.ConnectAsync(host, port);

                var stream = client.GetStream();
                reader = new StreamReader(stream);
                writer = new StreamWriter(stream);

                UserName = userName;
                await writer.WriteLineAsync(userName);
                await writer.FlushAsync();

                _ = Task.Run(ReceiveMessagesAsync);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private async Task ReceiveMessagesAsync()
        {
            try
            {
                while (true)
                {
                    var message = await reader.ReadLineAsync();
                    if (string.IsNullOrEmpty(message)) continue;


                    if (message.StartsWith("USERLIST|"))
                    {
                        var parts = message.Split('|');
                        var online = parts[1].Split(',', StringSplitOptions.RemoveEmptyEntries);
                        var offline = parts[2].Split(',', StringSplitOptions.RemoveEmptyEntries);
                        UserListsUpdated?.Invoke(online, offline);
                    }
                    else
                    {
                        MessageReceived?.Invoke(message);
                    }
                }
            }
            catch
            {
                MessageReceived?.Invoke("Disconnected from server.");
            }
        }

        public async Task SendMessageAsync(string msg)
        {
            await writer.WriteLineAsync(msg);
            await writer.FlushAsync();
        }

        public void Disconnect()
        {
            writer?.Close();
            reader?.Close();
            client?.Close();
        }
    }
}
