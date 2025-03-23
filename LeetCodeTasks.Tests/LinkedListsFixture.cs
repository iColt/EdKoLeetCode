namespace LeetCodeTasks.Tests;

[TestFixture]
internal class LinkedListsFixture
{
    [TestCase(new int[] { 0, 3, 3, 0 }, new int[] { 0, 3 }, new int[] { 0, 3 })]
    [TestCase(new int[] { -3, 4, 3, 90 }, new int[] { 0, 3 }, new int[] { 0, 2 })]
    [TestCase(new int[] { 2, 7, 11, 15 }, new int[] { 0, 3 }, new int[] { 0, 1 })]
    [TestCase(new int[] { 3, 2, 4 }, new int[] { 0, 3 }, new int[] { 1, 2 })]
    [TestCase(new int[] { 3, 3 }, new int[] { 0, 3 }, new int[] { 0, 1 })]
    public void Test_AddTwoNumbers(int[] first, int[] second, int[] output)
    {

    }
}
