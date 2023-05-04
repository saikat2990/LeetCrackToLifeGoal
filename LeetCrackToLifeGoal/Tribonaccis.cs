using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class Tribonaccis
    {
        public static int Tribonacci(int n)
        {
            var f = new int[100];
            if (n == 1) return 1;
            if (n == 2) return 2;
            f[0] = 1; f[1] = 1;

            var i = 2;
            while (i <= n)
            {
                f[i] += f[i - 1] + f[i - 2];
                i++;

            }
            return f[n];
        }
    }
}
