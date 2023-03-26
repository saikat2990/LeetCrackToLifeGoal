

using System.Linq;
using static LeetCrackToLifeGoal.MergeKListss;

namespace leetCrack
{

    public class Program
    {

        public static int MinSubArrayLen(int target, int[] nums)
        {
            var right = 0;
            var left = 0;
            var sum = 0;
            var count = nums.Length+1;
            var store = (nums[0]);
            while (true)
            {
                if (target > store)
                {
                    if (right >= nums.Length - 1) break;
                    right++;
                    store+=(nums[right]);
                }
                else
                {
                    if ((right - left + 1) < count)
                    {
                        count = right - left + 1;
                        if (count == 1) return count;

                    }
                   
                    store-=nums[left];
                    left++;
                }

            }

            if (count > nums.Length) return 0;
            return count;
        }

        public static void Main(string[] args)
        {

            MinSubArrayLen(7, new int[] { 2, 3, 1, 2, 4, 3 });
        }

       
    }
   
}