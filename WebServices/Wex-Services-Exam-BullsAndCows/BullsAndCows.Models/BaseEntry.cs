namespace BullsAndCows.Models
{
    using System.ComponentModel.DataAnnotations;

    public class BaseEntry
    {
        [Key]
        public int Id { get; set; }
    }
}
