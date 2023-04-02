using INNZ0S_HFT_2022231.Logic.Services;
using INNZ0S_HFT_2022231.Models.Entities;
using INNZ0S_HFT_2022231.Repository.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static INNZ0S_HFT_2022231.Models.Entities.Account;

namespace INNZ0S_HFT_2022231.Test
{
    [TestFixture]
    internal class Tests
    {
        static Random rnd = new Random();

        //[Test]
        [TestCaseSource(nameof(TestData))]
        public void AccountByTexan(List<Account> account, List<Client> client, List<Transaction> transaction)
        {
            var accountRepository = new Mock<IAccountRepository>();
            var clientRepository = new Mock<IClientRepository>();
            var transactionRepository = new Mock<ITransactionRepository>();

            accountRepository.Setup(x => x.ReadAll()).Returns(account.AsQueryable());
            clientRepository.Setup(x => x.ReadAll()).Returns(client.AsQueryable());

            var service = new AccountServices(accountRepository.Object, clientRepository.Object, transactionRepository.Object);

            var result = service.AccountsMadeByTexanClient();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(3));
        }

        [TestCaseSource(nameof(TestData))]
        public void TransactionsWithoutCreditCard(List<Account> account, List<Client> client, List<Transaction> transaction)
        {
            var accountRepository = new Mock<IAccountRepository>();
            var transactionRepository = new Mock<ITransactionRepository>();

            accountRepository.Setup(x => x.ReadAll()).Returns(account.AsQueryable());
            transactionRepository.Setup(x => x.ReadAll()).Returns(transaction.AsQueryable());

            var service = new TransactionServices(transactionRepository.Object, accountRepository.Object);

            var result = service.TransactionsWithoutCreditCard();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(5));
            Assert.That(result.FirstOrDefault().Transaction_Id, Is.EqualTo(1));
        }

        [TestCaseSource(nameof(TestData))]
        public void ClientsSortedByMostMoney(List<Account> account, List<Client> client, List<Transaction> transaction)
        {
            var accountRepository = new Mock<IAccountRepository>();
            var clientRepository = new Mock<IClientRepository>();
            var transactionRepository = new Mock<ITransactionRepository>();

            accountRepository.Setup(x => x.ReadAll()).Returns(account.AsQueryable());
            clientRepository.Setup(x => x.ReadAll()).Returns(client.AsQueryable());
            transactionRepository.Setup(x => x.ReadAll()).Returns(transaction.AsQueryable());

            var service = new ClientServices(clientRepository.Object,accountRepository.Object,transactionRepository.Object);

            var result = service.ClientsSortedByMostMoney();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.FirstOrDefault().Name == "E");
        }

        [TestCaseSource(nameof(TestData))]
        public void ClientsWithMoreAccounts(List<Account> account, List<Client> client, List<Transaction> transaction)
        {
            var accountRepository = new Mock<IAccountRepository>();
            var clientRepository = new Mock<IClientRepository>();
            var transactionRepository = new Mock<ITransactionRepository>();

            accountRepository.Setup(x => x.ReadAll()).Returns(account.AsQueryable());
            clientRepository.Setup(x => x.ReadAll()).Returns(client.AsQueryable());
            transactionRepository.Setup(x => x.ReadAll()).Returns(transaction.AsQueryable());

            var service = new ClientServices(clientRepository.Object, accountRepository.Object, transactionRepository.Object);

            var result = service.ClientsWithMoreAccounts();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.FirstOrDefault().Id, Is.EqualTo(5));
        }

        [TestCaseSource(nameof(TestData))]
        public void ClientsWithTransactionsInThisMonth(List<Account> account, List<Client> client, List<Transaction> transaction)
        {
            var accountRepository = new Mock<IAccountRepository>();
            var clientRepository = new Mock<IClientRepository>();
            var transactionRepository = new Mock<ITransactionRepository>();

            accountRepository.Setup(x => x.ReadAll()).Returns(account.AsQueryable());
            clientRepository.Setup(x => x.ReadAll()).Returns(client.AsQueryable());
            transactionRepository.Setup(x => x.ReadAll()).Returns(transaction.AsQueryable());

            var service = new ClientServices(clientRepository.Object, accountRepository.Object, transactionRepository.Object);

            var result = service.ClientsWithTransactionsInThisMonth();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.AtLeast(1));
            Assert.That(result.FirstOrDefault().Id, Is.EqualTo(1));
        }
        
        [Test]
        public void ClientCreate()
        {
            var client = new Client(1, "A", "Anderson Her", "TX", "Urbandale", "A street 12. ", new System.DateTime(1968, 02, 26), 4088419485);

            var accountRepository = new Mock<IAccountRepository>();
            var clientRepository = new Mock<IClientRepository>();
            var transactionRepository = new Mock<ITransactionRepository>();

            clientRepository.Setup(x => x.Create(It.IsAny<Client>())).Returns(client);

            var service = new ClientServices(clientRepository.Object, accountRepository.Object, transactionRepository.Object);

            var result = service.Create(client);

            Assert.That(result, Is.SameAs(client));
            clientRepository.Verify(x => x.Create(It.IsAny<Client>()), Times.Once);
        }

        [Test]
        public void AccountCreate()
        {
            var account = new Account(1, 1, 300000, true, 1000, false, 0, CreditCurrencyType.star, DebitCurrencyType.none);
            var client = new Client(1, "A", "Anderson Her", "TX", "Urbandale", "A street 12. ", new System.DateTime(1968, 02, 26), 4088419485);

            var accountRepository = new Mock<IAccountRepository>();
            var clientRepository = new Mock<IClientRepository>();
            var transactionRepository = new Mock<ITransactionRepository>();

            accountRepository.Setup(x => x.Create(It.IsAny<Account>())).Returns(account);
            clientRepository.Setup(x => x.Read(1)).Returns(client);
            var service = new AccountServices(accountRepository.Object, clientRepository.Object,transactionRepository.Object);

            var result = service.Create(account);

            Assert.That(result, Is.SameAs(account));
            accountRepository.Verify(x => x.Create(It.IsAny<Account>()), Times.Once);
        }

        [Test]
        public void TransactionCreate()
        {
            var transaction = new Transaction(1, 1, new System.DateTime(2022, 11, 6), 2000, new System.DateTime((int)rnd.Next(2000, 2023), (int)rnd.Next(1, 12), (int)rnd.Next(1, 30)), 2000, new System.DateTime((int)rnd.Next(2000, 2023), (int)rnd.Next(1, 12), (int)rnd.Next(1, 30)), 20000);
            var account = new Account(1, 1, 300000, true, 1000, false, 0, CreditCurrencyType.star, DebitCurrencyType.none);

            var accountRepository = new Mock<IAccountRepository>();
            var transactionRepository = new Mock<ITransactionRepository>();

            transactionRepository.Setup(x => x.Create(It.IsAny<Transaction>())).Returns(transaction);
            accountRepository.Setup(x => x.Read(1)).Returns(account);

            var service = new TransactionServices(transactionRepository.Object, accountRepository.Object);

            var result = service.Create(transaction);

            Assert.That(result, Is.SameAs(transaction));
            transactionRepository.Verify(x => x.Create(It.IsAny<Transaction>()), Times.Once);
        }

        [Test]
        public void ClientNameError()
        {
            var client = new Client(1, "", "Anderson Her", "TX", "Urbandale", "A street 12. ", new System.DateTime(1968, 02, 26), 4088419485);

            var accountRepository = new Mock<IAccountRepository>();
            var clientRepository = new Mock<IClientRepository>();
            var transactionRepository = new Mock<ITransactionRepository>();

            var service = new ClientServices(clientRepository.Object, accountRepository.Object, transactionRepository.Object);

            var exception = Assert.Throws<ApplicationException>(() => service.Create(client));
            Assert.That(exception.Message, Is.EqualTo("Client's name is required."));
            clientRepository.Verify(x => x.Create(It.IsAny<Client>()), Times.Never);
        }
        [Test]
        public void ClientMotherNameError()
        {
            var client = new Client(1, "A", "", "TX", "Urbandale", "A street 12. ", new System.DateTime(1968, 02, 26), 4088419485);

            var accountRepository = new Mock<IAccountRepository>();
            var clientRepository = new Mock<IClientRepository>();
            var transactionRepository = new Mock<ITransactionRepository>();

            var service = new ClientServices(clientRepository.Object, accountRepository.Object, transactionRepository.Object);

            var exception = Assert.Throws<ApplicationException>(() => service.Create(client));
            Assert.That(exception.Message, Is.EqualTo("Client's mother's name is required."));
            clientRepository.Verify(x => x.Create(It.IsAny<Client>()), Times.Never);
        }

        [Test]
        public void ClientStateNameError()
        {
            var client = new Client(1, "A", "B", "", "Urbandale", "A street 12. ", new System.DateTime(1968, 02, 26), 4088419485);

            var accountRepository = new Mock<IAccountRepository>();
            var clientRepository = new Mock<IClientRepository>();
            var transactionRepository = new Mock<ITransactionRepository>();

            var service = new ClientServices(clientRepository.Object, accountRepository.Object, transactionRepository.Object);

            var exception = Assert.Throws<ApplicationException>(() => service.Create(client));
            Assert.That(exception.Message, Is.EqualTo("State is required."));
            clientRepository.Verify(x => x.Create(It.IsAny<Client>()), Times.Never);
        }
        static IEnumerable<TestCaseData> TestData()
        {
            var result = new List<TestCaseData>();

            var account1 = new Account(1, 1, 300000, true, 1000, false, 0,CreditCurrencyType.star, DebitCurrencyType.none);
            var account2 = new Account(2, 2, 300000, true, 1000, false, 0, CreditCurrencyType.star, DebitCurrencyType.none);
            var account3 = new Account(3, 3, 300000, true, 1000, false, 0, CreditCurrencyType.star, DebitCurrencyType.none);
            var account4 = new Account(4, 4, 300000, false, 1000, false, 0, CreditCurrencyType.star, DebitCurrencyType.none);
            var account5 = new Account(5, 5, 3000000000000, true, 1000, false, 0,CreditCurrencyType.star, DebitCurrencyType.none);
            var account6 = new Account(5, 5, 3000000000000, true, 1000, false, 0, CreditCurrencyType.star, DebitCurrencyType.none);

            var client1 = new Client(1, "A", "Anderson Her", "TX", "Urbandale", "A street 12. ", new System.DateTime(1968, 02, 26), 4088419485);
            var client2 = new Client(2, "B", "Anderson Her", "TX", "Urbandale", "A street 12. ", new System.DateTime(1968, 02, 26), 4088419485);
            var client3 = new Client(3, "C", "Anderson Her", "TX", "Urbandale", "A street 12. ", new System.DateTime(1968, 02, 26), 4088419485);
            var client4 = new Client(4, "D", "Anderson Her", "CA", "Urbandale", "A street 12. ", new System.DateTime(1968, 02, 26), 4088419485);
            var client5 = new Client(5, "E", "Anderson Her", "CA", "Urbandale", "A street 12. ", new System.DateTime(1968, 02, 26), 4088419485);

            var transaction1 = new Transaction(1, 1, DateTime.Now, 2000, new System.DateTime((int)rnd.Next(2000, 2023), (int)rnd.Next(1, 12), (int)rnd.Next(1, 30)), 2000, new System.DateTime((int)rnd.Next(2000, 2023), (int)rnd.Next(1, 12), (int)rnd.Next(1, 30)), 20000);
            var transaction2 = new Transaction(2, 2, new System.DateTime(2022, 11, 6), 2000, new System.DateTime((int)rnd.Next(2000, 2023), (int)rnd.Next(1, 12), (int)rnd.Next(1, 30)), 2000, new System.DateTime((int)rnd.Next(2000, 2023), (int)rnd.Next(1, 12), (int)rnd.Next(1, 30)), 20000);
            var transaction3 = new Transaction(3, 3, new System.DateTime(2022, 11, 6), 2000, new System.DateTime((int)rnd.Next(2000, 2023), (int)rnd.Next(1, 12), (int)rnd.Next(1, 30)), 2000, new System.DateTime((int)rnd.Next(2000, 2023), (int)rnd.Next(1, 12), (int)rnd.Next(1, 30)), 20000);
            var transaction4 = new Transaction(4, 4, new System.DateTime(2022, 11, 6), 2000, new System.DateTime((int)rnd.Next(2000, 2023), (int)rnd.Next(1, 12), (int)rnd.Next(1, 30)), 2000, new System.DateTime((int)rnd.Next(2000, 2023), (int)rnd.Next(1, 12), (int)rnd.Next(1, 30)), 20000);
            var transaction5 = new Transaction(5, 5, new System.DateTime(2022, 11, 6), 2000, new System.DateTime((int)rnd.Next(2000, 2023), (int)rnd.Next(1, 12), (int)rnd.Next(1, 30)), 2000, new System.DateTime((int)rnd.Next(2000, 2023), (int)rnd.Next(1, 12), (int)rnd.Next(1, 30)), 20000);

            result.Add(new TestCaseData(
                new List<Account>() { account1, account2, account3, account4, account5, account6 },
                new List<Client>() { client1, client2, client3, client4, client5 },
                new List<Transaction> { transaction1, transaction2, transaction3, transaction4, transaction5 }
                ));

            return result;
        }
        
    }
}
