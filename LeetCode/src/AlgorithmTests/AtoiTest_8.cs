using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmProblems;

namespace AlgorithmTests
{
    [TestClass]
    public class AtoiTest_8
    {
        [TestMethod]
        public void Atoi()
        {
            var alg = new Atoi_8();

            Assert.AreEqual(1234, alg.MyAtoi("1234"));

            Assert.AreEqual(1234, alg.MyAtoi("+1234"));

            Assert.AreEqual(-1234, alg.MyAtoi("-1234"));

            Assert.AreEqual(Int32.MaxValue, alg.MyAtoi("3434343434343433431234"));

            Assert.AreEqual(1, alg.MyAtoi("1r234"));

            Assert.AreEqual(-2147483648, alg.MyAtoi("-2147483649"));
        }
    }
}
