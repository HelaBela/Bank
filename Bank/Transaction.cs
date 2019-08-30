using System;

namespace Bank
{
    public class Transaction
    {
        private TransactionType TransactionType { get; }
        public double Amount { get; }
        public DateTime TransactionDate { get; }
        public string ExternalAccountNumber { get; }

        public string Note { get; }

        public Transaction(TransactionType transactionType, double amount, DateTime transactionDate,
            string externalAccountNumber, string note)
        {
            TransactionDate = transactionDate;
            Amount = amount;
            TransactionDate = transactionDate;
            ExternalAccountNumber = externalAccountNumber;
            Note = note;
            TransactionType = transactionType;
        }
    }
}