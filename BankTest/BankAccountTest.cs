using System;
using Bank;
using NUnit.Framework;


namespace Tests
{
    public class BankAccountTest
    {
        private BankAccount testAccount;
        [SetUp]
        public void Setup()
        {
            testAccount = new BankAccount("citi", "209345", 49, new Person("tom", "3AddisonRD", 32, "e@gm.com"));
        }

        [Test]
        public void CanCreateBankAccount()
        {//arrange act assert
            Assert.IsNotNull(testAccount);
        }
        
        [Test]
        public void CanShowBalance()
        {

            var balance = testAccount.Balance; //act

            Assert.AreEqual(49, balance);

        }

        [Test]
        public void CannotCreateAccountWithNegativeBalance()
        {
            Assert.Throws<Exception>(() => new BankAccount("citi", "209345", -1, new Person("tom", "3AddisonRD", 32, "e@gm.com")));
            
        }
        
        [Test]
        public void CanCreateAccountWithBalanceZero()
        {
            BankAccount testAccountWithZeroBalance = new BankAccount("citi", "209345", 0, new Person("tom", "3AddisonRD", 32, "e@gm.com"));

            var balance = testAccountWithZeroBalance.Balance; //act

            Assert.AreEqual(0, balance);

        }

        [Test]
        public void CanMakeDeposit()
        {
            testAccount.MakeDeposit(10, DateTime.Now);
            
            var balance = testAccount.Balance; //act
            
            Assert.AreEqual(59, balance);
            
        }
    }
}