using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmProblems
{
    public class Solution_3043
    {
        /// <summary>
        /// 3043. Find the Length of the Longest Common Prefix
        /// </summary>
        /// <see cref="https://leetcode.com/problems/find-the-length-of-the-longest-common-prefix/description/?envType=daily-question&envId=2026-05-21"/>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        /// <returns></returns>
        public int LongestCommonPrefix(int[] arr1, int[] arr2)
        {
            HashSet<int> prefixes = new HashSet<int>();
            static int GetLength(int n)
            {
                if (n < 10) return 1;
                if (n < 100) return 2;
                if (n < 1000) return 3;
                if (n < 10000) return 4;
                if (n < 100000) return 5;
                if (n < 1000000) return 6;
                if (n < 10000000) return 7;
                if (n < 100000000) return 8;
                return 9;
            }
            foreach (var num in arr1)
            {
                var val = num;
                while (val > 0)
                {
                    prefixes.Add(val);
                    val /= 10;
                }
            }
            var max = 0;
            foreach (var num in arr2)
            {
                var val = num;
                while (val > 0)
                {
                    if (prefixes.Contains(val))
                    {
                        var len = GetLength(val); //(int)Math.Floor(Math.Log10(Math.Abs(number)) + 1);
                        max = Math.Max(len, max);
                        break;
                    }
                    val /= 10;
                }
            }
            return max;
        }
    }
}
