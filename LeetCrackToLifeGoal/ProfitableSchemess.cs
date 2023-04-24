using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class ProfitableSchemess
    {
        public static int ProfitableSchemes(int n, int minProfit, int[] group, int[] profit)
        {
            int MOD = 1000000007;
            int[,] dp = new int[minProfit + 1, n + 1];
            dp[0, 0] = 1;
            for (int k = 0; k < group.Length; k++)
            {
                int g = group[k];
                int p = profit[k];
                for (int i = minProfit; i >= 0; i--)
                {
                    for (int j = n - g; j >= 0; j--)
                    {
                        dp[Math.Min(i + p, minProfit), j + g] += dp[i, j];
                        dp[Math.Min(i + p, minProfit), j + g] %= MOD;
                    }
                }
            }
            int sum = 0;
            for (int j = 0; j <= n; j++)
            {
                sum = (sum + dp[minProfit, j]) % MOD;
            }
            return sum;
        }
    }
}
