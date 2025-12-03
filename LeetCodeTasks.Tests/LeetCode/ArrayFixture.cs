using System.Linq;

namespace LeetCodeTasks.Tests.LeetCode;
[TestFixture]
public class ArrayFixture
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase("aab", "baa", true)]
    [TestCase("bg", "efjbdfbdgfjhhaiigfhbaejahgfbbgbjagbddfgdiaigdadhcfcj", true)]
    [TestCase("aa", "ab", false)]
    [TestCase("a", "b", false)]
    public void Test_CanConstruct2(string ransom, string magaz, bool result)
    {
        Assert.That(Arrays.CanConstruct2(ransom, magaz), Is.EqualTo(result));
    }

    [TestCase(new int[] { 1, 1, 1, 0, 1, 1, 1, 1 }, 4)]
    [TestCase(new int[] { 1, 1, 1, 0, 1, 1, 1, 1, 0 }, 4)]
    [TestCase(new int[] { 1, 1, 1, 1, 0, 1, 1, 1, 0 }, 4)]
    public void Test_MaxCons(int[] ints, int res)
    {
        Assert.That(Arrays.FindMaxConsecutiveOnes(ints), Is.EqualTo(res));
    }

    [TestCase(new int[] { 0, 3, 3, 0 }, 0, new int[] { 0, 3 })]
    [TestCase(new int[] { -3, 4, 3, 90 }, 0, new int[] { 0, 2 })]
    [TestCase(new int[] { 2, 7, 11, 15 }, 9, new int[] { 0, 1 })]
    [TestCase(new int[] { 3, 2, 4 }, 6, new int[] { 1, 2 })]
    [TestCase(new int[] { 3, 3 }, 6, new int[] { 0, 1 })]
    public void Test_TwoSums(int[] ints, int res, int[] output)
    {
        CollectionAssert.AreEquivalent(Arrays.TwoSum(ints, res), output);
        CollectionAssert.AreEquivalent(Arrays.TwoSum2(ints, res), output);
        CollectionAssert.AreEquivalent(Arrays.TwoSum3(ints, res), output);
    }

    [TestCase(new int[] { 3, 2, 2, 3 }, 3, 2)]
    [TestCase(new int[] { 0, 1, 2, 2, 3, 0, 4, 2 }, 2, 5)]
    public void Test_RemoveElements(int[] ints, int value, int length)
    {
        Assert.That(Arrays.RemoveElement(ints, value), Is.EqualTo(length));
    }

    [TestCase(new int[] { 1, 1, 2 }, 2)]
    [TestCase(new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 }, 5)]
    [TestCase(new int[] { -100, -8, 0, 0, 1, 1, 2, 30, 30, 40 }, 7)]
    public void Test_RemoveDuplicates(int[] ints, int length)
    {
        Assert.That(Arrays.RemoveDuplicates(ints), Is.EqualTo(length));
    }

    [TestCase(new int[] { 1, 3, 5, 6 }, 5, 2)]
    [TestCase(new int[] { 1, 3, 5, 6 }, 2, 1)]
    [TestCase(new int[] { 1, 3, 5, 6 }, 7, 4)]
    public void Test_SearchInsert(int[] nums, int target, int pos)
    {
        Assert.That(Arrays.SearchInsert(nums, target), Is.EqualTo(pos));
    }

    #region 66 - Plus One

    [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2, 4 })]
    [TestCase(new int[] { 1, 2, 9 }, new int[] { 1, 3, 0 })]
    [TestCase(new int[] { 9, 9, 9 }, new int[] { 1, 0, 0, 0 })]
    [TestCase(new int[] { 1, 0, 0 }, new int[] { 1, 0, 1 })]
    [TestCase(new int[] { 9 }, new int[] { 1, 0 })]
    [TestCase(new int[] { 7 }, new int[] { 8 })]
    [TestCase(new int[] { 2, 3, 4 }, new int[] { 2, 3, 5 })]
    [TestCase(new int[] { 4, 3, 9, 9 }, new int[] { 4, 4, 0, 0 })]
    [TestCase(new int[] { 2, 3, 4 }, new int[] { 2, 3, 5 })]
    public void Tets_PlusOne(int[] nums, int[] expected)
    {
        int[] result = Arrays.PlusOne(nums);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Tets_PlusOne_ShouldHandleLargeNumber()
    {
        int[] input = new int[100];
        for (int i = 0; i < input.Length; i++)
            input[i] = 9;

        int[] result = Arrays.PlusOne(input);

        Assert.That(result.Length, Is.EqualTo(101));
        Assert.That(result[0], Is.EqualTo(1));
        Assert.That(result[1], Is.EqualTo(0));
    }

    #endregion

    #region 39

    [TestCase(new int[] { 5, 10, 8, 4, 3, 12, 9 }, 27, 45)]
    [TestCase(new int[] { 2, 3, 6, 7 }, 7, 2)]
    [TestCase(new int[] { 2, 3, 5 }, 8, 3)]
    [TestCase(new int[] { 2 }, 1, 0)]
    public void Test_CombinationSum(int[] candidates, int target, int countOfCombinations)
    {
        CompareTwoCombinations(Arrays.CombinationSum(candidates, target));
        //Assert.That(Arrays.CombinationSum(candidates, target).Count(), Is.EqualTo(countOfCombinations));
    }

    //new List<int> {5,5,5,5,4,3}, new List<int> {5,5,5,8,4}, new List<int> {5,5,5,4,4,4}, new List<int> {5,5,5,3,3,3,3}, new List<int> {5,5,5,3,9}, new List<int> {5,5,5,12}, new List<int> {5,5,10,4,3}, new List<int> {5,5,8,3,3,3}, new List<int> {5,5,8,9}, new List<int> {5,5,4,4,3,3,3}, new List<int> {5,5,4,4,9}, new List<int> {5,10,8,4}, new List<int> {5,10,4,4,4}, new List<int> {5,10,3,3,3,3}, new List<int> {5,10,3,9}, new List<int> {5,10,12}, new List<int> {5,8,8,3,3}, new List<int> {5,8,4,4,3,3}, new List<int> {5,4,4,4,4,3,3}, new List<int> {5,4,3,3,3,3,3,3}, new List<int> {5,4,3,3,3,9}, new List<int> {5,4,3,3,12}, new List<int> {5,4,9,9}, new List<int> {10,10,4,3}, new List<int> {10,8,3,3,3}, new List<int> {10,8,9}, new List<int> {10,4,4,3,3,3}, new List<int> {10,4,4,9}, new List<int> {8,8,8,3}, new List<int> {8,8,4,4,3}, new List<int> {8,4,4,4,4,3}, new List<int> {8,4,3,3,3,3,3}, new List<int> {8,4,3,3,9}, new List<int> {8,4,3,12}, new List<int> {4,4,4,4,4,4,3}, new List<int> {4,4,4,3,3,3,3,3}, new List<int> {4,4,4,3,3,9}, new List<int> {4,4,4,3,12}, new List<int> {3,3,3,3,3,3,3,3,3}, new List<int> {3,3,3,3,3,3,9}, new List<int> {3,3,3,3,3,12}, new List<int> {3,3,3,9,9}, new List<int> {3,3,12,9}, new List<int> {3,12,12}, new List<int> {9,9,9]
    private void CompareTwoCombinations(IList<IList<int>> result)
    {
        List<List<int>> list =
        [
          new List<int> { 5, 5, 5, 5, 4, 3 },
            new List<int> { 5, 5, 5, 8, 4 },
            new List<int> { 5, 5, 5, 4, 4, 4 },
            new List<int> { 5, 5, 5, 3, 3, 3, 3 },
            new List<int> { 5, 5, 5, 3, 9 },
            new List<int> { 5, 5, 5, 12 },
            new List<int> { 5, 5, 10, 4, 3 },
            new List<int> { 5, 5, 8, 3, 3, 3 },
            new List<int> { 5, 5, 8, 9 },
            new List<int> { 5, 5, 4, 4, 3, 3, 3 },
            new List<int> { 5, 5, 4, 4, 9 },
            new List<int> { 5, 10, 8, 4 },
            new List<int> { 5, 10, 4, 4, 4 },
            new List<int> { 5, 10, 3, 3, 3, 3 },
            new List<int> { 5, 10, 3, 9 },
            new List<int> { 5, 10, 12 },
            new List<int> { 5, 8, 8, 3, 3 },
            new List<int> { 5, 8, 4, 4, 3, 3 },
            new List<int> { 5, 4, 4, 4, 4, 3, 3 },
            new List<int> { 5, 4, 3, 3, 3, 3, 3, 3 },
            new List<int> { 5, 4, 3, 3, 3, 9 },
            new List<int> { 5, 4, 3, 3, 12 },
            new List<int> { 5, 4, 9, 9 },
            new List<int> { 10, 10, 4, 3 },
            new List<int> { 10, 8, 3, 3, 3 },
            new List<int> { 10, 8, 9 },
            new List<int> { 10, 4, 4, 3, 3, 3 },
            new List<int> { 10, 4, 4, 9 },
            new List<int> { 8, 8, 8, 3 },
            new List<int> { 8, 8, 4, 4, 3 },
            new List<int> { 8, 4, 4, 4, 4, 3 },
            new List<int> { 8, 4, 3, 3, 3, 3, 3 },
            new List<int> { 8, 4, 3, 3, 9 },
            new List<int> { 8, 4, 3, 12 },
            new List<int> { 4, 4, 4, 4, 4, 4, 3 },
            new List<int> { 4, 4, 4, 3, 3, 3, 3, 3 },
            new List<int> { 4, 4, 4, 3, 3, 9 },
            new List<int> { 4, 4, 4, 3, 12 },
            new List<int> { 3, 3, 3, 3, 3, 3, 3, 3, 3 },
            new List<int> { 3, 3, 3, 3, 3, 3, 9 },
            new List<int> { 3, 3, 3, 3, 3, 12 },
            new List<int> { 3, 3, 3, 9, 9 },
            new List<int> { 3, 3, 12, 9 },
            new List<int> { 3, 12, 12 },
            new List<int> { 9, 9, 9 }
        ];

        foreach (var x in result)
        {
            x.ToList().Sort();
        }

        foreach (var x in list)
        {
            x.Sort();
        }

        var comparer = new UnorderedIntArrayComparer();

        var onlyIn1 = result.Except(list, comparer).ToList();
        var onlyIn2 = list.Except(result, comparer).ToList();
    }

    public class UnorderedIntArrayComparer : IEqualityComparer<IList<int>>
    {
        public bool Equals(IList<int> a, IList<int> b)
        {
            if (a == null || b == null) return a == b;

            if (a.Count != b.Count) return false;

            return a.OrderBy(x => x).SequenceEqual(b.OrderBy(x => x));
        }

        public int GetHashCode(IList<int> arr)
        {
            unchecked
            {
                int hash = 17;

                foreach (var x in arr.OrderBy(v => v))   // normalize ordering
                    hash = hash * 31 + x.GetHashCode();

                return hash;
            }
        }
    }
    #endregion

    // Format:
    // nums1, m, nums2, n, expected
    [TestCase(new int[] { 1, 2, 3, 0, 0, 0 }, 3, new int[] { 2, 5, 6 }, 3, new int[] { 1, 2, 2, 3, 5, 6 })]
    [TestCase(new int[] { 1 }, 1, new int[] { }, 0, new int[] { 1 })]
    [TestCase(new int[] { 0 }, 0, new int[] { 1 }, 1, new int[] { 1 })]
    [TestCase(new int[] { 2, 0 }, 1, new int[] { 1 }, 1, new int[] { 1, 2 })]
    [TestCase(new int[] { 4, 5, 6, 0, 0, 0 }, 3, new int[] { 1, 2, 3 }, 3, new int[] { 1, 2, 3, 4, 5, 6 })]
    [TestCase(new int[] { 1, 2, 4, 5, 6, 0 }, 5, new int[] { 3 }, 1, new int[] { 1, 2, 3, 4, 5, 6 })]
    [TestCase(new int[] { 0, 0, 0 }, 0, new int[] { 2, 4, 6 }, 3, new int[] { 2, 4, 6 })]
    [TestCase(new int[] { 1, 3, 5, 0, 0, 0 }, 3, new int[] { 2, 4, 6 }, 3, new int[] { 1, 2, 3, 4, 5, 6 })]
    [TestCase(new int[] { 1, 2, 3, 0, 0, 0 }, 3, new int[] { 4, 5, 6 }, 3, new int[] { 1, 2, 3, 4, 5, 6 })]
    [TestCase(new int[] { 4, 0, 0, 0, 0 }, 1, new int[] { 1, 2, 3, 5 }, 4, new int[] { 1, 2, 3, 4, 5 })]
    public void Test_Merge(int[] nums1, int m, int[] nums2, int n, int[] expected)
    {
        Arrays.Merge(nums1, m, nums2, n);
        Assert.That(nums1, Is.EqualTo(expected));
    }

    #region 15

    [TestCaseSource(typeof(ThreeSumTestData), nameof(ThreeSumTestData.TestCases))]
    public void Test_ThreeSum(int[] nums, IList<IList<int>> expected)
    {
        var result = Arrays.ThreeSum(nums);

        var normExpected = NormalizeResult(expected);
        var normResult = NormalizeResult(result);

        Assert.That(normResult, Is.EqualTo(normExpected));
    }

    public static class ThreeSumTestData
    {
        public static IEnumerable<TestCaseData> TestCases
        {
            get
            {
                yield return new TestCaseData(
                    new int[] { -1, 0, 1, 2, -1, -4 },
                    new List<IList<int>>
                    {
                    new List<int> { -1, -1, 2 },
                    new List<int> { -1, 0, 1 }
                    }
                );
                yield return new TestCaseData(
                   new int[] { -1, 0, 1, 2, -1, -1, -1, -1, -4 },
                   new List<IList<int>>
                   {
                    new List<int> { -1, -1, 2 },
                    new List<int> { -1, 0, 1 }
                   }
               );
                yield return new TestCaseData(
                  new int[] { -1, 0, 1, 0 },
                  new List<IList<int>>
                  {
                    new List<int> { -1,0,1 },
                  }
              );
                yield return new TestCaseData(
                  new int[] { 1, 1, -2 },
                  new List<IList<int>>
                  {
                    new List<int> { -2,1,1 },
                  }
              );
                yield return new TestCaseData(
                   new int[] { 0, 0, 0 },
                   new List<IList<int>>
                   {
                    new List<int> { 0, 0, 0 }
                   }
               );
                yield return new TestCaseData(
                    new int[] { 0, 1, 1 },
                    new List<IList<int>>() // no triplets
                );
                yield return new TestCaseData(
                    new int[] { -2, 0, 1, 1, 2 },
                    new List<IList<int>>
                    {
                    new List<int> { -2, 0, 2 },
                    new List<int> { -2, 1, 1 }
                    }
                );

            }
        }
    }

    // ---------------- Helper Methods ----------------

    private static List<IList<int>> NormalizeResult(IList<IList<int>> list)
    {
        if (list == null)
            return new List<IList<int>>();

        var sortedTriplets = list
            .Select(t => t.OrderBy(x => x).ToList())
            .ToList();

        return sortedTriplets
            .OrderBy(t => t[0])
            .ThenBy(t => t[1])
            .ThenBy(t => t[2])
            .Select(t => (IList<int>)t)
            .ToList();
    }

    #endregion

    [TestCase(new int[] { 1, 3, 2, 2, 5, 2, 3, 7 }, 5)]
    [TestCase(new int[] { 1, 2, 3, 4 }, 2)]
    [TestCase(new int[] { 1, 1, 1, 1 }, 0)]
    [TestCase(new int[] { 1, 1, 3, 4 }, 2)]
    [TestCase(new int[] { 3, 4, 1, 1 }, 2)]
    [TestCase(new int[] { 3 }, 0)]
    [TestCase(new int[] { }, 0)]
    public void Test_FindLHS(int[] nums, int length)
    {
        Assert.That(Arrays.FindLHS(nums), Is.EqualTo(length));
    }

    [TestCase(new int[] { 2, 2, 1 }, 1)]
    [TestCase(new int[] { 4, 1, 2, 1, 2 }, 4)]
    [TestCase(new int[] { 1 }, 1)]
    public void Test_SingleNumber(int[] nums, int unique)
    {
        Assert.That(Arrays.SingleNumber(nums), Is.EqualTo(unique));
    }

    [TestCase(new int[] { 2, 2, 3, 2 }, 3)]
    [TestCase(new int[] { 0, 1, 0, 1, 0, 1, 99 }, 99)]
    [TestCase(new int[] { 1, 1, 1, 4 }, 4)]
    public void Test_SingleNumberII(int[] nums, int unique)
    {
        Assert.That(Arrays.SingleNumberII(nums), Is.EqualTo(unique));
    }

    [TestCase(new int[] { 1, 2, 1, 3, 2, 5 }, 2)]
    [TestCase(new int[] { -1, 0 }, 2)]
    [TestCase(new int[] { 0, 1 }, 2)]
    public void Test_SingleNumberIII(int[] nums, int unique)
    {
        Assert.That(Arrays.SingleNumberIII(nums).Count, Is.EqualTo(unique));
    }

    [TestCase(new int[] { 9, 8, 99, 98 }, "999988")]
    [TestCase(new int[] { 10, 2 }, "210")]
    [TestCase(new int[] { 10, 2, 110 }, "211010")]
    [TestCase(new int[] { 3, 30, 34, 5, 9 }, "9534330")]
    [TestCase(new int[] { 10, 2, 2100000000 }, "2210000000010")]
    [TestCase(new int[] { 10, 2, 2140000000 }, "2214000000010")]
    public void Test_LargestNumber(int[] nums, string output)
    {
        Assert.That(Arrays.LargestNumber(nums), Is.EqualTo(output));
    }
} 