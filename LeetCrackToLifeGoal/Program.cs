
using LeetCrackToLifeGoal;
using static leetCrack.FindWords;

namespace leetCrack
{

    public class Program
    {
        public static int MaxNumEdgesToRemove(int n, int[][] edges)
        {
            UnionFind ufAlice = new UnionFind(n);
            UnionFind ufBob = new UnionFind(n);
            bool[] aliceAll = new bool[n];
            bool[] bobAll = new bool[n];
            var count = 0;
            for (int i = 0; i < edges.Length; i++)
            {
                if (edges[i][0] == 1)
                {
                    if (ufAlice.Find(edges[i][1]-1) == ufAlice.Find(edges[i][2]-1))
                    {
                        count++;
                    }
                    else
                    {
                        ufAlice.Union(edges[i][1]-1, edges[i][2] - 1);
                        aliceAll[edges[i][1] - 1] = true;
                        aliceAll[edges[i][2] - 1] = true;
                    }

                   
                }
                if (edges[i][0] == 2)
                {
                    if (ufBob.Find(edges[i][1]-1) == ufBob.Find(edges[i][2] - 1))
                    {
                        count++;
                    }
                    else
                    {
                        ufBob.Union(edges[i][1] - 1, edges[i][2] - 1);
                        bobAll[edges[i][1] - 1] = true;
                        bobAll[edges[i][2] - 1] = true;
                    }
                  
                }
                if (edges[i][0] == 3)
                {
                    if (ufAlice.Find(edges[i][1] - 1) == ufAlice.Find(edges[i][2] - 1) && ufBob.Find(edges[i][1] - 1) == ufBob.Find(edges[i][2] - 1))
                    {
                        count++;
                    }
                    else
                    {
                        ufAlice.Union(edges[i][1] - 1, edges[i][2] - 1);
                        ufBob.Union(edges[i][1] - 1, edges[i][2] - 1);
                        aliceAll[edges[i][1] - 1] = true;
                        aliceAll[edges[i][2] - 1] = true;
                        bobAll[edges[i][1] - 1] = true;
                        bobAll[edges[i][2] - 1] = true;
                    }
                   
                }
            }

            for (int i = 0; i < n; i++)
            {
                if (!aliceAll[i] || !bobAll[i]) return -1;
            }

            return count;
        }
        public static void Main(string[] args)
        {
            MaxNumEdgesToRemove(4, new int[6][]
            {
                new[] { 3, 1, 2 }, new[] { 3, 2, 3 }, new[] { 1, 1, 3 }, new[] { 1, 2, 4 }, new[] { 1, 1, 2 },
                new[] { 2, 3, 4 }
            });
        }

      
    }
   
}