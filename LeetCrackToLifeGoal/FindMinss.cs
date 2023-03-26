using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class FindMinss
    {
        public int FindMin(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;
            var left = 0;
            var right = nums.Length - 1;
            var mid = 0;
            while (left < right)
            {
                mid = left + (right - left) / 2;
                if (nums[mid] < nums[right])
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return nums[left];
        }
    }
}
