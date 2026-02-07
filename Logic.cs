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

    public static (int amount, int horizontalLineMatches, Horizontal? match) HorizontalLineMatch(char[,] slotMachineArray, int spinWinAmount)
    {
        int horizontalLineMatches = 0;
        bool centerLineMatch = false;
        
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

            if (matches == Constants.NUMBER_OF_COLUMNS)
            {
                horizontalLineMatches++;
                if (i == Constants.CENTER_LINE)
                {
                    centerLineMatch = true;
                }

                // Identify the matcher for payout
                spinWinAmount = Logic.CalculateSpinWinAmount(horizontalMatcher, spinWinAmount);
            }
        } //horizontal line match

        if (centerLineMatch)
        {
            return (spinWinAmount, horizontalLineMatches, Horizontal.CenterLineMatch);
        }
        else if (horizontalLineMatches > 0)
        {
            return (spinWinAmount, horizontalLineMatches, Horizontal.LineMatch);
        }

        return (spinWinAmount, horizontalLineMatches, null);

    }

    public static (int amount, int verticalLineMatches, Vertical? match) VerticalLineMatch(char[,] slotMachineArray, int spinWinAmount)
    {
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
                // Identify the matcher for payout
                spinWinAmount = Logic.CalculateSpinWinAmount(verticalMatcher, spinWinAmount);
            }
        }

        if (verticalLineMatches > 0)
        {
            return (spinWinAmount, verticalLineMatches, Vertical.LineMatch);
        }
        else
        {
            return (spinWinAmount, verticalLineMatches, null);
        }
    }
}