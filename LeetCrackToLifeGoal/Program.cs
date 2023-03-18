namespace leetCrack
{

    public class Program
    {
        /**
  * Definition for a binary tree node.
  * public class TreeNode {
  *     public int val;
  *     public TreeNode left;
  *     public TreeNode right;
  *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
  *         this.val = val;
  *         this.left = left;
  *         this.right = right;
  *     }
  * }
  */
        public class Solution
        {

            public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
            {
                var levelList = new Dictionary<int, List<int>>();
                var answer = new List<IList<int>>();
                if (root == null) return answer;
                Queue<TreeNode> data = new Queue<TreeNode>();
                var tag = 0;
                data.Enqueue(root);

                while (data.Count > 0)
                {

                    levelList.Add(tag, new List<int>());
                    var listData = new List<TreeNode>();
                    while (data.Count > 0)
                    {
                        var chData = data.Dequeue();
                        levelList[tag].Add(chData.val);
                        listData.Add(chData);
                    }

                    var reVerseData = new List<TreeNode>();
                    for (int i = listData.Count - 1; i >= 0; i--)
                    {
                        reVerseData.Add(listData[i]);
                    }
                    listData.Clear();
                    foreach (var rData in reVerseData)
                    {
                        listData.Add(rData);
                    }
                    if (tag % 2 == 1)
                    {
                        foreach (var lData in listData)
                        {
                            if (lData.left != null) data.Enqueue(lData.left);
                            if (lData.right != null) data.Enqueue(lData.right);

                        }
                    }
                    else
                    {
                        foreach (var lData in listData)
                        {
                            if (lData.right != null) data.Enqueue(lData.right);
                            if (lData.left != null) data.Enqueue(lData.left);


                        }
                    }
                    tag++;
                }
                foreach (var ll in levelList.Keys)
                {

                    foreach (var VARIABLE in levelList[ll])
                    {
                        Console.Write(VARIABLE + " ");
                    }
                    Console.WriteLine();
                    answer.Add(levelList[ll]);
                }

                return answer;
            }
        }
        public static void Main(string[] args)
        {

         
        }


    }
   
}