using System;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace leetCrack
{
    

    public class Program
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

           

            //foreach (var key in dict.Keys)
            //{
            //    if (allApproved[key] == false)
            //    {
            //        finalAnswer.Add(key);
            //        if (key == 0)
                   

            //    }
            //}
            allApproved[0] = true;
            recursivelyCheck(n, dict, 0, allApproved, finalAnswer);
            foreach (var check in allApproved)
            {
                if (check == false) return false;
            }
            return true;
        }
        public static void Main(string[] args)
        {
            //AllPathsSourceTarget(new int[][] { new int[] { 4, 3, 1 }, new int[] { 3, 2, 4 }, new int[] {  }, new int[]{4} , new int[]{}});
            //var data = FindSmallestSetOfVertices(3, new List<IList<int>>()
            //{
            //    new List<int>(){1,2},
            //    new List<int>(){1,0},
            //    new List<int>(){0,2},
            //});
            var data = CanVisitAllRooms(new List<IList<int>>()
            {
                new List<int>(){1,3},
                new List<int>(){3,0,1},
                new List<int>(){2},
                new List<int>(){0}

            });

        }


    }
   
}