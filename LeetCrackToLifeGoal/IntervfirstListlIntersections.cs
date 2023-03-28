using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class IntervfirstListlIntersections
    {
        public int[][] IntervfirstListlIntersection(int[][] firstList, int[][] secondList)
        {
            int lenA = firstList.Length;
            int lenB = secondList.Length;
            List<int[]> result = new List<int[]>();
            int iA = 0, iB = 0;
            while (iA < lenA && iB < lenB)
            {
                if (firstList[iA][0] >= secondList[iB][0] && firstList[iA][0] <= secondList[iB][1] ||
                    secondList[iB][0] >= firstList[iA][0] && secondList[iB][0] <= firstList[iA][1])
                    result.Add(new int[] { Math.Max(firstList[iA][0], secondList[iB][0]),
                        Math.Min(firstList[iA][1], secondList[iB][1]) });
                if (firstList[iA][1] < secondList[iB][1])
                    iA++;
                else
                    iB++;
            }
            return result.ToArray();
        }

    }
}
