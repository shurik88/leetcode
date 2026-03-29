using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AlgorithmProblems
{
    public class BinaryAlgorithm
    {
        public int NumSteps_1404(string s)
        {
            var res = 0;
            var b = new StringBuilder(s);

            while (b.Length != 1)
            {
                if (b[b.Length - 1] == '1')
                {
                    b[b.Length - 1] = '0';
                    var remain = false;
                    for(var i = b.Length - 2; i >= 0; --i)
                    {
                        if (b[i] == '1')
                        {
                            b[i] = '0';
                            remain = true;
                        }
                        else
                        {
                            b[i] = '1';
                            remain = false;
                            break;
                        }
                    }
                    if(remain)
                    {
                        b.Insert(0, '1');
                    }
                }
                else
                {
                    b.Remove(b.Length - 1, 1);
                }
                res++;
            }

            return res;
        }

        public int ConcatenatedBinary_1680(int n)
        {
            int mod = 1_000_000_007;
            long result = 0;
            int length = 0;
            for (int i = 1; i <= n; ++i)
            {
                if ((i & (i - 1)) == 0)
                {
                    ++length;
                }
                result = ((result << length) | i) % mod;
            }
            return (int)result;
        }

        public char FindKthBit_1545(int n, int k)
        {
            if (n == 1)
            {
                return '0';
            }

            var count = (1 << n) - 1;
            if (k == count)
            {
                return '1';
            }
            if (k == count / 2 + 1)
            {
                return '1';
            }
            if (k - 1 < count / 2)
            {
                return FindKthBit_1545(n - 1, k);
            }
            return FindKthBit_1545(n - 1, count - k + 1) == '0' ? '1' : '0';
        }

        /// <summary>
        ///     Minimum changes to make altering binary string s
        /// </summary>
        /// <see cref="https://leetcode.com/problems/minimum-changes-to-make-alternating-binary-string/description/?envType=daily-question&envId=2026-03-05"/>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MinOperations_1758(string s)
        {
            var leadZeroString = 0;
            var leadOneString = 0;
            for(var i = 0; i < s.Length; ++i)
            {
                var isZero = s[i] == '0';
                if ( i % 2 == 0) //четные
                {
                    if (isZero)
                        leadOneString += 1;
                    else
                        leadZeroString += 1;
                }
                else //нечетные
                {
                    if (isZero)
                        leadZeroString += 1;
                    else
                        leadOneString += 1;

                }
            }

            return leadZeroString <= leadOneString ? leadZeroString : leadOneString;
        }

        /// <summary>
        /// Minimum Number of Flips to Make the Binary String Alternating
        /// </summary>
        /// <see cref="https://leetcode.com/problems/minimum-number-of-flips-to-make-the-binary-string-alternating/?envType=daily-question&envId=2026-03-07"/>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MinFlips_1888(string s)
        {
            if (s.Length <= 1)
                return 0;

            var tmpl = "01";
            var count = 0;

            for (var i = 0; i < s.Length; ++i)
            {
                if (s[i] != tmpl[i & 1])
                {
                    ++count;
                }
            }

            int min = Math.Min(count, s.Length - count);
            if (min == 0)
                return 0;

            for (int i = 0; i < s.Length; ++i)
            {
                if (s[i] != tmpl[i & 1])
                {
                    --count;
                }
                if (s[i] != tmpl[(i + s.Length) & 1])
                {
                    ++count;
                }
                min = Math.Min(min, Math.Min(count, s.Length - count));
            }

            return min;
        }

        /// <summary>
        ///     1784. Check if Binary String Has at Most One Segment of Ones
        /// </summary>
        /// <see cref="https://leetcode.com/problems/check-if-binary-string-has-at-most-one-segment-of-ones/?envType=daily-question&envId=2026-03-06"/>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool CheckOnesSegment_1784(string s)
        {
            var prevOne = false;
            var segmentsCount = 0;
            for (var i = 0; i < s.Length; i++)
            {
                var isOne = s[i] == '1';
                if(!prevOne)
                {
                    if(isOne)
                    {
                        if (segmentsCount == 1)
                            return false;
                        prevOne = true;
                    }
                }
                else
                {
                    if(!isOne)
                    {
                        prevOne = false;
                        segmentsCount++;
                    }
                }
            }
            return segmentsCount <= 1;
        }

        /// <summary>
        ///     1980. Find Unique Binary String
        /// </summary>
        /// <see cref="https://leetcode.com/problems/find-unique-binary-string/?envType=daily-question&envId=2026-03-08"/>
        /// <param name="nums"></param>
        /// <returns></returns>
        public string FindDifferentBinaryString_1980(string[] nums)
        {
            var builder = new StringBuilder();
            for(var i = 0; i < nums.Length; ++i)
            {
                builder.Append(nums[i][i] == '0' ? '1' : '0');
            }
            return builder.ToString();
        }

        public int ComplementofBase10Integer_1009(int n)
        {
            var bitsCount = 0;//(int)Math.Log(n, 2.0) + 1;
            var t = n;
            while (t != 0)
            {
                bitsCount++;
                t >>= 1;
            }
            if (bitsCount == 0)
                bitsCount = 1;
            return (1 << bitsCount) - 1 - n;
        }

        /// <summary>
        ///     1356. Sort Integers by The Number of 1 Bits
        /// </summary>
        /// <see cref="https://leetcode.com/problems/sort-integers-by-the-number-of-1-bits/?envType=daily-question&envId=2026-02-25"/>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int[] SortByBits_1356(int[] arr)
        {
            Array.Sort(arr, new SortByBitComparer());
            return arr;
        }

        public static int CountSetBitsSimple(int n)
        {
            int count = 0;
            while (n != 0)
            {
                // Check if the last bit is a 1
                count += n & 1;
                // Right shift the number by 1 bit
                n >>= 1;
            }
            return count;
        }

        public static int CountSetBitsKernighan(int n)
        {
            int count = 0;
            while (n != 0)
            {
                // Remove the rightmost 1 bit
                n &= (n - 1);
                count++;
            }
            return count;
        }

        private class SortByBitComparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                int xcount = BitOperations.PopCount((uint)x);
                int ycount = BitOperations.PopCount((uint)y);
                return xcount == ycount ? x.CompareTo(y) : xcount.CompareTo(ycount);
            }
        }
    }
}
