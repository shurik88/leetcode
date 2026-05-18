using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmProblems
{
    public class BinarySearchAlgorithm
    {
        /// <summary>
        ///     153. Find Minimum in Rotated Sorted Array
        /// </summary>
        /// <see cref="https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/description/?envType=daily-question&envId=2026-05-15"/>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindMin_153(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                throw new ArgumentException(nameof(nums), "required at least one element");
            if (nums.Length == 0)
                return nums[0];

            var min = int.MaxValue;
            var left = 0;
            var right = nums.Length - 1;
            while(left < right)
            {
                var mid = left + (right-left) / 2;
                if (nums[mid] <= nums[right] && nums[left] <= nums[mid])
                    return Math.Min(min, nums[left]);
                else if (nums[mid] <= nums[right])
                {
                    min = Math.Min(min, nums[mid]);
                    right = mid - 1;
                }
                else
                {
                    min = Math.Min(min, nums[left]);
                    left = mid + 1;
                }
            }
            return Math.Min(nums[left], min);
        }

        /// <summary>
        /// 154. Find Minimum in Rotated Sorted Array II
        /// </summary>
        /// <see cref="https://leetcode.com/problems/find-minimum-in-rotated-sorted-array-ii/description/?envType=daily-question&envId=2026-05-16"/>
        /// <param name="nums"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public int FindMin_154(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                throw new ArgumentException(nameof(nums), "required at least one element");
            if (nums.Length == 0)
                return nums[0];

            var min = int.MaxValue;
            var left = 0;
            var right = nums.Length - 1;
            while (left < right)
            {
                var mid = left + (right - left) / 2;
                if (nums[mid] == nums[left] && nums[mid] == nums[right])
                {
                    min = Math.Min(nums[mid], min);
                    left += 1;
                    right -= 1;
                }
                else if (nums[mid] < nums[right] && nums[left] < nums[mid])
                    return Math.Min(min, nums[left]);
                else if (nums[mid] <= nums[right])
                {
                    min = Math.Min(min, nums[mid]);
                    right = mid - 1;
                }
                else
                {
                    min = Math.Min(min, nums[left]);
                    left = mid + 1;
                }
            }
            return Math.Min(nums[left], min);
        }
    }
}
