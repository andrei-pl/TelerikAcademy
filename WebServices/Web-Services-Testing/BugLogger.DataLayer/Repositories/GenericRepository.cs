﻿namespace BugLogger.DataLayer.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using BugLogger.Models;
    using System.Data.Entity.Infrastructure;

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private IBugLoggerDbContext context;
        private IDbSet<T> set;

        public GenericRepository(IBugLoggerDbContext context)
        {
            this.context = context;
            this.set = context.Set<T>();
        }

        public IQueryable<T> All()
        {
            return this.set.AsQueryable();
        }

        public IQueryable<T> SearchFor(System.Linq.Expressions.Expression<Func<T, bool>> conditions)
        {
            return this.All().Where(conditions);
        }

        public void Add(T entity)
        {
            var entry = this.AttachIfDetached(entity);
            entry.State = EntityState.Added;
        }

        public void Update(T entity)
        {
            var entry = this.AttachIfDetached(entity);
            entry.State = EntityState.Modified;
        }

        public void Save()
        {
            this.context.SaveChanges();
        }

        public void Delete(T entity)
        {
            var entry = this.AttachIfDetached(entity);
            entry.State = EntityState.Deleted;
        }

        public T Find(T entity)
        {
            return this.set.Find(entity);
        }

        public void Detach(T entity)
        {
            var entry = this.context.Entry(entity);
            entry.State = EntityState.Detached;
        }

        private DbEntityEntry AttachIfDetached(T entity)
        {
            var entry = this.context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.set.Attach(entity);
            }

            return entry;
        }
    }
}
