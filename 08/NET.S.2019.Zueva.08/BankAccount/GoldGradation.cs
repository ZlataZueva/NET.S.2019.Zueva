using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount
{
    class GoldGradation:IAccountGradation
    {

        public GoldGradation()
        {
            TakingCost = 2;
            PuttingCost = 2;
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
            return (int)money * PuttingCost;
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
            return (int)money * TakingCost;
        }
    }
}
