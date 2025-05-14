namespace LeetCodeTasks.Helpers;

public static class LinkedListHelpers
{
    public static int[] ExposeLinkedList(this ListNode list, int maxLength, out int realLength)
    {
        int[] arr = new int[maxLength];
        realLength = 0;
        ListNode current = list;

        while(true)
        {
            if(current == null)
            {
                return arr;
            }

            realLength++;
            current = current.next;
        }
    }

    public static ListNode CreateLinkedList(this int[] array)
    {
        ListNode node = new ListNode(array[0]);
        ListNode currentNode = node;
        for(int i = 1; i < array.Length; i++)
        {
            if(i  == array.Length - 1)
            {
                return node;
            }

            ListNode newNode = new ListNode(array[i]);
            currentNode.next = newNode;
            currentNode = newNode;
        }

        return node;
    }
}
