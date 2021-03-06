﻿// <copyright file="Polynomial.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NET.S_2019.Zueva_04
{
    using System;
    using System.Linq;

    public sealed class Polynomial
    {
        /// <summary>
        /// Coefficients of the polynomial starting from the coefficient of the highest power of indeterminate x.
        /// </summary>
        private readonly double[] coefficients;

        /// <summary>
        /// Initializes a new instance of the <see cref="Polynomial"/> class with given coefficients.
        /// </summary>
        /// <param name="coefficients">The array of coefficients of polynomial to be created, starting from the highest power coefficient.</param>
        public Polynomial(double[] coefficients)
        {
            if (coefficients != null && coefficients.Length > 0)
            {
                int firstNonZeroValueIndex = 0;
                while (firstNonZeroValueIndex < coefficients.Length && coefficients[firstNonZeroValueIndex] == 0)
                {
                    firstNonZeroValueIndex++;
                }

                this.coefficients = new double[coefficients.Length - firstNonZeroValueIndex];
                Array.Copy(coefficients, firstNonZeroValueIndex, this.coefficients, 0, coefficients.Length - firstNonZeroValueIndex);
            }
            else
            {
                this.coefficients = new double[] { 0 };
            }
        }

        /// <summary>
        /// Indexer of this polynomial returning a coefficient before n-th power of indeterminate x.
        /// </summary>
        /// <param name="n">The power of indeterminate x which coefficient is to be returned.</param>
        /// <returns>The coefficient before x^n.</returns>
        public double this[int n]
        {
            get
            {
                if (n < this.coefficients.Length)
                {
                    return this.coefficients[this.coefficients.Length - n - 1];
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// Multiplies constant value c with polynomial by creating new polynomial with coefficients of second parameter multipled with first parameter.
        /// </summary>
        /// <param name="c">Constant value to be multiplied with polynomial.</param>
        /// <param name="polynom">Polynomial to be multiplied with constant value.</param>
        /// <returns>Created polynomial with multiplied coefficients.</returns>
        public static Polynomial operator *(double c, Polynomial polynom)
        {
            double[] newCoefficients = new double[polynom.coefficients.Length];
            for (int i = 0; i < polynom.coefficients.Length; i++)
            {
                newCoefficients[i] = polynom.coefficients[i] * c;
            }

            return new Polynomial(newCoefficients);
        }

        /// <summary>
        /// Multiplies constant value c with polynomial by creating new polynomial with coefficients of first parameter multipled with second parameter.
        /// </summary>
        /// <param name="c">Constant value to be multiplied with polynomial.</param>
        /// <param name="polynom">Polynomial to be multiplied with constant value.</param>
        /// <returns>New polynomial with multiplied coefficients.</returns>
        public static Polynomial operator *(Polynomial polynom, int c)
        {
            return c * polynom;
        }

        /// <summary>
        /// Summarizes two polynomials by summarizing coefficients of the terms in the same power.
        /// </summary>
        /// <param name="polynom1">The first polynomial to be summarized.</param>
        /// <param name="polynom2">The second polynomial to be summarized.</param>
        /// <returns>New polynomial with summarized coefficients of the terms.</returns>
        public static Polynomial operator +(Polynomial polynom1, Polynomial polynom2)
        {
            return Sum(polynom1, polynom2);
        }

        /// <summary>
        /// Substracts two polynomials by substracting coefficients of the terms in the same power.
        /// </summary>
        /// <param name="polynom1">The first polynomial to be substracted.</param>
        /// <param name="polynom2">The second polynomial to be substracted.</param>
        /// <returns>New polynomial with substracted coefficients of the terms.</returns>
        public static Polynomial operator -(Polynomial polynom1, Polynomial polynom2)
        {
            return Sum(polynom1, polynom2, false);
        }

        /// <summary>
        /// Multiplies two polynomials by multiplying each of monomials of the first polynomial with each of monomials of the second polynomial and summarizing.
        /// </summary>
        /// <param name="polynom1">The first polynomial to be multiplied.</param>
        /// <param name="polynom2">The second polynomial to be multiplied.</param>
        /// <returns>New polynomial result of multiplying.</returns>
        public static Polynomial operator *(Polynomial polynom1, Polynomial polynom2)
        {
            // The highest degree of first polynomial's term with non-zero coefficient
            int degree1 = polynom1.GetDegree();

            // The highest degree of second polynomial's term with non-zero coefficient
            int degree2 = polynom2.GetDegree();

            Polynomial sum = new Polynomial(new double[] { });
            for (int i = 0; i < degree1 + 1; i++)
            {
                if (polynom1[i] != 0)
                {
                    Monomial monomial1 = new Monomial(polynom1[i], i);
                    for (int j = 0; j < degree2 + 1; j++)
                    {
                        Monomial monomial2 = new Monomial(polynom2[j], j);
                        sum += monomial1 * monomial2;
                    }
                }
            }

            return sum;
        }

        /// <summary>
        /// Finds out whether two polynoms are equal or not by comparing its coefficients before the same power of variable.
        /// </summary>
        /// <param name="polynom1">The first polynomial to compare.</param>
        /// <param name="polynom2">The second polynomial to compare.</param>
        /// <returns>true, if the polynomials are equal.</returns>
        /// <returns>false, if the polynomial are not equal.</returns>
        public static bool operator ==(Polynomial polynom1, Polynomial polynom2)
        {
            return polynom1.Equals(polynom2);
        }

        public static bool operator !=(Polynomial polynom1, Polynomial polynom2)
        {
            return !polynom1.Equals(polynom2);
        }

        /// <summary>
        /// Find the value of polynomial function of a single indeterminate x.
        /// </summary>
        /// <param name="x">The value substituted for the indeterminate x of polynomial.</param>
        /// <returns>The value of the polynomial with substituted value for the indeterminate x.</returns>
        public double GetFunctionValue(double x)
        {
            double result = 0;
            double xPower = 1;
            for (int i = this.coefficients.Length - 1; i >= 0; i--)
            {
                result += this.coefficients[i] * xPower;
                xPower *= x;
            }

            return result;
        }

        /// <summary>
        /// Finds the highest degree of its monomials (individual terms) with non-zero coefficients.
        /// </summary>
        /// <returns>Degree of a polynomial.</returns>
        public int GetDegree()
        {
            int degree = this.coefficients.Length - 1;
            return degree;
        }

        /// <summary>
        /// Returns string representation of this polynomial in the form CnX^n + Cn-1X^(n-1) + ... + C1X + C0.
        /// </summary>
        /// <returns>String representation of this polynomial.</returns>
        public override string ToString()
        {
            string result = string.Empty;
            for (int i = 0; i < this.coefficients.Length - 1; i++)
            {
                if (this.coefficients[i] != 0)
                {
                    if (this.coefficients[i] > 0 && i > 0)
                    {
                        result += " + ";
                    }
                    else if (this.coefficients[i] < 0)
                    {
                        result += " - ";
                    }

                    if (Math.Abs(this.coefficients[i]) != 1)
                    {
                        result += Math.Abs(this.coefficients[i]).ToString();
                    }

                    result += this.coefficients.Length - i - 1 > 1 ? "X^" + (this.coefficients.Length - i - 1).ToString() : "X";
                }
            }

            if (this.coefficients.Length > 1 && this.coefficients.Last() > 0)
            {
                result += " + ";
            }
            else if (this.coefficients.Last() < 0)
            {
                result += " - ";
            }

            if (this.coefficients.Last() != 0)
            {
                result += Math.Abs(this.coefficients.Last()).ToString();
            }

            return result.Trim();
        }

        /// <summary>
        /// Finds out whether the specified polynomial is equal to the current polynomial.
        /// </summary>
        /// <param name="obj">The polynomial to compare with the current polynomial.</param>
        /// <returns>true, if the specified polynomial is equal to the current polynomial.</returns>
        /// <returns>false, if the specified polynomial is not equal to the current polynomial.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Polynomial)
            {
                if (base.Equals(obj))
                {
                    return true;
                }

                Polynomial polynom = (Polynomial)obj;
                if (this.GetDegree() != polynom.GetDegree())
                {
                    return false;
                }

                for (int i = 0; i < this.coefficients.Length; i++)
                {
                    if (this.coefficients[i] != polynom.coefficients[i])
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// Returns hash-code for this polynomial.
        /// </summary>
        /// <returns>Hash-code for this polynomial.</returns>
        public override int GetHashCode()
        {
            string coefficients = string.Empty;
            for (int i = this.coefficients.Length - this.GetDegree(); i < this.coefficients.Length; i++)
            {
                coefficients += this.coefficients[i].ToString() + " ";
            }

            return coefficients.GetHashCode();
        }

        /// <summary>
        /// Summarizes or subtracts, dependind on parameter isSum, two polynomials by summarizing or subtracting coefficients of the terms in the same power.
        /// </summary>
        /// <param name="polynom1">The first polynomial to be summarized or subtracted.</param>
        /// <param name="polynom2">The second polynomial to be summarized or subracted.</param>
        /// <param name="isSum">If this parameter is true(default) polynomials are to be summarized. If it is false they are to be substracted.</param>
        /// <returns>New polynomial result of the operation.</returns>
        private static Polynomial Sum(Polynomial polynom1, Polynomial polynom2, bool isSum = true)
        {
            // The highest degree of first polynomial's term with non-zero coefficient
            int degree1 = polynom1.GetDegree();

            // The highest degree of second polynomial's term with non-zero coefficient
            int degree2 = polynom2.GetDegree();

            // The degree of a new polynomial
            int newDegree = degree1 > degree2 ? degree1 : degree2;

            double[] newCoefficients = new double[newDegree + 1];
            for (int i = 0; i < newDegree + 1; i++)
            {
                newCoefficients[newDegree - i] = isSum ? polynom1[i] + polynom2[i] : polynom1[i] - polynom2[i];
            }

            return new Polynomial(newCoefficients);
        }

        /// <summary>
        /// Subclass representing one of the terms of polynomial.
        /// </summary>
        private struct Monomial
        {
            private double coefficient;
            private int degree;

            public Monomial(double coefficient, int degree)
            {
                this.coefficient = coefficient;
                this.degree = degree;
            }

            /// <summary>
            /// Multiplies two monomials by multiplying their coefficients and summarizing their degrees.
            /// </summary>
            /// <param name="monom1">The first monomial to be multiplied.</param>
            /// <param name="monom2">The second monomial to be multiplied.</param>
            /// <returns>New monomial result of multiplying.</returns>
            public static Monomial operator *(Monomial monom1, Monomial monom2)
            {
                return new Monomial(monom1.coefficient * monom2.coefficient, monom1.degree + monom2.degree);
            }

            /// <summary>
            /// Adds monomial to a polynomial.
            /// </summary>
            /// <param name="polynom">Original polynomial.</param>
            /// <param name="monom">Monomial to be added.</param>
            /// <returns>New polynomial after additing the monomial..</returns>
            public static Polynomial operator +(Polynomial polynom, Monomial monom)
            {
                int newDegree = polynom.GetDegree() > monom.degree ? polynom.GetDegree() : monom.degree;
                double[] newCoefficients = new double[newDegree + 1];
                for (int i = 0; i <= newDegree; i++)
                {
                    newCoefficients[newDegree - i] = polynom[i];
                }

                newCoefficients[newDegree - monom.degree] = polynom[monom.degree] + monom.coefficient;
                return new Polynomial(newCoefficients);
            }
        }
    }
}
