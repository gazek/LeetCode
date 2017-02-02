using System;

namespace ConstructBinaryTreefromPreorderandInorderTraversal
{
    // https://leetcode.com/problems/construct-binary-tree-from-preorder-and-inorder-traversal/
    class Program
    {
        static void Main(string[] args)
        {
            var preorder1 = new int[] { 1, 2 };
            var inorder1 = new int[] { 1, 2 };
            var solution = new Solution();
            var result1 = solution.BuildTree(preorder1, inorder1);

            var preorder2 = new int[] { 6, 2, 1, 4, 3, 5, 7, 9, 8 };
            var inorder2 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var result2 = solution.BuildTree(preorder2, inorder2);
        }
    }

    public class Solution
    {
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            if (inorder.Length == 0)
            {
                return null;
            }
            var root = new TreeNode(preorder[0]);
            BuildNode(root, preorder, inorder, 0, inorder.Length - 1);
            return root;
        }

        public static void BuildNode(TreeNode node, int[] preorder, int[] inorder, int left, int right)
        {
            var inOrderRootIndex = Array.IndexOf(inorder, node.val);
            var sizeLeft = Math.Max(0, inOrderRootIndex - left);
            var sizeRight = Math.Max(0, right - inOrderRootIndex);
            var preOrderRootIndex = Array.IndexOf(preorder, node.val);
            // Lookup for a node on the left
            if (sizeLeft > 0 &&
                preOrderRootIndex + 1 < preorder.Length &&
                Array.IndexOf(inorder, preorder[preOrderRootIndex + 1]) >= left &&
                Array.IndexOf(inorder, preorder[preOrderRootIndex + 1]) < inOrderRootIndex)
            {
                node.left = new TreeNode(preorder[preOrderRootIndex + 1]);
                BuildNode(node.left, preorder, inorder, left, inOrderRootIndex - 1);
            }

            if (sizeRight > 0 && preOrderRootIndex + sizeLeft + 1 < preorder.Length)
            {
                node.right = new TreeNode(preorder[preOrderRootIndex + sizeLeft + 1]);
                BuildNode(node.right, preorder, inorder, inOrderRootIndex + 1, right);
            }
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
}
