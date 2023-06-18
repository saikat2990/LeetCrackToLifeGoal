using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class RemoveDuplicatess
    {
        public static int RemoveDuplicates(int[] nums)
        {
            var hashSet = new Dictionary<int, int>();
            foreach (int num in nums)
            {
                if (hashSet.ContainsKey(num))
                {
                    hashSet[num]++;
                }
                else
                {
                    hashSet.Add(num, 1);
                }
            }

            var getAllkeys = hashSet.Keys.ToList();
            var count = 0;
            Array.Clear(nums, 0, nums.Length);
            for (int i = 0; i < getAllkeys.Count; i++)
            {
                if (hashSet[getAllkeys[i]] == 1)
                {
                    nums[count] = getAllkeys[i];
                    count++;
                }
                else
                {
                    nums[count] = getAllkeys[i];
                    count++;
                    nums[count] = getAllkeys[i];
                    count++;
                }
            }

            int oneExists = hashSet.Values.Count(x => x == 1);
            var twoCount = hashSet.Count() - oneExists;
            var answer = oneExists + twoCount * 2;
            return answer;


        }

    }
}
