using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class MaxScores
    {
        public void IndexCreateList(int currentIndex1, int currentIndex2, List<int> currentIndexList, List<List<int>> indexList, int n)
        {
            if (currentIndex1 == n || currentIndex2 == n) return;
            if (currentIndex2 == n - 1) indexList.Add(currentIndexList);
            currentIndexList.Add(currentIndex1);
            currentIndexList.Add(currentIndex2);
            IndexCreateList(currentIndex1, currentIndex2 + 1, currentIndexList, indexList, n);
            currentIndexList.RemoveAt(currentIndexList.Count - 1);
            currentIndexList.RemoveAt(currentIndexList.Count - 1);
            IndexCreateList(currentIndex1 + 1, currentIndex2 + 2, currentIndexList, indexList, n);
        }

        public void MaxScore(int[] nums1, int[] nums2, int k)
        {
            List<List<int>> indexList = new List<List<int>>();
            var n = nums1.Length;
            for (int i = 0; i < n; i++)
            {
                var newCurrentList = new List<int>();
                newCurrentList.Add(i);
                IndexCreateList(i + 1, i + 2, newCurrentList, indexList, n);
            }
        }
    }
}
