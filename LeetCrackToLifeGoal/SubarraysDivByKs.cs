using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class SubarraysDivByKs
    {
        public static int SubarraysDivByK(int[] nums, int k)
        {
            var dict = new Dictionary<int, int>();
            var sum = 0;
            var count = 0;
            dict.Add(0, 1);
            foreach (var num in nums)
            {
                sum += num;
                var remain = sum % k;
                if (remain < 0) remain += k;
                if (dict.ContainsKey(remain))
                {
                    dict[remain]++;
                    count += (dict[remain] - 1);
                }
                else
                {
                    dict.Add(remain, 1);
                }

            }
            return count;
        }


    }
}
