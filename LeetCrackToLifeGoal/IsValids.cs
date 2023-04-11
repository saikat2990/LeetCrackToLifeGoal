using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class IsValids
    {
        public static bool IsValid(string s)
        {
            var firstBracket = new List<char> { '(', '{', '[' };
            var secondBracket = new List<char> { ')', '}', ']' };
            var stack = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (firstBracket.Contains(s[i]))
                {
                    stack.Push(s[i]);
                }
                else
                {
                    if (stack.Count == 0) return false;
                    Console.WriteLine(stack.Peek());
                    var findIndex = firstBracket.Contains(stack.Peek())
                        ? secondBracket.FindIndex(x => x == s[i])
                        : -1;
                    if (findIndex != -1 && secondBracket.Contains(s[i]) && firstBracket[findIndex] == stack.Peek())
                    {
                        stack.Pop();
                    }

                    else
                    {
                        return false;
                    }
                }
            }

            if (stack.Count > 0) return false;
            return true;
        }
    }
}
