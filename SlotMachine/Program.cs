using SlotMachine;
using System.Linq;
namespace SlotMachine
{
    internal class Program
    {
        const int GRID = 3;
        const int WIN_LINE = 3;
        static void Main(string[] args)
        {   // 2D array 3x3
            int[,] slotNumbers = new int[GRID, GRID];
            char question = 'y';
            // Welcomes the user to the game
            UiMethods.WelcomeMessage();
            // guides the user what to input
            UiMethods.GuideThroughGame(UiMethods.Options.Wage);
            // user enters total wage
            int total = ConditionMethods.WaitForNum();
            // game loop
            while (question == 'y')
            {   // show the total funds to user
                UiMethods.Funds(total);
                // guides the user what to input
                UiMethods.GuideThroughGame(UiMethods.Options.Bet);
                // user is asked to enter bet
                int bet = ConditionMethods.WaitForBet();
                // checks to see if bet is not bigger that the total
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
                // Checks chosen lines for win
                total = LinesCheckMethods.LineCheckForWin(line, slotNumbers, total, bet, WIN_LINE);
                // check to see if there is funds left if not exits the game
                ConditionMethods.GameLost(total);
                // asks the user to play again
                question = UiMethods.Replay(question);
            }
        }
    }
}