using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class FindAllConcatenatedWordsInADicts
    {
        public static IList<string> FindAllConcatenatedWordsInADict(string[] words)
        {
            HashSet<string> ws = new(words);
            var change = false;
            bool IsFound(string word, int count = 0)
            {
                if (words.Contains(word) && change)
                    return count > 0;
                for (int i = 1; i < word.Length; i++)
                {
                    change = true;
                    if (ws.Contains(word.Substring(0, i)) && IsFound(word.Substring(i, word.Length - i), count + 1))
                    {
                        return true;
                    }
                }
                return false;
            }

            return words.Where(w =>
            {
                change = false;
                return IsFound(w);
            }).ToList();
        }
    }
}
