using INNZ0S_HFT_2022231.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using static INNZ0S_HFT_2022231.Models.Entities.Account;
using static INNZ0S_HFT_2022231.Models.Entities.Client;
using static INNZ0S_HFT_2022231.Models.Entities.Transaction;

namespace INNZ0S_HFT_2022231.Repository.DbContexts
{
    public  class NetBankDbContext : DbContext
    {
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }


        public NetBankDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("NetBankDb")
                          .UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Client>(client => 
            client.HasMany(x => x.Accounts)
                .WithOne(x => x.Client)
                .OnDelete(DeleteBehavior.NoAction));

            modelBuilder.Entity<Account>(account => 
            account.HasOne(x => x.Client)
                .WithMany(x => x.Accounts)
                .HasForeignKey(x => x.Client_Id)
                .OnDelete(DeleteBehavior.NoAction));

            modelBuilder.Entity<Account>(account => 
            account.HasMany(x => x.Transactions)
                .WithOne(x => x.Account)
                .OnDelete(DeleteBehavior.NoAction));

            modelBuilder.Entity<Transaction>(transaction => 
            transaction.HasOne(x => x.Account)
                .WithMany(x => x.Transactions)
                .HasForeignKey(x => x.Account_Id)
                .OnDelete(DeleteBehavior.NoAction));

            #region Seed data

            var rnd = new Random();

            var clients = new List<Client>()
            {
                new Client(1, "Shelby A. Claypool", "Anderson Her", "CA" , "Urbandale","A street 12. " , new System.DateTime(1968,02,26), 4088419485),
                new Client(2, "Romona D. Pike", "Elliot Glover", "IL", "Boston","B street 123.", new System.DateTime(1948, 01, 02), 7088147187),
                new Client(3, "Lydia R. Her", "Henry Hargreaves", "IA", "Urbandale","C street 1234.", new System.DateTime(1946, 04, 06), 6173561644),
                new Client(4, "Greta J. Lafrance", "Henry Hargreaves", "IA", "Urbandale","F street 12345.", new System.DateTime(1966, 02, 26), 6173561644),
                new Client(5, "Faith Walker", "Gail D. Elder", "TX", "Corpus Christi","G street 123456.", new System.DateTime(1992, 07, 16), 4573561644),
                new Client(6, "Chester M. Runnels", "Runnels Noe", "CO", "Gypsum","H street 1234567.", new System.DateTime(1992, 07, 16), 9702770015),
                new Client(7, "Random K. Tadm", "Tadm Chloe", "TX", "Austin","Y street 12345678.", new System.DateTime(1962, 05, 26), 19702770015)
            };

            var accounts = new List<Account>()
            {
            new Account(1, clients[0].Id, 300000, true, 1000, false, 0,CreditCurrencyType.star, DebitCurrencyType.none),
            new Account(2, clients[1].Id, 300001, true, 1000, false, 0,CreditCurrencyType.star, DebitCurrencyType.none),
            new Account(3, clients[2].Id, 300002, true, 1000, false, 0,CreditCurrencyType.star, DebitCurrencyType.none),
            new Account(4, clients[3].Id, 300003, true, 1000, false, 0,CreditCurrencyType.star, DebitCurrencyType.none),
            new Account(5, clients[4].Id, 300004, true, 1000, false, 0,CreditCurrencyType.star, DebitCurrencyType.none),
            new Account(6, clients[5].Id, 300005, true, 1000, true, 0,CreditCurrencyType.star, DebitCurrencyType.none),
            new Account(7, clients[6].Id, 300006, true, 1000, false, 0,CreditCurrencyType.star, DebitCurrencyType.none),
            new Account(8, clients[6].Id, 300007, true, 1000, false, 0,CreditCurrencyType.star, DebitCurrencyType.none)
            };

            

            var transactions = new List<Transaction>()
            {
                new Transaction(1,clients[0].Id,DateTime.Now,2000,new System.DateTime((int)rnd.Next(2000,2023),(int)rnd.Next(1,12),(int)rnd.Next(1,30)), 2000, new System.DateTime((int)rnd.Next(2000,2023),(int)rnd.Next(1,12),(int)rnd.Next(1,30)), 20000 ),
                new Transaction(2,clients[0].Id,new System.DateTime((int)rnd.Next(2000,2023),(int)rnd.Next(1,12),(int)rnd.Next(1,28)),2000,new System.DateTime((int)rnd.Next(2000,2023),(int)rnd.Next(1,12),(int)rnd.Next(1,28)), 2000, new System.DateTime((int)rnd.Next(2000,2023),(int)rnd.Next(1,12),(int)rnd.Next(1,28)), 20000 ),
                new Transaction(3,clients[0].Id,new System.DateTime((int)rnd.Next(2000,2023),(int)rnd.Next(1,12),(int)rnd.Next(1,28)),2000,new System.DateTime((int)rnd.Next(2000,2023),(int)rnd.Next(1,12),(int)rnd.Next(1,28)), 2000, new System.DateTime((int)rnd.Next(2000,2023),(int)rnd.Next(1,12),(int)rnd.Next(1,28)), 20000 ),
                new Transaction(4,clients[4].Id,new System.DateTime((int)rnd.Next(2000,2023),(int)rnd.Next(1,12),(int)rnd.Next(1,28)),2000,new System.DateTime((int)rnd.Next(2000,2023),(int)rnd.Next(1,12),(int)rnd.Next(1,28)), 2000, new System.DateTime((int)rnd.Next(2000,2023),(int)rnd.Next(1,12),(int)rnd.Next(1,28)), 20000 ),
                new Transaction(5,clients[4].Id,new System.DateTime((int)rnd.Next(2000,2023),(int)rnd.Next(1,12),(int)rnd.Next(1,28)),2000,new System.DateTime((int)rnd.Next(2000,2023),(int)rnd.Next(1,12),(int)rnd.Next(1,28)), 2000, new System.DateTime((int)rnd.Next(2000,2023),(int)rnd.Next(1,12),(int)rnd.Next(1,28)), 20000 ),
                new Transaction(6,clients[5].Id,new System.DateTime((int)rnd.Next(2000,2023),(int)rnd.Next(1,12),(int)rnd.Next(1,28)),2000,new System.DateTime((int)rnd.Next(2000,2023),(int)rnd.Next(1,12),(int)rnd.Next(1,28)), 2000, new System.DateTime((int)rnd.Next(2000,2023),(int)rnd.Next(1,12),(int)rnd.Next(1,28)), 20000 ),
                new Transaction(7,clients[5].Id,new System.DateTime((int)rnd.Next(2000,2023),(int)rnd.Next(1,12),(int)rnd.Next(1,28)),2000,new System.DateTime((int)rnd.Next(2000,2023),(int)rnd.Next(1,12),(int)rnd.Next(1,28)), 2000, new System.DateTime((int)rnd.Next(2000,2023),(int)rnd.Next(1,12),(int)rnd.Next(1,28)), 20000 ),
                new Transaction(8,clients[6].Id,new System.DateTime((int)rnd.Next(2000,2023),(int)rnd.Next(1,12),(int)rnd.Next(1,28)),2000,new System.DateTime((int)rnd.Next(2000,2023),(int)rnd.Next(1,12),(int)rnd.Next(1,28)), 2000, new System.DateTime((int)rnd.Next(2000,2023),(int)rnd.Next(1,12),(int)rnd.Next(1,28)), 20000 ),
            };

            modelBuilder.Entity<Client>().HasData(clients);
            modelBuilder.Entity<Account>().HasData(accounts);
            modelBuilder.Entity<Transaction>().HasData(transactions);


            
        #endregion

        }

    }
}
