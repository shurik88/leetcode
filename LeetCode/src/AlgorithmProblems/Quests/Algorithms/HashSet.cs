using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmProblems.Quests.Algorithms
{
    public class HashSet
    {
        /// <summary>
        /// Q1. Two Sum
        /// </summary>
        /// <see cref="https://leetcode.com/problems/two-sum/description/?envType=problem-list-v2&envId=dsa-association-slope-hash"/>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum(int[] nums, int target)
        {
            var dict = new Dictionary<int, int>();
            for (var i = 0; i < nums.Length; ++i)
            {
                if (dict.TryGetValue(target - nums[i], out var index))
                {
                    return new int[2] { index, i };
                }
                else
                {
                    dict[nums[i]] = i;
                }
            }
            return Array.Empty<int>();
        }


        public class Node
        {
            public int val;
            public Node next;
            public Node random;

            public Node(int _val)
            {
                val = _val;
                next = null;
                random = null;
            }

            public static Node Create(int[] arr, int[] randLinks)
            {
                Node head = new Node(arr[0]);
                var nodesArr = new Node[arr.Length];
                nodesArr[0] = head;
                var curr = head;
                for (var i = 1; i < arr.Length; ++i)
                {
                    var newNode = new Node(arr[i]);
                    curr.next = newNode;
                    nodesArr[i] = newNode;
                    curr = newNode;
                }
                for (var i = 0; i < randLinks.Length; ++i)
                    if (randLinks[i] != -1)
                        nodesArr[i].random = nodesArr[randLinks[i]];

                return head;
            }
        }

        /// <summary>
        /// Q2. Copy List with Random Pointer
        /// </summary>
        /// <see cref="https://leetcode.com/problems/copy-list-with-random-pointer/description/?envType=problem-list-v2&envId=dsa-association-slope-hash"/>
        /// <param name="head"></param>
        /// <returns></returns>
        public Node CopyRandomList(Node head)
        {
            if (head == null)
                return null;

            Node newHead = null;
            var newNodes = new List<Node>();
            var currNodes = new List<Node>();

            //var reqToMapRandomLinks = new List<Node>();
            var copies = new Dictionary<Node, Node>();

            var newCurr = newHead;
            var curr = head;
            var index = 0;
            var indexesWithRandom = new List<int>();
            while(curr != null)
            {
                var node = new Node(curr.val);
                newNodes.Add(node);
                copies.Add(curr, node);
                currNodes.Add(curr);
                if (curr.random != null)
                {
                    var itemWithRand = curr;
                    indexesWithRandom.Add(index);
                    //reqToMapRandomLinks.Add(itemWithRand);
                }
                if (newHead == null)
                {
                    newHead = node;
                    newCurr = node;
                }
                else
                {
                    newCurr.next = node;
                    newCurr = node;
                }
                
                curr = curr.next;
                index++;
            }

            foreach(var i in indexesWithRandom)
            {
                var newNode = newNodes[i];
                var initNode = currNodes[i];
                newNode.random = copies[initNode.random];
                //copy.random = copies[req.random];
            }
            return newHead;
        }

        /// <summary>
        /// Q3. First Missing Positive
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FirstMissingPositive(int[] nums)
        {
            int n = nums.Length;

            // Step 1: Cyclic Sort - Put each number in its right place
            for (int i = 0; i < n; i++)
            {
                // While the current number is in range [1, n] and not in its correct position
                // (nums[i] should be at index nums[i] - 1)
                while (nums[i] > 0 && nums[i] <= n && nums[nums[i] - 1] != nums[i])
                {
                    (nums[i], nums[nums[i] - 1]) = (nums[nums[i] - 1], nums[i]);
                }
            }

            // Step 2: Identify the first mismatch
            for (int i = 0; i < n; i++)
            {
                if (nums[i] != i + 1)
                {
                    return i + 1;
                }
            }

            // Step 3: If all numbers 1 to n are present, return n + 1
            return n + 1;
        }
    }
}
