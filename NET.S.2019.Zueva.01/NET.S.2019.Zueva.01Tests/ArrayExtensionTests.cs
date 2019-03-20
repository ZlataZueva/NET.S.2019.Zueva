using Microsoft.VisualStudio.TestTools.UnitTesting;
using NET.S._2019.Zueva._01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2019.Zueva._01.Tests
{
    [TestClass()]
    public class ArrayExtensionTests
    {
        [TestMethod()]
        public void QuickSortedTest()
        {
            //Arrange
            int[] arrayToSort = new int[] { 1, 5, 6, 3, 8, 10};
            int[] expectedResult = new int[] { 1, 3, 5, 6, 8, 10 };

            //Act
            arrayToSort.QuickSort();
            int[] actualResult = arrayToSort;

            //Assert
            Assert.AreEqual(expectedResult, actualResult, "Regular array of 6 elements sorting with quick sort is not correct.");
        }
    }
}