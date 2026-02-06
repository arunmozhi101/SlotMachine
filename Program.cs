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
            int betMoney = UI.GetBetMoney();

            //Print how many spins the user has and build the slot machine array
            //Create symbols list and randomize the array
            //Print player wins.
            int numberOfSpins = betMoney * Constants.COST_PER_SPIN;
            char[] symbolsList = { '@', '£', '$', '%' };
            char[,] slotMachineArray = new char[Constants.NUMBER_OF_ROWS, Constants.NUMBER_OF_COLUMNS];

            for (int spin = 1; spin <= numberOfSpins; spin++)
            {
                int spinWinAmount = 0;
                int randomNumber;
                
                Console.WriteLine();
                for (int i = 0; i < Constants.NUMBER_OF_ROWS; i++)
                {
                    for (int j = 0; j < Constants.NUMBER_OF_COLUMNS; j++)
                    {
                        randomNumber = rng.Next(0, symbolsList.Length);
                        slotMachineArray[i, j] = symbolsList[randomNumber];
                        Console.Write($"{slotMachineArray[i, j]}  ");
                    }
                    Console.WriteLine();
                }

                //How much did the player win?
                //horizontal lines check
                //string matcher = slotMachineArray[0,0];
                int horizontalLineMatches = 0;
                int centerLineMatch = 0;
                int diagonalLineMatch = 0;

                //horizontal line match
                for (int i = 0; i < Constants.NUMBER_OF_ROWS; i++)
                {
                    int matches = 0;
                    char horizontalMatcher = slotMachineArray[i, 0];

                    for (int j = 0; j < Constants.NUMBER_OF_COLUMNS; j++)
                    {
                        if (horizontalMatcher == slotMachineArray[i, j])
                        {
                            matches++;
                        }
                    }

                    if (matches == Constants.NUMBER_OF_ROWS)
                    {
                        horizontalLineMatches++;
                        Console.WriteLine("Horizontal Line Match!");
                        if (i == Constants.CENTER_LINE)
                        {
                            Console.WriteLine($"Center Line Match!");
                        }

                        // Identify the matcher for payout
                        switch (horizontalMatcher)
                        {
                            case '@':
                                spinWinAmount += Constants.AT;
                                break;
                            case '%':
                                spinWinAmount += Constants.PERCENT;
                                break;
                            case '£':
                                spinWinAmount += Constants.POUND;
                                break;
                            case '$':
                                spinWinAmount += Constants.DOLLAR;
                                break;
                        }
                    }
                } //horizontal line match

                //vertical line match
                int verticalLineMatches = 0;
                for (int j = 0; j < Constants.NUMBER_OF_COLUMNS; j++)
                {
                    int matches = 0;
                    char verticalMatcher = slotMachineArray[0, j];

                    for (int i = 0; i < Constants.NUMBER_OF_ROWS; i++)
                    {
                        if (verticalMatcher == slotMachineArray[i, j])
                        {
                            matches++;
                        }
                    }

                    if (matches == Constants.NUMBER_OF_COLUMNS)
                    {
                        verticalLineMatches++;
                        Console.WriteLine("Vertical Line Match!");
                        // Identify the matcher for payout
                        switch (verticalMatcher)
                        {
                            case '@':
                                spinWinAmount += Constants.AT;
                                break;
                            case '%':
                                spinWinAmount += Constants.PERCENT;
                                break;
                            case '£':
                                spinWinAmount += Constants.POUND;
                                break;
                            case '$':
                                spinWinAmount += Constants.DOLLAR;
                                break;
                        }
                    }
                } //vertical line match

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
                    switch (forwardDiagonalMatcher)
                    {
                        case '@':
                            spinWinAmount += Constants.AT;
                            break;
                        case '%':
                            spinWinAmount += Constants.PERCENT;
                            break;
                        case '£':
                            spinWinAmount += Constants.POUND;
                            break;
                        case '$':
                            spinWinAmount += Constants.DOLLAR;
                            break;
                    }
                }
                if (backwardDiagonalMatches == Constants.NUMBER_OF_ROWS)
                {
                    Console.WriteLine($"Backward Diagonal Match!");
                    switch (backwardDiagonalMatcher)
                    {
                        case '@':
                            spinWinAmount += Constants.AT;
                            break;
                        case '%':
                            spinWinAmount += Constants.PERCENT;
                            break;
                        case '£':
                            spinWinAmount += Constants.POUND;
                            break;
                        case '$':
                            spinWinAmount += Constants.DOLLAR;
                            break;
                    }
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