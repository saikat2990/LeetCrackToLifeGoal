using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LeetCrackToLifeGoal.MergeKListss;

namespace LeetCrackToLifeGoal
{
    internal class DeleteDuplicatess
    {
        public ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null) return head;
            var listElements = new List<int>();
            var prev = head;
            var next = head.next;

            while (next != null)
            {

                if (prev.val == next.val)
                {
                    listElements.Add(next.val);
                }
                prev = next;
                next = next.next;
            }

            prev = head;
            next = head.next;
            while (prev != null && listElements.Contains(prev.val))
            {
                prev = prev.next;
            }
            head = prev;
            if (prev != null)
            {
                next = prev.next;
                while (next != null)
                {
                    if (listElements.Contains(next.val))
                    {
                        while (next != null && listElements.Contains(next.val))
                        {
                            next = next.next;
                        }

                        prev.next = next;
                    }
                    prev = next;
                    if (next != null) next = next.next;
                }

            }

            return head;
        }
    }
}
