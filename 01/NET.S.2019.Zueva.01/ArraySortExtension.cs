using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2019.Zueva._01
{
    public static class IntArrayExtension
    {
        /// <summary>
        /// Sorting of integer array using recursive quick sort algorithm.
        /// </summary>
        /// <param name="array">Array to be sorted.</param>
        /// <exception cref="ArgumentNullException">Thrown if the array is null.</exception>
        public static int[] QuickSorted(this int[] array)
        {
            if (array != null)
            {
                return QuickSort(array, 0, array.Length - 1);
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        private static int[] QuickSort(int[] a, int i, int j)
        {
            if (i < j)
            {
                int q = Partition(a, i, j);
                a = QuickSort(a, i, q);
                a = QuickSort(a, q + 1, j);
            }
            return a;
        }

        private static int Partition(int[] a, int p, int r)
        {
            int x = a[p];
            int i = p - 1;
            int j = r + 1;
            while (true)
            {
                do
                {
                    j--;
                }
                while (a[j] > x);
                do
                {
                    i++;
                }
                while (a[i] < x);
                if (i < j)
                {
                    int tmp = a[i];
                    a[i] = a[j];
                    a[j] = tmp;
                }
                else
                {
                    return j;
                }
            }
        }


        /// <summary>
        /// Sorting of integer array using recursive merge sort algorithm.
        /// </summary>
        /// <param name="array">Array to be sorted.</param>
        /// <exception cref="ArgumentNullException">Thrown if the array is null.</exception>
        public static int[] MergeSorted(this int[] array)
        {
            if (array != null)
            {
                if (array.Length == 1)
                {
                    return array;
                }

                int middle = array.Length / 2;
                return Merge(MergeSorted(array.Take(middle).ToArray()), MergeSorted(array.Skip(middle).ToArray()));
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        private static int[] Merge(int[] arr1, int[] arr2)
        {
            int ptr1 = 0, ptr2 = 0;
            int[] merged = new int[arr1.Length + arr2.Length];

            for (int i = 0; i < merged.Length; ++i)
            {
                if (ptr1 < arr1.Length && ptr2 < arr2.Length)
                {
                    merged[i] = arr1[ptr1] > arr2[ptr2] ? arr2[ptr2++] : arr1[ptr1++];
                }
                else
                {
                    merged[i] = ptr2 < arr2.Length ? arr2[ptr2++] : arr1[ptr1++];
                }
            }

            return merged;
        }
    }
}
