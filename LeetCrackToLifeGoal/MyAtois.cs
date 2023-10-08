using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class MyAtois
    {
        public static int MyAtoi(string s)
        {
            if (s == "") return 0;
            double ans = 0;
            var index = 0;
            while (index < s.Length && s[index] == ' ')
            {
                index++;
            }

            var sign = 1;

            if (index < s.Length && (s[index] == '-' || s[index] == '+'))
            {
                if (s[index] == '-') sign = -1;
                index++;
            }

            while (index < s.Length && s[index] > 47 && s[index] < 58)
            {
                if (ans > 0) ans *= 10;
                ans += (s[index] - '0');
                index++;
            }

            ans *= sign;
            if (ans < -2147483648) return -2147483648;
            if (ans > 2147483647) return 2147483647;
            return (int)ans;
        }
    }
}
