using LeetCodeTasks.Helpers;

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

        for (int i = 0; i< ransomNote.Length; i++)
        {
            for(int j = magCounter; j < magazine.Length; j++ )
            {
                if (ransomArr[i] == magArr[j])
                {
                    if(i == ransomArr.Length - 1)
                    {
                        //no need to iterate
                        break;
                    }
                    magCounter++;
                    break;
                }

                magCounter++;
            }

            if(magCounter >= magazine.Length)
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
            for(int j = 0; j < magazine.Length; j++)
            {
                if (ransomNote[i] != magArr[j] || charUsage[j])
                {
                    // count to end and no match
                    if (j == magazine.Length - 1) {
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

    #region 



    #endregion
}
