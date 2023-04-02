using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class SuccessfulPairss
    {
        public int[] SuccessfulPairs(int[] spells, int[] potions, long success)
        {
            var answer = new List<int>();
            var spellList = spells.ToList();
            var portionList = potions.ToList();
            //spellList.Sort();
            portionList.Sort();
            portionList.Reverse();
            for (int i = 0; i < spellList.Count; i++)
            {
                //time limit
                var l = 0;
                var r = portionList.Count - 1;
                var index = -1;
                while (l <= r)
                {
                    var m = (r + l) / 2;
                    if (((long)spellList[i]) * portionList[m] >= success)
                    {
                        index = m;
                        r = m - 1;
                    }
                    else
                    {
                        l = m + 1;
                    }
                }

                answer.Add(index == -1 ? 0 : index);
            }
            return answer.ToArray();
        }
    }
}
