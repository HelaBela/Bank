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
            var bankAccTwo = new BankAccount("ANZ", "4567892", 30, clientTwo);

            bankAccTwo.MakeTransaction(20, DateTime.Now, "beer money", bankAcc);
            bankAcc.MakeTransaction(20, new DateTime(2001, 09, 12),"something" );

            Console.WriteLine(bankAcc.GenerateBankStatement(new DateTime(2013, 03, 03 ),new DateTime(2020, 03,03 ) ));
            Console.WriteLine(bankAccTwo.GenerateBankStatement(new DateTime(2015, 03, 03 ),new DateTime(2016, 03,03 ) ));
        }
    }
}