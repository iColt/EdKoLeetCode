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
} 
