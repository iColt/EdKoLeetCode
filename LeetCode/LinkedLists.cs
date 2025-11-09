using LeetCodeTasks.Helpers;

namespace LeetCodeTasks.LeetCode;

public class LinkedLists
{
    #region #2 - Add Two Numbers - non optimal in runtime, non optimal in memory

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

        int[] resultArray = AddDigitArrays(first, second);
        outputNode = resultArray.CreateLinkedList();

        return outputNode;
    }

    static int[] AddDigitArrays(int[] a, int[] b)
    {
        int i = a.Length - 1;
        int j = b.Length - 1;
        int carry = 0;
        var result = new List<int>(Math.Max(a.Length, b.Length) + 1);

        while (i >= 0 || j >= 0 || carry > 0)
        {
            int digitA = (i >= 0) ? a[i--] : 0;
            int digitB = (j >= 0) ? b[j--] : 0;

            int sum = digitA + digitB + carry;
            result.Add(sum % 10);
            carry = sum / 10;
        }

        result.Reverse();
        return result.ToArray();
    }

    #endregion

    #region #61

    public static ListNode RotateRight(ListNode head, int k)
    {
        // do 1-time analyze of List and save list[end] and list[end - k] element and list[initialHead]
        // if k < full list capacity:
        //  list[end - k] - will be new head
        //  list[end] will reference list[initialHead]
        //  list[end - k - 1] - will be new tail (reference null)
        // if k = full capacity - do nothing, return current head
        // else - reduce |k| by capacity, and do the second step of algorithm 
        int listCapacity = 0;

        ListNode endNode = null;
        ListNode newHeadNode = null;
        ListNode newTailNode = null;

        ListNode currentNode = head;
        ListNode previousNode = null;
        int iterator = 0;

        while(true)
        {
            if(currentNode.next == null)
            {
                endNode = currentNode;
                break;
            }

            previousNode = currentNode;
            currentNode = currentNode.next;
            iterator++;

            if (iterator > k + 1)
            {
                newTailNode = previousNode; 
                newHeadNode = currentNode;
            }
        }

        return head;
    }

    #endregion
}
