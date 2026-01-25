using EdkoSKD.Common.Models;

namespace LeetCodeTasks.LeetCode;

public static class DataStructures
{
    #region 146 LRU Cache Not Solved

    public class LRUCache
    {

        public LRUCache(int capacity)
        {

        }

        public int Get(int key)
        {
            return 0;
        }

        public void Put(int key, int value)
        {

        }
    }

    #endregion

    #region 173 Binary Search Tree Iterator - 100/12.6 poor memory

    public class BSTIterator
    {
        private TreeNode _root;
        private int _iterator = 0;
        private IList<int> _flattenTree = new List<int>();

        public BSTIterator(TreeNode root)
        {
            _root = root;
            BuildListFromTreeNode(root);
        }

        public int Next()
        {
            return _flattenTree[_iterator++];
        }

        public bool HasNext()
        {
            return _iterator < _flattenTree.Count;
        }

        private void BuildListFromTreeNode(TreeNode? node)
        {
            if(node == null)
            {
                return;
            }

            if(node.left == null && node.right == null)
            {
                _flattenTree.Add(node.val);
                return;
            }

            BuildListFromTreeNode(node.left);

            _flattenTree.Add(node.val);

            BuildListFromTreeNode(node.right);
        }
    }

    #endregion
}
