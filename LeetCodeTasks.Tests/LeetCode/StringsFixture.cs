namespace LeetCodeTasks.Tests.LeetCode;

[TestFixture]
public sealed class StringsFixture
{
    [TestCase("/home/", "/home")]
    [TestCase("/home//foo/", "/home/foo")]
    [TestCase("/home/user/Documents/../Pictures", "/home/user/Pictures")]
    [TestCase("/../", "/")]
    [TestCase("/.../a/../b/c/../d/./", "/.../b/d")]
    public void Test_SimplifyPath(string path, string result)
    {
        Assert.That(Strings.SimplifyPath(path), Is.EqualTo(result));
    }

    [TestCase("23", 9)]
    [TestCase("2", 3)]
    public void Test_LetterCombinations(string digits, int count)
    {
        Assert.That(Strings.LetterCombinations(digits).Count, Is.EqualTo(count));
    }

    public void Test_LengthOfLongestSubstring(string s, int count)
    {
        Assert.That(Strings.LengthOfLongestSubstring(s), Is.EqualTo(count));
    }

    [TestCase("III", 3)]
    [TestCase("LVIII", 58)]
    [TestCase("MCMXCIV", 1994)]
    public void Test_RomanToInt(string s, int number)
    {
        Assert.That(Strings.RomanToInt(s), Is.EqualTo(number));
    }
}
