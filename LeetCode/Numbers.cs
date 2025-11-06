namespace LeetCodeTasks.LeetCode;

public static class Numbers
{
    // #9 - IsPalindrome - medium memory and runtime performance
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
}
