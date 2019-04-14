// <copyright file="IAccountGradation.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BankAccount
{
    using System;
    using System.Collections.Generic;
    using System.Text;

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
