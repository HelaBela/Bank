using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Bank
{
    public class BankAccount
    {
        public string BankName { get; }
        
        public string AccountNumber { get; }

        public DateTime CreatedDate { get; }

        public  double Balance => _transactions.Sum(transaction => transaction.Amount);

        public Person Owner { get; }
        
        private readonly List<Transaction> _transactions;

        public BankAccount(string bankName, string accountNumber, int initialDeposit, Person owner)
        {
            if (initialDeposit < 0)
            {
                throw new Exception("Cant make an account with a negative deposit");
            }

            Owner = owner;
            CreatedDate = DateTime.Now;
            BankName = bankName;
            AccountNumber = accountNumber;
            _transactions = new List<Transaction>();

            if (initialDeposit > 0)
            {
                MakeTransaction(initialDeposit, CreatedDate, "initial deposit");
            }
        }

        public string GenerateBankStatement( DateTime fromDate, DateTime toDate)
        {
            var transactionsToShow = _transactions
                .Where(transaction => transaction.TransactionDate > fromDate && transaction.TransactionDate < toDate)
                .OrderBy(transaction => transaction.TransactionDate);
            
            var bankStatement = "Bank Name: " + BankName + Environment.NewLine +
                                   "Account number: " + AccountNumber + Environment.NewLine +
                                   "Created Date: " + CreatedDate + Environment.NewLine +
                                   "Client's name: " + Owner.Name + Environment.NewLine +
                                   "Client's Address: " + Owner.Address + Environment.NewLine +
                                   "Client's Age: " + Owner.Age + Environment.NewLine +
                                   "Client's Date of birth: " + Owner.DateOfBirth + Environment.NewLine +
                                   "Client's Email: " + Owner.Email + Environment.NewLine +
                                   "Balance: $" + Balance + Environment.NewLine +
                                   "Transactions from: " + fromDate + " to: " + toDate  + Environment.NewLine;

            foreach (var transaction in transactionsToShow)
            {
                bankStatement += transaction.TransactionDate.ToString(CultureInfo.InvariantCulture) + " $" +
                                 transaction.Amount + " " + transaction.Note + " " + transaction.ExternalAccountNumber +
                                 Environment.NewLine;
            }


            return bankStatement;
        }

        public void UpdateClientsDetails(string name, string address, string email)
        {
            Owner.Name = name;
            Owner.Address = address;
            Owner.Email = email;
        }


        public void MakeTransaction(double amount, DateTime time, string note, BankAccount externalBankAcc = null)
        {
            if (externalBankAcc != null)
            {
                MakeTransfer(amount, time, note, externalBankAcc);
            }
            else
            {
                if (amount < 0)
                {
                    MakeWithdrawal(amount, time, note);
                }
                else
                {
                    MakeDeposit(amount, time, note);
                }
            }
        }

        private bool BelongsToBank(string bankName)
        {
            return BankName == bankName;
        }

        private void MakeDeposit(double amount, DateTime time, string note)
        {
            var transaction = new Transaction(TransactionType.Deposit, amount, time, "", note);
            _transactions.Add(transaction);
        }

        private void MakeWithdrawal(double amount, DateTime time, string note)
        {
            if (amount * -1 > Balance)
            {
                throw new Exception("not enough money on the account to withdrawal");
            }

            var transaction = new Transaction(TransactionType.Withdrawal, amount, time, "", note);
            _transactions.Add(transaction);
        }

        private void MakeTransfer(double amount, DateTime time, string note, BankAccount externalBankAcc)
        {
            if (amount > Balance)
            {
                throw new Exception("not enough money on the account to transfer");
            }

            var totalToDeduct = amount;

            if (!externalBankAcc.BelongsToBank(BankName))
            {
                totalToDeduct = amount * 1.1;

            }

            var transaction = new Transaction(TransactionType.Transfer, totalToDeduct * -1, time, externalBankAcc.AccountNumber, note);
            _transactions.Add(transaction);
            
            externalBankAcc.MakeTransaction(amount, time, note);
        }
        
        
    }
}



