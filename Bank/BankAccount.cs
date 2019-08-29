using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;

namespace Bank
{
    public class BankAccount
    {
        public string BankName { get; }
        public string AccountNumber { get; }

        public DateTime CreatedDate { get; }
        public int Balance {
            get
            {
                var total = 0;
                foreach (Transaction transaction in Transactions)
                {
                    total += transaction.Amount;
                }

                return total;
            }
        }


        public Person Owner { get; }

        private List<Transaction> Transactions;

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
            Transactions = new List<Transaction>();

            if (initialDeposit > 0)
            {
                MakeTransaction(initialDeposit, CreatedDate, "inital deposit");
            }
        }

        public string GenerateBankStatement()
        {
            string bankStatement = "Bank Name: " + BankName + Environment.NewLine +
                                   "Account number: " + AccountNumber + Environment.NewLine +
                                   "Created Date: " + CreatedDate + Environment.NewLine +
                                   "Client's name: " + Owner.Name + Environment.NewLine +
                                   "Client's Address: " + Owner.Address + Environment.NewLine +
                                   "Client's Age: " + Owner.Age + Environment.NewLine +
                                   "Client's Email: " + Owner.Email + Environment.NewLine +
                                   "Balance: $" + Balance + Environment.NewLine +
                                   "Transactions: " + Environment.NewLine;
            
            foreach (Transaction transaction in Transactions)
            {
                bankStatement += transaction.TransactionDate.ToString(CultureInfo.InvariantCulture) + " $" +
                                 transaction.Amount + " " + transaction.Note + " " + transaction.ExternalAccountNumber +
                                 Environment.NewLine;
            }


            return bankStatement;
        }

        public void MakeTransaction(int amount, DateTime time, string note, BankAccount externalBankAcc = null)
        {
            if (externalBankAcc != null)
            {
                MakeTransfer(amount, time, note, externalBankAcc);
            }
            else
            {
                if (amount < 0)
                {
                    MakeWithdrawl(amount, time, note);
                }
                else
                {
                    MakeDeposit(amount, time, note);
                }
            }
            
        }
        
        private void MakeDeposit(int amount, DateTime time, string note)
        {

            Transaction transaction = new Transaction(TransactionType.Deposit, amount, time, "", note);
            Transactions.Add(transaction);
        }
        
        private void MakeWithdrawl(int amount, DateTime time, string note)
        {
            TransactionType transactionType;
            if (amount * -1 > Balance)
            {
                throw new Exception("not enough money on the account to withdraw");
            }

            Transaction transaction = new Transaction(TransactionType.Withdrawal, amount, time, "", note);
            Transactions.Add(transaction);
        }

        private void MakeTransfer(int amount, DateTime time, string note, BankAccount externalBankAcc)
        {
            if (amount > Balance)
            {
                throw new Exception("not enough money on the account to transfer");
            }

            Transaction transaction =
                new Transaction(TransactionType.Transfer, amount * -1, time, externalBankAcc.AccountNumber, note);
            Transactions.Add(transaction);
            externalBankAcc.MakeTransaction(amount, time, note);
        }
    }
}