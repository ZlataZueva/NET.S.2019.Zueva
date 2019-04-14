// <copyright file="PolynomialTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Tests
{
    using NET.S_2019.Zueva_04;
    using NUnit.Framework;

    [TestFixture]
    public class PolynomialTests
    {
        [TestCase(new double[] { 1.0, 0, 3, 0 }, new double[] { 3, 2, 0 }, new double[] { 3.0, 2.0, 9.0, 6.0, 0, 0 })]
        [TestCase(new double[] { 0, 5, 7 }, new double[] { 9 }, new double[] { 45, 63 })]
        [TestCase(new double[] { 2, 0, 0, 1, 3 }, new double[] { 1, 0 }, new double[] { 2, 0, 0, 1, 3, 0 })]
        public void PolynomialsMultiplyTest(double[] polymonToMultiply1, double[] polynomToMultiply2, double[] expectedResult)
        {
            Assert.AreEqual(new Polynomial(expectedResult), new Polynomial(polymonToMultiply1) * new Polynomial(polynomToMultiply2));
        }

        [TestCase(new double[] { 1.0, 0, 3, 0 }, new double[] { 3, 2, 0 }, new double[] { 1, 3, 5, 0 })]
        [TestCase(new double[] { 0, 5, 7 }, new double[] { 9 }, new double[] { 5, 16 })]
        [TestCase(new double[] { 2, 0, 0, 1, 3 }, new double[] { 1, 0 }, new double[] { 2, 0, 0, 2, 3 })]
        public void PolynomialsSumTest(double[] polynomToSum1, double[] polynomToSum2, double[] expectedResult)
        {
            Assert.AreEqual(new Polynomial(expectedResult), new Polynomial(polynomToSum1) + new Polynomial(polynomToSum2));
        }

        [TestCase(new double[] { 1.0, 0, 3, 0 }, new double[] { 3, 2, 0 }, new double[] { 1, -3, 1, 0 })]
        [TestCase(new double[] { 0, 5, 7 }, new double[] { 9 }, new double[] { 5, -2 })]
        [TestCase(new double[] { 2, 0, 0, 1, 3 }, new double[] { 1, 0 }, new double[] { 2, 0, 0, 0, 3 })]
        public void PolynomialsSubstractTest(double[] polynomToSubstract1, double[] polynomToSubstract2, double[] expectedResult)
        {
            Assert.AreEqual(new Polynomial(expectedResult), new Polynomial(polynomToSubstract1) - new Polynomial(polynomToSubstract2));
        }

        [TestCase(new double[] { 1.0, 0, 3, 0 }, new double[] { 1.0, 0, 3, 0 }, true)]
        [TestCase(new double[] { 0, 5, 7 }, new double[] { 9 }, false)]
        [TestCase(new double[] { 2, 0, 0, 1, 3 }, new double[] { 0, 2, 0, 0, 1, 3 }, true)]
        public void PolynomialsEqualTest(double[] polynomToCompare1, double[] polynomToCompare2, bool expectedResult)
        {
            Assert.AreEqual(expectedResult, new Polynomial(polynomToCompare1) == new Polynomial(polynomToCompare2));
        }

        [TestCase(new double[] { 1.0, 0, 3, 0 }, new double[] { 1.0, 0, 3, 0 }, false)]
        [TestCase(new double[] { 0, 5, 7 }, new double[] { 9 }, true)]
        [TestCase(new double[] { 2, 0, 0, 1, 3 }, new double[] { 0, 2, 0, 0, 1, 3 }, false)]
        public void PolynomialsNotEqualTest(double[] polynomToCompare1, double[] polynomToCompare2, bool expectedResult)
        {
            Assert.AreEqual(expectedResult, new Polynomial(polynomToCompare1) != new Polynomial(polynomToCompare2));
        }

        [TestCase(new double[] { 1.0, 0, 3, 0 }, "X^3 + 3X")]
        [TestCase(new double[] { 0, 5, 7 }, "5X + 7")]
        [TestCase(new double[] { -2, 0, -1, 0 }, "- 2X^3 - X")]
        [TestCase(new double[] { -1 }, "- 1")]
        [TestCase(new double[] { 2 }, "2")]
        public void PolynomialToStringTest(double[] polynom, string expectedResult)
        {
            Assert.AreEqual(expectedResult, new Polynomial(polynom).ToString());
        }
    }
}
