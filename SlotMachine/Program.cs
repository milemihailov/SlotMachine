using System.Linq;
using SlotMachine;
namespace SlotMachine
{
    public static class Program
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
            Console.WriteLine("Enter your wage:");
            int wage = 0;
            bool numEntered = false;
            while (!numEntered)
            {
                string inputWageNum = Console.ReadLine();
                numEntered = int.TryParse(inputWageNum, out wage);
                if (!numEntered)
                {
                    Console.WriteLine("Please enter a number:");
                }
            }
            int total = wage;
            while (question == 'y')
            {
                Console.WriteLine($"Your total is: {total}");
                Console.WriteLine("Enter your bet:");
                bool waitForBet = false;
                int bet = 0;
                while (!waitForBet) { 
                    string inputBetNum = Console.ReadLine();
                    waitForBet = int.TryParse(inputBetNum, out bet);
                    if (!waitForBet)
                    {
                        Console.WriteLine("Please enter a number:");
                    }
                }
                if (bet > total)
                {
                    Console.WriteLine("Insufficient funds");
                    Console.WriteLine($"Your total is: {total}");
                    continue;
                }
                total -= bet;
                Console.Clear();
                Console.WriteLine("Choose which lines to play");
                Console.WriteLine("'h' for 'Horizontal', 'v' for 'Vertical', 'd' for 'Diagonal'");
                char line = Console.ReadKey().KeyChar;
                Console.Clear();
                // generating random numbers for the grid and display the grid
                for (int row = 0; row < slotNumbers.GetLength(0); row++)
                {
                    for (int column = 0; column < slotNumbers.GetLength(1); column++)
                    {
                        int randomNum = rng.Next(MAX_RANDOM_NUM);
                        slotNumbers[row, column] = randomNum;
                        Console.Write($"{slotNumbers[row, column]}   ");
                    }
                    Console.WriteLine("\n");
                }
                Console.WriteLine($"\nYou have bet ${bet}");
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
                    Console.WriteLine("You lost!");
                    System.Environment.Exit(0);
                }
                Console.WriteLine("Would you like to play another one?");
                Console.WriteLine("Choose 'y' to continue any other key to exit ");
                question = Console.ReadKey().KeyChar;
                Console.Clear();
            }
        }
    }
}