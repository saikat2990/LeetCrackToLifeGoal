using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class LastStoneWeights
    {
        public int LastStoneWeight(int[] stones)
        {
            var data = stones.ToList();
            while (data.Count > 1)
            {
                data.Sort();
                data.Reverse();
                data[1] = data[0] - data[1];
                data = data.Skip(1).ToList();
            }
            return data[0];
        }
    }
}
