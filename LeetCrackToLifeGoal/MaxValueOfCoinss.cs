using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class MaxValueOfCoinss
    {
        public int MaxValueOfCoins(IList<IList<int>> piles, int k)
        {
            var n = piles.Count;
            var dp = new int[n][];
            for (int i = 0; i < n; i++)
            {
                dp[i] = new int[k + 1];
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < dp[i].Length; j++)
                {
                    dp[i][j] = -1;
                }
            }

            return recursivelySetValue(piles, dp, k, n - 1);
        }

        private int recursivelySetValue(IList<IList<int>> piles, int[][] dp, int k, int currentPile)
        {
            if (currentPile < 0 || k < 0) return 0;
            if (dp[currentPile][k] != -1) return dp[currentPile][k];

            int maxTraverse = Math.Min(k, piles[currentPile].Count);
            var maxSum = recursivelySetValue(piles, dp, k, currentPile - 1);
            int pickNow = 0;
            for (int i = 0; i < maxTraverse; i++)
            {
                pickNow += piles[currentPile][i];
                var nextSum = recursivelySetValue(piles, dp, k - i - 1, currentPile - 1);
                maxSum = Math.Max(maxSum, pickNow + nextSum);
            }

            return dp[currentPile][k] = maxSum;
        }
    }
}
