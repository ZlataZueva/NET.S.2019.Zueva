using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2019.Zueva._03
{
    public class GCDFinder
    {
        /// <summary>
        /// Finds the greatest common divisior of two numbers using Euclid algorithm: https://en.wikipedia.org/wiki/Euclidean_algorithm.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <returns>The greatest common divisior of the numbers.</returns>
        public static int FindGCDwithEuclid (int a, int b)
        {
            //If one of the numbers is 0 GCD is another number 
            if (a == 0)
                return b;
            if (b == 0)
                return a;

            //If the number is negative algorithm falls into an infinite loop
            //Divisiors of a negative number are equal to its absolute value
            if (a < 0)
                a = -a;
            if (b < 0)
                b = -b;

            //Euclid's algorithm
            while (a != b)
            {
                if (a>b)
                {
                    a -= b;
                }
                else
                {
                    b -= a;
                }
            }
            return a;
        }

        /// <summary>
        /// Finds the greatest common divisior of two numbers using Binary(Stein's) algorithm.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <returns>The greatest common divisior of the numbers.</returns>
        public static int FindGCDwithStein (int a, int b)
        {
            //If one of the numbers is 0 GCD is another number 
            if (a == 0)
                return b;
            if (b == 0)
                return a;

            //If the number is negative algorithm falls into an infinite loop
            //Divisiors of a negative number are equal to its absolute value
            if (a < 0)
                a = -a;
            if (b < 0)
                b = -b;

            //Binary (Stein's) algorithm
            if (a == b)
                return a;
            if ((~a & 1) != 0)
            {
                if ((b & 1) != 0)
                    return FindGCDwithStein(a >> 1, b);
                else
                    return FindGCDwithStein(a >> 1, b >> 1) << 1;
            }
            if ((~b & 1) != 0)
                return FindGCDwithStein(a, b >> 1);
            if (a > b)
                return FindGCDwithStein((a - b) >> 1, b);
            return FindGCDwithStein((b - a) >> 1, a);
        }


        /// <summary>
        /// Finds greatest common divisior of a sequence of numbers using Euclid algorithm: https://en.wikipedia.org/wiki/Euclidean_algorithm.
        /// </summary>
        /// <param name="numbers">Numbers to find greatest common divisor of.</param>
        /// <returns>Greatest common divisor of all numbers.</returns>
        /// <exception cref="ArgumentNullException">Thrown when NULL is passed.</exception>
        /// <exception cref="ArgumentException">Thrown when less than two numbers are passed.</exception>
        public static int FindGCDwithEuclid (params int[] numbers)
        {
            return FindGCDofSequence(FindGCDwithEuclid, numbers);
        }


        /// <summary>
        /// Finds greatest common divisior of a sequence of numbers using Euclid algorithm and estimates execution time.
        /// </summary>
        /// <param name="time">Out parameter for estimated execution time.</param>
        /// <param name="numbers">Numbers to find greatest common divisor of.</param>
        /// <returns>Greatest common divisor of all numbers.</returns>
        /// <exception cref="ArgumentNullException">Thrown when NULL is passed.</exception>
        /// <exception cref="ArgumentException">Thrown when less than two numbers are passed.</exception>
        public static int FindGCDwithEuclid (out TimeSpan time, params int[] numbers)
        {
            return FindGCDofSequence(FindGCDwithEuclid, out time, numbers);
        }

        /// <summary>
        /// Finds greatest common divisior of a sequence of numbers using Binary(Steins) algorithm.
        /// </summary>
        /// <param name="numbers">Numbers to find greatest common divisor of.</param>
        /// <returns>Greatest common divisor of all numbers.</returns>
        /// <exception cref="ArgumentNullException">Thrown when NULL is passed.</exception>
        /// <exception cref="ArgumentException">Thrown when less than two numbers are passed.</exception>
        public static int FindGCDwithStein(params int[] numbers)
        {
            return FindGCDofSequence(FindGCDwithStein, numbers);
        }

        /// <summary>
        /// Finds greatest common divisior of a sequence of numbers using Stein's (Binary) algorithm and estimates execution time.
        /// </summary>
        /// <param name="time">Out parameter for estimated execution time.</param>
        /// <param name="numbers">Numbers to find greatest common divisor of.</param>
        /// <returns>Greatest common divisor of all numbers.</returns>
        /// <exception cref="ArgumentNullException">Thrown when NULL is passed.</exception>
        /// <exception cref="ArgumentException">Thrown when less than two numbers are passed.</exception>
        public static int FindGCDwithStein(out TimeSpan time, params int[] numbers)
        {
            return FindGCDofSequence(FindGCDwithStein, out time, numbers);
        }


        /// <summary>
        /// Finds greatest common divisior of a sequence of numbers using given algorithm.
        /// </summary>
        /// <param name="algorithm">Algorithm of finding greatest common divisor of two numbers.</param>
        /// <param name="numbers">Numbers to find greatest common divisor of.</param>
        /// <returns>Greatest common divisor of all numbers.</returns>
        /// <exception cref="ArgumentNullException">Thrown when NULL is passed.</exception>
        /// <exception cref="ArgumentException">Thrown when less than two numbers are passed.</exception> 
        private static int FindGCDofSequence (Func<int,int,int> algorithm, params int[] numbers)
        {
            if (numbers != null)
            {
                if (numbers.Count() > 1)
                {
                    int gcd = algorithm(numbers[0], numbers[1]);
                    for (int i = 2; i < numbers.Count(); i++)
                    {
                        gcd = algorithm(gcd, numbers[i]);
                    }
                    return gcd;
                }
                else
                {
                    throw new ArgumentException("You should pass at least two numbers to get their GCD.");
                }
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// Finds greatest common divisior of a sequence of numbers using given algorithm and estimates execution time.
        /// </summary>
        /// <param name="algorithm">Algorithm of finding greatest common divisor of two numbers.</param>
        /// <param name="time">Out parameter for estimated execution time.</param>
        /// <param name="numbers">Numbers to find greatest common divisor of.</param>
        /// <returns>Greatest common divisor of all numbers.</returns>
        /// <exception cref="ArgumentNullException">Thrown when NULL is passed.</exception>
        /// <exception cref="ArgumentException">Thrown when less than two numbers are passed.</exception>
        private static int FindGCDofSequence(Func<int, int, int> algorithm, out TimeSpan time, params int[] numbers)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            int result = FindGCDofSequence(algorithm, numbers);
            stopWatch.Stop();
            time = stopWatch.Elapsed;
            return result;
        }

    }
}
