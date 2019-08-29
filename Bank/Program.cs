using System;

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            var clientOne = new Person("Tom", "8 AddisonRd", new DateTime(1985, 07, 21), "t@dt.com");
            var bankAcc = new BankAccount("Citi", "0332453", 90, clientOne);
            bankAcc.MakeTransaction(20, DateTime.Now, "salary");
            bankAcc.UpdateClientsDetails("Thomas", "sdsds", "d@fd.com");


            var clientTwo = new Person("Alex", "4 BunnSt", new DateTime(1994, 11, 10), "a@fm.com");
            var bankAccTwo = new BankAccount("west", "4567892", 30, clientTwo);

            bankAccTwo.MakeTransaction(20, DateTime.Now, "beer money", bankAcc);

            Console.WriteLine(bankAcc.GenerateBankStatement());
            Console.WriteLine(bankAccTwo.GenerateBankStatement());
        }
    }
}