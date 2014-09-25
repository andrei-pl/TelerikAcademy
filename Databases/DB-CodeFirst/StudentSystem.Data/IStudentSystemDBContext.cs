namespace StudentSystem.Data
{
    using System.Data.Entity;

    using StudentSystem.Model;
    using System.Data.Entity.Infrastructure;

    public interface IStudentSystemDBContext
    {
        IDbSet<Student> Students { get; set; }

        IDbSet<Course> Courses { get; set; }

        IDbSet<Homework> Homeworks { get; set; }

        IDbSet<Test> Tests { get; set; }

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();
    }
}
