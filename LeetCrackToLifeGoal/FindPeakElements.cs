using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class FindPeakElements
    {
        public int FindPeakElement(int[] nums)
        {
            if (nums.Length == 1) return 0;
            if (nums[0] > nums[1]) return 0;
            if (nums[nums.Length - 1] > nums[nums.Length - 2]) return nums.Length - 1;

            for (int i = 1; i < nums.Length - 1; i++)
            {
                if (nums[i - 1] < nums[i] && nums[i + 1] < nums[i])
                    return i;
            }

            return -1;
        }

    }
}
