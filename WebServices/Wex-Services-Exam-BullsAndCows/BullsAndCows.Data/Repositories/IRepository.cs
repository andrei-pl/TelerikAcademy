using System;
namespace BullsAndCows.Data.Repositories
{
    public interface IRepository<T>
    {
        void Add(T entity);

        System.Linq.IQueryable<T> All();

        T Delete(T entity);

        void Detach(T entity);

        T Find(object id);

        void SaveChanges();

        void Update(T entity);
    }
}
