using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class CoinChanges
    {
        public int CoinChange(int[] coins, int amount)
        {
            var totalArray = new int[amount + 1];
            Array.Fill(totalArray, amount + 1);
            for (int i = 0; i <= amount; i++)
            {
                for (int j = 0; j < coins.Length; j++)
                {
                    if (i >= coins[i])
                        totalArray[i] = Math.Min(coins[i - coins[i]] + 1, coins[i]);
                }
            }
            return totalArray[amount] > amount ? -1 : totalArray[amount];

        }
    }
}
