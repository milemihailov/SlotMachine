namespace SlotMachine
{
    public static class Program
    {
        public static readonly Random rng = new Random();
        public const int GRID = 3;
        public const int MAX_RANDOM_NUM = 1;
        public const char PLAY_MORE = 'y';

        static void Main(string[] args)
        {
            int[,] slotNumbers = new int[GRID, GRID];

            UiMethods.ShowWelcomeMessage();
            UiMethods.ShowGuideMessage(UiMethods.Options.Wage);

            int total = UiMethods.AskForNum();

            char question = PLAY_MORE;
            while (question == PLAY_MORE)
            {
                UiMethods.ShowFunds(total);
                UiMethods.ShowGuideMessage(UiMethods.Options.Bet);

                int bet = UiMethods.AskForNum();
                if (bet > total)
                {
                    UiMethods.ShowNotEnoughFunds();
                    continue;
                }
                total -= bet;

                UiMethods.ClearDisplay();
                UiMethods.ShowIntroMessage();

                char line = UiMethods.AskForChar();

                LogicMethods.PopulateGrid(slotNumbers);

                UiMethods.ClearDisplay();
                UiMethods.ShowGrid(slotNumbers);
                UiMethods.ShowUserBet(bet);

                int linesWon = LogicMethods.LinesWon(line, slotNumbers);
                total = LogicMethods.CalculateTotalFunds(total, linesWon, bet);
                int profit = LogicMethods.CalculateProfit(linesWon, bet);

                UiMethods.ShowStats(profit, total);

                if (total == 0)
                {
                    UiMethods.ShowLostMessage();
                    break;
                }
                UiMethods.ShowReplayMessage();

                question = UiMethods.AskToReplay();
            }
        }
    }
}