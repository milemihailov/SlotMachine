namespace SlotMachine
{
    internal class ConditionMethods
    {
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
