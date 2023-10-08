using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{

    internal class KnightDialers
    {
        public static long mod = (long)1e9 + 7;

        public static int KnightDialer(int n)
        {
            if (n == 1) return 10;
            long d1 = 1; long d2 = 1; long d3 = 1; long d4 = 1;
            long d6 = 1; long d7 = 1; long d8 = 1; long d9 = 1; long d0 = 1;

            while (n-- > 1)
            {
                long td0 = (d4 + d6) % mod;
                long td1 = (d6 + d8) % mod;
                long td2 = ((d7 + d9) % mod);
                long td3 = ((d4 + d8) % mod);
                long td4 = ((d0 + d3 + d9) % mod);
                long td6 = ((d0 + d1 + d7) % mod);
                long td7 = ((d6 + d2) % mod);
                long td8 = ((d1 + d3) % mod);
                long td9 = ((d2 + d4) % mod);

                d0 = (td0 % mod);
                d1 = (td1 % mod);
                d2 = (td2 % mod);
                d3 = (td3 % mod);
                d4 = (td4 % mod);
                d6 = (td6 % mod);
                d7 = (td7 % mod);
                d8 = (td8 % mod);
                d9 = (td9 % mod);
            }

            var sum = d0 % mod + d1 % mod + d2 % mod + d3 % mod + d4 % mod + d6 % mod + d7 % mod + d8 % mod + d9 % mod;
            var data = (int)(sum % mod);
            return data;
        }

    }
}
