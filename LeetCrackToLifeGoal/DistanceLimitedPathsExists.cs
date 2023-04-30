using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class DistanceLimitedPathsExists
    {
        public static bool[] DistanceLimitedPathsExist(int n, int[][] edgeList, int[][] queries)
        {
            UnionFind uf = new UnionFind(n);

            // Summary
            // First of We Sort queries and as well as edges because
            // we first try as minimum val can be added in same set
            // ascending orderly we can union other set values.
            // as we sort queries so we have to track index for result, thats why we add a index in quires

            for (int i = 0; i < queries.Length; i++)
            {
                queries[i] = new[] { queries[i][0], queries[i][1], queries[i][2], i };
            }

            Array.Sort(queries, (a, b) => a[2] - b[2]);
            Array.Sort(edgeList, (a, b) => a[2] - b[2]);
            bool[] ans = new bool[queries.Length];

            for (int i = 0, j = 0; i < queries.Length; i++)
            {
                while (j < edgeList.Length && edgeList[j][2] < queries[i][2])
                {
                    uf.Union(edgeList[j][0], edgeList[j++][1]);
                }
                ans[queries[i][3]] = uf.Find(queries[i][0]) == uf.Find(queries[i][1]);
            }
            return ans;
        }

        //DistanceLimitedPathsExist(3, new int[4][]
        //{
        //    new[] { 0, 1, 2 }, new[] { 1, 2, 4 }, new[] { 2, 0, 8 }, new[] { 1, 0, 16 }
        //}, new int[2][]
        //{
        //    new[] { 0, 1, 2 }, new[] { 0, 2, 5 }
        //});
    }
}
