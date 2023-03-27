using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class MaxAreas
    {
        public static int MaxArea(int[] height)
        {

            var maxArea = int.MinValue;
            var leftPillar = 0;
            var rightPillar = height.Length - 1;

            maxArea = Math.Min(height[rightPillar], height[leftPillar]) * (rightPillar - leftPillar);
            if (rightPillar == 1) return maxArea;
            while (rightPillar > leftPillar)
            {
                if (height[rightPillar] > height[leftPillar]) leftPillar++;
                else rightPillar--;
                if (rightPillar >= 0 && leftPillar < height.Length)
                {
                    var minPillar = height[leftPillar] < height[rightPillar] ? height[leftPillar] : height[rightPillar];
                    if (minPillar * (rightPillar - leftPillar) > maxArea)
                    {
                        maxArea = minPillar * (rightPillar - leftPillar);
                    }
                }


            }
            return maxArea;
        }

    }
}
