using System;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace leetCrack
{
    

    public class Program
    {
        
        public static void checkAnddAdd(int[][] graph, IList<IList<int>> final, IList<int> current,int index,int finish)
        {
           
            if (graph[index].Length == 0 && finish==index)
            {
               IList<int> newList= new List<int>();
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
                    current.RemoveAt(current.Count-1);
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
        public static void Main(string[] args)
        {
            AllPathsSourceTarget(new int[][] { new int[] { 4, 3, 1 }, new int[] { 3, 2, 4 }, new int[] {  }, new int[]{4} , new int[]{}});
        }


    }
   
}