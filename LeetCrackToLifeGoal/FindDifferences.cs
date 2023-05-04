using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class FindDifferences
    {
        public IList<IList<int>> FindDifference(int[] nums1, int[] nums2)
        {
            var answer = new List<IList<int>>();
            var commonStore = new List<int>();
            var f1 = nums1.ToList();
            var f2 = nums2.ToList();
            for (int i = 0; i < nums1.Length; i++)
            {
                if (f2.Contains(nums1[i])) commonStore.Add(nums1[i]);
            }

            foreach (int i in commonStore)
            {
                while (f2.Contains(i))
                {
                    f2.Remove(i);
                }
                while (f1.Contains(i))
                {
                    f1.Remove(i);
                }

            }
            answer.Add(f1.Distinct().ToList());
            answer.Add(f2.Distinct().ToList());
            return answer;
        }
    }
}
