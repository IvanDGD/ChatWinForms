using System.Text;
using System.Text.Json;

namespace CubeGame
{
    public partial class Form1 : Form
    {
        private readonly HttpClient client = new HttpClient();
        private string playerId;
        private string username;
        private System.Windows.Forms.Timer updateTimer;
        private int playerRoll = 0;
        private int opponentRoll = 0;
        private bool rollButtonPressed = false;
        private PictureBox playerDice;
        private PictureBox opponentDice;
        private int playerScore = 0;
        private int opponentScore = 0;
        private string gameMode = "Computer";

        public Form1()
        {
            InitializeComponent();
            ModeBox.SelectedIndex = 0;
            ModeBox.SelectedIndexChanged += (s, e) =>
            {
                gameMode = ModeBox.SelectedIndex == 0 ? "User" : "Computer";

                if (gameMode == "Computer")
                {
                    User2.Text = "Computer";
                }
                else
                {
                    User2.Text = "Ожидание противника...";
                }
            };

            RollDiceButton.Click += RollDiceButton_Click;

            playerDice = new PictureBox { Location = new Point(80, 20), Size = new Size(60, 60) };
            opponentDice = new PictureBox { Location = new Point(550, 20), Size = new Size(60, 60) };
            Controls.Add(playerDice);
            Controls.Add(opponentDice);
        }

        private async void RollDiceButton_Click(object sender, EventArgs e)
        {
            if (rollButtonPressed) return;
            rollButtonPressed = true;

            await AnimateDice(playerDice);

            if (gameMode == "User")
                await SendRollToServer();
            else
                await PlayAgainstComputer();

            rollButtonPressed = false;
        }

        private async Task PlayAgainstComputer()
        {
            Random rnd = new Random();
            playerRoll = rnd.Next(1, 7);
            opponentRoll = rnd.Next(1, 7);

            DrawDice(playerDice, playerRoll);
            await Task.Delay(500);
            DrawDice(opponentDice, opponentRoll);

            if (playerRoll > opponentRoll)
                playerScore++;
            else if (playerRoll < opponentRoll)
                opponentScore++;

            CountUser1.Text = playerScore.ToString();
            CountUser2.Text = opponentScore.ToString();
        }

        private async Task AnimateDice(PictureBox diceBox)
        {
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                int temp = rnd.Next(1, 7);
                DrawDice(diceBox, temp);
                await Task.Delay(100);
            }
        }

        private void DrawDice(PictureBox diceBox, int number)
        {
            Bitmap bmp = new Bitmap(diceBox.Width, diceBox.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                g.FillRectangle(Brushes.LightGray, 0, 0, bmp.Width, bmp.Height);
                g.DrawRectangle(Pens.Black, 0, 0, bmp.Width - 1, bmp.Height - 1);

                Brush dot = Brushes.Black;
                int size = 9;
                int offset = 12;
                Point[] positions = number switch
                {
                    1 => new[] { new Point(bmp.Width / 2, bmp.Height / 2) },
                    2 => new[] { new Point(offset, offset), new Point(bmp.Width - offset, bmp.Height - offset) },
                    3 => new[] { new Point(offset, offset), new Point(bmp.Width / 2, bmp.Height / 2), new Point(bmp.Width - offset, bmp.Height - offset) },
                    4 => new[] { new Point(offset, offset), new Point(bmp.Width - offset, offset), new Point(offset, bmp.Height - offset), new Point(bmp.Width - offset, bmp.Height - offset) },
                    5 => new[] { new Point(offset, offset), new Point(bmp.Width - offset, offset), new Point(bmp.Width / 2, bmp.Height / 2), new Point(offset, bmp.Height - offset), new Point(bmp.Width - offset, bmp.Height - offset) },
                    6 => new[] { new Point(offset, offset), new Point(bmp.Width / 2, offset), new Point(bmp.Width - offset, offset), new Point(offset, bmp.Height - offset), new Point(bmp.Width / 2, bmp.Height - offset), new Point(bmp.Width - offset, bmp.Height - offset) },
                    _ => Array.Empty<Point>()
                };

                foreach (var p in positions)
                    g.FillEllipse(dot, p.X - size / 2, p.Y - size / 2, size, size);
            }

            diceBox.Image = bmp;
        }

        private async Task SendRollToServer()
        {
            while (true)
            {
                var json = JsonSerializer.Serialize(new { id = playerId });
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("https://localhost:7209/roll", content);
                var responseText = await response.Content.ReadAsStringAsync();

                var data = JsonSerializer.Deserialize<RollResponse>(responseText);

                if (data.waiting)
                {
                    await Task.Delay(500);
                }
                else
                {
                    playerRoll = data.playerRoll;
                    opponentRoll = data.opponentRoll;

                    DrawDice(playerDice, playerRoll);
                    DrawDice(opponentDice, opponentRoll);

                    if (playerRoll > opponentRoll)
                        playerScore++;
                    else if (playerRoll < opponentRoll)
                        opponentScore++;

                    CountUser1.Text = playerScore.ToString();
                    CountUser2.Text = opponentScore.ToString();
                    break;
                }
            }
        }

        public class RollResponse
        {
            public bool waiting { get; set; }
            public int playerRoll { get; set; }
            public int opponentRoll { get; set; }
        }

        private async void LoginButton_Click(object sender, EventArgs e)
        {
            username = UsernameTextBox.Text.Trim();

            if (string.IsNullOrEmpty(username))
                return;
            if (gameMode == "Computer")
            {
                User1.Text = username;
                User2.Text = "Computer";
                return;
            }

            try
            {
                var json = JsonSerializer.Serialize(new { name = username });
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("https://localhost:7209/join", content);
                var responseText = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show($"Ошибка: {responseText}");
                    return;
                }

                var data = JsonSerializer.Deserialize<JoinResponse>(responseText);
                playerId = data.id;

                UpdatePlayers(data.players);

                updateTimer = new System.Windows.Forms.Timer();
                updateTimer.Interval = 2000;
                updateTimer.Tick += async (s, ev) => await RefreshPlayers();
                updateTimer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при подключении: {ex.Message}");
            }
        }

        private async Task RefreshPlayers()
        {
            var response = await client.GetAsync("https://localhost:7209/players");
            if (!response.IsSuccessStatusCode) return;

            var json = await response.Content.ReadAsStringAsync();
            var wrapper = JsonSerializer.Deserialize<PlayersWrapper>(json);

            if (wrapper != null)
                UpdatePlayers(wrapper.players);
        }

        private void UpdatePlayers(string[] players)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdatePlayers(players)));
                return;
            }

            if (players == null || players.Length == 0) return;

            if (players.Length == 1)
            {
                User1.Text = username;
                User2.Text = "Ожидание противника...";
                return;
            }

            string other = players[0] == username ? players[1] : players[0];

            User1.Text = username;
            User2.Text = other;
        }
    }

    public class PlayersWrapper
    {
        public string[] players { get; set; }
    }

    public class JoinResponse
    {
        public string id { get; set; }
        public string[] players { get; set; }
    }
}
