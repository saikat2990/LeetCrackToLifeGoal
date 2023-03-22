using leetCrack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    public class Road
    {
        public int symbol;
        public int distance;
    }

    internal class MinScores
    {
        public static int MinScore(int n, int[][] roads)
        {

            var connection = new Dictionary<int, Queue<Road>>();
            for (int i = 0; i < roads.Length; i++)
            {
                var data = roads[i];

                if (connection.ContainsKey(data[0]))
                {
                    connection[data[0]].Enqueue(new Road() { symbol = data[1], distance = data[2] });
                }
                else
                {
                    connection[data[0]] = new Queue<Road>();
                    connection[data[0]].Enqueue(new Road() { symbol = data[1], distance = data[2] });
                }
                if (connection.ContainsKey(data[1]))
                {
                    connection[data[1]].Enqueue(new Road() { symbol = data[0], distance = data[2] });
                }
                else
                {
                    connection[data[1]] = new Queue<Road>();
                    connection[data[1]].Enqueue(new Road() { symbol = data[0], distance = data[2] });
                }
            }

            var answer = new List<int>();
            DFS(connection, 1, answer, n);

            return answer[0];
        }

        private static void DFS(Dictionary<int, Queue<Road>> connection, int roadNum, List<int> answer, int n)
        {
            var roadQ = connection[roadNum];

            while (roadQ.Count > 0)
            {
                var road = roadQ.Dequeue();
                var next = road.symbol;

                if (connection.ContainsKey(next) && connection[next].Count > 0)
                {
                    if (answer.Count == 0)
                        answer.Add(road.distance);
                    else if (answer[0] > road.distance)
                    {
                        answer[0] = road.distance;
                    }

                    DFS(connection, road.symbol, answer, n);
                }
            }
        }
    }
}
