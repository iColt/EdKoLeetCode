namespace LeetCodeTasks.Tests;
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

    [TestCase(121, 121)]
    [TestCase(123, 321)]
    [TestCase(-123, -321)]
    [TestCase(120, 21)]
    [TestCase(-2147483648, 0)]
    public static void Test_Reverse(int number, int reversed)
    {
        Assert.That(Numbers.Reverse(number), Is.EqualTo(reversed));
    }
}
