using System.Linq;
using SlotMachine;
namespace SlotMachine
{
    internal class Program
    {
        const int MAX_RANDOM_NUM = 2;
        const int GRID = 3;
        const int WIN_LINE = 3;
        static void Main(string[] args)
        {
            int[,] slotNumbers = new int[GRID, GRID];
            Random rng = new Random();
            char question = 'y';
            UiMethods.WelcomeMessage();
            UiMethods.GuideThroughGame(UiMethods.Options.Wage);
            int wage = 0;
            bool numEntered = false;
            while (!numEntered)
            {
                string inputWageNum = Console.ReadLine();
                numEntered = int.TryParse(inputWageNum, out wage);
                if (!numEntered)
                {
                    UiMethods.GuideThroughGame(UiMethods.Options.Number);
                }
            }
            int total = wage;
            while (question == 'y')
            {
                UiMethods.Funds(total);
                UiMethods.GuideThroughGame(UiMethods.Options.Bet);
                bool waitForBet = false;
                int bet = 0;
                while (!waitForBet)
                {
                    string inputBetNum = Console.ReadLine();
                    waitForBet = int.TryParse(inputBetNum, out bet);
                    if (!waitForBet)
                    {
                        UiMethods.GuideThroughGame(UiMethods.Options.Number);
                    }
                }
                if (bet > total)
                {
                    Console.WriteLine("Insufficient funds");
                    continue;
                }
                total -= bet;
                Console.Clear();
                UiMethods.IntroToTheGame();
                char line = Console.ReadKey().KeyChar;
                Console.Clear();
                // generating random numbers for the grid and display the grid
                for (int row = 0; row < slotNumbers.GetLength(0); row++)
                {
                    for (int column = 0; column < slotNumbers.GetLength(1); column++)
                    {
                        int randomNum = rng.Next(MAX_RANDOM_NUM);
                        slotNumbers[row, column] = randomNum;
                        UiMethods.MakingGrid(slotNumbers, row, column);
                    }
                    Console.WriteLine("\n");
                }
                UiMethods.UserBet(bet);
                // horizontal
                int horizontalLinesWon = 0;
                int horizontalCount = 0;
                if (line == 'h')
                {
                    for (int row = 0; row < slotNumbers.GetLength(0); row++)
                    {
                        for (int column = 0; column < slotNumbers.GetLength(1); column++)
                        {
                            if (slotNumbers[row, 0] == slotNumbers[row, column])
                            {
                                horizontalCount++;
                            }
                            if (horizontalCount == WIN_LINE)
                            {
                                horizontalLinesWon++;
                                total += (horizontalLinesWon * bet);
                            }
                        }
                        horizontalCount = 0;
                    }
                    UiMethods.DisplayStats(horizontalLinesWon, total, bet);
                }
                // vertical 
                int verticalLinesWon = 0;
                int verticalCount = 0;
                if (line == 'v')
                {
                    for (int row = 0; row < slotNumbers.GetLength(0); row++)
                    {
                        for (int column = 0; column < slotNumbers.GetLength(1); column++)
                        {
                            if (slotNumbers[0, row] == slotNumbers[column, row])
                            {
                                verticalCount++;
                            }
                            if (verticalCount == WIN_LINE)
                            {
                                verticalLinesWon++;
                                total += (verticalLinesWon * bet);
                            }
                        }
                        verticalCount = 0;
                    }
                    UiMethods.DisplayStats(verticalLinesWon, total, bet);
                }
                // diagonal
                int diagonalLinesWon = 0;
                int firstDiagCountLine = 0;
                int secondDiagonalCountLine = 0;
                if (line == 'd')
                {
                    int column = GRID - 1;
                    for (int row = 0; row < slotNumbers.GetLength(0); row++)
                    {
                        if (slotNumbers[0, 0] == slotNumbers[row, row])
                        {
                            firstDiagCountLine++;
                        }
                        if (slotNumbers[0, GRID - 1] == slotNumbers[row, column])
                        {
                            secondDiagonalCountLine++;
                        }
                        if (firstDiagCountLine == WIN_LINE)
                        {
                            diagonalLinesWon++;
                            total += (diagonalLinesWon * bet);
                        }
                        if (secondDiagonalCountLine == WIN_LINE)
                        {
                            diagonalLinesWon++;
                            total += (diagonalLinesWon * bet);
                        }
                        column--;
                    }
                    UiMethods.DisplayStats(diagonalLinesWon, total, bet);
                }
                if (total == 0)
                {
                    UiMethods.LostMessage();
                }
                UiMethods.Replay(question);
            }
        }
    }
}