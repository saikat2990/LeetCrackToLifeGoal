﻿
using LeetCrackToLifeGoal;
using static leetCrack.FindWords;

namespace leetCrack
{

    public class Program
    {
        public int LengthOfLIS(int[] nums)
        {
            var LIS = new int[nums.Length];
            for (int i = 0; i < LIS.Length; i++)
            {
                LIS[i] = 1;
            }

            for (int i = 1; i < nums.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[j] < nums[i] && (LIS[j] + 1 > LIS[i]))
                    {
                        LIS[i] = LIS[j] + 1;
                    }
                }
            }

            var val = 1;
            for (int i = 0; i < LIS.Length; i++)
            {
                if (LIS[i] > val) val = LIS[i];
            }


            return val;
        }

        public int FindNumberOfLIS(int[] nums)
        {

        }

        public static void Main(string[] args)
        {
        }

       
    }
   
}