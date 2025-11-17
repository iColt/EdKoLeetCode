using LeetCodeTasks.Helpers;

namespace LeetCodeTasks.LeetCode;

public class Arrays
{
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

    #region 15 3Sum

    public static IList<IList<int>> ThreeSum(int[] nums)
    {
        List<IList<int>> result = new List<IList<int>>();

        Array.Sort(nums);

        // handle case, when count of 0 >= 3
        var zerosCount = nums.Where(i => i == 0).Count();
        if(zerosCount >= 3)
        {
            result.Add(new List<int> { 0, 0, 0 });
        }
        //set array to Distinct mode, as the task requires this
        var distinctNums = nums.Distinct().ToArray();
        int anyZeroPosition = Array.BinarySearch(distinctNums, 0);

        ThreeSumReccursive(distinctNums, result, anyZeroPosition, 0, InitializeNewEmptyArray(), 0);

        return result;
    }

    private static void ThreeSumReccursive(int[] nums, List<IList<int>> result, int zeroPos, int currentSum, int[] currentUsedElements, int currentStep)
    {
        //we don't need more check, we just need to find positive value that passes
        if (currentStep == 2)
        {
            int searchValue = currentSum * -1;
            // if temp sum > max element in array - no need to search
            if (searchValue > nums[nums.Length - 1])
            {
                return;
            }
            int sumPosition = Array.BinarySearch(nums, searchValue);
            if(sumPosition >= 0) {
                currentUsedElements[2] = nums[sumPosition];
            }
            result.Add(currentUsedElements);
            return;
        }

        //if this is the step 0 - iterate only until zero, in other case - until the end
        int breakdownIndex = currentStep == 0 ? zeroPos : nums.Length;

        for(int i = currentStep; i < breakdownIndex; i++)
        {
            //asap we reach 0 on first step - no need to continue
            if (currentStep == 0 && nums[i] == 0)
            {
                return;
            }

            currentSum += nums[i];
            currentUsedElements[currentStep] = nums[i];
            
            var currentUsedElementsTemp = InitializeNewEmptyArray();
            Array.Copy(currentUsedElements, currentUsedElementsTemp, 3);
            int nextStep = currentStep + 1;
            ThreeSumReccursive(nums, result, zeroPos, currentSum, currentUsedElementsTemp, nextStep);
        }
    }

    private static int[] InitializeNewEmptyArray()
    {
        var result = new int[3];
        for (int i = 0; i < result.Length; i++)
        {
            // we can set this because in the task definition result[i] cannot be > 10^5
            result[i] = int.MaxValue;
        }
        return result;
    }

    #endregion

    #region 26 - Remove Duplicates from Sorted Array - non optimal memory

    public static int RemoveDuplicates(int[] nums)
    {
        int currentElementIndex = 0;
        int exchangeElementIndex = currentElementIndex + 1;

        int currentUniqueElement = nums[currentElementIndex];
        while (true)
        {
            if(nums.Length == exchangeElementIndex)
            {
                break;
            }

            if(currentUniqueElement < nums[exchangeElementIndex])
            {
                currentUniqueElement = nums[exchangeElementIndex];
                nums[++currentElementIndex] = currentUniqueElement;
            }

            exchangeElementIndex++;
        }
        return currentElementIndex + 1;
    }

    #endregion

    #region #27 - RemoveElement - Optimal runtime, non-optimal memory (70%)

    public static int RemoveElement(int[] nums, int val)
    {
        int length = nums.Length;
        int currentElementFromNoseIndex = 0;
        int currElementFromTailIndex = length - 1;
        while(true)
        {
            if (currentElementFromNoseIndex == nums.Length || currentElementFromNoseIndex > currElementFromTailIndex) { break; }

            if (nums[currentElementFromNoseIndex] == val)
            {
                bool found = false;
                for(int i = currElementFromTailIndex; i > currentElementFromNoseIndex; i--)
                {
                    if (nums[i] != val)
                    {
                        found = true;
                        nums[currentElementFromNoseIndex] = nums[i];
                        nums[i] = val;
                        currElementFromTailIndex = i - 1;
                        break;
                    }
                }
                if(!found)
                {
                    break;
                }
            }

            currentElementFromNoseIndex++;
        }

        return currentElementFromNoseIndex;
    }

    #endregion

    #region 35 - Search Insert Position - 100/66.5

    public static int SearchInsert(int[] nums, int target)
    {
        return ArraysHelper.FindPosBinarySearch(nums, target);
    }

    #endregion

    #region 39 - Combination Sum - 5/5 - poor performance and memory consumption

    public static IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        Array.Sort<int>(candidates);

        // Need to initialize it, so that we can avoid duplicates
        // And avoid post-processing of result List
        List<IList<int>> result = new List<IList<int>>();

        CombinationSumReccursive(candidates, target, result, new List<int>(), 0);

        return result;
    }

    private static void CombinationSumReccursive(int[] candidates, int target, List<IList<int>> result, IList<int> currentEnum, int currentSumFromEnum)
    {
        for(int i = 0; i < candidates.Length; i++)
        {
            int currentPartialSum = candidates[i] + currentSumFromEnum;

            if(currentPartialSum == target)
            {
                var copyOfCurrent = new int[currentEnum.Count + 1];
                currentEnum.CopyTo(copyOfCurrent, 0);
                copyOfCurrent[currentEnum.Count] = candidates[i];
                //we need to check if similar array already added
                bool exist = false;
                foreach(var entry in result)
                {
                    if(AreEquivalentDistinct(entry, copyOfCurrent.ToList<int>()))
                    {
                        exist = true;
                    }
                }
                if(!exist)
                {
                    result.Add(copyOfCurrent);
                }
                // If sub array fits = no need to continue this 
                continue;
            }

            if(currentPartialSum > target)
            {
                // if additional value will increase sum > target - this set should be removed
                continue;
            }

            if(currentPartialSum < target)
            {
                var copyOfCurrent = new int[currentEnum.Count + 1];
                currentEnum.CopyTo(copyOfCurrent, 0);
                copyOfCurrent[currentEnum.Count] = candidates[i];
                // if currentPartialSum still < target, we call reccursively the same function
                CombinationSumReccursive(candidates, target, result, copyOfCurrent, currentPartialSum);
            }
        }

        return;
    }

    static bool AreEquivalentDistinct<T>(IList<T> a, IList<T> b)
    {
        if (a.Count != b.Count)
        {
            return false;
        }

        var sortedA = a.OrderBy(x => x).ToArray();
        var sortedB = b.OrderBy(x => x).ToArray();

        return sortedA.SequenceEqual(sortedB);
    }

    #endregion

    #region 46 - Permutations - 100/35.3. Non-optimal memory

    public IList<IList<int>> Permute(int[] nums)
    {
        return ArraysHelper.PermuteArray(nums);
    }

    #endregion

    #region 66 - Plus one - 100/51

    public static int[] PlusOne(int[] digits)
    {
        bool shouldAddOne = true;


        for(int i = digits.Length - 1; i >= 0; i--)
        {
            if(shouldAddOne)
            {
                digits[i] = digits[i] + 1;
                if (digits[i] != 10)
                {
                    shouldAddOne = false;
                    break;
                } else
                {
                    digits[i] = 0;
                }
            }
        }

        if(shouldAddOne)
        {
            Array.Resize(ref digits, digits.Length + 1);
            digits[0] = 1;
        }

        return digits;
    }

    #endregion

    #region 88 Merge Sorted Array - 100/40.5 Non optimal memory

    public static void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        // if second array empty - return just first one
        if(n == 0)
        {
            return;
        }
        if(m == 0)
        {
            for(int i = 0; i < n; i++)
            {
                nums1[i] = nums2[i];
            }
            return;
        }

        int firstArrayUsageCounter = m - 1;
        int secondArrayUsageCounter = n - 1;

        // pointer to position, that will be used to set values
        int commonPositionMarker = m + n -1;

        while(true)
        {
            if((firstArrayUsageCounter < 0 && secondArrayUsageCounter < 0) || commonPositionMarker < 0) {
                break;
            }

            //if first consumed - just fill num1 with rest of values
            if(firstArrayUsageCounter < 0)
            {
                for(int i = secondArrayUsageCounter; i >= 0; i--)
                {
                    nums1[commonPositionMarker] = nums2[i];
                    commonPositionMarker--;
                }
                break;
            }

            //if second already consumed - no need to do anything
            if(secondArrayUsageCounter < 0)
            {
                break;
            }

            if (nums1[firstArrayUsageCounter] >= nums2[secondArrayUsageCounter])
            {
                nums1[commonPositionMarker] = nums1[firstArrayUsageCounter];
                firstArrayUsageCounter--;
            } else
            if (nums1[firstArrayUsageCounter] < nums2[secondArrayUsageCounter])
            {
                nums1[commonPositionMarker] = nums2[secondArrayUsageCounter];
                secondArrayUsageCounter--;
            }

            commonPositionMarker--;
        }
    }

    #endregion

    #region 383 Ramsone note - Solved

    #region # 383 Ramsone note 61/19 - non optimal

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

    #region #485 - Find Max Consecutive Ones - 100/81

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

    #region #876 - Middle of the linked list - 100/27

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

    #region #1342 - Number of Steps to Reduce a Number to Zero - 100/88
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

    #region #1480 - Running Sum of 1d Array - 100/54

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

    #region #1672 - Richest Customer Wealth - 100/21 non-optimal memory

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
}
