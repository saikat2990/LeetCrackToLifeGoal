using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class MinFlipss
    {

        public static int MinFlips(int a, int b, int c)
        {
            string binaryA = Convert.ToString(a, 2);
            string binaryB = Convert.ToString(b, 2);

            string binaryC = Convert.ToString(c, 2);

            var lengthList = new List<int>() { binaryA.Length, binaryB.Length, binaryC.Length };
            lengthList.Sort();
            lengthList.Reverse();
            var max = lengthList.Max();
            if (binaryA.Length < max)
            {
                var shouldAdd = max - binaryA.Length;
                var str = "";
                for (int i = 0; i < shouldAdd; i++)
                {
                    str += "0";
                }

                binaryA = str + binaryA;
            }
            if (binaryB.Length < max)
            {
                var shouldAdd = max - binaryB.Length;
                var str = "";
                for (int i = 0; i < shouldAdd; i++)
                {
                    str += "0";
                }

                binaryB = str + binaryB;
            }
            if (binaryC.Length < max)
            {
                var shouldAdd = max - binaryC.Length;
                var str = "";
                for (int i = 0; i < shouldAdd; i++)
                {
                    str += "0";
                }

                binaryC = str + binaryC;
            }

            var count = 0;
            for (int i = 0; i < max; i++)
            {
                if (binaryC[i] == '0')
                {
                    if (binaryA[i] != '0') count++;
                    if (binaryB[i] != '0') count++;
                }

                if (binaryC[i] == '1')
                {
                    if (binaryA[i] != '1' && binaryB[i] != '1') count++;
                }
            }
            Console.WriteLine(binaryA + " " + binaryB + " " + binaryC + " count: " + count);

            return count;
        }
        public int MinCostClimbingStairs(int[] cost)
        {
            return 0;
        }
    }
}
