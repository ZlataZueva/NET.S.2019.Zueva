using System;
using System.Collections.Generic;
using System.Diagnostics;
//using System.Linq;
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
            string numberStr = sourceNumber.ToString();
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
                digitsToSort.Sort();
                for (i=0; i<digitsToSort.Count; i++)
                {
                    resultString += digitsToSort[i];
                }
                result = int.Parse(resultString);
            }
            return result;
        }

        public static int FindNextBiggerNumber(int sourceNumber, out long msecTime)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int result = FindNextBiggerNumber(sourceNumber);
            stopwatch.Stop();
            msecTime = stopwatch.ElapsedMilliseconds;
            return result;
        }

        public static void FilterDigit (this List<int> sourceNumberList, byte digitToFilter)
        {
            int i = 0;
            while (i < sourceNumberList.Count)
            { 
                if (!sourceNumberList[i].ToString().Contains(digitToFilter.ToString()))
                {
                    sourceNumberList.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }
        }

        public static double FindNthRoot (double a, int n, double eps)
        {
            double xk_1;
            double xk = 1;
            do
            {
                xk_1 = xk;
                xk =(1 / (double)n) * ((n - 1) * xk_1 + a / Math.Pow(xk_1, n - 1));
            }
            while (Math.Abs(xk - xk_1) > eps);

            int digitsAfterComaCounter = 0;
            while (eps<1)
            {
                digitsAfterComaCounter++;
                eps *= 10;
            }
            return Math.Round(xk, digitsAfterComaCounter);
        }
    }

}
