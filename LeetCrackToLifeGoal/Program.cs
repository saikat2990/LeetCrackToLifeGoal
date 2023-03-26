﻿

using System.Linq;
using static LeetCrackToLifeGoal.MergeKListss;

namespace leetCrack
{

    public class Program
    {

        public int FindMin(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;
            var left = 0;
            var right = nums.Length - 1;
            var mid = 0;
            while (left<right)
            {
                mid = left + (right - left) / 2;
                if (nums[mid] < nums[right])
                {
                    right = mid;
                }
                else
                {
                    left = mid+1;
                }
            }
            return nums[left];
        }
        public int FindPeakElement(int[] nums)
        {
            if (nums.Length == 1) return 0;
            if (nums[0] > nums[1]) return 0;
            if (nums[nums.Length - 1] > nums[nums.Length-2])return nums.Length-1;

            for (int i = 1; i < nums.Length-1; i++)
            {
                if (nums[i - 1] < nums[i] && nums[i + 1] < nums[i]) 
                    return i;
            }

            return -1;
        }
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
        public static void Main(string[] args)
        {


        }

       
    }
   
}