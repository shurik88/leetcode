using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmProblems.Quests.SpringSprint
{
    public class Practice3
    {
        /// <summary>
        ///     Q1. Best Time to Buy and Sell Stock
        /// </summary>
        /// <see cref="https://leetcode.com/problems/best-time-to-buy-and-sell-stock/?envType=problem-list-v2&envId=Practice-III"/>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxProfit(int[] prices)
        {
            if (prices.Length < 2)
                return 0;

            var minPrice = int.MaxValue;
            var maxProfit = 0;
            foreach(var price in prices)
            {
                if (price < minPrice)
                    minPrice = price;
                else if (price - minPrice > maxProfit)
                    maxProfit = price - minPrice;
            }
            return maxProfit;

            //var count = prices.Length;
            //int[] indices = [.. Enumerable.Range(0, count)];
            //Array.Sort(prices, indices);

            //var profit = 0;

            //var left = 0;
            //var right = prices.Length - 1;
            //while(left < right)
            //{
            //    var leftIndex = indices[left];
            //    var rightIndex = indices[right];
            //}

            //return profit;
        }

        ///// <summary>
        /////     Q2. Course schedule
        ///// </summary>
        ///// <see cref="https://leetcode.com/problems/course-schedule/description/?envType=problem-list-v2&envId=Practice-III"/>
        ///// <param name="numCourses"></param>
        ///// <param name="prerequisites"></param>
        ///// <returns></returns>
        //public bool CanFinish(int numCourses, int[][] prerequisites)
        //{

        //}

        /// <summary>
        ///     Q3. Number of Visible People in a Queue
        /// </summary>
        /// <see cref="https://leetcode.com/problems/number-of-visible-people-in-a-queue/description/?envType=problem-list-v2&envId=Practice-III"/>
        /// <param name="heights"></param>
        /// <returns></returns>
        public int[] CanSeePersonsCount(int[] heights)
        {
            var res = new int[heights.Length];
            if (heights.Length < 2)
                return res;

            var stack = new Stack<int>();
            stack.Push(heights[heights.Length - 1]);
            //var temp = 
            for(var i = heights.Length - 2; i >= 0; --i)
            {
                var count = 0;
                var elem = heights[i];
                while(stack.Count > 0 && elem > stack.Peek())
                {
                    stack.Pop();
                    count++;
                }
                if (stack.Count > 0)
                    count++;
                //var temp = new Stack<int>(stack.Count);
                //while(stack.Count != 0)
                //{
                //    var item = stack.Pop();
                //    count++;
                //    if(item > elem)
                //    {
                //        temp.Push(item);
                //        break;
                //    }
                //    else
                //    {
                //        //break;
                //    }
                //}
                //while (temp.Count != 0)
                //    stack.Push(temp.Pop());

                res[i] = count;
                stack.Push(elem);

            }
            return res;
        }
    }
}
