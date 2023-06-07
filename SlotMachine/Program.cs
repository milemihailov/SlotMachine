using SlotMachine;
using System.Linq;
namespace SlotMachine
{
    internal class Program
    {
        const int GRID = 3;
        const int WIN_LINE = 3;
        static void Main(string[] args)
        {
            int[,] slotNumbers = new int[GRID, GRID];
            char question = 'y';
            UiMethods.WelcomeMessage();
            UiMethods.GuideThroughGame(UiMethods.Options.Wage);
            int total = ConditionMethods.WaitForNum();
            while (question == 'y')
            {
                UiMethods.Funds(total);
                UiMethods.GuideThroughGame(UiMethods.Options.Bet);
                int bet = ConditionMethods.WaitForBet();
                if (bet > total)
                {
                    Console.WriteLine("Insufficient funds");
                    continue;
                }
                // decrements bet from the total amount
                total -= bet;
                Console.Clear();
                // asks the user what lines to play and assign it to variable "line"
                char line = UiMethods.IntroToTheGame();
                Console.Clear();
                // generating random numbers for the grid and display the grid
                UiMethods.PopulateGrid(slotNumbers);
                // user is asked to enter the bet
                UiMethods.UserBet(bet);
                // horizontal check
                total = LinesCheckMethods.HorizontalLineCheck(line, slotNumbers, total, bet, WIN_LINE);
                // vertical check
                total = LinesCheckMethods.VerticalLineCheck(line, slotNumbers, total, bet, WIN_LINE);
                // diagonal check
                total = LinesCheckMethods.DiagonalLineCheck(line, slotNumbers, total, bet, WIN_LINE);
                // check to see if there is funds left if not exits the game
                ConditionMethods.GameLost(total);
                // asks the user to play again
                question = UiMethods.Replay(question);
            }
        }
    }
}