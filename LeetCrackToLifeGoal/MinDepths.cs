using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using leetCrack;

namespace LeetCrackToLifeGoal
{
    internal class MinDepths
    {
        public void TraverseAndFind(TreeNode node, int level, List<int> ansList)
        {
            if (node.left == null && node.right == null)
            {
                ansList.Add(level);
            }

            if (node.left != null)
            {
                TraverseAndFind(node.left, level + 1, ansList);
            }
            if (node.right != null)
            {
                TraverseAndFind(node.right, level + 1, ansList);
            }
        }
        public int MinDepth(TreeNode root)
        {

            var ansList = new List<int>();
            if (root == null) return 0;
            TraverseAndFind(root, 1, ansList);
            ansList.Sort();
            return ansList[0];
        }
    }
}
