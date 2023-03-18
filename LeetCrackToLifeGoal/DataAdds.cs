using leetCrack;
using static LeetCrackToLifeGoal.MergeKListss;

namespace LeetCrackToLifeGoal
{
    internal class DataAdds
    {
        public TreeNode SortedListToBST(ListNode head)
        {
            if (head == null) return null;
            var data = new List<int>();

            while (head != null)
            {
                data.Add(head.val);
                head = head.next;
            }

            var dividentPoint = (data.Count / 2);
            var root = new TreeNode(data[dividentPoint]);
            var rightHead = new ListNode();
            var rHead = rightHead;

            for (int i = 0; i < dividentPoint; i++)
            {
                rightHead.val = data[i];
                rightHead = rightHead.next;
                if (i != dividentPoint - 1)
                    rightHead = new ListNode();
            }

            var leftHead = new ListNode();
            var lHead = leftHead;

            for (int i = 0; i < data.Count; i++)
            {
                leftHead.val = data[i];
                leftHead = leftHead.next;
                if (i != data.Count - 1)
                    leftHead = new ListNode();
            }

            root.right = SortedListToBST(rHead);
            root.left = SortedListToBST(lHead);

            return root;
        }

    }
}
