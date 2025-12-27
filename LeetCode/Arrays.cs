using LeetCodeTasks.Helpers;
using System.Text;

namespace LeetCodeTasks.LeetCode;

public static class Arrays
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

    #region 15 3Sum - 45/51 Medium

    public static IList<IList<int>> ThreeSum(int[] nums)
    {
        Array.Sort(nums);
        var result = new List<IList<int>>();

        for (int i = 0; i < nums.Length - 2; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1])
            {
                continue;
            }

            int left = i + 1;
            int right = nums.Length - 1;

            while (left < right)
            {
                int sum = nums[i] + nums[left] + nums[right];

                if (sum == 0)
                {
                    result.Add(new List<int> { nums[i], nums[left], nums[right] });

                    // skip duplicates
                    while (left < right && nums[left] == nums[left + 1]) left++;
                    while (left < right && nums[right] == nums[right - 1]) right--;

                    left++;
                    right--;
                }
                else if (sum < 0)
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }
        }

        return result;
    }

    #region Old

    public static IList<IList<int>> ThreeSum2(int[] nums)
    {
        List<IList<int>> result = new List<IList<int>>();

        Array.Sort(nums);

        // handle case, when count of 0 >= 3
        var zerosCount = nums.Where(i => i == 0).Count();
        if(zerosCount >= 3)
        {
            result.Add(new List<int> { 0, 0, 0 });
        }
        int anyZeroPosition = Array.BinarySearch(nums, 0);
        if(anyZeroPosition < 0)
        {
            // if < 0, need to find first element > 0
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0)
                {
                    anyZeroPosition = i;
                    break;
                }
            }
        }

        ThreeSumReccursive(nums, result, anyZeroPosition, 0, InitializeNewEmptyArray(), 0, 0);

        return result;
    }

    private static void ThreeSumReccursive(int[] nums, List<IList<int>> result, int zeroPos, int currentSum, int[] currentUsedElements, int currentStep, int currentElementIndex)
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
            // search starting from current element only
            int sumPosition = Array.BinarySearch(nums, currentElementIndex, nums.Length - currentElementIndex, searchValue);
            if(sumPosition >= 0) {
                currentUsedElements[2] = nums[sumPosition];
                result.Add(currentUsedElements);
            }
            return;
        }

        //if this is the step 0 - iterate only until zero, in other case - until the end
        int breakdownIndex = currentStep == 0 ? zeroPos : nums.Length;

        for(int i = currentElementIndex; i < breakdownIndex; i++)
        {
            //asap we reach 0 on first step - no need to continue
            if (currentStep == 0 && nums[i] == 0)
            {
                return;
            }
            //if current element equals previous - no need to analyze it as all possible situations already discovered on previous step
            // [-1 0 0 1]
            // [-4 -1 -1 -1 0 1 2]
            // [-4 -1 -1 0 1 2]
            if (currentStep == 0 && i > 0 && nums[i] == nums[i - 1])
            {
                continue;
            }
            if(currentStep == 1 && i - currentElementIndex > 0 && nums[i] == nums[currentElementIndex])
            {
                continue;
            }

            int copyOfCurrentSum = currentSum;
            copyOfCurrentSum += nums[i];
            currentUsedElements[currentStep] = nums[i];
            
            // If sum negative, but we already used last element - no need to iterate further
            if(copyOfCurrentSum < 0 && i == nums.Length - 1)
            {
                return;
            }

            var currentUsedElementsTemp = InitializeNewEmptyArray();
            Array.Copy(currentUsedElements, currentUsedElementsTemp, 3);
            int nextStep = currentStep + 1;
            ThreeSumReccursive(nums, result, zeroPos, copyOfCurrentSum, currentUsedElementsTemp, nextStep, i + 1);
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

    #region 39 - Combination Sum - 5/5 - poor performance and memory consumption (Old) || 44.8 / 96.5% Runtime/Memory (New)

    public static IList<IList<int>> CombinationSumOld(int[] candidates, int target)
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

    public static IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        List<IList<int>> result = new List<IList<int>>();

        // try to use backtail reccursive instead of difficult one from me
        // if we already switched to next digit
        // do not join previous one
        // this will garantee unique without stupid checks

        int temporarySum = 0;
        List<int> searchedSet = new List<int>();

        for(int i = 0; i < candidates.Length; i++)
        {
            searchedSet.Add(candidates[i]);
            int searchedSetCount = searchedSet.Count;
            temporarySum += candidates[i];
            BackTrack(i);
            temporarySum -= candidates[i];
            searchedSet.RemoveAt(searchedSetCount - 1);
        }

        void BackTrack(int index)
        {
            if(temporarySum > target)
            {
                return;
            }

            if(temporarySum == target)
            {
                List<int> temp = [.. searchedSet];
                result.Add(temp);
                return;
            }

            for(int j = index; j <  candidates.Length; j++)
            {
                searchedSet.Add(candidates[j]);
                int searchedSetCount = searchedSet.Count;
                temporarySum += candidates[j];
                BackTrack(j);
                temporarySum -= candidates[j];
                searchedSet.RemoveAt(searchedSetCount - 1);
            }
        }

        return result;
    }

    #endregion

    #region 46 - Permutations - 100/35.3. Non-optimal memory

    public static IList<IList<int>> Permute(int[] nums)
    {
        return ArraysHelper.PermuteArray(nums);
    }

    #endregion

    #region 56 Merge Intervals

    public static int[][] Merge(int[][] intervals)
    {
        return intervals;
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

    #region 73 Set Matrix Zeroes - 100/21.9

    public static void SetZeroes(int[][] matrix)
    {
        int rows = matrix.Length;
        int cols = matrix[0].Length;

        bool firstRowZero = false;
        bool firstColZero = false;

        for (int j = 0; j < cols; j++)
        {
            if (matrix[0][j] == 0)
            {
                firstRowZero = true;
                break;
            }
        }

        for (int i = 0; i < rows; i++)
        {
            if (matrix[i][0] == 0)
            {
                firstColZero = true;
                break;
            }
        }

        for (int i = 1; i < rows; i++)
        {
            for (int j = 1; j < cols; j++)
            {
                if (matrix[i][j] == 0)
                {
                    matrix[i][0] = 0;
                    matrix[0][j] = 0;
                }
            }
        }

        for (int j = 1; j < cols; j++)
        {
            if (matrix[0][j] == 0)
            {
                for (int i = 1; i < rows; i++)
                {
                    matrix[i][j] = 0;
                }
            }
        }

        for (int i = 1; i < rows; i++)
        {
            if (matrix[i][0] == 0)
            {
                for (int j = 1; j < cols; j++)
                {
                    matrix[i][j] = 0;
                }
            }
        }

        if (firstRowZero)
        {
            for (int j = 0; j < cols; j++)
                matrix[0][j] = 0;
        }

        if (firstColZero)
        {
            for (int i = 0; i < rows; i++)
                matrix[i][0] = 0;
        }
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

    #region 118 Pascal's triangle - 50/12 non optimal memory

    public static IList<IList<int>> Generate(int numRows)
    {
        IList<IList<int>> result = new List<IList<int>>
        {
            new List<int> { 1 }
        };

        if(numRows == 1)
        {
            return result;
        }

        for(int i = 1; i < numRows; i++)
        {
            var nextLevelOfPyramid = new List<int> { 1 };

            for(int j = 1; j < i; j ++)
            {
                nextLevelOfPyramid.Add(
                    result[i - 1][j - 1] + result[i - 1][j]
                    );
            }

            nextLevelOfPyramid.Add(1);
            result.Add(nextLevelOfPyramid);
        }

        return result;
    }

    #endregion

    #region 136 Single number - 28.9/19.5 Bad results || 100/86 new results

    public static int SingleNumberOld(int[] nums)
    {
        if(nums.Length == 1)
        {
            return nums[0];
        }

        HashSet<int> visited = new HashSet<int>();
        for (int i = 0; i < nums.Length; i++)
        {
            int currentHashSetLength = visited.Count;
            visited.Add(nums[i]);
            if(currentHashSetLength == visited.Count)
            {
                visited.Remove(nums[i]);
            }
        }

        return visited.First();
    }

    public static int SingleNumber(int[] nums)
    {
        int result = 0;

        foreach (int num in nums)
        {
            result ^= num;
        }

        return result;
    }

    #endregion

    #region 137 Single Number II - 17.5/44.2% Poor performance || 100/35 poor memory management

    public static int SingleNumberIIOld(int[] nums)
    {
        if (nums.Length == 1)
        {
            return nums[0];
        }

        HashSet<int> visited = new HashSet<int>();
        HashSet<int> doubleVisited = new HashSet<int>();
        for (int i = 0; i < nums.Length; i++)
        {
            int currentHashSetLength = visited.Count;
            visited.Add(nums[i]);
            if (currentHashSetLength == visited.Count)
            {
                int currentSecondHashSetLength = doubleVisited.Count;
                doubleVisited.Add(nums[i]);
                if(doubleVisited.Count == currentSecondHashSetLength)
                {
                    visited.Remove(nums[i]);
                    doubleVisited.Remove(nums[i]);
                }
            }
        }

        return visited.First();
    }

    public static int SingleNumberII(int[] nums)
    {
        int ones = 0, twos = 0;

        foreach (int num in nums)
        {
            ones = (ones ^ num) & ~twos;
            twos = (twos ^ num) & ~ones;
        }

        return ones;
    }

    #endregion

    #region 179 Largest Number - 27/65 poor performance

    public static string LargestNumberOld(int[] nums)
    {
        Array.Sort(nums);
        StringBuilder sb = new();
        StringBuilder zeroSB = new();
        StringBuilder zeroEndingSb = new();
        int iterator = 0;
        int lowSeparator = 1;
        int highSeparator = 10;
        while(iterator < nums.Length)
        {
            if (nums[iterator] == 0)
            {
                zeroSB.Append("0");
                iterator++;
            } else if (nums[iterator] >= lowSeparator && nums[iterator] < highSeparator)
            {
                StringBuilder tempSb = new();
                while(nums[iterator] < highSeparator)
                {
                    if (nums[iterator] % 10 == 0)
                    {
                        zeroEndingSb.Insert(0, nums[iterator++]);
                    } else
                    {
                        tempSb.Insert(0, nums[iterator++]);
                    }

                    if (iterator >= nums.Length)
                    {
                        break;
                    }
                }
                sb.Insert(0, tempSb);
            }


            if (iterator >= nums.Length)
            {
                break;
            }

            if (nums[iterator] >= highSeparator)
            {
                lowSeparator *= 10; 
                if(highSeparator > int.MaxValue / 10)
                {
                    highSeparator = int.MaxValue;
                } else
                {
                    highSeparator *= 10;
                }
            }
        }

        sb.Append(zeroEndingSb.ToString());
        sb.Append(zeroSB.ToString());
        return sb.ToString();
    }

    public static string LargestNumber(int[] nums)
    {
        var strings = nums.Select(n => n.ToString()).ToArray();

        Array.Sort(strings, (a, b) => (b + a).CompareTo(a + b));

        if (strings[0] == "0")
            return "0";

        return string.Concat(strings);
    }

    #endregion

    #region 228 Summary Ranges - 64/20 poor memory management

    public static IList<string> SummaryRanges(int[] nums)
    {
        int counter = 0;
        var result = new List<string>();
        if (nums.Length == 0)
        {
            return result;
        }
        if(nums.Length == 1)
        {
            result.Add(nums[0].ToString());
            return result;
        }

        while(counter < nums.Length)
        {
            int startIndex = counter;

            int endIndex = counter + 1;
            
            if(endIndex >= nums.Length)
            {
                result.Add(nums[startIndex].ToString());
                break;
            }

            while(true)
            {
                if (endIndex >= nums.Length)
                {
                    endIndex--;
                    break;
                }
                if (nums[endIndex] == nums[endIndex - 1])
                {
                    break;
                }

                if (nums[endIndex - 1] + 1 == nums[endIndex])
                {
                    endIndex++;
                    continue;
                } else
                {
                    endIndex--;
                    break;
                }
            }

            if(startIndex == endIndex)
            {
                result.Add(nums[startIndex].ToString());
            } else
            {
                result.Add($"{nums[startIndex]}->{nums[endIndex]}");
            }

            counter = endIndex + 1;
        }

        return result;
    }

    #endregion

    #region 260 Single Number III 19/40 Poor performance in all Single Number tasks

    public static int[] SingleNumberIII(int[] nums)
    {
        if (nums.Length == 2)
        {
            return nums;
        }

        HashSet<int> visited = new HashSet<int>();
        for (int i = 0; i < nums.Length; i++)
        {
            int currentHashSetLength = visited.Count;
            visited.Add(nums[i]);
            if (currentHashSetLength == visited.Count)
            {
                visited.Remove(nums[i]);
            }
        }

        return [visited.First(), visited.Last()];
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

    #region 594 - Longest harmonious subsequence 34/95 runtime+memory. Sorting takes time, but saves memory

    public static int FindLHS(int[] nums)
    {
        if (nums.Length < 2)
        {
            return 0;
        }

        int lengthOfLongest = 0;

        Array.Sort(nums);

        int currentNumber = nums[0];
        int temporaryLength = 1;
        int secondPartCount = -1;
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] == currentNumber)
            {
                temporaryLength++;
                if (secondPartCount > 0)
                {
                    secondPartCount++;
                }
            } else if (Math.Abs(nums[i] - currentNumber) == 1)
            {
                if (secondPartCount == -1) {
                    currentNumber = nums[i];
                    secondPartCount = 1;
                    temporaryLength++;
                } else
                {
                    currentNumber = nums[i];
                    if (lengthOfLongest < temporaryLength)
                    {
                        lengthOfLongest = temporaryLength;
                    }
                    temporaryLength = secondPartCount + 1;
                    secondPartCount = 1;
                }
            } else
            {
                currentNumber = nums[i];
                if (lengthOfLongest < temporaryLength && secondPartCount != -1)
                {
                    lengthOfLongest = temporaryLength;
                }
                temporaryLength = 1;
                secondPartCount = -1;
            }
        }

        if (secondPartCount == -1)
        {
            return lengthOfLongest;
        }

        return lengthOfLongest > temporaryLength ? lengthOfLongest : temporaryLength;
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
