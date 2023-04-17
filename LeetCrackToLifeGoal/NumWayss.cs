using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class NumWayss
    {
        public static int NumWays(string[] words, string target)
        {
            int alphabet = 26;
            int mod = 1000000007;
            int m = target.Length, k = words[0].Length;
            int[,] cnt = new int[alphabet, k];
            for (int j = 0; j < k; j++)
            {
                foreach (string word in words)
                {
                    cnt[word[j] - 'a', j]++;
                }
            }
            long[,] dp = new long[m + 1, k + 1];
            dp[0, 0] = 1;
            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    if (i < m)
                    {
                        dp[i + 1, j + 1] += cnt[target[i] - 'a', j] * dp[i, j];
                        dp[i + 1, j + 1] %= mod;
                    }
                    dp[i, j + 1] += dp[i, j];
                    dp[i, j + 1] %= mod;
                }
            }
            return (int)dp[m, k];
        }

    }
}
