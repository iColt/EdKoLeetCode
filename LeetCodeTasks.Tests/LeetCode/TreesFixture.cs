using LeetCodeTasks.Helpers;

namespace LeetCodeTasks.Tests.LeetCode;

[TestFixture]
public sealed class TreesFixture
{
    #region 112

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

    #endregion

    #region 100

    [TestCaseSource(typeof(SameTreeTestData), nameof(SameTreeTestData.TestCases))]
    public void Test_IsSameTree(TreeNode p, TreeNode q, bool expected)
    {
        bool result = Trees.IsSameTree(p, q);

        Assert.That(result, Is.EqualTo(expected));
    }

    public class SameTreeTestData
    {
        public static IEnumerable<TestCaseData> TestCases
        {
            get
            {
                // Same structure and values
                yield return new TestCaseData(
                    TreesHelpers.Tree(new int?[] { 1, 2, 3 }),
                    TreesHelpers.Tree(new int?[] { 1, 2, 3 }),
                    true
                );

                // Different structure
                yield return new TestCaseData(
                    TreesHelpers.Tree(new int?[] { 1, 2 }),
                    TreesHelpers.Tree(new int?[] { 1, null, 2 }),
                    false
                );

                // Different node values
                yield return new TestCaseData(
                    TreesHelpers.Tree(new int?[] { 1, 2, 1 }),
                    TreesHelpers.Tree(new int?[] { 1, 1, 2 }),
                    false
                );

                // Both empty
                yield return new TestCaseData(
                    null,
                    null,
                    true
                );

                // One empty, one not
                yield return new TestCaseData(
                    TreesHelpers.Tree(new int?[] { 1 }),
                    null,
                    false
                );

                yield return new TestCaseData(
                    null,
                    TreesHelpers.Tree(new int?[] { 1 }),
                    false
                );

                // Larger equal trees
                yield return new TestCaseData(
                    TreesHelpers.Tree(new int?[] { 3, 9, 20, null, null, 15, 7 }),
                    TreesHelpers.Tree(new int?[] { 3, 9, 20, null, null, 15, 7 }),
                    true
                );

                // Same values but different arrangement
                yield return new TestCaseData(
                    TreesHelpers.Tree(new int?[] { 3, 9, 20 }),
                    TreesHelpers.Tree(new int?[] { 3, 20, 9 }),
                    false
                );
            }
        }
    }
        #endregion
    }