using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmProblems
{
    public class Generate_Parentheses_22
    {
        public IList<string> GenerateParenthesis(int n)
        {
            var res = new List<string>();

            var queue = new Queue<Parenthesis>();
            queue.Enqueue(new Parenthesis(n, n, ""));
            while (queue.Count > 0)
            {
                var curr = queue.Dequeue();
                if (curr.RemainOpen == 0)
                    res.Add(curr.Prefix + new string(')', curr.RemainClose));
                else
                {
                    queue.Enqueue(new Parenthesis(curr.RemainOpen - 1, curr.RemainClose, curr.Prefix + "("));
                    if(curr.RemainClose > curr.RemainOpen)
                        queue.Enqueue(new Parenthesis(curr.RemainOpen, curr.RemainClose - 1, curr.Prefix + ")"));
                }
            }


            return res;
        }

        public IList<string> GenerateParenthesis3(int n)
        {
            List<string> res = new List<string>();
            string stack = "";
            Backtrack(0, 0, n, res, stack);
            return res;
        }

        public void Backtrack(int openN, int closedN, int n, List<string> res, string stack)
        {
            if (openN == closedN && openN == n)
            {
                res.Add(stack);
                return;
            }

            if (openN < n)
            {
                Backtrack(openN + 1, closedN, n, res, stack + '(');
            }

            if (closedN < openN)
            {
                Backtrack(openN, closedN + 1, n, res, stack + ')');
            }
        }

        public IList<string> GenerateParenthesis2(int n)
        {
            var res = new List<BitArray>();

            var queue = new Queue<ParenthesisCompact>();
            queue.Enqueue(new ParenthesisCompact(n, n, new BitArray(2 * n)));
            while (queue.Count > 0)
            {
                var curr = queue.Dequeue();
                if (curr.RemainOpen == 0)
                    res.Add(curr.Parenthesis);
                else
                {
                    var withOpen = new BitArray(curr.Parenthesis);
                    withOpen.Set(2 * n - curr.RemainClose - curr.RemainOpen, true);
                    queue.Enqueue(new ParenthesisCompact(curr.RemainOpen - 1, curr.RemainClose, withOpen));
                    if (curr.RemainClose > curr.RemainOpen)
                    {
                        var withClose = new BitArray(curr.Parenthesis);
                        queue.Enqueue(new ParenthesisCompact(curr.RemainOpen, curr.RemainClose - 1, withClose));
                    }
                }
            }


            return res.Select(x => string.Join("", Enumerable.Range(0, n).Select(y => x[y] ? "(" : ")"))).ToList();
        }

        public struct ParenthesisCompact
        {
            public int RemainOpen { get; set; }

            public int RemainClose { get; set; }

            public BitArray Parenthesis { get; set; }
            public ParenthesisCompact(int open, int close, BitArray parenthesis)
            {
               RemainClose = close;
               RemainOpen = open;
               Parenthesis = parenthesis;
            }
        }

        public struct Parenthesis
        {
            public int RemainOpen { get; set; }

            public int RemainClose { get; set; }

            public string Prefix { get; set; }
            public Parenthesis(int open, int close, string prefix)
            {
                Prefix = prefix;
                RemainOpen = open;
                RemainClose = close;
            }
        }
    }
}
