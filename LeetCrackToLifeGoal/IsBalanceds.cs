using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using leetCrack;

namespace LeetCrackToLifeGoal
{
    internal class IsBalanceds
    {
        public int TraverseAndFind(TreeNode node, int level, List<bool> ansList)
        {
            if ((node.left == null && node.right == null) || node == null)
            {
                return 0;
            }

            var dfL = 0;
            var dfR = 0;
            if (node.left != null)
            {
                dfL = TraverseAndFind(node.left, level + 1, ansList);
            }
            if (node.right != null)
            {
                dfR = TraverseAndFind(node.right, level + 1, ansList);
            }

            var dff = dfR - dfL;
            if (dff < 0) dff = -dff;
            ansList.Add(dff > 1 ? false : true);
            var df = Math.Max(dfL, dfR);
            return df + 1;
        }
        public bool IsBalanced(TreeNode root)
        {

            var ansList = new List<bool>();
            if (root == null) return true;
            TraverseAndFind(root, 1, ansList);
            foreach (var ch in ansList)
            {
                if (ch == false) return false;
            }
            return true;
        }
    }
}
