using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class IsMatchs
    {
        public static bool IsMatch(string s, string p)
        {
            var dp = new bool[p.Length + 1, s.Length + 1];
            for (int i = 0; i <= p.Length; i++)
            {
                for (int j = 0; j <= s.Length; j++)
                {
                    dp[i, j] = false;
                }
            }

            for (int i = 0; i <= p.Length; i++)
            {
                for (int j = 0; j <= s.Length; j++)
                {
                    if (i == 0 && j == 0) { dp[i, j] = true; }
                    else if (j == 0)
                    {
                        if (i > 0 && p[i - 1] == '*')
                            dp[i, j] = dp[i - 2, j];
                    }
                    else if (i == 0) continue;
                    else
                    {
                        var chp = p[i - 1];
                        var chs = s[j - 1];
                        if (chp == '*')
                        {
                            dp[i, j] = dp[i - 2, j];
                            if (chs == p[i - 2] || p[i - 2] == '.')
                            {
                                dp[i, j] = dp[i, j] || dp[i, j - 1];
                            }
                        }
                        else if (chp == chs || chp == '.')
                        {
                            dp[i, j] = dp[i - 1, j - 1];
                        }
                    }
                }
            }

            return dp[p.Length, s.Length];
        }
    }
}
