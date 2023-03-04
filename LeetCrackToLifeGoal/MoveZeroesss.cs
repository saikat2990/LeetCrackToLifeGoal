using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    public class MoveZeroesss
    {
        public static void MoveZeroes(int[] nums)
        {
            var countZero = 0;
            var notZeros = new List<int>();
            foreach (var num in nums)
            {
                if (num != 0)
                {
                    notZeros.Add(num);
                }
                else
                {
                    countZero++;
                }
            }

            for (int i = 0; i < notZeros.Count; i++)
            {
                nums[i] = notZeros[i];
            }

            for (int i = notZeros.Count; i < notZeros.Count + countZero; i++)
            {
                nums[i] = 0;
            }

            foreach (var VARIABLE in nums)
            {
                Console.Write(VARIABLE);
            }
        }
    }
}
