using BullsAndCows.Data.Repositories;
using BullsAndCows.Models;
using System;
using System.Collections.Generic;
namespace BullsAndCows.Data
{
    public class BullsAndCowsData : IBullsAndCowsData
    {
        private BullsAndCowsDbContext context;
        private IDictionary<Type, object> repositories;

        public BullsAndCowsData(BullsAndCowsDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }
        
        public IRepository<Game> Games
        {
            get
            {
                return this.GetRepository<Game>();
            }
        }

        public IRepository<Guess> Guesses
        {
            get
            {
                return this.GetRepository<Guess>();
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);

            if (!this.repositories.ContainsKey(typeOfModel))
            {
                this.repositories.Add(typeOfModel, Activator.CreateInstance(typeof(Repository<T>), this.context));
            }

            return (IRepository<T>)this.repositories[typeOfModel];
        }
    }
}
