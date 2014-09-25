namespace StudentSystem.Data.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public IStudentSystemDBContext context;
        public GenericRepository(IStudentSystemDBContext context)
        {
            this.context = context;
        }

        public IQueryable<T> All()
        {
            return this.context.Set<T>();
        }

        public IQueryable<T> Search(Expression<Func<T, bool>> condition)
        {
            return this.All().Where(condition);
        }

        public void Add(T entity)
        {
            ChangeState(entity, EntityState.Added);
        }

        public T Delete(T entity)
        {
            ChangeState(entity, EntityState.Deleted);
            return entity;
        }

        public void Update(T entity)
        {
            ChangeState(entity, EntityState.Modified);
        }

        public void Detach(T entity)
        {
            ChangeState(entity, EntityState.Detached);
        }

        private void ChangeState(T entity, EntityState state)
        {
            this.context.Set<T>().Attach(entity);
            this.context.Entry(entity).State = state;
        }


        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}
