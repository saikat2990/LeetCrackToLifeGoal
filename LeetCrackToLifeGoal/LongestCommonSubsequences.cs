using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class LongestCommonSubsequences
    {
        public static int LongestCommonSubsequence(string text1, string text2)
        {
            var dataCheck = new int[text2.Length + 1][];
            for (int i = 0; i < dataCheck.Length; i++)
            {
                dataCheck[i] = new int[text1.Length + 1];
            }

            for (int i = 1; i <= text2.Length; i++)
            {
                for (int j = 1; j <= text1.Length; j++)
                {

                    if (text1[j - 1] == text2[i - 1])
                    {
                        dataCheck[i][j] = dataCheck[i - 1][j - 1] + 1;
                    }
                    else
                    {
                        dataCheck[i][j] = Math.Max(dataCheck[i - 1][j], dataCheck[i][j - 1]);
                    }


                }
            }
            return dataCheck[text2.Length][text1.Length];
        }
    }
}
