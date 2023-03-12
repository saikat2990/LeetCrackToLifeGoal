using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class ClimbStairs
    {
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
