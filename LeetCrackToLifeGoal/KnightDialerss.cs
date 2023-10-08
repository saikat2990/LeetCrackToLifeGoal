using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class KnightDialerss
    {
        public static int KnightDialers(int n)
        {
            var answer = 0;
            var listData = new Dictionary<int, string>();
            listData.Add(0, "46");
            listData.Add(1, "68");
            listData.Add(2, "79");
            listData.Add(3, "48");
            listData.Add(4, "039");
            listData.Add(6, "017");
            listData.Add(7, "26");
            listData.Add(8, "13");
            listData.Add(9, "24");
            var jumpString = new string[9] { "0", "1", "2", "3", "4", "6", "7", "8", "9" };
            for (int i = 0; i < n - 1; i++)
            {
                var newJumpString = new List<string>();
                for (int j = 0; j < jumpString.Length; j++)
                {


                    var s = jumpString[j];
                    for (int l = 0; l < listData[Int32.Parse(s[s.Length - 1].ToString())].Length; l++)
                    {
                        newJumpString.Add(s + listData[Int32.Parse(s[s.Length - 1].ToString())][l]);
                    }


                }

                jumpString = newJumpString.ToArray();
            }

            return jumpString.Length % (100000007);
        }


    }
}
