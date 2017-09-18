namespace AlgorithmProblems
{
    public class TwoNumbers_2
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode root = null;
            ListNode curr = null;
            ListNode curr1 = l1;
            ListNode curr2 = l2;
            var rem = 0;
            while (curr1 != null || curr2 != null)
            {
                var sum = 0;
                if (curr1 != null)
                    sum += curr1.val;
                if (curr2 != null)
                    sum += curr2.val;
                sum += rem;
                rem = sum / 10;
                sum = sum % 10;
                if (root == null)
                {
                    root = new ListNode(sum);
                    curr = root;
                }
                else
                {
                    curr.next = new ListNode(sum);
                    curr = curr.next;
                }
                if (curr1 != null)
                    curr1 = curr1.next;
                if (curr2 != null)
                    curr2 = curr2.next;
            }
            if (rem != 0)
                curr.next = new ListNode(rem);
            return root;
        }
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

    }
}
