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
}