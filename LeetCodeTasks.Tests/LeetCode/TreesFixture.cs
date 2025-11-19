using LeetCodeTasks.Helpers;

namespace LeetCodeTasks.Tests.LeetCode;

[TestFixture]
public sealed class TreesFixture
{
    [TestCaseSource(typeof(PathSumTestData), nameof(PathSumTestData.TestCases))]
    public void Test_HasPathSum(TreeNode root, int targetSum, bool expected)
    {
        bool result = Trees.HasPathSum(root, targetSum);

        Assert.That(result, Is.EqualTo(expected));
    }

    public static class PathSumTestData
    {
        public static IEnumerable<TestCaseData> TestCases
        {
            get
            {
                // More complex tree
                yield return new TestCaseData(
                    TreesHelpers.Tree(new int?[] { -2, null, -3 }),
                    -5,
                    true
                );

                // More complex tree
                yield return new TestCaseData(
                    TreesHelpers.Tree(new int?[] { 1, 2, 3, 4, null, null, 5 }),
                    8,
                    false     // path 1 → 2 → 4
                );

                // Example 1 from LeetCode
                yield return new TestCaseData(
                    TreesHelpers.Tree(new int?[] { 5, 4, 8, 11, null, 13, 4, 7, 2, null, null, null, 1 }),
                    22,
                    true
                );

                // No valid path
                yield return new TestCaseData(
                    TreesHelpers.Tree(new int?[] { 1, 2, 3 }),
                    5,
                    false
                );

                // Single node equal to target
                yield return new TestCaseData(
                    TreesHelpers.Tree(new int?[] { 1 }),
                    1,
                    true
                );

                // Single node not equal
                yield return new TestCaseData(
                    TreesHelpers.Tree(new int?[] { 1 }),
                    2,
                    false
                );

                // Empty tree
                yield return new TestCaseData(
                    null,
                    0,
                    false
                );

                yield return new TestCaseData(
                    TreesHelpers.Tree(new int?[] { 1, 2, 3, 4, null, null, 5 }),
                    10,
                    false
                );
            }
        }
    }
}