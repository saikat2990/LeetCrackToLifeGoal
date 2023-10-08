using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    public class MinDifficultys
    {
        public int MinDifficulty(int[] jobDifficulty, int d)
        {
            if (d > jobDifficulty.Length) return -1;
            if (d == jobDifficulty.Length) return jobDifficulty.Sum();
            var dp = new int[d + 1, jobDifficulty.Length + 1];
            for (int i = 0; i <= d; i++)
            {
                for (int j = 0; j < jobDifficulty.Length; j++)
                {
                    dp[i, j] = Int32.MaxValue;
                }
            }

            for (int day = 1; day <= d; day++)
            {
                for (int i = 0; i < jobDifficulty.Length - day + 1; i++)
                {
                    var diff = 0;
                    for (int j = i + 1; j < jobDifficulty.Length - day + 2; j++)
                    {
                        diff = Math.Max(diff, jobDifficulty[j - 1]);
                        if (dp[day - 1, j] != Int32.MaxValue)
                        {
                            dp[day, i] = Math.Min(diff + dp[day - 1, j], dp[day, i]);
                        }
                    }
                }
            }
            return dp[d, 0] == Int32.MaxValue ? -1 : dp[d, 0];
        }
    }
}
