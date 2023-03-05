using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    public class CanVisitAllRoomss
    {
        public static void recursivelyCheck(int n, Dictionary<int, IList<int>> edges, int currentIndex, bool[] isCheckedArray, List<int> finalAnswer)
        {


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
                            recursivelyCheck(n, edges, node, isCheckedArray, finalAnswer);
                        }


                    }
                }
            }



        }

        public static bool CanVisitAllRooms(IList<IList<int>> edges)
        {
            var finalAnswer = new List<int>();
            var n = edges.Count;
            var allApproved = new bool[n];
            for (int i = 0; i < n; i++)
            {
                allApproved[i] = false;
            }

            var dict = new Dictionary<int, IList<int>>();

            for (int i = 0; i < edges.Count; i++)
            {
                for (int j = 0; j < edges[i].Count; j++)
                {
                    if (dict.ContainsKey(i))
                    {
                        dict[i].Add(edges[i][j]);
                    }
                    else
                    {
                        dict.Add(i, new List<int>() { edges[i][j] });
                    }
                }

            }
            allApproved[0] = true;
            recursivelyCheck(n, dict, 0, allApproved, finalAnswer);
            foreach (var check in allApproved)
            {
                if (check == false) return false;
            }
            return true;
        }
        //var data = CanVisitAllRooms(new List<IList<int>>()
        //{
        //    new List<int>(){1,3},
        //    new List<int>(){3,0,1},
        //    new List<int>(){2},
        //    new List<int>(){0}

        //});
    }
}
