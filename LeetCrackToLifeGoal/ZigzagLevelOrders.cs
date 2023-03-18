using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using leetCrack;

namespace LeetCrackToLifeGoal
{
    internal class ZigzagLevelOrders
    {
        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            var levelList = new Dictionary<int, List<int>>();
            var answer = new List<IList<int>>();
            if (root == null) return answer;
            Queue<TreeNode> data = new Queue<TreeNode>();
            var tag = 0;
            data.Enqueue(root);

            while (data.Count > 0)
            {

                levelList.Add(tag, new List<int>());
                var listData = new List<TreeNode>();
                while (data.Count > 0)
                {
                    var chData = data.Dequeue();
                    levelList[tag].Add(chData.val);
                    listData.Add(chData);
                }

                var reVerseData = new List<TreeNode>();
                for (int i = listData.Count - 1; i >= 0; i--)
                {
                    reVerseData.Add(listData[i]);
                }
                listData.Clear();
                foreach (var rData in reVerseData)
                {
                    listData.Add(rData);
                }
                if (tag % 2 == 1)
                {
                    foreach (var lData in listData)
                    {
                        if (lData.left != null) data.Enqueue(lData.left);
                        if (lData.right != null) data.Enqueue(lData.right);

                    }
                }
                else
                {
                    foreach (var lData in listData)
                    {
                        if (lData.right != null) data.Enqueue(lData.right);
                        if (lData.left != null) data.Enqueue(lData.left);


                    }
                }
                tag++;
            }
            foreach (var ll in levelList.Keys)
            {

                foreach (var VARIABLE in levelList[ll])
                {
                    Console.Write(VARIABLE + " ");
                }
                Console.WriteLine();
                answer.Add(levelList[ll]);
            }

            return answer;
        }

    }
}
