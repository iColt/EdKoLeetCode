using EdkoSKD.Common.Helpers;
using System.Numerics;
using System.Text;

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

    #region 38 - Count and Say - 8/30

    public static string CountAndSay(int n)
    {
        StringBuilder sb = new StringBuilder("1");

        for (int i = 1; i < n; i++)
        {
            var parsedNumber = ParseNumber(sb.ToString());
            sb = new StringBuilder(ConvertToString(parsedNumber));
        }
        return sb.ToString();

        static IList<(int, int)> ParseNumber(string number)
        {
            List<(int, int)> result = new List<(int, int)>();
            char currentChar = number[0];
            int currentCount = 1;
            for (int i = 1; i < number.Length; i++)
            {
                if (number[i] == currentChar)
                {
                    currentCount++;
                }
                else
                {
                    result.Add((currentCount, currentChar - '0'));
                    currentChar = number[i];
                    currentCount = 1;
                }
            }
            result.Add((currentCount, currentChar - '0'));
            return result;
        }

        static string ConvertToString(IList<(int, int)> number)
        {
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < number.Count; i++)
            {
                sb.Append(number[i].Item1);
                sb.Append(number[i].Item2);
            }
            return sb.ToString();
        }
    }

    #endregion

    #region 41 First Missing Positive 60/52 good result for the first attempt!

    // 1, 3, 5, 2, 7
    // 0001 + 0010 + 0011 + 0100 = 1010
    // Explanation of sol#1
    // Find min and max values and number of suitable values
    // use array of positions trick, where index in array determins value
    // to adjust values according to index, calculate number of positive, get rid of too big elements and negative
    public static int FirstMissingPositive(int[] nums)
    {
        if(nums.Length == 0)
        {
            return 1;
        }
        int minimumValue = int.MaxValue;
        int maxValue = 0;
        int positiveCounter = 0;
        int minimumPositive = 1;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] > 0) {
                if (nums[i] > 0)
                {
                    positiveCounter++;
                }
                if(nums[i] < minimumValue)
                {
                    minimumValue = nums[i];
                }
                if (nums[i] > maxValue) { maxValue = nums[i]; }
            }
        }

        if (minimumPositive < minimumValue)
        {
            return minimumPositive;
        }

        bool[] classifier = new bool[positiveCounter];
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] >= 1 && nums[i] < minimumValue + positiveCounter)
            {
                classifier[nums[i] - 1] = true;
            }
        }

        for (int i = 0; i < classifier.Length; i++)
        {
            if(!classifier[i])
            {
                return minimumPositive + i;
            }
        }

        return maxValue + 1;
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

    #region 172 Factorial Trailing Zeroes - 100/100

    public static int TrailingZeroes(int n)
    {
        int count = 0;
        for (long p = 5; p <= n; p *= 5)
        {
            count += (int)(n / p);
        }
        return count;
    }

    #endregion

    #region 202 - Happy Number - 8/5 poor

    public static bool IsHappy(int n)
    {
        int[] digits;

        int numberUnderReview = n;
        int cycleCounter = 0;
        while(true)
        {
            digits = numberUnderReview.ConvertToArrayOfDigits();

            int sum = 0;
            for (int i = 0; i < digits.Length; i++)
            {
                sum += (int) Math.Pow(digits[i], 2);
            }

            if(sum == 1)
            {
                return true;
            }

            if (sum == n || sum < 0 || cycleCounter > 100) {
                break;
            }

            numberUnderReview = sum;
            cycleCounter++;

        }

        return false;
    }

    #endregion

    #region 263 - Ugly Number - 100/7

    public static bool IsUgly(int n)
    {
        if(n <= 0)
        {
            return false;
        }

        if(n == 1)
        {
            return true;
        }

        int numberUnderReview = n;

        while (true)
        {
            if (numberUnderReview == 1)
            {
                break;
            }

            if (numberUnderReview % 2 == 0) {
                numberUnderReview  /= 2;
            } else if (numberUnderReview % 3 == 0)
            {
                numberUnderReview /= 3;
            } else if (numberUnderReview % 5 == 0)
            {
                numberUnderReview /= 5;
            } else
            {
                return false;
            }
        }

        return true;

    }

    #endregion

    #region 264 - Ugly Number II - not done

    public static int NthUglyNumber(int n)
    {
        List<int> firstN = new List<int> { 1, 2, 3, 4, 5, 6, 8, 9, 10, 12, 15 };

        if (n <= 11)
        {
            return firstN[n - 1];
        }

        int basicIndexForTwo = 6;
        int basicIndexForThree = 5;
        int basicIndexForFive = 3;

        int currentListPointer = 11;
        
        for (int i = 12; i < n; i++)
        {
            int multiplyOnTwo = firstN[basicIndexForTwo] * 2;
            int multiplyOnThree = firstN[basicIndexForThree] * 3;
            int multiplyOnFive = firstN[basicIndexForFive] * 5;

            // sort positions and values
            // select first that match - > currentBiggest and < all others
            // Move pointer of found value by 1, and set value to collection
            int currentBiggestNumber = firstN[currentListPointer - 1];


        }


        return 0;
    }

    #endregion
}

