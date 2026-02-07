namespace SlotMachine;

public class Logic
{
    public static char[,] RandomizeSlotMachineArray()
    {
        char[,] randomCharArray = new char[Constants.NUMBER_OF_ROWS, Constants.NUMBER_OF_COLUMNS];;
        
        Random rng = new Random();
        
        for (int i = 0; i < Constants.NUMBER_OF_ROWS; i++)
        {
            for (int j = 0; j < Constants.NUMBER_OF_COLUMNS; j++)
            {
                int randomNumber = rng.Next(0, Constants.symbolsList.Length);
                randomCharArray[i, j] = Constants.symbolsList[randomNumber];
            }
        }
        
        return randomCharArray;
    }

    public static int CalculateSpinWinAmount(char matcher, int spinWinAmount)
    {
        switch (matcher)
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
        
        return spinWinAmount;
    }
}