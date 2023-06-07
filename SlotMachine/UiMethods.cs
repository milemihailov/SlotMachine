using SlotMachine;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
namespace SlotMachine
{
    public static class UiMethods
    {
        const int MAX_RANDOM_NUM = 2;
        public enum Options
        {
            Bet,
            Wage,
            Number
        }
        const int GRID = 3;
        /// <summary>
        /// It is a welcome message to the game also explains the rules.
        /// </summary>
        public static void WelcomeMessage()
        {
            Console.WriteLine("Hello you can choose to play 'Horizontal', 'Vertical' and 'Diagonal' lines.");
            Console.WriteLine($"You can play 1 line for $1 and up to ${GRID} and up to {GRID} lines for 'Horizontal' and 'Vertical' up to 2 lines for 'Diagonal'");
            Console.WriteLine("Choose your wager and lines to play!");
        }
        /// <summary>
        /// Asks the user what lines to play.
        /// </summary>
        public static char IntroToTheGame()
        {
            Console.WriteLine("Choose which lines to play");
            Console.WriteLine("'h' for 'Horizontal', 'v' for 'Vertical', 'd' for 'Diagonal'");
            char line = Console.ReadKey().KeyChar;
            return line;
        }
        /// <summary>
        /// Generates a grid from a 2D array and displays it
        /// </summary>
        /// <param name="list">2D Array</param>
        public static void PopulateGrid(int[,] list)
        {
            Random rng = new Random();
            for (int row = 0; row < list.GetLength(0); row++)
            {
                for (int column = 0; column < list.GetLength(1); column++)
                {
                    int randomNum = rng.Next(MAX_RANDOM_NUM);
                    list[row, column] = randomNum;
                    Console.Write($"{list[row, column]}   ");
                }
                Console.WriteLine("\n");
            }
        }
        /// <summary>
        /// Informs the user of how much he bets.
        /// </summary>
        /// <param name="bet">Enter the bet of the user:</param>
        public static void UserBet(int bet)
        {
            Console.WriteLine($"\nYou have bet ${bet}");
        }
        /// <summary>
        /// It is displaying the outcome of the game if user won or lost and how much.
        /// </summary>
        /// <param name="linesWon">Enter the lines won:</param>
        /// <param name="total">Enter the total funds:</param>
        /// <param name="bet">Enter the user's bet</param>
        public static void DisplayStats(int linesWon, int total, int bet)
        {
            Console.WriteLine($"You have {linesWon} winning lines.");
            Console.WriteLine($"You have won ${linesWon * bet}");
            Console.WriteLine($"Your total is ${total}");
        }
        /// <summary>
        /// Asks if the user wants to play more.
        /// </summary>
        /// <param name="question"></param>
        /// <returns>What had user entered.</returns>
        public static char Replay(char question)
        {
            Console.WriteLine("Would you like to play another one?");
            Console.WriteLine("Choose 'y' to continue any other key to exit ");
            question = Console.ReadKey().KeyChar;
            Console.Clear();
            return question;
        }
        /// <summary>
        /// Informs the user he lost and exits the game.
        /// </summary>
        public static void LostMessage()
        {
            Console.WriteLine("You lost!");
            System.Environment.Exit(0);
        }
        /// <summary>
        /// Guides the user what to enter:
        /// </summary>
        /// <param name="mode"></param>
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
        /// <summary>
        /// Informs the user of his total funds
        /// </summary>
        /// <param name="total">Total funds of the user</param>
        public static void Funds(int total)
        {
            Console.WriteLine($"Your total is: {total}");
        }
    }
}
