using INNZ0S_HFT_2022231.Logic.Interfaces;
using INNZ0S_HFT_2022231.Models.Entities;
using INNZ0S_HFT_2022231.Repository.Interfaces;
using INNZ0S_HFT_2022231.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace INNZ0S_HFT_2022231.Logic.Services
{
    public class AccountServices : IAccountServices
    {
        IAccountRepository AccountRepository;
        IClientRepository ClientRepository;
        ITransactionRepository TransactionRepository;

        public AccountServices(IAccountRepository accountRepository, IClientRepository clientRepository, ITransactionRepository transactionRepository)
        {
            AccountRepository = accountRepository;
            ClientRepository = clientRepository;
            TransactionRepository = transactionRepository;
        }

        public Account Create(Account account)
        {
            if (ClientRepository.Read(account.Client_Id) == null)
            {
                throw new ApplicationException("Not valid client id.");
            }
            var result = AccountRepository.Create(account);

            return result;
        }

        public void Delete(int id)
        {
            if (AccountRepository.Read(id) == null)
            {
                throw new ApplicationException("Not valid id.");
            }

            var Transaction_temp = TransactionRepository.ReadAll();

            Transaction_temp = Transaction_temp.Where(t => t.Account_Id == id);

            if (Transaction_temp.Count() != 0)
            {
                foreach (var item in Transaction_temp)
                {
                    TransactionRepository.Delete(item.Transaction_Id);
                }
            }

            AccountRepository.Delete(id);

        }

        public Account Read(int id)
        {
            var result = AccountRepository.Read(id);


            return result;
        }

        public List<Account> ReadAll()
        {
            return AccountRepository.ReadAll().ToList();
        }

        public Account Update(Account account)
        {
            if (ClientRepository.Read(account.Client_Id) == null)
            {
                throw new ApplicationException("No valid client has been given.");
            }
            var temp = AccountRepository.Read(account.Account_Id);
            temp.AccountSum = account.AccountSum;  
            temp.DebitLimit = account.DebitLimit;
            temp.CreditLimit = account.CreditLimit; 
            temp.CreditCard = account.CreditCard;
            temp.DebitCard = account.DebitCard; 
            temp.DebitType = account.DebitType;
            temp.CreditType = account.CreditType;   
            var result = AccountRepository.Update(temp);
            return result;
        }
        public IEnumerable<Account> AccountsMadeByTexanClient()
        {
            var result = AccountRepository.ReadAll().Where(x => ClientRepository.ReadAll().Where(y => y.State == "TX").Select(z => z.Id).Contains(x.Client_Id));

            return result;
        }
    }
}
