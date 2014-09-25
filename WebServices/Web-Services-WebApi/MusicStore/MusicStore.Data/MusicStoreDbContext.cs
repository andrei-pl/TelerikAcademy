namespace MusicStore.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Migrations;

    using MusicStore.Data.Migrations;
    using MusicStore.Models;

    public class MusicStoreDbContext : DbContext, IMusicStoreDbContext
    {
        public MusicStoreDbContext()
            : base("MusicStore")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MusicStoreDbContext, Configuration>());
        }

        public IDbSet<Album> Albums { get; set; }

        public IDbSet<Artist> Artists { get; set; }

        public IDbSet<Song> Songs { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}
