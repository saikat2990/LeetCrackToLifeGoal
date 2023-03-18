using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LeetCrackToLifeGoal.MergeKListss;

namespace LeetCrackToLifeGoal
{
    internal class RemoveNthFromEnds
    {
        public ListNode ReverseNode(ListNode head)
        {
            ListNode rest = null;
            while (head != null)
            {
                rest = new ListNode(head.val, rest);
                head = head.next;
            }

            return rest;
        }

        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {

            var reverseNode = ReverseNode(head);
            if (n == 1) return ReverseNode(reverseNode.next);
            var it = 0;
            head = reverseNode;
            ListNode Head = head;
            ListNode previousNode = head;
            while (it < n)
            {
                previousNode = head;
                head = head.next;
                it++;
            }
            previousNode.next = head.next;

            return ReverseNode(Head);
        }
    }
}

