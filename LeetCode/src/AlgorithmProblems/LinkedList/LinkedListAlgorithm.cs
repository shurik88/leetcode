using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmProblems.LinkedList
{
    public class LinkedListAlgorithm
    {
        public ListNode MergeTwoLists_21(ListNode list1, ListNode list2)
        {
            ListNode head = null;
            ListNode curr = null;
            var curr1 = list1;
            var curr2 = list2;
            while(curr1 != null || curr2 != null)
            {
                var val = 0;
                if (curr2 == null || (curr1 != null && curr1.val <= curr2.val))
                {
                    val = curr1.val;
                    curr1 = curr1.next;

                }
                else
                {
                    val = curr2.val;
                    curr2 = curr2.next;
                }
                var node = new ListNode(val);
                if (head == null)
                {
                    head = node;
                    curr = head;
                }
                else
                {
                    curr.next = node;
                    curr = curr.next;
                }

            }
            return head;
        }

        //public ListNode SwapPairs_24(ListNode head)
        //{
        //    if (head == null || head.next == null)
        //        return head;

        //    ListNode head1 = null;
        //    ListNode curr = head;
        //    while(curr!= null)
        //    {
        //        if(head1 == null)
        //        {
        //            head1 = curr;
        //            if(curr.next != null)

        //        }
        //    }
        //    return head1;
        //}

        public ListNode DeleteDuplicates_82(ListNode head)
        {
            var curr = head;
            
            while(curr != null)
            {
                if(curr != head)
                curr = curr.next;
            }
            return head;
        }
    }
}
