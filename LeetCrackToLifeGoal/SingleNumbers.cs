using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class SingleNumbers
    {
        public int SingleNumber(int[] nums)
        {
            var counts = new Dictionary<int, int>();
            foreach (var data in nums)
            {
                if (counts.ContainsKey(data))
                {
                    counts[data]++;
                }
                else
                {
                    counts.Add(data, 1);
                }
            }

            foreach (var data in nums)
            {
                if (counts[data] == 1) return data;

            }
            return 0;
        }
    }
}
