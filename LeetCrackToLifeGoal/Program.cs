
using LeetCrackToLifeGoal;
using static leetCrack.FindWords;

namespace leetCrack
{

    public class Program
    {
        public void Traverse(char[][] board, List<List<int>> data, bool[][] isVisited,int row,int col)
        {
            isVisited[row][col] = true;
            var m = board.Length;
            var n = board[0].Length;
            if (data.Count == 0)
            {
                return;
            }

            if (row == m - 1 || col == n -1)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    isVisited[data[i][0]][data[i][1]] = false;
                }
                data.Clear();
                return;
            }
            if (row - 1 >= 0 && board[row - 1][col] == 'O' && isVisited[row - 1][col] == false)
            {
                var l = new List<int>();
                l.Add(row - 1);
                l.Add(col);
                data.Add(l);
                Traverse(board,data,isVisited,row-1,col);
            }
            if (row + 1 <m && board[row + 1][col] == 'O' && isVisited[row + 1][col] == false)
            {
                var l = new List<int>();
                l.Add(row + 1);
                l.Add(col);
                data.Add(l);
                Traverse(board, data, isVisited, row + 1, col);
            }
            if (col - 1 >= 0 && board[row][col-1] == 'O' && isVisited[row][col-1] == false)
            {
                var l = new List<int>();
                l.Add(row);
                l.Add(col - 1);
                data.Add(l);
                Traverse(board, data, isVisited, row, col-1);
            }
            if (col+1 <n && board[row][col+1] == 'O' && isVisited[row][col+1] == false)
            {
                var l = new List<int>();
                l.Add(row);
                l.Add(col + 1);
                data.Add(l);
                Traverse(board, data, isVisited, row, col+1);
            }
        }

        public void Solve(char[][] board)
        {
            var m = board.Length;
            var n = board[0].Length;
            var isVisited = new bool[m][];
            for (int j = 0; j < m; j++)
            {
                isVisited[j] = new bool[n];
            }

            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    if (board[i][j] == 'O' && (board[i - 1][j]=='x' || board[i + 1][j]=='x' || board[i][j-1]=='X' || board[i][j+1]=='X'))
                    {
                        var data = new List<List<int>>();
                        var l = new List<int>();
                        l.Add(i);
                        l.Add(j);
                        data.Add(l);
                        Traverse(board, data, isVisited, i, j);
                        Console.WriteLine(data.Count);
                        if (data.Count > 1)
                        {
                            var tag = true;
                            foreach (var t in data)
                            {
                                if (t[0] == 0 || t[1] == 0 || t[0] == m - 1 || t[1] == n - 1)
                                {
                                    tag= false;
                                    break;
                                }
                            }

                            if (tag)
                            {
                                foreach (var t in data)
                                {

                                    board[t[0]][t[1]] = 'X';
                                }
                            }

                           
                        }

                        
                    }


                }
            }
        }
        public static void Main(string[] args)
        {
        }

       
    }
   
}