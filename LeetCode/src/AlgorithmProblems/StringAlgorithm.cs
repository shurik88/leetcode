using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmProblems
{
    public class StringAlgorithm
    {
        /// <summary>
        ///     1415. The k-th Lexicographical String of All Happy Strings of Length n
        /// </summary>
        /// <see cref="https://leetcode.com/problems/the-k-th-lexicographical-string-of-all-happy-strings-of-length-n/?envType=daily-question&envId=2026-03-14"/>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public string GetHappyString_1415(int n, int k)
        {
            var curr = 0;
            foreach(var s in GetStrings(n, ""))
            {
                curr++;
                if (curr == k)
                    return s;
            }
            return "";
        }

        private IEnumerable<string> GetStrings(int n, string str)
        {
            if (str.Length == n)
                yield return str;

            else
            {
                var last = str.Length == 0 ? '0' : str[^1];

                if (last == 'b')
                {
                    foreach (var s in GetStrings(n, str + 'a'))
                        yield return s;
                    foreach (var s in GetStrings(n, str + 'c'))
                        yield return s;
                }
                else if (last == 'c')
                {
                    foreach (var s in GetStrings(n, str + 'a'))
                        yield return s;
                    foreach (var s in GetStrings(n, str + 'b'))
                        yield return s;
                }
                else if (last == 'a')
                {
                    foreach (var s in GetStrings(n, str + 'b'))
                        yield return s;
                    foreach (var s in GetStrings(n, str + 'c'))
                        yield return s;
                }
                else
                {
                    foreach (var s in GetStrings(n, str + 'a'))
                        yield return s;
                    foreach (var s in GetStrings(n, str + 'b'))
                        yield return s;
                    foreach (var s in GetStrings(n, str + 'c'))
                        yield return s;
                }
            }
            
        }
    }
}
