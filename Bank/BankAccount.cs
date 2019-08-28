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

        public List<Transaction> Transactions { get;}

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
            
            //Transaction initialTransaction = new Transaction(TransactionType.Deposit, initialDeposit, CreatedDate, "");
            //Transactions.Add(initialTransaction);
            MakeDeposit(initialDeposit, CreatedDate);
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
            foreach (var item in Transactions)
            {
                //Balance += item.AmountTransffered; //?
            }


            return bankStatement;
        }

        public void MakeDeposit(int amount, DateTime time)
        {
            Transaction transaction = new Transaction(TransactionType.Deposit, amount, time, "" );
            Transactions.Add(transaction);
        }
    }
}