// <copyright file="JaggedIntArraySortTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Tests
{
    using NET.S._2019.Zueva._04;
    using NUnit.Framework;

    [TestFixture]
    public class JaggedIntArraySortTests
    {
        [Test]
        public void SortByElementsSumTest()
        {
            int[][] arrayToSort = new int[][]
            {
                new int[] { 1, 4, 5, 8 },
                new int[] { 3, 5, 4, 3, 2, 6 },
                new int[] { 89, 3, 2, 1, -1 }
            };
            int[][] expectedResult = new int[][]
            {
                new int[] { 1, 4, 5, 8 },
                new int[] { 3, 5, 4, 3, 2, 6 },
                new int[] { 89, 3, 2, 1, -1 }
            };
            arrayToSort.SortByElementsSum();
            Assert.AreEqual(expectedResult, arrayToSort);
        }

        [Test]
        public void SortByMaxElementTest()
        {
            int[][] arrayToSort = new int[][]
            {
                new int[] { 43, 32, 13, 100, 12 },
                new int[] { 23, 2, 5, 1000, 15 },
                new int[] { 0, 22, 1 }
            };
            int[][] expectedResult = new int[][]
            {
                new int[] { 0, 22, 1 },
                new int[] { 43, 32, 13, 100, 12 },
                new int[] { 23, 2, 5, 1000, 15 }
            };
            arrayToSort.SortByMaxElements();
            Assert.AreEqual(expectedResult, arrayToSort);
        }

        [Test]
        public void SortByMinElementTest()
        {
            int[][] arrayToSort = new int[][]
            {
                new int[] { 43, 32, 13, 100, 12 },
                new int[] { 23, 2, 5, 1000, 15 },
                new int[] { 0, 22, 1 }
            };
            int[][] expectedResult = new int[][]
            {
                new int[] { 0, 22, 1 },
                new int[] { 23, 2, 5, 1000, 15 },
                new int[] { 43, 32, 13, 100, 12 }
            };
            arrayToSort.SortByMinElements();
            Assert.AreEqual(expectedResult, arrayToSort);
        }
    }
}
