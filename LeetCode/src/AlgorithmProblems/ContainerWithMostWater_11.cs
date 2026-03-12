using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmProblems
{
    public class ContainerWithMostWater_11
    {
        public int MaxArea(int[] height)
        {
            var max = 0;
            var left = 0;
            var right = height.Length - 1;
            while(left < right)
            {
                var square = right - left;
                if (height[left] < height[right])
                {
                    square *= height[left];
                    left++;
                }
                else
                {
                    square *= height[right];
                    right--;
                }
                if(square > max)
                    max = square;
            }
            return max;
        }
        public int MaxAreaBad(int[] height)
        {
            var max = 0;
            for (var i = 0; i < height.Length; ++i)
            {
                for (var j = i + 1; j < height.Length; ++j)
                {
                    var square = (j - i) * Math.Min(height[i], height[j]);
                    if (square > max)
                    {
                        max = square;
                    }
                }
            }
            return max;
        }
    }
}
