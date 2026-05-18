using AlgorithmProblems.LinkedList;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmProblems.Quests.SpringSprint.Week2
{
    public class Challenge2
    {
        /// <summary>
        ///     Q1. Subarray Sum Equals K
        /// </summary>
        /// <see cref="https://leetcode.com/problems/subarray-sum-equals-k/?envType=problem-list-v2&envId=Challenge-II"/>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int SubarraySum(int[] nums, int k)
        {
            var length = nums.Length;
            var total = 0;

            //for(var i = 0; i < length; i++)
            //{
            //    nums[i] = i == 0 ? nums[i] : nums[i - 1] + nums[i];
            //}

            //for(var i = 0; i < length; ++i)
            //{
            //    var prev = i == 0 ? 0 : nums[i - 1];
            //    for (var j = i; j < length; ++j)
            //    {

            //        if (nums[j] - prev == k)
            //            total++;
            //    }
            //}

            var currSum = 0;
            var dict = new Dictionary<int, int> { [0] = 1 };
            for(var i = 0; i < length; ++i)
            {
                currSum+= nums[i];
                if (dict.ContainsKey(currSum - k))
                    total += dict[currSum - k];

                if (!dict.ContainsKey(currSum))
                    dict[currSum] = 1;
                else
                    dict[currSum] += 1;
            }


            return total;
        }

        public ListNode MergeKLists(ListNode[] lists)
        {
            var priority = new PriorityQueue<ListNode, int>();
            for (var i = 0; i < lists.Length; ++i)
            {
                if (lists[i] == null)
                    continue;
                priority.Enqueue(lists[i], lists[i].val);
            }
                

            ListNode head = null;
            ListNode curr = null;
            while(priority.Count !=0)
            {
                var nextMin = priority.Dequeue();
                var newNode = new ListNode(nextMin.val);
                if (nextMin.next != null)
                    priority.Enqueue(nextMin.next, nextMin.next.val);
                if (curr == null)
                {
                    head = newNode;
                    curr = head;
                }
                else
                {
                    curr.next = newNode;
                }
                curr = newNode;
            }
            return head;
        }

        //public int MinOperations(int n)
        //{

        //}
    }
}
