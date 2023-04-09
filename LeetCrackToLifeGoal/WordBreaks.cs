using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class WordBreaks
    {
        public static bool WordBreak(string s, IList<string> wordDict)
        {
            HashSet<string> uniSetData = new HashSet<string>(wordDict);
            int[] memorize = new int[s.Length + 1];
            Array.Fill(memorize, -1);
            return recursivelyValidationCheck(s, uniSetData, memorize, 0);
        }

        public static bool recursivelyValidationCheck(string s, HashSet<string> uniSetData, int[] memorize, int start)
        {
            int i = start;
            bool match = false;
            if (start >= s.Length)
            {
                return true;
            }
            if (memorize[start] != -1)
            {
                return memorize[start] == 1;
            }
            while (i++ < s.Length)
            {
                var subString = s.Substring(start, i - start);
                if (uniSetData.Contains(subString))
                {
                    match = match || recursivelyValidationCheck(s, uniSetData, memorize, i);
                }
            }
            memorize[start] = match == true ? 1 : 0;
            return memorize[start] == 1;
        }
    }
}
