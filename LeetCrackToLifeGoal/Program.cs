using System;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace leetCrack
{
    

    public class Program
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

            for (int i = notZeros.Count; i <notZeros.Count+countZero; i++)
            {
                nums[i] = 0;
            }

            foreach (var VARIABLE in nums)
            {
                Console.Write(VARIABLE);
            }
        }
        public static void Main(string[] args)
        {
            MoveZeroes(new int[] { 1, 2, 3, 0, 6, 0, 9, 3 });
        }


    }
   
}