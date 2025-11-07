namespace LeetCodeTasks.LeetCode;

public static class Numbers
{
    #region #9 - IsPalindrome - medium memory and runtime performance

    public static  bool IsPalindrome(int x)
    {
        if(x >= 0 && x < 10) return true;
        if(x < 0) return false;

        int numberLength = 0;
        //x < 2^31
        int[] arrNumber = new int[10];
        while(true)
        {
            arrNumber[numberLength] = x % 10;
            x = x / 10;
            numberLength++;

            if(x == 0)
            {
                break;
            }
        }

        Array.Resize(ref arrNumber, numberLength);

        for(int i = 0; i < numberLength / 2; i++)
        {
            if (arrNumber[i] != arrNumber[numberLength - i - 1])
            {
                return false;
            }
        }

        return true;
    }

    #endregion

    #region #7

    public static int Reverse(int x)
    {
        if(x == 0) return 0;

        bool negative = x < 0;
        //x < 2^31
        int reversedNumber = 0;
        int numberLength = 0;
        while (true)
        {
            reversedNumber = reversedNumber * 10 + x % 10;
            numberLength++;
            x = x / 10;

            if (x == 0)
            {
                break;
            }

            if (numberLength == 9)
            {
                int maxIntegerDivided = 214748364;
                if (reversedNumber > maxIntegerDivided)
                    return 0;
                if(reversedNumber == maxIntegerDivided && x > 7)
                {
                    return 0;
                }
            }

        }

        if(negative)
        {
            reversedNumber *= 1;
        }
        return reversedNumber;
    }

    #endregion
}
