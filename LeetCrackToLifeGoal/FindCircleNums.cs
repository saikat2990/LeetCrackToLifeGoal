using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class FindCircleNums
    {
        public void TraverseAndFinds(int[][] isConnected, int row)
        {
            for (int i = 0; i < isConnected[row].Length; i++)
            {
                if (isConnected[row][i] == 1)
                {
                    isConnected[row][i] = 0;
                    isConnected[i][row] = 0;
                    TraverseAndFinds(isConnected, i);
                }
            }
        }

        public int FindCircleNum(int[][] isConnected)
        {
            var discreate = 0;
            for (int i = 0; i < isConnected.Length; i++)
            {
                for (int j = 0; j < isConnected[i].Length; j++)
                {
                    if (isConnected[i][j] == 1)
                    {
                        discreate++;
                        isConnected[j][i] = 0;
                        isConnected[i][j] = 0;
                        TraverseAndFinds(isConnected, j);
                    }
                }
            }
            return discreate;
        }
    }
}
