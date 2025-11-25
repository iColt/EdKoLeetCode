namespace LeetCodeTasks.LeetCode;

public static class Strings
{
    #region 3 Longest Substring without repeating characters

    public static int LengthOfLongestSubstring(string s)
    {
        return 0;
    }

    #endregion

    #region 17 - Letter combination of phone number - 5/5 - poor runtime and memory

    public static IList<string> LetterCombinations(string digits)
    {
        var phoneCombinations = new List<List<string>>
        {
            // empty list so that we don't need to avoid index adjustment during producing results
            new(),
            new() {"a", "b", "c" },
            new() {"d", "e", "f" },
            new() {"g", "h", "i" },
            new() {"j", "k", "l" },
            new() {"m", "n", "o" },
            new() {"p", "q", "r", "s" },
            new() {"t", "u", "v" },
            new() {"w", "x", "y", "z" },
        };

        var numberDigitList = digits.Select(x => int.Parse(x.ToString())).ToList();

        return ProduceLetterCombinationsReccursively(numberDigitList, phoneCombinations, string.Empty, 0);
    }

    private static List<string> ProduceLetterCombinationsReccursively(List<int> digits, List<List<string>> phoneCombinations, string currentCompination, int currentDigit)
    {
        var result = new List<string>();

        if(digits.Count - 1 == currentDigit)
        {
            foreach(var letter in phoneCombinations[digits[currentDigit] - 1]) { 
                result.Add(currentCompination +  letter);
            }
            return result;
        }

        int nextDigit = currentDigit + 1;

        for (int j = 0; j < phoneCombinations[digits[currentDigit] - 1].Count; j++)
        {
            result.AddRange(
                ProduceLetterCombinationsReccursively(digits, phoneCombinations, currentCompination + phoneCombinations[digits[currentDigit] - 1][j], nextDigit)
                );
        }

        return result;
    }

    #endregion

    #region 71 - Simplify path - 70/84 runtime/memory

    public static string SimplifyPath(string path)
    {
        if (string.IsNullOrEmpty(path))
        {
            return "/";
        }

        var stack = new Stack<string>();
        var parts = path.Split('/', StringSplitOptions.RemoveEmptyEntries);

        foreach (var part in parts)
        {
            if (part == ".")
            {
                continue;
            }
            else if (part == "..")
            {
                if (stack.Count > 0)
                {
                    stack.Pop();
                }
            }
            else
            {
                stack.Push(part);
            }
        }

        var result = "/" + string.Join('/', stack.Reverse());
        return result;
    }

    #endregion
}
