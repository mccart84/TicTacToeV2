using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeV2.Views
{
    class WinConditionHelp
    {
        public static void WinConditionsHelpPage()
        {
            Console.Clear();
            Console.WriteLine("Winning the game requires a player to control 3 spots in a row.");
            Console.WriteLine("These spots can span across all three boards");
            Console.WriteLine("");
            Console.WriteLine("Examples:");
            Console.WriteLine("A1 => B5 => C9");
            Console.WriteLine("A2 => A5 => A8");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("[1] Return to help page");
            Console.WriteLine("[2] Return to current game");
        }
    }
}
