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

        [TestCase(null)]
        [TestCase("")]
        [TestCase("           ")]
        public void CreatingTransactionWithEmpySenderShouldTrownAnException(string sender)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                ITransaction transaction = new Transaction(5, TransactionStatus.Aborted, sender, "Pesho", 50);
            }, "Sender name cannot be null or whitespace string!");
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("           ")]
        public void CreatingTransactionWithEmpyReceiverShouldTrownAnException(string receiver)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                ITransaction transaction = new Transaction(5, TransactionStatus.Aborted, receiver, "Pesho", 50);
            }, "Receiver name cannot be null or whitespace string!");
        }

        [TestCase(-1000)]
        [TestCase(-1)]
        [TestCase(-0.0000000001)]
        [TestCase(0)]
        public void CreatingTransactionWithZeroOrNegativeAmountShouldTrownAnException(decimal amount)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                ITransaction transaction = new Transaction(5, TransactionStatus.Aborted, "Gosho", "Pesho", amount);
            }, "Transaction amount must be a positive amount!");
        }


    }
}
