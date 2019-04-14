// <copyright file="PlatinumGradation.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BankAccount
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class PlatinumGradation : IAccountGradation
    {
        private static readonly double Coefficient = 0.5;

        public PlatinumGradation()
        {
            this.TakingCost = 5;
            this.PuttingCost = 5;
        }

        public int TakingCost { get; set; }

        public int PuttingCost { get; set; }

        public string GetGradation()
        {
            return "Platinum";
        }

        /// <summary>
        /// Counts bonuses when user puts money.
        /// </summary>
        /// <param name="money">Output amount of money.</param>
        /// <returns>
        /// Number of bonuses to add to account.
        /// </returns>
        public int PutMoney(double money)
        {
            return (int)(money * Coefficient) * this.PuttingCost;
        }

        /// <summary>
        /// Counts bonuses when user takes money.
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
