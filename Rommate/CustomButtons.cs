// Copyright (c) Tise <vladden500@gmail.com>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using DSharpPlus;
using DSharpPlus.Entities;

namespace Rommate
{
    public static class CustomButtons
    {
        #region ButtonsTest
        public static readonly DiscordButtonComponent buttonPrimary   = new(ButtonStyle.Primary, "TestPrimary", "Primary!");
        public static readonly DiscordButtonComponent buttonSecondary = new(ButtonStyle.Secondary, "TestSecondary", "Secondary!");
        public static readonly DiscordButtonComponent buttonInvalid   = new(ButtonStyle.Danger, "TestWrongID", "Wrong ID Test!");

        public static readonly DiscordButtonComponent[] ButtonGroupTest = { buttonPrimary, buttonSecondary, buttonInvalid };
        #endregion

        public static readonly DiscordButtonComponent textInputPopUp = new(ButtonStyle.Primary, "TextInputPopUp", "Text Input");
    }
}
