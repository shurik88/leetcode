using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmTests
{
    [TestClass]
    public class QuestAlgorithmTests
    {
        [TestMethod]
        [DataRow(new int[] { 1, 1, 0, 0 }, new int[] { 0, 1, 0, 1 }, 0)]
        [DataRow(new int[] { 1, 1, 1, 0, 0, 1 }, new int[] { 1, 0, 0, 0, 1, 1 }, 3)]
        public void CountStudents(int[] students, int[] sandwiches, int count)
        {
            var sut = new AlgorithmProblems.Quests.Algorithms.Queue();
            sut.CountStudents(students, sandwiches).Should().Be(count);
        }

        [TestMethod]
        [DataRow(new int[] { 9, 3, 5 }, true)]
        [DataRow(new int[] { 1, 1, 1, 2 }, false)]
        [DataRow(new int[] { 8, 5 }, true)]
        [DataRow(new int[] { 2, 900000001 }, true)]
        public void IsPossible(int[] target, bool res)
        {
            var sut = new AlgorithmProblems.Quests.Algorithms.Heap();
            sut.IsPossible(target).Should().Be(res);
        }

        [TestMethod]
        [DataRow("5F3Z-2e-9-w", 4, "5F3Z-2E9W")]
        [DataRow("2-5g-3-J", 2, "2-5G-3J")]
        public void LicenseKeyFormatting(string input, int k, string res)
        {
            var sut = new AlgorithmProblems.Quests.Algorithms.String();
            sut.LicenseKeyFormatting(input, k).Should().Be(res);
        }
    }
}
