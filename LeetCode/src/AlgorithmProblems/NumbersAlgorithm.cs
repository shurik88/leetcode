using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmProblems
{
    public class NumbersAlgorithm
    {
        public int MinPartitions_1689(string n)
        {
            var max = 0;
            for (var i = 0; i < n.Length; ++i)
            {
                var x = n[i] - '0';
                if (x > max)
                {
                    max = x;
                }
            }
            return max;
        }

        /// <summary>
        ///     Divide two numbers without divide, mul, mod
        /// </summary>
        /// <see cref="https://leetcode.com/problems/divide-two-integers/description/"/>
        /// <param name="dividend"></param>
        /// <param name="divisor"></param>
        /// <returns></returns>
        public int Divide_29(int dividend, int divisor)
        {
            if (dividend == 0)
                return 0;
            var signPlus = dividend > 0 && divisor > 0 || dividend < 0 && divisor < 0;
            var d1 = dividend > 0 ? dividend : 0-dividend;
            var d2 = divisor > 0 ? divisor : 0-divisor;

            var res = 0;
            while (d1 >= d2)
            {
                d1 -= d2;
                if (res == int.MaxValue)
                    return int.MaxValue;
                res++;
            }
            return signPlus ? res : 0-res;
        }
    }
}
