using AlgorithmProblems.LinkedList;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO.Pipelines;
using System.Linq.Expressions;
using System.Text;

namespace AlgorithmProblems.Quests.Algorithms
{
    public class SpecificSort
    {
        public int[] QuickSort(int[] arr, IComparer<int> comparer)
        {
            QuickSortInternal(arr, 0, arr.Length - 1, comparer, new Random());
            return arr;
        }

        private static int PartitionArray(int[] arr, int left, int right, IComparer<int> comparer)
        {
            var pivot = arr[right];
            var l = left;
            for (var i = left; i <= right; i++)
            {
                if (comparer.Compare(arr[i], pivot) == -1) //(arr[i] < pivot)
                {
                    (arr[i], arr[l]) = (arr[l], arr[i]);
                    l++;
                }
            }
            (arr[right], arr[l]) = (arr[l], arr[right]);
            return l;
        }

        private static void QuickSortInternal(int[] arr, int left, int right, IComparer<int> comparer, Random rand)
        {
            if (left >= right)
                return;

            var index = rand.Next(left, right + 1);
            (arr[right], arr[index]) = (arr[index], arr[right]);
            var pivotIndex = PartitionArray(arr, left, right, comparer);
            QuickSortInternal(arr, left, pivotIndex - 1, comparer, rand);
            QuickSortInternal(arr, pivotIndex + 1, right, comparer, rand);
        }

        /// <summary>
        ///     Q1. Kth Largest Element in an Array
        /// </summary>
        /// <seealso cref="https://leetcode.com/problems/kth-largest-element-in-an-array/description/?envType=problem-list-v2&envId=dsa-sorting-plateau-counting-sort-merge-sort-quickselect"/>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int FindKthLargest(int[] nums, int k)
        {
            var queue = new PriorityQueue<int, int>(nums.Select(x => (x, x)), new DecendingOrder());
            for (var i = 0; i < k - 1; i++)
                queue.Dequeue();
            return queue.Dequeue();
            if (nums.Length == 1)
                return nums[0];

            (var left, var right) = (0, nums.Length - 1);
            while(true)
            {
                var pivot = nums[right];
                var l = left;
                for (var i = left; i <= right; i++)
                {
                    if (nums[i] > pivot) //(arr[i] < pivot)
                    {
                        (nums[i], nums[l]) = (nums[l], nums[i]);
                        l++;
                    }
                }
                (nums[right], nums[l]) = (nums[l], nums[right]);
                if (l == k - 1)
                    return nums[l];
                else if (l < k - 1)
                    left = l + 1;
                else
                {
                    right = l - 1;
                }
            }
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Q3. Insertion Sort List
        /// </summary>
        /// <see cref="https://leetcode.com/problems/insertion-sort-list/?envType=problem-list-v2&envId=dsa-sorting-plateau-counting-sort-merge-sort-quickselect"/>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode InsertionSortList(ListNode head)
        {
            if (head?.next == null)
                return head;

            var list = new ListNode(head.val);
            var tail = list;
            var curr = head.next;
            while(curr != null)
            {
                var newNode = new ListNode(curr.val);
                var c = list;
                ListNode prev = null;
                while(c != null && c.val <  curr.val)
                {
                    prev = c;
                    c = c.next;

                }
                if(c != curr)
                {
                    if(prev == null)
                    {
                        newNode.next = list;
                        list = newNode;
                    }
                    else
                    {
                        newNode.next = prev.next;
                        prev.next = newNode;
                    }

                }
                else
                {
                    tail.next = newNode;
                    tail = newNode;
                }
                curr = curr.next;
            }
            return list;
        }
    }

    public class AscendingOrder : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return x.CompareTo(y);
        }
    }

    public class DecendingOrder : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return y.CompareTo(x);
        }
    }
}
