using EdkoSKD.Common.Models;
using EdkoSKD.Common.Trees;

namespace LeetCodeTasks.LeetCode;

public static class Trees
{
    #region 94 Binary Tree Inorder Traversal - 100/90

    public static IList<int> InorderTraversal(TreeNode root)
    {
        var result = new List<int>();

        if (root == null)
        {
            return result;
        }

        result.AddRange(InorderTraversal(root.left));
        result.Add(root.val);
        result.AddRange(InorderTraversal(root.right));

        return result;
    }

    #endregion

    #region 100 Same tree - 100/35

    public static bool IsSameTree(TreeNode p, TreeNode q)
    {
        if(p == null && q == null)
        {
            return true;
        }

        if((p == null && q != null) || (p != null && q == null)) {
            return false;
        }

        if (p.val != q.val)
        {
            return false;
        }

        if(!IsSameTree(p.left, q.left))
        {
            return false;
        }

        return IsSameTree(p.right, q.right);
    }

    #endregion

    #region 101 Symmetric tree - 100/58.2

    public static bool IsSymmetric(TreeNode root)
    {
        if(root == null)
        {
            return true;
        }

        return IsLeafsSymmetric(root.left, root.right);
    }

    private static bool IsLeafsSymmetric(TreeNode left, TreeNode right)
    {
        if(left == null && right == null)
        {
            return true;
        }

        if(left == null || right == null)
        {
            return false;
        }

        if(left.val != right.val) { 
            return false; 
        }

        return IsLeafsSymmetric(left.left, right.right) && IsLeafsSymmetric(left.right, right.left);
    }

    #endregion

    #region 108 Convert sorted array to Binary Search tree - 100/66

    public static TreeNode SortedArrayToBST(int[] nums)
    {
        if(nums.Length == 1)
        {
            return new TreeNode(nums[0]);
        }

        int length = nums.Length;

        return BuildBST(nums, 0, length - 1);
    }

    private static TreeNode BuildBST(int[] nums, int startIndex,  int endIndex)
    {
        if(endIndex - startIndex == 1)
        {
            return new TreeNode
            {
                val = nums[endIndex],
                left = new TreeNode(nums[startIndex]),
            };
        }

        if(startIndex == endIndex)
        {
            return new TreeNode(nums[startIndex]);
        }

        int currentTop = (endIndex + startIndex) / 2;
        TreeNode topNode = new TreeNode(nums[currentTop]);
        topNode.left = BuildBST(nums, startIndex, currentTop - 1);
        topNode.right = BuildBST(nums, currentTop + 1, endIndex);


        return topNode;
    }

    #endregion

    #region 110 Balanced Binary Tree - 100/17.8 non effective memory consumption

    public static bool IsBalanced(TreeNode root)
    {
        if(root == null || (root.left == null && root.right == null))
        {
            return true;
        }

        int leftSubTreeHeight = SubTreeHeight(root.left, 0);
        int rightSubTreeHeight = SubTreeHeight(root.right, 0);

        if(leftSubTreeHeight == -1 || rightSubTreeHeight == -1)
        {
            return false;
        }

        if(Math.Abs(leftSubTreeHeight - rightSubTreeHeight) < 2)
        {
            return true;
        }

        return false;
    }

    private static int SubTreeHeight(TreeNode root, int currentHeight)
    {
        if(root == null)
        {
            return currentHeight;
        }

        int leftSubTreeHeight = SubTreeHeight(root.left, currentHeight + 1);
        int rightSubTreeHeight = SubTreeHeight(root.right, currentHeight + 1);

        if (leftSubTreeHeight == -1 || rightSubTreeHeight == -1)
        {
            return -1;
        }

        if (Math.Abs(leftSubTreeHeight - rightSubTreeHeight) > 1)
        {
            //return impossible value
            return -1;
        }

        return leftSubTreeHeight > rightSubTreeHeight ? leftSubTreeHeight : rightSubTreeHeight;
    }

    #endregion

    #region 112 Path Sum - 100/58.7

    public static bool HasPathSum(TreeNode root, int targetSum)
    {
        if(root == null) return false;

        if(root.left == null && root.right == null) return root.val == targetSum;

        if(HasPathSum(root.left, targetSum - root.val))
        {
            return true;
        }

        return HasPathSum(root.right, targetSum - root.val);
    }

    #endregion

    #region 144 Binary Tree Preorder traversal - 100/53

    public static IList<int> PreorderTraversal(TreeNode root)
    {
        var result = new List<int>();

        if (root == null)
        {
            return result;
        }

        result.Add(root.val);

        result.AddRange(PreorderTraversal(root.left));
        result.AddRange(PreorderTraversal(root.right));

        return result;
    }

    #endregion

    #region 145 Binary Tree Postorder traversal - 100/35.5

    public static IList<int> PostorderTraversal(TreeNode root)
    {
        var result = new List<int>();

        if (root == null)
        {
            return result;
        }

        result.AddRange(PostorderTraversal(root.left));
        result.AddRange(PostorderTraversal(root.right));

        result.Add(root.val);

        return result;
    }

    #endregion

    #region 226 Invert Binary Tree - 100/67.5

    public static TreeNode InvertTree(TreeNode root)
    {
        if(root == null)
        {
            return null;
        }

        TreeNode newLeft = InvertTree(root.right);
        root.right = InvertTree(root.left);
        root.left = newLeft;

        return root;
    }

    #endregion

    #region 563 - Binary Tree Tilt - 5/71 poor performance || 10/6 2nd attempt, poorest :) || 100/22 slow memory for some reason :)

    // Improvement idea - create second tree, where sum will be calculated 
    public static int FindTiltOld(TreeNode root)
    {
        int sum = 0;

        if(root == null || (root.left == null && root.right == null))
        {
            return 0;
        }

        sum += Math.Abs(root.left.FindBinaryTreeNodeSum() - root.right.FindBinaryTreeNodeSum());

        sum += FindTilt(root.left);
        sum += FindTilt(root.right);

        return sum;
    }

    public static int FindTiltOld2(TreeNode root) {

        if (root == null || (root.left == null && root.right == null))
        {
            return 0;
        }

        var tiltTree = root.BuildTiltTree();

        return tiltTree.FindBinaryTreeNodeSum();
    }

    public static int FindTilt(TreeNode root)
    {
        int sum = 0;

        DFS(root);

        int DFS(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            int leftSum = DFS(root.left);
            int rightSum = DFS(root.right);

            sum += Math.Abs(leftSum - rightSum);

            return root.val + leftSum + rightSum;
        }

        return sum;
    }
    #endregion

    #region 617

    public static TreeNode MergeTrees(TreeNode root1, TreeNode root2)
    {
        return root1;
    }

    #endregion
}
