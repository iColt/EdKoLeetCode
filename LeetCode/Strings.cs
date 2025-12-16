using LeetCodeTasks.Helpers;
using System.Text;

namespace LeetCodeTasks.LeetCode;

public static class Strings
{
    #region 3 Longest Substring without repeating characters - 26/52 - poor runtime

    public static int LengthOfLongestSubstring(string s)
    {
        if(s.Length < 2)
        {
            return s.Length;
        }

        int maxConsLenght = 0;
        int currConsLenght = 0;

        char[] chars = s.ToCharArray();

        HashSet<char> uniqueSymbols = new HashSet<char>();

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
                currConsLenght = i - indexOfPreviousInserted;
                uniqueSymbols.Clear();
                for(int j = indexOfPreviousInserted + 1; j <= i; j++) {
                    uniqueSymbols.Add(chars[j]);
                }

            }
        }


        return currConsLenght > maxConsLenght ? currConsLenght : maxConsLenght;
    }

    #endregion

    #region 13 Roman to Integer - 9/14 - poor performace || 71.5/74 runtume/memory with one loop and +- approach

    public static int RomanToIntOld(string s)
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

    public static int RomanToInt(string s)
    {
        var map = new Dictionary<char, int>
        {
            ['I'] = 1,
            ['V'] = 5,
            ['X'] = 10,
            ['L'] = 50,
            ['C'] = 100,
            ['D'] = 500,
            ['M'] = 1000
        };

        int total = 0;

        for (int i = 0; i < s.Length; i++)
        {
            int value = map[s[i]];

            if (i + 1 < s.Length && map[s[i + 1]] > value)
            {
                total -= value;
            }
            else
            {
                total += value;
            }
        }

        return total;
    }

    #endregion

    #region 17 - Letter combination of phone number - 5/5 - poor runtime and memory(Old), 100/24.4 - nice runtime, poor memory management

    public static IList<string> LetterCombinationsOld(string digits)
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

    public static IList<string> LetterCombinations(string digits)
    {
        if (string.IsNullOrEmpty(digits))
            return new List<string>();

        var map = new Dictionary<char, string>
        {
            ['2'] = "abc",
            ['3'] = "def",
            ['4'] = "ghi",
            ['5'] = "jkl",
            ['6'] = "mno",
            ['7'] = "pqrs",
            ['8'] = "tuv",
            ['9'] = "wxyz"
        };

        var result = new List<string>();
        var current = new StringBuilder();

        void Backtrack(int index)
        {
            if (index == digits.Length)
            {
                result.Add(current.ToString());
                return;
            }

            string letters = map[digits[index]];
            foreach (char c in letters)
            {
                current.Append(c);
                Backtrack(index + 1);
                current.Length--;
            }
        }

        Backtrack(0);
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

    #region 125 - 62/27.5 poor memory one more time

    public static bool IsPalindrome(string s)
    {
        if(s.Length < 2)
        {
            return true;
        }

        int startPointer = 0;
        
        string lower = s.ToLower();
        var collection = lower.ToCharArray().Where(x => ((int)x > 96 && (int)x < 123) || ((int)x > 47 && (int)x < 58)).ToArray();
        while (startPointer < collection.Length / 2)
        {
            if (collection[startPointer] != collection[collection.Length - startPointer - 1]) { return false; }
            startPointer++;
        }


        return true;
    }

    #endregion

    #region 131 Palindrome Partioning - Not Solved

    public static IList<IList<string>> Partition(string s)
    {
        return new List<IList<string>>();
    }

    #endregion

    #region 168 - Excel Sheet Column Title - 100/98

    public static string ConvertToTitle(int columnNumber)
    {
        if(columnNumber == 1)
        {
            return "A";
        }
        var result = new StringBuilder();

        while (columnNumber > 0)
        {
            columnNumber--;
            int remainder = columnNumber % 26;
            char c = (char)('A' + remainder);
            result.Insert(0, c);
            columnNumber /= 26;
        }

        return result.ToString();
    }

    #endregion
}
