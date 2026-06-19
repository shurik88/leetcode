using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmProblems.LinkedList
{
    public class ListNode
    {
        public int val;

        public ListNode next;

        public ListNode(int x) { val = x; }

        public static ListNode Create(int[] arr)
        {
            ListNode head = new ListNode(arr[0]);
            var curr = head;
            for(var  i =1; i < arr.Length; ++i)
            {
                var newNode = new ListNode(arr[i]);
                curr.next = newNode;
                curr = newNode;
            }
            return head;
        }

        public int[] GetNumbers()
        {
            var curr = this;
            var list = new List<int> {  };
            while(curr != null)
            {
                var val = curr.val;
                list.Add(val);
                curr = curr.next;
            }
            return list.ToArray();
        }
    }
}
