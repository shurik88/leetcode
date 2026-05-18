using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace AlgorithmProblems.Quests.SpringSprint.Week3
{
    public class Ascension1
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            //if (nums1.Length == 0)
            //    return nums2.Length % 2 != 0 ? nums2[nums2.Length / 2] 
            //        : (nums2[nums2.Length / 2] + nums2[nums2.Length / 2 - 1]) / 2.0;
            //if (nums2.Length == 0)
            //    return nums1.Length % 2 != 0 ? nums1[nums1.Length / 2]
            //        : (nums1[nums1.Length / 2] + nums1[nums1.Length / 2 - 1]) / 2.0;
            //if (nums2.Length < nums1.Length && nums2.Length != 1)
            //    (nums1, nums2) = (nums2, nums1);

            //(var m, var n) = (nums1.Length, nums2.Length);
            //var half = m + (n - m) / 2;
            //(var left, var right) = (0, m - 1);
            //while(true)
            //{
            //    var l1Index = (left + right) / 2;
            //    var l2Index = half - (l1Index + 1) - 1;
            //    var l1 = l1Index < 0 ? int.MinValue : nums1[l1Index];
            //    var r1 = l1Index >= m - 1 ? int.MaxValue : nums1[l1Index + 1];
            //    var l2 = l2Index < 0 ? int.MinValue : nums2[l2Index];
            //    var r2 = l2Index >= n - 1 ? int.MaxValue : nums2[l2Index + 1];

            //    if (l1 > r2)
            //        right = l1Index - 1;
            //    else if (l2 > r1)
            //    {
            //        left = l1Index + 1;
            //    }
            //    else
            //    {
            //        if ((m + n) % 2 == 0)
            //            return (Math.Max(l1, l2) + Math.Min(r1, r2)) / 2.0;
            //        else
            //            return Math.Min(r1, r2);
            //    }
            //}
            if (nums1.Length > nums2.Length)
            {
                return FindMedianSortedArrays(nums2, nums1);
            }

            int m = nums1.Length;
            int n = nums2.Length;
            int low = 0, high = m;

            while (low <= high)
            {
                int partitionX = (low + high) / 2;
                int partitionY = (m + n + 1) / 2 - partitionX;

                // If partitionX is 0, there is nothing on the left side. Use -INF.
                // If partitionX is m, there is nothing on the right side. Use +INF.
                int maxLeftX = (partitionX == 0) ? int.MinValue : nums1[partitionX - 1];
                int minRightX = (partitionX == m) ? int.MaxValue : nums1[partitionX];

                int maxLeftY = (partitionY == 0) ? int.MinValue : nums2[partitionY - 1];
                int minRightY = (partitionY == n) ? int.MaxValue : nums2[partitionY];

                if (maxLeftX <= minRightY && maxLeftY <= minRightX)
                {
                    // Correct partition found
                    if ((m + n) % 2 == 0)
                    {
                        return (Math.Max(maxLeftX, maxLeftY) + Math.Min(minRightX, minRightY)) / 2.0;
                    }
                    else
                    {
                        return Math.Max(maxLeftX, maxLeftY);
                    }
                }
                else if (maxLeftX > minRightY)
                {
                    // Too far right in nums1, move left
                    high = partitionX - 1;
                }
                else
                {
                    // Too far left in nums1, move right
                    low = partitionX + 1;
                }
            }
            throw new ArgumentException("Input arrays are not sorted.");
        }

        /// <summary>
        ///     Q3. Group Anagrams
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var groups = new Dictionary<string, List<string>>();
            for(var i = 0; i < strs.Length; i++)
            {
                var charArray = strs[i].ToCharArray();
                Array.Sort(charArray);
                var str = new string(charArray);
                if(!groups.ContainsKey(str))
                {
                    groups[str] = new List<string>();
                }
                groups[str].Add(strs[i]);

            }
            return groups.Values.Cast<IList<string>>().ToList();
            //var codes = new short[strs.Length, 26];
            //for(var i = 0; i < strs.Length; i++)
            //{
            //    for (var j = 0; j < strs[i].Length; j++)
            //        codes[i, strs[i][j] - 'a']++;
            //}
            //var comparer = new AnagramComparer(codes, strs);
            //return Enumerable.Range(0, strs.Length).GroupBy(x => x, comparer).Select(x => x.Select(y => strs[y]).ToList() as IList<string>).ToList();

        }

        private class AnagramComparer(short[,] codes, string[] strs) : IEqualityComparer<int>
        {
            public bool Equals(int x, int y)
            {
                if (strs[x].Length != strs[y].Length)
                    return false;

                for (var i = 0; i < codes.GetLength(1); ++i)
                    if (codes[x, i] != codes[y, i])
                        return false;
                return true;
            }

            public int GetHashCode([DisallowNull] int obj)
            {
                return strs[obj].Length;
            }
        }
    }
}
