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


        /// <summary>
        ///     2839. Check if Strings Can be Made Equal With Operations I
        /// </summary>
        /// <see cref="https://leetcode.com/problems/check-if-strings-can-be-made-equal-with-operations-i/?envType=daily-question&envId=2026-03-29"/>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public bool CanBeEqual_2839(string s1, string s2)
        {
            char[] even1 = { s1[0], s1[2] };
            char[] even2 = { s2[0], s2[2] };
            char[] odd1 = { s1[1], s1[3] };
            char[] odd2 = { s2[1], s2[3] };
            Array.Sort(even1);
            Array.Sort(even2);
            Array.Sort(odd1);
            Array.Sort(odd2);
            return even1[0] == even2[0] &&
            even1[1] == even2[1] &&
            odd1[0] == odd2[0] &&
            odd1[1] == odd2[1];
        }

        /// <summary>
        /// 2840. Check if Strings Can be Made Equal With Operations II
        /// </summary>
        /// <see cref="https://leetcode.com/problems/check-if-strings-can-be-made-equal-with-operations-ii/?envType=daily-question&envId=2026-03-30"/>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public bool CheckStrings_2840(string s1, string s2)
        {
            if (s1 == s2)
                return true;

            var even = new int[26]; //исспользуем алгоритм подсчета;
            var odd = new int[26];
            var n = s1.Length;
            for (var i = 0; i < n; ++i)
            {
                if (i % 2 == 0)
                {
                    even[s1[i] - 'a']++;
                }
                else
                {
                    odd[s1[i] - 'a']++;
                }
            }

            for (var i = 0; i < n; ++i)
            {
                if (i % 2 == 0)
                {
                    even[s2[i] - 'a']--;
                }
                else
                {
                    odd[s2[i] - 'a']--;
                }
            }

            for(var i = 0; i < 26; ++i)
            {
                if (even[i] != 0 || odd[i] != 0)
                    return false;
            }
            return true;
        }

        public bool CheckStrings_2840_bad(string s1, string s2)
        {
            var n = s1.Length;
            var even1 = new char[n % 2 == 0 ? n / 2 : n / 2 + 1];
            var even2 = new char[n % 2 == 0 ? n / 2 : n / 2 + 1];
            var odd1 = new char[n / 2];
            var odd2 = new char[n / 2];
            var ie = 0;
            var io = 0;
            for (var i = 0; i < n; ++i)
            {
                if (i % 2 == 0)
                {
                    even1[ie] = s1[i];
                    even2[ie] = s2[i];
                    ie++;
                }
                else
                {
                    odd1[io] = s1[i];
                    odd2[io] = s2[i];
                    io++;
                }
            }
            Array.Sort(even1);
            Array.Sort(even2);
            Array.Sort(odd1);
            Array.Sort(odd2);

            for (var i = 0; i < even1.Length; ++i)
            {
                if (even1[i] != even2[i])
                    return false;
            }
            for (var i = 0; i < odd1.Length; ++i)
            {
                if (odd1[i] != odd2[i])
                    return false;
            }
            return true;
        }

    }
}
