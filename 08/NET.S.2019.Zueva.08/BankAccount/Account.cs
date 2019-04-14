// <copyright file="Account.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BankAccount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    internal class Account
    {
        private readonly string infoFile = @"C:\Users\ZlatKa\Documents\info.bin";
        private readonly IAccountGradation gradation;
        private long number;
        private string ownerName;
        private string ownerSurname;
        private double amount;
        private bool closeAccount;
        private int bonus;

        /// <summary>
        /// Initializes a new instance of the <see cref="Account"/> class with specified chracteristics.
        /// </summary>
        /// <param name="number">The number of account.</param>
        /// <param name="name">Name of account owner.</param>
        /// <param name="surname">Surname of account owner.</param>
        /// <param name="amount">Amount of money.</param>
        /// <param name="bonus">Bonuses for operations.</param>
        /// <param name="gradation">Gradation of the account.</param>
        public Account(long number, string name, string surname, double amount, int bonus, IAccountGradation gradation)
        {
            this.Number = number;
            this.OwnerName = name;
            this.OwnerSurname = surname;
            this.Amount = amount;
            this.bonus = bonus;
            this.gradation = gradation;
            this.closeAccount = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Account"/> class with specified chracteristics.
        /// </summary>
        /// <param name="name">Name of account owner.</param>
        /// <param name="surname">Surname of account owner.</param>
        /// <param name="gradation">Gradation of the account.</param>
        public Account(string name, string surname, IAccountGradation gradation)
        {
            this.Number = new Random().Next(1, int.MaxValue);
            this.OwnerName = name;
            this.OwnerSurname = surname;
            this.Amount = 0;
            this.bonus = 0;
            this.gradation = gradation;
        }

        /// <summary>
        /// Gets counter of bonuses of the account accrued for replenishment and withdrawal operations.
        /// </summary>
        public int Bonus
        {
            get => this.bonus;
            private set => this.bonus = value;
        }

        /// <summary>
        /// Gets or sets number of the account.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown if the value is less than zero.</exception>
        public long Number
        {
            get => this.number;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Account number can't be less than zero.");
                }

                this.number = value;
            }
        }

        /// <summary>
        /// Gets or sets name of the account owner.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown if the value if null.</exception>
        public string OwnerName
        {
            get => this.ownerName;
            set
            {
                if (value != null)
                {
                    this.ownerName = value;
                }

                throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// Gets or sets surname of the account owner.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown if the value if null.</exception>
        public string OwnerSurname
        {
            get => this.ownerSurname;
            set
            {
                if (value != null)
                {
                    this.ownerSurname = value;
                }

                throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// Gets or sets amount of money left on the account.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown if the value is less than zero.</exception>
        public double Amount
        {
            get => this.amount;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Account money amount can't be less than zero.");
                }

                this.amount = value;
            }
        }

        /// <summary>
        /// Adds money to amount of account.
        /// </summary>
        /// <param name="money">Adding amount of money.</param>
        public void PutMoney(double money)
        {
            if (this.closeAccount)
            {
                throw new ArgumentException();
            }

            this.Amount += money;
            this.bonus += this.gradation.PutMoney(money);
            this.SaveToFile();
        }

        /// <summary>
        /// Takes money from amount of account.
        /// </summary>
        /// <param name="money">Taking amount of money.</param>
        public void TakeMoney(double money)
        {
            if (this.closeAccount)
            {
                throw new ArgumentException();
            }

            this.Amount -= money;
            this.bonus += this.gradation.TakeMoney(money);
            this.SaveToFile();
        }

        /// <summary>
        /// Creates a new account with the same owner and new specified gradation.
        /// </summary>
        /// <param name="gradation">Gradation of new account.</param>
        /// <returns>Created account.</returns>
        public Account CreateNewAccount(IAccountGradation gradation)
        {
            return new Account(this.OwnerName, this.OwnerSurname, gradation);
        }

        /// <summary>
        /// Closes account - makes taking and putting not available.
        /// </summary>
        public void CloseAccount()
        {
            this.closeAccount = true;
            this.Amount = 0;
        }

        /// <summary>
        /// Finds current account in binary file for changing data.
        /// </summary>
        /// <returns>
        /// Position in file to start write new information.
        /// </returns>
        public long FindAccountInFile()
        {
            long position = 0;
            using (BinaryReader reader = new BinaryReader(File.Open(this.infoFile, FileMode.OpenOrCreate)))
            {
                while (reader.BaseStream.Position != reader.BaseStream.Length)
                {
                    position = reader.BaseStream.Position;
                    var num = reader.ReadInt64();
                    var name = reader.ReadString();
                    var surname = reader.ReadString();
                    var amount = reader.ReadDouble();
                    var bonus = reader.ReadInt32();
                    var nameOfGradation = reader.ReadString();
                    if (nameOfGradation == "Base")
                    {
                        IAccountGradation gradation = new BaseGradation();
                    }

                    if (nameOfGradation == "Gold")
                    {
                        IAccountGradation gradation = new GoldGradation();
                    }

                    if (nameOfGradation == "Platinum")
                    {
                        IAccountGradation gradation = new PlatinumGradation();
                    }

                    Account account = new Account(num, name, surname, amount, bonus, this.gradation);
                    if (this.Equals(account))
                    {
                        return position;
                    }

                    position = reader.BaseStream.Length;
                }
            }

            return position;
        }

        /// <summary>
        /// Saves current account changes in binary file.
        /// </summary>
        public void SaveToFile()
        {
            int pos = (int)this.FindAccountInFile();
            using (BinaryWriter writer = new BinaryWriter(File.Open(this.infoFile, FileMode.OpenOrCreate)))
            {
                writer.Seek(pos, SeekOrigin.Begin);
                writer.Write(this.Number);
                writer.Write(this.OwnerName);
                writer.Write(this.OwnerSurname);
                writer.Write(this.Amount);
                writer.Write(this.bonus);
                writer.Write(this.gradation.GetGradation());
            }
        }
    }
}
