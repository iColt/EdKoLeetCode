using LeetCodeTasks.Helpers;

namespace LeetCodeTasks.LeetCode;

public class LinkedLists
{
    // #2 - Add Two Numbers - non optimal in runtime, non optimal in memory
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
}
