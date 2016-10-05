using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using TicTacToeV2.Controller;

namespace TicTacToeV2.Views
{
    class GameBoard
    {
        static char[] delineator = { 'A', 'B', 'C' };
        static char[] arrA = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static char[] arrB = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static char[] arrC = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static char[] arrReset = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static string quit = "QUIT";
        static int choice;
        static int player = 0;
        static string boardSelection = "";                 
        static int flag = 0;
        static int defaultValue = 0;
        static int moveCount = 0;
        private static string player1Name;
        private static string player2Name;
        

        public static void NewGame(string player1, string player2, int goesFirst)
        {
            do
            {
                if (player == 0)
                {
                    player1Name = player1;
                    player2Name = player2;
                    player = goesFirst;
                }                
                Console.Clear();
                Console.WriteLine("Enter 'Help' at any time for a list of options.");
                Console.WriteLine("");
                Console.WriteLine($"{player1}:X and {player2}:O");
                Console.WriteLine("\n");

                Console.WriteLine("\n");
                Board();
                Console.WriteLine(player%2 == 0 ? "" + player2 + " Chance" : "" + player1 + " Chance");
                Console.WriteLine("Please make a selection.");

                while (boardSelection == "")
                {
                    var board = Console.ReadLine().ToUpper();

                    if (board.Contains("A") || board.Contains("B") || board.Contains("C"))
                    {
                        var boardChoice = Regex.Split(board, @"(?<=[ABC])");

                        boardSelection = boardChoice[0];

                        if(board.Contains("1") || board.Contains("2") || board.Contains("3") || board.Contains("4") || board.Contains("5") || board.Contains("6") || board.Contains("7") || board.Contains("8") || board.Contains("9"))
                        {
                            var validateChoice = int.TryParse(boardChoice[1], out defaultValue);

                            if (validateChoice)
                            {
                                var validatedChoice = int.Parse(boardChoice[1]);

                                if (validatedChoice == 1 || validatedChoice <= 9)
                                {
                                    choice = validatedChoice;
                                }
                            }
                        }
                    }
                    else if (board == quit)
                    {
                        QuitGame();
                    }
                    else if (board == "HELP")
                    {
                        HelpMenu();
                    }
                    else
                    {
                        Console.WriteLine("{0} is not a valid selection.", board.ToString());
                        Thread.Sleep(1000);                                       
                    }
                }                
                
                if (boardSelection == "A")
                {
                    UserSelection(arrA, choice);
                    boardSelection = "";
                }
                else if (boardSelection == "B")
                {
                    UserSelection(arrB, choice);
                    boardSelection = "";
                }
                else if (boardSelection == "C")
                {
                    UserSelection(arrC, choice);
                    boardSelection = "";
                }                

                flag = CheckWin();

            } while (flag != 1 && flag != -1);

            Console.Clear(); 
            Board();

            if (flag == 1)
            {
                var playerVictory = (player%2) + 1;
                if (playerVictory == 1)
                {
                    Console.WriteLine("{0} has won", player1Name);
                } else if (playerVictory == 2)
                {
                    Console.WriteLine("{0} has won", player2Name); 
                }
                Console.WriteLine("Press any key to return to the main menu");
                Console.ReadKey();
                ResetGameBoards();
                player = 1;
                MainMenu.MainMenuContent();
            }
            else
            {
                Console.WriteLine("Draw");
                Console.WriteLine("Press any key to return to the main menu");
                Console.ReadKey();
                ResetGameBoards();
                player = 1;
                MainMenu.MainMenuContent();
            }
            Console.ReadLine();
        }
        
        /// <summary>
        /// 
        /// </summary>
        private static void Board()
        {
            string topRow = "     |   |          |   |          |   |   ";
            int boardWidth = topRow.Length;
            Console.SetCursorPosition((Console.WindowWidth - boardWidth) / 2, 4);
            Console.WriteLine("     A              B              C        ");
            Console.SetCursorPosition((Console.WindowWidth - boardWidth) / 2, 6);
            Console.WriteLine("   |   |          |   |          |   |      ");
            Console.SetCursorPosition((Console.WindowWidth - boardWidth) / 2, 7);
            Console.WriteLine(" {0} | {1} | {2}      {3} | {4} | {5}      {6} | {7} | {8}", arrA[1], arrA[2], arrA[3], arrB[1], arrB[2], arrB[3], arrC[1], arrC[2], arrC[3]);
            Console.SetCursorPosition((Console.WindowWidth - boardWidth) / 2, 8);
            Console.WriteLine("___|___|___    ___|___|___    ___|___|___");
            Console.SetCursorPosition((Console.WindowWidth - boardWidth) / 2, 9);
            Console.WriteLine("   |   |          |   |          |   |      ");
            Console.SetCursorPosition((Console.WindowWidth - boardWidth) / 2, 10);
            Console.WriteLine(" {0} | {1} | {2}      {3} | {4} | {5}      {6} | {7} | {8}", arrA[4], arrA[5], arrA[6], arrB[4], arrB[5], arrB[6], arrC[4], arrC[5], arrC[6]);
            Console.SetCursorPosition((Console.WindowWidth - boardWidth) / 2, 11);
            Console.WriteLine("___|___|___    ___|___|___    ___|___|___");
            Console.SetCursorPosition((Console.WindowWidth - boardWidth) / 2, 12);
            Console.WriteLine("   |   |          |   |          |   |      ");
            Console.SetCursorPosition((Console.WindowWidth - boardWidth) / 2, 13);
            Console.WriteLine(" {0} | {1} | {2}      {3} | {4} | {5}      {6} | {7} | {8}", arrA[7], arrA[8], arrA[9], arrB[7], arrB[8], arrB[9], arrC[7], arrC[8], arrC[9]);
            Console.SetCursorPosition((Console.WindowWidth - boardWidth) / 2, 14);
            Console.WriteLine("   |   |          |   |          |   |      ");
            Console.WriteLine("");
        }

        public static void UserSelection(char[] board, int choice)
        {
            if (board[choice] != 'X' && board[choice] != 'O')
            {
                if (player % 2 == 0)
                {
                    board[choice] = 'O';
                    player++;
                    boardSelection = "";
                    moveCount++;
                }
                else
                {
                    board[choice] = 'X';
                    player++;
                    boardSelection = "";
                    moveCount++;
                }
            }
            else
            {
                Console.WriteLine("Sorry the row {0} is already marked with {1}", choice, board[choice]);
                Console.WriteLine("\n");
                Console.WriteLine("Please wait 2 second board is loading again.....");
                Thread.Sleep(2000);
            }
        }

        public static void QuitGame()
        {
            ResetGameBoards();
            player = 1;
            MainMenu.MainMenuContent();
        }

        public static void HelpMenu()
        {
            GameController.GoToHelpPage(player1Name, player2Name, player);
        }

        public static void ResetGameBoards()
        {
            if (arrA.Contains('X') || arrA.Contains('O'))
            {
                arrA = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            }
            if (arrB.Contains('X') || arrB.Contains('O'))
            {
                arrB = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            }
            if (arrC.Contains('X') || arrC.Contains('O'))
            {
                arrC = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            }
        }

        private static int CheckWin()
        {
            #region Horzontal Winning Condtion
            //Winning Condition For First Row on Board A  
            if ((arrA[1] == 'X' && arrA[2] == 'X' && arrA[3] == 'X') || (arrA[1] == 'O' && arrA[2] == 'O' && arrA[3] == 'O'))
            {
                return 1;
            }
            //Winning Condition For Second Row on Board A   
            else if ((arrA[4] == 'X' && arrA[5] == 'X' && arrA[6] == 'X') || (arrA[4] == 'O' && arrA[5] == 'O' && arrA[6] == 'O'))
            {
                return 1; 
            }
            //Winning Condition For Third Row on Board A
            else if ((arrA[7] == 'X' && arrA[8] == 'X' && arrA[9] == 'X') || (arrA[7] == 'O' && arrA[8] == 'O' && arrA[9] == 'O'))
            {
                return 1;
            }
            //Winning Condition For Second Row on Board B 
            else if ((arrB[1] == 'X' && arrB[2] == 'X' && arrB[3] == 'X') || (arrB[1] == 'O' && arrB[2] == 'O' && arrB[3] == 'O'))
            {
                return 1;
            }
            //Winning Condition For Second Row on Board B   
            else if ((arrB[4] == 'X' && arrB[5] == 'X' && arrB[6] == 'X') || (arrB[4] == 'O' && arrB[5] == 'O' && arrB[6] == 'O'))
            {
                return 1;
            }
            //Winning Condition For Third Row on Board B  
            else if ((arrB[7] == 'X' && arrB[8] == 'X' && arrB[9] == 'X') || (arrB[7] == 'O' && arrB[8] == 'O' && arrB[9] == 'O'))
            {
                return 1;
            }
            //Winning Condition For Second Row on Board C 
            else if ((arrC[1] == 'X' && arrC[2] == 'X' && arrC[3] == 'X') || (arrC[1] == 'O' && arrC[2] == 'O' && arrC[3] == 'O'))
            {
                return 1;
            }
            //Winning Condition For Second Row on Board C  
            else if ((arrC[4] == 'X' && arrC[5] == 'X' && arrC[6] == 'X') || (arrC[4] == 'O' && arrC[5] == 'O' && arrC[6] == 'O'))
            {
                return 1;
            }
            //Winning Condition For Third Row on Board C  
            else if ((arrC[7] == 'X' && arrC[8] == 'X' && arrC[9] == 'X') || (arrC[7] == 'O' && arrC[8] == 'O' && arrC[9] == 'O'))
            {
                return 1;
            }
            //Winning Condition For cross sections on all 3 boards
            else if ((arrA[1] == 'X' && arrB[1] == 'X' && arrC[1] == 'X') || (arrA[1] == 'O' && arrB[1] == 'O' && arrC[1] == 'O'))
            {
                return 1;
            }
            else if ((arrA[2] == 'X' && arrB[2] == 'X' && arrC[2] == 'X') || (arrA[2] == 'O' && arrB[2] == 'O' && arrC[2] == 'O'))
            {
                return 1;
            }
            else if ((arrA[3] == 'X' && arrB[3] == 'X' && arrC[3] == 'X') || (arrA[3] == 'O' && arrB[3] == 'O' && arrC[3] == 'O'))
            {
                return 1;
            }
            else if ((arrA[4] == 'X' && arrB[4] == 'X' && arrC[4] == 'X') || (arrA[4] == 'O' && arrB[4] == 'O' && arrC[4] == 'O'))
            {
                return 1;
            }
            else if ((arrA[5] == 'X' && arrB[5] == 'X' && arrC[5] == 'X') || (arrA[5] == 'O' && arrB[5] == 'O' && arrC[5] == 'O'))
            {
                return 1;
            }
            else if ((arrA[6] == 'X' && arrB[6] == 'X' && arrC[6] == 'X') || (arrA[6] == 'O' && arrB[6] == 'O' && arrC[6] == 'O'))
            {
                return 1;
            }
            else if ((arrA[7] == 'X' && arrB[7] == 'X' && arrC[7] == 'X') || (arrA[7] == 'O' && arrB[7] == 'O' && arrC[7] == 'O'))
            {
                return 1;
            }
            else if ((arrA[8] == 'X' && arrB[8] == 'X' && arrC[8] == 'X') || (arrA[8] == 'O' && arrB[8] == 'O' && arrC[8] == 'O'))
            {
                return 1;
            }
            else if ((arrA[9] == 'X' && arrB[9] == 'X' && arrC[9] == 'X') || (arrA[9] == 'O' && arrB[9] == 'O' && arrC[9] == 'O'))
            {
                return 1;
            }
            #endregion

            #region vertical Winning Condtion
            //Winning Condition For First Column       
            else if ((arrA[1] == 'X' && arrA[4] == 'X' && arrA[7] == 'X') || (arrA[1] == 'O' && arrA[4] == 'O' && arrA[7] == 'O'))
            {
                return 1;
            }
            //Winning Condition For Second Column  
            else if ((arrA[2] == 'X' && arrA[5] == 'X' && arrA[8] == 'X') || (arrA[2] == 'O' && arrA[5] == 'O' && arrA[8] == 'O'))
            {
                return 1;
            }
            //Winning Condition For Third Column  
            else if ((arrA[3] == 'X' && arrA[6] == 'X' && arrA[9] == 'X') || (arrA[3] == 'O' && arrA[6] == 'O' && arrA[9] == 'O'))
            {
                return 1;
            }
            // Winning Condition For First Column       
            else if ((arrB[1] == 'X' && arrB[4] == 'X' && arrB[7] == 'X') || (arrB[1] == 'O' && arrB[4] == 'O' && arrB[7] == 'O'))
            {
                return 1;
            }
            //Winning Condition For Second Column  
            else if ((arrB[2] == 'X' && arrB[5] == 'X' && arrB[8] == 'X') || (arrB[2] == 'O' && arrB[5] == 'O' && arrB[8] == 'O'))
            {
                return 1;
            }
            //Winning Condition For Third Column  
            else if ((arrB[3] == 'X' && arrB[6] == 'X' && arrB[9] == 'X') || (arrB[3] == 'O' && arrB[6] == 'O' && arrB[9] == 'O'))
            {
                return 1;
            }
            // Winning Condition For First Column       
            else if ((arrC[1] == 'X' && arrC[4] == 'X' && arrC[7] == 'X') || (arrC[1] == 'O' && arrC[4] == 'O' && arrC[7] == 'O'))
            {
                return 1;
            }
            //Winning Condition For Second Column  
            else if ((arrC[2] == 'X' && arrC[5] == 'X' && arrC[8] == 'X') || (arrC[2] == 'O' && arrC[5] == 'O' && arrC[8] == 'O'))
            {
                return 1;
            }
            //Winning Condition For Third Column  
            else if ((arrC[3] == 'X' && arrC[6] == 'X' && arrC[9] == 'X') || (arrC[3] == 'O' && arrC[6] == 'O' && arrC[9] == 'O'))
            {
                return 1;
            }
            #endregion

            #region Diagonal Winning Condition
            else if ((arrA[1] == 'X' && arrA[5] == 'X' && arrA[9] == 'X') || (arrA[1] == 'O' && arrA[5] == 'O' && arrA[9] == 'O'))
            {
                return 1;
            }
            else if ((arrA[3] == 'X' && arrA[5] == 'X' && arrA[7] == 'X') || (arrA[3] == 'O' && arrA[5] == 'O' && arrA[7] == 'O'))
            {
                return 1;
            }
            else if ((arrB[1] == 'X' && arrB[5] == 'X' && arrB[9] == 'X') || (arrB[1] == 'O' && arrB[5] == 'O' && arrB[9] == 'O'))
            {
                return 1;
            }
            else if ((arrB[3] == 'X' && arrB[5] == 'X' && arrB[7] == 'X') || (arrB[3] == 'O' && arrB[5] == 'O' && arrB[7] == 'O'))
            {
                return 1;
            }
            else if ((arrC[1] == 'X' && arrC[5] == 'X' && arrC[9] == 'X') || (arrC[1] == 'O' && arrC[5] == 'O' && arrC[9] == 'O'))
            {
                return 1;
            }
            else if ((arrC[3] == 'X' && arrC[5] == 'X' && arrC[7] == 'X') || (arrC[3] == 'O' && arrC[5] == 'O' && arrC[7] == 'O'))
            {
                return 1;
            }

            else if ((arrA[1] == 'X' && arrB[2] == 'X' && arrC[3] == 'X') || (arrA[1] == 'O' && arrB[2] == 'O' && arrC[3] == 'O'))
            {
                return 1;
            }
            else if ((arrA[4] == 'X' && arrB[5] == 'X' && arrC[6] == 'X') || (arrA[4] == 'O' && arrB[5] == 'O' && arrC[6] == 'O'))
            {
                return 1;
            }
            else if ((arrA[7] == 'X' && arrB[8] == 'X' && arrC[9] == 'X') || (arrA[7] == 'O' && arrB[8] == 'O' && arrC[9] == 'O'))
            {
                return 1;
            }
            else if ((arrA[3] == 'X' && arrB[2] == 'X' && arrC[1] == 'X') || (arrA[3] == 'O' && arrB[2] == 'O' && arrC[1] == 'O'))
            {
                return 1;
            }
            else if ((arrA[6] == 'X' && arrB[5] == 'X' && arrC[4] == 'X') || (arrA[6] == 'O' && arrB[5] == 'O' && arrC[4] == 'O'))
            {
                return 1;
            }
            else if ((arrA[9] == 'X' && arrB[8] == 'X' && arrC[7] == 'X') || (arrA[9] == 'O' && arrB[8] == 'O' && arrC[7] == 'O'))
            {
                return 1;
            }
            else if ((arrA[1] == 'X' && arrB[5] == 'X' && arrC[9] == 'X') || (arrA[1] == 'O' && arrB[5] == 'O' && arrC[9] == 'O'))
            {
                return 1;
            }
            else if ((arrA[3] == 'X' && arrB[5] == 'X' && arrC[7] == 'X') || (arrA[3] == 'O' && arrB[5] == 'O' && arrC[7] == 'O'))
            {
                return 1;
            }
            else if ((arrA[3] == 'X' && arrB[6] == 'X' && arrC[9] == 'X') || (arrA[3] == 'O' && arrB[6] == 'O' && arrC[9] == 'O'))
            {
                return 1;
            }
            else if ((arrA[9] == 'X' && arrB[6] == 'X' && arrC[3] == 'X') || (arrA[9] == 'O' && arrB[6] == 'O' && arrC[3] == 'O'))
            {
                return 1;
            }
            else if ((arrA[2] == 'X' && arrB[5] == 'X' && arrC[8] == 'X') || (arrA[2] == 'O' && arrB[5] == 'O' && arrC[8] == 'O'))
            {
                return 1;
            }
            else if ((arrA[8] == 'X' && arrB[5] == 'X' && arrC[2] == 'X') || (arrA[8] == 'O' && arrB[5] == 'O' && arrC[2] == 'O'))
            {
                return 1;
            }
            else if ((arrA[1] == 'X' && arrB[4] == 'X' && arrC[7] == 'X') || (arrA[1] == 'O' && arrB[4] == 'O' && arrC[7] == 'O'))
            {
                return 1;
            }
            else if ((arrA[7] == 'X' && arrB[4] == 'X' && arrC[1] == 'X') || (arrA[7] == 'O' && arrB[4] == 'O' && arrC[1] == 'O'))
            {
                return 1;
            }
            else if ((arrA[3] == 'X' && arrB[5] == 'X' && arrC[7] == 'X') || (arrA[3] == 'O' && arrB[5] == 'O' && arrC[7] == 'O'))
            {
                return 1;
            }
            else if ((arrA[7] == 'X' && arrB[5] == 'X' && arrC[3] == 'X') || (arrA[7] == 'O' && arrB[5] == 'O' && arrC[3] == 'O'))
            {
                return 1;
            }
            #endregion

            #region Checking For Draw
            // If all the cells or values filled with X or O then any player has won the match  
            else if (arrA[1] != '1' && arrA[2] != '2' && arrA[3] != '3' && arrA[4] != '4' && arrA[5] != '5' && arrA[6] != '6' && arrA[7] != '7' && arrA[8] != '8' && arrA[9] != '9')
            {
                return -1;
            }
            #endregion

            else
            {
                return 0;
            }
        }

        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
}
