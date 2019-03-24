using NUnit.Framework;
using NET.S._2019.Zueva._02;
using System.Collections.Generic;
using System;

namespace NumbersOperationsTesting
{
    [TestFixture]
    public class InsertNumberTests
    {
        [Test]
        public void EqualNumbersZeroRangeInsertNumberTest ()
        {
            //Arrange
            int sourceNumber = 15;
            int inNumber = sourceNumber;
            byte i = 0;
            byte j = i;
            int expectedResult = sourceNumber;


            //Act
            int actualResult = UnusualOperationsWithNumbers.InsertNumber(sourceNumber, inNumber, i, j);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void DifferentNumbersZeroRangeInsertNumberTest()
        {
            //Arrange
            int sourceNumber = 8;
            int inNumber = 15;
            byte i = 0;
            byte j = i;
            int expectedResult = 9;


            //Act
            int actualResult = UnusualOperationsWithNumbers.InsertNumber(sourceNumber, inNumber, i, j);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(15, 8, 1, 3, 1)]
        [TestCase(8, 15, 3, 8,120)]
        public void DifferentNumbersNonZeroRangeInsertNumberTest(int numberSource, int numberIn, byte bitFrom, byte bitTo, int expectedResult)
        { 
            Assert.AreEqual(expectedResult, UnusualOperationsWithNumbers.InsertNumber(numberSource, numberIn, bitFrom, bitTo));
        }

    }

    [TestFixture]
    public class FindNexBiggerNumberTests
    {
        [TestCase(12, 21)]
        [TestCase(513, 531)]
        [TestCase(414, 441)]
        public void SmallNumbersWithOneBiggerNumberTest (int number, int ExpectedResult)
        {
            Assert.AreEqual(ExpectedResult, UnusualOperationsWithNumbers.FindNextBiggerNumber(number));
        }

        [TestCase(2017, 2071)]
        [TestCase(144, 414)]
        [TestCase(1234321, 1241233)]
        [TestCase(1234126, 1234162)]
        [TestCase(3456432, 3462345)]
        public void NumbersWithManyBiggerNumbersTest(int number, int ExpectedResult)
        {
            Assert.AreEqual(ExpectedResult, UnusualOperationsWithNumbers.FindNextBiggerNumber(number));
        }

        [TestCase(10, -1)]
        [TestCase(20, -1)]
        [TestCase(55, -1)]
        [TestCase(711, -1)]
        public void NumbersWithNoBiggerNumbersTest(int number, int ExpectedResult)
        {
            Assert.AreEqual(ExpectedResult, UnusualOperationsWithNumbers.FindNextBiggerNumber(number));
        }
    }

    [TestFixture]
    public class FilterDigitTests
    {
        [TestCase(new int[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 },7, new int[] {7,7,70,17 })]
        public void ListWithTargetNumbersTests (int[] sourceNumberArr, byte digitToFilter, int[] expectedResult)
        {
            List<int> sourceNumberList = new List<int>(sourceNumberArr);
            UnusualOperationsWithNumbers.FilterDigit(sourceNumberList, digitToFilter);
            Assert.AreEqual(new List<int>(expectedResult),sourceNumberList);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 68, 69, 15 }, 7, new int[] { })]
        public void ListWithoutTargetNumbersTests(int[] sourceNumberArr, byte digitToFilter, int[] expectedResult)
        {
            List<int> sourceNumberList = new List<int>(sourceNumberArr);
            UnusualOperationsWithNumbers.FilterDigit(sourceNumberList, digitToFilter);
            Assert.AreEqual(new List<int>(expectedResult), sourceNumberList);
        }
    }

    [TestFixture]
    public class FindNRootTests
    {
        [TestCase(1, 5, 0.0001, 1)]
        [TestCase(8, 3, 0.0001, 2)]
        [TestCase(81, 4, 0.0001, 3)]
        public void FindIntegerRootsTests(double a, int n, double eps, double expectedResult)
        {
            Assert.AreEqual(expectedResult, UnusualOperationsWithNumbers.FindNthRoot(a, n, eps));
        }

        [TestCase(0.001, 3, 0.0001, 0.1)]
        [TestCase(0.04100625, 4, 0.0001, 0.45)]
        [TestCase(0.0279936, 7, 0.0001, 0.6)]
        [TestCase(0.004241979, 9, 0.00000001, 0.545)]
        public void FindRealRootsTests(double a, int n, double eps, double expectedResult)
        {
            Assert.AreEqual(expectedResult, UnusualOperationsWithNumbers.FindNthRoot(a, n, eps));
        }

        [TestCase(-0.008, 3, 0.1, -0.2)]
        [TestCase(-0.0081, 3, 0.1, -0.3)]
        public void FindNegativeRootsTests(double a, int n, double eps, double expectedResult)
        {
            Assert.AreEqual(expectedResult, UnusualOperationsWithNumbers.FindNthRoot(a, n, eps));
        }
    }
}
