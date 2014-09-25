namespace MusicStore.Models
{
    using System.Collections.Generic;

    public class Album
    {
        private ICollection<Song> songs;

        private ICollection<Artist> artists;

        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public string Producer { get; set; }
        public Album()
        {
            this.Songs = new HashSet<Song>();
            this.Artists = new HashSet<Artist>();
        }
        public virtual ICollection<Artist> Artists
        {
            get
            {
                return this.artists;
            }
            set
            {
                this.artists = value;
            }
        }

        public virtual ICollection<Song> Songs
        {
            get
            {
                return this.songs;
            }
            set
            {
                this.songs = value;
            }
        }
    }
}
