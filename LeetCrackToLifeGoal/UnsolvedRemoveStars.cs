using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class UnsolvedRemoveStars
    {
        public static int NumDecodings(string s)
        {
            var answer = new List<string>();
            for (int i = 0; i < s.Length; i++)
            {
                if (i == 0 && s[i] != '0') answer.Add(s[i].ToString());
                else if (i > 0)
                {
                    if (s[i] != '0') answer.Add(s[i].ToString());
                    if (s[i - 1] != '0')
                    {
                        var str = s[i - 1].ToString() + s[i].ToString();
                        if (Int32.Parse(str) <= 26)
                        {
                            answer.Add(str);
                        }
                    }
                }
            }
            return answer.Count;
        }

        public static string RemoveStars(string s)
        {
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == '*')
                {
                    var count = 0;
                    var index = i;

                    while (s[index] == '*')
                    {

                        if (index == 0) return "";
                        index--;
                        count++;
                    }

                    for (int j = 0; j < count; j++)
                    {

                        if (index == 0) return "";
                        char[] charArr = s.ToCharArray();
                        charArr[index] = ' '; // freely modify the array
                        charArr[i - j] = ' ';
                        s = new string(charArr);
                        index--;
                    }

                    i = index;
                }
            }

            var str = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != ' ')
                {
                    str += s[i];
                }
            }
            return str;
        }
    }
}
