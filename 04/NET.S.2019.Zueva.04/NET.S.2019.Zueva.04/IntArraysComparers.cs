using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2019.Zueva._04
{

    class ElementsSumComparer : Comparer<int[]>
    {
        public override int Compare(int[] x, int[] y)
        {
            return Sum(x)-Sum(y);
        }

        private int Sum (int[] array)
        {
            int sum = 0;
            for (int i=0; i<array.Length; i++)
            {
                sum += array[i];
            }
            return sum;
        }
    }

    class MaxElementsComparer : Comparer<int[]>
    {
        public override int Compare(int[] x, int[] y)
        {
            return Max(x) - Max(y);
        }

        private int Max (int[] array)
        {
            int max = array[0];
            for (int i=1; i<array.Length; i++)
            {
                if (max < array[i])
                    max = array[i];
            }
            return max;
        }
    }

    class MinElementsComparer : Comparer<int[]>
    {
        public override int Compare(int[] x, int[] y)
        {
            return Min(x) - Min(y);
        }

        private int Min(int[] array)
        {
            int min = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (min > array[i])
                    min = array[i];
            }
            return min;
        }
    }
}
