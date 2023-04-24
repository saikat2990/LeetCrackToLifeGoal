using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class LongestZigZagss
    {
        private int max = 0;

        public void traverseZigZag(int count, IsSymmetrics.TreeNode node, bool left)
        {
            if (node == null)
            {
                if (max < count) max = count;
                return;
            }

            if (left)
            {
                traverseZigZag(count + 1, node.right, false);
                traverseZigZag(0, node.left, true);
            }
            else
            {
                traverseZigZag(count + 1, node.left, true);
                traverseZigZag(0, node.right, false);
            }
        }

        public int LongestZigZag(IsSymmetrics.TreeNode root)
        {
            traverseZigZag(0, root.right, false);
            traverseZigZag(0, root.left, true);
            return max;

        }
    }
}
