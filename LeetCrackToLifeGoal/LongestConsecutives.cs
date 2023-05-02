using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class LongestConsecutives
    {
        public static int LongestConsecutive(int[] nums)
        {
            if (nums.Length == 0) return 0;
            Array.Sort(nums);
            var storeData = new List<List<int>>();
            var data = new HashSet<int>();
            data.Add(nums[0]);
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i - 1] == nums[i] - 1 || nums[i - 1] == nums[i])
                {
                    data.Add(nums[i]);
                }
                else
                {
                    List<int> newList = data.ToList().GetRange(0, data.Count);
                    storeData.Add(newList);
                    data.Clear();
                    data.Add(nums[i]);
                }
            }
            if (data.Count > 0)
                storeData.Add(data.ToList());
            var count = 0;
            for (int i = 0; i < storeData.Count; i++)
            {
                if (storeData[i].Count > count) count = storeData[i].Count;
            }
            return count;
        }
    }
}
