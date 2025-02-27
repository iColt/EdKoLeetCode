using LeetCodeTasks.Helpers;

namespace LeetCodeTasks.LeetCode;

internal class Arrays
{
    // #1480
    public int[] RunningSum(int[] nums)
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

    // #1672
    public int MaximumWealth(int[][] accounts)
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

    // #412 - non optimal
    public IList<string> FizzBuzz(int n)
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

    // #1342
    public int NumberOfSteps(int num)
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

    // #876
    public ListNode MiddleNode(ListNode head)
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

    public bool CanConstruct(string ransomNote, string magazine)
    {
        var x = ransomNote.ToCharArray();
        return true;
    }
}
