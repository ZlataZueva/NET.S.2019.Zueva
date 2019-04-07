using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount
{
    /// <summary>
    /// Interface to count bonuses for different accounts gradations.
    /// </summary>
    public interface IAccountGradation
    {
        int TakingCost { get; set; }

        int PuttingCost { get; set; }

        string GetGradation();

        int PutMoney(double money);

        int TakeMoney(double money);
    }
}
