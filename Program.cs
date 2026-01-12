namespace SlotMachine
{
    class SlotMachineClass
    {
        static void Main(string[] args)
        {
            const int NUMBER_OF_ROWS = 3;
            const int NUMBER_OF_COLUMNS = 3;
            const int JACKPOT = 100;
            const int AT = 2;
            const int PERCENT = 4;
            const int POUND = 8;
            const int DOLLAR = 10;
            const int THREE_MATCHES = 3;
            const int CENTER_LINE = 1;
            const int COST_PER_SPIN = 1;

            int betMoney = 0;
            int totalWinAmount = 0;

            Random rng = new Random();

            Console.WriteLine("Welcome to the Slot Machine Game!");

            //Display rules
            while (true)
            {
                Console.Write("Are you playing the game for the first time?(Y/N) - ");
                string firstTime = Console.ReadLine().ToLower();
                string rulesOfTheGame = $"""
                                         You enter an amount of money to play. Each spin is ${COST_PER_SPIN}. 

                                         This is the payout, for each horizontal, vertical and diagonal line,

                                         @ @ @ - ${AT}
                                         % % % - ${PERCENT}
                                         £ £ £ - ${POUND}
                                         $ $ $ = ${DOLLAR} 

                                         If two lines of the same symbol match then single line payout is doubled.

                                         Jackpot is if all lines have the same symbol,
                                         For Jackpot it is ${JACKPOT}.

                                         """;
                if (firstTime == "y")
                {
                    Console.Write(rulesOfTheGame);
                    break;
                }
                else if (firstTime == "n")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Error: Incorrect input. Please enter Y or y for Yes and N or n for No.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    Console.Clear();
                }
            }

            //Bet Money
            while (true)
            {
                Console.Write("How much money would you like to wager? $");
                string unparsedMoneyInput = Console.ReadLine();

                if (int.TryParse(unparsedMoneyInput, out betMoney))
                {
                    Console.WriteLine($"So you wanna bet ${betMoney}?");
                    Console.WriteLine("Excellent!");
                    Console.WriteLine("Let's play!");
                    break;
                }
                else
                {
                    Console.WriteLine("Error: Incorrect input for money. Please try again.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    Console.Clear();
                }
            }


            //Print how many spins the user has and build the slot machine array
            //Create symbols list and randomize the array
            //Print player wins.
            int numberOfSpins = betMoney * COST_PER_SPIN;
            char[] symbolsList = { '@', '£', '$', '%' };
            
            for (int spin = 1; spin <= numberOfSpins; spin++)
            {
                int spinWinAmount = 0;
                Console.Write($"You have {numberOfSpins} spins left.");
                //Building the SlotMachine array.
                char[,] slotMachineArray = new char[3, 3];
                int randomNumber; 

                Console.WriteLine();
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        randomNumber = rng.Next(0, 4);
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
                for (int i = 0; i < 3; i++)
                {
                    int matches = 0;
                    char horizontalMatcher = slotMachineArray[i, 0];

                    for (int j = 0; j < 3; j++)
                    {
                        if (horizontalMatcher == slotMachineArray[i, j])
                        {
                            matches++;
                        }
                    }

                    if (matches == THREE_MATCHES)
                    {
                        horizontalLineMatches++;
                        Console.WriteLine("Horizontal Line Match!");
                        if (i == CENTER_LINE)
                        {
                            Console.WriteLine($"Center Line Match!");
                        }

                        // Identify the matcher for payout
                        switch (horizontalMatcher)
                        {
                            case '@':
                                spinWinAmount += AT;
                                break;
                            case '%':
                                spinWinAmount += PERCENT;
                                break;
                            case '£':
                                spinWinAmount += POUND;
                                break;
                            case '$':
                                spinWinAmount += DOLLAR;
                                break;
                        }
                    }
                } //horizontal line match

                //vertical line match
                int verticalLineMatches = 0;
                for (int j = 0; j < 3; j++)
                {
                    int matches = 0;
                    char verticalMatcher = slotMachineArray[0, j];

                    for (int i = 0; i < 3; i++)
                    {
                        if (verticalMatcher == slotMachineArray[i, j])
                        {
                            matches++;
                        }
                    }

                    if (matches == THREE_MATCHES)
                    {
                        Console.WriteLine("Vertical Line Match!");
                        // Identify the matcher for payout
                        switch (verticalMatcher)
                        {
                            case '@':
                                spinWinAmount += AT;
                                break;
                            case '%':
                                spinWinAmount += PERCENT;
                                break;
                            case '£':
                                spinWinAmount += POUND;
                                break;
                            case '$':
                                spinWinAmount += DOLLAR;
                                break;
                        }
                    }
                } //vertical line match

                //diagonal lines check
                char diagonalMatcher1 = slotMachineArray[0, 0];
                if (slotMachineArray[0, 0] == slotMachineArray[1, 1] && slotMachineArray[0, 0] == slotMachineArray[2, 2])
                {
                    Console.WriteLine($"Backward Diagonal Match!");
                    switch (diagonalMatcher1)
                    {
                        case '@':
                            spinWinAmount += AT;
                            break;
                        case '%':
                            spinWinAmount += PERCENT;
                            break;
                        case '£':
                            spinWinAmount += POUND;
                            break;
                        case '$':
                            spinWinAmount += DOLLAR;
                            break;
                    }
                }

                char diagonalMatcher2 = slotMachineArray[0, 2];
                if (slotMachineArray[0, 2] == slotMachineArray[1, 2] && slotMachineArray[0, 2] == slotMachineArray[2, 0])
                {
                    Console.WriteLine($"Forward Diagonal Match!");
                    switch (diagonalMatcher2)
                    {
                        case '@':
                            spinWinAmount += AT;
                            break;
                        case '%':
                            spinWinAmount += PERCENT;
                            break;
                        case '£':
                            spinWinAmount += POUND;
                            break;
                        case '$':
                            spinWinAmount += DOLLAR;
                            break;
                    }
                }

                if (horizontalLineMatches == NUMBER_OF_ROWS || verticalLineMatches == NUMBER_OF_COLUMNS)
                {
                    Console.WriteLine($"$$$ JACKPOT $$$");
                    spinWinAmount = JACKPOT;
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
        }
    }
}