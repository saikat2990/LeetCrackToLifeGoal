using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class FindRedundantConnections
    {
        public int[] FindRedundantConnection(int[][] edges)
        {
            UnionFind uf = new UnionFind(edges.Length);
            var lastOccur = new List<int[]>();
            for (int i = 0; i < edges.Length; i++)
            {
                if (uf.Find(edges[i][0]) == uf.Find(edges[i][1]))
                {
                    lastOccur.Add(edges[i]);
                }
                else
                {
                    uf.Union(edges[i][0], edges[i][1]);
                }
            }

            if (lastOccur.Count > 0)
                return lastOccur[lastOccur.Count - 1];
            return new int[0];
        }

    }
}
