using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class LongestValidParenthesess
    {
        public static int LongestValidParentheses(string s)
        {
            var stack = new Stack<int>();
            var max = Int32.MinValue;
            for (int i = 0; i < s.Length; i++)
            {
                var ch = s[i];
                if (ch == '(')
                {
                    stack.Push(i);
                }
                else
                {
                    if (stack.Count > 0)
                    {
                        var index = stack.Pop();
                        if (stack.Count == 0)
                        {
                            stack.Push(index);
                            var check = i - index;
                            max = Math.Max(max, check);
                        }
                        else
                        {
                            index = stack.Peek();
                            var check = i - index;

                            max = Math.Max(max, check);
                        }
                    }
                }
            }

            if (max == Int32.MinValue) return 0;
            if (max % 2 == 1) max += 1;
            return max;
        }


    }
}
