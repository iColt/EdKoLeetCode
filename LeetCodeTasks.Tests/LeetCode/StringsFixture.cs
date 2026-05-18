using NUnit.Framework.Legacy;

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

    [TestCase("", true)]
    [TestCase(" ", true)]
    [TestCase("a", true)]
    [TestCase("A", true)]
    [TestCase("aa", true)]
    [TestCase("ab", false)]

    [TestCase("A man, a plan, a canal: Panama", true)]
    [TestCase("race a car", false)]
    [TestCase("No 'x' in Nixon", true)]

    [TestCase(".,", true)]
    [TestCase("0P", false)]
    [TestCase("12321", true)]
    [TestCase("1231", false)]

    public void IsPalindrome_ReturnsExpectedResult(string input, bool expected)
    {
        // Act
        bool result = Strings.IsPalindrome(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    #region 8

    [TestCaseSource(nameof(MyAtoiTestCases))]
    public void MyAtoi_ShouldReturnCorrectValue(
        string input,
        int expected)
    {
        // Act
        var result = Strings.MyAtoi(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    public static object[] MyAtoiTestCases =
    {
        // Basic numbers
        new object[] { "0", 0 },
        new object[] { "42", 42 },
        new object[] { "-42", -42 },
        new object[] { "+42", 42 },

        // Leading spaces
        new object[] { "   42", 42 },
        new object[] { "   -42", -42 },

        // Trailing characters
        new object[] { "4193 with words", 4193 },
        new object[] { "-91283472332 words", int.MinValue },

        // Words before numbers
        new object[] { "words and 987", 0 },

        // Sign only
        new object[] { "+", 0 },
        new object[] { "-", 0 },

        // Multiple signs
        new object[] { "+-12", 0 },
        new object[] { "--2", 0 },
        new object[] { "-+3", 0 },

        // Leading zeros
        new object[] { "00000", 0 },
        new object[] { "0000123", 123 },

        // Overflow
        new object[] { "2147483647", int.MaxValue },
        new object[] { "2147483648", int.MaxValue },
        new object[] { "-2147483648", int.MinValue },
        new object[] { "-2147483649", int.MinValue },

        // Mixed symbols
        new object[] { "  -0012a42", -12 },

        // Empty / whitespace
        new object[] { "", 0 },
        new object[] { "   ", 0 },

        // Non-digit start
        new object[] { ".", 0 },
        new object[] { "   +abc", 0 },

        // Digits then sign (invalid)
        new object[] { "123-45", 123 },

        // Large number with sign
        new object[] { "+10000000000", int.MaxValue },
        new object[] { "-10000000000", int.MinValue }
    };

    #endregion

    #region 58

    [TestCase("A B", 1)]
    [TestCase("HELLO WORLD", 5)]
    [TestCase("HI ALL ", 3)]
    [TestCase("KEK", 3)]
    public void LengthOfLastWord_ReturnsExpectedResult(string input, int result)
    {
        Assert.That(result, Is.EqualTo(Strings.LengthOfLastWord(input)));
    }

    #endregion

    #region 151

    [TestCase(" World    Hello  ", "Hello World")]
    [TestCase("the sky is blue", "blue is sky the")]
    public void ReverseWords_ReturnsExpectedResult(string input, string output)
    {
        Assert.That(Strings.ReverseWords(input), Is.EqualTo(output));
    }

    #endregion

    #region 165

    [TestCase("1.0", "1.0", 0)]
    [TestCase("1.0", "1.1", -1)]
    [TestCase("1.1", "1.0", 1)]
    [TestCase("1.0.0", "1.0", 0)]
    [TestCase("1.0.1", "1.0", 1)]
    [TestCase("1.0", "1.0.1", -1)]
    [TestCase("0.1", "1.1", -1)]
    [TestCase("1.01", "1.001", 0)]
    public void CompareVersion_ReturnsExpectedResult(string version1, string version2, int expected)
    {
        Assert.That(expected, Is.EqualTo(Strings.CompareVersion(version1, version2)));
    }

    #endregion

    #region 242

    [TestCase("car", "arc", true)]
    [TestCase("car", "rat", false)]
    public void IsAnagram_ReturnExpectedResult(string input, string secondInput, bool expected)
    {
        Assert.That(expected, Is.EqualTo(Strings.IsAnagram(input, secondInput)));
    }

    #endregion

    #region 387

    [TestCaseSource(nameof(FirstUniqCharTestCases))]
    public void FirstUniqChar_ShouldReturnCorrectIndex(
        string input,
        int expected)
    {
        // Act
        var result = Strings.FirstUniqChar(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    public static object[] FirstUniqCharTestCases =
    {
        // Empty string
        new object[]
        {
            "",
            -1
        },

        // Single character
        new object[]
        {
            "a",
            0
        },

        // Example 1
        new object[]
        {
            "leetcode",
            0
        },

        // Example 2
        new object[]
        {
            "loveleetcode",
            2
        },

        // All characters repeat
        new object[]
        {
            "aabbcc",
            -1
        },

        // First unique at the end
        new object[]
        {
            "aabbccd",
            6
        },

        // Multiple uniques, take first
        new object[]
        {
            "abaccdeff",
            1
        },

        // Adjacent duplicates
        new object[]
        {
            "aabb",
            -1
        },

        // Long repetition then unique
        new object[]
        {
            "zzzzzzzzzzx",
            10
        },

        // Mixed pattern
        new object[]
        {
            "aadadaad",
            -1
        }
    };

    #endregion

    #region 409

    [TestCaseSource(nameof(LongestPalindromeTestCases))]
    public void LongestPalindrome_ShouldReturnCorrectLength(string input, int expected)
    {
        // Act
        var result = Strings.LongestPalindrome(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    public static object[] LongestPalindromeTestCases =
    {
        // LeetCode examples
        new object[] { "abccccdd", 7 },
        new object[] { "a", 1 },

        // All characters even count
        new object[] { "aabbcc", 6 },

        // One odd count allowed in center
        new object[] { "aaabbbb", 7 },

        // Multiple odd counts (only one can be used fully)
        new object[] { "abc", 1 },

        // Mixed uppercase and lowercase
        new object[] { "Aa", 1 },
        new object[] { "AaBb", 1 },

        // Empty string
        new object[] { "", 0 },

        // Single repeated character
        new object[] { "zzzz", 4 },

        // Long mixed string
        new object[] { "bananas", 5 }, // "anana"

        // Two odd counts
        new object[] { "aabbc", 5 }
    };

    #endregion
}
