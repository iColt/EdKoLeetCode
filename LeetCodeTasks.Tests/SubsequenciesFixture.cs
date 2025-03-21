namespace LeetCodeTasks.Tests;
[TestFixture]
internal class SubsequenciesFixture
{
    [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31 }, 7)]
    [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 5)]
    [TestCase(new int[] { 1, 3, 7, 11, 12, 14, 18 }, 3)]
    [TestCase(new int[] { 2, 4, 7, 8, 9, 10, 14, 15, 18, 23, 32, 50 }, 5)]
    [TestCase(new int[] { 1, 3, 5 }, 0)]
    public void Test_LenLongestFibSubseq(int[] ints, int sequenceLength)
    {
        Assert.That(Subsequencies.LenLongestFibSubseq(ints), Is.EqualTo(sequenceLength));
    }

    [TestCase(new int[] { 2, 3, 5, 9, 1 }, 1, 1)]
    [TestCase(new int[] { 2, 3, 5, 9 }, 2, 5)]
    [TestCase(new int[] { 2, 7, 9, 3, 1 }, 2, 2)]
    public void Test_MinCapability(int[] ints, int minHouseNum, int maxCap)
    {
        Assert.That(Subsequencies.MinCapability(ints, minHouseNum), Is.EqualTo(maxCap));
    }
}
