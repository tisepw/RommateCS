using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;

namespace Rommate
{
    public static class ModalResponse
    {
        public static async Task ModalRespose(DiscordClient sender, ModalSubmitEventArgs args)
        {
            switch (args.Interaction.Data.CustomId)
            {
                case "TextInputTest":
                    await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder()
                        .WithContent(args.Values.Values.First()));
                    return;

                default:
                    Console.WriteLine("Default");
                    return;
            }
        }
    }
}
