using System;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace leetCrack
{
    

    public class Program
    {
        public int FindCenter(int[][] edges)
        {
            var dict = new Dictionary<int, int>();
            foreach (var edge in edges)
            {
                if (dict.ContainsKey(edge[0]))
                {
                    dict[edge[0]]++;
                }
                else
                {
                    dict.Add(edge[0],1);
                }
                if (dict.ContainsKey(edge[1]))
                {
                    dict[edge[1]]++;
                }
                else
                {
                    dict.Add(edge[1], 1);
                }
            }
            var allKeys = dict.Keys;
            var maxVal = -1;
            var maxFace = -1;
            foreach (var key in allKeys)
            {
                if (dict[key] > maxVal)
                {
                    maxVal = dict[key];
                    maxFace = key;
                }
            }
            return maxFace;
        }
        public static void Main(string[] args)
        {
           
        }


    }
   
}