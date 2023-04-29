using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class NumSimilarGroupss
    {
        //public static bool isMismatchMoreThan2(string str1, string str2)
        //{

        //    var count = 0;
        //    for (int i = 0; i < str1.Length; i++)
        //    {
        //        if (str1[i] != str2[i])
        //        {
        //            count++;
        //            if (count > 2) return false;
        //        }
        //    }
        //    return true;
        //}

        //public static int NumSimilarGroups(string[] strs)
        //{
        //    if (strs.Length == 0) return 0;
        //    var dict = new Dictionary<string, int>();
        //    var uni = 1;
        //    dict.Add(strs[0],uni);
        //    for (int i = 0; i < strs.Length; i++)
        //    {
        //        var isFound = false;
        //        for (int j = i+1; j < strs.Length; j++)
        //        {
        //            if (isMismatchMoreThan2(strs[i], strs[j]))
        //            {
        //                isFound = true;

        //                if (!dict.ContainsKey(strs[j]) && dict.ContainsKey(strs[i]))
        //                {
        //                    dict.Add(strs[j], dict[strs[i]]);
        //                }


        //            }

        //        }

        //        if (!isFound && !dict.ContainsKey(strs[i]))
        //        {
        //            uni++;
        //            dict.Add(strs[i], uni);

        //        }
        //    }

        //    return uni;
        //}
        public static int NumSimilarGroups(string[] strs)
        {
            var graph = CreateGraph(strs);
            var aux = new int[strs.Length];
            var rs = 0;
            for (int i = 0; i < aux.Length; i++)
            {
                if (aux[i] == 0)
                {
                    rs++;
                    NumSimilarGroupsDfs(rs, i, aux, graph);
                }
            }
            return rs;
        }
        private static void NumSimilarGroupsDfs(int id, int index, int[] aux, List<int>[] graph)
        {
            aux[index] = id;
            for (int i = 0; i < graph[index].Count; i++)
            {
                if (aux[graph[index][i]] == 0) NumSimilarGroupsDfs(id, graph[index][i], aux, graph);
            }
        }
        private static List<int>[] CreateGraph(string[] strs)
        {
            var rs = new List<int>[strs.Length];
            for (int i = 0; i < rs.Length; i++)
            {
                rs[i] = new List<int>();
            }
            for (int i = 0; i < strs.Length - 1; i++)
            {
                for (int j = i + 1; j < strs.Length; j++)
                {
                    if (DifferIn2Chars(strs[i], strs[j]))
                    {
                        rs[i].Add(j);
                        rs[j].Add(i);
                    }
                }
            }
            return rs;
        }
        private static bool DifferIn2Chars(string str0, string str1)
        {
            var count = 0;
            for (int i = 0; i < str0.Length; i++)
            {
                if (str0[i] != str1[i])
                {
                    count++;
                    if (count > 2) return false;
                }
            }
            return true;
        }
    }
}
