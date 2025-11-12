namespace LeetCodeTasks.Tests.LeetCode;
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
    [TestCase(new int[] { 2, 7, 11, 15 }, 9, new int[] { 0, 1 })]
    [TestCase(new int[] { 3, 2, 4 }, 6, new int[] { 1, 2 })]
    [TestCase(new int[] { 3, 3 }, 6, new int[] { 0, 1 })]
    public void Test_TwoSums(int[] ints, int res, int[] output)
    {
        CollectionAssert.AreEquivalent(Arrays.TwoSum(ints, res), output);
        CollectionAssert.AreEquivalent(Arrays.TwoSum2(ints, res), output);
        CollectionAssert.AreEquivalent(Arrays.TwoSum3(ints, res), output);
    }

    [TestCase(new int[] { 3, 2, 2, 3 }, 3, 2)]
    [TestCase(new int[] { 0, 1, 2, 2, 3, 0, 4, 2 }, 2, 5)]
    public void Test_RemoveElements(int[] ints, int value, int length)
    {
        Assert.That(Arrays.RemoveElement(ints, value), Is.EqualTo(length));
    }

    [TestCase(new int[] { 1, 1, 2 }, 2)]
    [TestCase(new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 }, 5)]
    [TestCase(new int[] { -100, -8, 0, 0, 1, 1, 2, 30, 30, 40 }, 7)]
    public void Test_RemoveDuplicates(int[] ints, int length)
    {
        Assert.That(Arrays.RemoveDuplicates(ints), Is.EqualTo(length));
    }

    [TestCase(new int[] { 1, 3, 5, 6 }, 5, 2)]
    [TestCase(new int[] { 1, 3, 5, 6 }, 2, 1)]
    [TestCase(new int[] { 1, 3, 5, 6 }, 7, 4)]
    public void Test_SearchInsert(int[] nums, int target, int pos)
    {
        Assert.That(Arrays.SearchInsert(nums, target), Is.EqualTo(pos));
    }

    #region 66 - Plus One

    [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2, 4 })]
    [TestCase(new int[] { 1, 2, 9 }, new int[] { 1, 3, 0 })]
    [TestCase(new int[] { 9, 9, 9 }, new int[] { 1, 0, 0, 0 })]
    [TestCase(new int[] { 1, 0, 0 }, new int[] { 1, 0, 1 })]
    [TestCase(new int[] { 9 }, new int[] { 1, 0 })]
    [TestCase(new int[] { 7 }, new int[] { 8 })]
    [TestCase(new int[] { 2, 3, 4 }, new int[] { 2, 3, 5 })]
    [TestCase(new int[] { 4, 3, 9, 9 }, new int[] { 4, 4, 0, 0 })]
    [TestCase(new int[] { 2, 3, 4 }, new int[] { 2, 3, 5 })]
    public void Tets_PlusOne(int[] nums, int[] expected)
    {
        int[] result = Arrays.PlusOne(nums);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Tets_PlusOne_ShouldHandleLargeNumber()
    {
        int[] input = new int[100];
        for (int i = 0; i < input.Length; i++)
            input[i] = 9;

        int[] result = Arrays.PlusOne(input);

        Assert.That(result.Length, Is.EqualTo(101));
        Assert.That(result[0], Is.EqualTo(1));
        Assert.That(result[1], Is.EqualTo(0));
    }

    #endregion
}