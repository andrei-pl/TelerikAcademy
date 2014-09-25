namespace BugLogger.DataLayer
{
    using BugLogger.Models;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public interface IBugLoggerDbContext
    {
        IDbSet<Bug> Bugs { get; set; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        void SaveChanges();

        void Dispose();
    }
}
