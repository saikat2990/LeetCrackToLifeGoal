using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using leetCrack;

namespace LeetCrackToLifeGoal
{
    public class IsSymmetrics
    {

        public void traverseRight(TreeNode node, List<TreeNode> rightAnswer)
        {

            if (node != null)
            {
                rightAnswer.Add(node);
                traverseRight(node.right, rightAnswer);
                traverseRight(node.left, rightAnswer);
            }
            else
            {
                rightAnswer.Add(null);
            }
        }
        public void traverseLeft(TreeNode node, List<TreeNode> leftAnswer)
        {
            if (node != null)
            {
                leftAnswer.Add(node);
                traverseRight(node.left, leftAnswer);
                traverseRight(node.right, leftAnswer);
            }
            else
            {
                leftAnswer.Add(null);
            }

        }
        public bool IsSymmetric(TreeNode root)
        {
            var leftAnswer = new List<TreeNode>();
            var rightAnswer = new List<TreeNode>();
            traverseLeft(root.left, leftAnswer);
            traverseRight(root.right, rightAnswer);
            for (int i = 0; i < leftAnswer.Count; i++)
            {
                if (leftAnswer[i] == null && rightAnswer[i] == null)
                    continue;
                if (leftAnswer[i] != null && rightAnswer[i] == null)
                    return false;
                if (leftAnswer[i] == null && rightAnswer[i] != null)
                    return false;
                Console.WriteLine(leftAnswer[i].val);
                Console.WriteLine(rightAnswer[i].val);

                if (leftAnswer[i].val != rightAnswer[i].val) return false;
            }
            return true;
        }
    }
}
