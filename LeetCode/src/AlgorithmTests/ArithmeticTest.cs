using AlgorithmProblems.Quests.MathA;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using static AlgorithmProblems.Quests.MathA.Arithmetic;

namespace AlgorithmTests
{
    [TestClass]
    public class ArithmeticTest
    {
        [TestMethod]
        [DataRow(8, 6)]
        [DataRow(4, -1)]
        [DataRow(1, 1)]
        public void PivotInteger(int n, int res)
        {
            var x = -123;
            bool isNegative = false;
            if (x < 0)
                isNegative = true;

            var curr = isNegative ? -x : x;
            var reverse = 0L;
            while (curr != 0)
            {
                var mod = curr % 10;
                curr = curr / 10;
                reverse = reverse * 10 + mod;
            }
            reverse = isNegative ? -reverse : reverse;
            if (reverse > int.MaxValue || reverse < int.MinValue)
            {

            }

            var value = (int)reverse;
            value = isNegative ? -res : res;
            var sut = new Arithmetic();
            sut.PivotInteger(n).Should().Be(res);
        }
    }
}
