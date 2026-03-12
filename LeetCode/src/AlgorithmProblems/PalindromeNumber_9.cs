using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmProblems
{
    public class PalindromeNumber_9
    {
        public bool IsPalindrome(int x)
        {
            if (x < 0)
                return false;
            if (x == 0)
                return true;

            var curr = x;
            var st = new Stack<int>();
            var queue = new Queue<int>();
            while(curr != 0)
            {
                var mod = curr % 10;
                curr = curr / 10;
                st.Push(mod);
                queue.Enqueue(mod);
            }

            var n = st.Count / 2;
            for(var i = 0; i < n; ++i)
            {
                var q1 = queue.Dequeue();
                var s1 = st.Pop();
                if(s1 != q1)
                    return false;
            }
            return true;
        }

        public bool IsPalindromeBest(int x)
        {
            if (x < 0)
                return false;
            if (x < 10)
                return true;

            var curr = x;
            var reverse = 0;
            while (curr != 0)
            {
                var mod = curr % 10;
                curr = curr / 10;
                reverse = reverse * 10 + mod;
            }
            return reverse == x;
        }
    }
}
