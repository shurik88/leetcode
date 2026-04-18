using AlgorithmProblems;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmTests
{
    [TestClass]
    public class StringsAlgorithmTest
    {
        [TestMethod]
        [DataRow("abe", "bea", false)]
        public void CheckStrings_2840(string s1, string s2, bool res)
        {
            var sut = new StringAlgorithm();
            sut.CheckStrings_2840(s1, s2).Should().Be(res);
        }
    }
}
