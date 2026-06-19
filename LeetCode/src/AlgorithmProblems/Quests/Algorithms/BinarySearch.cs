using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmProblems.Quests.Algorithms
{
    public class BinarySearch
    {
        /// <summary>
        ///     Q1. Peak Index in a Mountain Array
        /// </summary>
        /// <see cref="https://leetcode.com/problems/peak-index-in-a-mountain-array/description/?envType=problem-list-v2&envId=dsa-sorting-plateau-binary-search"/>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int PeakIndexInMountainArray(int[] arr)
        {
            (var left, var right) = (0, arr.Length - 1);
            var peak = 0;
            while (left <= right)
            {
                var mid = (right + left) / 2;
                if (arr[mid - 1] < arr[mid] && arr[mid + 1] < arr[mid])
                    return mid;
                else if (arr[mid] > arr[mid - 1])
                {
                    left = mid;
                }
                else
                {
                    right = mid;
                }
            }
            return peak;
        }

        /// <summary>
        /// Q2. Binary Search
        /// </summary>
        /// <see cref="https://leetcode.com/problems/binary-search/description/?envType=problem-list-v2&envId=dsa-sorting-plateau-binary-search"/>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int Search(int[] nums, int target)
        {
            (var left, var right) = (0, nums.Length - 1);
            while (left <= right)
            {
                var mid = (left + right) / 2;
                if (nums[mid] == target)
                    return mid;
                else if (nums[mid] > target)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return -1;
        }

        /// <summary>
        ///     Q3. Sum of Square Numbers
        /// </summary>
        /// <see cref="https://leetcode.com/problems/sum-of-square-numbers/description/?envType=problem-list-v2&envId=dsa-sorting-plateau-binary-search"/>
        /// <param name="c"></param>
        /// <returns></returns>
        public bool JudgeSquareSum(int c)
        {
            (var left, var right) = (0L, (long)Math.Sqrt(c));
            while (left <= right)
            {
                var sum = left * left + right * right;
                if (c == sum)
                {
                    return true;
                }
                else if (sum < c)
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }
            return false;
        }

        /// <summary>
        /// Q4. Search in Rotated Sorted Array
        /// </summary>
        /// <see cref="https://leetcode.com/problems/search-in-rotated-sorted-array/description/?envType=problem-list-v2&envId=dsa-sorting-plateau-binary-search"/>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int SearchRotated(int[] nums, int target)
        {
            (var left, var right) = (0, nums.Length - 1);
            while (left < right)
            {
                var mid = left + (right - left) / 2;
                if (nums[mid] == target)
                    return mid;
                else if (nums[left] <= nums[mid])
                {
                    if (nums[left] <= target && nums[mid] > target)
                        right = mid - 1;
                    else
                        left = mid + 1;
                }
                else
                {
                    if (nums[right] >= target && nums[mid] < target)
                        left = mid + 1;
                    else
                        right = mid - 1;
                }
            }
            return nums[left] == target ? left : -1;
        }
    }
}
