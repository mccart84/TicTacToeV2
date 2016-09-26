using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.SetCursorPosition((Console.WindowWidth - menuOption1.Length) / 2, 15);
            Console.WriteLine(menuOption1);
            Console.SetCursorPosition((Console.WindowWidth - menuOption2.Length) / 2, 16);
            Console.WriteLine(menuOption2);

            while (selection == 0)
            {
                userSelection = Console.ReadLine();
                var validateUserSelection = int.TryParse(userSelection, out defaultValue);

                if (validateUserSelection)
                {
                    var inputValue = int.Parse(userSelection);
                    if  (inputValue == 1 || inputValue < 3)
                    {
                        selection = int.Parse(userSelection);
                    }
                    else
                    {
                        Console.WriteLine("{0} is not a valid menu option", userSelection.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("{0} is not a valid menu option", userSelection.ToString());
                }

                if (selection != 0)
                {
                    if (selection == 1 || selection < 3)
                    {
                        switch (selection)
                        {
                            case 1:
                                MainMenu.MainMenuContent();
                                break;
                            case 2:
                                Environment.Exit(0);
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("{0} is not a valid menu option", selection.ToString());
                    }
                }
            }
        }
    }
}
