namespace StudentSystem.Data.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> All();

        IQueryable<T> Search(Expression<Func<T, bool>> condition);

        //T GetById(object id);

        void Add(T entity);

        T Delete(T entity);

        void Update(T entity);

        void Detach(T entity);

        void SaveChanges();
    }
}
