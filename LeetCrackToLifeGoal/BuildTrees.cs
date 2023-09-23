using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using leetCrack;

namespace LeetCrackToLifeGoal
{
    internal class BuildTrees
    {
        public static TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            if (preorder.Length == 0 && inorder.Length == 0)
            {
                return null;
            }

            var rootValue = preorder[0];
            var root = new TreeNode(rootValue);
            var findRootIndex = inorder.ToList().IndexOf(rootValue);
            var leftInOrder = inorder.Skip(0).Take(findRootIndex).ToArray();
            var rightInorder = inorder.Skip(findRootIndex + 1).Take(inorder.Length - findRootIndex - 1).ToArray();
            var leftpreorderr = preorder.Skip(1).Take(findRootIndex).ToArray();
            var rightPreorder = preorder.Skip(findRootIndex + 1).Take(preorder.Length - findRootIndex - 1).ToArray();
            root.left = BuildTree(leftpreorderr, leftInOrder);
            root.right = BuildTree(rightPreorder, rightInorder);
            return root;
        }

    }
}
