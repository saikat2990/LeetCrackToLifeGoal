using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class NumSubarrayProductLessThanKs
    {
        public static int NumSubarrayProductLessThanK(int[] nums, int k)
        {

            var right = 0;
            int count = 0;
            var added = new Queue<int>();
            var product = 1;
            while (right < nums.Length)
            {
                if (nums[right] < k)
                {

                    count++;
                    added.Enqueue(nums[right]);
                    product *= nums[right];
                    while (product >= k)
                    {
                        product = product / added.Peek();
                        added.Dequeue();
                    }


                    if (added.Count > 2)
                        count += ((added.Count - 1));
                    else if (added.Count == 2 && product < k) count++;
                }
                else
                {
                    added.Clear();
                    product = 1;
                }

                right++;
            }

            return count;
        }
    }
}
