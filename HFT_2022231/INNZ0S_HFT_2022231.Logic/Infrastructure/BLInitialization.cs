using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INNZ0S_HFT_2022231.Repository.Infrastrucutre;
using INNZ0S_HFT_2022231.Logic.Interfaces;
using INNZ0S_HFT_2022231.Logic.Services;

namespace INNZ0S_HFT_2022231.Logic.Infrastructure
{
    public static class BLInitialization
    {
        public static void InitBLServices(IServiceCollection services)
        {
            RepositoryInitialization.InitRepoServices(services);
            services.AddScoped<IAccountServices, AccountServices>();
            services.AddScoped<IClientServices, ClientServices>();
            services.AddScoped<ITransactionServices, TransactionServices>();
        }
    }
}
