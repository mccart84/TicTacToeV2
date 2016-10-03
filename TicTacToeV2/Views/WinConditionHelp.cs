using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeV2.Controller;

namespace TicTacToeV2.Views
{
    class WinConditionHelp
    {
        private static int defaultValue = 0;
        public static void WinConditionsHelpPage()
        {
            Console.Clear();
            Console.WriteLine("Win Condition Help");
            Console.WriteLine("Winning the game requires a player to control 3 spots in a row.");
            Console.WriteLine("These spots can span across all three boards");
            Console.WriteLine("");
            Console.WriteLine("Examples:");
            Console.WriteLine("A1 => B5 => C9");
            Console.WriteLine("A2 => A5 => A8");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("[1] Return to help page");
            Console.WriteLine("[2] Return to current game");

            var selection = Console.ReadLine();
            var validateSelection = true;
            if (selection != null)
            {
                validateSelection = (int.TryParse(selection, out defaultValue));
            }

            if (validateSelection)
            {
                var validated = int.Parse(selection);
                GameController.NavigateFromHelpPage(validated);
            }
        }
    }
}
