using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Bank
{
    public class BankAccount
    {
        public string BankName { get; }
        public string AccountNumber { get; }

        public DateTime CreatedDate { get; }
        public int Balance { get; }
        
        public Person Owner { get; }

        public List<Transaction> Transactions { get;}

        public BankAccount(string bankName, string accountNumber, int initialDeposit, Person owner)
        {
            
            Owner = owner;
            CreatedDate = DateTime.Now;
            BankName = bankName;
            AccountNumber = accountNumber;
            Balance = initialDeposit;
            Transactions = new List<Transaction>();

            if (initialDeposit > 0)
            {
                Balance = initialDeposit;
                Transactions.Add(new Transaction(TransactionType.Deposit , initialDeposit, DateTime.Now, null));
            }
            else if (initialDeposit < 0)
            {
                throw new Exception("cant have minus balance at start");
            }
        }

        public string GenerateBankStatement()
        {
            string bankStatement = "Bank Name: " + BankName + Environment.NewLine +
                                   "Account number:" + AccountNumber + Environment.NewLine +
                                   "Created Date:" + CreatedDate + Environment.NewLine +
                                   "Client's name:" + Owner.Name + Environment.NewLine +
                                   "Client's Address:" + Owner.Address + Environment.NewLine +
                                   "Client's Age:" + Owner.Age + Environment.NewLine +
                                   "Client's Email: " + Owner.Email + Environment.NewLine +
                                   "Balance: " + Balance + Environment.NewLine +
                                   "transactions: " + Transactions;
            foreach (var transaction in Transactions)
            {
                bankStatement += transaction;
            }


            return bankStatement;
        }
    }
}