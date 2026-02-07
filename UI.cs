namespace SlotMachine;

public class UI
{
    public static void WelcomeMessage()
    {
        Console.WriteLine("Welcome to the Slot Machine Game!");
    }

    public static void DisplayRules()
    {
        while (true)
        {
            Console.Write("Are you playing the game for the first time?(Y/N) - ");
            string firstTime = Console.ReadLine().ToLower();
            string rulesOfTheGame = $"""
                                     You enter an amount of money to play. Each spin is ${Constants.COST_PER_SPIN}. 

                                     This is the payout, for each horizontal, vertical and diagonal line,

                                     @ @ @ - ${Constants.AT}
                                     % % % - ${Constants.PERCENT}
                                     £ £ £ - ${Constants.POUND}
                                     $ $ $ = ${Constants.DOLLAR} 

                                     If two lines of the same symbol match then single line payout is doubled.

                                     Jackpot is if all lines have the same symbol,
                                     For Jackpot it is ${Constants.JACKPOT}.

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
    }

    public static int GetBetMoney()
    {
        int betMoney;
        
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

        return betMoney;
    }

    public static void DisplaySlotMachineArray(char[,] slotMachineArray)
    {
        Console.WriteLine();
        for (int i = 0; i < Constants.NUMBER_OF_ROWS; i++)
        {
            for (int j = 0; j < Constants.NUMBER_OF_COLUMNS; j++)
            {
                Console.Write($"{slotMachineArray[i, j]}  ");
            }
            Console.WriteLine();
        }
    }

    public static void PrintHorizontalLineMatchMessage(WIN? matchType)
    {
        if (matchType.Value == WIN.HorizontalLineMatch)
        {
            Console.WriteLine("Horizontal Line Match!");
        }
        else if (matchType.Value == WIN.CenterLineMatch)
        {
            Console.WriteLine($"Center Line Match!");
        }
    }
    
    public static void PrintVerticalLineMatchMessage(WIN? matchType)
    {
        if (matchType.Value == WIN.VerticalLineMatch)
        {
            Console.WriteLine("Vertical Line Match!");
        }
    }
    
    public static void PrintDiagonalLineMatchMessage(WIN? matchType)
    {
        if (matchType.Value == WIN.BothDiagonalsMatch)
        {
            Console.WriteLine($"Both Forward and Backward Diagonals Match!");
        }
        if (matchType.Value == WIN.ForwardDiagonalMatch)
        {
            Console.WriteLine($"Forward Diagonal Match!");
        }
        if (matchType.Value == WIN.BackwardDiagonalMatch)
        {
            Console.WriteLine($"Backward Diagonal Match!");
        }
    }
    
    public static void PrintJackpotMessage(WIN? matchType, int spinWinAmount)
    {
        Console.WriteLine($"$$$ JACKPOT $$$");
        Console.WriteLine($"You have won ${spinWinAmount}");
    }

    public static void PrintTotalWinsThisSpinMessage(int spinWinAmount)
    {
        Console.WriteLine($"Total wins in this spin = ${spinWinAmount}");
    }
    
    public static void PrintOverallWinsMessage(int totalWinAmount)
    {
        Console.WriteLine($"Total wins so far = ${totalWinAmount}");

        Console.WriteLine("Ready for the next spin?");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}