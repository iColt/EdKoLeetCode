using LeetCodeTasks.Helpers;

namespace LeetCodeTasks.Tests.LeetCode;

[TestFixture]
internal class LinkedListsFixture
{
    [TestCase(new int[] { 2, 4, 3 }, new int[] { 5, 6, 4 }, 3, new int[] { 7, 0, 8 })]
    [TestCase(new int[] { 0 }, new int[] { 0 }, 1, new int[] { 0 })]
    [TestCase(new int[] { 9, 9, 9, 9, 9, 9, 9 }, new int[] { 9, 9, 9, 9 }, 8, new int[] { 8, 9, 9, 9, 0, 0, 0, 1 })]
    public void Test_AddTwoNumbers(int[] first, int[] second, int maxLen, int[] output)
    {
        var result = LinkedLists.AddTwoNumbers(first.CreateLinkedList(), second.CreateLinkedList());
        CollectionAssert.AreEquivalent(result.ExposeLinkedList(maxLen, out var _), output);
    }

    [TestCase(new int[] { 0, 1, 2 }, 1, 2)]
    [TestCase(new int[] { 0, 1, 2 }, 2, 1)]
    [TestCase(new int[] { 0, 1, 2 }, 3, 0)]
    [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, 4)]
    [TestCase(new int[] { 0, 1, 2 }, 4, 2)]
    public void Test_RotateRight(int[] first, int k, int firstEl)
    {
        var result = LinkedLists.RotateRight2(first.CreateLinkedList(), k);
        Assert.That(result.val, Is.EqualTo(firstEl));
    }

    [TestCase(new int[] { 1, 2, 4 }, new int[] { 1, 3, 4 }, new int[] { 1, 1, 2, 3, 4, 4 }, 6)]
    [TestCase(new int[] { }, new int[] { }, new int[] { }, 0)]
    [TestCase(new int[] { }, new int[] { 0 }, new int[] { 0 }, 1)]
    public void Test_MergeTwoLists(int[] first, int[] second, int[] output, int maxLen)
    {
        var result = LinkedLists.MergeTwoLists(first.CreateLinkedList(), second.CreateLinkedList());
        CollectionAssert.AreEquivalent(result.ExposeLinkedList(maxLen, out var _), output);
    }

    [TestCase(new int[] { }, new int[] { }, 0)]
    [TestCase(new int[] { 4, 2, 1, 3 }, new int[] { 1, 2, 3, 4 }, 4)]
    [TestCase(new int[] { -1, 5, 3, 4, 0 }, new int[] { -1, 0, 3, 4, 5 }, 5)]
    [TestCase(new int[] { 1 }, new int[] { 1 }, 1)]
    public void Test_SortList(int[] linkedList, int[] output, int maxLen)
    {
        var result = LinkedLists.SortList(linkedList.CreateLinkedList());
        CollectionAssert.AreEquivalent(result.ExposeLinkedList(maxLen, out var _), output);
    }

    [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, new int[] { 1 }, 1)]
    [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 }, new int[] { 1, 2 }, 2)]
    [TestCase(new int[] { }, new int[] { }, 0)]
    [TestCase(new int[] { 1 }, new int[] { 1 }, 1)]
    [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4 }, 4)]
    [TestCase(new int[] { 1, 1, 2, 2, 3, 3, 4 }, new int[] { 1, 2, 3, 4 }, 4)]
    public void Test_DeleteDuplicates(int[] linkedList, int[] output, int maxLen)
    {
        var result = LinkedLists.DeleteDuplicates(linkedList.CreateLinkedList());
        CollectionAssert.AreEquivalent(result.ExposeLinkedList(maxLen, out var _), output);
    }

    [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, new int[] { }, 0)]
    [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 }, new int[] {  }, 0)]
    [TestCase(new int[] { 1, 1, 2, 2, 3, 3, 4 }, new int[] { 4 }, 1)]
    [TestCase(new int[] { }, new int[] { }, 0)]
    [TestCase(new int[] { 1 }, new int[] { 1 }, 1)]
    [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4 }, 4)]
    public void Test_DeleteDuplicates2(int[] linkedList, int[] output, int maxLen)
    {
        var result = LinkedLists.DeleteDuplicates2(linkedList.CreateLinkedList());
        CollectionAssert.AreEquivalent(result.ExposeLinkedList(maxLen, out var _), output);
    }
}
