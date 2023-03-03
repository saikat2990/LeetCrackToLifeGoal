using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    public class Compress
    {
        public static int Compresss(char[] chars)
        {
            int i = 0;
            int j = 0;
            string str = "";
            while (chars.Length > i)
            {
                var ch = chars[i];
                j = i;
                var count = 0;
                while (chars.Length > j && chars[j] == ch)
                {
                    j++;
                    count++;
                }

                str += ch.ToString();

                if (count > 1)
                {
                    var countString = count.ToString();
                    foreach (var cS in countString)
                    {
                        i++;
                        str += cS.ToString();
                    }
                }

                i = j;

            }


            for (int k = 0; k < str.Length; k++)
            {
                chars[k] = str[k];
            }
            return str.Length;
        }


    }
}
