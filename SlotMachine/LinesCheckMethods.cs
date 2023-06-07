using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SlotMachine
{
    internal class LinesCheckMethods
    {
        const int GRID = 3;
        /// <summary>
        /// Checks lines for win
        /// </summary>
        /// <param name="line">Char to check for equality</param>
        /// <param name="list">Enter the list to be checked</param>
        /// <param name="total">Enter the total of the user</param>
        /// <param name="bet">Enter the bet of the user</param>
        /// <param name="winLine">Enter WIN_LINE const</param>
        /// <returns>total</returns>
        public static int LineCheckForWin(char line, int[,] list, int total, int bet, int winLine)
        {
            int horizontalLinesWon = 0;
            int horizontalCount = 0;
            if (line == 'h')
            {
                for (int row = 0; row < list.GetLength(0); row++)
                {
                    for (int column = 0; column < list.GetLength(1); column++)
                    {
                        if (list[row, 0] == list[row, column])
                        {
                            horizontalCount++;
                        }
                        if (horizontalCount == winLine)
                        {
                            horizontalLinesWon++;
                            total += (horizontalLinesWon * bet);
                        }
                    }
                    horizontalCount = 0;
                }
                UiMethods.DisplayStats(horizontalLinesWon, total, bet);
            }
            int verticalLinesWon = 0;
            int verticalCount = 0;
            if (line == 'v')
            {
                for (int row = 0; row < list.GetLength(0); row++)
                {
                    for (int column = 0; column < list.GetLength(1); column++)
                    {
                        if (list[0, row] == list[column, row])
                        {
                            verticalCount++;
                        }
                        if (verticalCount == winLine)
                        {
                            verticalLinesWon++;
                            total += (verticalLinesWon * bet);
                        }
                    }
                    verticalCount = 0;
                }
                UiMethods.DisplayStats(verticalLinesWon, total, bet);
            }
            int diagonalLinesWon = 0;
            int firstDiagCountLine = 0;
            int secondDiagonalCountLine = 0;
            if (line == 'd')
            {
                int column = GRID - 1;
                for (int row = 0; row < list.GetLength(0); row++)
                {
                    if (list[0, 0] == list[row, row])
                    {
                        firstDiagCountLine++;
                    }
                    if (list[0, GRID - 1] == list[row, column])
                    {
                        secondDiagonalCountLine++;
                    }
                    if (firstDiagCountLine == winLine)
                    {
                        diagonalLinesWon++;
                        total += (diagonalLinesWon * bet);
                    }
                    if (secondDiagonalCountLine == winLine)
                    {
                        diagonalLinesWon++;
                        total += (diagonalLinesWon * bet);
                    }
                    column--;
                }
                UiMethods.DisplayStats(diagonalLinesWon, total, bet);
            }
            return total;
        }
    }
}
