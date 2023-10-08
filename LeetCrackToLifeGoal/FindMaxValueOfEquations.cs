using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class FindMaxValueOfEquations
    {
        public static int FindMaxValueOfEquation(int[][] points, int k)
        {


            var dict = new PriorityQueue<(int, int), (int, int)>(Comparer<(int, int)>
                .Create((a, b) => a.Item1 == b.Item1 ? a.Item2 - b.Item2 : b.Item1 - a.Item1));
            int res = -1000000002;
            foreach (var point in points)
            {
                while (dict.Count > 0 && (point[0] - dict.Peek().Item1 > k)) dict.Dequeue();
                if (dict.Count > 0 && point[1] + point[0] + dict.Peek().Item2 > res)
                {
                    res = point[1] + point[0] + dict.Peek().Item2;

                }
                dict.Enqueue((point[0], (point[1] - point[0])), (point[0], (point[1] - point[0])));
            }
            return res;

        }

    }
}
