using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class SmallestEquivalentStrings
    {
        public static string SmallestEquivalentString(string s1, string s2, string baseStr)
        {
            UnionFindCharacter ufChar = new UnionFindCharacter();

            for (int i = 0; i < s1.Length; i++)
            {
                char[] charArr = new char[2] { s1[i], s2[i] };
                Array.Sort(charArr);
                if (ufChar.Find(charArr[1]) > ufChar.Find(charArr[0]))
                    ufChar.Union(charArr[1], charArr[0]);
                else ufChar.Union(charArr[0], charArr[1]);
            }

            var ans = "";
            for (int i = 0; i < baseStr.Length; i++)
            {
                ans += ufChar.Find(baseStr[i]).ToString();
            }
            return ans;
        }
    }
}
