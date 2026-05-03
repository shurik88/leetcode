using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmProblems.Quests.MathA
{
    public class Arithmetic
    {
        /// <summary>
        ///     Q2. Find the Pivot Integer
        /// </summary>
        /// <see cref="https://leetcode.com/problems/find-the-pivot-integer/?envType=problem-list-v2&envId=maths-m1-arithmetic-basic-reasoning"/>
        /// <param name="n"></param>
        /// <returns></returns>
        public int PivotInteger(int n)
        {
            if (n == 1)
                return 1;

            var sum = (1 + n) * n / 2;
            var i = n;
            var sumRight = n;
            while (sumRight < (sum - sumRight + i))
            {
                i--;
                sumRight += i;
            }
            return sumRight == (sum - sumRight + i) ? i : -1;
        }
    }
}
