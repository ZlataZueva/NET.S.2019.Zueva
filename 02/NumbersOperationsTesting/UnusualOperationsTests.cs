using NUnit.Framework;
using NET.S._2019.Zueva._02;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


}
