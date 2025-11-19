namespace LeetCodeTasks.Tests.LeetCode;
[TestFixture]
public sealed class OptimizationsFixture
{
    [TestCase(new int[] { 7, 1, 5, 3, 6, 4 }, 5)]
    [TestCase(new int[] { 7, 6, 4, 3, 1 }, 0)]
    public void Test_MaxProfit(int[] prices, int output)
    {
        Assert.That(Optimizations.MaxProfit(prices), Is.EqualTo(output));
    }
}
