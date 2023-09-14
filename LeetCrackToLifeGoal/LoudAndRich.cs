using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class LoudAndRichs
    {
        public static int[] LoudAndRich(int[][] richer, int[] quiet)
        {
            List<List<int>> graph = new();
            int n = quiet.Length;
            var cache = new int[n];

            for (int i = 0; i < n; i++)
            {
                cache[i] = -1;
            }

            for (int i = 0; i < quiet.Length; i++)
                graph.Add(new());



            for (int i = 0; i < richer.Length; i++)
            {
                graph[richer[i][1]].Add(richer[i][0]);
            }

            var ans = new int[n];
            for (int i = 0; i < graph.Count; i++)
            {
                ans[i] = recursivelyDataSave(i, graph, quiet, cache);
            }

            return ans;

        }

        private static int recursivelyDataSave(int index, List<List<int>> graph, int[] quiet, int[] cache)
        {
            if (cache[index] != -1) return cache[index];
            var temp = index;

            for (int i = 0; i < graph[index].Count; i++)
            {
                var val = recursivelyDataSave(graph[index][i], graph, quiet, cache);
                if (quiet[val] < quiet[temp])
                {
                    temp = val;
                }
            }

            cache[index] = temp;
            return cache[index];
        }

    }
}
