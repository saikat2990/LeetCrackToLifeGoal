
using LeetCrackToLifeGoal;
using static leetCrack.FindWords;

namespace leetCrack
{

    public class Program
    {
        public static int NumDecodings(string s)
        {
            var answer = new List<string>();
            for (int i = 0; i < s.Length; i++)
            {
                if(i==0 && s[i] != '0') answer.Add(s[i].ToString());
                else if(i>0)
                {
                    if (s[i]!='0') answer.Add(s[i].ToString());
                    if (s[i - 1] != '0')
                    {
                        var str = s[i-1].ToString()+ s[i].ToString();
                        if (Int32.Parse(str) <= 26)
                        {
                            answer.Add(str);
                        }
                    }
                }
            }
            return answer.Count;
        }

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
                    Console.WriteLine(stack.Peek());
                    var findIndex = firstBracket.Contains(stack.Peek())
                        ? secondBracket.FindIndex(x=>x==s[i])
                        : -1;
                    if (findIndex !=-1 && secondBracket.Contains(s[i]) && firstBracket[findIndex] == stack.Peek())
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
        public static void Main(string[] args)
        {
            IsValid("()[]{}");
            //NumDecodings("225");
        }

       
    }
   
}