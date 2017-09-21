using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmProblems;

namespace AlgorithmTests
{
    [TestClass]
    public class ReverseNumberTest_7
    {
        [TestMethod]
        public void ReverseNumber()
        {
            var revNumber = new ReverseNumber_7();

            Assert.AreEqual(-321, revNumber.Reverse(-123));

            Assert.AreEqual(1056, revNumber.Reverse(6501));

            Assert.AreEqual(107, revNumber.Reverse(701));

            Assert.AreEqual(-1, revNumber.Reverse(-1000));

            Assert.AreEqual(0, revNumber.Reverse(Int32.MaxValue));

            Assert.AreEqual(0, revNumber.Reverse(Int32.MinValue));
        }
    }
}
