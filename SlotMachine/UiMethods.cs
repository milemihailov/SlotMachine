namespace SlotMachine
{
    public static class UiMethods
    {
        public const int MAX_RANDOM_NUM = 2;
        public enum Options
        {
            Bet,
            Wage,
            Number
        }
        /// <summary>
        /// It is a welcome message to the game also explains the rules.
        /// </summary>
        public static void ShowWelcomeMessage()
        {
            Console.WriteLine("Hello you can choose to play 'Horizontal', 'Vertical' and 'Diagonal' lines.");
            Console.WriteLine($"You can play 1 line for $1 and up to ${Program.GRID} and up to {Program.GRID} lines for 'Horizontal' and 'Vertical' up to 2 lines for 'Diagonal'");
            Console.WriteLine("Choose your wager and lines to play!");
        }
        /// <summary>
        /// Asks the user what lines to play.
        /// </summary>
        public static void ShowIntroMessage()
        {
            Console.WriteLine("Choose which lines to play");
            Console.WriteLine("'h' for 'Horizontal', 'v' for 'Vertical', 'd' for 'Diagonal'");
        }
        /// <summary>
        /// Asks the user to enter a char value
        /// </summary>
        /// <returns>returns the character entered</returns>
        public static char AskForChar()
        {
            char value = Console.ReadKey().KeyChar;
            return value;
        }
        /// <summary>
        /// Displays 3x3 grid from 2D Array
        /// </summary>
        /// <param name="list">2D Array</param>
        public static void ShowGrid(int[,] list)
        {
            for (int row = 0; row < list.GetLength(0); row++)
            {
                for (int column = 0; column < list.GetLength(1); column++)
                {
                    Console.Write($"{list[row, column]}   ");
                }
                Console.WriteLine("\n");
            }
        }
        /// <summary>
        /// Informs the user of how much he bets.
        /// </summary>
        /// <param name="bet">Enter the bet of the user:</param>
        public static void ShowUserBet(int bet)
        {
            Console.WriteLine($"\nYou have bet ${bet}");
        }
        /// <summary>
        /// It is displaying the outcome of the game if user won or lost and how much.
        /// </summary>
        /// <param name="linesWon">Enter the lines won:</param>
        /// <param name="total">Enter the total funds:</param>
        /// <param name="bet">Enter the user's bet</param>
        public static void DisplayStats(int linesWon, int total, int bet)
        {
            Console.WriteLine($"You have {linesWon} winning lines.");
            Console.WriteLine($"You have won ${linesWon * bet}");
            Console.WriteLine($"Your total is ${total}");
        }
        /// <summary>
        /// Asks if the user wants to play more.
        /// </summary>
        public static void ShowReplayMessage()
        {
            Console.WriteLine("Would you like to play another one?");
            Console.WriteLine("Choose 'y' to continue any other key to exit ");
        }
        /// <summary>
        /// takes input from user
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        public static char AskToReplay()
        {
            char question = Console.ReadKey().KeyChar;
            Console.Clear();
            return question;
        }
        /// <summary>
        /// Informs the user he lost and exits the game.
        /// </summary>
        public static void ShowLostMessage()
        {
            Console.WriteLine("You lost!");
        }
        /// <summary>
        /// Guides the user what to enter:
        /// </summary>
        /// <param name="mode"></param>
        public static void ShowGuideMessage(Options mode)
        {
            switch (mode)
            {
                case Options.Number:
                    Console.WriteLine("Enter a number: ");
                    break;
                case Options.Bet:
                    Console.WriteLine("Enter your bet: ");
                    break;
                case Options.Wage:
                    Console.WriteLine("Enter your wage: ");
                    break;
            }
        }
        /// <summary>
        /// Informs the user of his total funds
        /// </summary>
        /// <param name="total">Total funds of the user</param>
        public static void ShowFunds(int total)
        {
            Console.WriteLine($"Your total is: {total}");
        }
        public static void ShowNotEnoughFunds()
        {
            Console.WriteLine("Insufficient funds");
        }
        public static void ClearDisplay()
        {
            Console.Clear();
        }
        /// <summary>
        /// Wait for the user to enter hes bet
        /// </summary>
        /// <returns>Bet</returns>
        public static int WaitForBet()
        {
            bool waitForBet = false;
            int bet = 0;
            while (!waitForBet)
            {
                string inputBetNum = Console.ReadLine();
                waitForBet = int.TryParse(inputBetNum, out bet);
                if (!waitForBet)
                {
                    UiMethods.ShowGuideMessage(UiMethods.Options.Number);
                }
            }
            return bet;
        }
        /// <summary>
        /// Wait for the user to enter wage
        /// </summary>
        /// <returns>wage</returns>
        public static int WaitForNum()
        {
            int wage = 0;
            bool numEntered = false;
            while (!numEntered)
            {
                string inputWageNum = Console.ReadLine();
                numEntered = int.TryParse(inputWageNum, out wage);
                if (!numEntered)
                {
                    UiMethods.ShowGuideMessage(UiMethods.Options.Number);
                }
            }
            return wage;
        }
    }
}