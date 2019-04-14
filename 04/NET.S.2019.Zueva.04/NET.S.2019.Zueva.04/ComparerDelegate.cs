// <copyright file="ComparerDelegate.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NET.S_2019.Zueva_04
{
    using System;
    using System.Collections.Generic;

    internal class ComparerDelegate : Comparer<int[]>
    {
        private Func<int[], int[], int> comparer;

        public ComparerDelegate(Func<int[], int[], int> comparer)
        {
            this.comparer = comparer;
        }

        public override int Compare(int[] x, int[] y)
        {
            return this.comparer(x, y);
        }
    }
}
