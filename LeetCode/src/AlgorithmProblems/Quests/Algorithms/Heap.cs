using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmProblems.Quests.Algorithms
{
    public class Heap
    {
        /// <summary>
        ///     Q1. Last Stone Weight
        /// </summary>
        /// <see cref="https://leetcode.com/problems/last-stone-weight/?envType=problem-list-v2&envId=dsa-sequence-valley-heap"/>
        /// <param name="stones"></param>
        /// <returns></returns>
        public int LastStoneWeight(int[] stones)
        {
            if (stones.Length < 1)
                return stones.Length == 0 ? 0 : stones[0];

            var priorityQueue = new PriorityQueue<int, int>(stones.Length, Comparer<int>.Create((x, y) => y.CompareTo(x)));
            for (var i = 0; i < stones.Length; ++i)
                priorityQueue.Enqueue(stones[i], stones[i]);

            while(priorityQueue.Count > 1)
            {
                var elem1 = priorityQueue.Dequeue();
                var elem2 = priorityQueue.Dequeue();
                var abs = Math.Abs(elem1 - elem2);
                if (abs != 0)
                    priorityQueue.Enqueue(abs, abs);
            }
            return priorityQueue.Count == 0 ? 0 : priorityQueue.Dequeue();
        }

        /// <summary>
        /// Q2. Find K Pairs with Smallest Sums
        /// </summary>
        /// <see cref="https://leetcode.com/problems/find-k-pairs-with-smallest-sums/?envType=problem-list-v2&envId=dsa-sequence-valley-heap"/>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
        {
            var res = new List<IList<int>>();
            var queue = new PriorityQueue<(int, int), int>(k);

            for (var i = 0; i < Math.Min(nums1.Length, k); ++i)
                queue.Enqueue((i, 0), nums1[i] + nums2[0]);

            while(k-- > 0 && queue.Count > 0)
            {
                var (i, j) = queue.Dequeue();
                res.Add([nums1[i], nums2[j]]);
                if (j + 1 < nums2.Length)
                {
                    queue.Enqueue((i, j + 1), nums1[i] + nums2[j + 1]);
                }
            }

            return res;
        }

        /// <summary>
        ///     Q3. Construct Target Array With Multiple Sums
        /// </summary>
        /// <see cref="https://leetcode.com/problems/construct-target-array-with-multiple-sums/?envType=problem-list-v2&envId=dsa-sequence-valley-heap"/>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool IsPossible(int[] target)
        {
            var currSum = 0L;
            var priority = new PriorityQueue<int, int>(target.Length, Comparer<int>.Create((x, y) => y.CompareTo(x)));
            for(var i = 0; i < target.Length; ++i)
            {
                if (target[i] < 1)
                    return false;

                currSum += target[i];
                priority.Enqueue(target[i], target[i]);
            }
            while(priority.Peek() > 1)
            {
                var item = priority.Dequeue();
                var others = currSum - item;
                if (others == 1)
                    return true;
                if (others == 0 || item <= others)
                    return false;
                
                int newItem = (int)(item % others);

                if (newItem == 0)
                    return false;

                currSum = newItem + others;
                priority.Enqueue(newItem, newItem);
            }
            return true;

        }
    }
}
