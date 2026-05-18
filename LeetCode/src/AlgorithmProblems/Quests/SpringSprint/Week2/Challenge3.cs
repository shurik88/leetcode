using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmProblems.Quests.SpringSprint.Week2
{
    public class Challenge3
    {
        /// <summary>
        ///     Q1 Valid parentheses
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool IsValid(string s)
        {
            var stack = new Stack<char>();
            for (var i = 0; i < s.Length; ++i)
            {
                if (s[i] == '(' || s[i] == '[' || s[i] == '{')
                    stack.Push(s[i]);
                else
                {
                    if (stack.Count == 0)
                        return false;

                    var last = stack.Pop();
                    if (last == '(' && s[i] != ')'
                        || last == '{' && s[i] != '}'
                        || last == '[' && s[i] != ']')
                        return false;
                }
            }
            return stack.Count == 0;
        }

        /// <summary>
        ///     Q2. Remove All Adjacent Duplicates in String II
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public string RemoveDuplicates(string s, int k)
        {
            var stack = new Stack<SymCount>();

            for(var i = 0; i < s.Length; ++i)
            {
                if (stack.Count == 0)
                    stack.Push(new SymCount { Count = 1, Sym = s[i] });
                else
                {
                    var last = stack.Peek();
                    if(last.Sym == s[i])
                    {
                        if (last.Count == k - 1)
                            stack.Pop();
                        else
                            last.Count++;
                    }
                    else
                    {
                        stack.Push(new SymCount { Count = 1, Sym = s[i] });
                    }
                }
            }
            var sb = new StringBuilder();
            while(stack.Count != 0)
            {
                var last = stack.Pop();
                sb.Append(last.Sym, last.Count);
            }
            char[] charArray = new char[sb.Length];
            sb.CopyTo(0, charArray, 0, sb.Length); // Copy to array
            Array.Reverse(charArray);              // Reverse array
            return new string(charArray); // Convert back

        }

        private class SymCount 
        {
            public char Sym { get; set; }

            public int Count { get; set; }
        }

    }
}
