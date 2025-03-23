using LeetCodeTasks.Helpers;
using System.Linq;

namespace LeetCodeTasks.LeetCode;

public class Arrays
{
    #region #1480

    public static int[] RunningSum(int[] nums)
    {
        int arrayLength = nums.Length;
        int[] resultArr = new int[arrayLength];
        resultArr[0] = nums[0];
        for (int i = 1; i < arrayLength; i++)
        {
            resultArr[i] = resultArr[i - 1] + nums[i];
        }
        return resultArr;
    }

    #endregion

    #region #1672

    public static int MaximumWealth(int[][] accounts)
    {
        int maxVal = 0;
        int currWealth = 0;
        for (int i = 0; i < accounts.Length; i++)
        {
            for (int j = 0; j < accounts[i].Length; j++)
            {
                currWealth += accounts[i][j];
            }
            if (currWealth > maxVal)
            {
                maxVal = currWealth;
            }

            currWealth = 0;
        }
        return maxVal;
    }

    #endregion

    #region #412 - non optimal

    public static IList<string> FizzBuzz(int n)
    {
        var res = new List<string>(n);
        for (int i = 1; i <= n; i++)
        {
            if (i % 3 == 0 && i % 5 == 0)
            {
                res.Add("FizzBuzz");
            }
            else if (i % 3 == 0)
            {
                res.Add("Fizz");
            }
            else if (i % 5 == 0)
            {
                res.Add("Buzz");
            }
            else
            {
                res.Add(i.ToString());
            }
        }
        return res;
    }

    #endregion

    #region #1342
    public static int NumberOfSteps(int num)
    {
        int numberOfSteps = 0;
        while (true)
        {
            if (num == 0)
            {
                break;
            }

            numberOfSteps++;
            num = num / 2;

            if (num == 0)
            {
                break;
            }

            if (num % 2 == 1)
            {
                num -= 1;
                numberOfSteps++;
            }
        }
        return numberOfSteps;
    }

    #endregion

    #region #876

    public static ListNode MiddleNode(ListNode head)
    {
        if (head.next == null)
        {
            return head;
        }

        if (head.next.next == null)
        {
            return head.next;
        }

        int nodeCounter = 3;
        ListNode currentMiddle = head.next;
        ListNode currentNode = head.next.next;
        while (true)
        {
            if (currentNode.next == null)
            {
                break;
            }

            nodeCounter++;
            currentNode = currentNode.next;

            if (nodeCounter % 2 == 0)
            {
                currentMiddle = currentMiddle.next;
            }
        }

        return currentMiddle;
    }

    #endregion

    #region # 383 - non optimal

    public static bool CanConstruct(string ransomNote, string magazine)
    {
        var ransomArr = ransomNote.ToCharArray();
        var magArr = magazine.ToCharArray();
        Array.Sort(ransomArr);
        Array.Sort(magArr);
        bool accepted = true;
        int magCounter = 0;

        for (int i = 0; i < ransomNote.Length; i++)
        {
            for (int j = magCounter; j < magazine.Length; j++)
            {
                if (ransomArr[i] == magArr[j])
                {
                    if (i == ransomArr.Length - 1)
                    {
                        //no need to iterate
                        break;
                    }
                    magCounter++;
                    break;
                }

                magCounter++;
            }

            if (magCounter >= magazine.Length)
            {
                accepted = false;
                break;
            }

        }
        return accepted;
    }

    #endregion

    #region #383 - 2. Try not to allocate arrays of chars

    public static bool CanConstruct2(string ransomNote, string magazine)
    {
        if (magazine.Length < ransomNote.Length)
        {
            return false;
        }

        bool accepted = true;
        var charUsage = new bool[magazine.Length];
        var magArr = magazine.ToCharArray();

        for (int i = 0; i < ransomNote.Length; i++)
        {
            for (int j = 0; j < magazine.Length; j++)
            {
                if (ransomNote[i] != magArr[j] || charUsage[j])
                {
                    // count to end and no match
                    if (j == magazine.Length - 1)
                    {
                        accepted = false;
                        break;
                    }

                    continue;
                }
                else
                {
                    charUsage[j] = true;
                    break;
                }


            }
        }
        return accepted;
    }

    #endregion

    #region FindMaxConsecutiveOnes

    public static int FindMaxConsecutiveOnes(int[] nums)
    {
        int maxConsecutiveOnes = 0;
        int tempConsecutiveOnes = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0)
            {
                if (tempConsecutiveOnes > maxConsecutiveOnes)
                {
                    maxConsecutiveOnes = tempConsecutiveOnes;
                }
                tempConsecutiveOnes = 0;
            }
            else
            {
                tempConsecutiveOnes++;
            }
        }

        return maxConsecutiveOnes > tempConsecutiveOnes ? maxConsecutiveOnes : tempConsecutiveOnes;
    }

    #endregion

    #region #1 - Runtime unoptimal

    public static int[] TwoSum(int[] nums, int target)
    {
        int[] output = new int[2];
        bool seqFound = false;
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target)
                {
                    output[0] = i;
                    output[1] = j;
                    seqFound = true;
                    break;
                }
            }
            if (seqFound)
            {
                break;
            }
        }

        return output;
    }


    #region #1(2) - Better performance

    public static int[] TwoSum2(int[] nums, int target)
    {
        int[] output = [0, 0];
        int[] valuesInPos = new int[2];
        int[] copyOfInput = new int[nums.Length];
        Array.Copy(nums, copyOfInput, nums.Length);
        Array.Sort(copyOfInput);

        for (int i = 0; i < nums.Length; i++)
        {
            int pos = Array.BinarySearch(copyOfInput, i + 1, copyOfInput.Length - i - 1, target - copyOfInput[i]);

            if (pos > 0)
            {
                valuesInPos[0] = copyOfInput[i];
                valuesInPos[1] = copyOfInput[pos];
                break;
            }
        }

        bool firstSet = false;
        bool secondSet = false;
        for (int j = 0; j < nums.Length; j++)
        {
            if (nums[j] == valuesInPos[0] && !firstSet)
            {
                firstSet = true;
                output[0] = j;
            }
            else if (nums[j] == valuesInPos[1] && !secondSet)
            {
                secondSet = true;
                output[1] = j;
            }

            if (firstSet && secondSet)
            {
                break;
            }
        }

        return output;
    }

    #endregion

    #region #1 - Hash = Beat 99%

    public static int[] TwoSum3(int[] nums, int target)
    {
        int[] output = new int[2];

        //Dictionary<int, int> keyValuePairs = nums
        //    .Select((v, i) => new { Key = i, Value = v })
        //    .ToDictionary(o => o.Key, o => o.Value);

        Dictionary<int, int> valuePosPairs = new Dictionary<int, int>(nums.Length);

        valuePosPairs[nums[0]] = 0;

        for (int i = 1; i < nums.Length; i++)
        {
            if (valuePosPairs.TryGetValue(target - nums[i], out int pos))
            {
                output[0] = pos;
                output[1] = i;
                break;
            }

            if (valuePosPairs.ContainsKey(nums[i]))
            {
                continue;
            }

            valuePosPairs[nums[i]] = i;
        }

        return output;
    }

    #endregion

    #endregion


}
