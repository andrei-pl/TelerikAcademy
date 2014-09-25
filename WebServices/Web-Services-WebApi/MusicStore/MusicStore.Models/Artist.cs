namespace MusicStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Artist
    {
        private ICollection<Album> albums;
        private ICollection<Song> songs;

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Country { get; set; }

        public Artist()
        {
            this.Albums = new HashSet<Album>();
            this.Songs = new HashSet<Song>();
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

        public virtual ICollection<Album> Albums
        {
            get
            {
                return this.albums;
            }
            set
            {
                this.albums = value;
            }
        }

        public DateTimeOffset? BirthDate
        {
            get
            {
                return birthDate.HasValue ? new DateTimeOffset(birthDate.Value, TimeSpan.FromHours(0)) : (DateTimeOffset?)null;
            }
            set
            {
                birthDate = value.HasValue ? value.Value.UtcDateTime : (DateTime?)null;
            }
        }

        [NotMapped]
        private Nullable<DateTime> birthDate;
    }
}
