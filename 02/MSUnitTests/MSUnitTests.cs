using Microsoft.VisualStudio.TestTools.UnitTesting;
using NET.S._2019.Zueva._02;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSUnitTests
{
    [TestClass]
    public class InsertNumberTests
    {
        [TestMethod]
        public void EqualNumbersZeroRangeInsertNumberTest()
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

        [TestMethod]
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
    }
}
