using NUnit.Framework;
using NET.S._2019.Zueva._02;
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

        [Test]
        public void DifferentNumbersNonZeroRangeInsertNumberTest()
        {
            //Arrange
            int sourceNumber = 15;
            int inNumber = 8;
            byte i = 1;
            byte j = 3;
            int expectedResult = 1;


            //Act
            int actualResult = UnusualOperationsWithNumbers.InsertNumber(sourceNumber, inNumber, i, j);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
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
}
