using LeetCodeTasks.Helpers;

namespace LeetCodeTasks.Tests;

[TestFixture]
internal class LinkedListsFixture
{
    [TestCase(new int[] { 2,4,3 }, new int[] { 5,6,4 }, 3, new int[] { 7,0,8 })]
    [TestCase(new int[] { 0 }, new int[] { 0 }, 1, new int[] { 0 })]
    [TestCase(new int[] { 9, 9, 9, 9, 9, 9, 9 }, new int[] { 9, 9, 9, 9 }, 8, new int[] { 8, 9, 9, 9, 0, 0, 0, 1 })]
    public void Test_AddTwoNumbers(int[] first, int[] second, int maxLen, int[] output)
    {
        var result = LinkedLists.AddTwoNumbers(first.CreateLinkedList(), second.CreateLinkedList());
        CollectionAssert.AreEquivalent(result.ExposeLinkedList(maxLen, out var _), output);
    }

    [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, 4)]
    [TestCase(new int[] { 0, 1, 2 }, 4, 2)]
    public void Test_RotateRight(int[] first, int k, int firstEl)
    {
        var result = LinkedLists.RotateRight(first.CreateLinkedList(), k);
        Assert.That(result.val, Is.EqualTo(firstEl));
    }
}
