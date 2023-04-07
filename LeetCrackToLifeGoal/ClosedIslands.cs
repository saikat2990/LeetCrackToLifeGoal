using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class ClosedIslands
    {
        public void traverAndStoreData(int[][] grid, List<int> zeros, int row, int col, List<(int, int)> valueTuples)
        {
            var rows = grid.Length;
            var cols = grid[0].Length;
            if (rows <= row || cols <= col || row < 0 || col < 0)
            {
                return;
            }
            else
            {
                if (grid[row][col] == 0)
                {
                    zeros.Add(0);
                    valueTuples.Add((row, col));
                    grid[row][col] = -1;
                    traverAndStoreData(grid, zeros, row + 1, col, valueTuples);
                    traverAndStoreData(grid, zeros, row, col + 1, valueTuples);
                    traverAndStoreData(grid, zeros, row - 1, col, valueTuples);
                    traverAndStoreData(grid, zeros, row, col - 1, valueTuples);
                }
            }

            return;
        }

        public int ClosedIsland(int[][] grid)
        {
            var count = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == 0)
                    {
                        var zeros = new List<int>();
                        var indexes = new List<(int, int)>();
                        traverAndStoreData(grid, zeros, i, j, indexes);
                        foreach (var ch in indexes)
                        {
                            if (ch.Item1 == 0 || ch.Item2 == 0 || ch.Item1 == grid.Length - 1 ||
                                ch.Item2 == grid[0].Length - 1)
                            {
                                zeros.Clear();
                                break;
                            }
                        }
                        if (zeros.Count > 0)
                            count++;
                    }
                }
            }

            return count;
        }
    }
}
