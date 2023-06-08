namespace SlotMachine
{
    public static class Program
    {
        public const int GRID = 3;
        const int WIN_LINE = 3;
        static void Main(string[] args)
        {
            int[,] slotNumbers = new int[GRID, GRID];
            char question = 'y';

            UiMethods.ShowWelcomeMessage();

            UiMethods.ShowGuideMessage(UiMethods.Options.Wage);

            int total = ConditionMethods.WaitForNum();

            while (question == 'y')
            {
                UiMethods.ShowFunds(total);

                UiMethods.ShowGuideMessage(UiMethods.Options.Bet);

                int bet = ConditionMethods.WaitForBet();

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

                UiMethods.PopulateGrid(slotNumbers);

                UiMethods.ShowUserBet(bet);

                total = LinesCheckMethods.LineCheckForWin(line, slotNumbers, total, bet, WIN_LINE);

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