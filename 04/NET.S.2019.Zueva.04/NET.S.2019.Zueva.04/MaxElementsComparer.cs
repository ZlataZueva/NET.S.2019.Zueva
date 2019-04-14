// <copyright file="MaxElementsComparer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NET.S_2019.Zueva_04
{
    using System.Collections.Generic;

    internal class MaxElementsComparer : Comparer<int[]>
    {
        public override int Compare(int[] x, int[] y)
        {
            return Max(x) - Max(y);
        }

        private static int Max(int[] array)
        {
            int max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (max < array[i])
                {
                    max = array[i];
                }
            }

            return max;
        }
    }
}
