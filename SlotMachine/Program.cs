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
                    Console.WriteLine("Insufficient funds");
                    continue;
                }
                total -= bet;
                Console.Clear();

                UiMethods.ShorIntroMessage();

                char line = UiMethods.AskForChar();

                Console.Clear();

                UiMethods.PopulateGrid(slotNumbers);

                UiMethods.ShowUserBet(bet);

                total = LinesCheckMethods.LineCheckForWin(line, slotNumbers, total, bet, WIN_LINE);

                if (total == 0)
                {
                    UiMethods.ShowLostMessage();
                    break;
                }
                question = UiMethods.Replay(question);
            }
        }
    }
}