using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class LengthOfLIS_Should_Solve_Again
    {
        public int LengthOfLIS(int[] nums)
        {

            var lenSum = new int[nums.Length][];
            lenSum[0] = new[] { 1, 1 };
            var maxLen = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                var currentNum = 0;
                var curSum = 1;
                for (int j = 0; j < i; j++)
                {
                    if (nums[j] < nums[i])
                    {
                        if (currentNum < lenSum[j][0])
                        {
                            currentNum = lenSum[j][0];
                            curSum = lenSum[j][1];
                        }

                        if (currentNum == lenSum[j][0])
                        {
                            curSum += lenSum[j][1];
                        }

                    }
                }

                currentNum++;
                lenSum[i][0] = currentNum;
                lenSum[i][1] = curSum;
                maxLen = Math.Max(maxLen, currentNum);
            }

            return lenSum.Sum(v => v[0] == maxLen ? v[1] : 0);
        }
    }
}
