using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class FloodFills
    {
        public static int[][] FloodFill(int[][] image, int sr, int sc, int color)
        {
            var queue = new Queue<(int, int)>();
            queue.Enqueue((sr, sc));
            var startingPixel = image[sr][sc];
            var col = image[0].Length;
            bool[][] isExplore = new bool[image.Length][];
            for (int i = 0; i < isExplore.Length; i++)
            {
                isExplore[i] = new bool[col];
                for (int j = 0; j < isExplore[i].Length; j++)
                {
                    isExplore[i][j] = false;
                }
            }
            ;
            while (queue.Count > 0)
            {
                var rc = queue.Dequeue();
                image[rc.Item1][rc.Item2] = color;
                isExplore[rc.Item1][rc.Item2] = true;
                var rUp = rc.Item1 - 1;
                var rDown = rc.Item1 + 1;
                var cLeft = rc.Item2 - 1;
                var cRight = rc.Item2 + 1;
                if (rUp > -1 && image[rUp][rc.Item2] == startingPixel && !isExplore[rUp][rc.Item2]) queue.Enqueue((rUp, rc.Item2));
                if (rDown < image.Length && image[rDown][rc.Item2] == startingPixel && !isExplore[rDown][rc.Item2]) queue.Enqueue((rDown, rc.Item2));
                if (cLeft > -1 && image[rc.Item1][cLeft] == startingPixel && !isExplore[rc.Item1][cLeft]) queue.Enqueue((rc.Item1, cLeft));
                if (cRight < col && image[rc.Item1][cRight] == startingPixel && !isExplore[rc.Item1][cRight]) queue.Enqueue((rc.Item1, cRight));
            }
            return image;
        }
        // FloodFill(new int[][]{new int[]{0,0,0},new int[] { 0, 0, 0 }},0,0,0 );
    }
}
