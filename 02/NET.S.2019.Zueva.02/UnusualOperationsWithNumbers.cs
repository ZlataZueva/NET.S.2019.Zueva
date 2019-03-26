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
        /// <summary>
        ///  Inderting bits of numberIn into numberSource starting from bit #bitFrom and finishing with #bitTo.
        /// </summary>
        /// <param name="numberSource">An integer number into which the bits are to be inserted.</param>
        /// <param name="numberIn">An integer number from which bits are to be inserted.</param>
        /// <param name="bitFrom">Number of bit starting the inserting range.</param>
        /// <param name="bitTo">Number of bit ending the inserting range.</param>
        /// <returns>A source number with inserted bits.</returns>
        /// <exception cref="ArgumentException">Thrown when argument bitFrom is greater than bitTo.</exception>
        public static int InsertNumber (int numberSource, int numberIn, byte bitFrom, byte bitTo)
        {
            if (bitTo >= bitFrom)
            {
                int bitMaskofInsertingRange = 1;
                for (byte i = bitFrom; i < bitTo; i++)
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
            else
            {
                throw new ArgumentException("Argument bitTo should be greater than bitFrom or equal.");
            }
        }

        /// <summary>
        /// Finds closest bigger integer number consisting of digits of sourceNumber.
        /// </summary>
        /// <param name="sourceNumber">An original number closest bigger to which should be found.</param>
        /// <returns>Found closest bigger number.</returns>
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

        /// <summary>
        /// Finds closest bigger integer number consisting of digits of sourceNumber and measures execution time. 
        /// </summary>
        /// <param name="sourceNumber">An original number closest bigger to which should be found.</param>
        /// <param name="msecTime">Out parameter for execution time in milliseconds.</param>
        /// <returns>Found closest bigger number.</returns>
        public static int FindNextBiggerNumber(int sourceNumber, out long msecTime)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int result = FindNextBiggerNumber(sourceNumber);
            stopwatch.Stop();
            msecTime = stopwatch.ElapsedMilliseconds;
            return result;
        }


        /// <summary>
        /// Filters a list of integer values by consisting a digit.
        /// </summary>
        /// <param name="sourceNumberList">A list of integer values to be filtered.</param>
        /// <param name="digitToFilter">A digit which numbers of filtered list must include.</param>
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

        /// <summary>
        /// Finds the n-th root of a number with a specified accuracy.
        /// </summary>
        /// <param name="a">A number which root is to be found.</param>
        /// <param name="n">A root degree.</param>
        /// <param name="eps">An accuracy of calculation.</param>
        /// <returns>Found root.</returns>
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
