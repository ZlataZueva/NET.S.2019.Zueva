// <copyright file="ElementsSumComparer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NET.S_2019.Zueva_04
{
    using System.Collections.Generic;

    internal class ElementsSumComparer : Comparer<int[]>
    {
        public override int Compare(int[] x, int[] y)
        {
            return Sum(x) - Sum(y);
        }

        private static int Sum(int[] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }
    }
}
