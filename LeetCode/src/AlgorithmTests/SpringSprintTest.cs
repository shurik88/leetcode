using AlgorithmProblems.Quests.SpringSprint;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using spring = AlgorithmProblems.Quests.SpringSprint;

namespace AlgorithmTests
{
    [TestClass]
    public class SpringSprintTest
    {
        [TestMethod]
        [DataRow(new int[] { 1, 2, 3, 1 }, 4)]
        [DataRow(new int[] { 2, 7, 9, 3, 1 }, 12)]
        [DataRow(new int[] { 1, 3, 1, 3, 100 }, 103)]
        public void InterviewInstance1_Q3(int[] input, int res)
        {
            var sut = new spring.InterviewInstance1.Q3();
            sut.Rob(input).Should().Be(res);
        }

        [TestMethod]
        [DataRow(new int[] { 10, 6, 8, 5, 11, 9 }, new int[] { 3, 1, 2, 1, 1, 0 })]
        [DataRow(new int[] { 5, 1, 2, 3, 10 }, new int[] { 4, 1, 1, 1, 0 })]
        public void CanSeePersonsCount(int[] heights, int[] res)
        {
            var sut = new Practice3();
            sut.CanSeePersonsCount(heights).Should().BeEquivalentTo(res);
        }

        public void 
    }
}
