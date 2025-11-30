using LeetCodeTasks.Helpers;

namespace LeetCodeTasks.LeetCode;

public static class Strings
{
    #region 3 Longest Substring without repeating characters

    public static int LengthOfLongestSubstring(string s)
    {
        if(s.Length < 2)
        {
            return s.Length;
        }

        int maxConsLenght = 0;
        int currConsLenght = 0;
        // use HashSet<char>?
        // when find duplicate - save Max 
        char[] chars = s.ToCharArray();

        HashSet<char> uniqueSymbols = new HashSet<char>();
        int pointerToHashSet = 0;

        for(int i = 0; i < chars.Length; i++)
        {
            int currentUniqueSetLength = uniqueSymbols.Count;

            uniqueSymbols.Add(chars[i]);

            if(currentUniqueSetLength != uniqueSymbols.Count)
            {
                currConsLenght++;
            }
            else
            {
                if(currConsLenght > maxConsLenght)
                {
                    maxConsLenght = currConsLenght;
                }

                int indexOfPreviousInserted = s.IndexOf(chars[i], i - currentUniqueSetLength);
            }
        }


        return currConsLenght > maxConsLenght ? currConsLenght : maxConsLenght;
    }

    #endregion

    #region 13 Roman to Integer - 9/14 - poor performace

    public static int RomanToInt(string s)
    {
        int number = 0;

        if(s.Length == 1)
        {
            return RomanNumbers.RomanNumberToIntegerMap[s];
        }

        if(RomanNumbers.CommonUsedRomanIntegers.TryGetValue(s, out number))
        {
            return number;
        }

        var reversed = s.Reverse().ToArray();
        int romanNumberLength = s.Length;
        int currentIterator = 0;

        while(currentIterator < romanNumberLength)
        {
            var currentDigit = reversed[currentIterator++];

            // case when number like VIII
            if(currentDigit == 'I')
            {
                int result = 1;
                if(reversed[currentIterator] == 'I')
                {
                    result++;
                    currentIterator++;
                    if (reversed[currentIterator] == 'I')
                    {
                        result++;
                        currentIterator++;
                    }
                }
                number += result;
                continue;
            }

            // it will not produce error as 1, 2, 3 already covered by CommonUsedRomanIntegers
            if (currentIterator < romanNumberLength && RomanNumbers.ReducedRomanIntegers.TryGetValue($"{reversed[currentIterator]}{currentDigit}", out int value))
            {
                number += value;
                currentIterator++;
            } else
            {
                number += RomanNumbers.RomanNumberToIntegerMap[currentDigit.ToString()];
            }
        }

        return number;
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
