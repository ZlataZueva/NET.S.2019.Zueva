// <copyright file="MinElementsComparer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NET.S_2019.Zueva_04
{
    using System.Collections.Generic;

    internal class MinElementsComparer : Comparer<int[]>
    {
        public override int Compare(int[] x, int[] y)
        {
            return Min(x) - Min(y);
        }

        private static int Min(int[] array)
        {
            int min = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (min > array[i])
                {
                    min = array[i];
                }
            }

            return min;
        }
    }
}
