using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    public class FindSmallestSetOfVerticess
    {
        public static void recursivelyCheck(int n, Dictionary<int, IList<int>> edges, int currentIndex, bool[] isCheckedArray, List<int> finalAnswer)
        {

            isCheckedArray[currentIndex] = true;
            if (edges.ContainsKey(currentIndex))
            {
                var edge = edges[currentIndex];
                foreach (var node in edge)
                {

                    if (finalAnswer.IndexOf(node) != -1)
                    {
                        finalAnswer.RemoveAt(finalAnswer.IndexOf(node));
                    }
                    if (!isCheckedArray[node])
                    {
                        recursivelyCheck(n, edges, node, isCheckedArray, finalAnswer);
                    }
                }
            }



        }

        public static IList<int> FindSmallestSetOfVertices(int n, IList<IList<int>> edges)
        {
            var finalAnswer = new List<int>();
            var allApproved = new bool[n];
            for (int i = 0; i < n; i++)
            {
                allApproved[i] = false;
            }

            var populatedEdges = new List<int>();
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
            }

            foreach (var key in dict.Keys)
            {
                if (allApproved[key] == false)
                {
                    finalAnswer.Add(key);
                    recursivelyCheck(n, dict, key, allApproved, finalAnswer);

                }
            }

            return finalAnswer;
        }
        public static void Mainss(string[] args)
        {
            //AllPathsSourceTarget(new int[][] { new int[] { 4, 3, 1 }, new int[] { 3, 2, 4 }, new int[] {  }, new int[]{4} , new int[]{}});
            var data = FindSmallestSetOfVertices(3, new List<IList<int>>()
            {
                new List<int>(){1,2},
                new List<int>(){1,0},
                new List<int>(){0,2},
            });
            data = FindSmallestSetOfVertices(5, new List<IList<int>>()
            {
                new List<int>(){1,3},
                new List<int>(){2,0},
                new List<int>(){2,3},
                new List<int>(){1,0},
                new List<int>(){4,1},
                new List<int>(){0,3},

            });

        }
    }
}
