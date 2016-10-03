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
            string logoTop = "_______ _  ___   _______ _____  ___   _______ _____   ___";
            string logoLine2 = "\\_   _/| ||  _|  \\_   _/|  _  ||  _|  \\_   _/|  _  | |  _|";
            string logoLine3 = "  | |  | || |  __  | |  | |_| || |  __  | |  | | | | | |_";
            string logoLine4 = "  | |  | || | |__| | |  |  _  || | |__| | |  | | | | |  _|";
            string logoLine5 = "  | |  | || |_     | |  | | | || |_     | |  | |_| | | |_";
            string logoLine6 = "  |_|  |_||___|    |_|  |_| |_||___|    |_|  |_____| |___|";

            while (selection == 0)
            {
                Console.Clear();
                Console.SetCursorPosition((Console.WindowWidth - logoTop.Length)/2, 6);
                Console.WriteLine(logoTop);
                Console.SetCursorPosition((Console.WindowWidth - logoLine2.Length) / 2, 7);
                Console.WriteLine(logoLine2);
                Console.SetCursorPosition((Console.WindowWidth - logoLine3.Length) / 2, 8);
                Console.WriteLine(logoLine3);
                Console.SetCursorPosition((Console.WindowWidth - logoLine4.Length) / 2, 9);
                Console.WriteLine(logoLine4);
                Console.SetCursorPosition((Console.WindowWidth - logoLine5.Length) / 2, 10);
                Console.WriteLine(logoLine5);
                Console.SetCursorPosition((Console.WindowWidth - logoLine6.Length) / 2, 11);
                Console.WriteLine(logoLine6);
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
