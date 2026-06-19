using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmProblems.Quests.SpringSprint.Week3
{
    public class Ascension3
    {
        /// <summary>
        /// Q1. Top K Frequent Elements
        /// </summary>
        /// <see cref="https://leetcode.com/problems/top-k-frequent-elements/description/?envType=problem-list-v2&envId=Ascension-III"/>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] TopKFrequent(int[] nums, int k)
        {
            var res = new int[k];
            var dict = new Dictionary<int, int>();
            for (var i = 0; i < nums.Length; ++i)
                if (dict.TryGetValue(nums[i], out int value))
                    dict[nums[i]] = value + 1;
                else
                    dict[nums[i]] = 1;

            var maxHeap = new PriorityQueue<int, int>(dict.Select(x => (x.Key, -x.Value)));
            for(var i = 0; i < k; ++i)
                res[i] = maxHeap.Dequeue(); 

            return res;
        }

        /// <summary>
        /// Q2. Sliding Window Maximum
        /// </summary>
        /// <see cref="https://leetcode.com/problems/sliding-window-maximum/description/?envType=problem-list-v2&envId=Ascension-III"/>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            if(nums == null || nums.Length == 0 || k <=0)
                return [];

            var res = new int[nums.Length - k + 1];
            var deque = new LinkedList<int>();
            for(var i = 0; i < nums.Length; ++i)
            {
                // 1. Remove indices that are out of the current window range
                if (deque.Count > 0 && deque.First.Value <= i - k)
                {
                    deque.RemoveFirst();
                }
                // 2. Remove indices of elements smaller than the current element
                // (They can never be the maximum again)
                while (deque.Count > 0 && nums[deque.Last.Value] < nums[i])
                {
                    deque.RemoveLast();
                }
                // 3. Add current element's index
                deque.AddLast(i);
                if (i >= k - 1)
                {
                    res[i - k + 1] = nums[deque.First.Value];
                }
            }
            return res;
        }
    }
}
