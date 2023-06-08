namespace SlotMachine
{
    internal class LogicMethods
    {
        /// <summary>
        /// Checks lines for win
        /// </summary>
        /// <param name="line">Char to check for equality</param>
        /// <param name="list">Enter the list to be checked</param>
        /// <param name="total">Enter the total of the user</param>
        /// <param name="bet">Enter the bet of the user</param>
        /// <param name="winLine">Enter WIN_LINE const</param>
        /// <returns>total</returns>
        public static int ShowResultsFromTheLinesPlayed(char line, int[,] list, int total, int bet, int winLine)
        {
            int profit;
            //horizontal check

            if (line == 'h')
            {
                int horizontalLinesWon = HorizontalCheckForWin(list, winLine);

                total = TotalFunds(total, horizontalLinesWon, bet);

                profit = ProfitCalculation(horizontalLinesWon, bet);

                UiMethods.ShowStats(horizontalLinesWon, total, profit);
            }
            //vertical check

            if (line == 'v')
            {
                int verticalLinesWon = VerticalCheckForWin(list, winLine);

                total = TotalFunds(total, verticalLinesWon, bet);

                profit = ProfitCalculation(verticalLinesWon, bet);

                UiMethods.ShowStats(verticalLinesWon, total, profit);
            }
            //diagonal check

            if (line == 'd')
            {
                int diagonalLinesWon = DiagonalCheckForWin(list, winLine);

                total = TotalFunds(total, diagonalLinesWon, bet);

                profit = ProfitCalculation(diagonalLinesWon, bet);

                UiMethods.ShowStats(diagonalLinesWon, total, profit);
            }
            return total;
        }
        /// <summary>
        /// checks for win lines in horizontal lines
        /// </summary>
        /// <param name="list"></param>
        /// <param name="winLine"></param>
        /// <returns>how many horizontal lines were won</returns>
        public static int HorizontalCheckForWin(int[,] list, int winLine)
        {
            int horizontalLinesWon = 0;
            int horizontalCount = 0;
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
                    }
                }
                horizontalCount = 0;
            }
            return horizontalLinesWon;
        }
        /// <summary>
        /// checks for win lines in vertical lines
        /// </summary>
        /// <param name="list"></param>
        /// <param name="winLine"></param>
        /// <returns>how many vertical lines were won</returns>
        public static int VerticalCheckForWin(int[,] list, int winLine)
        {
            int verticalLinesWon = 0;
            int verticalCount = 0;
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
                    }
                }
                verticalCount = 0;
            }
            return verticalLinesWon;
        }
        /// <summary>
        /// checks for diagonal lines win
        /// </summary>
        /// <param name="list"></param>
        /// <param name="winLine"></param>
        /// <returns>how many diagonaal lines were won</returns>
        public static int DiagonalCheckForWin(int[,] list, int winLine)
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
                if (firstDiagCountLine == winLine)
                {
                    diagonalLinesWon++;
                }
                if (secondDiagonalCountLine == winLine)
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
                    int randomNum = Program.rng.Next(UiMethods.MAX_RANDOM_NUM);
                    list[row, column] = randomNum;
                }
            }
        }
    }
}
