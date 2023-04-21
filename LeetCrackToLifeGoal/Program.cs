
using LeetCrackToLifeGoal;
using static leetCrack.FindWords;

namespace leetCrack
{

    public class Program
    {
        private int max = 0;

        public void traverseZigZag(int count, TreeNode node, bool left)
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

        public int LongestZigZag(TreeNode root)
        {
            traverseZigZag(0, root.right, false);
            traverseZigZag(0, root.left, true);
            return max;

        }
        public static void Main(string[] args)
        {
            


        }

       
    }
   
}