using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2019.Zueva._02
{
    public class UnusualOperationsWithNumbers
    {
        public static int InsertNumber (int numberSource, int numberIn, byte bitFrom, byte bitTo)
        {
            int bitMaskofInsertingRange = 1;
            for (byte i=bitFrom; i<bitTo; i++)
            {
                bitMaskofInsertingRange <<= 1;
                bitMaskofInsertingRange++;
            }
            int numberInRange = numberIn & bitMaskofInsertingRange;
            numberInRange <<= bitFrom;
            bitMaskofInsertingRange <<= bitFrom;
            numberSource &= ~bitMaskofInsertingRange;
            return numberSource + numberInRange;
        }
    }
}
