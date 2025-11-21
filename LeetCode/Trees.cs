using LeetCodeTasks.Helpers;

namespace LeetCodeTasks.LeetCode;

public static class Trees
{
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
}
