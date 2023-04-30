using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class MaxNumEdgesToRemoves
    {
        public static int MaxNumEdgesToRemove(int n, int[][] edges)
        {
            UnionFind ufAlice = new UnionFind(n);
            UnionFind ufBob = new UnionFind(n);
            bool[] aliceAll = new bool[n];
            bool[] bobAll = new bool[n];
            var count = 0;
            Array.Sort(edges, (a, b) => b[0] - a[0]);
            for (int i = 0; i < edges.Length; i++)
            {
                if (edges[i][0] == 1)
                {
                    if (ufAlice.Find(edges[i][1] - 1) == ufAlice.Find(edges[i][2] - 1))
                    {
                        count++;
                    }
                    else
                    {
                        ufAlice.Union(edges[i][1] - 1, edges[i][2] - 1);

                    }


                }
                if (edges[i][0] == 2)
                {
                    if (ufBob.Find(edges[i][1] - 1) == ufBob.Find(edges[i][2] - 1))
                    {
                        count++;
                    }
                    else
                    {
                        ufBob.Union(edges[i][1] - 1, edges[i][2] - 1);

                    }

                }
                if (edges[i][0] == 3)
                {
                    if (ufAlice.Find(edges[i][1] - 1) == ufAlice.Find(edges[i][2] - 1) && ufBob.Find(edges[i][1] - 1) == ufBob.Find(edges[i][2] - 1))
                    {
                        count++;
                    }
                    else
                    {
                        ufAlice.Union(edges[i][1] - 1, edges[i][2] - 1);
                        ufBob.Union(edges[i][1] - 1, edges[i][2] - 1);
                    }

                }
            }

            var bobBoss = ufBob.Find(0);
            var aliceBoss = ufAlice.Find(0);
            for (int i = 1; i < n; i++)
            {
                if (ufAlice.Find(i) != aliceBoss || ufBob.Find(i) != bobBoss) return -1;
            }

            return count;
        }

        //MaxNumEdgesToRemove(4, new int[6][]
        //{
        //    new[] { 3, 1, 2 }, new[] { 3, 2, 3 }, new[] { 1, 1, 3 }, new[] { 1, 2, 4 }, new[] { 1, 1, 2 },
        //    new[] { 2, 3, 4 }
        //});
    }
}
