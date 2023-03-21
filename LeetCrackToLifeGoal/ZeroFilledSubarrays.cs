using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class ZeroFilledSubarrays
    {
        public static long ZeroFilledSubarray(int[] nums)
        {
            long active = 0;
            var numberOfOccur = new Dictionary<int, int>();
            var num = 0;
            long numsOfZeros = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    num++;

                }
                else
                {
                    for (int j = 1; j <= num; j++)
                    {
                        var data = (num - j + 1);
                        if (numberOfOccur.ContainsKey(j))
                        {
                            numberOfOccur[j] += data;
                        }
                        else
                        {
                            numberOfOccur.Add(j, data);
                        }
                    }
                    num = 0;
                }
            }
            for (int j = 1; j <= num; j++)
            {
                var data = (num - j + 1);
                if (numberOfOccur.ContainsKey(j))
                {
                    numberOfOccur[j] += data;
                }
                else
                {
                    numberOfOccur.Add(j, data);
                }
            }

            foreach (var val in numberOfOccur.Values)
            {
                numsOfZeros += val;
            }

            return numsOfZeros;
        }

    }
}
