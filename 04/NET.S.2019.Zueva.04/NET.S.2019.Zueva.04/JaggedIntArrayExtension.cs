using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2019.Zueva._04
{
    public static class JaggedIntArrayExtension
    {
        /// <summary>
        /// Sorts jagged int array using bubble sort algorithm.
        /// </summary>
        /// <param name="array">Array to be sorted.</param>
        /// <param name="comparer">Implementation of comparation for two arrays.</param>
        /// <param name="isDesc">Defines wherher sorting is descending or not. Default value is false.</param>
        private static void BubbleSort(this int[][] array, IComparer<int[]> comparer, bool isDesc = false)
        {
            int[] temp;
            int comparationResult;

            for (int i = array.Length; i > 1; i--)
            {
                for (int j = 0; j < (i - 1); j++)
                {
                    comparationResult = comparer.Compare(array[j], array[j + 1]);

                    if ((comparationResult > 0) && !isDesc || (comparationResult < 0) && isDesc)
                    {
                        temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }

        /// <summary>
        /// Sorts jagged int array by sum of elements in rows.
        /// </summary>
        /// <param name="array">Array to sort.</param>
        /// <param name="isDesc">Defines wherher sorting is descending or not. Default value is false.</param>
        public static void SortByElementsSum(this int[][] array, bool isDesc = false)
        {
            if (array != null)
            {
                if (array.Length > 1)
                {
                    ElementsSumComparer comparer = new ElementsSumComparer();
                    array.BubbleSort(comparer, isDesc);
                }
            }
            throw new ArgumentNullException();
        }

        /// <summary>
        /// Sorts jagged int array by max elements in rows.
        /// </summary>
        /// <param name="array">Array to sort.</param>
        /// <param name="isDesc">Defines wherher sorting is descending or not. Default value is false.</param>
        public static void SortByMaxElements(this int[][] array, bool isDesc = false)
        {
            if (array != null)
            {
                if (array.Length > 1)
                {
                    MaxElementsComparer comparer = new MaxElementsComparer();
                    array.BubbleSort(comparer, isDesc);
                }
            }
            throw new ArgumentNullException();
        }

        /// <summary>
        /// Sorts jagged int array by min elements in rows.
        /// </summary>
        /// <param name="array">Array to sort.</param>
        /// <param name="isDesc">Defines wherher sorting is descending or not. Default value is false.</param>
        public static void SortByMinElements(this int[][] array, bool isDesc = false)
        {
            if (array != null)
            {
                if (array.Length > 1)
                {
                    MinElementsComparer comparer = new MinElementsComparer();
                    array.BubbleSort(comparer, isDesc);
                }
            }
            throw new ArgumentNullException();
        }
    }
}
