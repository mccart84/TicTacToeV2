using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeV2.Views;

namespace TicTacToeV2.Controller
{
    class GameController
    {
        public static void StartMenuNavigation(int userSelection)
        {
            switch (userSelection)
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

        public static void MainMenuNavigation(int userSelection)
        {
            switch (userSelection)
            {
                case 1:
                    PlayerSelectionForNewGame.PlayerNames();
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

        public static void HelpMenuNavigation(int userSelection)
        {
            if (userSelection != 0)
            {
                switch (userSelection)
                {
                    case 1:
                        MoveSelectionHelp.MoveSelectionHelpPage();
                        break;
                    case 2:
                        WinConditionHelp.WinConditionsHelpPage();
                        break;
                    case 3:
                        QuitGameHelp.QuitGameHelpPage();
                        break;
                    case 4:
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
