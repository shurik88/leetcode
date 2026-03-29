using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmProblems.SystemDesign.Quests
{
    /// <summary>
    ///     Q1. Kth Largest Element in a Stream
    /// </summary>
    /// <see cref="https://leetcode.com/problems/kth-largest-element-in-a-stream/description/?envType=problem-list-v2&envId=ssd-ssd2-data-stream-processing"/>
    public class KthLargest
    {
        private readonly PriorityQueue<int, int> _minHeap;
        private readonly int _k;
        public KthLargest(int k, int[] nums)
        {
            _minHeap = new PriorityQueue<int, int>(k);
            _k = k;
            for(var i = 0; i < nums.Length; ++i)
                AddElementAndGetMin(nums[i]);
        }

        private int AddElementAndGetMin(int val)
        {
            if (_minHeap.Count == _k)
            {
                var min = _minHeap.Peek();
                if (min >= val)
                    return min;

                _minHeap.Dequeue();
            }
            _minHeap.Enqueue(val, val);
            return _minHeap.Peek();
        }

        public int Add(int val)
        {
            return AddElementAndGetMin(val);
        }
    }

    /*
     * You are part of a university admissions office and need to keep track of the kth highest test score from applicants in real-time.
     * This helps to determine cut-off marks for interviews and admissions dynamically as new applicants submit their scores.
     * You are tasked to implement a class which, for a given integer k, maintains a stream of test scores and continuously returns the kth highest test score after a new score has been submitted. 
     * More specifically, we are looking for the kth highest score in the sorted list of all scores.
        Implement the KthLargest class:
        KthLargest(int k, int[] nums) Initializes the object with the integer k and the stream of test scores nums.
        int add(int val) Adds a new test score val to the stream and returns the element representing the kth largest element in the pool of test scores so far.
     */
}
