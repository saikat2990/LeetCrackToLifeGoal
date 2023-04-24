using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class MinInsertionss
    {
        private static int MinInsertions(string s, Dictionary<string, int> dic)
        {
            if (dic.ContainsKey(s)) return dic[s];
            if (s.Length == 1) return 0;
            if (s.Length == 2) return s[0] == s[1] ? 0 : 1;
            var rs = -1;
            if (s[0] == s[s.Length - 1])
            {
                rs = MinInsertions(s.Substring(1, s.Length - 2), dic);
            }
            else
            {
                var rs0 = MinInsertions(s.Substring(1), dic);
                var rs1 = MinInsertions(s.Substring(0, s.Length - 1), dic);
                rs = 1 + Math.Min(rs0, rs1);
            }
            if (!dic.ContainsKey(s)) dic.Add(s, rs);
            return rs;
        }
        public static int MinInsertions(string s)
        {
            var dic = new Dictionary<string, int>();
            dic.Add("", 0);
            var rs = MinInsertions(s, dic);
            return rs;
        }
    }
}
