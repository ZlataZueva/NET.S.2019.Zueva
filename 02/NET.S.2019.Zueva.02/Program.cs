using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2019.Zueva._02
{
    class Program
    {
        static void Main(string[] args)
        {
            int result1 = UnusualOperationsWithNumbers.InsertNumber(8, 15, 3, 8);

            int result2 = UnusualOperationsWithNumbers.FindNextBiggerNumber(12);
            result2 = UnusualOperationsWithNumbers.FindNextBiggerNumber(513);
            result2 = UnusualOperationsWithNumbers.FindNextBiggerNumber(2017);
            result2 = UnusualOperationsWithNumbers.FindNextBiggerNumber(414);
            result2 = UnusualOperationsWithNumbers.FindNextBiggerNumber(144);
            result2 = UnusualOperationsWithNumbers.FindNextBiggerNumber(1234321);
            result2 = UnusualOperationsWithNumbers.FindNextBiggerNumber(1234126);
            result2 = UnusualOperationsWithNumbers.FindNextBiggerNumber(3456432);
            result2 = UnusualOperationsWithNumbers.FindNextBiggerNumber(10);
            result2 = UnusualOperationsWithNumbers.FindNextBiggerNumber(20);

            long msec;
            int result3 = UnusualOperationsWithNumbers.FindNextBiggerNumber(12,out msec);
            result3 = UnusualOperationsWithNumbers.FindNextBiggerNumber(513, out msec);
            result3 = UnusualOperationsWithNumbers.FindNextBiggerNumber(2017, out msec);
            result3 = UnusualOperationsWithNumbers.FindNextBiggerNumber(414, out msec);
            result3 = UnusualOperationsWithNumbers.FindNextBiggerNumber(144, out msec);
            result3 = UnusualOperationsWithNumbers.FindNextBiggerNumber(1234321, out msec);
            result3 = UnusualOperationsWithNumbers.FindNextBiggerNumber(1234126, out msec);
            result3 = UnusualOperationsWithNumbers.FindNextBiggerNumber(3456432, out msec);
            result3 = UnusualOperationsWithNumbers.FindNextBiggerNumber(10, out msec);
            result3 = UnusualOperationsWithNumbers.FindNextBiggerNumber(20, out msec);

            List<int> test4 = new List<int>(new int[]{ 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 });
            test4.FilterDigit(7);

            double result5 = UnusualOperationsWithNumbers.FindNthRoot(1, 5, 0.0001);
            result5 = UnusualOperationsWithNumbers.FindNthRoot(8, 3, 0.0001);
            result5 = UnusualOperationsWithNumbers.FindNthRoot(0.001, 3, 0.0001);
            result5 = UnusualOperationsWithNumbers.FindNthRoot(0.04100625, 4, 0.0001);

        }
    }
}
