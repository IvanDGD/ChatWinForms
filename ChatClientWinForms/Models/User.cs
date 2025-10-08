using System.Text.Json;

namespace ChatClientWinForms
{
    public class User
    {
        public string Username { get; set; }
        public string Email { get; set; }  
        public string Password { get; set; }
    }

    public static class UserStorage
    {
        private static string filePath = "users.json";

        public static List<User> LoadUsers()
        {
            if (!File.Exists(filePath))
                return new List<User>();

            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
        }

        public static void SaveUsers(List<User> users)
        {
            var json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        public static void AddUser(User user)
        {
            var users = LoadUsers();
            users.Add(user);
            SaveUsers(users);
        }

        public static User? GetUserByEmail(string email, string password)
        {
            var users = LoadUsers();
            return users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }

        public static bool EmailExists(string email)
        {
            var users = LoadUsers();
            return users.Any(u => u.Email == email);
        }
    }
}