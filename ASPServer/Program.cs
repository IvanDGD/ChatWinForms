using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DiceServer
{
    class Program
    {
        static Dictionary<string, string> players = new();

        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            var players = new ConcurrentDictionary<string, string>();
            var ready = new ConcurrentDictionary<string, bool>();
            var rolls = new ConcurrentDictionary<string, int>();

            var rnd = new Random();

            app.MapPost("/join", async context =>
            {
                using var reader = new StreamReader(context.Request.Body);
                var body = await reader.ReadToEndAsync();
                var data = JsonSerializer.Deserialize<Dictionary<string, string>>(body);

                string name = data["name"];
                string id = Guid.NewGuid().ToString();

                players[id] = name;
                ready[id] = false;
                rolls[id] = 0;

                Console.WriteLine($"{name} вошёл ({id})");

                var response = new { id, players = players.Values.ToList() };
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            });

            app.MapGet("/players", async context =>
            {
                var response = new { players = players.Values.ToList() };
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            });
            var lastRoll = new ConcurrentDictionary<string, (int playerRoll, int opponentRoll)>();

            app.MapPost("/roll", async context =>
            {
                using var reader = new StreamReader(context.Request.Body);
                var body = await reader.ReadToEndAsync();
                var data = JsonSerializer.Deserialize<Dictionary<string, string>>(body);

                string id = data["id"];
                ready[id] = true;

                if (ready.Values.Count(v => v) < 2)
                {
                    if (lastRoll.TryGetValue(id, out var rollsCache))
                    {
                        await context.Response.WriteAsync(JsonSerializer.Serialize(new
                        {
                            waiting = false,
                            playerRoll = rollsCache.playerRoll,
                            opponentRoll = rollsCache.opponentRoll
                        }));
                    }
                    else
                    {
                        await context.Response.WriteAsync(JsonSerializer.Serialize(new { waiting = true }));
                    }
                    return;
                }

                int[] results = { rnd.Next(1, 7), rnd.Next(1, 7) };
                var ids = players.Keys.ToArray();

                var roll1 = results[0];
                var roll2 = results[1];

                rolls[ids[0]] = roll1;
                rolls[ids[1]] = roll2;

                lastRoll[ids[0]] = (roll1, roll2);
                lastRoll[ids[1]] = (roll2, roll1);

                ready[ids[0]] = false;
                ready[ids[1]] = false;

                var response = new
                {
                    waiting = false,
                    playerRoll = lastRoll[id].playerRoll,
                    opponentRoll = lastRoll[id].opponentRoll
                };

                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            });


            app.Run("https://localhost:7209");
        }
    }
}
