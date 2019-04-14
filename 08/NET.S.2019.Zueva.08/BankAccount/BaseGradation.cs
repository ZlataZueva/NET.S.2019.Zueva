// <copyright file="BaseGradation.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BankAccount
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class BaseGradation : IAccountGradation
    {
        private static readonly double Coefficient = 0.5;

        public BaseGradation()
        {
            this.TakingCost = 1;
            this.PuttingCost = 1;
        }

        public int TakingCost { get; set; }

        public int PuttingCost { get; set; }

        public string GetGradation()
        {
            return "Base";
        }

        /// <summary>
        /// Count bonuses when user puts money.
        /// </summary>
        /// <param name="money">Input amount of money.</param>
        /// <returns>
        /// Number of bonuses to add to account.
        /// </returns>
        public int PutMoney(double money)
        {
            return (int)(money * Coefficient) * this.PuttingCost;
        }

        /// <summary>
        /// Count bonuses when user takes money.
        /// </summary>
        /// <param name="money">Output amount of money.</param>
        /// <returns>
        /// Number of bonuses to add to account.
        /// </returns>
        public int TakeMoney(double money)
        {
            return (int)(money * Coefficient) * this.TakingCost;
        }
    }
}
