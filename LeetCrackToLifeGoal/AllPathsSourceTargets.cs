using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    public class AllPathsSourceTargets
    {
        public static void checkAnddAdd(int[][] graph, IList<IList<int>> final, IList<int> current, int index, int finish)
        {

            if (graph[index].Length == 0 && finish == index)
            {
                IList<int> newList = new List<int>();
                foreach (var val in current)
                {
                    newList.Add(val);
                }
                final.Add(newList);
            }
            else
            {
                foreach (var data in graph[index])
                {
                    current.Add(data);
                    checkAnddAdd(graph, final, current, data, finish);
                    current.RemoveAt(current.Count - 1);
                }
            }

        }

        public static IList<IList<int>> AllPathsSourceTarget(int[][] graph)
        {
            var finalAnswer = new List<IList<int>>();
            var finishPoint = graph.Length - 1;
            foreach (var node in graph[0])
            {
                var current = new List<int>();
                current.Add(0);
                current.Add(node);
                checkAnddAdd(graph, finalAnswer, current, node, finishPoint);
            }
            return finalAnswer;
        }
    }
}
