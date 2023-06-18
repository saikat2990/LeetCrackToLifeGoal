using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class NextPermutations
    {
        public static void NextPermutation(int[] nums)
        {
            var length = nums.Length;
            var tag = false;
            var temporalList = new List<int>();
            while (length > 0)
            {
                var index = length - 1;
                if (index > 0)
                {

                    if (nums[index] > nums[index - 1])
                    {
                        temporalList.Add(nums[index]);
                        temporalList.Sort();
                        for (int i = index; i < nums.Length; i++)
                        {
                            if (nums[index - 1] < temporalList[i - index])
                            {
                                var temp = temporalList[i - index];
                                temporalList[i - index] = nums[index - 1];
                                nums[index - 1] = temp;
                                temporalList.Sort();
                                break;
                            }
                        }

                        for (int i = index; i < nums.Length; i++)
                        {
                            nums[i] = temporalList[i - index];
                        }


                        tag = true;
                        break;
                    }

                    temporalList.Add(nums[index]);
                }
                length--;
            }

            if (!tag)
            {
                Array.Sort(nums);
            }

        }

    }
}
