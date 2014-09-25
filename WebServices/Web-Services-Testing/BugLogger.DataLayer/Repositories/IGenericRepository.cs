namespace BugLogger.DataLayer.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IGenericRepository<T>
    {
        void Add(T entity);

        IQueryable<T> SearchFor(Expression<Func<T, bool>> conditions);

        T Find(T entity);

        IQueryable<T> All();

        void Delete(T entity);

        void Update(T entity);

        void Detach(T entity);

        void Save();
    }
}
