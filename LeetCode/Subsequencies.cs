namespace LeetCodeTasks.LeetCode;

public class Subsequencies
{
    // #873 - non optimal in runtime
    public static int LenLongestFibSubseq(int[] arr)
    {
        int longestFibSubseq = 0;
        int arrLength = arr.Length;

        for (int i = 0; i < arrLength; i++)
        {
            for(int j = i + 1; j < arrLength - 1; j++)
            {
                int searchedVal = arr[i] + arr[j];
                int countForCurrent = CountLengthFibSubseq(arr, j+1, searchedVal);

                if(countForCurrent > longestFibSubseq) {  
                    longestFibSubseq = countForCurrent; 
                }
            }

            if(longestFibSubseq > arrLength - i - 1)
            {
                break;
            }
        }

        return longestFibSubseq;
    }

    public static int CountLengthFibSubseq(int[] arr, int startPos, int initialVal)
    {
        int lengthFibSeq = 0;
        int currentPos = startPos;
        int currentVal = initialVal;

        while (true)
        {
            int nextFib = NextFibElem(arr, currentPos, currentVal);

            if(nextFib < 0)
            {
                break;
            }

            lengthFibSeq++;
            currentVal = arr[currentPos - 1] + arr[nextFib];
            currentPos = nextFib + 1;

            if (currentPos == arr.Length || currentVal > arr[arr.Length - 1])
            {
                break;
            }
        }

        return lengthFibSeq > 0 ? lengthFibSeq + 2 : 0;
    }

    public static int NextFibElem(int[] arr, int startPos, int searchValue)
    {
        return Array.BinarySearch<int>(arr, startPos, arr.Length - startPos, searchValue);
    }
}
