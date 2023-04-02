using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class Rob2
    {
        public static int Rob(int[] nums)
        {
            if (nums.Length <= 3)
            {
                Array.Sort(nums);
                return nums[nums.Length - 1];
            }

            var indexArray = new List<int>();
            var prev = nums[0];
            var curr = nums[1];
            var isFirst = false;
            for (int i = 2; i < nums.Length - 1; i++)
            {
                var previous = prev;
                prev = Math.Max(curr, prev);
                curr = Math.Max(previous + nums[i], curr);

            }

            var ans1 = curr;

            prev = nums[1];
            curr = nums[2];
            for (int i = 2; i < nums.Length; i++)
            {
                var previous = prev;
                prev = Math.Max(curr, prev);
                curr = Math.Max(previous + nums[i], curr);

            }

            return Math.Max(curr, ans1);


            //if (isFirst)
            //{
            //    if (curr >= prev + nums[nums.Length-1])
            //    {
            //        return curr;
            //    }
            //    else
            //    {
            //        var pr = prev;
            //        if (prev - nums[0] + nums[nums.Length - 1] > pr)
            //        {
            //            return prev - nums[0] + nums[nums.Length - 1];
            //        }
            //        else
            //        {
            //            return pr;
            //        }
            //    }
            //}
            //else
            //{
            //    if (curr > prev + nums[nums.Length - 1])
            //    {
            //        return curr;
            //    }
            //    else return prev + nums[nums.Length - 1];
            //}

            Console.WriteLine(curr + " " + prev);
            return curr;
        }

    }
}
