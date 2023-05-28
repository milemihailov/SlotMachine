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

            List<int> horizontal = new List<int>();
            List<int> vertical = new List<int>();

            char question = 'y';

            while (question == 'y')
            {
                Console.WriteLine(@$"Hello you can choose to play 'Horizontal', 'Vertical' and 'Diagonal' lines.
You can play 1 line for $1 and up to ${GRID} and up to {GRID} lines for 'Horizontal' and 'Vertical' up to 2 lines for 'Diagonal'
Choose your wager and lines to play!
Enter your wager:");
                
                char input = Console.ReadKey().KeyChar;
                Console.Clear();
                int wage = int.Parse(input.ToString());
                Console.WriteLine("Choose which lines to play");
                Console.WriteLine("'h' for 'Horizontal', 'v' for 'Vertical', 'd' for 'Diagonal'");
                char line = Console.ReadKey().KeyChar;
                Console.Clear();

                int row = 0;
                int horizontalLinesWon = 0;

                for (int i = 0; i < slotNumbers.GetLength(0); i++)
                {
                    for (int j = 0; j < slotNumbers.GetLength(1); j++)
                    {
                        int randomNum = rng.Next(MAX_RANDOM_NUM);
                        if (row == slotNumbers.GetLength(0))
                        {
                            Console.WriteLine("\n");
                            row = 0;
                        }
                        slotNumbers[i, j] = randomNum;
                        Console.Write($"{slotNumbers[i, j]}   ");
                        row++;
                        vertical.Add(slotNumbers[i, j]);
                        horizontal.Add(slotNumbers[i, j]);
                    }
                    // horizontal
                    if (horizontalLinesWon == wage)
                    {
                        continue;
                    }
                    if (horizontal.All(n => n == horizontal[0]))
                    {
                        horizontalLinesWon++;
                    }
                    horizontal.Clear();

                }

                // diagonal
                int diagonalLinesWon = 0;
                int diagCount = 0;
                for (int i = 0; i < vertical.Count; i += 4)
                {
                    if (diagonalLinesWon == wage)
                    {
                        break;
                    }
                    if (vertical[0] == vertical[i])
                    {
                        diagCount++;
                    }
                    if (diagCount == WIN_LINE)
                    {
                        diagonalLinesWon++;
                    }
                }
                diagCount = 0;

                for (int i = 2; i < vertical.Count - 2; i += 2)
                {
                    if (diagonalLinesWon == wage)
                    {
                        break;
                    }
                    if (vertical[2] == vertical[i])
                    {
                        diagCount++;
                    }
                    if (diagCount == WIN_LINE)
                    {
                        diagonalLinesWon++;
                    }
                }
                // vertical 
                int verticalLinesWon = 0;
                int verticalCount = 0;
                for (int i = 0; i < vertical.Count; i += 3)
                {
                    if (verticalLinesWon == wage)
                    {
                        break;
                    }
                    if (vertical[0] == vertical[i])
                    {
                        verticalCount++;
                    }
                    if (verticalCount == WIN_LINE)
                    {
                        verticalLinesWon++;
                    }
                }
                verticalCount = 0;
                for (int i = 1; i < vertical.Count; i += 3)
                {
                    if (verticalLinesWon == wage)
                    {
                        break;
                    }
                    if (vertical[1] == vertical[i])
                    {
                        verticalCount++;
                    }
                    if (verticalCount == WIN_LINE)
                    {
                        verticalLinesWon++;
                    }
                }
                verticalCount = 0;
                for (int i = 2; i < vertical.Count; i += 3)
                {
                    if (verticalLinesWon == wage)
                    {
                        break;
                    }
                    if (vertical[2] == vertical[i])
                    {
                        verticalCount++;
                    }
                    if (verticalCount == WIN_LINE)
                    {
                        verticalLinesWon++;
                    }
                }
                Console.WriteLine($"\nYou have bet ${wage}");

                if (line == 'h')
                {
                    Console.WriteLine(@$"You have {horizontalLinesWon} winning lines.
You have won ${horizontalLinesWon}
Your total is ${horizontalLinesWon + horizontalLinesWon}");
                }
                if (line == 'v')
                {
                    Console.WriteLine(@$"You have {verticalLinesWon} winning lines.
You have won ${verticalLinesWon}
Your total is ${verticalLinesWon + verticalLinesWon}");
                }
                if (line == 'd')
                {
                    Console.WriteLine(@$"You have {diagonalLinesWon} winning lines.
You have won ${diagonalLinesWon}
Your total is ${diagonalLinesWon + diagonalLinesWon}");
                }

                Console.WriteLine("Would you like to play another one?");
                Console.WriteLine("Choose 'y' to continue any other key to exit ");
                question = Console.ReadKey().KeyChar;

                vertical.Clear();
                verticalLinesWon = 0;
                horizontalLinesWon = 0;
                diagonalLinesWon = 0;
                Console.Clear();
            }

        }
    }
}