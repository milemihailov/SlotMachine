using System.Linq;
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

            while (question == 'y')
            {
                Console.WriteLine(@$"Hello you can choose to play 'Horizontal', 'Vertical' and 'Diagonal' lines.
You can play 1 line for $1 and up to ${GRID} and up to {GRID} lines for 'Horizontal' and 'Vertical' up to 2 lines for 'Diagonal'
Choose your wager and lines to play!
Enter your wager:");

                int wage = 0;
                try
                {
                    wage = Convert.ToInt32(Console.ReadLine());

                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("You need to enter a number.\nTry again.");
                    continue;
                }

                Console.Clear();
                Console.WriteLine("Choose which lines to play");
                Console.WriteLine("'h' for 'Horizontal', 'v' for 'Vertical', 'd' for 'Diagonal'");
                char line = Console.ReadKey().KeyChar;
                Console.Clear();

                int horizontalLinesWon = 0;
                int horizontalCount = 0;

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

                Console.WriteLine($"\nYou have bet ${wage}");
                // horizontal
                if (line == 'h')
                {
                    for( int row = 0; row < slotNumbers.GetLength(0); row++) {
                        for( int column = 0;column < slotNumbers.GetLength(1); column++)
                        {
                            if (slotNumbers[row, 0] == slotNumbers[row, column])
                            {
                                horizontalCount++;
                            }
                            if (horizontalCount == 3)
                            {
                                horizontalLinesWon++;
                            }
                        }
                        horizontalCount = 0;
                    }

                    Console.WriteLine(@$"You have {horizontalLinesWon} winning lines.
You have won ${horizontalLinesWon}
Your total is ${horizontalLinesWon + horizontalLinesWon}");
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
                            }
                        }
                        verticalCount = 0;
                    }
                    Console.WriteLine(@$"You have {verticalLinesWon} winning lines.
You have won ${verticalLinesWon}
Your total is ${verticalLinesWon + verticalLinesWon}");
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
                        if (slotNumbers[0,0] == slotNumbers[row, row])
                        {
                            firstDiagCountLine++;
                        }
                        if (slotNumbers[0,GRID-1] == slotNumbers[row, column])
                        {
                            secondDiagonalCountLine++;
                        }
                        if (firstDiagCountLine == WIN_LINE)
                        {
                            diagonalLinesWon++;
                        }
                        if (secondDiagonalCountLine == WIN_LINE)
                        {
                            diagonalLinesWon++;
                        }
                        column--;
                    }

                    Console.WriteLine(@$"You have {diagonalLinesWon} winning lines.
You have won ${diagonalLinesWon}
Your total is ${diagonalLinesWon + diagonalLinesWon}");

                }
                Console.WriteLine("Would you like to play another one?");
                Console.WriteLine("Choose 'y' to continue any other key to exit ");
                question = Console.ReadKey().KeyChar;
                Console.Clear();
            }

        }
    }
}