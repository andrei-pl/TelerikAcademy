namespace BullsAndCows.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Guess : BaseEntry
    {
        [Required]
        public virtual Guid UserId { get; set; }

        public virtual User User { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public int GameId { get; set; }

        public virtual Game Game { get; set; }

        [Required]
        public int Number { get; set; }

        public DateTime DateMade { get; set; }

        [Required]
        public int CowsCount { get; set; }

        [Required]
        public int BullsCount { get; set; }
    }
}
