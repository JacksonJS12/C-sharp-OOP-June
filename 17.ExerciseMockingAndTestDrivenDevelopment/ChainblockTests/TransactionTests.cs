namespace Chainblock.Tests
{
    using System;

    using NUnit.Framework;

    using Contracts;
    using Models;

    [TestFixture]
    public class TransactionTests
    {
        [Test]
        public void ConstructorShouldInitializeTransactionCorrectly()
        {
            int expectedId = 1;
            TransactionStatus expectedStatus = TransactionStatus.Successful;
            string expectedSender = "Pesho";
            string expectedReceiver = "Gosho";
            decimal expectedAmount = 50m;

            ITransaction transaction = 
                new Transaction(expectedId, expectedStatus, expectedSender, expectedReceiver, expectedAmount);

            Assert.AreEqual(expectedId, transaction.Id);
            Assert.AreEqual(expectedStatus, transaction.Status);
            Assert.AreEqual(expectedSender, transaction.From);
            Assert.AreEqual(expectedReceiver, transaction.To);
            Assert.AreEqual(expectedAmount, transaction.Amount);
        }

    }
}
