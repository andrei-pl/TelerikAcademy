namespace BullsAndCows.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Game : BaseEntry
    {
        private ICollection<Guess> guesses;

        public Game()
        {
            this.GameState = GameState.AvailableForJoining;
            this.guesses = new HashSet<Guess>();
            this.BlueId = new Guid();
            this.RedId = new Guid();
        }
        public string Name { get; set; }

        [Required]
        public virtual Guid RedId { get; set; }

        public virtual User RedUser { get; set; }

        public virtual Guid BlueId { get; set; }

        public virtual User BlueUser { get; set; }

        public virtual GameState GameState { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual ICollection<Guess> Guesses
        {
            get
            {
                return this.guesses;
            }
            set
            {
                this.guesses = value;
            }
        }
    }
}
