using AlgorithmProblems.LinkedList;
using System.Reflection.Metadata.Ecma335;

namespace AlgorithmProblems.Quests.Algorithms
{
    public class LinkedList
    {
        /// <summary>
        /// Q1. Remove Duplicates from Sorted List
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null)
                return head;
            //var curr = head;
            var prev = head;
            var curr = head.next;
            while (curr != null)
            {
                if (curr.val == prev.val)
                {
                    prev.next = curr.next;
                    curr.next = null;
                    curr = prev;
                }
                else
                {
                    prev = curr;
                }
                curr = curr.next;
            }
            return head;
        }

        /// <summary>
        /// Q2. Odd Even Linked List
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode OddEvenList(ListNode head)
        {
            if (head == null)
                return head;

            ListNode headOdd = head;
            var currOdd = headOdd;

            ListNode headEven = head.next;
            var currEven = headEven;

            var curr = currEven?.next;
            var i = 0;
            while(curr != null)
            {
                var node = new ListNode(curr.val);
                if(i % 2 == 0)
                {
                    currOdd.next = node;
                    currOdd = node;
                }
                else
                {
                    currEven.next = node;
                    currEven = node;
                }
                curr = curr.next;
                i++;
            }

            if(headEven != null)
                currOdd.next = headEven;
            if (currEven != null)
                currEven.next = null;

            return headOdd;
        }

        /// <summary>
        /// Q3. Reverse Linked List
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode ReverseList(ListNode head)
        {
            if (head?.next == null)
                return head;

            var tail = new ListNode(head.val);
            var curr = head.next;
            while(curr != null)
            {
                var node = new ListNode(curr.val);
                node.next = tail;
                tail = node;

                curr = curr.next;
            }
            return tail;
        }
    }
}
