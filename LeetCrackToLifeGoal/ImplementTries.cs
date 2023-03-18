using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class ImplementTries
    {
    }
    public class Trie
    {
        private HashSet<string> values;
        private HashSet<string> keys;
        public Trie()
        {
            values = new HashSet<string>();
            keys = new HashSet<string>();
        }

        public void Insert(string word)
        {
            if (!values.Contains(word))
            {
                values.Add(word);
            }

            for (int i = 0; i < word.Length; i++)
            {
                var subString = word.Substring(0, 1);
                if (!keys.Contains(subString))
                {
                    keys.Add(subString);
                }
            }
        }

        public bool Search(string word)
        {
            if (values.Contains(word)) return true;
            return false;
        }

        public bool StartsWith(string prefix)
        {
            if (keys.Contains(prefix)) return true;
            return false;
        }
    }
}
