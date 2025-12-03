namespace LeetCodeTasks.Tests.LeetCode;
[TestFixture]
internal class SubsequenciesFixture
{
    [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31 }, 7)]
    [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 5)]
    [TestCase(new int[] { 1, 3, 7, 11, 12, 14, 18 }, 3)]
    [TestCase(new int[] { 2, 4, 7, 8, 9, 10, 14, 15, 18, 23, 32, 50 }, 5)]
    [TestCase(new int[] { 1, 3, 5 }, 0)]
    public void Test_LenLongestFibSubseq(int[] ints, int sequenceLength)
    {
        Assert.That(Subsequencies.LenLongestFibSubseq(ints), Is.EqualTo(sequenceLength));
    }

    [TestCase(new int[] { 2, 3, 5, 9, 1 }, 1, 1)]
    [TestCase(new int[] { 2, 3, 5, 9 }, 2, 5)]
    [TestCase(new int[] { 2, 7, 9, 3, 1 }, 2, 2)]
    public void Test_MinCapability(int[] ints, int minHouseNum, int maxCap)
    {
        Assert.That(Subsequencies.MinCapability(ints, minHouseNum), Is.EqualTo(maxCap));
    }

    [TestCaseSource(typeof(LongestConsecutiveTestData), nameof(LongestConsecutiveTestData.TestCases))]
    public void Test_LongestConsecutive(int[] nums, int expected)
    {
        int result = Subsequencies.LongestConsecutive(nums);

        Assert.That(result, Is.EqualTo(expected));
    }

    public class LongestConsecutiveTestData
    {
        public static IEnumerable<TestCaseData> TestCases
        {
            get
            {
                // LeetCode Example 1: [100,4,200,1,3,2] => 4 (1,2,3,4)
                yield return new TestCaseData(
                    new int[] { 100, 4, 200, 1, 3, 2 },
                    4
                );

                // LeetCode Example 2: [] => 0
                yield return new TestCaseData(
                    new int[] { },
                    0
                );

                // Single element
                yield return new TestCaseData(
                    new int[] { 10 },
                    1
                );

                // No consecutive numbers
                yield return new TestCaseData(
                    new int[] { 10, 30, 50 },
                    1
                );

                // Fully consecutive sequence: result should be full length
                yield return new TestCaseData(
                    new int[] { 1, 2, 3, 4, 5, 6 },
                    6
                );

                // Reverse ordered sequence
                yield return new TestCaseData(
                    new int[] { 6, 5, 4, 3, 2, 1 },
                    6
                );

                // Mixed with duplicates
                yield return new TestCaseData(
                    new int[] { 1, 2, 2, 3 },
                    3
                );

                // Several sequences, choose the longest
                yield return new TestCaseData(
                    new int[] { 10, 11, 12, 50, 51, 100 },
                    3
                );

                // Large gap then long sequence
                yield return new TestCaseData(
                    new int[] { 0, 3, 7, 2, 5, 8, 4, 6, 0, 1 },
                    9
                );

                // Negative numbers and positives
                yield return new TestCaseData(
                    new int[] { -1, -2, -3, 10, 11, 12, -4 },
                    4      // -4, -3, -2, -1
                );

                // Only duplicates
                yield return new TestCaseData(
                    new int[] { 5, 5, 5, 5 },
                    1
                );

                // Only zero
                yield return new TestCaseData(
                    new int[] { 0 },
                    1
                );

                // Only two zeros
                yield return new TestCaseData(
                    new int[] { 0, 0 },
                    1
                );
            }
        }
    }
}
