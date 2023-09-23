namespace LeetCrackToLifeGoal
{
    internal class ReorganizeStrings
    {
        public static string ReorganizeString(string s)
        {
            var result = "";
            var dict = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (!dict.ContainsKey(s[i]))
                {
                    dict.Add(s[i], 1);
                }
                else
                {
                    dict[s[i]]++;
                }
            }
            dict = dict.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            while (dict.Count > 0)
            {
                if (dict.Count == 1)
                {
                    for (int i = 0; i < dict[dict.ElementAt(0).Key]; i++)
                    {
                        result += (dict.ElementAt(0).Key);
                    }
                    dict.Remove(dict.ElementAt(0).Key);
                    break;
                }

                if (dict[dict.ElementAt(0).Key] > 0)
                {
                    result += (dict.ElementAt(0).Key);
                    dict[dict.ElementAt(0).Key]--;
                }
                if (dict[dict.ElementAt(0).Key] == 0)
                {
                    dict.Remove(dict.ElementAt(0).Key);
                }
                if (dict.Count == 1)
                {
                    for (int i = 0; i < dict[dict.ElementAt(0).Key]; i++)
                    {
                        result += (dict.ElementAt(0).Key);
                    }
                    dict.Remove(dict.ElementAt(0).Key);
                    break;
                }
                if (dict[dict.ElementAt(1).Key] > 0)
                {
                    result += (dict.ElementAt(1).Key);
                    dict[dict.ElementAt(1).Key]--;
                }
                if (dict[dict.ElementAt(1).Key] == 0)
                {
                    dict.Remove(dict.ElementAt(1).Key);
                }

            }

            for (int i = 1; i < result.Length; i++)
                if (result[i] == result[i - 1]) return "";
            return result;
        }

    }
}
