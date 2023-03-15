using leetCrack;

namespace LeetCrackToLifeGoal
{
    internal class SumNumberss
    {
        public void Traverse(TreeNode node, List<List<int>> answer, List<int> current)
        {
            if (node.right == null && node.left == null)
            {
                current.Add(node.val);
                var newCur = new int[current.Count];
                current.CopyTo(newCur);
                answer.Add(newCur.ToList());
                if (current.Count > 0)
                    current.RemoveAt(current.Count - 1);
            }
            else
            {
                current.Add(node.val);
                Traverse(node.right, answer, current);
                Traverse(node.left, answer, current);

            }
        }

        public int SumNumbers(TreeNode root)
        {
            List<List<int>> answer = new List<List<int>>();
            List<int> current = new List<int>();
            Traverse(root, answer, current);
            var data = 0;
            foreach (var eachData in answer)
            {
                var newData = 0;
                for (int i = 0; i < eachData.Count; i++)
                {
                    newData += eachData[i];
                    if (i < eachData.Count - 1)
                    {
                        newData *= 10;
                    }
                }


                data += newData;
            }

            return data;
        }
    }
}
