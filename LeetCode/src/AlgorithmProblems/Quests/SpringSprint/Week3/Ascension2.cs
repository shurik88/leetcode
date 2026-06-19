using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmProblems.Quests.SpringSprint.Week3
{
    public class Ascension2
    {
        /// <summary>
        ///     Q1. Max Consecutive Ones III
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int LongestOnes(int[] nums, int k)
        {
            if (nums.Length == 0)
                return 0;

            var max = 0;
            (var left, var right) = (0, 0);
            var ones = nums[left] == 1 ? 1 : 0;
            var zeros = nums[left] == 0 ? 1 : 0;
            while (right < nums.Length)
            {
                var elemsCount = right - left + 1;
                var currLeft = nums[left];

                //расширяем окно
                if(zeros <= k)
                {
                    max = Math.Max(max, ones + zeros);
                    right++;

                }else // смещаем окно
                {
                    left ++;
                    right ++;
                    if (currLeft == 1)
                        ones--;
                    else
                        zeros--;
                }
                if(right < nums.Length)
                {
                    if (nums[right] == 1)
                        ones++;
                    else
                        zeros++;
                }
            }
            return max;

        }

        /// <summary>
        /// Q2. Trapping Rain Water
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int Trap(int[] height)
        {
            if (height == null || height.Length == 0) return 0;

            int left = 0, right = height.Length - 1;
            int leftMax = 0, rightMax = 0;
            int totalWater = 0;

            while (left < right)
            {
                if (height[left] < height[right])
                {
                    if (height[left] >= leftMax)
                    {
                        leftMax = height[left];
                    }
                    else
                    {
                        totalWater += leftMax - height[left];
                    }
                    left++;
                }
                else
                {
                    if (height[right] >= rightMax)
                    {
                        rightMax = height[right];
                    }
                    else
                    {
                        totalWater += rightMax - height[right];
                    }
                    right--;
                }
            }
            return totalWater;
        }
    }
}
