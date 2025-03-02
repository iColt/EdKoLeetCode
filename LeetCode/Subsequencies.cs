using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTasks.LeetCode;

public class Subsequencies
{
    // #873
    // for each i from the beginning to (end - longestFibSubseqLen)
    // check if possible to start fibon seq with i + j element = exist elem k = i + j
    // if possible - start from k to the end
    public static int LenLongestFibSubseq(int[] arr)
    {
        int longestFibSubseq = 1;
        int arrLength = arr.Length;

        for (int i = 0; i < arrLength; i++)
        {
            for(int j = 1; j < arrLength - 1; j++)
            {
                int searchedVal = arr[i] + arr[j];
                int countForCurrent = CountLengthFibSubseq(arr, j+1, searchedVal);

            }

            // if longest > arrLenth - i; break
        }

        return longestFibSubseq;
    }

    public static int CountLengthFibSubseq(int[] arr, int startPos, int initialVal)
    {
        int lengthFibSeq = 2;
        //find new element
        //if found - reccursive call and add value to 
        //int nextFib = NextFibElem(arr, j, initialVal);

        return lengthFibSeq;
    }

    // search binary
    // should be decorated and made recursive
    public static int NextFibElem(int[] arr, int startPos, int searchValue)
    {
        return -1;
    }
}
