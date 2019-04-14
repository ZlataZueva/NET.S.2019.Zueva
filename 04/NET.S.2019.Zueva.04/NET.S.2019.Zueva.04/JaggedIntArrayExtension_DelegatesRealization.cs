// <copyright file="JaggedIntArrayExtension_DelegatesRealization.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NET.S_2019.Zueva_04
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal static class JaggedIntArrayExtension_DelegatesRealization
    {
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
                    array.BubbleSort(new ElementsSumComparer().Compare, isDesc);
                }
            }
            else
            {
                throw new ArgumentNullException();
            }
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
                    array.BubbleSort(new MaxElementsComparer().Compare, isDesc);
                }
            }
            else
            {
                throw new ArgumentNullException();
            }
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
                    array.BubbleSort(new MinElementsComparer().Compare, isDesc);
                }
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// Sorts jagged int array using bubble sort algorithm.
        /// </summary>
        /// <param name="array">Array to be sorted.</param>
        /// <param name="comparer">Implementation of comparation for two arrays.</param>
        /// <param name="desc">Defines wherher sorting is descending or not. Default value is false.</param>
        private static void BubbleSort(this int[][] array, IComparer<int[]> comparer, bool desc = false)
        {
            BubbleSort(array, comparer.Compare, desc);
        }

        /// <summary>
        /// Sorts jagged array of integers using bubble sort algorithm.
        /// </summary>
        /// <param name="array">Array to be sorted.</param>
        /// <param name="comparer">Function comparing two arrays of integers.</param>
        /// <param name="desc">Defines wherher sorting is descending or not. Default value is false.</param>
        private static void BubbleSort(this int[][] array, Func<int[], int[], int> comparer, bool desc = false)
        {
            int[] temp;
            int comparationResult;

            for (int i = array.Length; i > 1; i--)
            {
                for (int j = 0; j < (i - 1); j++)
                {
                    comparationResult = comparer(array[j], array[j + 1]);

                    if (((comparationResult > 0) && !desc) || ((comparationResult < 0) && desc))
                    {
                        temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }
    }
}
