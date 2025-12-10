using System.Text;

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

    [TestCase("pwwkew", 3)]
    [TestCase("abcabcbb", 3)]
    [TestCase("bbbbb", 1)]
    public void Test_LengthOfLongestSubstring(string s, int count)
    {
        Assert.That(Strings.LengthOfLongestSubstring(s), Is.EqualTo(count));
    }

    [TestCase("MCMXCIV", 1994)]
    [TestCase("I", 1)]
    [TestCase("II", 2)]
    [TestCase("III", 3)]
    [TestCase("IV", 4)]
    [TestCase("LVIII", 58)]
    public void Test_RomanToInt(string s, int number)
    {
        Assert.That(Strings.RomanToInt(s), Is.EqualTo(number));
    }

    [TestCase(18278, "ZZZ")]
    [TestCase(52, "AZ")]
    [TestCase(702, "ZZ")]
    [TestCase(78, "BZ")]
    [TestCase(2147483647, "FXSHRXW")]
    [TestCase(703, "AAA")]
    [TestCase(53, "BA")]
    [TestCase(26, "Z")]
    [TestCase(701, "ZY")]
    [TestCase(1, "A")]
    public void Test_ConvertToTitle(int columnNumber, string output)
    {
        Assert.That(Strings.ConvertToTitle(columnNumber), Is.EqualTo(output));
    }

    [TestCase("a")]
    [TestCase("aa")]
    [TestCase("aab")]
    [TestCase("efe")]
    public void Test_Partition_ReturnsCorrectPartitions(string input)
    {
        // Arrange: predefined expected results
        var expected = input switch
        {
            "a" => new List<IList<string>>
            {
                new List<string>{ "a" }
            },

            "aa" => new List<IList<string>>
            {
                new List<string>{ "a", "a" },
                new List<string>{ "aa" }
            },

            "aab" => new List<IList<string>>
            {
                new List<string>{ "a", "a", "b" },
                new List<string>{ "aa", "b" }
            },

            "efe" => new List<IList<string>>
            {
                new List<string>{ "e", "f", "e" },
                new List<string>{ "efe" }
            },

            _ => null
        };

        // Act
        var result = Strings.Partition(input);

        // Normalize ordering of lists (convert to hashable)
        var expectedSet = Normalize(expected);
        var resultSet = Normalize(result);

        // Assert
        CollectionAssert.AreEquivalent(expectedSet, resultSet);
    }

    // Convert list of lists into hashable string for order-insensitive comparison
    private static HashSet<string> Normalize(IList<IList<string>> list)
    {
        return new HashSet<string>(
            list.Select(part => string.Join(",", part))
        );
    }
}
