using System;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace leetCrack
{

    public class Program
    {


        public static int ClimbStairs(int n)
        {
            var f = new int[100];
            if (n == 1) return 1;
            if (n == 2) return 2;
            var m = n;
            f[0]=1; f[1]=2;
        
            var i = 2;
            while (i<=n)
            {
                f[i] = f[i - 1] + f[i - 2];
                i++;
               
            }

            return f[n - 1];
        }

        public static void Main(string[] args)
        {
            var data = ClimbStairs(6);
            Console.WriteLine(data);
        }


    }
   
}