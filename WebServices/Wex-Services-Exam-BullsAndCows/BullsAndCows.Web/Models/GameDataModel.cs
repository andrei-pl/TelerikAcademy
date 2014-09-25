namespace BullsAndCows.Web.Models
{
    using BullsAndCows.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web;

    public class GameDataModel : BaseDataModelEntry
    {
        private ICollection<GuessDataModel> guesses;

        public GameDataModel()
        {
            this.GameState = GameState.AvailableForJoining;
            this.guesses = new HashSet<GuessDataModel>();
        }

        public static Expression<Func<Game, GameDataModel>> FromGame
        {
            get
            {
                return a => new GameDataModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    RedId = a.RedId,
                    BlueId = a.BlueId,
                    GameState = a.GameState,
                    DateCreated = a.DateCreated,
                    Guesses = a.Guesses.AsQueryable().Select(GuessDataModel.FromGuess).ToList(),
                };
            }
        }

        public string Name { get; set; }

        [Required]
        public Guid RedId { get; set; }

        public Guid BlueId { get; set; }

        public virtual GameState GameState { get; set; }

        public DateTime DateCreated { get; set; }

        public ICollection<GuessDataModel> Guesses
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