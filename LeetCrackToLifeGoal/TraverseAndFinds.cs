using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using leetCrack;

namespace LeetCrackToLifeGoal
{
    internal class TraverseAndFinds
    {
        public void TraverseAndFind(TreeNode node, Dictionary<int, List<int>> levelList, int level)
        {
            if (!levelList.ContainsKey(level))
            {
                levelList.Add(level, new List<int>());
            }
            levelList[level].Add(node.val);
            if (node.left != null)
            {
                TraverseAndFind(node.left, levelList, level + 1);

            }
            if (node.right != null)
            {

                TraverseAndFind(node.right, levelList, level + 1);
            }


        }

        public IList<IList<int>> LevelOrder(TreeNode root)
        {

            var levelList = new Dictionary<int, List<int>>();
            var answer = new List<IList<int>>();
            if (root == null) return answer;
            TraverseAndFind(root, levelList, 0);
            foreach (var ll in levelList.Keys)
            {
                Console.WriteLine(levelList[ll]);
                answer.Add(levelList[ll]);
            }

            return answer;

        }
    }
}
