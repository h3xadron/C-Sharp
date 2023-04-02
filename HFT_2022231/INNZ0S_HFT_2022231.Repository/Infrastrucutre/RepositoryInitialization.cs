using INNZ0S_HFT_2022231.Repository.DbContexts;
using INNZ0S_HFT_2022231.Repository.Interfaces;
using INNZ0S_HFT_2022231.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INNZ0S_HFT_2022231.Repository.Infrastrucutre
{
    public static class RepositoryInitialization
    {
        public static void InitRepoServices(IServiceCollection services)
        {
            services.AddScoped<DbContext, NetBankDbContext>(); 
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
        }
    }
}
