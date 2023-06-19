using DSharpPlus;
using DSharpPlus.SlashCommands;

namespace Rommate
{
    public class DiscordBot
    {
        private readonly string Token;

        public DiscordBot(string _token)
        {
            Token = _token;
        }

        public async Task StartDiscordBot()
        {
            DiscordClient discordClient = new(new DiscordConfiguration()
            {
                Token = Token,
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.AllUnprivileged
            });

            var slash = discordClient.UseSlashCommands();

            slash.RegisterCommands<SlashCommands>();

            discordClient.ComponentInteractionCreated += ButtonResponse.ButtonPressResponse;

            await discordClient.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}
