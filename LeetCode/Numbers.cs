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

    #region #7 - Reverse - 80%/70% runtime/memory

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
                var valueToCompare = negative ? reversedNumber * -1 : reversedNumber;
                if (valueToCompare > maxIntegerDivided)
                    return 0;
                if(reversedNumber == maxIntegerDivided && x > 7)
                {
                    return 0;
                }
            }

        }

        return reversedNumber;
    }

    #endregion

    #region 50 - Pow(x, n) - 100/72 in second implementation

    public static double MyPow(double x, int n)
    {
        if (x == -1)
        {
            if (n % 2 != 0) { return -1; }
            else { return 1; }
        }
        if (n == 0)
        {
            return 1;
        }

        if (n == 1)
        {
            return x;
        }

        if(x == 0)
        {
            return 0;
        }

        if(x == 1)
        {
            return 1;
        }

        double result = x;

        if(n < 0)
        {
            result = 1 / x;
            x = result;
            n *= -1;
            //value will be less then round amount
            if(n > 50)
            {
                return 0;
            }
        }
        for (int i = 0; i < n - 1; i++)
        {
            result *= x;
        }
        
        return Math.Round(result, 5);
    }

    public static double MyPow2(double x, int n)
    {
        long N = n;
        if (N < 0)
        {
            x = 1 / x;
            N = -N;
        }

        return MyPowReccursive(x, N);
    }

    private static double MyPowReccursive(double x, long n)
    {
        if (n == 0) return 1.0;

        double half = MyPowReccursive(x, n / 2);

        if (n % 2 == 0)
            return half * half;
        else
            return half * half * x;
    }

    #endregion

    #region 69 - Sqrt(x) - 100/60.5 runtime/memory

    public static int MySqrt(int x)
    {
        int maxSqrt = 46340;
        int maxPowResult = 2147395600;

        if (x <= 1)
        {
            return x;
        }

        if(x >= maxPowResult)
        {
            return maxSqrt;
        }

        int leftBorder = 1;
        int rightBorder = maxSqrt;
        int currentTarget;
        while (true)
        {
            currentTarget = (rightBorder + leftBorder) / 2;

            if(currentTarget * currentTarget == x)
            {
                break;
            }

            if (currentTarget * currentTarget < x && ((currentTarget + 1) * (currentTarget + 1)) >= x)
            {
                if ((currentTarget + 1) * (currentTarget + 1) == x)
                {
                    return currentTarget + 1;
                }
                break;
            }

            if(currentTarget * currentTarget < x)
            {
                leftBorder = currentTarget;
            }
            else
            {
                rightBorder = currentTarget;
            }
        }

        return currentTarget;
    }

    #endregion

    #region 70 Climbing Stairs 100/33.5

    // 5: 11111, 2111, 1112, 1211, 1121, 122, 212, 221
    public static int ClimbStairs(int n)
    {
        if(n <= 3)
        {
            return n;
        }

        int previousValue = 2;
        int result = 3;

        for(int i = 3; i < n; i++)
        {
            int tmp = result;
            result += previousValue;
            previousValue = tmp;
        }
        return result;
    }

    #endregion
}
