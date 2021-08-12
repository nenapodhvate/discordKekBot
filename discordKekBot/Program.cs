using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace Discord_BOT
{
    class Program
    {
        DiscordSocketClient client;

        static void Main(string[] args)

            => new Program().MainAsync().GetAwaiter().GetResult();

        private async Task MainAsync()
        {
            client = new DiscordSocketClient();
            client.MessageReceived += CommandsHandler;
            client.Log += Log;


            var token = "ODY4MTg4NTUwNDAxNzg1ODg2.YPsBmA.X_U4TafliX00zfLhwp-V-6wopjc";

            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();

            Console.ReadLine();

        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        private Task CommandsHandler(SocketMessage msg)
        {
            if (!msg.Author.IsBot)
                switch (msg.Content)
                {
                    case "!pl":
                        {
                            msg.Channel.SendMessageAsync($"TEST");
                            break;
                        }
                    case "!rnd":
                        {
                            Random rnd = new Random();
                            msg.Channel.SendMessageAsync($"Result: {rnd.Next(1, 10)}");
                            break;
                        }
                }
            return Task.CompletedTask;
        }
    }
}
