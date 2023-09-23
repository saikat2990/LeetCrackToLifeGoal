
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using leetCrack;

namespace LeetCrackToLifeGoal
{
    internal class LowestCommonAncestors
    {
        public TreeNode SelectedNode { get; set; } = null;

        public bool traverseTree(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null) return false;
            if (root.val == p.val || root.val == q.val)
            {
                return true;
            }

            var rightValue = traverseTree(root.right, p, q);
            var leftValue = traverseTree(root.left, p, q);
            if ((rightValue && leftValue) || (rightValue && (root.val == p.val || root.val == q.val)) || (leftValue && (root.val == p.val || root.val == q.val)))
            {
                if (SelectedNode == null) SelectedNode = root;
                return true;
            }

            if (rightValue || leftValue) return true;

            return false;
        }

        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null) return null;
            if (traverseTree(root, p, q) && SelectedNode == null)
            {
                SelectedNode = root;
            }
            return SelectedNode;
        }
    }
}
