namespace MusicStore.Data.Repositories
{
    using MusicStore.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ArtistsRepository : Repository<Artist>, IRepository<Artist>
    {
        private MusicStoreDbContext context;

        public ArtistsRepository() : this(new MusicStoreDbContext())
        {
        }

        public ArtistsRepository(MusicStoreDbContext musicStoreDbContext)
        {
            this.context = musicStoreDbContext;
        }

        public IQueryable<Album> GetAllAlbums()
        {
            return this.All().Where(a => a.Albums.Count() > 0) as IQueryable<Album>;
        }

        public IQueryable<Song> GetAllSongs()
        {
            return this.All().Where(s => s.Songs.Count() > 0) as IQueryable<Song>;
        }
    }
}
