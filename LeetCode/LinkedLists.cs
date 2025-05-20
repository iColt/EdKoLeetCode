using LeetCodeTasks.Helpers;

namespace LeetCodeTasks.LeetCode;

public class LinkedLists
{
    // #2 - Add Two Numbers
    public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        ListNode outputNode = new ListNode();
        int lengthFirst;
        int[] first = LinkedListHelpers.ExposeLinkedList(l1, 100, out lengthFirst);
        int lengthSecond;
        int[] second = LinkedListHelpers.ExposeLinkedList(l2, 100, out lengthSecond);
        
        Array.Resize<int>(ref first, lengthFirst);
        Array.Resize<int>(ref second, lengthSecond);

        Array.Reverse(first);
        Array.Reverse(second);

        int[] resultArray;
        // just convert to classic long numbers and sum?
        // (maybe it will be not correct and I need to save current approach just in case)
        if (lengthFirst > lengthSecond)
        {
            resultArray = SumTwoArraysByNum(first, lengthFirst, second, lengthSecond);
        }
        else
        {
            resultArray = SumTwoArraysByNum(second, lengthSecond, first, lengthFirst);
        }

        Array.Reverse(resultArray);

        outputNode = resultArray.CreateLinkedList();
        // Approach 1:
        // reverse first, calculate length
        // reverse second, calculate length
        // join

        // Approach 2
        // run reccursion on both two linked lists
        // reccursion should return integer 0 < x < 19
        // when reccursion meet the end of any list -  

        return outputNode;
    }

    // no initial revert = incorrect numbers
    //we should convert number to array and just sum it, then write to output array or event node
    private static int[] SumTwoArraysByNum(int[] first, int lengthFirst, int[] second, int lengthSecond)
    {
        int[] resultArray = new int[lengthFirst + 1];
        int increaseValue = 0;

        for (int i = 0; i < lengthFirst; i++)
        {
            if(i < lengthSecond)
            {
                int sum = first[i] + second[i] + increaseValue;
                if(sum > 9)
                {
                    increaseValue = sum / 10;
                    resultArray[i] = sum % 10;
                }
                else
                {
                    resultArray[i] = sum;
                    increaseValue = 0;
                }
            }
            else
            {
                int sum = first[i] + increaseValue;
                if (sum > 9)
                {
                    increaseValue = sum % 10;
                    resultArray[i] = sum / 10;
                }
                else
                {
                    resultArray[i] = sum;
                    increaseValue = 0;
                }
            }
        }

        if(increaseValue != 0)
        {
            resultArray[lengthFirst + 1] = increaseValue;
        }
        else
        {
            Array.Resize(ref resultArray, lengthFirst);
        }

        return resultArray;
    }
}
