using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    public class RemoveKdigitss
    {
        public static string RemoveKdigits(string num, int k)
        {

            var stack = new Stack<char>();
            foreach (var ch in num)
            {
                while (k > 0 && stack.Count > 0 && ch < stack.Peek())
                {
                    stack.Pop();
                    k--;
                }
                stack.Push(ch);
            }

            while (k > 0)
            {
                stack.Pop();
                k--;
            }

            var ans = "";
            while (stack.Count > 0)
            {
                ans += stack.Peek();
                stack.Pop();
            }

            char[] arr = ans.ToCharArray();
            Array.Reverse(arr);
            var ansf = new string(arr);
            ansf = ansf.TrimStart('0');
            return ansf.Length == 0 ? "0" : ansf;
        }

    }
}
