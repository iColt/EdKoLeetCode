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

    #region 21 Merge Two Sorted Lists - 100/7 runtime/memory. Awful memory consumption

    public static ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        ListNode resultHead = new ListNode();
        ListNode? iterator = resultHead;

        ListNode currentFirst = list1;
        ListNode currentSecond = list2;

        if (currentFirst == null && currentSecond == null)
        {
            return null;
        }

        while (true)
        {
            if (currentFirst == null && currentSecond == null)
            {
                break;
            }

            if (currentFirst == null && currentSecond != null)
            {
                currentSecond = SetValue(iterator, currentSecond);
            }
            else
            if (currentFirst != null && currentSecond == null)
            {
                currentFirst = SetValue(iterator, currentFirst);
            }
            else if (currentFirst != null && currentSecond != null)
            {
                if (currentFirst.val < currentSecond.val)
                {
                    currentFirst = SetValue(iterator, currentFirst);
                }
                else
                {
                    currentSecond = SetValue(iterator, currentSecond);
                }
            }

            if (currentFirst != null && currentSecond != null)
            {
                iterator.next = new ListNode();
                iterator = iterator.next;
            }
        }

        return resultHead;
    }

    private static ListNode SetValue(ListNode iterator, ListNode current)
    {
        iterator.val = current.val;
        current = current.next;
        return current;
    }

    #endregion

    #region #61 Rotate List - non optimal in runtime, non optimal in memory 21.5/8

    public static ListNode RotateRight(ListNode head, int k)
    {
        // do 1-time analyze of List and save list[end] and list[end - k] element and list[initialHead]
        // if k < full list capacity:
        //  list[end - k] - will be new head
        //  list[end] will reference list[initialHead]
        //  list[end - k - 1] - will be new tail (reference null)
        // if k = full capacity - do nothing, return current head
        // else - reduce |k| by capacity, and do the second step of algorithm 

        if (k == 0 || head == null)
        {
            return head;
        }

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

            if(iterator == k + 1)
            {
                newTailNode = previousNode;
                newHeadNode = currentNode;
            }
            
        }

        if(k == iterator || iterator <= 1)
        {
            return head;
        }
        else if(k < iterator)
        {
            newHeadNode.next = head;
            newTailNode.next = null;
            return endNode;
        }
        else
        {

        }
        return head;
    }

    public static ListNode RotateRight2(ListNode head, int k)
    {
        if (k == 0 || head == null)
        {
            return head;
        }

        ListNode outputNode = new ListNode();
        int listLength;
        int[] arrayForm = LinkedListHelpers.ExposeLinkedList(head, 500, out listLength);

        if(listLength == k)
        {
            return head;
        }

        Array.Resize<int>(ref arrayForm, listLength);

        int moduleK = k;
        if (k > listLength)
        {
            moduleK = k % listLength;
        }
        int[] resultArr = new int[listLength];
        for(int i = 0; i < moduleK; i ++)
        {
            resultArr[i] = arrayForm[listLength - moduleK + i];
        }
        for(int i = 0; i < listLength - moduleK; i++)
        {
            resultArr[i + moduleK] = arrayForm[i];
        }

        outputNode = resultArr.CreateLinkedList();

        return outputNode;
    }

    #endregion

    #region 148 Sort List - 35.35/99.9 Worst runtime, because of extra sort of extra array?

    public static ListNode SortListTimeConsuming(ListNode head)
    {
        if(head == null)
        {
            return null;
        }

        if(head.next == null)
        {
            return head;
        }

        ListNode currentNode = head;
        ListNode iterationNode = head.next;
        ListNode minValueNode = currentNode;
        while (true) {

            if (currentNode == null || currentNode.next == null)
            {
                break;
            }

            int currentValue = currentNode.val;

            while(true)
            {
                if (iterationNode == null)
                {
                    break;
                }

                if(iterationNode.val < minValueNode.val)
                {
                    minValueNode = iterationNode;
                }

                iterationNode = iterationNode.next;
            }

            if(currentValue > minValueNode.val)
            {
                currentNode.val = minValueNode.val;
                minValueNode.val = currentValue;
            }

            currentNode = currentNode.next;
            iterationNode = currentNode.next;
            minValueNode = currentNode;

        }

        return head;
    }

    public static ListNode SortList(ListNode head)
    {
        if (head == null)
        {
            return null;
        }

        if (head.next == null)
        {
            return head;
        }

        ListNode currentNode = head;
        const int maxLenght = 50000;
        int[] array = new int[maxLenght];
        int counter = 0;
        while(true)
        {
            if(currentNode == null)
            {
                break;
            }

            array[counter++] = currentNode.val;
            currentNode = currentNode.next;
        }

        Array.Resize(ref array, counter);
        Array.Sort(array);

        currentNode = head;
        for(int i = 0; i < array.Length; i++)
        {
            currentNode.val = array[i];
            currentNode = currentNode.next;
        }
        return head;
    }

    #endregion
}
