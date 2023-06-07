using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SlotMachine;
namespace SlotMachine
{
    public static class UiMethods
    {
        public enum Options
        {
            Bet,
            Wage,
            Number
        }

        const int MAX_RANDOM_NUM = 2;
        const int GRID = 3;
        const int WIN_LINE = 3;
        public static void WelcomeMessage()
        {
            Console.WriteLine("Hello you can choose to play 'Horizontal', 'Vertical' and 'Diagonal' lines.");
            Console.WriteLine($"You can play 1 line for $1 and up to ${GRID} and up to {GRID} lines for 'Horizontal' and 'Vertical' up to 2 lines for 'Diagonal'");
            Console.WriteLine("Choose your wager and lines to play!");
        }
        public static void IntroToTheGame()
        {
            Console.WriteLine("Choose which lines to play");
            Console.WriteLine("'h' for 'Horizontal', 'v' for 'Vertical', 'd' for 'Diagonal'");
        }
        public static void MakingGrid(int[,] list, int row, int column)
        {
            Console.Write($"{list[row, column]}   ");
        }
        public static void UserBet(int bet)
        {
            Console.WriteLine($"\nYou have bet ${bet}");
        }
        public static void DisplayStats(int linesWon, int total, int bet)
        {
            Console.WriteLine($"You have {linesWon} winning lines.");
            Console.WriteLine($"You have won ${linesWon * bet}");
            Console.WriteLine($"Your total is ${total}");
        }
        public static char Replay(char question)
        {
            Console.WriteLine("Would you like to play another one?");
            Console.WriteLine("Choose 'y' to continue any other key to exit ");
            question = Console.ReadKey().KeyChar;
            Console.Clear();
            return question;
        }
        public static void LostMessage()
        {
            Console.WriteLine("You lost!");
            System.Environment.Exit(0);
        }
        public static void GuideThroughGame(Options mode)
        {
            switch (mode)
            {
                case Options.Number:
                    Console.WriteLine("Enter a number: ");
                    break;
                case Options.Bet:
                    Console.WriteLine("Enter your bet: ");
                    break;
                case Options.Wage:
                    Console.WriteLine("Enter your wage: ");
                    break;
            }
        }
        public static void Funds(int total)
        {
            Console.WriteLine($"Your total is: {total}");
        }

    }
}
