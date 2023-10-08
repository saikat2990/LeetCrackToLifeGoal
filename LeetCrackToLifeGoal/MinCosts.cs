using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    public class MinCosts
    {
        public static int MinCost(int n, int[] cuts)
        {
            List<int> list = new List<int>();
            var c = cuts.Length;
            list.Add(0);
            foreach (var cut in cuts) list.Add(cut);
            list.Add(n);
            cuts = list.ToArray();
            Array.Sort(cuts);

            var dp = new int[cuts.Length + 1, cuts.Length + 1];
            for (int i = 0; i <= cuts.Length; i++)
            for (int j = 0; j < cuts.Length; j++)
                dp[i, j] = -1;

            var data = solve(cuts, 1, c, dp);
            return data;
        }
        private static int solve(int[] cuts, int ini, int final, int[,] dp)
        {
            if (ini > final) return 0;
            var mini = Int32.MaxValue;
            if (dp[ini, final] != -1) return dp[ini, final];
            for (int i = ini; i <= final; i++)
            {
                mini = Math.Min(mini, cuts[final + 1] - cuts[ini - 1] + solve(cuts, ini, i - 1, dp) + solve(cuts, i + 1, final, dp));
            }

            dp[ini, final] = mini;
            return mini;
        }
    }
}
