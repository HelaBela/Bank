using System;

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            var clientOne = new Person("Tom", "8 AddisonRd", 34, "t@dt.com");
            var bankAcc = new BankAccount("Citi", "0332453", 90, clientOne); 
           bankAcc.MakeDeposit(20, DateTime.Now, "salary");
           
           
           var clientTwo = new Person("Alex", "4 BunnSt", 22, "a@fm.com");
           var bankAccTwo = new BankAccount("west", "4567892", 30, clientTwo);
           
           bankAccTwo.TransferMoney(20, bankAcc, DateTime.Now, "beer money"); 
           
           Console.WriteLine(bankAcc.GenerateBankStatement());
           Console.WriteLine(bankAccTwo.GenerateBankStatement());
           
           
        }
    }
}