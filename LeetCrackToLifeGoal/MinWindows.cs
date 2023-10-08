using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class MinWindows
    {
        public static string MinWindow(string s, string t)
        {
            var dict = new Dictionary<char, int>();
            foreach (var c in t)
            {
                if (!dict.ContainsKey(c))
                {
                    dict.Add(c, 0);
                }
                dict[c]++;
            }

            var r = 0;
            var l = 0;
            var count = 0;
            var len = int.MaxValue;
            var head = l;
            while (r < s.Length)
            {
                if (dict.ContainsKey(s[r]))
                {
                    dict[s[r]]--;
                    if (dict[s[r]] == 0) count++;
                }

                r++;
                while (count == dict.Count)
                {
                    if (len > r - l)
                    {
                        len = r - l;
                        head = l;
                    }

                    if (dict.ContainsKey(s[l]))
                    {
                        dict[s[l]]++;
                        if (dict[s[l]] > 0) count--;
                    }

                    l++;
                }
            }

            if (len == int.MaxValue) return "";
            return s.Substring(head, len);
        }

    }
}
