using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spectre.Console;

namespace Frontend
{
    public class UserInteface
    {
        internal void MainMenu()
        {
            bool isOn = true;
            while (isOn)
            {
                 Console.Clear();
                var actionChoice = AnsiConsole.Prompt(
                new SelectionPrompt<MenuAction>().Title("Select an action:")
                .PageSize(10)
                .UseConverter(action =>
                    System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(
                        action.ToString().Replace("_", " ").ToLower()))
                .AddChoices(Enum.GetValues<MenuAction>()));
            }
        }
    }
}
