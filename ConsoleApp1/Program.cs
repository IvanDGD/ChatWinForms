using System.Net;
using System.Net.Sockets;
using System.Text.Json;

namespace Server
{
    public class User
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public static class UserStorage
    {
        private static string filePath = @"C:\Users\user\Desktop\VisualStudio2022\TcpServerWinForms\ChatClientWinForms\bin\Debug\net8.0-windows\users.json";

        public static List<User> LoadUsers()
        {

            if (!File.Exists(filePath))
            {
                return new List<User>();
            }

            var json = File.ReadAllText(filePath);
            var users = JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();


            return users;
        }
    }


    class Program
    {
        static async Task Main()
        {
            ServerObject server = new ServerObject();
            await server.ListenAsync();
        }
    }

    class ServerObject
    {
        TcpListener tcpListener = new TcpListener(IPAddress.Any, 8888);
        List<ClientObject> clients = new List<ClientObject>();

        protected internal void RemoveConnection(string id)
        {
            ClientObject? client = clients.FirstOrDefault(c => c.Id == id);
            if (client != null) clients.Remove(client);
            client?.Close();
        }

        protected internal async Task ListenAsync()
        {
            try
            {
                tcpListener.Start();
                Console.WriteLine("Server started. Waiting for clients...");

                while (true)
                {
                    TcpClient tcpClient = await tcpListener.AcceptTcpClientAsync();
                    ClientObject clientObject = new ClientObject(tcpClient, this);
                    clients.Add(clientObject);
                    Task.Run(clientObject.ProcessAsync);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Disconnect();
            }
        }

        protected internal async Task BroadcastMessageAsync(string message)
        {
            foreach (var client in clients)
            {
                await client.Writer.WriteLineAsync(message);
                await client.Writer.FlushAsync();
            }
        }

        protected internal async Task UpdateUserListsAsync()
        {
            var allRegistered = UserStorage.LoadUsers().Select(u => u.Username).ToList();

            var onlineUsers = clients.Where(c => !string.IsNullOrEmpty(c.UserName))
                                     .Select(c => c.UserName)
                                     .ToList();

            var offlineUsers = allRegistered
                .Where(u => !onlineUsers.Any(o =>
                    string.Equals(o, u, StringComparison.OrdinalIgnoreCase)))
                .ToList();

            string message = $"USERLIST|{string.Join(",", onlineUsers)}|{string.Join(",", offlineUsers)}";

            foreach (var client in clients)
            {
                await client.Writer.WriteLineAsync(message);
                await client.Writer.FlushAsync();
            }
        }


        protected internal void Disconnect()
        {
            foreach (var client in clients)
                client.Close();

            tcpListener.Stop();
        }
    }

    class ClientObject
    {
        protected internal string Id { get; } = Guid.NewGuid().ToString();
        protected internal StreamWriter Writer { get; }
        protected internal StreamReader Reader { get; }
        protected internal string UserName { get; private set; } = string.Empty;

        TcpClient client;
        ServerObject server;

        public ClientObject(TcpClient tcpClient, ServerObject serverObject)
        {
            client = tcpClient;
            server = serverObject;
            var stream = client.GetStream();
            Reader = new StreamReader(stream);
            Writer = new StreamWriter(stream);
        }

        public async Task ProcessAsync()
        {
            try
            {
                string username = await Reader.ReadLineAsync();
                if (string.IsNullOrEmpty(username)) return;

                UserName = username;
                Console.WriteLine($"{UserName} connected.");

                await server.BroadcastMessageAsync($"{UserName} logged into the chat room");
                await server.UpdateUserListsAsync();

                while (true)
                {
                    string? msg = await Reader.ReadLineAsync();
                    if (msg == null) break;

                    string formattedMsg = $"{UserName}: {msg}";
                    Console.WriteLine(formattedMsg);
                    await server.BroadcastMessageAsync(formattedMsg);
                }
            }
            catch
            {
                Console.WriteLine($"{UserName} disconnected unexpectedly.");
                await server.BroadcastMessageAsync($"{UserName} exited the chat room");
            }
            finally
            {
                server.RemoveConnection(Id);
                await server.UpdateUserListsAsync();
            }
        }

        protected internal void Close()
        {
            Writer.Close();
            Reader.Close();
            client.Close();
        }
    }
}
