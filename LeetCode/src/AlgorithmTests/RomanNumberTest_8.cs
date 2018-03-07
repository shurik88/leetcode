using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmProblems;

namespace AlgorithmTests
{
    [TestClass]
    public class RomanNumberTest_8
    {
        [TestMethod]
        public void RomanNumber()
        {
            var converter = new RomanNumber_12();

            Assert.AreEqual("XII", converter.IntToRoman(12));

            Assert.AreEqual("XXXIX", converter.IntToRoman(39));

            Assert.AreEqual("LXIV", converter.IntToRoman(64));

            Assert.AreEqual("M", converter.IntToRoman(1000));

            Assert.AreEqual("MMXXI", converter.IntToRoman(2021));

        }
    }
}
