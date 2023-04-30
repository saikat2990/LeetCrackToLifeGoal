using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class leetcodeContest_4_30_2023_cs
    {
        public static int MaximizeSum(int[] nums, int k)
        {
            Array.Sort(nums);
            Array.Reverse(nums);
            var firstElement = nums[0];
            var sum = firstElement;
            for (int i = 0; i < k - 1; i++)
            {
                sum += (firstElement + i + 1);
            }
            return sum;
        }
        public static int[] FindThePrefixCommonArray(int[] A, int[] B)
        {
            var len = A.Length;
            var result = new int[len];
            for (int i = 0; i < len; i++)
            {
                var count = 0;
                var tempA = (A.Take(i + 1).ToArray());
                Array.Sort(tempA);
                var tempB = (B.Take(i + 1).ToArray());
                Array.Sort(tempB);
                for (int j = 0; j <= i; j++)
                {
                    if (tempA.ToList().Contains(tempB[j])) count++;
                }
                result[i] = count;
            }

            return result;
        }

        public static int traverseWaterLand(int[][] grid, List<int> ans, int r, int c, int num)
        {
            var row = grid.Length;
            var col = grid[0].Length;
            grid[r][c] = 0;
            if (r + 1 < row && grid[r + 1][c] != 0) num += traverseWaterLand(grid, ans, r + 1, c, grid[r + 1][c]);
            if (c + 1 < col && grid[r][c + 1] != 0) num += traverseWaterLand(grid, ans, r, c + 1, grid[r][c + 1]);
            if (r - 1 >= 0 && grid[r - 1][c] != 0) num += traverseWaterLand(grid, ans, r - 1, c, grid[r - 1][c]);
            if (c - 1 >= 0 && grid[r][c - 1] != 0) num += traverseWaterLand(grid, ans, r, c - 1, grid[r][c - 1]);
            return num;
        }

        public static int FindMaxFish(int[][] grid)
        {
            var row = grid.Length;
            var col = grid[0].Length;
            var ans = new List<int>();
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (grid[i][j] != 0)
                    {
                        ans.Add(traverseWaterLand(grid, ans, i, j, grid[i][j]));
                    }
                }
            }
            ans.Sort();
            ans.Reverse();
            if (ans.Count == 0) return 0;
            return ans[0];
        }
        public static long CountOperationsToEmptyArray(int[] nums)
        {
            var forSort = new int[nums.Length];
            nums.CopyTo(forSort, 0);
            Array.Sort(forSort);
            var list = nums.ToList();
            long count = 0;
            while (list.Count > 0)
            {
                if (list[0] == forSort[0])
                {
                    list = list.Skip(1).ToList();
                    forSort = forSort.ToList().Skip(1).ToArray();
                }
                else
                {
                    var element = list[0];
                    list = list.Skip(1).ToList();
                    list.Add(element);
                }

                count++;
            }
            return count;
        }

    }
}
