using EdkoSKD.Common.Models;
using EdkoSKD.Common.Trees;
using System.Text;

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

    #region 98 Valid binary tree - 17/5 poor performance

    public static bool IsValidBST(TreeNode root)
    {
        //go to childs and return min and max val
        //on parent level, check that min left < max left < val && val < min right < max right

        TreeValidityModel IsValidBTSInternal(TreeNode node)
        {
            if(node == null)
            {
                return TreeValidityModel.New(null, null);
            }

            var leftState = IsValidBTSInternal(node.left);
            var rightState = IsValidBTSInternal(node.right);

            if(!leftState.IsTreeValid || !rightState.IsTreeValid)
            {
                leftState.IsTreeValid = false;
                return leftState;
            }

            if(leftState.MinValue == null && leftState.MaxValue == null)
            {
                leftState.MinValue = node.val;
            }

            if(leftState.MaxValue >= node.val ||  rightState.MinValue <= node.val)
            {
                leftState.IsTreeValid = false;
                return leftState;
            }

            if(rightState.MaxValue != null)
            {
                leftState.MaxValue = rightState.MaxValue;
            }
            else
            {
                leftState.MaxValue = node.val;
            }

            return leftState;
        }

        return IsValidBTSInternal(root).IsTreeValid;
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

    #region 104 Max Depth of Binary Tree - 100/27.3

    public static int MaxDepth(TreeNode root)
    {
        return root.MaxDepth();
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

    #region 102 Binary Tree Level Order Traversal - 100/15.3 bad memory for DFS || 100/53.7 improvement with BFS

    public static IList<IList<int>> LevelOrderDFS(TreeNode root)
    {
        var result = new List<IList<int>>();

        if(root == null)
        {
            return result;
        }

        result.Add(new List<int>());
        LevelOrderInternal(root, 0);

        void LevelOrderInternal(TreeNode node, int level)
        {
            if(node == null)
            {
                return;
            }

            if(result.Count <= level)
            {
                result.Add(new List<int>());
            }
            result[level].Add(node.val);

            LevelOrderInternal(node.left, level + 1);
            LevelOrderInternal(node.right, level + 1);
        }
        return result;
    }

    public static IList<IList<int>> LevelOrder(TreeNode root)
    {
        var result = new List<IList<int>>();
        if (root == null)
        {
            return result;
        }

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            int size = queue.Count;
            var level = new List<int>(size);

            for (int i = 0; i < size; i++)
            {
                var node = queue.Dequeue();
                level.Add(node.val);

                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }

                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }
            }

            result.Add(level);
        }

        return result;
    }

    #endregion

    #region 107 Binary Tree Level Order Traversal BFS

    public static IList<IList<int>> LevelOrderBottom(TreeNode root)
    {
        var result = new List<IList<int>>();
        if (root == null)
        {
            return result;
        }
        var stack = new Stack<int>();

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while(queue.Count > 0)
        {
            int size = queue.Count;
            var level = new List<int> { size };
            result.Add(level);

            for (int i = 0; i < size; i++)
            {
                var node = queue.Dequeue();
                stack.Push(node.val) ;

                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }

                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }
            }
        }

        for(int i = result.Count - 1; i >= 0 ; i--)
        {
            var size = result[i][0];
            for (int j = 0; j < size; j++)
            {
                result[i][j] = stack.Pop();
            }
        }

        return result;
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

    #region 111 - 23/29.7 poor perf

    public static int MinDepth(TreeNode root)
    {
        if(root ==null)
        {
            return 0;
        }

        return MinDepth(root);

        int MinDepth(TreeNode? node)
        {
            if (node == null)
            {
                return int.MaxValue;
            }

            if(node.left == null && node.right  == null)
            {
                return 1;
            }

            int leftDepth = MinDepth(node.left);
            int rightDepth = MinDepth(node.right);

            return Math.Min(leftDepth, rightDepth) + 1;
        }
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

    #region 257 Binary Tree Path - 54/13.7 memory unoptimal

    public static IList<string> BinaryTreePaths(TreeNode root)
    {
        var list = new List<string>();

        if(root == null)
        {
            return list;
        }
       
        StringBuilder currentPath = new StringBuilder(root.val.ToString());

        Iterate(root);

        void Iterate(TreeNode node)
        {
            if(node.left == null && node.right == null)
            {
                list.Add(currentPath.ToString());
                return;
            }

            int currentPathLength = currentPath.Length;
            if(node.left != null)
            {
                currentPath.Append("->" + node.left.val.ToString());
                Iterate(node.left);
                currentPath.Remove(currentPathLength, currentPath.Length - currentPathLength);
            }
            if(node.right != null)
            {
                currentPath.Append("->" + node.right.val.ToString());
                Iterate(node.right);
                currentPath.Remove(currentPathLength, currentPath.Length - currentPathLength);
            }
            
        }

        return list;
    }

    #endregion

    #region 297 Serialize/Deserialize BST 2 - 41/96

    public class Codec2
    {
        public string serialize(TreeNode root)
        {
            return root.SerializeTree();
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            return TreeSerializator.Deserialize(data);
        }
    }

    #endregion

    #region 449 Serialize and Deserialize BST - 70/16 bad memory management

    public class Codec
    {

        public string serialize(TreeNode root)
        {
            return root.SerializeTree();
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            return TreeSerializator.Deserialize(data);
        }
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

    #region 606 Construct String from Binary Tree - 70.3/70.3 Pretty nice performance from the first attempt

    public static string Tree2str(TreeNode root)
    {
        StringBuilder sb = new StringBuilder();
        
        PreOrderTrav(root, true);

        void PreOrderTrav(TreeNode node, bool isHead = false, bool isLeft = false)
        {
            if(node == null) { 
                if(isLeft)
                {
                    sb.Append("()");
                }
                return; 
            }
            if(!isHead)
            {
                sb.Append("(");
            }
            sb.Append($"{node.val}");
            PreOrderTrav(node.left, false, node.right != null);
            PreOrderTrav(node.right);
            if(!isHead)
            sb.Append(")");
        }

        return sb.ToString();
    }

    #endregion

    #region 617 - 100/39 not optimal memory || 6/22 bad performance when no mutation on first tree || 33/37 still not optimal memory

    public static TreeNode MergeTreesMy(TreeNode root1, TreeNode root2)
    {
        if(root2 == null)
        {
            return root1;
        }

        if(root1 == null)
        {
            root1 = root2;
            return root1;
        }

        root1.val += root2.val;

        root1.left = MergeTreesMy(root1.left, root2.left);
        root1.right = MergeTreesMy(root1.right, root2.right);
        
        return root1;

    }

    public static TreeNode MergeTreesSecond(TreeNode root1, TreeNode root2)
    {
        if (root1 == null && root2 == null)
            return null;

        int val = (root1?.val ?? 0) + (root2?.val ?? 0);

        return new TreeNode(val)
        {
            left = MergeTreesSecond(root1?.left, root2?.left),
            right = MergeTreesSecond(root1?.right, root2?.right)
        };
    }

    public static TreeNode MergeTrees(TreeNode root1, TreeNode root2)
    {
        if (root1 == null) return root2;
        if (root2 == null) return root1;

        var stack = new Stack<(TreeNode, TreeNode)>();
        stack.Push((root1, root2));

        while (stack.Count > 0)
        {
            var (n1, n2) = stack.Pop();

            n1.val += n2.val;

            if (n1.left == null)
                n1.left = n2.left;
            else if (n2.left != null)
                stack.Push((n1.left, n2.left));

            if (n1.right == null)
                n1.right = n2.right;
            else if (n2.right != null)
                stack.Push((n1.right, n2.right));
        }

        return root1;
    }

    #endregion

    #region 652 Find Duplicate Subtrees - 5/7.7 poor performance and memory management

    public static IList<TreeNode> FindDuplicateSubtrees(TreeNode root)
    {
        HashSet<string> serializedTrees = new HashSet<string>();
        Dictionary<string, TreeNode> uniqueDuplicatedTrees = new Dictionary<string, TreeNode>();

        ProcessTree(root);

        void ProcessTree(TreeNode node)
        {
            if(node == null)
            {
                return;
            }

            var serializedTree = TreeHelpers.SerializeTree(node);
            var currentSerializedTreeCount = serializedTrees.Count;
            serializedTrees.Add(serializedTree);
            if(serializedTrees.Count == currentSerializedTreeCount)
            {
                uniqueDuplicatedTrees.TryAdd(serializedTree,node);
            }

            ProcessTree(node.left);
            ProcessTree(node.right);
        }

        return uniqueDuplicatedTrees.Select(x => x.Value).ToList();
    }

    #endregion

    #region 2458 Height of binary tree after sub tree removal queries - Not solved

    public static int[] TreeQueries(TreeNode root, int[] queries)
    {

        int[] results = new int[queries.Length];

        return results;
    }

    #endregion
}
