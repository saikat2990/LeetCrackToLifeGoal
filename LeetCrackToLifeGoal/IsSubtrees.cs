using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using leetCrack;

namespace LeetCrackToLifeGoal
{
    internal class IsSubtrees
    {
        public bool checkIsSame(TreeNode node, TreeNode subRoot)
        {
            if (node == null && subRoot == null) return true;
            if (node.val != subRoot.val || (node == null && subRoot != null) || (node != null && subRoot == null)) return false;

            if (!checkIsSame(node.right, subRoot.right))
            {
                return false;
            }
            if (!checkIsSame(node.left, subRoot.left))
            {
                return false;
            }
            return true;

        }

        public bool IsSubtree(TreeNode root, TreeNode subRoot)
        {
            var tag = checkIsSame(root, subRoot);
            if (tag) return true;
            if (root.right != null && !tag) tag = IsSubtree(root.right, subRoot);
            if (root.left != null && !tag) tag = IsSubtree(root.left, subRoot);
            return tag;
        }
    }
}
