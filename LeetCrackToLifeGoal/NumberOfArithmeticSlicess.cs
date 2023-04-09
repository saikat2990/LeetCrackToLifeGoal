using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class NumberOfArithmeticSlicess
    {
        public static int NumberOfArithmeticSlices(int[] nums)
        {
            var count = 2;
            var result = 0;
            for (int i = 2; i < nums.Length; i++)
            {
                if (nums[i] - nums[i - 1] == nums[i - 1] - nums[i - 2])
                {
                    count++;
                }
                else
                {
                    if (count > 2)
                    {
                        result += ((count - 2) * (count - 1) / 2);
                        count = 2;
                    }
                }
            }
            if (count > 2)
            {
                result += ((count - 2) * (count - 1) / 2);

            }
            return result;

        }
    }
}
