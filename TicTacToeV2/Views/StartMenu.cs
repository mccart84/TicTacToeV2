using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TicTacToeV2.Controller;

namespace TicTacToeV2.Views
{
    class StartMenu
    {
        public static void Main(string[] args)
        {
            int selection = 0;
            int defaultValue = 0;
            string userSelection;
            string menuOption1 = "[1] Main Menu";
            string menuOption2 = "[2] Quit";            

            while (selection == 0)
            {
                Console.Clear();
                Console.SetCursorPosition(12, 6);
                Console.WriteLine("_______ _  ___   _______ _____  ___   _______ _____   ___");
                Console.SetCursorPosition(12, 7);
                Console.WriteLine("\\_   _/| ||  _|  \\_   _/|  _  ||  _|  \\_   _/|  _  | |  _|");
                Console.SetCursorPosition(12, 8);
                Console.WriteLine("  | |  | || |  __  | |  | |_| || |  __  | |  | | | | | |_");
                Console.SetCursorPosition(12, 9);
                Console.WriteLine("  | |  | || | |__| | |  |  _  || | |__| | |  | | | | |  _|");
                Console.SetCursorPosition(12, 10);
                Console.WriteLine("  | |  | || |_     | |  | | | || |_     | |  | |_| | | |_");
                Console.SetCursorPosition(12, 11);
                Console.WriteLine("  |_|  |_||___|    |_|  |_| |_||___|    |_|  |_____| |___|");
                Console.SetCursorPosition((Console.WindowWidth - menuOption1.Length) / 2, 15);
                Console.WriteLine(menuOption1);
                Console.SetCursorPosition((Console.WindowWidth - menuOption2.Length) / 2, 16);
                Console.WriteLine(menuOption2);

                userSelection = Console.ReadLine();
                var validateUserSelection = int.TryParse(userSelection, out defaultValue);

                if (validateUserSelection)
                {
                    var inputValue = int.Parse(userSelection);
                    if  (inputValue > 0 && inputValue < 3)
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
                    Console.WriteLine("{0} is not a valid menu option", userSelection.ToString());
                    Thread.Sleep(2000);
                }

                if (selection != 0)
                {
                    if (selection == 1 || selection < 3)
                    {
                        GameController.StartMenuNavigation(selection);
                    }
                    else
                    {
                        Console.WriteLine("Please choose menu option");
                        Thread.Sleep(2000);
                    }
                }
            }
        }
    }
}
