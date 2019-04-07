using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount
{
    class BaseGradation:IAccountGradation
    {
        private static readonly double _coefficient = 0.5;

        public BaseGradation()
        {
            TakingCost = 1;
            PuttingCost = 1;
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
            return (int)(money * _coefficient) * PuttingCost;
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
            return (int)(money * _coefficient) * TakingCost;
        }
    }
}
