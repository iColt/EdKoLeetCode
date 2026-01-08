using EdkoSKD.Common.Models;
using EdkoSKD.Common.Trees;

namespace LeetCodeTasks.Tests.LeetCode;

[TestFixture]
public sealed class TreesFixture
{
    #region 94
    [TestCaseSource(typeof(InorderTraversalTestData), nameof(InorderTraversalTestData.TestCases))]
    public void Test_InorderTraversal(TreeNode root, IList<int> expected)
    {
        var result = Trees.InorderTraversal(root);

        Assert.That(result, Is.EqualTo(expected));
    }

    public class InorderTraversalTestData
    {
        public static IEnumerable<TestCaseData> TestCases
        {
            get
            {
                yield return new TestCaseData(
                    TreeHelpers.Tree(new int?[] { 1, null, 2, 3 }),
                    new List<int> { 1, 3, 2 }
                );

                // Single node
                yield return new TestCaseData(
                    TreeHelpers.Tree(new int?[] { 1 }),
                    new List<int> { 1 }
                );

                // Empty tree
                yield return new TestCaseData(
                    null,
                    new List<int>()
                );

                // Full binary tree
                //      1
                //     / \
                //    2   3
                //   / \   \
                //  4   5   6
                yield return new TestCaseData(
                    TreeHelpers.Tree(new int?[] { 1, 2, 3, 4, 5, null, 6 }),
                    new List<int> { 4, 2, 5, 1, 3, 6 }
                );

                // Left-skewed tree: 1 -> 2 -> 3 -> 4
                yield return new TestCaseData(
                    TreeHelpers.Tree(new int?[] { 1, 2, 3, 4, 5, null, 8, null, null, 6, 7, 9 }),
                    new List<int> { 4, 2, 6, 5, 7, 1, 3, 9, 8 }
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
                    TreeHelpers.Tree(new int?[] { 1, 2, 3 }),
                    TreeHelpers.Tree(new int?[] { 1, 2, 3 }),
                    true
                );

                // Different structure
                yield return new TestCaseData(
                    TreeHelpers.Tree(new int?[] { 1, 2 }),
                    TreeHelpers.Tree(new int?[] { 1, null, 2 }),
                    false
                );

                // Different node values
                yield return new TestCaseData(
                    TreeHelpers.Tree(new int?[] { 1, 2, 1 }),
                    TreeHelpers.Tree(new int?[] { 1, 1, 2 }),
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
                    TreeHelpers.Tree(new int?[] { 1 }),
                    null,
                    false
                );

                yield return new TestCaseData(
                    null,
                    TreeHelpers.Tree(new int?[] { 1 }),
                    false
                );

                // Larger equal trees
                yield return new TestCaseData(
                    TreeHelpers.Tree(new int?[] { 3, 9, 20, null, null, 15, 7 }),
                    TreeHelpers.Tree(new int?[] { 3, 9, 20, null, null, 15, 7 }),
                    true
                );

                // Same values but different arrangement
                yield return new TestCaseData(
                    TreeHelpers.Tree(new int?[] { 3, 9, 20 }),
                    TreeHelpers.Tree(new int?[] { 3, 20, 9 }),
                    false
                );
            }
        }
    }
    #endregion

    #region 110

    [TestCaseSource(typeof(BalancedTreeTestData), nameof(BalancedTreeTestData.TestCases))]
    public void TestBalancedBinaryTree(TreeNode root, bool expected)
    {
        Assert.That(Trees.IsBalanced(root), Is.EqualTo(expected));
    }

    public class BalancedTreeTestData
    {
        public static IEnumerable<TestCaseData> TestCases
        {
            get
            {
                yield return new TestCaseData(
                  TreeHelpers.Tree(new int?[] { 1, 2, 2, 3, 3, null, null, 4, 4 }),
                  false
              );

                // Complex but still balanced
                //         1
                //        / \
                //       2   3
                //      /     \
                //     4       5
                //      \     /
                //       6   7
                yield return new TestCaseData(
                    TreeHelpers.Tree(new int?[] { 1, 2, 3, 4, null, null, 5, null, 6, 7, null }),
                    false
                );

                // Empty tree -> balanced
                yield return new TestCaseData(
                    null,
                    true
                );

                // Single node -> balanced
                yield return new TestCaseData(
                    TreeHelpers.Tree(new int?[] { 1 }),
                    true
                );

                // Perfect balanced tree
                //       1
                //     /   \
                //    2     3
                //   / \   / \
                //  4   5 6   7
                yield return new TestCaseData(
                    TreeHelpers.Tree(new int?[] { 1, 2, 3, 4, 5, 6, 7 }),
                    true
                );

                // Balanced but not perfect
                //      1
                //     / \
                //    2   3
                //   /
                //  4
                yield return new TestCaseData(
                    TreeHelpers.Tree(new int?[] { 1, 2, 3, 4 }),
                    true
                );

                // Unbalanced (classic example)
                //       1
                //      /
                //     2
                //    /
                //   3
                yield return new TestCaseData(
                    TreeHelpers.Tree(new int?[] { 1, 2, null, 3 }),
                    false
                );

                // Unbalanced – deeper right subtree
                //    1
                //     \
                //      2
                //       \
                //        3
                yield return new TestCaseData(
                    TreeHelpers.Tree(new int?[] { 1, null, 2, null, 3 }),
                    false
                );

                // Mixed: balanced at upper levels, unbalanced deeper
                //       1
                //      / \
                //     2   3
                //    /
                //   4
                //  /
                // 5
                yield return new TestCaseData(
                    TreeHelpers.Tree(new int?[] { 1, 2, 3, 4, null, null, null, 5 }),
                    false
                );

                yield return new TestCaseData(
                 TreeHelpers.Tree(new int?[] { 1, 2, 2, 3, null, null, 3, 4, null, null, 4 }),
                 false
             );


            }
        }
    }
    #endregion

    #region 108

    public static IEnumerable<TestCaseData> ConvertTestCases()
    {
        yield return new TestCaseData(
           new int[] { 1, 2, 3, 4, 5, 6, 7 },
           new TreeNode(4,
               new TreeNode(2,
                   new TreeNode(1),
                   new TreeNode(3)),
               new TreeNode(6,
                   new TreeNode(5),
                   new TreeNode(7)))
       );
        yield return new TestCaseData(
            new int[] { 1 },
            new TreeNode(1)
        );

        yield return new TestCaseData(
            new int[] { 1, 3 },
            new TreeNode(3,
                new TreeNode(1),
                null)
        );

        yield return new TestCaseData(
            new int[] { -10, -3, 0, 5, 9 },
            new TreeNode(0,
                new TreeNode(-3,
                    new TreeNode(-10),
                    null),
                new TreeNode(9,
                    new TreeNode(5),
                    null))
        );
    }

    [TestCaseSource(nameof(ConvertTestCases))]
    public void SortedArrayToBST_ShouldBuildCorrectTree(int[] nums, TreeNode expected)
    {
        var result = Trees.SortedArrayToBST(nums);

        Assert.IsTrue(TreeHelpers.AreEqualTrees(expected, result), "Generated tree does not match expected");
    }

    #endregion

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
                    TreeHelpers.Tree(new int?[] { -2, null, -3 }),
                    -5,
                    true
                );

                // More complex tree
                yield return new TestCaseData(
                    TreeHelpers.Tree(new int?[] { 1, 2, 3, 4, null, null, 5 }),
                    8,
                    false     // path 1 → 2 → 4
                );

                // Example 1 from LeetCode
                yield return new TestCaseData(
                    TreeHelpers.Tree(new int?[] { 5, 4, 8, 11, null, 13, 4, 7, 2, null, null, null, 1 }),
                    22,
                    true
                );

                // No valid path
                yield return new TestCaseData(
                    TreeHelpers.Tree(new int?[] { 1, 2, 3 }),
                    5,
                    false
                );

                // Single node equal to target
                yield return new TestCaseData(
                    TreeHelpers.Tree(new int?[] { 1 }),
                    1,
                    true
                );

                // Single node not equal
                yield return new TestCaseData(
                    TreeHelpers.Tree(new int?[] { 1 }),
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
                    TreeHelpers.Tree(new int?[] { 1, 2, 3, 4, null, null, 5 }),
                    10,
                    false
                );
            }
        }
    }

    #endregion

    #region 144

    [TestCaseSource(typeof(PreorderTraversalTestData), nameof(PreorderTraversalTestData.TestCases))]
    public void Test_PreorderTraversal(TreeNode root, IList<int> expected)
    {
        var result = Trees.PreorderTraversal(root);

        Assert.That(result, Is.EqualTo(expected));
    }

    public class PreorderTraversalTestData
    {
        public static IEnumerable<TestCaseData> TestCases
        {
            get
            {
                // LeetCode Example: [1,null,2,3] -> [1,2,3]
                yield return new TestCaseData(
                    TreeHelpers.Tree(new int?[] { 1, null, 2, 3 }),
                    new List<int> { 1, 2, 3 }
                );

                // Single node
                yield return new TestCaseData(
                    TreeHelpers.Tree(new int?[] { 1 }),
                    new List<int> { 1 }
                );

                // Empty tree
                yield return new TestCaseData(
                    null,
                    new List<int>()
                );

                // Full binary tree
                //      1
                //     / \
                //    2   3
                //   / \   \
                //  4   5   6
                yield return new TestCaseData(
                    TreeHelpers.Tree(new int?[] { 1, 2, 3, 4, 5, null, 6 }),
                    new List<int> { 1, 2, 4, 5, 3, 6 }
                );

                // Left-skewed tree: 1 -> 2 -> 3 -> 4
                yield return new TestCaseData(
                    TreeHelpers.Tree(new int?[] { 1, 2, null, 3, null, 4 }),
                    new List<int> { 1, 2, 3, 4 }
                );

                // Right-skewed tree: 1 -> 2 -> 3 -> 4
                yield return new TestCaseData(
                    TreeHelpers.Tree(new int?[] { 1, null, 2, null, 3, null, 4 }),
                    new List<int> { 1, 2, 3, 4 }
                );

                // Mixed tree
                //      5
                //     / \
                //    1   7
                //       /
                //      6
                yield return new TestCaseData(
                    TreeHelpers.Tree(new int?[] { 5, 1, 7, null, null, 6 }),
                    new List<int> { 5, 1, 7, 6 }
                );
            }
        }
    }
    #endregion

    #region 145
    [TestCaseSource(typeof(PostorderTraversalTestData), nameof(PostorderTraversalTestData.TestCases))]
    public void Test_PostorderTraversal(TreeNode root, IList<int> expected)
    {
        var result = Trees.PostorderTraversal(root);

        Assert.That(result, Is.EqualTo(expected));
    }

    public class PostorderTraversalTestData
    {
        public static IEnumerable<TestCaseData> TestCases
        {
            get
            {
                // LeetCode Example: [1,null,2,3] -> [1,2,3]
                yield return new TestCaseData(
                    TreeHelpers.Tree(new int?[] { 1, null, 2, 3 }),
                    new List<int> { 3, 2, 1 }
                );

                // Single node
                yield return new TestCaseData(
                    TreeHelpers.Tree(new int?[] { 1 }),
                    new List<int> { 1 }
                );

                // Empty tree
                yield return new TestCaseData(
                    null,
                    new List<int>()
                );

                // Full binary tree
                //      1
                //     / \
                //    2   3
                //   / \   \
                //  4   5   6
                yield return new TestCaseData(
                    TreeHelpers.Tree(new int?[] { 1, 2, 3, 4, 5, null, 6 }),
                    new List<int> { 4, 5, 2, 6, 3, 1 }
                );

                // Left-skewed tree: 1 -> 2 -> 3 -> 4
                yield return new TestCaseData(
                    TreeHelpers.Tree(new int?[] { 1, 2, 3, 4, 5, null, 8, null, null, 6, 7, 9 }),
                    new List<int> { 4, 6, 7, 5, 2, 9, 8, 3, 1 }
                );

                // Right-skewed tree: 1 -> 2 -> 3 -> 4
                yield return new TestCaseData(
                    TreeHelpers.Tree(new int?[] { 1, null, 2, null, 3, null, 4 }),
                    new List<int> { 4, 3, 2, 1 }
                );

                // Mixed tree
                //      5
                //     / \
                //    1   7
                //       /
                //      6
                yield return new TestCaseData(
                    TreeHelpers.Tree(new int?[] { 5, 1, 7, null, null, 6 }),
                    new List<int> { 1, 6, 7, 5 }
                );
            }
        }
    }
    #endregion

    #region 226

    [TestCaseSource(nameof(InvertTreeTestCases))]
    public void InvertTree_ShouldInvertCorrectly(TreeNode input, TreeNode expected)
    {
        // Act
        var result = Trees.InvertTree(input);

        // Assert
        Assert.IsTrue(TreeHelpers.AreEqualTrees(expected, result));
    }

    public static object[] InvertTreeTestCases =
    {
        // Empty tree
        new object[]
        {
            null,
            null
        },

        // Single node
        new object[]
        {
            new TreeNode(1),
            new TreeNode(1)
        },

        // Simple tree
        //   2          2
        //  / \   ->   / \
        // 1   3      3   1
        new object[]
        {
            new TreeNode(2,
                new TreeNode(1),
                new TreeNode(3)
            ),
            new TreeNode(2,
                new TreeNode(3),
                new TreeNode(1)
            )
        },

        // LeetCode example
        //       4                 4
        //     /   \     ->      /   \
        //    2     7           7     2
        //   / \   / \         / \   / \
        //  1   3 6   9       9   6 3   1
        new object[]
        {
            new TreeNode(4,
                new TreeNode(2,
                    new TreeNode(1),
                    new TreeNode(3)
                ),
                new TreeNode(7,
                    new TreeNode(6),
                    new TreeNode(9)
                )
            ),
            new TreeNode(4,
                new TreeNode(7,
                    new TreeNode(9),
                    new TreeNode(6)
                ),
                new TreeNode(2,
                    new TreeNode(3),
                    new TreeNode(1)
                )
            )
        },

        // Left-skewed tree
        new object[]
        {
            new TreeNode(3,
                new TreeNode(2,
                    new TreeNode(1),
                    null),
                null
            ),
            new TreeNode(3,
                null,
                new TreeNode(2,
                    null,
                    new TreeNode(1))
            )
        },

        // Right-skewed tree
        new object[]
        {
            new TreeNode(1,
                null,
                new TreeNode(2,
                    null,
                    new TreeNode(3))
            ),
            new TreeNode(1,
                new TreeNode(2,
                    new TreeNode(3),
                    null),
                null
            )
        }
    };

    #endregion

    #region 563

    [TestCaseSource(nameof(FindTiltTestCases))]
    public void FindTilt_ShouldReturnCorrectTilt(TreeNode input, int expected)
    {
        // Act
        var result = Trees.FindTilt(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    public static object[] FindTiltTestCases =
    {
       
        // Linear left tree
        //   4
        //  /
        // 2
        //  /
        // 3
        // Tilt = |5 - 0| + |3 - 0| = 5 + 3 = 8
        new object[]
        {
            new TreeNode(4,
                new TreeNode(2,
                    new TreeNode(3),
                    null),
                null
            ),
            8
        },

        // Balanced tree
        //       4
        //     /   \
        //    2     9
        //   / \     \
        //  3   5     7
        // Tilt = |(3+5+2) - (9+7)| + |3-5| + |0-7| = 6 + 2 + 7 = 15
        new object[]
        {
            new TreeNode(4,
                new TreeNode(2,
                    new TreeNode(3),
                    new TreeNode(5)
                ),
                new TreeNode(9,
                    null,
                    new TreeNode(7)
                )
            ),
            15
        },

        // Tree with negative values
        //   -1
        //   / \
        // -2  -3
        // Tilt = |-2 - (-3)| = 1
        new object[]
        {
            new TreeNode(-1,
                new TreeNode(-2),
                new TreeNode(-3)
            ),
            1
        },

        // All zero values
        new object[]
        {
            new TreeNode(0,
                new TreeNode(0),
                new TreeNode(0)
            ),
            0
        },
         // Empty tree
        new object[]
        {
            null,
            0
        },

        // Single node
        new object[]
        {
            new TreeNode(1),
            0
        },

        // LeetCode example
        //   1
        //  / \
        // 2   3
        // Tilt = |2 - 3| = 1
        new object[]
        {
            new TreeNode(1,
                new TreeNode(2),
                new TreeNode(3)
            ),
            1
        },

    };

    #endregion

    #region 617

    [TestCaseSource(nameof(MergeTreesTestCases))]
    public void MergeTrees_ShouldMergeCorrectly(
       TreeNode root1,
       TreeNode root2,
       TreeNode expected)
    {
        // Act
        var result = Trees.MergeTrees(root1, root2);

        // Assert
        Assert.That(TreeHelpers.AreEqualTrees(expected, result));
    }

    public static object[] MergeTreesTestCases =
    {
        // Both trees empty
        new object[]
        {
            null,
            null,
            null
        },

        // One tree empty
        new object[]
        {
            new TreeNode(1),
            null,
            new TreeNode(1)
        },

        new object[]
        {
            null,
            new TreeNode(2),
            new TreeNode(2)
        },

        // LeetCode example
        // Tree 1:        Tree 2:
        //      1              2
        //     / \            / \
        //    3   2          1   3
        //   /                \   \
        //  5                  4   7
        //
        // Result:
        //      3
        //     / \
        //    4   5
        //   / \   \
        //  5   4   7
        new object[]
        {
            new TreeNode(1,
                new TreeNode(3,
                    new TreeNode(5),
                    null),
                new TreeNode(2)
            ),
            new TreeNode(2,
                new TreeNode(1,
                    null,
                    new TreeNode(4)),
                new TreeNode(3,
                    null,
                    new TreeNode(7))
            ),
            new TreeNode(3,
                new TreeNode(4,
                    new TreeNode(5),
                    new TreeNode(4)),
                new TreeNode(5,
                    null,
                    new TreeNode(7))
            )
        },

        // Both trees single node
        new object[]
        {
            new TreeNode(5),
            new TreeNode(7),
            new TreeNode(12)
        },

        // One-sided trees
        new object[]
        {
            new TreeNode(1,
                new TreeNode(2),
                null
            ),
            new TreeNode(3,
                null,
                new TreeNode(4)
            ),
            new TreeNode(4,
                new TreeNode(2),
                new TreeNode(4)
            )
        },

        // Trees with negative values
        new object[]
        {
            new TreeNode(-1,
                new TreeNode(-2),
                null
            ),
            new TreeNode(1,
                null,
                new TreeNode(3)
            ),
            new TreeNode(0,
                new TreeNode(-2),
                new TreeNode(3)
            )
        }
    };

    #endregion
}