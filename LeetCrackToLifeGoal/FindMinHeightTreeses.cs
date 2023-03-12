using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    public class FindMinHeightTreeses
    {
        private static HashSet<int>[] Edges;

        public static IList<int> FindMinHeightTrees(int n, int[][] edges)
        {
            Edges = new HashSet<int>[n];
            var result = new List<int>();
            foreach (var eachEdge in edges)
            {
                AddEdges(eachEdge[0], eachEdge[1]);
                AddEdges(eachEdge[1], eachEdge[0]);

            }

            Queue<int> leafs = new Queue<int>();
            for (int i = 0; i < Edges.Length; i++)
            {
                if (Edges[i].Count == 1)
                {
                    leafs.Enqueue(i);
                }
            }

            while (n > 2)
            {
                Queue<int> newLeafs = new Queue<int>();
                while (leafs.Count > 0)
                {
                    var eachLeaf = leafs.Dequeue();
                    n--;
                    var parent = Edges[eachLeaf].FirstOrDefault();
                    Edges[parent].Remove(eachLeaf);
                    if (Edges[parent].Count == 1)
                    {
                        newLeafs.Enqueue(parent);
                    }


                }
                while (newLeafs.Count > 0)
                {
                    leafs.Enqueue(newLeafs.Dequeue());
                }
            }

            while (leafs.Count > 0)
            {
                result.Add(leafs.Dequeue());
                ;
            }
            return result;

        }

        public static void AddEdges(int p, int q)
        {
            if (Edges[p] == null)
            {
                Edges[p] = new HashSet<int>();
            }
            Edges[p].Add(q);
        }

    }
}
