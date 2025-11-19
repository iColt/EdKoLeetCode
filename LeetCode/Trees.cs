using LeetCodeTasks.Helpers;

namespace LeetCodeTasks.LeetCode;

public static class Trees
{
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
}
