using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class ClimbStairs
    {
        public static int ClimbStairsss(int n)
        {
            var f = new int[100];
            if (n == 1) return 1;
            if (n == 2) return 2;
            f[0] = 1; f[1] = 2;

            var i = 2;
            while (i <= n)
            {
                f[i] = f[i - 1] + f[i - 2];
                i++;

            }

            return f[n - 1];
        }
        public static void backTrack(List<int> currentArray, int n, List<List<int>> answer)
        {
            if (currentArray.Sum() == n)
            {
                var copyArr = new List<int>();
                foreach (var val in currentArray)
                {
                    copyArr.Add(val);
                }
                answer.Add(copyArr);
            }


            else
            {
                if (currentArray.Sum() + 1 <= n)
                {
                    currentArray.Add(1);
                    backTrack(currentArray, n, answer);
                    if (currentArray.Any())
                    {
                        currentArray.RemoveAt(currentArray.Count - 1);
                    }
                }

                if (currentArray.Sum() + 2 <= n)
                {

                    currentArray.Add(2);
                    backTrack(currentArray, n, answer);
                    if (currentArray.Any())
                    {
                        currentArray.RemoveAt(currentArray.Count - 1);
                    }
                }
            }




        }

        public static int ClimbStairss(int n)
        {
            var current = new List<int>();
            var answer = new List<List<int>>();
            backTrack(current, n, answer);
            return answer.Count;
        }

    }
}
