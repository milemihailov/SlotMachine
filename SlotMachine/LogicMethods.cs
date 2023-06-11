namespace SlotMachine
{
    internal class LogicMethods
    {
        public const char HORIZONTAL_LINE = 'h';
        public const char VERTICAL_LINE = 'v';
        public const char DIAGONAL_LINE = 'd';
        public const int WIN_LINE = 3;
        /// <summary>
        /// Checks lines for win
        /// </summary>
        /// <param name="line">Char to check for equality</param>
        /// <param name="slotNumbers">Enter the list to be checked</param>
        /// <param name="total">Enter the total of the user</param>
        /// <param name="bet">Enter the bet of the user</param>
        /// <param name="winLine">Enter WIN_LINE const</param>
        /// <returns>total</returns>
        public static int ShowResultsFromTheLinesPlayed(char line, int[,] slotNumbers, int total, int bet)
        {
            int linesWon = 0;
            int profit;
            //horizontal and vertical check

            if (line == HORIZONTAL_LINE || line == VERTICAL_LINE)
            {
                linesWon = CheckForWin(slotNumbers, line);
            }
            //diagonal check

            if (line == DIAGONAL_LINE)
            {
                linesWon = DiagonalCheckForWin(slotNumbers);
            }

            total = TotalFunds(total, linesWon, bet);

            profit = ProfitCalculation(linesWon, bet);

            UiMethods.ShowStats(linesWon, total, profit);

            return total;
        }
        /// <summary>
        /// checks for win lines in horizontal lines
        /// </summary>
        /// <param name="list"></param>
        /// <param name="winLine"></param>
        /// <returns>how many horizontal lines were won</returns>
        public static int CheckForWin(int[,] list, char line)
        {
            int linesWon = 0;
            int count = 0;
            for (int row = 0; row < list.GetLength(0); row++)
            {
                for (int column = 0; column < list.GetLength(1); column++)
                {
                    if (line == VERTICAL_LINE && list[0, row] == list[column, row])
                    {
                        count++;
                    }
                    if (line == HORIZONTAL_LINE && list[row, 0] == list[row, column])
                    {
                        count++;
                    }
                    if (count == WIN_LINE)
                    {
                        linesWon++;
                    }
                }
                count = 0;
            }
            return linesWon;
        }
        /// <summary>
        /// checks for diagonal lines win
        /// </summary>
        /// <param name="list"></param>
        /// <param name="winLine"></param>
        /// <returns>how many diagonaal lines were won</returns>
        public static int DiagonalCheckForWin(int[,] list)
        {
            int diagonalLinesWon = 0;
            int firstDiagCountLine = 0;
            int secondDiagonalCountLine = 0;
            int column = Program.GRID - 1;
            for (int row = 0; row < list.GetLength(0); row++)
            {
                if (list[0, 0] == list[row, row])
                {
                    firstDiagCountLine++;
                }
                if (list[0, Program.GRID - 1] == list[row, column])
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
            return diagonalLinesWon;
        }
        /// <summary>
        /// Calculates the total of your funds
        /// </summary>
        /// <param name="total"></param>
        /// <param name="linesWon"></param>
        /// <param name="bet"></param>
        /// <returns>total funds </returns>
        public static int TotalFunds(int total, int linesWon, int bet)
        {
            if (linesWon > 0)
            {
                total += bet;
            }
            return total += (linesWon * bet);
        }
        /// <summary>
        /// Calculates the profit from the lines won
        /// </summary>
        /// <param name="linesWon"></param>
        /// <param name="bet"></param>
        /// <returns> profit made </returns>
        public static int ProfitCalculation(int linesWon, int bet)
        {
            return linesWon * bet;
        }
        /// <summary>
        /// Makes a grid 3x3 from 2D array
        /// </summary>
        /// <param name="list">2D array</param>
        public static void PopulateGrid(int[,] list)
        {
            for (int row = 0; row < list.GetLength(0); row++)
            {
                for (int column = 0; column < list.GetLength(1); column++)
                {
                    int randomNum = Program.rng.Next(Program.MAX_RANDOM_NUM);
                    list[row, column] = randomNum;
                }
            }
        }
    }
}
