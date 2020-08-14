using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeProblems
{
    [TestFixture]
    public class AddStringNumberTests
    {       
        [Test]
        public void Verify_WithSingleDigitNumbers()
        {
            var sum = "10";             
            Assert.AreEqual(sum , KaratsubaMultiplication.Add("5", "5"));

            sum = "0";
            Assert.AreEqual(sum, KaratsubaMultiplication.Add("0", "0"));

            sum = "1";
            Assert.AreEqual(sum, KaratsubaMultiplication.Add("0", "1"));
        }

        [Test]
        public void Verify_WithDoubleDigitNumbers()
        {
            var sum = "30";
            Assert.AreEqual(sum, KaratsubaMultiplication.Add("15", "15"));

            sum = "29";
            Assert.AreEqual(sum, KaratsubaMultiplication.Add("10", "19"));

            sum = "69";
            Assert.AreEqual(sum, KaratsubaMultiplication.Add("29", "40"));
        }
    }
}
