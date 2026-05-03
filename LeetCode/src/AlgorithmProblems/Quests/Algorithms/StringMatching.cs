using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmProblems.Quests.Algorithms
{
    public class StringMatching
    {
        /// <summary>
        ///     Q1. Repeated Substring Pattern
        /// </summary>
        /// <see cref="https://leetcode.com/problems/repeated-substring-pattern/description/?envType=problem-list-v2&envId=dsa-sequence-valley-string-matching"/>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool RepeatedSubstringPattern(string s)
        {
            var length = s.Length;
            for (var count = 1; count <= length / 2; ++count)
            {
                if (length % count != 0)
                    continue;
                var match = true;
                for (var i = 0; i < length - count; i ++)
                {
                    if (s[i] != s[i + count])
                    {
                        match = false;
                        break;
                    }
                }
                if (match)
                    return true;
            }
            return false;
        }

        /// <summary>
        ///     Q2. Rotate string
        /// </summary>
        /// <see cref="https://leetcode.com/problems/rotate-string/?envType=problem-list-v2&envId=dsa-sequence-valley-string-matching"/>
        /// <param name="s"></param>
        /// <param name="goal"></param>
        /// <returns></returns>
        public bool RotateString(string s, string goal)
        {
            if (s.Length != goal.Length)
                return false;

            return (s + s).Contains(goal);
        }

        /// <summary>
        ///     Q3. Repeated string match
        /// </summary>
        /// <see cref="https://leetcode.com/problems/repeated-string-match/?envType=problem-list-v2&envId=dsa-sequence-valley-string-matching"/>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int RepeatedStringMatch(string a, string b)
        {
            var builder = new StringBuilder(a);
            var count = 1;
            while(builder.Length < b.Length)
            {
                builder.Append(a);
                count++;
            }

            if (builder.ToString().Contains(b))
                return count;

            builder.Append(a);
            return builder.ToString().Contains(b) ? count + 1 : -1;
        }
    }
}
