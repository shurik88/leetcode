using System;

namespace AlgorithmProblems
{
    public class MedianOfSortedArrays_4
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var viewedCount = 0;
            var index1 = 0;
            var index2 = 0;
            var total = nums1.Length + nums2.Length;
            var prev = 0;
            while (viewedCount < total / 2)
            {
                viewedCount++;
                if (index1 == nums1.Length)
                {
                    prev = nums2[index2];
                    index2++;
                    continue;
                }
                if (index2 == nums2.Length)
                {
                    prev = nums1[index1];
                    index1++;
                    continue;
                }
                var n1 = nums1[index1];
                var n2 = nums2[index2];
                if (n1 < n2)
                {
                    prev = nums1[index1];
                    index1++;
                }
                else
                {
                    prev = nums2[index2];
                    index2++;
                }

            }
            var next = index1 == nums1.Length
                ? nums2[index2]
                : index2 == nums2.Length
                    ? nums1[index1]
                    : nums1[index1] < nums2[index2]
                            ? nums1[index1]
                            : nums2[index2];

            return total % 2 == 0 ? (next + prev) / 2.0 : next;
            //int m = nums1.Length;
            //int n = nums2.Length;
            //if (m > n)
            //{ // to ensure m<=n
            //    int[] temp = nums1; nums1 = nums2; nums2 = temp;
            //    int tmp = m; m = n; n = tmp;
            //}
            //int iMin = 0, iMax = m, halfLen = (m + n + 1) / 2;
            //while (iMin <= iMax)
            //{
            //    int i = (iMin + iMax) / 2;
            //    int j = halfLen - i;
            //    if (i < iMax && nums2[j - 1] > nums1[i])
            //    {
            //        iMin = iMin + 1; // i is too small
            //    }
            //    else if (i > iMin && nums1[i - 1] > nums2[j])
            //    {
            //        iMax = iMax - 1; // i is too big
            //    }
            //    else
            //    { // i is perfect
            //        int maxLeft = 0;
            //        if (i == 0) { maxLeft = nums2[j - 1]; }
            //        else if (j == 0) { maxLeft = nums1[i - 1]; }
            //        else { maxLeft = Math.Max(nums1[i - 1], nums2[j - 1]); }
            //        if ((m + n) % 2 == 1) { return maxLeft; }

            //        int minRight = 0;
            //        if (i == m) { minRight = nums2[j]; }
            //        else if (j == n) { minRight = nums1[i]; }
            //        else { minRight = Math.Min(nums2[j], nums1[i]); }

            //        return (maxLeft + minRight) / 2.0;
            //    }
            //}
            //return 0.0;
        }
    }
}
