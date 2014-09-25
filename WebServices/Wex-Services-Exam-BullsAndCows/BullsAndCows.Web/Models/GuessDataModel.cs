namespace BullsAndCows.Web.Models
{
    using BullsAndCows.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web;

    public class GuessDataModel : BaseDataModelEntry
    {
        public static Expression<Func<Guess, GuessDataModel>> FromGuess
        {
            get
            {
                return a => new GuessDataModel
                {
                    Id = a.Id,
                    UserId = a.UserId,
                    UserName = a.UserName,
                    GameId = a.GameId,
                    Number = a.Number,
                    DateMade = a.DateMade,
                    CowsCount = a.CowsCount,
                    BullsCount = a.BullsCount
                };
            }
        }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public int GameId { get; set; }

        [Required]
        public int Number { get; set; }

        public DateTime DateMade { get; set; }

        [Required]
        public int CowsCount { get; set; }

        [Required]
        public int BullsCount { get; set; }
    }
}