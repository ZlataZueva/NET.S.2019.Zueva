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
            int result1 = UnusualOperationsWithNumbers.InsertNumber(15, 15, 0, 0);
            result1 = UnusualOperationsWithNumbers.InsertNumber(8, 15, 0, 0);
            result1 = UnusualOperationsWithNumbers.InsertNumber(8, 15, 3, 8);
            result1 = UnusualOperationsWithNumbers.InsertNumber(15, 8, 1, 3);

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

        }
    }
}
