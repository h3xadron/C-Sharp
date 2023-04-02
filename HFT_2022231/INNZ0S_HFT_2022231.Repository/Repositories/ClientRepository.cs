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
    public class ClientRepository : RepositoryParent<Client, int>, IClientRepository
    {
        public ClientRepository(DbContext context) : base(context)
        {
        }
        public override Client Read(int id)
        {
            return ReadAll().SingleOrDefault(x => x.Id == id);
        }

        public void Delete(int id)
        {
            Delete(Read(id));
        }

    }
}
