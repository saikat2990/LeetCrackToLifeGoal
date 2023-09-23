using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class MaxProfits
    {
        public static int MaxProfit(int[] prices)
        {
            var n = prices.Length;
            var leftToRight = new int[n];
            var rightToLeft = new int[n];
            var rightMax = prices[n - 1];
            var leftMin = prices[0];
            for (int i = 1; i < n; i++)
            {
                leftMin = Math.Min(leftMin, prices[i]);
                leftToRight[i] = Math.Max(leftToRight[i - 1], prices[i] - leftMin);
            }

            for (int i = n - 2; i >= 0; i--)
            {
                rightMax = Math.Max(rightMax, prices[i]);
                rightToLeft[i] = Math.Max(rightToLeft[i + 1], rightMax - prices[i]);
            }

            var answer = 0;
            for (int i = 0; i < n; i++)
            {
                answer = Math.Max(answer, leftToRight[i] + rightToLeft[i]);
            }

            return answer;
        }

    }
}
