using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class LongestArithSeqLengths
    {
        public static int LongestArithSeqLength(int[] nums)
        {
            var dict = new Dictionary<string, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    var str = i + "," + (nums[j] - nums[i]);
                    var val = 1;
                    if (dict.ContainsKey(str))
                    {
                        val = dict[str];
                    }
                    var strr = j + "," + (nums[j] - nums[i]);
                    dict[strr] = val + 1;

                }
            }

            var max = int.MinValue;
            for (int i = 0; i < dict.Values.Count; i++)
            {
                if (dict.Values.ToList()[i] > max) max = dict.Values.ToList()[i];
            }
            return max + 1;
        }

    }
}
