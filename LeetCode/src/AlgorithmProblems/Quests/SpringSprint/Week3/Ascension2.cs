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
    }
}
