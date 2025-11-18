using LeetCodeTasks.Helpers;

namespace LeetCodeTasks.Tests.LeetCode;

[TestFixture]
public sealed class TreesFixture
{
    [TestCaseSource(typeof(PathSumTestData), nameof(PathSumTestData.TestCases))]
    public void TestHasPathSum(TreeNode root, int targetSum, bool expected)
    {
        bool result = Trees.HasPathSum(root, targetSum);

        Assert.That(result, Is.EqualTo(expected));
    }

    public class PathSumTestData
    {
        public static IEnumerable<TestCaseData> TestCases
        {
            get
            {
                // Example 1 from LeetCode
                yield return new TestCaseData(
                    TreesHelpers.Tree(new int?[] { 5, 4, 8, 11, null, 13, 4, 7, 2, null, null, null, 1 }),
                    22,
                    true
                ).SetName("Example1_True");

                // No valid path
                yield return new TestCaseData(
                    TreesHelpers.Tree(new int?[] { 1, 2, 3 }),
                    5,
                    false
                ).SetName("NoValidPath");

                // Single node equal to target
                yield return new TestCaseData(
                    TreesHelpers.Tree(new int?[] { 1 }),
                    1,
                    true
                ).SetName("SingleNode_True");

                // Single node not equal
                yield return new TestCaseData(
                    TreesHelpers.Tree(new int?[] { 1 }),
                    2,
                    false
                ).SetName("SingleNode_False");

                // Empty tree
                yield return new TestCaseData(
                    null,
                    0,
                    false
                ).SetName("EmptyTree");

                // More complex tree
                yield return new TestCaseData(
                    TreesHelpers.Tree(new int?[] { 1, 2, 3, 4, null, null, 5 }),
                    8,
                    true     // path 1 → 2 → 4
                ).SetName("ComplexTree_True");

                yield return new TestCaseData(
                    TreesHelpers.Tree(new int?[] { 1, 2, 3, 4, null, null, 5 }),
                    10,
                    false
                ).SetName("ComplexTree_False");
            }
        }
    }
}