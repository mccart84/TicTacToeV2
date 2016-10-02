using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TicTacToeV2.Controller;

namespace TicTacToeV2.Views
{
    class HelpPage
    {
        public static void DisplayHelpMenu ()
        {
            var selection = 0;
            var defaultValue = 0;
            string userSelection;

            while (selection == 0)
            {
                Console.Clear();
                Console.WriteLine("Please choose a category.");
                Console.WriteLine("[1] Move Selection");
                Console.WriteLine("[2] Winning the game");
                Console.WriteLine("[3] Quitting a game");
                Console.WriteLine("[4] Saving a game");

                userSelection = Console.ReadLine();
                var validateUserSelection = int.TryParse(userSelection, out defaultValue);

                if (validateUserSelection)
                {
                    var inputValue = int.Parse(userSelection);
                    if (inputValue > 0 && inputValue < 7)
                    {
                        selection = int.Parse(userSelection);
                    }
                    else
                    {
                        Console.WriteLine("{0} is not a valid menu option", userSelection.ToString());
                        Thread.Sleep(2000);
                    }
                }
                else
                {
                    Console.WriteLine("Please choose a menu option");
                    Thread.Sleep(2000);
                }

                if (selection != 0)
                {
                    if (selection == 1 || selection < 5)
                    {
                        GameController.HelpMenuNavigation(selection);
                    }
                    else
                    {
                        Console.WriteLine("{0} is not a valid menu option", selection.ToString());
                        Thread.Sleep(2000);
                    }
                }
            }
        }
    }
}
