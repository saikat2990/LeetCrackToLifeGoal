using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class _3Sum
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            var result = new List<IList<int>>();
            Array.Sort(nums);

            for (int i = 0; i < nums.Length - 2; i++)
            {
                var ini = nums[i];
                var currentValue = nums[i];
                var low = i + 1;
                var high = nums.Length - 1;
                while (low < high)
                {
                    if ((nums[low] + nums[high] + currentValue) == 0)
                    {
                        var data = new List<int>() { nums[low], nums[high], currentValue };
                        data.Sort();
                        ini = data[0];
                        result.Add(data);
                        low++;
                        high--;
                    }

                    if ((0 - currentValue) > nums[low] + nums[high]) low++;
                    if ((0 - currentValue) < nums[low] + nums[high]) high--;

                }
                result = result.OrderBy(x => x[0]).ToList();
                while (nums[i + 1] == ini && i < nums.Length - 2) i++;

            }

            return result;
        }

    }
}
