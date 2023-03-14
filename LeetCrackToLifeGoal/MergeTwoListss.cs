using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LeetCrackToLifeGoal.MergeKListss;

namespace LeetCrackToLifeGoal
{
    internal class MergeTwoListss
    {
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            if (list1 == null && list2 == null) return null;
            var dataList = new List<int>();
            while (list1 != null)
            {
                dataList.Add(list1.val);
                list1 = list1.next;
            }
            while (list2 != null)
            {
                dataList.Add(list2.val);
                list2 = list2.next;
            }
            dataList.Sort();
            var newData = new ListNode();
            var head = newData;
            for (int i = 0; i < dataList.Count; i++)
            {
                if (i != dataList.Count - 1)
                    newData.next = new ListNode();
                newData.val = dataList[i];
                newData = newData.next;
            }

            return head;

        }
    }
}
