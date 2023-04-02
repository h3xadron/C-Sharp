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
    public class TransactionServices : ITransactionServices
    {
        ITransactionRepository TransactionRepository;
        IAccountRepository AccountRepository;
        public TransactionServices(ITransactionRepository transactionRepository, IAccountRepository accountRepository)
        {
            TransactionRepository = transactionRepository;
            AccountRepository = accountRepository;
        }



        public Transaction Create(Transaction transaction)
        {
            if (AccountRepository.Read(transaction.Account_Id) == null)
            {
                throw new ApplicationException("Not valid account id.");
            }
            var result = TransactionRepository.Create(transaction);

            return result;

        }

        public void Delete(int id)
        {
            if (TransactionRepository.Read(id) == null)
            {
                throw new ApplicationException("Not valid id.");
            }

            


            TransactionRepository.Delete(id);
        }

        public Transaction Read(int id)
        {
            var result = TransactionRepository.Read(id);
            return result;
        }

        public List<Transaction> ReadAll()
        {
            return TransactionRepository.ReadAll().ToList();
        }

        

        public Transaction Update(Transaction transaction)
        {
            if (AccountRepository.Read(transaction.Account_Id) == null)
            {
                throw new ApplicationException("Not valid account id.");
            }

            var temp = TransactionRepository.Read(transaction.Transaction_Id);
            var result = TransactionRepository.Update(temp);
            return result;

        }
        public IEnumerable<Transaction> TransactionsWithoutCreditCard()
        {
            var result = TransactionRepository.ReadAll().Where(t => AccountRepository.ReadAll().Where(k => !k.CreditCard).Select(x => x.Account_Id).Contains(t.Account_Id));
            return result;
        }
    }
}
