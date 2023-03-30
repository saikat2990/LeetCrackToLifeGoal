using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using leetCrack;

namespace LeetCrackToLifeGoal
{
    internal class Connects
    {
        public static void setValue(FindWords.Node node, Dictionary<int, List<FindWords.Node>> ansDic, int level)
        {
            if (ansDic.ContainsKey(level))
            {
                var list = ansDic[level];
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].val == node.val)
                    {
                        if (i == list.Count - 1)
                        {
                            node.next = null;
                        }
                        else
                        {
                            node.next = list[i + 1];
                        }
                    }
                }
            }
            if (node.left != null)
                setValue(node.left, ansDic, level + 1);

            if (node.right != null)
                setValue(node.right, ansDic, level + 1);
        }

        public static FindWords.Node Connect(FindWords.Node root)
        {
            if (root == null) return root;
            var nodeQueue = new Queue<FindWords.Node>();
            var ansList = new List<FindWords.Node>();
            var newNode = new FindWords.Node();
            var ansDic = new Dictionary<int, List<FindWords.Node>>();
            var level = 1;
            nodeQueue.Enqueue(root);
            while (nodeQueue.Count > 0)
            {
                var currentNodeList = new List<FindWords.Node>();
                while (nodeQueue.Count > 0)
                {
                    currentNodeList.Add(nodeQueue.Peek());
                    nodeQueue.Dequeue();
                }

                if (!ansDic.ContainsKey(level))
                {
                    ansDic.Add(level, currentNodeList);
                }

                level++;
                foreach (var curNode in currentNodeList)
                {
                    if (curNode != null)
                    {
                        if (curNode.left != null)
                        {

                            nodeQueue.Enqueue(curNode.left);
                        }
                        if (curNode.right != null)
                        {
                            nodeQueue.Enqueue(curNode.right);

                        }


                    }
                }
            }

            setValue(root, ansDic, 1);

            return root;
        }
    }
}
