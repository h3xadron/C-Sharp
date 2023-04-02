using INNZ0S_HFT_2022231.Models.Entities;
using INNZ0S_HFT_2022231.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INNZ0S_HFT_2022231.Repository.Repositories
{
    public class TransactionRepository : RepositoryParent<Transaction, int>, ITransactionRepository
    {
        public TransactionRepository(DbContext context) : base(context)
        {
        }
        public override Transaction Read(int id)
        {
            return ReadAll().SingleOrDefault(x => x.Transaction_Id == id);
        }
        public void Delete(int id)
        {
            Delete(Read(id));
        }
    
    }
}
