using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace BankAccount
{
    class Account
    {
        private long _number;
        private string _ownerName;
        private string _ownerSurname;
        private double _amount;
        private string _infoFile = @"C:\Users\ZlatKa\Documents\info.bin";
        private bool _closeAccount;
        private int _bonus;
        private IAccountGradation _gradation;

        /// <summary>
        /// Creates an Account with specified chracteristics.
        /// </summary>
        /// <param name="number">The number of account.</param>
        /// <param name="name">Name of account owner.</param>
        /// <param name="surname">Surname of account owner.</param>
        /// <param name="amount">Amount of money.</param>
        /// <param name="bonus">Bonuses for operations.</param>
        /// <param name="gradation">Gradation of the account.</param>
        public Account(long number, string name, string surname, double amount, int bonus, IAccountGradation gradation)
        {
            Number = number;
            OwnerName = name;
            OwnerSurname = surname;
            Amount = amount;
            _bonus = bonus;
            _gradation = gradation;
            _closeAccount = false;
        }

        /// <summary>
        /// Creates an Account with specified chracteristics.
        /// </summary>
        /// <param name="name">Name of account owner.</param>
        /// <param name="surname">Surname of account owner.</param>
        /// <param name="gradation">Gradation of the account.</param>
        public Account(string name, string surname, IAccountGradation gradation)
        {
            Number = new Random().Next(1, int.MaxValue);
            OwnerName = name;
            OwnerSurname = surname;
            Amount = 0;
            _bonus = 0;
            _gradation = gradation;
        }

        /// <summary>
        /// Counter of bonuses of the account accrued for replenishment and withdrawal operations.
        /// </summary>
        public int Bonus
        {
            get => _bonus;
            private set => _bonus = value;
        }

        /// <summary>
        /// Number of the account.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown if the value is less than zero.</exception>
        public long Number
        {
            get => _number;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Account number can't be less than zero.");
                }

                _number = value;
            }
        }

        /// <summary>
        /// Name of the account owner.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown if the value if null.</exception>
        public string OwnerName
        {
            get => _ownerName;
            set
            {
                if(value != null)
                {
                    _ownerName = value;
                }

                throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// Surname of the account owner.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown if the value if null.</exception>
        public string OwnerSurname
        {
            get => _ownerSurname;
            set
            {
                if (value != null)
                {
                    _ownerSurname = value;
                }

                throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// Amount of money left on the account.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown if the value is less than zero.</exception>
        public double Amount
        {
            get => _amount;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Account money amount can't be less than zero.");
                }

                _amount = value;
            }
        }

        /// <summary>
        /// Adds money to amount of account.
        /// </summary>
        /// <param name="money">Adding amount of money.</param>
        public void PutMoney(double money)
        {
            if (_closeAccount)
            {
                throw new ArgumentException();
            }

            Amount += money;
            _bonus += _gradation.PutMoney(money);
            SaveToFile();
        }

        /// <summary>
        /// Takes money from amount of account.
        /// </summary>
        /// <param name="money">Taking amount of money.</param>
        public void TakeMoney(double money)
        {
            if (_closeAccount)
            {
                throw new ArgumentException();
            }

            Amount -= money;
            _bonus += _gradation.TakeMoney(money);
            SaveToFile();
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
            _closeAccount = true;
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
            using (BinaryReader reader = new BinaryReader(File.Open(_infoFile, FileMode.OpenOrCreate)))
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

                    Account account = new Account(num, name, surname, amount, bonus, _gradation);
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
            int pos = (int)FindAccountInFile();
            using (BinaryWriter writer = new BinaryWriter(File.Open(_infoFile, FileMode.OpenOrCreate)))
            {
                writer.Seek(pos, SeekOrigin.Begin);
                writer.Write(Number);
                writer.Write(OwnerName);
                writer.Write(OwnerSurname);
                writer.Write(Amount);
                writer.Write(_bonus);
                writer.Write(_gradation.GetGradation());
            }
        }
    }
}
