

namespace leetCrack
{
   
    public class Program
    {

        public static TreeNode CreateNewNode(TreeNode root)
        {
            var newRoot = new TreeNode(0);
            if (root.right != null)
            {
                newRoot.right = CreateNewNode(root.right);
            }
           

            if (root.left != null)
            {
                newRoot.left = CreateNewNode(root.left);
            }

            return newRoot;
        }

        public static void construct(TreeNode root, TreeNode node, int current, int n, List<TreeNode> ans)
        {
            if (n == 1) root = node;
            if (current + 2 == n)
            {
                node.right = new TreeNode(0);
                node.left = new TreeNode(0);
                var data = CreateNewNode(root);
                ans.Add(data);
                node.right = null;
                node.left = null;
            }
            else if (current < n)
            {

                node.right = new TreeNode(0);
                node.left = new TreeNode(0);
                current += 1;
                construct(root, node.right, current, n, ans);
               
                current += 1;
                
                construct(root, node.left, current, n, ans);
                node.right = null;
                node.left = null;
            }
        }
        public static IList<TreeNode> AllPossibleFBT(int n)
        {
            var answerList = new List<TreeNode>();
            var root = new TreeNode(0);
            var node = new TreeNode(0);
            construct(root, root, 1, n, answerList);
            return answerList;
        }

        public static void Main(string[] args)
        {
            AllPossibleFBT(7);
        }


    }
   
}