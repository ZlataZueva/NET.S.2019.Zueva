using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount
{
    class PlatinumGradation:IAccountGradation
    {
        private static readonly double _coefficient = 0.5;

        public PlatinumGradation()
        {
            TakingCost = 5;
            PuttingCost = 5;
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
            return (int)(money * _coefficient) * PuttingCost;
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
            return (int)(money * _coefficient) * TakingCost;
        }
    }
}
