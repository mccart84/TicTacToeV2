using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeV2.Views
{
    class MainMenu
    {
        public static void MainMenuContent()
        {
            int selection = 0;
            int defaultValue = 0;
            string userSelection;
            string menuOption1 = "[1] Start A New Game";
            string menuOption2 = "[2] Resume Game";
            string menuOption3 = "[3] Play Tutorial";
            string menuOption4 = "[4] View Current Game Stats";
            string menuOption5 = "[5] View Historic Game Stats";
            string menuOption6 = "[6] Quit";
            Console.Clear();
            Console.SetCursorPosition((Console.WindowWidth - menuOption1.Length) / 2, 7);
            Console.WriteLine(menuOption1);
            Console.SetCursorPosition((Console.WindowWidth - menuOption2.Length) / 2, 8);
            Console.WriteLine(menuOption2);
            Console.SetCursorPosition((Console.WindowWidth - menuOption3.Length) / 2, 9);
            Console.WriteLine(menuOption3);
            Console.SetCursorPosition((Console.WindowWidth - menuOption4.Length) / 2, 10);
            Console.WriteLine(menuOption4);
            Console.SetCursorPosition((Console.WindowWidth - menuOption5.Length) / 2, 11);
            Console.WriteLine(menuOption5);
            Console.SetCursorPosition((Console.WindowWidth - menuOption6.Length) / 2, 12);
            Console.WriteLine(menuOption6);

            while (selection == 0)
            {
                userSelection = Console.ReadLine();
                var validateUserSelection = int.TryParse(userSelection, out defaultValue);

                if (validateUserSelection)
                {
                    var inputValue = int.Parse(userSelection);
                    if (inputValue == 1 || inputValue < 7)
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
                    if (selection == 1 || selection < 7)
                    {
                        switch (selection)
                        {
                            case 1:
                                GameBoard.NewGame();
                                Console.ReadLine();
                                break;
                            case 2:
                                Console.WriteLine("Resume a game");
                                Console.ReadLine();
                                break;
                            case 3:
                                Console.WriteLine("Play Tutorial");
                                Console.ReadLine();
                                break;
                            case 4:
                                Console.WriteLine("Current Game Stats");
                                Console.ReadLine();
                                break;
                            case 5:
                                Console.WriteLine("Historic Game Stats");
                                Console.ReadLine();
                                break;
                            case 6:
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
