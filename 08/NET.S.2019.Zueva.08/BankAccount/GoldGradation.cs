// <copyright file="GoldGradation.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace BankAccount
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class GoldGradation : IAccountGradation
    {
        public GoldGradation()
        {
            this.TakingCost = 2;
            this.PuttingCost = 2;
        }

        public int TakingCost { get; set; }

        public int PuttingCost { get; set; }

        public string GetGradation()
        {
            return "Gold";
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
            return (int)money * this.PuttingCost;
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
            return (int)money * this.TakingCost;
        }
    }
}
