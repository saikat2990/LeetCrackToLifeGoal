using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class FindMInimumHeightTreeWithTLE
    {
        public static void recursivelyCheck(int n, Dictionary<int, IList<int>> edges, int currentIndex, bool[] isCheckedArray, Dictionary<int, int> finalAnswer, int root, int layer)
        {
            if (layer > finalAnswer[root])
                finalAnswer[root] = layer;
            if (edges.ContainsKey(currentIndex))
            {
                var edge = edges[currentIndex];

                foreach (var node in edge)
                {

                    if (!isCheckedArray[node])
                    {
                        if (node != currentIndex)
                        {
                            isCheckedArray[node] = true;

                            recursivelyCheck(n, edges, node, isCheckedArray, finalAnswer, root, layer + 1);
                        }


                    }
                }

            }
        }
        public static IList<int> FindMinHeightTrees(int n, int[][] edges)
        {
            var answer = new List<int>();
            var allApproved = new bool[n];


            var dict = new Dictionary<int, IList<int>>();
            foreach (var edge in edges)
            {
                if (dict.ContainsKey(edge[0]))
                {
                    dict[edge[0]].Add(edge[1]);
                }
                else
                {

                    dict.Add(edge[0], new List<int>() { edge[1] });
                }
                if (dict.ContainsKey(edge[1]))
                {

                    dict[edge[1]].Add(edge[0]);
                }
                else
                {
                    dict.Add(edge[1], new List<int>() { edge[0] });
                }


            }


            var finish = new Dictionary<int, int>();
            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    allApproved[i] = false;
                }
                allApproved[j] = true;
                finish.Add(j, 0);
                recursivelyCheck(n, dict, j, allApproved, finish, j, 0);
            }

            for (int i = 0; i < allApproved.Length; i++)
            {
                if (allApproved[i] == false)
                    answer.Add(i);
            }

            var values = finish.Values.ToList();
            var min = int.MaxValue;
            foreach (var val in values)
            {
                if (val < min) min = val;
            }

            foreach (var fk in finish.Keys)
            {
                if (finish[fk] == min) answer.Add(fk);
            }
            return answer;
        }
    }
}
