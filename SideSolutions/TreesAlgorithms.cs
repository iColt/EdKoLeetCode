using EdkoSKD.Common.Models;

namespace LeetCodeTasks.SideSolutions;

public class TreesAlgorithms
{

    /// <summary>
    /// Idea - compute path of longest subtree, then check if input from query exist in path
    /// </summary>
    /// <param name="root">root of the tree</param>
    /// <param name="queries">list of nodes to check</param>
    /// <returns></returns>
    public static int[] TreeQueries(TreeNode root, int[] queries)
    {

        List<int> MaxDepthPath(TreeNode node)
        {
            if (node == null)
            {
                return new List<int>();
            }

            if (node.left == null && node.right == null)
            {
                return new List<int> { node.val };
            }

            var leftSideDepth = MaxDepthPath(node.left);
            var rightSideDepth = MaxDepthPath(node.right);

            if (leftSideDepth.Count > rightSideDepth.Count)
            {
                leftSideDepth.Add(node.val);
                return leftSideDepth;
            }
            else
            {
                rightSideDepth.Add(node.val);
                return rightSideDepth;
            }
        }

        int[] results = new int[queries.Length];

        var maxDepthPath = MaxDepthPath(root);
        maxDepthPath.Sort();
        var arr = maxDepthPath.ToArray<int>();

        for (int i = 0; i < queries.Length; i++)
        {
            if (Array.BinarySearch(arr, queries[i]) >= 0)
            {
                results[i] = maxDepthPath.Count;
            }
            else
            {
                results[i] = maxDepthPath.Count - 1;
            }
        }

        return results;
    }

}
