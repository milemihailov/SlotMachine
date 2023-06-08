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

            UiMethods.WelcomeMessage();

            UiMethods.GuideThroughGame(UiMethods.Options.Wage);

            int total = ConditionMethods.WaitForNum();

            while (question == 'y')
            {
                UiMethods.Funds(total);

                UiMethods.GuideThroughGame(UiMethods.Options.Bet);

                int bet = ConditionMethods.WaitForBet();

                if (bet > total)
                {
                    Console.WriteLine("Insufficient funds");
                    continue;
                }
                total -= bet;
                Console.Clear();

                char line = UiMethods.IntroToTheGame();
                Console.Clear();

                UiMethods.PopulateGrid(slotNumbers);

                UiMethods.UserBet(bet);

                total = LinesCheckMethods.LineCheckForWin(line, slotNumbers, total, bet, WIN_LINE);

                if (total == 0)
                {
                    UiMethods.LostMessage();
                    break;
                }
                question = UiMethods.Replay(question);
            }
        }
    }
}