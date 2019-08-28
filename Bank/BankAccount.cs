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

            if (initialDeposit > 0)
            {
                MakeDeposit(initialDeposit, CreatedDate, "inital deposit");
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
                                   "Balance: $" + Balance + Environment.NewLine +
                                   "transactions: " + Environment.NewLine;
            
            foreach (Transaction transaction in Transactions)
            {
                bankStatement += transaction.TransactionDate.ToString(CultureInfo.InvariantCulture) + " $" +
                                 transaction.Amount + " " + transaction.Note + " " + transaction.ExternalAccountNumber +
                                 Environment.NewLine;
            }


            return bankStatement;
        }

        public void MakeDeposit(int amount, DateTime time, string note)
        {
            Transaction deposit = new Transaction(TransactionType.Deposit, amount, time, "" , note);
            Transactions.Add(deposit);
        }
        
        public void MakeWithdrawal(int amount, DateTime time, string note)
        {
            amount *= -1;
            Transaction withdrawal = new Transaction(TransactionType.Withdrawal, amount, time, "", note );
            Transactions.Add(withdrawal);
        }

        public void TransferMoney(int amount, BankAccount destinationBankAcc,  DateTime time, string note)
        {
            if ( amount > Balance)
            {
               throw new Exception("not enough money on the account");
            }

            
            Transaction source = new Transaction(TransactionType.Transfer, amount * -1, time, destinationBankAcc.AccountNumber, note);
            Transactions.Add(source);
            
            Transaction destination = new Transaction(TransactionType.Transfer, amount, time, AccountNumber, note);
            destinationBankAcc.Transactions.Add(destination);
        }
        
    }
}