using System;
using Bank;
using NUnit.Framework;


namespace Tests
{
    public class BankAccountTest
    {
        private BankAccount _testAccount;
        private BankAccount _testAccount2;
        [SetUp]
        public void Setup()
        {
            _testAccount = new BankAccount("citi", "209345", 49, new Person("tom", "3AddisonRD", new DateTime(1985, 07, 21),"e@gm.com"));
            _testAccount2 = new BankAccount("hdf", "202245", 20, new Person("alex", "3bunnST", new DateTime(2000, 07, 21), "a@gm.com"));
        }

        [Test]
        public void CanCreateBankAccount()
        {//arrange act assert
            Assert.IsNotNull(_testAccount);
        }
        
        [Test]
        public void CanShowBalance()
        {

            var balance = _testAccount.Balance; //act

            Assert.AreEqual(49, balance);

        }

        [Test]
        public void CannotCreateAccountWithNegativeBalance()
        {
            Assert.Throws<Exception>(() => new BankAccount("citi", "209345", -1, new Person("tom", "3AddisonRD", new DateTime(1985, 07, 21), "e@gm.com")));
            
        }
        
        [Test]
        public void CanCreateAccountWithBalanceZero()
        {
            var testAccountWithZeroBalance = new BankAccount("citi", "209345", 0, new Person("tom", "3AddisonRD", new DateTime(1985, 07, 21), "e@gm.com"));

            var balance = testAccountWithZeroBalance.Balance; //act

            Assert.AreEqual(0, balance);

        }

        [Test]
        public void CanMakeDeposit()
        {
            _testAccount.MakeTransaction(10, DateTime.Now, "");
            
            var balance = _testAccount.Balance; //act
            
            Assert.AreEqual(59, balance);
            
        }
        
        [Test]
        public void CanMakeWithdrawal()
        {
            _testAccount.MakeTransaction(-10, DateTime.Now, "");
            
            var balance = _testAccount.Balance; //act
            
            Assert.AreEqual(39, balance);
            
        }
        
          
        [Test]
        public void CanMakeTransferAndUpdateSourceBalance()
        {
            _testAccount.MakeTransaction(40, DateTime.Now, "" , _testAccount2 );
            
            var balance = _testAccount.Balance; //act

            Assert.AreEqual(9, balance); 

        }
        
        [Test]
        public void CanMakeTransferAndUpdateTheReceiverBalance()
        {
            _testAccount.MakeTransaction(40, DateTime.Now, "", _testAccount2 );
            
            var balance = _testAccount2.Balance; //act
            
            Assert.AreEqual(60, balance);
            
        }
        
        [Test]
        public void CanNotMakeTransferBiggerThanBalance()
        {
            
            
            Assert.Throws<Exception>(() =>  _testAccount.MakeTransaction(2340, DateTime.Now, "", _testAccount2 ));
            
        }
    }
}