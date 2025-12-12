
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

    #region 173 Binary Search Tree Iterator - Not Solved

    public class BSTIterator
    {
        private TreeNode _root;
        private TreeNode _previousValue;
        private ListNode _rootNode;
        private ListNode _currentIterator;

        public BSTIterator(TreeNode root)
        {
            _root = root;
            BuildListFromTreeNode(root);
        }

        public int Next()
        {
            _currentIterator = _currentIterator.next;
            return _currentIterator.val;
        }

        public bool HasNext()
        {
            return _currentIterator.next != null;
        }

        private ListNode BuildListFromTreeNode(TreeNode root)
        {
            return new ListNode();
        }
    }

    #endregion
}
