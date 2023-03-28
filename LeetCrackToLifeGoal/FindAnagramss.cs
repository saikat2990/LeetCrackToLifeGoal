using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class FindAnagramss
    {
        public static IList<int> FindAnagrams(string s, string p)
        {

            var dict = new Dictionary<char, int>();
            var answer = new List<int>();
            if (s.Length == 0) return answer;
            var index = 0;
            var traverseIndex = index;
            foreach (var pattern in p)
            {
                if (!dict.ContainsKey(pattern))
                {
                    dict.Add(pattern, 1);
                }
                else
                {
                    dict[pattern]++;
                }
            }

            var tempDict = new Dictionary<char, int>();
            while (index < s.Length - p.Length + 1)
            {

                if (dict.ContainsKey(s[index]))
                {
                    for (int i = index; i < index + p.Length; i++)
                    {
                        if (i < s.Length && dict.ContainsKey(s[i]))
                        {
                            if (!tempDict.ContainsKey(s[i]))
                            {
                                tempDict.Add(s[i], 1);

                            }
                            else
                            {
                                tempDict[s[i]]++;
                            }
                        }
                        else
                        {
                            tempDict.Clear();
                            index++;
                            break;
                        }

                    }

                    if (tempDict.Count > 0)
                    {
                        var allKeys = dict.Keys;
                        var tag = true;
                        foreach (var cKey in allKeys)
                        {
                            if (tempDict.ContainsKey(cKey) && tempDict[cKey] != dict[cKey])
                            {
                                tag = false;
                                break;
                            }
                        }
                        if (tag)
                        {
                            answer.Add(index);
                            index++;
                        }
                        else
                        {

                            index++;
                        }
                    }

                    tempDict.Clear();
                }
                else
                {
                    index++;
                }
            }
            return answer;
        }
    }
}
