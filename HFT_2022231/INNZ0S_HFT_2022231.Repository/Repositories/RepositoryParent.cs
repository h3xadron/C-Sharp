using INNZ0S_HFT_2022231.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INNZ0S_HFT_2022231.Repository.Repositories
{
    public abstract class RepositoryParent<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class
    {

        protected DbContext Context;

        protected RepositoryParent(DbContext context)
        {
            Context = context;
        }

        public IQueryable<TEntity> ReadAll()
        {
            return Context.Set<TEntity>();
        }

        public TEntity Create(TEntity entity)
        {
            var result = Context.Set<TEntity>().Add(entity);
            Context.SaveChanges();
            
            return result.Entity;
        }

        public void Delete(TEntity entity)
        {
            Context.Remove(entity);
            Context.SaveChanges();
        }

        public abstract TEntity Read(TKey id);

        public TEntity Update(TEntity entity)
        {
            var result = Context.Set<TEntity>().Update(entity);
            Context.SaveChanges();

            return result.Entity;
        }
    }
}
