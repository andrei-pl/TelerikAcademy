using MusicStore.Data.Repositories;
using MusicStore.Models;
namespace MusicStore.Data
{
    public interface IMusicStoreData
    {
        IRepository<Album> Albums { get; }
       
        IRepository<Song> Songs { get; }

        ArtistsRepository Artist { get; }
    }
}
