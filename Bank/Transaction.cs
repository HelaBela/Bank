using System;

namespace Bank
{
    public class Transaction
    {
        private TransactionType TransactionType { get; }
        public int AmountTransffered { get; set; }
        public DateTime TransactionDate { get; }
        private string ExternalAccountNumber { get; }

        public Transaction(TransactionType transactionType, int amountTransffered, DateTime transactionDate, string externalAccountNumber)
        {
            TransactionDate = transactionDate;
            AmountTransffered = amountTransffered;
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