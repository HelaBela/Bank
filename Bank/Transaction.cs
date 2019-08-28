using System;

namespace Bank
{
    public class Transaction
    {
        private TransactionType TransactionType { get; }
        public int Amount { get; }
        public DateTime TransactionDate { get; }
        public string ExternalAccountNumber { get; }

        public string Note { get; }

        public Transaction(TransactionType transactionType, int amount, DateTime transactionDate, string externalAccountNumber, string note)
        {
            TransactionDate = transactionDate;
            Amount = amount;
            TransactionDate = transactionDate;
            ExternalAccountNumber = externalAccountNumber;
            Note = note;
        }

       
    }

    public enum TransactionType
    {
        Deposit,
        Withdrawal,
        Transfer
    }
}