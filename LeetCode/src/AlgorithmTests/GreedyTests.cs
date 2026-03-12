using AlgorithmProblems;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmTests
{
    [TestClass]
    public class GreedyTests
    {
        [TestMethod]
        [DataRow(new int[] { 2, 3, 1, 1, 4 }, 2)]
        [DataRow(new int[] { 2, 1 }, 1)]
        [DataRow(new int[] { 3, 2, 1 }, 1)]
        [DataRow(new int[] { 2, 3, 1 }, 1)]
        [DataRow(new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 1, 0}, 2)]
        public void JumpGame2_45(int[] arr, int res)
        {
            var sut = new GreedyAlgorithm();
            sut.Jump_45(arr).Should().Be(res);
        }
    }
}
