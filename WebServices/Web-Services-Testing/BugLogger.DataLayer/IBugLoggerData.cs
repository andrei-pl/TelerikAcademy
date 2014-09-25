namespace BugLogger.DataLayer
{
    using BugLogger.DataLayer.Repositories;
    using BugLogger.Models;

    public interface IBugLoggerData
    {
        IGenericRepository<Bug> Bugs { get; }

        void SaveChanges();

        void Dispose();
    }
}
