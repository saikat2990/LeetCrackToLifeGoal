using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class PartitionStrings
    {
        public static int PartitionString(string s)
        {
            var length = s.Length;
            List<string> ans = new List<string>();
            for (int i = 0; i < length; i++)
            {
                var charTag = new bool[26];
                var str = "";
                var index = i;
                for (int j = i; j < length; j++)
                {
                    if (charTag[s[j] - 'a'] == true)
                    {
                        i = j - 1;
                        ans.Add(str);
                        str = "";
                        break;
                    }
                    charTag[s[j] - 'a'] = true;
                    str += s[j].ToString();
                    index = j;

                }
                if (index != i) i = index;
                if (str != "")
                    ans.Add(str);
            }
            return ans.Count;
        }
    }
}
