using System;

namespace Bank
{
    public class Transaction
    {
        private TransactionType TransactionType { get; }
        public int Amount { get; }
        public DateTime TransactionDate { get; }
        private string ExternalAccountNumber { get; }

        public Transaction(TransactionType transactionType, int amount, DateTime transactionDate, string externalAccountNumber)
        {
            TransactionDate = transactionDate;
            Amount = amount;
            TransactionDate = transactionDate;
            ExternalAccountNumber = externalAccountNumber;
        }

       
    }

    public enum TransactionType
    {
        Deposit,
        Withdrawal,
        Transfer
    }
}