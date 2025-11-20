namespace LeetCodeTasks.Tests.LeetCode;
[TestFixture]
public sealed class DynamicProgrammingFixture
{
    [TestCase(new int[] { 1, 7, 4, 2 }, 6)]
    [TestCase(new int[] { 3, 2, 6, 1, 8 }, 7)]
    [TestCase(new int[] { 5, 4, 3, 8, 1, 10 }, 9)]
    [TestCase(new int[] { 5, 5, 5, 5 }, 0)]
    [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 5)]
    [TestCase(new int[] { 7, 1, 5, 3, 6, 4 }, 5)]
    [TestCase(new int[] { 7, 6, 4, 3, 1 }, 0)]
    [TestCase(new int[] { }, 0)]
    [TestCase(new int[] { 5 }, 0)]
    
    public void Test_MaxProfit(int[] prices, int output)
    {
        Assert.That(DynamicProgramming.MaxProfit(prices), Is.EqualTo(output));
    }
}
