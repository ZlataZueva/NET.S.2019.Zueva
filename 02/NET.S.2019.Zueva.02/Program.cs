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

            double result5 = UnusualOperationsWithNumbers.FindNthRoot(1, 5, 0.0001);
            result5 = UnusualOperationsWithNumbers.FindNthRoot(8, 3, 0.0001);
            result5 = UnusualOperationsWithNumbers.FindNthRoot(0.001, 3, 0.0001);
            result5 = UnusualOperationsWithNumbers.FindNthRoot(0.04100625, 4, 0.0001);

        }
    }
}
