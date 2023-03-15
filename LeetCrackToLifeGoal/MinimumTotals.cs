using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class MinimumTotals
    {
        public int MinimumTotal(IList<IList<int>> triangle)
        {
            var row = triangle.Count;
            var index = 0;
            var sum = 0;
            for (int i = 1; i < triangle.Count; i++)
            {
                for (int j = 0; j < triangle[i].Count; j++)
                {
                    if (j == 0)
                    {
                        triangle[i][j] = triangle[i - 1][j] + triangle[i][j];
                    }
                    else if (j == triangle[i].Count - 1)
                    {
                        triangle[i][j] = triangle[i - 1][j - 1] + triangle[i][j];
                    }
                    else
                    {
                        triangle[i][j] = Math.Min((triangle[i - 1][j - 1] + triangle[i][j]),
                            (triangle[i - 1][j] + triangle[i][j]));
                    }

                }

            }

            var data = triangle[triangle.Count - 1][0];
            for (int i = 1; i < triangle[triangle.Count - 1].Count; i++)
            {
                if (data > triangle[triangle.Count - 1][i])
                {
                    data = triangle[triangle.Count - 1][i];
                }
            }
            return data;
        }
    }
}
