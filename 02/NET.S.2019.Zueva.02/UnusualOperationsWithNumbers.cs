using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2019.Zueva._02
{
    public static class UnusualOperationsWithNumbers
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

        public static int FindNextBiggerNumber(int sourceNumber)
        {
            int result = -1;
            //List<byte> digitsList = new List<byte>();
            string numberStr = sourceNumber.ToString();
            //int tenPower = 10;
            //while(sourceNumber > 0)
            //{
            //    byte digit = (byte)(sourceNumber % tenPower);
            //    sourceNumber /= tenPower;
            //    tenPower *= 10;
            //    digitsList.Add(digit);
            //}
            byte? firstDigitBiggerthenNextIndex = null; //index of first digit (starting from lower) which is bigger then the next one
            byte i = (byte)(numberStr.Length-1);
            List<char> digitsToSort = new List<char>();
            while (i>0 && !firstDigitBiggerthenNextIndex.HasValue)
            {
                if (numberStr[i]>numberStr[i-1])
                {
                    firstDigitBiggerthenNextIndex = i;
                }
                else
                {
                    digitsToSort.Add(numberStr[i]);
                }
                i--;
            }
            if(firstDigitBiggerthenNextIndex.HasValue)
            {
                digitsToSort.Add(numberStr[firstDigitBiggerthenNextIndex.Value - 1]);
                string resultString = "";
                for (i=0; i<firstDigitBiggerthenNextIndex.Value-1; i++)
                {
                    resultString += numberStr[i];
                }
                resultString += numberStr[firstDigitBiggerthenNextIndex.Value];
                //digitsList[firstDigitBiggerthenNextIndex.Value + 1] = digitsList[firstDigitBiggerthenNextIndex.Value];
                digitsToSort.Sort();
                for (i=0; i<digitsToSort.Count(); i++)
                {
                    resultString += digitsToSort[i];
                }
                result = int.Parse(resultString);
            }
            return result;
        }

        public static int FindNextBiggerNumber(int sourceNumber, out int msecTime)
        {
            msecTime = 0;
            return -1;
        }
    }

}
