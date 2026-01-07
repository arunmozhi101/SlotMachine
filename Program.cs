

namespace SlotMachine
{
    class SlotMachineClass
    {
        static void Main(string[] args)
        {
            int money = 0;

            while (true)
            {
                Console.WriteLine("Welcome to the Slot Machine Game!");
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