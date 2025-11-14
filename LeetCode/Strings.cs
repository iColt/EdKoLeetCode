namespace LeetCodeTasks.LeetCode;

public static class Strings
{
    #region 17

    public static IList<string> LetterCombinations(string digits)
    {
        var phoneCombinations = new List<List<string>>
        {
            // empty list so that we don't need to avoid index adjustment during producing results
            new List<string>(),
            new List<string> {"a", "b", "c" },
            new List<string> {"d", "e", "f" },
            new List<string> {"g", "h", "i" },
            new List<string> {"j", "k", "l" },
            new List<string> {"m", "n", "o" },
            new List<string> {"p", "q", "r", "s" },
            new List<string> {"t", "u", "v" },
            new List<string> {"w", "x", "y", "z" },
        };

        var numberDigitList = digits.Select(x => Int32.Parse(x.ToString())).ToList();

        return ProduceLetterCombinationsReccursively(numberDigitList, phoneCombinations, string.Empty);
    }

    //EDKO - current implementation does not support correct enumeration. We need to enumerate by letters under digits, not digits itself
    private static List<string> ProduceLetterCombinationsReccursively(List<int> digits, List<List<string>> phoneCombinations, string currentCompination)
    {
        var result = new List<string>();

        if(digits.Count == 1)
        {
            foreach(var letter in phoneCombinations[digits[0] - 1]) { 
                result.Add(currentCompination +  letter);
            }
            return result;
        }

        for (int i = 0; i < digits.Count; i++)
        {
            var reducedDigits = digits.Except(new List<int> { digits[i] }).ToList();

            for (int j = 0; j < phoneCombinations[digits[i]].Count; j++)
            {
                result.AddRange(ProduceLetterCombinationsReccursively(reducedDigits, phoneCombinations, currentCompination + phoneCombinations[digits[i] - 1][j]));
            }
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
