using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmProblems;
using FluentAssertions;

namespace AlgorithmTests
{
    [TestClass]
    public class RomanNumberTest
    {
        [TestMethod]
        public void NumberToRoman_8()
        {
            var converter = new RomanNumberAlgorithm();

            Assert.AreEqual("XII", converter.IntToRoman_12(12));

            Assert.AreEqual("XXXIX", converter.IntToRoman_12(39));

            Assert.AreEqual("LXIV", converter.IntToRoman_12(64));

            Assert.AreEqual("M", converter.IntToRoman_12(1000));

            Assert.AreEqual("MMXXI", converter.IntToRoman_12(2021));

        }

        [TestMethod]
        [DataRow("III", 3)]
        [DataRow("LVIII", 58)]
        [DataRow("MCMXCIV", 1994)]

        public void RomanToNumber(string roman, int number)
        {
            var sut = new RomanNumberAlgorithm();
            sut.RomanToInt_13(roman).Should().Be(number);
        }
    }
}
