using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmProblems.LinkedList
{
    public class Solution_61
    {
        public ListNode RotateRight(ListNode head, int k)
        {
            if (k == 0 || head == null || head.next == null)
                return head;

            var count = 1;
            var oldTail = head;
            while(oldTail.next != null)
            {
                count++;
                oldTail = oldTail.next;
            }

            k %= count;
            if (k == 0)
                return head;

            oldTail.next = head;

            var newTail = head;
            for(var i = 0; i < count - k - 1; i++)
            {
                newTail = newTail.next;
            }

            var newHead = newTail.next;
            newTail.next = null;
            return newHead;
        }
    }
}
