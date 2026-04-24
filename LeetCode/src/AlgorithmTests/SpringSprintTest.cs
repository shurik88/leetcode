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
    }
}
