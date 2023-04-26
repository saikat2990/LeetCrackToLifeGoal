﻿
using LeetCrackToLifeGoal;
using static leetCrack.FindWords;

namespace leetCrack
{

    public class Program
    {

        public static IList<TreeNode> AllPossibleFBT(int N)
        {
            var Res = allFBT(N);
            return Res;
        }

        public static List<TreeNode> allFBT(int N)
        {
            List<TreeNode> res = new List<TreeNode>();
            if (N % 2 == 0)
                return res;

            if (N == 1)
            {
                res.Add(new TreeNode(0));
                return res;
            }

            for (int i = 1; i <= N - 2; i += 2)
            {
                List<TreeNode> left = allFBT(i);
                List<TreeNode> right = allFBT(N - 1 - i);

                foreach (TreeNode l in left)
                {
                    foreach (TreeNode r in right)
                    {
                        TreeNode root = new TreeNode(0);
                        root.left = l;
                        root.right = r;
                        res.Add(root);
                    }
                }
            }

            return res;
        }
        public static void Main(string[] args)
        {
            AllPossibleFBT(7);
        }

       
    }
   
}