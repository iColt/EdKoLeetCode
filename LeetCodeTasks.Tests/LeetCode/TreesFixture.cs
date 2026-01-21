using EdkoSKD.Common.Models;
using EdkoSKD.Common.Trees;
using LeetCodeTasks.Tests.Helpers;
using static LeetCodeTasks.LeetCode.Trees;

namespace LeetCodeTasks.Tests.LeetCode;

[TestFixture]
public sealed class TreesFixture
{
    private static readonly TreeNode OneNodeBST = new(1);
    private static readonly TreeNode SimpleBST = new(2,
                    OneNodeBST,
                    new TreeNode(3)
                );

    private static readonly TreeNode SimpleBST2 = new TreeNode(1,
                    new TreeNode(2),
                    new TreeNode(3)
                );
    private static readonly TreeNode LeftSkewedBST = new TreeNode(3,
                    new TreeNode(2,
                        OneNodeBST,
                        null),
                    null
                );
    private static readonly TreeNode LeftSkewedBST2 = new TreeNode(1,
                    new TreeNode(2,
                        new TreeNode(3,
                            new TreeNode(4),
                            null),
                        null),
                    null
                );

    private static readonly TreeNode RightSkewedBST = new TreeNode(1,
                    null,
                    new TreeNode(2,
                        null,
                        new TreeNode(3))
                );
    #region 94
    [TestCaseSource(typeof(InorderTraversalTestData), nameof(InorderTraversalTestData.TestCases))]
    public void Test_InorderTraversal(TreeNode root, IList<int> expected)
    {
        var result = InorderTraversal(root);

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

    #region 98 Validate Binary Tree

    [TestCaseSource(nameof(IsValidBSTTestCases))]
    public void IsValidBST_ShouldValidateCorrectly(
        TreeNode root,
        bool expected)
    {
        // Act
        var result = IsValidBST(root);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    public static object[] IsValidBSTTestCases =
    {
        new object[]
        {
            //[3,null,30,10,null,null,15,null,45],
             new TreeNode(3,
                null,
                new TreeNode(30, 
                    new TreeNode(10, 
                        null, 
                        new TreeNode(15, 
                            null, 
                            new TreeNode(45)))
                    )),
            false
        },
        // Empty tree (valid BST)
        new object[]
        {
            null,
            true
        },

        // Single node
        new object[]
        {
            OneNodeBST,
            true
        },

        // Simple valid BST
        //     2
        //    / \
        //   1   3
        new object[]
        {
            SimpleBST,
            true
        },

        // Invalid: left child greater than root
        new object[]
        {
            new TreeNode(2,
                new TreeNode(3),
                OneNodeBST
            ),
            false
        },

        // Invalid deeper violation
        //       5
        //      / \
        //     1   6
        //        / \
        //       3   7
        new object[]
        {
            new TreeNode(5,
                OneNodeBST,
                new TreeNode(6,
                    new TreeNode(3),
                    new TreeNode(7))
            ),
            false
        },

        // Valid BST with negative values
        new object[]
        {
            new TreeNode(0,
                new TreeNode(-3),
                new TreeNode(9)
            ),
            true
        },

        // Invalid because of duplicate values
        //     2
        //    / \
        //   2   3
        new object[]
        {
            new TreeNode(2,
                new TreeNode(2),
                new TreeNode(3)
            ),
            false
        },

        // Invalid: right subtree contains smaller value
        //       10
        //      /  \
        //     5    15
        //         / \
        //        6   20
        new object[]
        {
            new TreeNode(10,
                new TreeNode(5),
                new TreeNode(15,
                    new TreeNode(6),
                    new TreeNode(20))
            ),
            false
        },

        // Valid large BST
        new object[]
        {
            new TreeNode(8,
                new TreeNode(3,
                    OneNodeBST,
                    new TreeNode(6,
                        new TreeNode(4),
                        new TreeNode(7))),
                new TreeNode(10,
                    null,
                    new TreeNode(14,
                        new TreeNode(13),
                        null))
            ),
            true
        }
    };

    #endregion

    #region 100

    [TestCaseSource(typeof(SameTreeTestData), nameof(SameTreeTestData.TestCases))]
    public void Test_IsSameTree(TreeNode p, TreeNode q, bool expected)
    {
        bool result = IsSameTree(p, q);

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

    #region 102

    [TestCaseSource(nameof(LevelOrderTestCases))]
    public void LevelOrder_ShouldReturnCorrectLevels(
       TreeNode root,
       IList<IList<int>> expected)
    {
        // Act
        var result = LevelOrder(root);

        // Assert
        Assert.That(result, Is.Not.Null);
        TreesAsserts.AssertLevelsEqual(expected, result);
    }

    public static object[] LevelOrderTestCases =
    {
        // Empty tree
        new object[]
        {
            null,
            new List<IList<int>>()
        },

        // Single node
        new object[]
        {
            OneNodeBST,
            new List<IList<int>>
            {
                new List<int> { 1 }
            }
        },

        // Simple BST: 2 -> (1, 3)
        new object[]
        {
            SimpleBST,
            new List<IList<int>>
            {
                new List<int> { 2 },
                new List<int> { 1, 3 }
            }
        },

        // Simple BST 2: 1 -> (2, 3)
        new object[]
        {
            SimpleBST2,
            new List<IList<int>>
            {
                new List<int> { 1 },
                new List<int> { 2, 3 }
            }
        },

        // Left skewed BST
        // 3
        // |
        // 2
        // |
        // 1
        new object[]
        {
            LeftSkewedBST,
            new List<IList<int>>
            {
                new List<int> { 3 },
                new List<int> { 2 },
                new List<int> { 1 }
            }
        },

        // Deep left skewed BST
        new object[]
        {
            LeftSkewedBST2,
            new List<IList<int>>
            {
                new List<int> { 1 },
                new List<int> { 2 },
                new List<int> { 3 },
                new List<int> { 4 }
            }
        },

        // Right skewed BST
        new object[]
        {
            RightSkewedBST,
            new List<IList<int>>
            {
                new List<int> { 1 },
                new List<int> { 2 },
                new List<int> { 3 }
            }
        }
    };

   

    #endregion

    #region 104

    [TestCaseSource(nameof(MaxDepthTestCases))]
    public void MaxDepth_ShouldReturnCorrectDepth(
       TreeNode root,
       int expected)
    {
        // Act
        var result = MaxDepth(root);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    public static object[] MaxDepthTestCases =
    {
        // Empty tree
        new object[]
        {
            null,
            0
        },

        // Single node
        new object[]
        {
            OneNodeBST,
            1
        },

        // Balanced tree
        //       3
        //      / \
        //     9  20
        //        / \
        //       15  7
        new object[]
        {
            new TreeNode(3,
                new TreeNode(9),
                new TreeNode(20,
                    new TreeNode(15),
                    new TreeNode(7))
            ),
            3
        },

        // Left-skewed tree
        // 1 -> 2 -> 3 -> 4
        new object[]
        {
            LeftSkewedBST2,
            4
        },

        // Right-skewed tree
        new object[]
        {
            RightSkewedBST,
            3
        },

        // Complete binary tree
        //        1
        //       / \
        //      2   3
        //     / \  /
        //    4  5 6
        new object[]
        {
            new TreeNode(1,
                new TreeNode(2,
                    new TreeNode(4),
                    new TreeNode(5)),
                new TreeNode(3,
                    new TreeNode(6),
                    null)
            ),
            3
        },

        // Tree with negative values
        new object[]
        {
            new TreeNode(-1,
                new TreeNode(-2,
                    new TreeNode(-3),
                    null),
                null
            ),
            3
        }
    };

    #endregion

    #region 107


    [TestCaseSource(nameof(LevelOrderBottomTestCases))]
    public void LevelOrderBottom_ShouldReturnCorrectLevels(
       TreeNode root,
       IList<IList<int>> expected)
    {
        // Act
        var result = LevelOrderBottom(root);

        // Assert
        Assert.That(result, Is.Not.Null);
        TreesAsserts.AssertLevelsEqual(expected, result);
    }

    public static object[] LevelOrderBottomTestCases =
    {
        // Empty tree
        new object[]
        {
            null,
            new List<IList<int>>()
        },

        // Single node
        new object[]
        {
            OneNodeBST,
            new List<IList<int>>
            {
                new List<int> { 1 }
            }
        },

        // Simple BST: 2 -> (1, 3)
        new object[]
        {
            SimpleBST,
            new List<IList<int>>
            {
                new List<int> { 1, 3 },
                new List<int> { 2 }
            }
        },

        // Simple BST 2: 1 -> (2, 3)
        new object[]
        {
            SimpleBST2,
            new List<IList<int>>
            {
                new List<int> { 2, 3 },
                new List<int> { 1 }
            }
        },

        // Left skewed BST
        // 3
        // |
        // 2
        // |
        // 1
        new object[]
        {
            LeftSkewedBST,
            new List<IList<int>>
            {
                new List<int> { 1 },
                new List<int> { 2 },
                new List<int> { 3 }
            }
        },

        // Deep left skewed BST
        new object[]
        {
            LeftSkewedBST2,
            new List<IList<int>>
            {
                new List<int> { 4 },
                new List<int> { 3 },
                new List<int> { 2 },
                new List<int> { 1 }
            }
        },

        // Right skewed BST
        new object[]
        {
            RightSkewedBST,
            new List<IList<int>>
            {
                new List<int> { 3 },
                new List<int> { 2 },
                new List<int> { 1 }
            }
        }
    };


    #endregion

    #region 108

    public static IEnumerable<TestCaseData> ConvertTestCases()
    {
        yield return new TestCaseData(
           new int[] { 1, 2, 3, 4, 5, 6, 7 },
           new TreeNode(4,
               SimpleBST,
               new TreeNode(6,
                   new TreeNode(5),
                   new TreeNode(7)))
       );
        yield return new TestCaseData(
            new int[] { 1 },
            OneNodeBST
        );

        yield return new TestCaseData(
            new int[] { 1, 3 },
            new TreeNode(3,
                OneNodeBST,
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
        var result = SortedArrayToBST(nums);

        Assert.IsTrue(TreeHelpers.AreEqualTrees(expected, result), "Generated tree does not match expected");
    }

    #endregion

    #region 110

    [TestCaseSource(typeof(BalancedTreeTestData), nameof(BalancedTreeTestData.TestCases))]
    public void TestBalancedBinaryTree(TreeNode root, bool expected)
    {
        Assert.That(IsBalanced(root), Is.EqualTo(expected));
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

    #region 111 

    [TestCaseSource(nameof(MinDepthTestCases))]
    public void MinDepth_ShouldReturnCorrectDepth(
        TreeNode root,
        int expected)
    {
        // Act
        var result = MinDepth(root);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    public static object[] MinDepthTestCases =
    {
        // Empty tree
        new object[]
        {
            null,
            0
        },

        // Single node
        new object[]
        {
            OneNodeBST,
            1
        },

        // Simple balanced tree
        //     1
        //    / \
        //   2   3
        new object[]
        {
           SimpleBST2,
            2
        },

        // Left-skewed tree
        // 1 -> 2 -> 3 -> 4
        new object[]
        {
            LeftSkewedBST2,
            4
        },

        // Right-skewed tree
        new object[]
        {
            RightSkewedBST,
            3
        },

        // One child only (must not take min of 0)
        //     1
        //    /
        //   2
        new object[]
        {
            new TreeNode(1,
                new TreeNode(2),
                null
            ),
            2
        },

        // Leaf on one side only
        //     1
        //      \
        //       2
        new object[]
        {
            new TreeNode(1,
                null,
                new TreeNode(2)
            ),
            2
        },

        // More complex tree
        //        10
        //       /  \
        //      5    15
        //           \
        //            18
        new object[]
        {
            new TreeNode(10,
                new TreeNode(5),
                new TreeNode(15,
                    null,
                    new TreeNode(18))
            ),
            2
        }
    };

    #endregion

    #region 112

    [TestCaseSource(typeof(PathSumTestData), nameof(PathSumTestData.TestCases))]
    public void Test_HasPathSum(TreeNode root, int targetSum, bool expected)
    {
        bool result = HasPathSum(root, targetSum);

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
        var result = PreorderTraversal(root);

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
        var result = PostorderTraversal(root);

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
        var result = InvertTree(input);

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
            OneNodeBST,
            OneNodeBST
        },

        // Simple tree
        //   2          2
        //  / \   ->   / \
        // 1   3      3   1
        new object[]
        {
            SimpleBST,
            new TreeNode(2,
                new TreeNode(3),
                OneNodeBST
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
                SimpleBST,
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
                    OneNodeBST
                )
            )
        },

        // Left-skewed tree
        new object[]
        {
            LeftSkewedBST,
            new TreeNode(3,
                null,
                new TreeNode(2,
                    null,
                    OneNodeBST)
            )
        },

        // Right-skewed tree
        new object[]
        {
            RightSkewedBST,
            new TreeNode(1,
                new TreeNode(2,
                    new TreeNode(3),
                    null),
                null
            )
        }
    };

    #endregion

    #region 257

    [TestCaseSource(nameof(BinaryTreePathsTestCases))]
    public void BinaryTreePaths_ShouldReturnAllRootToLeafPaths(
       TreeNode root,
       IList<string> expected)
    {
        // Act
        var result = BinaryTreePaths(root);

        // Assert
        Assert.That(result, Is.Not.Null);
        CollectionAssert.AreEquivalent(expected, result);
    }

    public static object[] BinaryTreePathsTestCases =
    {
         // Left-skewed tree
        // 1 -> 2 -> 3 -> 4
        new object[]
        {
            LeftSkewedBST2,
            new List<string>
            {
                "1->2->3->4"
            }
        },

        // Empty tree
        new object[]
        {
            null,
            new List<string>()
        },

        // Single node
        new object[]
        {
            OneNodeBST,
            new List<string> { "1" }
        },

        // Simple tree
        //     1
        //    / \
        //   2   3
        new object[]
        {
            SimpleBST2,
            new List<string>
            {
                "1->2",
                "1->3"
            }
        },

        // LeetCode example
        //     1
        //    / \
        //   2   3
        //    \
        //     5
        new object[]
        {
            new TreeNode(1,
                new TreeNode(2,
                    null,
                    new TreeNode(5)),
                new TreeNode(3)
            ),
            new List<string>
            {
                "1->2->5",
                "1->3"
            }
        },

       
        // Right-skewed tree
        new object[]
        {
            RightSkewedBST,
            new List<string>
            {
                "1->2->3"
            }
        },

        // Tree with negative values
        new object[]
        {
            new TreeNode(-1,
                new TreeNode(-2),
                new TreeNode(3)
            ),
            new List<string>
            {
                "-1->-2",
                "-1->3"
            }
        },

        // More complex tree
        //        10
        //       /  \
        //      5    15
        //     / \     \
        //    3   7     18
        new object[]
        {
            new TreeNode(10,
                new TreeNode(5,
                    new TreeNode(3),
                    new TreeNode(7)),
                new TreeNode(15,
                    null,
                    new TreeNode(18))
            ),
            new List<string>
            {
                "10->5->3",
                "10->5->7",
                "10->15->18"
            }
        }
    };

    #endregion

    #region 449

    [TestCaseSource(nameof(SerializeDeserializeBSTTestCases))]
    public void SerializeDeserializeBST_ShouldPreserveTreeStructure(TreeNode root)
    {
        // Arrange
        var codec = new Codec();

        // Act
        var serialized = codec.serialize(root);
        var deserialized = codec.deserialize(serialized);

        // Assert
        Assert.That(TreeHelpers.AreEqualTrees(root, deserialized));
    }

    public static object[] SerializeDeserializeBSTTestCases =
    {
        // Empty tree
        new object[]
        {
            null
        },

        // Single node
        new object[]
        {
            OneNodeBST
        },

        // Simple BST
        //     2
        //    / \
        //   1   3
        new object[]
        {
            SimpleBST
        },

        // Left-skewed BST
        // 5 -> 4 -> 3 -> 2 -> 1
        new object[]
        {
            new TreeNode(5,
                new TreeNode(4,
                    LeftSkewedBST,
                    null),
                null
            )
        },

        // Right-skewed BST
        new object[]
        {
            new TreeNode(1,
                null,
                new TreeNode(2,
                    null,
                    new TreeNode(3,
                        null,
                        new TreeNode(4)))
            )
        },

        // Balanced BST
        //        8
        //       / \
        //      3   10
        //     / \    \
        //    1   6    14
        //       / \   /
        //      4   7 13
        new object[]
        {
            new TreeNode(8,
                new TreeNode(3,
                    OneNodeBST,
                    new TreeNode(6,
                        new TreeNode(4),
                        new TreeNode(7))),
                new TreeNode(10,
                    null,
                    new TreeNode(14,
                        new TreeNode(13),
                        null))
            )
        },

        // BST with negative values
        new object[]
        {
            new TreeNode(0,
                new TreeNode(-3,
                    new TreeNode(-10),
                    null),
                new TreeNode(9,
                    new TreeNode(5),
                    null))
        }
    };

    #endregion

    #region 563

    [TestCaseSource(nameof(FindTiltTestCases))]
    public void FindTilt_ShouldReturnCorrectTilt(TreeNode input, int expected)
    {
        // Act
        var result = FindTilt(input);

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
            OneNodeBST,
            0
        },

        // LeetCode example
        //   1
        //  / \
        // 2   3
        // Tilt = |2 - 3| = 1
        new object[]
        {
            SimpleBST2,
            1
        },

    };

    #endregion

    #region 606

    [TestCaseSource(nameof(Tree2strTestCases))]
    public void Tree2str_ShouldConstructCorrectString(
       TreeNode root,
       string expected)
    {
        // Act
        var result = Tree2str(root);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    public static object[] Tree2strTestCases =
    {
        // Empty tree
        new object[]
        {
            null,
            string.Empty
        },

        // Single node
        new object[]
        {
            OneNodeBST,
            "1"
        },

        // Simple tree
        //     1
        //    / \
        //   2   3
        new object[]
        {
            SimpleBST2,
            "1(2)(3)"
        },

        // LeetCode example 1
        //     1
        //    / \
        //   2   3
        //    \
        //     4
        new object[]
        {
            new TreeNode(1,
                new TreeNode(2,
                    null,
                    new TreeNode(4)),
                new TreeNode(3)
            ),
            "1(2()(4))(3)"
        },

        // LeetCode example 2
        //     1
        //    /
        //   2
        //  /
        // 3
        new object[]
        {
            new TreeNode(1,
                new TreeNode(2,
                    new TreeNode(3),
                    null),
                null
            ),
            "1(2(3))"
        },

        // Right child only (must include empty parentheses)
        //     1
        //      \
        //       2
        new object[]
        {
            new TreeNode(1,
                null,
                new TreeNode(2)
            ),
            "1()(2)"
        },

        // More complex tree
        //        10
        //       /  \
        //      5    15
        //       \
        //        7
        new object[]
        {
            new TreeNode(10,
                new TreeNode(5,
                    null,
                    new TreeNode(7)),
                new TreeNode(15)
            ),
            "10(5()(7))(15)"
        },

        // Tree with negative values
        new object[]
        {
            new TreeNode(-1,
                new TreeNode(-2),
                new TreeNode(3)
            ),
            "-1(-2)(3)"
        }
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
        var result = MergeTrees(root1, root2);

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
            OneNodeBST,
            null,
            OneNodeBST
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

    #region 652

    [TestCaseSource(nameof(FindDuplicateSubtreesTestCases))]
    public void FindDuplicateSubtrees_ShouldReturnDuplicateRoots(
       TreeNode root,
       IList<TreeNode> expected)
    {
        // Act
        var result = FindDuplicateSubtrees(root);

        // Assert
        Assert.That(result, Is.Not.Null);
        AssertDuplicateSubtrees(expected, result);
    }

    public static object[] FindDuplicateSubtreesTestCases =
    {
        // Empty tree
        new object[]
        {
            null,
            new List<TreeNode>()
        },

        // Single node (no duplicates)
        new object[]
        {
            OneNodeBST,
            new List<TreeNode>()
        },

        // Two identical leaf nodes
        //    1
        //   / \
        //  2   2
        new object[]
        {
            new TreeNode(1,
                new TreeNode(2),
                new TreeNode(2)
            ),
            new List<TreeNode>
            {
                new TreeNode(2)
            }
        },

        // LeetCode example
        //        1
        //       / \
        //      2   3
        //     /   / \
        //    4   2   4
        //       /
        //      4
        new object[]
        {
            new TreeNode(1,
                new TreeNode(2,
                    new TreeNode(4),
                    null),
                new TreeNode(3,
                    new TreeNode(2,
                        new TreeNode(4),
                        null),
                    new TreeNode(4))
            ),
            new List<TreeNode>
            {
                new TreeNode(2,
                    new TreeNode(4),
                    null),
                new TreeNode(4)
            }
        },

        // Multiple duplicates of same subtree (should return once)
        //        1
        //       / \
        //      2   2
        //     /   /
        //    3   3
        new object[]
        {
            new TreeNode(1,
                new TreeNode(2,
                    new TreeNode(3),
                    null),
                new TreeNode(2,
                    new TreeNode(3),
                    null)
            ),
            new List<TreeNode>
            {
                new TreeNode(2,
                    new TreeNode(3),
                    null),
                new TreeNode(3)
            }
        },

        // No duplicates
        new object[]
        {
            SimpleBST2,
            new List<TreeNode>()
        },

        // Duplicate complex subtrees
        //        5
        //       / \
        //      1   1
        //     / \ / \
        //    2  3 2  3
        new object[]
        {
            new TreeNode(5,
                SimpleBST2,
                SimpleBST2
            ),
            new List<TreeNode>
            {
                SimpleBST2,
                new TreeNode(2),
                new TreeNode(3)
            }
        }
    };

    // ----------------------
    // Helper assertions
    // ----------------------
    private static void AssertDuplicateSubtrees(
        IList<TreeNode> expected,
        IList<TreeNode> actual)
    {
        Assert.That(actual.Count, Is.EqualTo(expected.Count), "Duplicate count mismatch");

        var expectedSerialized = expected
            .Select(TreeHelpers.SerializeTree)
            .ToHashSet();

        var actualSerialized = actual
            .Select(TreeHelpers.SerializeTree)
            .ToHashSet();

        CollectionAssert.AreEquivalent(expectedSerialized, actualSerialized);
    }


    #endregion

    #region 2458

    [TestCaseSource(nameof(TreeQueriesTestCases))]
    public void TreeQueries_ShouldReturnCorrectHeights(
        TreeNode root,
        int[] queries,
        int[] expected)
    {
        // Act
        var result = TreeQueries(root, queries);

        // Assert
        Assert.That(result, Is.Not.Null);
        CollectionAssert.AreEqual(expected, result);
    }

    public static object[] TreeQueriesTestCases =
    {
        // LeetCode example
        //        1
        //       / \
        //      3   4
        //     /   / \
        //    2   6   5
        //
        // Heights (edges):
        // Full tree height = 2
        new object[]
        {
            new TreeNode(1,
                new TreeNode(3,
                    new TreeNode(2),
                    null),
                new TreeNode(4,
                    new TreeNode(6),
                    new TreeNode(5))
            ),
            new[] { 4, 3, 6 },
            new[] { 2, 2, 2 }
        },

        // Removing root → empty tree
        new object[]
        {
            SimpleBST2,
            new[] { 1 },
            new[] { 0 }
        },

        // Skewed left tree
        // 1 - 2 - 3 - 4
        new object[]
        {
            LeftSkewedBST2,
            new[] { 4, 3, 2 },
            new[] { 2, 1, 0 }
        },

        // Skewed right tree
        new object[]
        {
            new TreeNode(1,
                null,
                new TreeNode(2,
                    null,
                    new TreeNode(3,
                        null,
                        new TreeNode(4)))
            ),
            new[] { 2, 3 },
            new[] { 0, 1 }
        },

        // Balanced tree
        //        10
        //       /  \
        //      5    15
        //     / \     \
        //    3   7     18
        new object[]
        {
            new TreeNode(10,
                new TreeNode(5,
                    new TreeNode(3),
                    new TreeNode(7)),
                new TreeNode(15,
                    null,
                    new TreeNode(18))
            ),
            new[] { 5, 15, 3 },
            new[] { 2, 2, 2 }
        },

        // Leaf removals only
        new object[]
        {
            SimpleBST2,
            new[] { 2, 3 },
            new[] { 1, 1 }
        },

        // Deep subtree removal changes height
        //        1
        //       / \
        //      2   3
        //         /
        //        4
        //       /
        //      5
        new object[]
        {
            new TreeNode(1,
                new TreeNode(2),
                new TreeNode(3,
                    new TreeNode(4,
                        new TreeNode(5),
                        null),
                    null)
            ),
            new[] { 3, 4 },
            new[] { 1, 2 }
        }
    };

    #endregion
}