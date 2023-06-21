// Copyright (c) Tise <vladden500@gmail.com>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;

namespace Rommate
{
    public static class ButtonResponse
    {
        public static async Task ButtonPressResponse(DiscordClient sender, ComponentInteractionCreateEventArgs args)
        {
            switch (args.Interaction.Data.CustomId)
            {
                case "TestPrimary":
                    await InteractionResponseAsync(args, new DiscordInteractionResponseBuilder()
                        .WithContent("Click event: Primary button recognised.")
                        .AddComponents(CustomButtons.ButtonGroupTest));
                    return;

                case "TestSecondary":
                    await InteractionResponseAsync(args, new DiscordInteractionResponseBuilder()
                        .WithContent("Click event: Secondary button recognised.")
                        .AddComponents(CustomButtons.ButtonGroupTest));
                    return;

                default:
                    await InteractionResponseAsync(args, new DiscordInteractionResponseBuilder()
                        .WithContent("Internal error: Invalid button ID! Information has been sent to the developer.")
                        .AddComponents(CustomButtons.ButtonGroupTest));
                    return;
            }
        }

        private static async Task InteractionResponseAsync(ComponentInteractionCreateEventArgs args, DiscordInteractionResponseBuilder builder)
        {
            await args.Interaction.CreateResponseAsync(
                    InteractionResponseType.UpdateMessage,
                    builder);
        }
    }
}
