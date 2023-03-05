using System;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace leetCrack
{
    

    public class Program
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

            while (n>2)
            {
                Queue<int> newLeafs = new Queue<int>();
                while (leafs.Count>0)
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

            while (leafs.Count>0)
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

        public static void Main(string[] args)
        {
            //AllPathsSourceTarget(new int[][] { new int[] { 4, 3, 1 }, new int[] { 3, 2, 4 }, new int[] {  }, new int[]{4} , new int[]{}});
            //var data = FindMinHeightTrees(3, new List<IList<int>>()
            //{
            //    new List<int>(){1,2},
            //    new List<int>(){1,0},
            //    new List<int>(){0,2},
            //});
            var data = FindMinHeightTrees(6,
                new int[][] { new int[] { 3, 0 }, new int[] { 3, 1 }, new int[] { 3, 2 }, new int[] { 3, 4 }, new int[] { 5, 4 } });


        }


    }
   
}