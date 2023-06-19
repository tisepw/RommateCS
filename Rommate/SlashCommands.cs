using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using DSharpPlus.SlashCommands.Attributes;

namespace Rommate
{
    public class SlashCommands : ApplicationCommandModule
    {
        private static readonly DiscordInteractionResponseBuilder builder = new();

        [SlashCommand("ping", "Check WS ping")]
        public static async Task PingCommand(InteractionContext ctx)
        {
            builder.AddEmbed(new DiscordEmbedBuilder()
            {
                Color = DiscordColor.Orange,
                Title = "Pong!",
                Description = $"WS latency: {ctx.SlashCommandsExtension.Client.Ping}ms"
            });

            await AsyncResponse(ctx, builder);
        }

        public enum Number
        {
            [ChoiceName("Null")]
            option1 = 0,

            [ChoiceName("One")]
            option2 = 1,

            [ChoiceName("Two")]
            option3 = 2,

            [ChoiceName("Three")]
            option4 = 3,
        }

        [SlashCommand("optiontest", "Test option feature")]
        public static async Task OptionTestCommand(InteractionContext ctx,
            [Option("user", "Select a user")] DiscordUser user,
            [Option("Number", "Pick a number")] Number number = Number.option1)
        {
            builder.AddEmbed(new DiscordEmbedBuilder()
            {
                Color = DiscordColor.Orange,
                Description = $"{user.Mention}, number: {number.GetName()}"
            });

            await AsyncResponse(ctx, builder);
        }

        [SlashCommand("buttontest", "Test button feature")]
        public static async Task ButtonTestCommand(InteractionContext ctx)
        {
            builder.AddEmbed(new DiscordEmbedBuilder()
            {
                Color = DiscordColor.Orange,
                Title = "Buttons here!",
            });

            builder.AddComponents(CustomButtons.ButtonGroupTest);

            await AsyncResponse(ctx, builder);
        }

        [SlashCommand("checkAdminPriveleges", "Check admin priveleges")]
        [SlashRequireUserPermissions(Permissions.Administrator)]
        public static async Task CheckAdminPriveleges(InteractionContext ctx)
        {
            builder.AddEmbed(new DiscordEmbedBuilder()
            {
                Color = DiscordColor.Orange,
                Title = "You're admin, yay!"
            });

            await AsyncResponse(ctx, builder);
        }

        private static async Task AsyncResponse(InteractionContext _ctx, DiscordInteractionResponseBuilder _builder)
        {
            await _ctx.CreateResponseAsync(
                InteractionResponseType.ChannelMessageWithSource,
                _builder);

            builder.Clear();
        }
    }
}
