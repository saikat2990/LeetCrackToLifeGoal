using leetCrack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class MergeTreess
    {
        public TreeNode Merge(TreeNode tNode1, TreeNode tNode2)
        {
            if (tNode1 == null && tNode2 == null) return null;
            var node = new TreeNode();
            var val = 0;
            if (tNode1 != null)
                val += tNode1.val;
            if (tNode2 != null)
                val += tNode2.val;
            node.val = val;
            node.right = Merge(tNode1 == null ? null : tNode1.right, tNode2 == null ? null : tNode2.right);
            node.left = Merge(tNode1 == null ? null : tNode1.left, tNode2 == null ? null : tNode2.left);
            return node;
        }

        public TreeNode MergeTrees(TreeNode root1, TreeNode root2)
        {
            var newRoot = Merge(root1, root2);
            return newRoot;
        }
    }
}
