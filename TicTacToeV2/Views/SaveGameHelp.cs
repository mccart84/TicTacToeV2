using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeV2.Controller;

namespace TicTacToeV2.Views
{
    class SaveGameHelp
    {
        private static int defaultValue = 0;
        public static void SaveGameHelpPage()
        {
            Console.Clear();
            Console.WriteLine("Save Game Help: ");
            Console.WriteLine("Saving a game exits the current game and allows the game to be continued later..");
            Console.WriteLine("");
            Console.WriteLine("If a player wishes to save the current game, then they need to enter 'SAVE'");
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
