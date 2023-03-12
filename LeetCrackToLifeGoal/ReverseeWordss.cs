using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class ReverseeWordss
    {
        public static string ReverseeWordsss(string s)
        {
            var result = "";
            var stringList = s.Split(" ");
            for (int j = 0; j < stringList.Length; j++)
            {
                char[] chars = stringList[j].ToCharArray();
                for (int i = 0; i < chars.Length / 2; i++)
                {
                    (chars[i], chars[chars.Length - i - 1]) = (chars[chars.Length - i - 1], chars[i]);
                }

                foreach (var ch in chars)
                {
                    result += ch.ToString();
                }

                if (j != stringList.Length - 1) result += " ";
            }

            return result;


        }
        public static void ReverseString(char[] s)
        {
            for (int i = 0; i < s.Length / 2; i++)
            {
                (s[i], s[s.Length - i - 1]) = (s[s.Length - i - 1], s[i]);
            }

            for (int i = 0; i < s.Length; i++)
            {
                Console.Write(s[i]);
            }
        }
        public static void Mainss(string[] args)
        {

            //ReverseString(new char[] { 'H', 'a', 'n', 'n', 'a', 'h' });
            ReverseeWordsss("djkahs aioshjd 8iasd ");
        }

    }
}
