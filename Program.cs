namespace SlotMachine
{
    class SlotMachineClass
    {
        static void Main(string[] args)
        {
            int money = 0;

            Console.WriteLine("Welcome to the Slot Machine Game!");
            while (true)
            {
                Console.Write("Are you playing the game for the first time?(Y/N) - ");
                string firstTime = Console.ReadLine().ToLower();
                string rulesOfTheGame = """
                                        You enter an amount of money to play. Each spin is $1. 

                                        This is the payout, for each horizontal, vertical and diagonal line,

                                        @ @ @ - $2
                                        % % % - $4
                                        £ £ £ - $8
                                        $ $ $ = $10 

                                        If two or three lines of the same symbol match then single line payout is multiplied by the number of lines of match.

                                        Jackpot is if all lines have the same symbol,
                                        For Jackpot it is $100.
                                        
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
            

            while (true)
            {
                Console.Write("How much money would you like to wager? $");
                string unparsedMoneyInput = Console.ReadLine();

                if (int.TryParse(unparsedMoneyInput, out money))
                {
                    Console.WriteLine($"So you wanna bet ${money}?");
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
        }
    }
}