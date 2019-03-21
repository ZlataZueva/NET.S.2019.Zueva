using NUnit.Framework;
using NET.S._2019.Zueva._01;
using System;

namespace ArraySortingTesting
{
    [TestFixture]
    public class NUnitTesting
    {
        [Test]
        public void ValidArrayQuickSortTest ()
        {
            //Arrange
            int[] arrayToSort = new int[] { 5, 3, 6, 12, 9, 1 };
            int[] expectedResult = new int[] { 1, 3, 5, 6, 9, 12 };

            //Act
            int[] actualResult = arrayToSort.QuickSorted();

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void EmptyArrayQuickSortTest ()
        {
            //Arrange
            int[] arrayToSort = new int[] { };
            int[] expectedResult = new int[] { };

            //Act
            int[] actualResult = arrayToSort.QuickSorted();

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void NullArrayQuickSortTest ()
        {
            //Arrange
            int[] arrayToSort = null;

            //Assert
            Assert.Throws<ArgumentNullException>( () => arrayToSort.QuickSorted() );
        }


        [Test]
        public void ValidArrayMergeSortTest()
        {
            //Arrange
            int[] arrayToSort = new int[] { 5, 3, 6, 12, 9, 1 };
            int[] expectedResult = new int[] { 1, 3, 5, 6, 9, 12 };

            //Act
            int[] actualResult = arrayToSort.MergeSorted();

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void EmptyArrayMergeSortTest()
        {
            //Arrange
            int[] arrayToSort = new int[] { };
            int[] expectedResult = new int[] { };

            //Act
            int[] actualResult = arrayToSort.MergeSorted();

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void NullArrayMergeSortTest()
        {
            //Arrange
            int[] arrayToSort = null;

            //Assert
            Assert.Throws<ArgumentNullException>(() => arrayToSort.MergeSorted());
        }
    }
}
