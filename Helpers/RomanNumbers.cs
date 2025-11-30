namespace LeetCodeTasks.Helpers;

public static class RomanNumbers
{
    public static Dictionary<string, int> CommonUsedRomanIntegers = new Dictionary<string, int>
    {
        {"I", 1 },
        {"II", 2 },
        {"III", 3 },
    };

    public static Dictionary<string, int> ReducedRomanIntegers = new Dictionary<string, int>
    {
        {"IV", 4 },
        {"IX", 9 },
        {"XL", 40 },
        {"XC", 90 },
        {"CD", 400 },
        {"CM", 900 },
    };

    public static Dictionary<string, int> RomanNumberToIntegerMap = new Dictionary<string, int>
    {
        {"I", 1 },
        {"V", 5 },
        {"X", 10 },
        {"L", 50 },
        {"C", 100 },
        {"D", 500 },
        {"M", 1000 },
    };
}
