using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmProblems.Quests.Algorithms
{
    public class MonotonicStack
    {
        /// <summary>
        /// Q1. Final Prices With a Special Discount in a Shop
        /// </summary>
        /// <see cref="https://leetcode.com/problems/final-prices-with-a-special-discount-in-a-shop/?envType=problem-list-v2&envId=dsa-linear-shoal-monotonic-stack"/>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int[] FinalPrices(int[] prices)
        {
            var stack = new Stack<int>();
            for (var i = 0; i < prices.Length; ++i)
            {
                if (stack.Count == 0)
                {
                    stack.Push(i);
                }
                else
                {

                    while (stack.Count != 0)
                    {
                        var prevI = stack.Peek();
                        if (prices[prevI] >= prices[i])
                        {
                            prices[prevI] -= prices[i];
                            stack.Pop();
                        }
                        else
                            break;
                    }
                    stack.Push(i);
                }
            }
            return prices;
        }

        /// <summary>
        ///     Q2. Daily Temperatures
        /// </summary>
        /// <see cref="https://leetcode.com/problems/daily-temperatures/?envType=problem-list-v2&envId=dsa-linear-shoal-monotonic-stack"/>
        /// <param name="temperatures"></param>
        /// <returns></returns>
        public int[] DailyTemperatures(int[] temperatures)
        {
            var stack = new Stack<int>();
            var res = new int[temperatures.Length];
            for (var i = 0; i < temperatures.Length; ++i)
            {
                if (stack.Count != 0)
                {
                    while (stack.Count != 0)
                    {
                        var last = stack.Peek();
                        if (temperatures[last] < temperatures[i])
                        {
                            res[last] = i - last;
                            stack.Pop();
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                stack.Push(i);
            }
            return res;
        }

        /// <summary>
        /// Q3. Largest Rectangle in Histogram
        /// </summary>
        /// <see cref="https://leetcode.com/problems/largest-rectangle-in-histogram/?envType=problem-list-v2&envId=dsa-linear-shoal-monotonic-stack"/>
        /// <param name="heights"></param>
        /// <returns></returns>
        public int LargestRectangleArea(int[] heights)
        {
            //var square = 0;
            //for(var  i = 0; i < heights.Length; i++)
            //{
            //    var height = heights[i];
            //    var count = 1;
            //    for(var j = i + 1; j < heights.Length; ++j)
            //    {
            //        if (heights[j] < height)
            //            break;
            //        count++;
            //    }
            //    for (var j = i -1; j >=0; --j)
            //    {
            //        if (heights[j] < height)
            //            break;
            //        count++;
            //    }
            //    square = Math.Max(square, height * count);
            //}
            //return square;
            var square = 0;
            var stack = new Stack<int>();
            for (var i = 0; i < heights.Length; i++)
            {
                var curr = heights[i];
                while(stack.Count != 0 && heights[stack.Peek()] > curr)
                {
                    var height = heights[stack.Pop()];
                    var width = stack.Count == 0 ? i : (i -  stack.Peek() -1);
                    square = Math.Max(square, width * height);
                }
                stack.Push(i);
            }
            while (stack.Count != 0)
            {
                var height = heights[stack.Pop()];
                var width = stack.Count == 0 ? heights.Length : (heights.Length - stack.Peek() - 1);
                square = Math.Max(square, width * height);
            }
            return square;
        }
    }
}
