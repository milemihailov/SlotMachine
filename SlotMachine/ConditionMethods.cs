using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SlotMachine
{
    internal class ConditionMethods
    {
        public static void GameLost(int total)
        {
            if (total == 0)
            {
                UiMethods.LostMessage();
            }
        }
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
                    UiMethods.GuideThroughGame(UiMethods.Options.Number);
                }
            }
            return bet;
        }
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
                    UiMethods.GuideThroughGame(UiMethods.Options.Number);
                }
            }
            return wage;
        }
    }
}
