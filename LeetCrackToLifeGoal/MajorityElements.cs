using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class MajorityElements
    {
        public static int MajorityElement(int[] nums)
        {
            var dict = new Dictionary<int, int>();
            foreach (var c in nums)
            {
                if (!dict.ContainsKey(c))
                {
                    dict.Add(c, 0);
                }
                dict[c]++;
            }
            dict = dict.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            return dict.First().Value;
        }

    }
}
