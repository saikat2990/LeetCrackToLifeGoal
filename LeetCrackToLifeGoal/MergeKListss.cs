using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    public class MergeKListss
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists.Length == 0) return null;
            var newNode = new ListNode();
            var ansNode = newNode;
            var data = new List<int>();
            foreach (var node in lists)
            {
                var tempNode = node;
                while (tempNode != null)
                {
                    data.Add(tempNode.val);
                    tempNode = tempNode.next;
                }
            }

            if (data.Count == 0) return null;
            data.Sort();
            for (int i = 0; i < data.Count; i++)
            {
                newNode.val = data[i];
                if (i != data.Count - 1)
                    newNode.next = new ListNode();
                newNode = newNode.next;
            }
            return ansNode;
        }

    }
}
