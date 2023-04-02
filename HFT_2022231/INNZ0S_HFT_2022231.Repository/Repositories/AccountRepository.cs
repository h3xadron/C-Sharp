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
    public class AccountRepository : RepositoryParent<Account, int>, IAccountRepository
    {
        public AccountRepository(DbContext context) : base(context)
        {
        }

        public override Account Read(int id)
        {
            return ReadAll().SingleOrDefault(x => x.Account_Id == id);
        }
        public void Delete(int id)
        {
            Delete(Read(id));
        }


    }
}
