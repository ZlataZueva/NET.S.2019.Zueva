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
            int result = UnusualOperationsWithNumbers.InsertNumber(15, 15, 0, 0);
            result = UnusualOperationsWithNumbers.InsertNumber(8, 15, 0, 0);
            result = UnusualOperationsWithNumbers.InsertNumber(8, 15, 3, 8);
            result = UnusualOperationsWithNumbers.InsertNumber(15, 8, 1, 3);
        }
    }
}
