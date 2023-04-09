using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class LargestPathValues
    {
        public int LargestPathValue(string colors, int[][] edges)
        {
            var graph = new Dictionary<int, List<int>>();
            var totalNode = colors.Length;
            var colorCount = new int[totalNode][];
            var indegree = new int[totalNode];
            for (int i = 0; i < edges.Length; i++)
            {
                if (!graph.ContainsKey(edges[i][0]))
                {
                    graph[edges[i][0]] = new List<int>();
                }
                graph[edges[i][0]].Add(edges[i][1]);
                indegree[edges[i][1]]++;
            }

            for (int i = 0; i < totalNode; i++)
            {
                colorCount[i] = new int[26];
            }

            var queue = new Queue<int>();
            for (int i = 0; i < totalNode; i++)
            {
                if (indegree[i] == 0) queue.Enqueue(i);
            }
            var answer = 1;
            var nodeSeen = 0;
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                nodeSeen++;
                answer = Math.Max(answer, ++colorCount[node][colors[node] - 'a']);

                if (!graph.ContainsKey(node)) continue;


                for (int i = 0; i < graph[node].Count; i++)
                {
                    var neighbour = graph[node][i];
                    for (int j = 0; j < 26; j++)
                    {
                        colorCount[neighbour][i] = Math.Max(colorCount[neighbour][i], colorCount[node][i]);
                    }

                    indegree[neighbour]--;
                    if (indegree[neighbour] == 0)
                        queue.Enqueue(neighbour);
                }
            }

            return nodeSeen < totalNode ? -1 : answer;

        }

    }
}
