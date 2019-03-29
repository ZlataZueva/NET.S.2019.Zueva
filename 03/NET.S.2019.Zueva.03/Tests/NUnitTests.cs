﻿using System;
using NUnit.Framework;
using NET.S._2019.Zueva._03;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class NUnitTests
    {
        [TestCase(new int[] {1,0,5,15,25}, 1)]
        [TestCase(new int[] { 0,0,0,0}, 0)]
        [TestCase(new int[] { 0, 7, 21, 84}, 7)]
        public void ZeroContainingSequences_GCDEuclidTests (int[] numbers, int expectedResult)
        {
            Assert.AreEqual(expectedResult, GCDFinder.FindGCDwithEuclid(numbers));
        }

        [TestCase(new int[] { -5, -10, 5, 15, 25 }, 5)]
        [TestCase(new int[] {-12, 12, 24, -6}, 6)]
        [TestCase(new int[] { -24, -72, -48}, 24)]
        public void NegativeContainingSequences_GCDEuclidTests(int[] numbers, int expectedResult)
        {
            Assert.AreEqual(expectedResult, GCDFinder.FindGCDwithEuclid(numbers));
        }

        [Test]
        public void ArgumentNullException_GCDEuclidTest()
        {
            Assert.Throws<ArgumentNullException>(()=> { GCDFinder.FindGCDwithEuclid(null); });
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] {7})]
        [TestCase(9)]
        public void NotEnoughNumbers_GCDEuclidTest(int[] numbers)
        {
            Assert.Throws<ArgumentException>(() => { GCDFinder.FindGCDwithEuclid(numbers); });
        }


        [TestCase(new int[] { 1, 0, 5, 15, 25 }, 1)]
        [TestCase(new int[] { 0, 0, 0, 0 }, 0)]
        [TestCase(new int[] { 0, 7, 21, 84 }, 7)]
        public void ZeroContainingSequences_GCDSteinTests(int[] numbers, int expectedResult)
        {
            Assert.AreEqual(expectedResult, GCDFinder.FindGCDwithStein(numbers));
        }

        [TestCase(new int[] { -5, -10, 5, 15, 25 }, 5)]
        [TestCase(new int[] { -12, 12, 24, -6 }, 6)]
        [TestCase(new int[] { -24, -72, -48 }, 24)]
        public void NegativeContainingSequences_GCDSteinTests(int[] numbers, int expectedResult)
        {
            Assert.AreEqual(expectedResult, GCDFinder.FindGCDwithStein(numbers));
        }

        [Test]
        public void ArgumentNullException_GCDSteinTest()
        {
            Assert.Throws<ArgumentNullException>(() => { GCDFinder.FindGCDwithStein(null); });
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 7 })]
        [TestCase(9)]
        public void NotEnoughNumbers_GCDSteinTest(int[] numbers)
        {
            Assert.Throws<ArgumentException>(() => { GCDFinder.FindGCDwithStein(numbers); });
        }
    }
}
