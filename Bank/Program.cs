using System;

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            var clientOne = new Person("Tom", "8AddisonRd", 34, "t@dt.com");
            var bankAcc = new BankAccount("Citi", "0332453", 90, clientOne); 
            var firstTransaction = new Transaction(TransactionType.Transfer, 2000, DateTime.Now, "234432");
            
            Console.WriteLine(bankAcc.GenerateBankStatement());
        }
    }
}