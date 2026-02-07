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

            //Display rules
            UI.DisplayRules();

            //Bet Money
            betMoney = UI.GetBetMoney();

            //Print how many spins the user has and build the slot machine array
            //Create symbols list and randomize the array
            //Print player wins.
            int numberOfSpins = betMoney * Constants.COST_PER_SPIN;
            char[,] slotMachineArray = new char[Constants.NUMBER_OF_ROWS, Constants.NUMBER_OF_COLUMNS];

            for (int spin = 1; spin <= numberOfSpins; spin++)
            {
                int spinWinAmount = 0;

                slotMachineArray = Logic.RandomizeSlotMachineArray();
                UI.DisplaySlotMachineArray(slotMachineArray);

                //How much did the player win?
                //horizontal lines check
                //string matcher = slotMachineArray[0,0];
                
                (spinWinAmount, int horizontalLineMatches, var horizontalMatchType) = Logic.HorizontalLineMatch(slotMachineArray, spinWinAmount);
                if (horizontalMatchType.HasValue)
                {
                    UI.PrintHorizontalLineMatchMessage(horizontalMatchType);
                }
                
                (spinWinAmount, int verticalLineMatches, var verticalMatchType) = Logic.VerticalLineMatch(slotMachineArray, spinWinAmount);
                if (verticalMatchType.HasValue)
                {
                    UI.PrintVerticalLineMatchMessage(verticalMatchType);
                }
                
                /*int diagonalLineMatch = 0;*/

                //diagonal lines check
                int forwardDiagonalMatches = 0;
                char forwardDiagonalMatcher = slotMachineArray[0, 0];
                int backwardDiagonalMatches = 0;
                char backwardDiagonalMatcher = slotMachineArray[0, Constants.NUMBER_OF_COLUMNS - 1];
                for (int i = 0; i < Constants.NUMBER_OF_ROWS; i++)
                {
                    for (int j = 0; j < Constants.NUMBER_OF_COLUMNS; j++)
                    {
                        if (i == j && forwardDiagonalMatcher ==  slotMachineArray[i, j])
                        {
                            forwardDiagonalMatches++;
                        }

                        if ( i == (Constants.NUMBER_OF_ROWS - (j + 1)) &&
                             backwardDiagonalMatcher == slotMachineArray[i, j])
                        {   
                            backwardDiagonalMatches++;
                        }
                    }
                }

                if (forwardDiagonalMatches == Constants.NUMBER_OF_ROWS)
                {
                    Console.WriteLine($"Forward Diagonal Match!");
                    spinWinAmount = Logic.CalculateSpinWinAmount(forwardDiagonalMatcher, spinWinAmount);
                }
                if (backwardDiagonalMatches == Constants.NUMBER_OF_ROWS)
                {
                    Console.WriteLine($"Backward Diagonal Match!");
                    spinWinAmount = Logic.CalculateSpinWinAmount(backwardDiagonalMatcher, spinWinAmount);
                }

                if (horizontalLineMatches == Constants.NUMBER_OF_ROWS || verticalLineMatches == Constants.NUMBER_OF_COLUMNS)
                {
                    Console.WriteLine($"$$$ JACKPOT $$$");
                    spinWinAmount = Constants.JACKPOT;
                    Console.WriteLine($"You have won ${spinWinAmount}");
                }
                else
                {
                    Console.WriteLine($"Total wins in this spin = ${spinWinAmount}");
                }
                
                totalWinAmount += spinWinAmount;
                Console.WriteLine($"Total wins so far = ${totalWinAmount}");

                Console.WriteLine("Ready for the next spin?");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            //End of spin for loop
        }
    }
}