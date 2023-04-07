
using LeetCrackToLifeGoal;
using static leetCrack.FindWords;

namespace leetCrack
{

    public class Program
    {

        public static bool WordBreak(string s, IList<string> wordDict)
        {
            var subString = "";
            for (int j = 0; j < s.Length; j++)
            {
                var ch = s[j];
                subString += ch.ToString();
                for (int i = 0; i < wordDict.Count; i++)
                {
                    if (wordDict[i] == subString)
                    {
                        subString = "";
                        break;
                    }

                    if (j + 1 < s.Length)
                    {
                        var ss = s.Substring(j, s.Length);
                        if (wordDict.Contains(ss))
                        {
                            return true;
                        }
                    }

                    
                }

            }
            if (subString != "") return false;

            return true;
        }
        public static void Main(string[] args)
        {
            WordBreak("aaaaaaa", new List<string>() { "aaaa", "aaa" });
        }

       
    }
   
}