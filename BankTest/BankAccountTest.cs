using System;
using Bank;
using NUnit.Framework;


namespace Tests
{
    public class BankAccountTest
    {
        private BankAccount testAccount;
        private BankAccount testAccount2;
        [SetUp]
        public void Setup()
        {
            testAccount = new BankAccount("citi", "209345", 49, new Person("tom", "3AddisonRD", 32, "e@gm.com"));
            testAccount2 = new BankAccount("hdf", "202245", 20, new Person("alex", "3bunnST", 22, "a@gm.com"));
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
            testAccount.MakeTransaction(10, DateTime.Now, "");
            
            var balance = testAccount.Balance; //act
            
            Assert.AreEqual(59, balance);
            
        }
        
        [Test]
        public void CanMakeWithdrawal()
        {
            testAccount.MakeTransaction(-10, DateTime.Now, "");
            
            var balance = testAccount.Balance; //act
            
            Assert.AreEqual(39, balance);
            
        }
        
          
        [Test]
        public void CanMakeTransferAndUpdateSourceBalance()
        {
            testAccount.MakeTransaction(40, DateTime.Now, "" , testAccount2 );
            
            var balance = testAccount.Balance; //act

            Assert.AreEqual(9, balance); 

        }
        
        [Test]
        public void CanMakeTransferAndUpdateTheReceiverBalance()
        {
            testAccount.MakeTransaction(40, DateTime.Now, "", testAccount2 );
            
            var balance = testAccount2.Balance; //act
            
            Assert.AreEqual(60, balance);
            
        }
        
        [Test]
        public void CanNotMakeTransferBiggerThanBalance()
        {
            
            
            Assert.Throws<Exception>(() =>  testAccount.MakeTransaction(2340, DateTime.Now, "", testAccount2 ));
            
        }
    }
}