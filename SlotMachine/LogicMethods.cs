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
        public static int LinesWon(char line, int[,] slotNumbers)
        {
            int linesWon = 0;

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
            return linesWon;
        }


        /// <summary>
        /// checks for win lines in horizontal lines
        /// </summary>
        /// <param name="slotNumbers"></param>
        /// <param name="winLine"></param>
        /// <returns>how many horizontal lines were won</returns>
        public static int CheckForWin(int[,] slotNumbers, char line)
        {
            int linesWon = 0;
            int count = 0;
            for (int row = 0; row < slotNumbers.GetLength(0); row++)
            {
                for (int column = 0; column < slotNumbers.GetLength(1); column++)
                {
                    if (line == VERTICAL_LINE && slotNumbers[0, row] == slotNumbers[column, row])
                    {
                        count++;
                    }
                    if (line == HORIZONTAL_LINE && slotNumbers[row, 0] == slotNumbers[row, column])
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
        /// <param name="slotNumbers"></param>
        /// <param name="winLine"></param>
        /// <returns>how many diagonaal lines were won</returns>
        public static int DiagonalCheckForWin(int[,] slotNumbers)
        {
            int diagonalLinesWon = 0;
            int firstDiagCountLine = 0;
            int secondDiagonalCountLine = 0;
            int column = Program.GRID - 1;
            for (int row = 0; row < slotNumbers.GetLength(0); row++)
            {
                if (slotNumbers[0, 0] == slotNumbers[row, row])
                {
                    firstDiagCountLine++;
                }
                if (slotNumbers[0, Program.GRID - 1] == slotNumbers[row, column])
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
        public static int CalculateTotalFunds(int total, int linesWon, int bet)
        {
            // checks to see if user won any lines if so returns the bet plus the total
            if (linesWon > 0)
            {
                total += bet;
            }
            return total + linesWon * bet;
        }


        /// <summary>
        /// Calculates the profit from the lines won
        /// </summary>
        /// <param name="linesWon"></param>
        /// <param name="bet"></param>
        /// <returns> profit made </returns>
        public static int CalculateProfit(int linesWon, int bet)
        {
            return linesWon * bet;
        }


        /// <summary>
        /// Makes a grid 3x3 from 2D array
        /// </summary>
        /// <param name="slotNumbers">2D array</param>
        public static void PopulateGrid(int[,] slotNumbers)
        {
            for (int row = 0; row < slotNumbers.GetLength(0); row++)
            {
                for (int column = 0; column < slotNumbers.GetLength(1); column++)
                {
                    int randomNum = Program.rng.Next(Program.MAX_RANDOM_NUM + 1);
                    slotNumbers[row, column] = randomNum;
                }
            }
        }
    }
}
