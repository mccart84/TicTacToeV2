using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TicTacToeV2.Views
{
    class GameBoard
    {
        static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static char[] arrReset = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int player = 1; 
        static int choice;   
                 
        static int flag = 0;

        public static void NewGame()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Player1:X and Player2:O");
                Console.WriteLine("\n");

                Console.WriteLine("\n");
                Board();
                Console.WriteLine(player%2 == 0 ? "Player 2 Chance" : "Player 1 Chance");

                choice = int.Parse(Console.ReadLine());
                
                if (arr[choice] != 'X' && arr[choice] != 'O')
                {
                    if (player % 2 == 0) 
                    {
                        arr[choice] = 'O';
                        player++;
                    }
                    else
                    {
                        arr[choice] = 'X';
                        player++;
                    }
                }
                else 
                {
                    Console.WriteLine("Sorry the row {0} is already marked with {1}", choice, arr[choice]);
                    Console.WriteLine("\n");
                    Console.WriteLine("Please wait 2 second board is loading again.....");
                    Thread.Sleep(2000);
                }
                flag = CheckWin(); 
            } while (flag != 1 && flag != -1);

            Console.Clear(); 
            Board();

            if (flag == 1)
            {
                Console.WriteLine("Player {0} has won", (player % 2) + 1);
                Console.WriteLine("Press any key to return to the main menu");
                Console.ReadKey();
                arr = arrReset;
                player = 1;
                MainMenu.MainMenuContent();
            }
            else
            {
                Console.WriteLine("Draw");
                Console.WriteLine("Press any key to return to the main menu");
                Console.ReadKey();
                arr = arrReset;
                player = 1;
                MainMenu.MainMenuContent();
            }
            Console.ReadLine();
        }
        
        private static void Board()
        {
            string topRow = "     |     |      ";
            int boardWidth = topRow.Length;
            Console.SetCursorPosition((Console.WindowWidth - boardWidth) / 2, 7);
            Console.WriteLine("     |     |      ");
            Console.SetCursorPosition((Console.WindowWidth - boardWidth) / 2, 8);
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[1], arr[2], arr[3]);
            Console.SetCursorPosition((Console.WindowWidth - boardWidth) / 2, 9);
            Console.WriteLine("_____|_____|_____ ");
            Console.SetCursorPosition((Console.WindowWidth - boardWidth) / 2, 10);
            Console.WriteLine("     |     |      ");
            Console.SetCursorPosition((Console.WindowWidth - boardWidth) / 2, 11);
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[4], arr[5], arr[6]);
            Console.SetCursorPosition((Console.WindowWidth - boardWidth) / 2, 12);
            Console.WriteLine("_____|_____|_____ ");
            Console.SetCursorPosition((Console.WindowWidth - boardWidth) / 2, 13);
            Console.WriteLine("     |     |      ");
            Console.SetCursorPosition((Console.WindowWidth - boardWidth) / 2, 14);
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[7], arr[8], arr[9]);
            Console.SetCursorPosition((Console.WindowWidth - boardWidth) / 2, 15);
            Console.WriteLine("     |     |      ");
        }


        public static void QuitGame()
        {
            arr = arrReset;
            player = 1;
            MainMenu.MainMenuContent();
        }
        
        private static int CheckWin()
        {
            #region Horzontal Winning Condtion
            //Winning Condition For First Row   
            if (arr[1] == arr[2] && arr[2] == arr[3])
            {
                return 1;
            }
            //Winning Condition For Second Row   
            else if (arr[4] == arr[5] && arr[5] == arr[6])
            {
                return 1;
            }
            //Winning Condition For Third Row   
            else if (arr[6] == arr[7] && arr[7] == arr[8])
            {
                return 1;
            }
            #endregion

            #region vertical Winning Condtion
            //Winning Condition For First Column       
            else if (arr[1] == arr[4] && arr[4] == arr[7])
            {
                return 1;
            }
            //Winning Condition For Second Column  
            else if (arr[2] == arr[5] && arr[5] == arr[8])
            {
                return 1;
            }
            //Winning Condition For Third Column  
            else if (arr[3] == arr[6] && arr[6] == arr[9])
            {
                return 1;
            }
            #endregion

            #region Diagonal Winning Condition
            else if (arr[1] == arr[5] && arr[5] == arr[9])
            {
                return 1;
            }
            else if (arr[3] == arr[5] && arr[5] == arr[7])
            {
                return 1;
            }
            #endregion

            #region Checking For Draw
            // If all the cells or values filled with X or O then any player has won the match  
            else if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' && arr[4] != '4' && arr[5] != '5' && arr[6] != '6' && arr[7] != '7' && arr[8] != '8' && arr[9] != '9')
            {
                return -1;
            }
            #endregion

            else
            {
                return 0;
            }
        }
    }
}
