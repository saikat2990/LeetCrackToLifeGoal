using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class TrapRainWaters
    {
        public static int TrapRainWater(int[][] heightMap)
        {

            var answer = 0;
            for (int i = 1; i < heightMap.Length - 1; i++)
            {
                for (int j = 1; j < heightMap[i].Length - 1; j++)
                {
                    var list = new List<int>();
                    list.Add(heightMap[i - 1][j]);
                    list.Add(heightMap[i + 1][j]);
                    list.Add(heightMap[i][j - 1]);
                    list.Add(heightMap[i][j + 1]);
                    list.Sort();
                    if (list[0] > heightMap[i][j])
                    {
                        answer += (list[0] - heightMap[i][j]);
                        heightMap[i][j] += (list[0] - heightMap[i][j]);
                    }
                }
            }
            return answer;
        }
        public int Trap(int[] height)
        {
            int left = 0, right = height.Length;
            int leftMax = 0, rightMax = 0;
            var amount = 0;
            while (left < right)
            {
                if (height[left] <= height[right])
                {
                    if (height[left] < leftMax)
                    {
                        amount += (leftMax - height[left]);
                    }
                    else
                    {
                        leftMax = height[left];
                    }

                    left++;
                }
                else
                {
                    if (height[right] < rightMax)
                    {
                        amount += (rightMax - height[right]);
                    }
                    else
                    {
                        rightMax = height[right];
                    }

                    right--;
                }
            }

            return amount;
        }
        public static IList<int> EventualSafeNodes(int[][] graph)
        {
            var reverseGraph = new List<int>[graph.Length];
            var connectedLinks = new int[graph.Length];
            var answer = new List<int>();

            var queue = new Queue<int>();
            for (int i = 0; i < graph.Length; i++)
            {
                reverseGraph[i] = new List<int>();
            }

            for (int i = 0; i < graph.Length; i++)
            {
                for (int j = 0; j < graph[i].Length; j++)
                {
                    reverseGraph[graph[i][j]].Add(i);
                    connectedLinks[i]++;
                }
            }

            for (int i = 0; i < graph.Length; i++)
            {
                if (connectedLinks[i] == 0) queue.Enqueue(i);
            }

            while (queue.Count > 0)
            {
                var data = queue.Dequeue();
                for (int i = 0; i < reverseGraph[data].Count; i++)
                {
                    connectedLinks[reverseGraph[data][i]]--;
                    if (connectedLinks[reverseGraph[data][i]] == 0)
                        queue.Enqueue(reverseGraph[data][i]);
                }
                answer.Add(data);
            }
            answer.Sort();
            return answer;
        }

        public int LargestVariance(string s)
        {
            var maxVariance = 0;
            for (char a = 'a'; a < 26; a++)
            {
                for (char b = 'a'; b < 26; b++)
                {
                    if (a != b)
                    {
                        var data = kadaneAlgorithm(s, a, b);
                        maxVariance = Math.Max(maxVariance, data);
                    }
                }
            }

            return maxVariance;
        }

        public int kadaneAlgorithm(string s, char a, char b)
        {
            int countA = 0, countB = 0, ans = 0;
            bool isExtenable = false;
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (c != a || c != b) continue;
                if (c == a)
                {
                    countA++;
                }
                else
                {
                    countB++;
                }

                if (countB > 0)
                {
                    ans = Math.Max(ans, countA - countB);
                }
                else if (countB == 0 && isExtenable)
                {
                    ans = Math.Max(ans, countA - 1);
                }

                if (countB > countA)
                {
                    countA = 0;
                    countB = 0;
                    isExtenable = true;
                }
            }

            return ans;
        }


        public int FirstMissingPositive(int[] nums)
        {
            var hashData = new HashSet<int>();
            var minData = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (minData == nums[i])
                {
                    while (hashData.Contains(minData++)) ;
                }
            }

            return minData;
        }

        public int[] getZerosOnes(int[][] board, int ri, int cj)
        {
            var rows = board.Length;
            var cols = board[0].Length;
            var result = new List<int>();
            int[] rowss = new int[] { 1, 0, -1 };
            int[] colss = new int[] { 0, 1, -1 };
            for (int i = 0; i < rowss.Length; i++)
            {
                for (int j = 0; j < colss.Length; j++)
                {
                    if (i != 0 && j != 0)
                    {
                        if (ri + rowss[i] < rows && ri + rowss[i] >= -0 &&
                            cj + colss[j] < cols && cj + colss[j] >= -0)
                        {
                            result.Add(board[ri + rowss[i]][cj + colss[j]]);
                        }
                    }
                }
            }
            return result.ToArray();
        }

        public class indexValue
        {
            public int rowN { get; set; }
            public int colN { get; set; }
            public int val { get; set; }

            public indexValue(int r, int c, int v)
            {
                rowN = r;
                colN = c;
                val = v;
            }
        }

        public void GameOfLife(int[][] board)
        {
            var rows = board.Length;
            var cols = board[0].Length;
            var result = new List<indexValue>();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    var r = getZerosOnes(board, i, j);
                    if (board[i][j] == 0 && r.ToList().Count(x => x == 1) == 3) result.Add(new indexValue(i, j, 1));
                    if (board[i][j] == 1 && r.ToList().Count(x => x == 1) < 2) result.Add(new indexValue(i, j, 0));
                }
            }

            for (int i = 0; i < result.Count; i++)
            {
                board[result[i].rowN][result[i].colN] = result[i].val;
            }
        }
        public static int[] MaxSlidingWindow(int[] nums, int k)
        {
            var answer = new List<int>();
            LinkedList<int> linkedListIndex = new LinkedList<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                while (linkedListIndex.Count > 0 && linkedListIndex.First.Value < i - k + 1)
                    linkedListIndex.RemoveFirst();

                var currentValue = nums[i];
                while (linkedListIndex.Count > 0 && linkedListIndex.Last.Value < currentValue)
                    linkedListIndex.RemoveLast();

                linkedListIndex.AddLast(i);
                if (i >= k - 1)
                    answer.Add(nums[linkedListIndex.First.Value]);

            }

            return answer.ToArray();
        }
        public static void AutomaticSorting()
        {
            var queue = new Queue<int>();
            queue.Enqueue(10);
            queue.Enqueue(1);
            queue.Enqueue(8);
            var a = queue.ToArray().ToList();
            a.Sort();
            a.Reverse();
            queue = new Queue<int>(a);

        }


        public string MinWindow(string s, string t)
        {
            var dict = new Dictionary<char, int>();
            foreach (var ch in t)
            {
                if (!dict.ContainsKey(ch))
                {
                    dict.Add(ch, 0);
                }
                else
                {
                    dict[ch]++;
                }
            }

            var right = 0;
            var left = 0;
            var len = int.MaxValue;
            var count = 0;
            var head = 0;
            while (right < s.Length)
            {
                if (dict.ContainsKey(s[right]))
                {
                    dict[s[right]]--;
                    if (dict[s[right]] == 0)
                    {
                        count++;
                    }
                }

                right++;
                while (count == dict.Count)
                {
                    if (right - left < len)
                    {
                        len = right - left;
                        head = left;
                    }

                    if (dict.ContainsKey(s[left]))
                    {
                        dict[s[left]]++;
                        if (dict[s[left]] > 0)
                            count++;
                    }

                    left++;

                }
            }

            if (len == int.MaxValue) return "";
            return s.Substring(len - head);

        }

        public static int[] ProductExceptSelf(int[] nums)
        {
            var result = new int[nums.Length];
            Array.Clear(result, 0, result.Length);
            var product = 1;
            if (nums.ToList().Any(x => x == 0))
            {
                if (nums.ToList().Where(x => x == 0).ToList().Count() > 1)
                    return result;

                var findIndex = nums.ToList().FindIndex(x => x == 0);

                for (int i = 0; i < nums.Length; i++)
                {
                    if (findIndex != i)
                    {
                        product *= nums[i];
                    }
                }

                result[findIndex] = product;
                return result;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                product *= nums[i];
            }

            for (int i = 0; i < nums.Length; i++)
            {
                result[i] = product / nums[i];
            }
            return result;
        }
    }
}
