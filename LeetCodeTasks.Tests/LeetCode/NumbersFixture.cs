namespace LeetCodeTasks.Tests.LeetCode;
[TestFixture]
internal class NumbersFixture
{
    [TestCase(121, true)]
    [TestCase(-121, false)]
    [TestCase(10, false)]
    [TestCase(123454321, true)]
    [TestCase(1234554321, true)]
    public static void Test_IsPalindrome(int number, bool result)
    {
        Assert.That(Numbers.IsPalindrome(number), Is.EqualTo(result));
    }

    [TestCase(1534236469, 0)]
    [TestCase(-123, -321)]
    [TestCase(-2147483648, 0)]
    [TestCase(121, 121)]
    [TestCase(123, 321)]
    [TestCase(120, 21)]
    public static void Test_Reverse(int number, int reversed)
    {
        Assert.That(Numbers.Reverse(number), Is.EqualTo(reversed));
    }

    [TestCase(2147483647, 46340)]
    [TestCase(2147395600, 46340)]
    [TestCase(4, 2)]
    [TestCase(1225, 35)]
    [TestCase(8, 2)]
    [TestCase(0, 0)]
    [TestCase(1, 1)]
    [TestCase(10001, 100)]
    public static void Test_MySqrt(int number, int expected)
    {
        Assert.That(Numbers.MySqrt(number), Is.EqualTo(expected));
    }

    [TestCase(-1.00000, -2147483648, 1)]
    [TestCase(2, -213423432, 0)]
    [TestCase(2, -2, 0.25)]
    [TestCase(0, 1, 0)]
    [TestCase(1, 0, 1)]
    [TestCase(2.1, 3, 9.26100d)]
    public void Test_Pow(double x, int n, double result)
    {
        Assert.That(Numbers.MyPow(x, n), Is.EqualTo(result));
    }

    [TestCase(1, 1)]
    [TestCase(2, 2)]
    [TestCase(3, 3)]
    [TestCase(4, 5)]
    public void Test_ClimbStairs(int n, int output)
    {
        Assert.That(Numbers.ClimbStairs(n), Is.EqualTo(output));
    }

    #region 38

    [TestCase(1, "1")]
    [TestCase(2, "11")]
    [TestCase(3, "21")]
    [TestCase(4, "1211")]
    [TestCase(5, "111221")]
    public void Test_CountAndSay(int n, string output)
    {
        Assert.That(Numbers.CountAndSay(n), Is.EqualTo(output));
    }

    #endregion

    #region 41

    [TestCaseSource(nameof(TestCases))]
    public void FirstMissingPositive_ShouldReturnExpectedResult(
        int[] nums,
        int expected)
    {
        // Act
        var result = Numbers.FirstMissingPositive(nums);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    private static readonly object[] TestCases =
    {
        // LeetCode examples
        new object[]
        {
            new[] { 1, 2, 0 },
            3
        },
        new object[]
        {
            new[] { 3, 4, -1, 1 },
            2
        },
        new object[]
        {
            new[] { 7, 8, 9, 11, 12 },
            1
        },

        // Single element
        new object[]
        {
            new[] { 1 },
            2
        },
        new object[]
        {
            new[] { 2 },
            1
        },
        new object[]
        {
            new[] { -1 },
            1
        },

        // Already complete sequence
        new object[]
        {
            new[] { 1, 2, 3, 4, 5 },
            6
        },

        // Missing first value
        new object[]
        {
            new[] { 2, 3, 4 },
            1
        },

        // Missing in middle
        new object[]
        {
            new[] { 1, 2, 4, 5 },
            3
        },

        // Duplicates
        new object[]
        {
            new[] { 1, 1 },
            2
        },
        new object[]
        {
            new[] { 1, 1, 2, 2 },
            3
        },
        new object[]
        {
            new[] { 2, 2, 2, 2 },
            1
        },

        // Negatives and zeros
        new object[]
        {
            new[] { -1, -2, -3 },
            1
        },
        new object[]
        {
            new[] { 0, 0, 0 },
            1
        },
        new object[]
        {
            new[] { -1, 0, 1, 2 },
            3
        },

        // Unsorted arrays
        new object[]
        {
            new[] { 4, 1, 3, 2 },
            5
        },
        new object[]
        {
            new[] { 2, 1 },
            3
        },

        // Large gaps
        new object[]
        {
            new[] { 1, 1000 },
            2
        },
        new object[]
        {
            new[] { 100, 101, 102 },
            1
        },

        // Typical tricky cases
        new object[]
        {
            new[] { 1, 2, 6, 3, 5, 4, 8 },
            7
        },
        new object[]
        {
            new[] { 3, 3, 1, 4, 0 },
            2
        },

        // Values outside useful range
        new object[]
        {
            new[] { int.MaxValue, 1 },
            2
        },
        new object[]
        {
            new[] { int.MaxValue, int.MinValue },
            1
        },

        // Empty array
        new object[]
        {
            Array.Empty<int>(),
            1
        }
    };

    #endregion

    #region 172

    [TestCase(6, 1)]
    [TestCase(1, 0)]
    [TestCase(2, 0)]
    [TestCase(5, 1)]
    public void Test_TrailingZeroes(int n, int output)
    {
        Assert.That(Numbers.TrailingZeroes(n), Is.EqualTo(output));
    }

    #endregion
}
