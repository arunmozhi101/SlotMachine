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

    private static int CalculateSpinWinAmount(char matcher, int spinWinAmount)
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

    public static (int amount, int horizontalLineMatches, WIN? match) HorizontalLineMatch(char[,] slotMachineArray, int spinWinAmount)
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
            return (spinWinAmount, horizontalLineMatches, WIN.CenterLineMatch);
        }
        else if (horizontalLineMatches > 0)
        {
            return (spinWinAmount, horizontalLineMatches, WIN.HorizontalLineMatch);
        }

        return (spinWinAmount, horizontalLineMatches, null);

    }

    public static (int amount, int verticalLineMatches, WIN? match) VerticalLineMatch(char[,] slotMachineArray, int spinWinAmount)
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
            return (spinWinAmount, verticalLineMatches, WIN.VerticalLineMatch);
        }
        else
        {
            return (spinWinAmount, verticalLineMatches, null);
        }
    }

    public static (int amount, WIN? match) DiagonalLinesMatch(char[,] slotMachineArray, int spinWinAmount)
    {
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

                if ( i == (Constants.NUMBER_OF_ROWS - (j + 1)) && backwardDiagonalMatcher == slotMachineArray[i, j])
                {   
                    backwardDiagonalMatches++;
                }
            }
        }
        
        if (forwardDiagonalMatcher == Constants.NUMBER_OF_ROWS && backwardDiagonalMatches == Constants.NUMBER_OF_ROWS)
        {
            spinWinAmount = Logic.CalculateSpinWinAmount(forwardDiagonalMatcher, spinWinAmount) +
                            Logic.CalculateSpinWinAmount(backwardDiagonalMatcher, spinWinAmount);
            return (spinWinAmount,  WIN.BothDiagonalsMatch);
        }
        if (forwardDiagonalMatches == Constants.NUMBER_OF_ROWS)
        {
            //Console.WriteLine($"Forward Diagonal Match!");
            spinWinAmount = Logic.CalculateSpinWinAmount(forwardDiagonalMatcher, spinWinAmount);
            return (spinWinAmount, WIN.ForwardDiagonalMatch);
        }
        if (backwardDiagonalMatches == Constants.NUMBER_OF_ROWS)
        {
            //Console.WriteLine($"Backward Diagonal Match!");
            spinWinAmount = Logic.CalculateSpinWinAmount(backwardDiagonalMatcher, spinWinAmount);
            return (spinWinAmount, WIN.BackwardDiagonalMatch);
        }
        return (spinWinAmount, null);
    }

    public static (int amount, WIN? match) CheckJackpot(int horizontalLineMatches, int verticalLineMatches, int spinWinAmount)
    {
        if (horizontalLineMatches == Constants.NUMBER_OF_ROWS || verticalLineMatches == Constants.NUMBER_OF_COLUMNS)
        {
            spinWinAmount = Constants.JACKPOT;
            return (spinWinAmount, WIN.Jackpot);
        }
        else
        {
            return (spinWinAmount, null);
        }
    }
}