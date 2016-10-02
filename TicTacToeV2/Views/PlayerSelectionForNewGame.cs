using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TicTacToeV2.Views
{
    class PlayerSelectionForNewGame
    {
        static string player1 = "";
        static string player2 = "";
        static int goesFirst = 0;
        public static void PlayerNames()
        {
            Console.Clear();
            
            Console.WriteLine("Please enter a name for player 1 (leave empty for Player 1)");
            
            var player1Data = Console.ReadLine();

            if (player1Data.Length > 0)
            {
                player1 = player1Data;
            }
            else
            {
                player1 = "Player 1";
            }

            Console.Clear();

            Console.WriteLine("Please enter a name for player 2 (leave empty for Player 2)");

            var player2Data = Console.ReadLine();

            if (player2Data.Length > 0)
            {
                player2 = player2Data;
            }
            else
            {
                player2 = "Player 2";
            }

            var exitvalue = true;

            while (exitvalue)
            {
                Console.Clear();
                Console.WriteLine("Please select who goes first");
                Console.WriteLine("[1] Player 1");
                Console.WriteLine("[2] Player 2");
                Console.WriteLine("[3] Random");

                var userSelection = Console.ReadLine();
                var defaultValue = 0;
                var validateSelection = int.TryParse(userSelection, out defaultValue);

                if (validateSelection)
                {
                    var validated = int.Parse(userSelection);
                    if (validated == 1 || validated < 4)
                    {
                        GoesFirst(validated);
                        exitvalue = false;
                    }
                    else
                    {
                        Console.WriteLine("{0} is not a valid selection", userSelection);
                        Thread.Sleep(2000);
                        exitvalue = true;
                    }
                }
                else
                {
                    Console.WriteLine("{0} is not a valid selection", userSelection);
                    Thread.Sleep(2000);
                    exitvalue = true;
                }
            }

            if (player1 != "" && player2 != "" && goesFirst != 0)
            {
                GameBoard.NewGame(player1, player2, goesFirst);
            }
        }

        public static void GoesFirst(int choice)
        {
            if (choice == 1)
            {
                goesFirst = 1;   
            }
            else if (choice == 2)
            {
                goesFirst = 2;
            }
            else if (choice == 3)
            {
                Random rand = new Random();

                goesFirst = rand.Next(1, 3);
            }
        }
        
        
    }
}
