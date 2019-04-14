// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace BankAccount
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            Account newAccount1 = new Account("Zlata", "Zueva", new BaseGradation());
            newAccount1.PutMoney(12.90);
            Console.WriteLine(newAccount1.Bonus);
            newAccount1.PutMoney(50.10);
            newAccount1.TakeMoney(10.30);
            Console.WriteLine(newAccount1.Amount);
            Account newAccount2 = new Account(newAccount1.Number, "Alexander", "Azarov", newAccount1.Amount, newAccount1.Bonus, new GoldGradation());
            newAccount2.PutMoney(11);
            Account newAccount3 = newAccount2.CreateNewAccount(new PlatinumGradation());
            Console.WriteLine(newAccount3.Bonus);
            newAccount3.CloseAccount();
            Console.ReadLine();
        }
    }
}
