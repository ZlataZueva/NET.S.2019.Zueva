﻿// <copyright file="DoubleExtension.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NET.S_2019.Zueva_03
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class DoubleExtension
    {
        private static readonly long RangeOfMantissa = 4503599627370496; // 2^52, because mantissa takes 52 bits of double value
        private static readonly byte ExpBitsCount = 11;
        private static readonly byte MantissaBitsCount = 52;

        /// <summary>
        /// Gets binary representation of a value as a string.
        /// </summary>
        /// <param name="value">Value which binary representation is to b found.</param>
        /// <returns>String binary representation of the value.</returns>
        public static string BinaryToString(this double value)
        {
            // Double value = (-1)^S*1,M*2^(E-1023)
            char s = '0';
            if (value < 0)
            {
                s = '1';
                value = -value;
            }

            // Find max less than value power of two
            int powerOfTwo = 0;
            if (value >= 1)
            {
                long powerOfTwoValue = 1;
                while (value > powerOfTwoValue)
                {
                    powerOfTwoValue <<= 1;
                    powerOfTwo++;
                }

                powerOfTwo--;
            }
            else
            {
                double originalValue = value;
                while (originalValue < 1)
                {
                    originalValue *= 2;
                    powerOfTwo--;
                }
            }

            // Find E and its string representation
            int intE = powerOfTwo + 1023; // 1023 is from: (-1)^S*1,M*2^(E- 1023 )
            string e = ((long)intE).BinaryToString(ExpBitsCount);

            // Find M
            double powerOfTwoDoubleValue = powerOfTwo > 0 ? ((long)1 << powerOfTwo) : Math.Pow(2, powerOfTwo);
            double offset = (value - powerOfTwoDoubleValue) / powerOfTwoDoubleValue;
            long intM = (long)Math.Round(RangeOfMantissa * offset);
            string m = intM.BinaryToString(MantissaBitsCount);

            return s + e + m;
        }

        /// <summary>
        /// Get binary representation of a value as a string.
        /// </summary>
        /// <param name="value">Value which binary representation is to be found.</param>
        /// <param name="size">Size in bits of the value. Default value is sizeof(long)*8.</param>
        /// <returns>String binary representation of the value.</returns>
        private static string BinaryToString(this long value, byte size = sizeof(long) * 8)
        {
            // char S = value > 0 ? '0' : '1';
            if (value < 0)
            {
                value = -value;
            }

            string result = string.Empty;

            while (value > 0)
            {
                result = (value % 2).ToString() + result;
                value >>= 1;
            }

            for (int i = 0; i < (size - result.Length - 1); i++)
            {
                result = "0" + result;
            }

            // result = S + result;
            return result;
        }
    }
}
