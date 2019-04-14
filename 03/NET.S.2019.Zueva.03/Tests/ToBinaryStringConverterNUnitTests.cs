// <copyright file="ToBinaryStringConverterNUnitTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Tests
{
    using System;
    using NET.S_2019.Zueva_03;
    using NUnit.Framework;

    [TestFixture]
    public class ToBinaryStringConverterNUnitTests
    {
        [TestCase(-255.255, "1100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(255.255, "0100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(4294967295.0, "0100000111101111111111111111111111111111111000000000000000000000")]
        [TestCase(double.MinValue, "1111111111101111111111111111111111111111111111111111111111111111")]
        [TestCase(double.MaxValue, "0111111111101111111111111111111111111111111111111111111111111111")]
        [TestCase(double.Epsilon, "0000000000000000000000000000000000000000000000000000000000000001")]
        [TestCase(double.NaN, "1111111111111000000000000000000000000000000000000000000000000000")]
        [TestCase(double.NegativeInfinity, "1111111111110000000000000000000000000000000000000000000000000000")]
        [TestCase(double.PositiveInfinity, "0111111111110000000000000000000000000000000000000000000000000000")]
        [TestCase(-0.0, "1000000000000000000000000000000000000000000000000000000000000000")]
        [TestCase(0.0, "0000000000000000000000000000000000000000000000000000000000000000")]
        public void AverageNumbers_BinaryToStringTest(double value, string expectedResult)
        {
            Assert.AreEqual(expectedResult, value.BinaryToString());
        }

        [Test]
        public void Test()
        {
            Assert.AreEqual(2, 2);
        }
    }
}
