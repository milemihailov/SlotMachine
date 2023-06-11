namespace SlotMachine
{
    public static class Program
    {
        public static readonly Random rng = new Random();
        public const int GRID = 3;
        public const char PLAY_MORE = 'y';
        public const int MAX_RANDOM_NUM = 2;
        static void Main(string[] args)
        {
            int[,] slotNumbers = new int[GRID, GRID];
            char question = PLAY_MORE;

            UiMethods.ShowWelcomeMessage();

            UiMethods.ShowGuideMessage(UiMethods.Options.Wage);

            int total = UiMethods.WaitForNum();

            while (question == PLAY_MORE)
            {
                UiMethods.ShowFunds(total);

                UiMethods.ShowGuideMessage(UiMethods.Options.Bet);

                int bet = UiMethods.WaitForBet();

                if (bet > total)
                {
                    UiMethods.ShowNotEnoughFunds();
                    continue;
                }
                total -= bet;
                UiMethods.ClearDisplay();

                UiMethods.ShowIntroMessage();

                char line = UiMethods.AskForChar();

                UiMethods.ClearDisplay();

                LogicMethods.PopulateGrid(slotNumbers);

                UiMethods.ShowGrid(slotNumbers);

                UiMethods.ShowUserBet(bet);

                total = LogicMethods.ShowResultsFromTheLinesPlayed(line, slotNumbers, total, bet);

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