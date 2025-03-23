namespace LeetCodeTasks.Tests;
[TestFixture]
public class ArrayFixture
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase("aab", "baa", true)]
    [TestCase("bg", "efjbdfbdgfjhhaiigfhbaejahgfbbgbjagbddfgdiaigdadhcfcj", true)]
    [TestCase("aa", "ab", false)]
    [TestCase("a", "b", false)]
    public void Test_CanConstruct2(string ransom, string magaz, bool result)
    {
        Assert.That(Arrays.CanConstruct2(ransom, magaz), Is.EqualTo(result));
    }

    [TestCase(new int[] { 1, 1, 1, 0, 1, 1, 1, 1 }, 4)]
    [TestCase(new int[] { 1, 1, 1, 0, 1, 1, 1, 1, 0 }, 4)]
    [TestCase(new int[] { 1, 1, 1, 1, 0, 1, 1, 1, 0 }, 4)]
    public void Test_MaxCons(int[] ints, int res)
    {
        Assert.That(Arrays.FindMaxConsecutiveOnes(ints), Is.EqualTo(res));
    }

    [TestCase(new int[] { 0, 3, 3, 0 }, 0, new int[] { 0, 3 })]
    [TestCase(new int[] { -3, 4, 3, 90 }, 0, new int[] { 0, 2 })]
    [TestCase(new int[] { 2, 7, 11, 15 }, 9, new int[] { 0,1 })]
    [TestCase(new int[] { 3, 2, 4 }, 6, new int[] { 1, 2 })]
    [TestCase(new int[] { 3,3 }, 6, new int[] { 0, 1 })]
    public void Test_TwoSums(int[] ints, int res, int[] output)
    {
        CollectionAssert.AreEquivalent(Arrays.TwoSum(ints, res), output);
        CollectionAssert.AreEquivalent(Arrays.TwoSum2(ints, res), output);
        CollectionAssert.AreEquivalent(Arrays.TwoSum3(ints, res), output);
    }
}