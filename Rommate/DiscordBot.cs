// Copyright (c) Tise <vladden500@gmail.com>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

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
            discordClient.ModalSubmitted += ModalResponse.ModalRespose;

            await discordClient.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}
