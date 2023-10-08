using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using leetCrack;

namespace LeetCrackToLifeGoal
{
    public class Robs
    {
        public int Rob(TreeNode root)
        {

            var ans = robBro(root);
            return ans.containingValue > ans.previousBest ? ans.containingValue : ans.previousBest;
        }

        private (int containingValue, int previousBest) robBro(TreeNode node)
        {
            if (node == null) return (0, 0);
            var leftNode = robBro(node.left);
            var rightNode = robBro(node.right);
            var containingValue = leftNode.previousBest + rightNode.previousBest + node.val;
            var previousBest = Math.Max(leftNode.containingValue, leftNode.previousBest) +
                               Math.Max(rightNode.containingValue, rightNode.previousBest);
            return (containingValue, previousBest);
        }
    }
}
