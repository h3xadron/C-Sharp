using System;
using System.Collections.Generic;
using System.Linq;
using INNZ0S_HFT_2022231.Models.Entities;
using ConsoleTools;

namespace INNZ0S_HFT_2022231.Client
{
    internal class Program
    {
        static List<string> AccountFields = new List<string>() 
        {"Account_Id","Client_Id","AccountSum","DebitCard","DebitLimit","CreditCard","CreditLimit","CreditType","DebitType"};
        static List<string> TransactionFields = new List<string>()
        {"Transaction_Id","Account_Id","CreditTransactionTime","CreditTransaction","DebitTransactionTime","DebitTransaction","CashTime","Cash"};
        static List<string> ClientFields = new List<string>()
        {"Id","Name","Address","MotherName","State","City","BirthDate","MobilNumber"};
        static void Main(string[] args)
        {
            var httpServicea = new HttpService("Account", new Uri("http://localhost:63809/api/"));
            var httpServicet = new HttpService("Transaction", new Uri("http://localhost:63809/api/"));
            var httpServicec = new HttpService("Client", new Uri("http://localhost:63809/api/"));

            var transSub = new ConsoleMenu(args, level: 1)
                .Add("ReadAll", () => Show(httpServicet.GetAll<Transaction>()))
                .Add("Read",() => Show(httpServicet.Get<Transaction,int>(GetId())))
                .Add("Delete", () => httpServicet.Delete(GetId()))
                .Add("Create", () => httpServicet.Create(GetTransaction(GetData(TransactionFields))))
                .Add("Update", () => httpServicet.Update(GetTransaction(GetData(TransactionFields))))
                .Add("Transactions Without Creditcard", () => Show(httpServicet.GetAll<Transaction>("TransactionsWithoutCreditCard")))
                .Add("Back", ConsoleMenu.Close)
                .Configure(config =>
                {
                    config.Selector = "--> ";
                    config.Title = "Transaction Menu";
                    config.EnableBreadcrumb = true;
                    config.WriteBreadcrumbAction = titles => Console.WriteLine(string.Join(" / ", titles));
                });

            var accountSub = new ConsoleMenu(args, level: 1)
                .Add("ReadAll", () => Show(httpServicea.GetAll<Account>()))
                .Add("Read", () => Show(httpServicea.Get<Account, int>(GetId())))
                .Add("Delete", () => httpServicea.Delete(GetId()))
                .Add("Create", () => httpServicea.Create(GetAccount(GetData(AccountFields))))
                .Add("Update", () => httpServicea.Update(GetAccount(GetData(AccountFields))))
                .Add("Accounts made by Texan Clients", () => Show(httpServicea.GetAll<Account>("TexanClients")))
                .Add("Back", ConsoleMenu.Close)
                .Configure(config =>
                {
                    config.Selector = "--> ";
                    config.Title = "Account menu";
                    config.EnableBreadcrumb = true;
                    config.WriteBreadcrumbAction = titles => Console.WriteLine(string.Join(" / ", titles));
                    
                });

            var clientSub = new ConsoleMenu(args, level: 1)
                .Add("ReadAll", () => Show(httpServicec.GetAll<INNZ0S_HFT_2022231.Models.Entities.Client>()))
                .Add("Read", () => Show(httpServicec.Get<INNZ0S_HFT_2022231.Models.Entities.Client, int>(GetId())))
                .Add("Delete", () => httpServicec.Delete(GetId()))
                .Add("Create", () => httpServicec.Create(GetClient(GetData(ClientFields))))
                .Add("Update", () => httpServicec.Update(GetClient(GetData(ClientFields))))
                .Add("Clients sorted by account balance (desc)", () => Show(httpServicec.GetAll<INNZ0S_HFT_2022231.Models.Entities.Client>("ClientsWithTheMostMoney")))
                .Add("Clients with more accounts", () => Show(httpServicec.GetAll<INNZ0S_HFT_2022231.Models.Entities.Client>("ClientsWithMoreAccounts")))
                .Add("Clients who made transactions this month", () => Show(httpServicec.GetAll<INNZ0S_HFT_2022231.Models.Entities.Client>("ThisMonthTransaction")))
                .Add("Back", ConsoleMenu.Close)
                .Configure(config =>
                {
                    config.Selector = "--> ";
                    config.Title = "Client menu";
                    config.EnableBreadcrumb = true;
                    config.WriteBreadcrumbAction = titles => Console.WriteLine(string.Join(" / ", titles));
                });

            var menu = new ConsoleMenu(args, level:0)
                .Add("Transaction Table", transSub.Show)
                .Add("Account Table", accountSub.Show)
                .Add("Client Table", clientSub.Show)
                .Add("Exit", () => Environment.Exit(0))
                .Configure(config =>
                {
                    config.Selector = "--> ";
                    config.Title = "Main menu";
                    config.EnableWriteTitle = true;
                });

            menu.Show();
        }
        static void Show(IEnumerable<Transaction> input)
        {
            foreach (var item in input)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("Press Enter");
            Console.ReadLine();
        }
        static void Show(Transaction input)
        {
            Console.WriteLine(input.ToString());
            Console.WriteLine("Press Enter");
            Console.ReadLine();
        }
        static void Show(IEnumerable<Account> input)
        {
            foreach (var item in input)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("Press Enter");
            Console.ReadLine();
        }
        static void Show(Account input)
        {

            Console.WriteLine(input.ToString());
            Console.WriteLine("Press Enter");
            Console.ReadLine();
        }
        static void Show(IEnumerable<INNZ0S_HFT_2022231.Models.Entities.Client> input)
        {
            foreach (var item in input)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("Press Enter");
            Console.ReadLine();
        }
        static void Show(INNZ0S_HFT_2022231.Models.Entities.Client input)
        {
            Console.WriteLine(input.ToString());
            Console.WriteLine("Press Enter");
            Console.ReadLine();
        }
        static int GetId()
        {
            Console.Write("Id of item: ");
            return int.Parse(Console.ReadLine());
        }
        static List<string> GetData(List<string> fields)
        {
            List<string> temp = new List<string>();
            for (int i = 0; i < fields.Count; i++)
            {
                Console.Write(fields.ElementAt(i) + ": ");
                temp.Add(Console.ReadLine());
            }

            return temp;
        }
        static Transaction GetTransaction(List<string> data)
        {
            return new Transaction
            {
                Transaction_Id = int.Parse(data[0]),
                Account_Id = int.Parse(data[1]),
                CreditTransactionTime = DateTime.Parse(data[2]),
                CreditTransaction = int.Parse(data[3]),
                DebitTransactionTime = DateTime.Parse(data[4]),
                DebitTransaction = int.Parse(data[5]),
                CashTime = DateTime.Parse(data[6]),
                Cash = int.Parse(data[7])
            };
        }
        static Account GetAccount(List<string> data)
        {
            return new Account
            {
                Account_Id = int.Parse(data[0]),
                Client_Id = int.Parse(data[1]),
                AccountSum = double.Parse(data[2]),
                DebitCard = bool.Parse(data[3]),
                DebitLimit = double.Parse(data[4]),
                CreditCard = bool.Parse(data[5]),
                CreditLimit = double.Parse(data[6]),
                CreditType = (Account.CreditCurrencyType)int.Parse(data[7]),
                DebitType = (Account.DebitCurrencyType)int.Parse(data[8])
            };
        }

        static INNZ0S_HFT_2022231.Models.Entities.Client GetClient(List<string> data)
        {
            return new INNZ0S_HFT_2022231.Models.Entities.Client
            {
                Id = int.Parse(data[0]),
                Name = data[1],
                MotherName = data[2],
                State = data[3],
                City = data[4],
                Address = data[5],
                BirthDate = DateTime.Parse(data[6]),
                MobilNumber = long.Parse(data[7])
            };
        }

    }
}
