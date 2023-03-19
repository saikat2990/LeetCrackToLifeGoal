using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using leetCrack;

namespace LeetCrackToLifeGoal
{
    internal class BuildTreePostInOrder
    {
        public TreeNode BuildTreePostInorder(int[] inorder, int[] postorder)
        {
            if (inorder.Length == 0 || postorder.Length == 0)
            {
                return null;
            }

            var root = postorder[postorder.Length - 1];
            var node = new TreeNode(root);
            var mid = Array.IndexOf(inorder, root);
            var leftInorder = inorder.Skip(0).Take(mid).ToArray();
            var rightInoder = inorder.Skip(mid + 1).Take(inorder.Length - mid - 1).ToArray();
            var leftPostorder = postorder.Skip(0).Take(mid).ToArray();
            var rightPostorder = postorder.Skip(mid).Take(postorder.Length - mid - 1).ToArray();
            node.left = BuildTreePostInorder(leftInorder, leftPostorder);
            node.right = BuildTreePostInorder(rightInoder, rightPostorder);
            return node;
        }

    }
}
