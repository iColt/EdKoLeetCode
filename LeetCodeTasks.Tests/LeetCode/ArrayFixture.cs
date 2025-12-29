using EdkoSKD.Common.Arrays;

namespace LeetCodeTasks.Tests.LeetCode;
[TestFixture]
public class ArrayFixture
{
    [SetUp]
    public void Setup()
    {
    }

    #region 1

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

    #endregion

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

    #region 26

    [TestCase(new int[] { 1, 1, 2 }, 2)]
    [TestCase(new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 }, 5)]
    [TestCase(new int[] { -100, -8, 0, 0, 1, 1, 2, 30, 30, 40 }, 7)]
    public void Test_RemoveDuplicates(int[] ints, int length)
    {
        Assert.That(Arrays.RemoveDuplicates(ints), Is.EqualTo(length));
    }

    #endregion

    #region 27

    [TestCase(new int[] { 3, 2, 2, 3 }, 3, 2)]
    [TestCase(new int[] { 0, 1, 2, 2, 3, 0, 4, 2 }, 2, 5)]
    public void Test_RemoveElements(int[] ints, int value, int length)
    {
        Assert.That(Arrays.RemoveElement(ints, value), Is.EqualTo(length));
    }

    #endregion

    #region 35

    [TestCase(new int[] { 1, 3, 5, 6 }, 5, 2)]
    [TestCase(new int[] { 1, 3, 5, 6 }, 2, 1)]
    [TestCase(new int[] { 1, 3, 5, 6 }, 7, 4)]
    public void Test_SearchInsert(int[] nums, int target, int pos)
    {
        Assert.That(Arrays.SearchInsert(nums, target), Is.EqualTo(pos));
    }

    #endregion

    #region 39

    [TestCase(new int[] { 2, 3, 5 }, 8, 3)]
    [TestCase(new int[] { 5, 10, 8, 4, 3, 12, 9 }, 27, 45)]
    [TestCase(new int[] { 2, 3, 6, 7 }, 7, 2)]
    [TestCase(new int[] { 2 }, 1, 0)]
    public void Test_CombinationSum(int[] candidates, int target, int countOfCombinations)
    {
        //CompareTwoCombinations(Arrays.CombinationSum(candidates, target));
        Assert.That(Arrays.CombinationSum(candidates, target).Count(), Is.EqualTo(countOfCombinations));
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

    #region 56

    [TestCaseSource(nameof(MergeIntervalsTestCases))]
    public void Merge_ShouldReturnExpectedIntervals(int[][] input, int[][] expected)
    {
        // Act
        var result = Arrays.Merge(input);

        // Assert
        AssertIntervalsEqual(expected, result);
    }

    public static object[] MergeIntervalsTestCases =
    {
        // Example 1
        new object[]
        {
            new[]
            {
                [1, 3],
                [2, 6],
                [8, 10],
                new[] {15, 18}
            },
            new[]
            {
                [1, 6],
                [8, 10],
                new[] {15, 18}
            }
        },

        // Example 2
        new object[]
        {
            new[]
            {
                [1, 4],
                new[] {4, 5}
            },
            new[]
            {
                new[] {1, 5}
            }
        },

        // Single interval
        new object[]
        {
            new[]
            {
                new[] {5, 7}
            },
            new[]
            {
                new[] {5, 7}
            }
        },

        // Already merged
        new object[]
        {
            new[]
            {
                [1, 10],
                [2, 3],
                new[] {4, 8}
            },
            new[]
            {
                new[] {1, 10}
            }
        },

        // No overlaps
        new object[]
        {
            new[]
            {
                [1, 2],
                [3, 4],
                new[] {5, 6}
            },
            new[]
            {
                [1, 2],
                [3, 4],
                new[] {5, 6}
            }
        },

        // Unsorted input
        new object[]
        {
            new[]
            {
                [8, 10],
                [1, 3],
                new[] {2, 6}
            },
            new[]
            {
                [1, 6],
                new[] {8, 10}
            }
        },

        // Nested intervals
        new object[]
        {
            new[]
            {
                [1, 10],
                [2, 3],
                [4, 5],
                new[] {6, 7}
            },
            new[]
            {
                new[] {1, 10}
            }
        }
    };

    private static void AssertIntervalsEqual(int[][] expected, int[][] actual)
    {
        Assert.That(actual.Length, Is.EqualTo(expected.Length), "Interval count mismatch");

        for (int i = 0; i < expected.Length; i++)
        {
            Assert.That(actual[i][0], Is.EqualTo(expected[i][0]), $"Start mismatch at index {i}");
            Assert.That(actual[i][1], Is.EqualTo(expected[i][1]), $"End mismatch at index {i}");
        }
    }


    #endregion

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

    #region 73

    [TestCaseSource(nameof(SetZeroesTestCases))]
    public void SetZeroes_ModifiesMatrixCorrectly(int[][] input, int[][] expected)
    {
        // Act
        Arrays.SetZeroes(input);

        // Assert
        AssertMatricesAreEqual(expected, input);
    }

    public static IEnumerable<TestCaseData> SetZeroesTestCases()
    {
        // Single element non-zero
        yield return new TestCaseData(
            new int[][] { new[] { 1 } },
            new int[][] { new[] { 1 } }
        );

        // Single element zero
        yield return new TestCaseData(
            new int[][] { new[] { 0 } },
            new int[][] { new[] { 0 } }
        );

        // LeetCode example
        yield return new TestCaseData(
            new int[][]
            {
                new[] { 1, 1, 1 },
                new[] { 1, 0, 1 },
                new[] { 1, 1, 1 }
            },
            new int[][]
            {
                new[] { 1, 0, 1 },
                new[] { 0, 0, 0 },
                new[] { 1, 0, 1 }
            }
        );

        // Multiple zeros
        yield return new TestCaseData(
            new int[][]
            {
                new[] { 0, 1, 2, 0 },
                new[] { 3, 4, 5, 2 },
                new[] { 1, 3, 1, 5 }
            },
            new int[][]
            {
                new[] { 0, 0, 0, 0 },
                new[] { 0, 4, 5, 0 },
                new[] { 0, 3, 1, 0 }
            }
        );

        // Zero in first row
        yield return new TestCaseData(
            new int[][]
            {
                new[] { 1, 0, 3 },
                new[] { 4, 5, 6 },
                new[] { 7, 8, 9 }
            },
            new int[][]
            {
                new[] { 0, 0, 0 },
                new[] { 4, 0, 6 },
                new[] { 7, 0, 9 }
            }
        );

        // Zero in first column
        yield return new TestCaseData(
            new int[][]
            {
                new[] { 1, 2, 3 },
                new[] { 0, 5, 6 },
                new[] { 7, 8, 9 }
            },
            new int[][]
            {
                new[] { 0, 2, 3 },
                new[] { 0, 0, 0 },
                new[] { 0, 8, 9 }
            }
        );
    }

    private void AssertMatricesAreEqual(int[][] expected, int[][] actual)
    {
        Assert.AreEqual(expected.Length, actual.Length);

        for (int i = 0; i < expected.Length; i++)
        {
            CollectionAssert.AreEqual(expected[i], actual[i]);
        }
    }


    #endregion

    #region 88

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

    #endregion

    #region 118

    [TestCase(1)]
    [TestCase(2)]
    [TestCase(5)]
    [TestCase(6)]
    public void Test_Generate_ReturnsCorrectTriangle(int numRows)
    {
        // Arrange: expected results
        var expected = numRows switch
        {
            1 => new List<IList<int>>
            {
                new List<int>{ 1 }
            },

            2 => new List<IList<int>>
            {
                new List<int>{ 1 },
                new List<int>{ 1, 1 },
            },

            5 => new List<IList<int>>
            {
                new List<int>{ 1 },
                new List<int>{ 1, 1 },
                new List<int>{ 1, 2, 1 },
                new List<int>{ 1, 3, 3, 1 },
                new List<int>{ 1, 4, 6, 4, 1 },
            },

            6 => new List<IList<int>>
            {
                new List<int>{ 1 },
                new List<int>{ 1, 1 },
                new List<int>{ 1, 2, 1 },
                new List<int>{ 1, 3, 3, 1 },
                new List<int>{ 1, 4, 6, 4, 1 },
                new List<int>{ 1, 5, 10, 10, 5, 1 },
            },

            _ => null
        };

        // Act
        var result = Arrays.Generate(numRows);

        // Assert count
        Assert.That(numRows, Is.EqualTo(result.Count));

        // Assert row contents
        for (int i = 0; i < numRows; i++)
        {
            CollectionAssert.AreEqual(expected[i], result[i]);
        }
    }

    #endregion

    #region 136

    [TestCase(new int[] { 2, 2, 1 }, 1)]
    [TestCase(new int[] { 4, 1, 2, 1, 2 }, 4)]
    [TestCase(new int[] { 1 }, 1)]
    public void Test_SingleNumber(int[] nums, int unique)
    {
        Assert.That(Arrays.SingleNumber(nums), Is.EqualTo(unique));
    }

    #endregion

    #region 137

    [TestCase(new int[] { 2, 2, 3, 2 }, 3)]
    [TestCase(new int[] { 0, 1, 0, 1, 0, 1, 99 }, 99)]
    [TestCase(new int[] { 1, 1, 1, 4 }, 4)]
    public void Test_SingleNumberII(int[] nums, int unique)
    {
        Assert.That(Arrays.SingleNumberII(nums), Is.EqualTo(unique));
    }

    #endregion

    #region 179

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

    #endregion

    #region 228

    [TestCaseSource(nameof(SummaryRangeTestCases))]
    public void SummaryRanges_ReturnsExpectedResult(int[] nums, IList<string> expected)
    {
        // Act
        var result = Arrays.SummaryRanges(nums);

        // Assert
        CollectionAssert.AreEqual(expected, result);
    }

    public static IEnumerable<TestCaseData> SummaryRangeTestCases()
    {
        yield return new TestCaseData(
            new int[] { },
            new List<string> { }
        );

        yield return new TestCaseData(
            new int[] { 5 },
            new List<string> { "5" }
        );

        yield return new TestCaseData(
            new int[] { 0, 1, 2, 4, 5, 7 },
            new List<string> { "0->2", "4->5", "7" }
        );

        yield return new TestCaseData(
            new int[] { 0, 2, 3, 4, 6, 8, 9 },
            new List<string> { "0", "2->4", "6", "8->9" }
        );

        yield return new TestCaseData(
            new int[] { -3, -2, -1, 0, 1 },
            new List<string> { "-3->1" }
        );

        yield return new TestCaseData(
            new int[] { int.MinValue, int.MinValue + 1, 0, int.MaxValue },
            new List<string>
            {
                 $"{int.MinValue}->{int.MinValue + 1}",
                 "0",
                 $"{int.MaxValue}"
            }
        );
        yield return new TestCaseData(
           new int[] { int.MinValue + 1, 2, 3, 4 },
           new List<string>
           {
                 $"{int.MinValue + 1}",
                 "2->4"
           }
       );
        yield return new TestCaseData(
           new int[] { -100, -99, int.MaxValue },
           new List<string>
           {
                "-100->-99",
                $"{int.MaxValue}"
           }
       );
        yield return new TestCaseData(
           new int[] { int.MinValue, 0, 2, 3, 4 },
           new List<string>
           {
                $"{int.MinValue}",
                "0",
                "2->4"
           }
       );
    }

    #endregion

    #region 260

    [TestCase(new int[] { 1, 2, 1, 3, 2, 5 }, 2)]
    [TestCase(new int[] { -1, 0 }, 2)]
    [TestCase(new int[] { 0, 1 }, 2)]
    public void Test_SingleNumberIII(int[] nums, int unique)
    {
        Assert.That(Arrays.SingleNumberIII(nums).Count, Is.EqualTo(unique));
    }

    #endregion

    #region 283

    [TestCaseSource(nameof(MoveZeroesTestCases))]
    public void MoveZeroes_ShouldMoveCorrectly(int[] input, int[] expected)
    {
        // Act
        Arrays.MoveZeroes(input);

        // Assert
        Assert.That(ArrayHelpers.AssertArraysEqual(expected, input));
    }

    public static object[] MoveZeroesTestCases =
    {
        // LeetCode example
        new object[]
        {
            new[] { 0, 1, 0, 3, 12 },
            new[] { 1, 3, 12, 0, 0 }
        },

        // No zeros
        new object[]
        {
            new[] { 1, 2, 3 },
            new[] { 1, 2, 3 }
        },

        // All zeros
        new object[]
        {
            new[] { 0, 0, 0 },
            new[] { 0, 0, 0 }
        },

        // Zero at end
        new object[]
        {
            new[] { 1, 2, 3, 0 },
            new[] { 1, 2, 3, 0 }
        },

        // Zero at start
        new object[]
        {
            new[] { 0, 1, 2, 3 },
            new[] { 1, 2, 3, 0 }
        },

        // Multiple zeros in middle
        new object[]
        {
            new[] { 1, 0, 2, 0, 3, 0 },
            new[] { 1, 2, 3, 0, 0, 0 }
        },

        // Single element - zero
        new object[]
        {
            new[] { 0 },
            new[] { 0 }
        },

        // Single element - non-zero
        new object[]
        {
            new[] { 5 },
            new[] { 5 }
        },

        // Negative numbers
        new object[]
        {
            new[] { 0, -1, 0, -2, 3 },
            new[] { -1, -2, 3, 0, 0 }
        }
    };

    #endregion

    #region 383

    [TestCase("aab", "baa", true)]
    [TestCase("bg", "efjbdfbdgfjhhaiigfhbaejahgfbbgbjagbddfgdiaigdadhcfcj", true)]
    [TestCase("aa", "ab", false)]
    [TestCase("a", "b", false)]
    public void Test_CanConstruct2(string ransom, string magaz, bool result)
    {
        Assert.That(Arrays.CanConstruct2(ransom, magaz), Is.EqualTo(result));
    }

    #endregion

    #region 448

    [TestCaseSource(nameof(FindDisappearedNumbersTestCases))]
    public void FindDisappearedNumbers_ShouldReturnCorrectResult(
      int[] input,
      IList<int> expected)
    {
        // Act
        var result = Arrays.FindDisappearedNumbers(input);

        // Assert
        AssertListsEqual(expected, result);
    }

    public static object[] FindDisappearedNumbersTestCases =
    {
        // LeetCode example
        new object[]
        {
            new[] { 4, 3, 2, 7, 8, 2, 3, 1 },
            new List<int> { 5, 6 }
        },

        // No missing numbers
        new object[]
        {
            new[] { 1, 2, 3, 4, 5 },
            new List<int>()
        },

        // All numbers missing except one
        new object[]
        {
            new[] { 1, 1, 1, 1 },
            new List<int> { 2, 3, 4 }
        },

        // Single element - no missing
        new object[]
        {
            new[] { 1 },
            new List<int>()
        },

        // Single element - missing one (not possible per constraints, but defensive)
        new object[]
        {
            new[] { 1, 1 },
            new List<int> { 2 }
        },

        // Reverse order with duplicates
        new object[]
        {
            new[] { 5, 4, 3, 2, 1, 1 },
            new List<int> { 6 }
        },

        // All elements the same
        new object[]
        {
            new[] { 2, 2, 2, 2 },
            new List<int> { 1, 3, 4 }
        }
    };

    private static void AssertListsEqual(IList<int> expected, IList<int> actual)
    {
        Assert.AreEqual(expected.Count, actual.Count, "List count mismatch");

        var sortedExpected = expected.OrderBy(x => x).ToList();
        var sortedActual = actual.OrderBy(x => x).ToList();

        for (int i = 0; i < sortedExpected.Count; i++)
        {
            Assert.AreEqual(sortedExpected[i], sortedActual[i],
                $"Mismatch at index {i}");
        }
    }


    #endregion

    #region 485

    [TestCase(new int[] { 1, 1, 1, 0, 1, 1, 1, 1 }, 4)]
    [TestCase(new int[] { 1, 1, 1, 0, 1, 1, 1, 1, 0 }, 4)]
    [TestCase(new int[] { 1, 1, 1, 1, 0, 1, 1, 1, 0 }, 4)]
    public void Test_MaxCons(int[] ints, int res)
    {
        Assert.That(Arrays.FindMaxConsecutiveOnes(ints), Is.EqualTo(res));
    }

    #endregion

    #region 496

    [TestCaseSource(nameof(TestCases))]
    public void NextGreaterElement_ShouldReturnCorrectResult(
       int[] nums1,
       int[] nums2,
       int[] expected)
    {
        // Act
        var result = Arrays.NextGreaterElement(nums1, nums2);

        // Assert
        Assert.That(ArrayHelpers.AssertArraysEqual(expected, result));
    }

    public static object[] TestCases =
    {
        // LeetCode example 1
        new object[]
        {
            new[] { 4, 1, 2 },
            new[] { 1, 3, 4, 2 },
            new[] { -1, 3, -1 }
        },

        // LeetCode example 2
        new object[]
        {
            new[] { 2, 4 },
            new[] { 1, 2, 3, 4 },
            new[] { 3, -1 }
        },

        // Single element
        new object[]
        {
            new[] { 1 },
            new[] { 1 },
            new[] { -1 }
        },

        // nums1 == nums2
        new object[]
        {
            new[] { 1, 3, 2 },
            new[] { 1, 3, 2 },
            new[] { 3, -1, -1 }
        },

        // Strictly decreasing nums2
        new object[]
        {
            new[] { 5, 4, 3 },
            new[] { 5, 4, 3, 2, 1 },
            new[] { -1, -1, -1 }
        },

        // nums1 elements appear later in nums2
        new object[]
        {
            new[] { 2, 1 },
            new[] { 3, 2, 1, 4 },
            new[] { 4, 4 }
        },

        // nums1 empty
        new object[]
        {
            new int[] { },
            new[] { 1, 2, 3 },
            new int[] { }
        }
    };

    #endregion

    #region 594

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

    #endregion

}