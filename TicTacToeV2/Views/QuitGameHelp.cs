using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeV2.Controller;

namespace TicTacToeV2.Views
{
    class QuitGameHelp
    {
        private static int defaultValue = 0;
        public static void QuitGameHelpPage()
        {
            Console.Clear();
            Console.WriteLine("Quit Game Help: ");
            Console.WriteLine("Quitting a game exits without saving the current game.");
            Console.WriteLine("If a player decides to quit a game after the game has been started, ");
            Console.WriteLine("then that player receives a loss for the game.");
            Console.WriteLine("");
            Console.WriteLine("If a player wishes to quit the current game, then they need to enter 'QUIT'");
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
