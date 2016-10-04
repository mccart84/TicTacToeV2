using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeV2.Controller;

namespace TicTacToeV2.Views
{
    class MoveSelectionHelp
    {
        private static int defaultValue = 0;
        public static void MoveSelectionHelpPage()
        {
            Console.Clear();
            Console.WriteLine("Move Selection Help:");
            Console.WriteLine("Selecting moves is a very simple process in this game.");
            Console.WriteLine("If a player wants to select the position on board B in slot 5");
            Console.WriteLine("then the player would type in 'B5' for their choice");
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
