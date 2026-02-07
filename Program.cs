namespace SlotMachine
{
    class SlotMachineClass
    {
        static void Main(string[] args)
        {
            int betMoney = 0;
            int totalWinAmount = 0;

            Random rng = new Random();

            UI.WelcomeMessage();
            UI.DisplayRules();

            betMoney = UI.GetBetMoney();
            
            int numberOfSpins = betMoney * Constants.COST_PER_SPIN;
            char[,] slotMachineArray = new char[Constants.NUMBER_OF_ROWS, Constants.NUMBER_OF_COLUMNS];

            for (int spin = 1; spin <= numberOfSpins; spin++)
            {
                WIN? match = null;
                int spinWinAmount = 0;

                slotMachineArray = Logic.RandomizeSlotMachineArray();
                UI.DisplaySlotMachineArray(slotMachineArray);
                
                (spinWinAmount, int horizontalLineMatches, match) = Logic.HorizontalLineMatch(slotMachineArray, spinWinAmount);
                if (match.HasValue)
                {
                    UI.PrintHorizontalLineMatchMessage(match);
                }
                
                (spinWinAmount, int verticalLineMatches, match) = Logic.VerticalLineMatch(slotMachineArray, spinWinAmount);
                if (match.HasValue)
                {
                    UI.PrintVerticalLineMatchMessage(match);
                }
                
                (spinWinAmount, match) = Logic.DiagonalLinesMatch(slotMachineArray, spinWinAmount);
                if (match.HasValue)
                {
                    UI.PrintDiagonalLineMatchMessage(match);
                }
                
                (spinWinAmount, match) = Logic.CheckJackpot(horizontalLineMatches, verticalLineMatches, spinWinAmount);
                if (match.HasValue)
                {
                    UI.PrintJackpotMessage(match, spinWinAmount);
                }

                UI.PrintTotalWinsThisSpinMessage(spinWinAmount);
                
                totalWinAmount += spinWinAmount;
                UI.PrintOverallWinsMessage(totalWinAmount);
            }
            //End of spin for loop
        }
    }
}