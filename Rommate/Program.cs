using System.Reflection;
using System.Text.RegularExpressions;

namespace Rommate
{
    public class Program
    {
        private static async Task Main(string[] args)
        {
#if DEBUG
            DiscordBot discordBot = new(Environment.GetEnvironmentVariable("token") ?? "");
            await discordBot.StartDiscordBot();
#else
            #region CheatSheet
            string cheatSheet =
            "Usage: rommate [option]=[value]                   \n" +
            "Example: rommate -t=\"token\"                     \n" +
            "                                                  \n" +
            "Options:                                          \n" +
            " -t, --token             set bot token to start   \n" +
            "                                                  \n" +
            " -h, --help              print help page          \n" +
            " -v, --version           print Rommate version    \n";
            #endregion

            foreach (string arg in args)
            {
                string[] split = arg.Split('=');

                string key = split[0];
                string value = split.Length > 1 ? split[1] : string.Empty;

                switch (key)
                {
                    #region DefaultArgument
                    default:
                        Console.WriteLine($"Urecognized argument: {key}. Use rommate -h to see options list.");

                        return;
                    #endregion

                    #region VersionArgument
                    case "-v":
                    case "--version":
                        Console.WriteLine($"v{Assembly.GetExecutingAssembly().GetName()?.Version?.ToString()}");

                        continue;
                    #endregion

                    #region HelpArgument
                    case "-h":
                    case "--help":
                        Console.WriteLine(cheatSheet);

                        continue;
                    #endregion

                    #region TokenArgument
                    case "-t":
                    case "--token":
                        if (value == string.Empty)
                        {
                            Console.WriteLine("You must specify the token! Use rommate -h to see options list.");
                            return;
                        }
                        else if (!Regex.IsMatch(value, "/.+\\..{6}\\..+/g"))
                        {
                            Console.WriteLine("Wrong token! Make sure your token is valid.");
                            return;
                        }

                        DiscordBot discordBot = new(value);
                        await discordBot.StartDiscordBot();

                        return;
                    #endregion
                }
            }
#endif
        }
    }
}