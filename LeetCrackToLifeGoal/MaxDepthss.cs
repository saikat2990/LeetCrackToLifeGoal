using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
   
    public class MaxDepthss
    {
        public class Node
        {
            public int val;
            public IList<Node> children;

            public Node() { }

            public Node(int _val)
            {
                val = _val;
            }

            public Node(int _val, IList<Node> _children)
            {
                val = _val;
                children = _children;
            }
        }
        public int MaxDepth(Node root)
        {
            var queue = new Queue<Node>();
            var check = 0;
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                check++;
                var nodeList = new List<Node>();
                while (queue.Count > 0)
                {
                    nodeList.Add(queue.Dequeue());
                }

                foreach (var node in nodeList)
                {
                    foreach (var nodeCh in node.children)
                    {
                        queue.Enqueue(nodeCh);
                    }
                }
            }

            return check;
        }
    }
}
