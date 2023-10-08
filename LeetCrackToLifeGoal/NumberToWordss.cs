using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class NumberToWordss
    {
        public static string NumberToWords(int num)
        {
            var fistAndThird = new string[] { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
            var second = new string[] { "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
            var dic = new Dictionary<string, string>();
            dic.Add("10", "Ten");
            dic.Add("11", "Eleven");
            dic.Add("12", "Twelve");
            dic.Add("13", "Thirteen");
            dic.Add("14", "Fourteen");
            dic.Add("15", "Fifteen");
            dic.Add("16", "Sixteen");
            dic.Add("17", "Seventeen");
            dic.Add("18", "Eighteen");
            dic.Add("19", "Nineteen");

            string calculate(string num)
            {
                if (num == "000")
                    return "";
                var result = "";
                if (num[2] != '0')
                {
                    result += fistAndThird[(num[2] - '0') - 1];
                }

                if (num[1] != '0')
                {
                    if (num[1] == '1')
                    {
                        result = dic[num[1] + num[2].ToString()];
                    }
                    else
                        result = second[(num[1] - '0') - 1] + " " + result;
                }

                if (num[0] != '0')
                {
                    result = fistAndThird[(num[0] - '0') - 1] + " Hundred" + result;
                }
                return result;
            }

            var sNum = num.ToString();
            sNum = sNum.PadLeft(12, '0');
            var d1 = calculate(sNum.Substring(0, 3)).Trim();
            var d2 = calculate(sNum.Substring(3, 3));
            var d3 = calculate(sNum.Substring(6, 3));
            var d4 = calculate(sNum.Substring(9, 3)).Trim();

            var r = (d1 == "" ? "" : d1 + " Billion") + (d2 == "" ? "" : d2 + " Million") + (d3 == "" ? "" : d3 + " Thousand") + d4;
            while (r.Contains("  "))
            {
                r = r.Replace("  ", " ");
            }
            return r;

        }

    }
}
