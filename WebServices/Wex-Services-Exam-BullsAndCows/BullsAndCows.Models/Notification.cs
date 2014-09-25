namespace BullsAndCows.Models
{
    using System;
    using System.Linq;

    public class Notification : BaseEntry
    {
        public int GameId { get; set; }

        public virtual Game Game { get; set; }

        public string Message { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
