using INNZ0S_HFT_2022231.Logic.Interfaces;
using INNZ0S_HFT_2022231.Models.Entities;
using INNZ0S_HFT_2022231.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace INNZ0S_HFT_2022231.Logic.Services
{
    public class ClientServices : IClientServices
    {

        IClientRepository ClientRepository;

        IAccountRepository AccountRepository;

        ITransactionRepository TransactionRepository;

        public ClientServices(IClientRepository clientRepository, IAccountRepository accountRepository, ITransactionRepository transactionRepository)
        {
            ClientRepository = clientRepository;
            AccountRepository = accountRepository;
            TransactionRepository = transactionRepository;
        }


        public Client Create(Client client)
        {
            if (String.IsNullOrEmpty(client.Name))
            {
                throw new ApplicationException("Client's name is required."); 
            }

            if (String.IsNullOrEmpty(client.MotherName))
            {
                throw new ApplicationException("Client's mother's name is required.");
            }

            if (String.IsNullOrEmpty(client.State))
            {
                throw new ApplicationException("State is required.");
            }

            if (String.IsNullOrEmpty(client.City))
            {
                throw new ApplicationException("City is required.");
            }

            if (String.IsNullOrEmpty(client.Address))
            {
                throw new ApplicationException("Address is required.");
            }

            if (String.IsNullOrEmpty(client.BirthDate.ToString()))
            {
                throw new ApplicationException("Birthdate is required.");
            }

            var maxLength = 747;

            if (client.Name.Length > maxLength)
            {
                throw new ApplicationException($"The client's name max length is {maxLength}!");
            }

            if (client.MotherName.Length > maxLength)
            {
                throw new ApplicationException($"The client's mother's name max length is {maxLength}!");
            }

            var result = ClientRepository.Create(client);

            return result;

        }
        public void Delete(int id)
        {
            if (ClientRepository.Read(id) == null)
            {
                throw new ApplicationException("Not valid id or ");
            }



            var Account_temp = AccountRepository.ReadAll().Where(t => t.Client_Id == id);
            


            if (Account_temp.Count() != 0)
            {
                throw new ApplicationException("There are still remaining accounts assigned to the Client");
            
            }

        
            ClientRepository.Delete(id);
        }

        public Client Read(int id)
        {
            var result = ClientRepository.Read(id);
            return result;
        }

        public List<Client> ReadAll()
        {
            return ClientRepository.ReadAll().ToList();
        }

        public Client Update(Client client)
        {


            if (String.IsNullOrEmpty(client.Name))
            {
                throw new ApplicationException("Client's name is required.");
            }

            if (String.IsNullOrEmpty(client.MotherName))
            {
                throw new ApplicationException("Client's mother's name is required.");
            }

            if (String.IsNullOrEmpty(client.State))
            {
                throw new ApplicationException("State is required.");
            }

            if (String.IsNullOrEmpty(client.City))
            {
                throw new ApplicationException("City is required.");
            }

            if (String.IsNullOrEmpty(client.Address))
            {
                throw new ApplicationException("Address is required.");
            }

            if (String.IsNullOrEmpty(client.BirthDate.ToString()))
            {
                throw new ApplicationException("Birthdate is required.");
            }

            var maxLength = 747;

            if (client.Name.Length > maxLength)
            {
                throw new ApplicationException($"The client's name max length is {maxLength}!");
            }

            if (client.MotherName.Length > maxLength)
            {
                throw new ApplicationException($"The client's mother's name max length is {maxLength}!");
            }

            var temp = ClientRepository.Read(client.Id);
            temp.Address = client.Address; 
            temp.State = client.State;
            temp.City = client.City;    
            temp.MobilNumber = client.MobilNumber;  
            var result = ClientRepository.Update(temp);
            return result;
                
        }
        public IEnumerable<Client> ClientsSortedByMostMoney()
        {
            var result = from client in ClientRepository.ReadAll()
                         join account in AccountRepository.ReadAll()
                         on client.Id equals account.Client_Id
                         into clientWithAccountBalance
                         from account in clientWithAccountBalance.DefaultIfEmpty()
                         select new
                         { 
                            Client_Id = client.Id,
                            AccountBalance = account.AccountSum
                         };
            var groupedByClient = result.GroupBy(x => x.Client_Id).Select(x => new
            { 
                Client_Id = x.Key,
                AccountBalance = x.Sum(y => y.AccountBalance)
            });

            var sortedByBalance = groupedByClient.OrderByDescending(x => x.AccountBalance);

            var resultFinal = from sorted in sortedByBalance
                              join client in ClientRepository.ReadAll()
                              on sorted.Client_Id equals client.Id
                              select new Client
                              {
                                  Id = sorted.Client_Id,
                                  State = client.State,
                                  Address = client.Address,
                                  BirthDate = client.BirthDate,
                                  City = client.City,
                                  MobilNumber = client.MobilNumber,
                                  MotherName = client.MotherName,
                                  Name = client.Name,
                              };

            return resultFinal.ToList();
        }

        public IEnumerable<Client> ClientsWithMoreAccounts()
        {
            var result = ClientRepository.ReadAll().Where(t => AccountRepository.ReadAll().Where(n => n.Client_Id == t.Id).Count() > 1);
            return result; 
        }

        public IEnumerable<Client> ClientsWithTransactionsInThisMonth()
        {

            var tempResult = from client in ClientRepository.ReadAll()
                             join account in AccountRepository.ReadAll()
                             on client.Id equals account.Client_Id
                             join transaction in TransactionRepository.ReadAll()
                             on account.Account_Id equals transaction.Account_Id
                             select new
                             {
                                 Client_Id = client.Id,
                                 CreditTransactionTime = transaction.CreditTransactionTime,
                                 DebitTransactionTime = transaction.DebitTransactionTime
                             };
            var datesResult = tempResult.Where(x => (x.CreditTransactionTime.Month == DateTime.Now.Month && x.CreditTransactionTime.Year == DateTime.Now.Year) || (x.DebitTransactionTime.Month == DateTime.Now.Month && x.DebitTransactionTime.Year == DateTime.Now.Year));

            var finalResult = from selected in datesResult
                              join client in ClientRepository.ReadAll()
                              on selected.Client_Id equals client.Id
                              select new Client
                              {
                                  Id = selected.Client_Id,
                                  State = client.State,
                                  Address = client.Address,
                                  BirthDate = client.BirthDate,
                                  City = client.City,
                                  MobilNumber = client.MobilNumber,
                                  MotherName = client.MotherName,
                                  Name = client.Name,
                              };
            return finalResult;                                                 
        }
    }
}
