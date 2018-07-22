using System;
using System.Collections.Generic;
using System.Linq;
namespace AlgorithmProblems
{
    class RemoveNFromLInkedList_19
    {
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            var curr1 = head;
            var curr2 = head;
            ListNode prevCurr2 = null;
            
            for(var i = 1; i <= n; ++i)
                curr1 = curr1.next;

            if (curr1 == null)
                return curr2.next;

            while (curr1 != null)
            {
                curr1 = curr1.next;
                prevCurr2 = curr2;
                curr2 = curr2.next;
            }
            if (prevCurr2 == null)
                return curr2.next;
            else
            {
                prevCurr2.next = curr2.next;
                return head;
            }
        }
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
    }


}
