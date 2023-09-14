using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class Candy
    {
        public int Candys(int[] ratings)
        {
            var candyList = new int[ratings.Length];
            Array.Fill(candyList, 1);

            for (int i = 1; i < ratings.Length; i++)
            {
                if (ratings[i] > ratings[i - 1])
                {
                    candyList[i] = candyList[i - 1] + 1;
                }
            }

            for (int i = ratings.Length - 2; i >= 0; i--)
            {
                if (ratings[i] > ratings[i + 1])
                {
                    candyList[i] = Math.Max(candyList[i], candyList[i + 1] + 1);
                }
            }


            return candyList.Sum();
        }

    }
}
