using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    public class FindCenters
    {
        public int FindCenter(int[][] edges)
        {
            var dict = new Dictionary<int, int>();
            foreach (var edge in edges)
            {
                if (dict.ContainsKey(edge[0]))
                {
                    dict[edge[0]]++;
                }
                else
                {
                    dict.Add(edge[0], 1);
                }
                if (dict.ContainsKey(edge[1]))
                {
                    dict[edge[1]]++;
                }
                else
                {
                    dict.Add(edge[1], 1);
                }
            }
            var allKeys = dict.Keys;
            var maxVal = -1;
            var maxFace = -1;
            foreach (var key in allKeys)
            {
                if (dict[key] > maxVal)
                {
                    maxVal = dict[key];
                    maxFace = key;
                }
            }
            return maxFace;
        }

    }
}
