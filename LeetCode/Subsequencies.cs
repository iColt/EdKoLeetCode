namespace LeetCodeTasks.LeetCode;

public class Subsequencies
{
    #region #873

    // #873 - non optimal in runtime, optimal in memory
    public static int LenLongestFibSubseq(int[] arr)
    {
        int longestFibSubseq = 0;
        int arrLength = arr.Length;

        for (int i = 0; i < arrLength; i++)
        {
            for (int j = i + 1; j < arrLength - 1; j++)
            {
                int searchedVal = arr[i] + arr[j];
                int countForCurrent = CountLengthFibSubseq(arr, j + 1, searchedVal);

                if (countForCurrent > longestFibSubseq)
                {
                    longestFibSubseq = countForCurrent;
                }
            }

            if (longestFibSubseq > arrLength - i - 1)
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

            if (nextFib < 0)
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

    #endregion

    #region #2560

    public static int MinCapability(int[] nums, int k)
    {
        int[] sortedArr = new int[nums.Length];
        nums.CopyTo(sortedArr, 0);
        int[] indexArr = new int[nums.Length];

        for (int i = 0; i < nums.Length; i++)
        {
            indexArr[i] = i;
        }

        Array.Sort<int, int>(sortedArr, indexArr);

        if (k == 1)
        {
            return nums[indexArr[0]];
        }

        int[] valueArr = new int[k];
        int[] tempIndexesArr = new int[k];
        int maxValue = 0;
        bool seqFound = false;

        //initial value
        //for (int i = 0; i < k; i+=2)
        //{
        //    valueArr[i] = nums[i];
        //    if(maxValue < valueArr[i])
        //    {
        //        maxValue = valueArr[i];
        //    }
        //    indexesArr[i] = i;
        //}

        for(int i = 0; i < nums.Length - k; ++i)
        {
            //somehow iterate through k elements, find possible combination
            //possible combination - we took elem i, than check all other (k - 1) elem
            //check if possible combination, where all elem differs > 1 in position array
            maxValue = sortedArr[i];
            tempIndexesArr[0] = indexArr[i];
            int nextElPos = i + 1;

            for (int j = 0; j < k - 1; j ++)
            {
                nextElPos = GetNextElPos(nextElPos, sortedArr, tempIndexesArr, j + 1);

                if(nextElPos == 1)
                {
                    break;
                }
            }

            //if(seqFound)
            //{
            //    break;
            //}
        }

        return maxValue;
    }

    /// <summary>
    /// Get next element that satisfy requirement about 'adjacent homes'
    /// </summary>
    /// <param name="startingIndex">Index to start iterate</param>
    /// <param name="indexesArr">Array with already found indexes, that should be checked</param>
    /// <param name="currentFillLevel">Count of elements in indexesArr to check</param>
    /// <returns></returns>
    private static int GetNextElPos(int startingIndex, int[] sortedArr, int[] indexesArr, int currentFillLevel)
    {
        for (int i = startingIndex; i < sortedArr.Length; i++)
        {

        }
        return -1;
    }
    #endregion

    #region 128 Longest Consecutive Sequence

    public static int LongestConsecutive(int[] nums)
    {
        //shall we store distance between numbers?
        return 0;
    }

    #endregion
}
