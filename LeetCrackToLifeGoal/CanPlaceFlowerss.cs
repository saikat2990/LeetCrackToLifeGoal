using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class CanPlaceFlowerss
    {
        public bool CanPlaceFlowers(int[] flowerbed, int n)
        {
            int pluged = 0;
            if (flowerbed.Length == 1 && flowerbed[0] == 0)
            {
                flowerbed[0] = 1;
                pluged++;
            }



            if (flowerbed.Length >= 2 && flowerbed[flowerbed.Length - 1] == 0 && flowerbed[flowerbed.Length - 2] == 0)
            {
                flowerbed[flowerbed.Length - 1] = 1;
                flowerbed[flowerbed.Length - 2] = -1;
                pluged++;
            }
            if (flowerbed.Length >= 2 && flowerbed[0] == 0 && (flowerbed[1] == 0 || flowerbed[1] == -1))
            {
                flowerbed[0] = 1;
                flowerbed[1] = -1;
                pluged++;
            }

            if (flowerbed.Length > 2)
            {
                for (int i = 2; i < flowerbed.Length - 1; i++)
                {
                    if (flowerbed[i] == 0 && (flowerbed[i - 1] == 0 || flowerbed[i - 1] == -1) &&
                        ((flowerbed[i + 1] == 0 || flowerbed[i + 1] == -1)))
                    {
                        flowerbed[i] = 1;
                        flowerbed[i - 1] = -1;
                        flowerbed[i + 1] = -1;
                        pluged++;
                    }
                }
            }

            if (pluged >= n) return true;
            return false;
        }

    }
}
