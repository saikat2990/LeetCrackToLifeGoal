using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using leetCrack;

namespace LeetCrackToLifeGoal
{
    internal class BuildTreePreInOrding
    {
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            if (inorder.Length == 0 || preorder.Length == 0)
            {
                return null;
            }

            var root = preorder[0];
            var node = new TreeNode(root);
            var mid = Array.IndexOf(inorder, root);
            var leftInorder = inorder.Skip(0).Take(mid).ToArray();
            var rightInoder = inorder.Skip(mid + 1).Take(inorder.Length - mid - 1).ToArray();
            var leftPostorder = preorder.Skip(1).Take(mid + 1).ToArray();
            var rightPostorder = preorder.Skip(mid + 1).Take(inorder.Length - mid - 1).ToArray();
            node.left = BuildTree(leftPostorder, leftInorder);
            node.right = BuildTree(rightPostorder, rightInoder);
            return node;
        }
    }
}
